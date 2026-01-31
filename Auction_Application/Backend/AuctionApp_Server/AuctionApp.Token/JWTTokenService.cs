using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace AuctionApp.Token;

/// <summary>
/// Class to handle Jwt tokens
/// </summary>
public sealed class JWTTokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly AuctionApp.Utilities.Utility _utility;

    public JWTTokenService(IConfiguration configuration, AuctionApp.Utilities.Utility utility)
    {
        _configuration = configuration;
        _utility = utility;
    }

    /// <summary>
    /// Method used to generate jwt token
    /// </summary>
    /// <param name="tokenPayload"></param>
    /// <returns></returns>
    public string GenerateToken(TokenPayload tokenPayload)
    {
        IConfigurationSection jwtSettings = _configuration.GetSection("Jwt");

        // Key to jwt token
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));

        // Signing credential
        SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

        string sessionExpiryMinutes = jwtSettings["SessionExpiryInMinute"]!;
        string sessionExpiryDays = jwtSettings["SessionExpiryInDays"]!;

        DateTime tokenExpiry = DateTime.UtcNow.AddDays(double.Parse(sessionExpiryDays)).AddMinutes(double.Parse(sessionExpiryMinutes));
        tokenPayload.TokenExpiry = tokenExpiry;

        string jwtPayload = _utility.EncryptData(JsonSerializer.Serialize(tokenPayload));
        string value = jwtPayload;

        // Claims
        IEnumerable<Claim> claim = [new Claim("payload", value)];


        JwtSecurityToken securityToken = new JwtSecurityToken(claims: claim, signingCredentials: creds);
        string jwtToken = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return jwtToken;
    }

    /// <summary>
    /// Method used to refresh token
    /// </summary>
    /// <param name="tokenPayload"></param>
    /// <returns></returns>
    public string RefreshToken(TokenPayload tokenPayload)
    {
        return GenerateToken(tokenPayload);
    }

    /// <summary>
    /// Method used to check if the token is still valid or expire
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool VerifyToken(string token)
    {
        throw new NotImplementedException();
    }
}
