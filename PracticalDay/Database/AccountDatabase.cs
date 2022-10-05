using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using PracticalDay.Model;


namespace PracticalDay.Database;

public class AccountDatabase : IAccountDatabase
{

    private readonly ContextDb _contextDb;


    public AccountDatabase(ContextDb contextDb)
    {
        _contextDb = contextDb;       
    }
    
    public async Task<AccountModel> Create(AccountModel accountModel)
    {
        AccountModel user = new AccountModel();

        user.UserId = new Guid();

        user.Password = accountModel.Password;

        user.Username = accountModel.Username;
        
        _contextDb.AccountModel.Add(user);
        await _contextDb.SaveChangesAsync();
        return user;
    }

    public async Task<IEnumerable<AccountModel>> Get()
    {
        return await _contextDb.AccountModel.ToListAsync();
    }

    public AuthResponse Login(AccountModel accountModel)
    {
        
        var users = _contextDb.AccountModel.Find(accountModel.UserId);

        if (users.Username != accountModel.Username && users.Password != accountModel.Password)
        {
            return null;
        }

        var tokenExpiry = DateTime.Now.AddMinutes(30);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.ASCII.GetBytes("CODING_HAVE_FUN_BE_HAPPY");
        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new List<Claim>
            {
                new Claim("Username", accountModel.Username)
            }),
            Expires = tokenExpiry,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = jwtSecurityTokenHandler.WriteToken(securityToken);

        return new AuthResponse
        {
            token = token,
            username = accountModel.Username,
            expires = tokenExpiry.Subtract(DateTime.Now)
        };

    }
}