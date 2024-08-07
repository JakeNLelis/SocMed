using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.Interfaces;
using backend.Models;
using dotenv.net;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace backend.Services;

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;
    // private readonly IDictionary<string, string> _secrets;
    IDictionary<string, string> _secrets = DotEnv.Read();

    public TokenService()
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secrets["JWTSigningKey"]));
    }

    public string CreateToken(AppUser user)
    {
#pragma warning disable CS8604 // Possible null reference argument.
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Email, user.Email),
            new (JwtRegisteredClaimNames.GivenName, user.UserName)
        };
#pragma warning restore CS8604 // Possible null reference argument.

        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(3),
            SigningCredentials = credentials,
            Issuer = _secrets["JWTIssuer"],
            Audience = _secrets["JWTAudience"],
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
