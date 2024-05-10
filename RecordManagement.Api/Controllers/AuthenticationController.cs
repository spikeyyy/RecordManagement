using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RecordManagement.Application.Services.Authentication;
using RecordManagement.Contracts.Authentication;
using RegisterRequest = RecordManagement.Contracts.Authentication.RegisterRequest;
using LoginRequest = RecordManagement.Contracts.Authentication.LoginRequest;
using RecordManagement.Contracts.UserProfile.Authentication;

namespace RecordManagement.Api.Controllers;

[ApiController]
[Route("auth")] // api route
public class AuthenticationController(IAuthenticationServices authenticationServices) : ControllerBase
{
    private readonly IAuthenticationServices _authenticationService = authenticationServices;

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
           request.Email,
           request.Password,
           request.FirstName,
           request.LastName
       );

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );

        return Ok(response);
    }


}