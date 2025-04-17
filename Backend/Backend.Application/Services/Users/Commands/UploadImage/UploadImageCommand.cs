using Backend.Application.Services.Users.Common;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Users.Commands.UploadImage;

public record UploadImageCommand(
    Guid Id,
    string ContentType,
    Stream Stream
) : IRequest<ErrorOr<UploadImageResult>>;