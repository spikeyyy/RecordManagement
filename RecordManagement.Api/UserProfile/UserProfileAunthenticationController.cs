using Microsoft.AspNetCore.Mvc;
using RecordManagement.Application.Services.UserProfile;
using RecordManagement.Contracts.UserProfile.Authentication;

namespace RecordManagement.Api.UserProfile;

[ApiController]
[Route("auth")]

public class IUserProfileAuthenticationService : ControllerBase
{

    private readonly IUserProfileIAuthenticationService _userProfileIAuthenticationService;

    public IUserProfileAuthenticationService(IUserProfileIAuthenticationService userProfileIAuthenticationService)
    {
        _userProfileIAuthenticationService = userProfileIAuthenticationService;
    }

    [HttpPost("userprofile")]
    public IActionResult UserProfile(UserProfileRequest request)
    {
        var authResult = _userProfileIAuthenticationService.UserProfile(
            request.firstName,
            request.lastName,
            request.username,
            request.password,
            request.email,
            request.contact);

        var response = new UserProfileAuthenticationResponse(
            authResult.Id,
            authResult.username,
            authResult.password,
            authResult.email,
            authResult.firstName,
            authResult.lastName,
            authResult.contact
        );

        return Ok(response);
    }


}