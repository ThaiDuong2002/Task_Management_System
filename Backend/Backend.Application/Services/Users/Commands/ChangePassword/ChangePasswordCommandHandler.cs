using Backend.Application.Common.Interfaces.Authentication;
using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Users.Common;
using Backend.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Users.Commands.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ErrorOr<ChangePasswordResult>>
{
    private readonly ISecurePasswordProvider _securePasswordProvider;
    private readonly IUserRepository _userRepository;

    public ChangePasswordCommandHandler(IUserRepository userRepository, ISecurePasswordProvider securePasswordProvider)
    {
        _userRepository = userRepository;
        _securePasswordProvider = securePasswordProvider;
    }

    public async Task<ErrorOr<ChangePasswordResult>> Handle(ChangePasswordCommand command,
        CancellationToken cancellationToken)
    {
        // 1. Check if the user exists
        var user = await _userRepository.GetUserById(command.UserId);
        if (user is null) return Errors.User.NotFound;

        // 2. Check if the old password is correct
        if (!_securePasswordProvider.Verify(command.OldPassword, user.PasswordHash, user.Email))
            return Errors.User.InvalidPassword;

        // 3. Change the password
        user.PasswordHash = _securePasswordProvider.Encrypt(command.NewPassword, user.Email);

        // 4. Save the changes
        var result = await _userRepository.ChangePassword(user.Id!.Value.ToString(), user.PasswordHash);

        // 5. Check if the update was successful
        if (result == 0) return Errors.User.UpdateFailed;
        
        // 6. Delete the refresh token
        await _userRepository.DeleteRefreshToken(user.Id!.Value.ToString());

        // 6. Return the updated user
        return new ChangePasswordResult(
            user.Id!.Value
        );
    }
}