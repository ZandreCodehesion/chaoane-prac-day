using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PracticalDay.Model;
using PracticalDay.tokens;

namespace PracticalDay.Database;

public class TokensDatabase : ITokensDatabase
{
    private readonly ContextDb accountContext;

    public TokensDatabase(ContextDb _accountContext,IConfiguration _configuration)
    {
        accountContext = _accountContext;
     
    }
    
    public TokensModel? Authenticate(AccountModel users)
    {
        var user = accountContext.AccountModel.Any(x => x.Username == users.Username && x.Password == users.Password);
        if (!user)
        {
            return null;
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        //var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, users.Username)                    
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
          //  SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new TokensModel(tokenHandler.WriteToken(token));

    }
}