﻿namespace Backend.Infrastructure.Cloudinary;

public class CloudinarySettings
{
    public const string SectionName = "Cloudinary";
    public string CloudName { get; init; } = null!;
    public string ApiKey { get; init; } = null!;
    public string ApiSecret { get; init; } = null!;
}