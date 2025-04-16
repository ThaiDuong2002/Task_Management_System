namespace Backend.Contracts.Users;

public record ChangePasswordRequest(
    string OldPassword,
    string NewPassword
);