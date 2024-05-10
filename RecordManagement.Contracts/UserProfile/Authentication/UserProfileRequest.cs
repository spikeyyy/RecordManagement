namespace RecordManagement.Contracts.UserProfile.Authentication;


public record UserProfileRequest(
    string username,
    string password,
    string email,
    string firstName,
    string lastName,
    string contact


);