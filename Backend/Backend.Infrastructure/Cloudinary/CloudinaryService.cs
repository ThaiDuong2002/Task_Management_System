using Backend.Application.Common.Interfaces.Cloudinary;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Cloudinary;

public class CloudinaryService : ICloudinaryService
{
    public Task<string> UploadImageAsync(IFormFile file, string folderName)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadImageAsync(string imageUrl, string folderName)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadImageAsync(byte[] imageBytes, string folderName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteImageAsync(string imageUrl)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteImageAsync(byte[] imageBytes)
    {
        throw new NotImplementedException();
    }
}