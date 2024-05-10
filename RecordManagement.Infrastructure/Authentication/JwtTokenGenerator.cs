using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RecordManagement.Application.Common.Interfaces.Authentication;
using System;
using System.Security.Cryptography;
using RecordManagement.Application.Services;
using Microsoft.Extensions.Options;

namespace RecordManagement.Infrastructure.Authentication;


public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dayTimeProvider;
    private readonly JwtSettings _jwtSettings;
    public JwtTokenGenerator(IDateTimeProvider dayTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dayTimeProvider = dayTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public static class JwtSecretKeyGenerator
    {
        public static byte[] GenerateSecretKey(int keySizeInBits)
        {
            using (var provider = new RNGCryptoServiceProvider())
            {
                var key = new byte[keySizeInBits / 8];
                provider.GetBytes(key);
                return key;
            }
        }
    }
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var secretKey = JwtSecretKeyGenerator.GenerateSecretKey(256);
   var signingCredentials = new SigningCredentials(
    new SymmetricSecurityKey(secretKey),
    SecurityAlgorithms.HmacSha256
);
      var claims = new[]
      {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      };


      var securityToken = new JwtSecurityToken(
        issuer: _jwtSettings.Issuer,
         audience: _jwtSettings.Audience,
        expires: _dayTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
        claims: claims,
        signingCredentials: signingCredentials
        
        
        );
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}