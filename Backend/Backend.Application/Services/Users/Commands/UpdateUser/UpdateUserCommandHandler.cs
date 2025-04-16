using Backend.Application.Common.Interfaces.Persistence;
using Backend.Application.Services.Users.Common;
using Backend.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Backend.Application.Services.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<UpdateUserResult>>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UpdateUserResult>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        // 1. Check if the user exists
        var user = await _userRepository.GetUserById(command.UserId);
        if (user is null) return Errors.User.NotFound;

        // 2. Update the user
        if (!string.IsNullOrEmpty(command.FirstName)) user.FirstName = command.FirstName;

        if (!string.IsNullOrEmpty(command.LastName)) user.LastName = command.LastName;

        if (!string.IsNullOrEmpty(command.UserName)) user.UserName = command.UserName;

        // 3. Save the changes
        var result = await _userRepository.Update(user);

        // 4. Check if the update was successful
        if (result == 0) return Errors.User.UpdateFailed;

        // 5. Return the updated user
        return new UpdateUserResult(
            user.Id!.Value
        );
    }
}