namespace RecordManagement.Application.Services.UserProfile;


public record UserProfileAuthenticationResult(
            Guid Id,
            string firstName,
            string lastName,
            string username,
            string password,
            string email, 
            string contact
);