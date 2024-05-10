

namespace RecordManagement.Application.Services.UserProfile;

public interface IUserProfileIAuthenticationService 
{
        UserProfileAuthenticationResult UserProfile (
            string firstName,
            string lastName,
            string username,
            string password,
            string email, 
            string contact);
        
}