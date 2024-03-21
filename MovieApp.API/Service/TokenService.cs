using Microsoft.IdentityModel.Tokens;
using MovieApp.API.Config;
using MovieApp.API.Models;
using MovieApp.Infra.Identity.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieApp.API.Service;

public class TokenService
{
    private readonly string _secret;
    private readonly TokenConfiguration _tokenConfiguration;
    public TokenService(string secret, TokenConfiguration tokenConfiguration)
    {
        this._secret = secret;
        this._tokenConfiguration = tokenConfiguration;
    }
    public TokenModel GenerateToken(Credential credential)
    {
        var claims = new[]
        {
            new Claim("Id", credential.id),
            new Claim("Email", credential.Email),
            new Claim("UserName", credential.UserName)
            
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_secret));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddHours(_tokenConfiguration.ExpireHours);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _tokenConfiguration.Issuer,
            audience: _tokenConfiguration.Audience,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
            );


        return new TokenModel()
        {
            Authenticated = true,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration,
            Message = "Token JWT Ok"
        };
    }
}
