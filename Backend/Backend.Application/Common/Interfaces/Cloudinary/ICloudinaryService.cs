using Microsoft.AspNetCore.Http;

namespace Backend.Application.Common.Interfaces.Cloudinary;

public interface ICloudinaryService
{
    Task<string> UploadImageAsync(IFormFile file, string folderName);
    Task<string> UploadImageAsync(string imageUrl, string folderName);
    Task<string> UploadImageAsync(byte[] imageBytes, string folderName);
    Task<bool> DeleteImageAsync(string imageUrl);
    Task<bool> DeleteImageAsync(byte[] imageBytes);
}