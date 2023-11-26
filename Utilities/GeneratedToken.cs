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
            new Claim("userName", user.Name),
            user.Person.urlImage != null ? new Claim("urlImage", user.Person.urlImage) : null,
            new Claim("id", user.Id.ToString()),
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

    public Dictionary<string, string> ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = GetValidationParameters();

        SecurityToken validatedToken;
        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            var claims = principal.Claims;

            // Handle potential duplicates by grouping claims
            var claimsDictionary = claims
                .GroupBy(c => c.Type)
                .ToDictionary(g => g.Key, g => g.Select(c => c.Value).FirstOrDefault());

            return claimsDictionary;
        }
        catch (Exception e)
        {
            // Optionally, handle or log the exception here
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
