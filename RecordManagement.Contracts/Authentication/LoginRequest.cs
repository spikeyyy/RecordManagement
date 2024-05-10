namespace RecordManagement.Contracts.Authentication;

public record LoginRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
);
