namespace Backend.Api.Common.Uploads;

public record ChangeImageRequest(
    IFormFile? File
);