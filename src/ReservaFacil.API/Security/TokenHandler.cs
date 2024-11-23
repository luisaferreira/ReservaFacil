using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ReservaFacil.API.Security;

public class TokenHandler
{
    private readonly string _secret;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _expiracaoHoras;

    public TokenHandler(IConfiguration configuration)
    {
        _secret = Environment.GetEnvironmentVariable("ReservaFacil_JwtSettings_Secret");
        _issuer = Environment.GetEnvironmentVariable("ReservaFacil_JwtSettings_Issuer");
        _audience = Environment.GetEnvironmentVariable("ReservaFacil_JwtSettings_Audience");
        _expiracaoHoras = int.Parse(configuration["JwtSettings:ExpirationHours"] ?? "1");
        
        if (string.IsNullOrEmpty(_secret) || string.IsNullOrEmpty(_issuer) || string.IsNullOrEmpty(_audience))
            throw new InvalidOperationException("As variáveis de ambiente para JWT não estão configuradas corretamente.");
    }

    public string GerarToken(string nomeUsuario)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, nomeUsuario)
        };

        var chaveSeguranca = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
        var credenciais = new SigningCredentials(chaveSeguranca, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            expires: DateTime.Now.AddHours(_expiracaoHoras),
            claims: claims,
            signingCredentials: credenciais);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}