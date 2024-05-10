namespace RecordManagement.Contracts.UserProfile.Authentication;


public record UserProfileAuthenticationResponse(
    Guid Id,
    string username,
    string password,
    string email,
    string firstName,
    string lastName,
    string contact

);