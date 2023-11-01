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

    public string ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = GetValidationParameters();

        SecurityToken validatedToken;
        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            var nameClaim = principal?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            return nameClaim?.Value;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    private TokenValidationParameters GetValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:key"])),

            ValidateIssuer = true,
            ValidIssuer = _config["JWTSettings:Issuer"],

            ValidateAudience = true,
            ValidAudience = _config["JWTSettings:Audience"],

            ValidateLifetime = true,

        };
    }
}
