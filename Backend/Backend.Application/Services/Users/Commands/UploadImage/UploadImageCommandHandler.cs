using Backend.Application.Common.Interfaces.Cloudinary;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Users.Common;
using Backend.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Users.Commands.UploadImage;

public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, ErrorOr<UploadImageResult>>
{
    private readonly ICloudinaryService _cloudinaryService;
    private readonly IUserRepository _userRepository;

    public UploadImageCommandHandler(IUserRepository userRepository, ICloudinaryService cloudinaryService)
    {
        _userRepository = userRepository;
        _cloudinaryService = cloudinaryService;
    }


    public async Task<ErrorOr<UploadImageResult>> Handle(UploadImageCommand command,
        CancellationToken cancellationToken)
    {
        var imageUrl = await _cloudinaryService.UploadFileAsync(command.Stream, command.ContentType, "User");

        if (imageUrl is null) return Errors.User.UploadImageFailed;

        var result = await _userRepository.ChangeImage(command.Id, imageUrl);

        if (result == 0) return Errors.User.UpdateFailed;

        return new UploadImageResult(
            imageUrl
        );
    }
}