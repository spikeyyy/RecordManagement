namespace RecordManagement.Application.Services.Authentication;

public interface IAuthenticationServices
{
    AuthenticationResult Register(string FirstName, string LastName, string Email, string Password);
    AuthenticationResult Login(string FirstName, string LastName, string Email, string Password);


}