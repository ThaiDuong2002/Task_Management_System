using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Backend.Application.Common.Interfaces.Cloudinary;

public interface ICloudinaryService
{
    Task<string?> UploadImageAsync(IFormFile file, string folderName);
    Task<string?> UploadFileAsync(Stream stream, string contentType, string folderName);
    string GetBoundary(MediaTypeHeaderValue contentType);
}