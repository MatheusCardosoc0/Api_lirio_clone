using Api.Models.Utilitarios;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService
{
    private readonly IConfiguration _config;

    public TokenService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(UserSystem user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            // You can add more claims if needed
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_config["JWTSettings:Issuer"],
            _config["JWTSettings:Audience"],
            claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
