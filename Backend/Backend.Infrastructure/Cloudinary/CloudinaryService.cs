using Backend.Application.Common.Interfaces.Cloudinary;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace Backend.Infrastructure.Cloudinary;

public class CloudinaryService : ICloudinaryService
{
    private readonly CloudinaryDotNet.Cloudinary _cloudinary;

    public CloudinaryService(CloudinaryDotNet.Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<string?> UploadImageAsync(IFormFile file, string folderName)
    {
        if (file.Length <= 0) return null;

        await using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.Name, stream),
            Folder = folderName,
            Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
        if (uploadResult.Error != null) throw new Exception(uploadResult.Error.Message);

        return uploadResult.SecureUrl.ToString();
    }

    public async Task<string?> UploadFileAsync(Stream fileStream, string contentType, string folderName)
    {
        fileStream.Position = 0;
        var uploadResult = new ImageUploadResult();
        var boundary = GetBoundary(MediaTypeHeaderValue.Parse(contentType));

        var multipartReader = new MultipartReader(boundary, fileStream);

        var section = await multipartReader.ReadNextSectionAsync();

        while (section is not null)
        {
            var fileSection = section.AsFileSection();
            if (fileSection != null)
            {
                await using var memoryStream = new MemoryStream();
                await fileSection.FileStream!.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(fileSection.FileName, memoryStream),
                    PublicId = Path.GetFileNameWithoutExtension(fileSection.FileName),
                    Folder = folderName,
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null) return null;
                return uploadResult.SecureUrl.ToString();
            }

            section = await multipartReader.ReadNextSectionAsync();
        }

        return uploadResult.SecureUrl.ToString();
    }

    public string GetBoundary(MediaTypeHeaderValue contentType)
    {
        var boundary = HeaderUtilities.RemoveQuotes(contentType.Boundary).Value;
        if (string.IsNullOrWhiteSpace(boundary)) throw new InvalidDataException("Missing content-type boundary.");
        return boundary;
    }
}