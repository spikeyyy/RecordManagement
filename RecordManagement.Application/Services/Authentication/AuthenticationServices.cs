using RecordManagement.Application.Common.Interfaces.Authentication;

namespace RecordManagement.Application.Services.Authentication;

public class AuthenticationServices : IAuthenticationServices
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationServices(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }


    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {


        //check if user alreadu exitst 
        // create user (gen uniqie id )
        //create JWT token


        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);


        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token
        );
    }

    public AuthenticationResult Login(string email, string password, string firstName, string lastName)
    {
        return new AuthenticationResult(
           Guid.NewGuid(),
            firstName,
            lastName,
            email,
            "token"
        );
    }
}