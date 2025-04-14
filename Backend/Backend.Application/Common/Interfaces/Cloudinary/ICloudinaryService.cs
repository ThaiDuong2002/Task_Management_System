using Microsoft.AspNetCore.Http;

namespace Backend.Application.Common.Interfaces.Cloudinary;

public interface ICloudinaryService
{
    Task<string?> UploadImageAsync(IFormFile file, string folderName);
}