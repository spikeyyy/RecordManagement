
using RecordManagement.Application.Common.Interfaces.Persistence;
using RecordManagement.Domain.Entities;

namespace RecordManagement.Application.Services.UserProfile;


public class UserProfileAuthenticationServices : IUserProfileIAuthenticationService
{

    private readonly IUserProfileRepository _userProfileRepository;

    public UserProfileAuthenticationServices(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public UserProfileAuthenticationResult UserProfile(string firstName, string lastName, string username, string password, string email, string contact)
    {

        if (_userProfileRepository.GetUserByEmail(email) is not null)
        {

            throw new Exception("User with given email is already exist ");
        }

        var userProfile = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Username = username,
            Password = password,
            Email = email,
            Contact = contact
        };

        return new UserProfileAuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            username,
            password,
            email,
            contact);
    }
}

