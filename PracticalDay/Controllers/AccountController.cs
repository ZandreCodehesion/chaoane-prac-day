using Microsoft.AspNetCore.Mvc;
using PracticalDay.Database;
using PracticalDay.Model;


namespace PracticalDay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{

    private readonly IAccountDatabase account;
    
    private readonly ITokensDatabase tokensDatabase;
    
    public AccountController(IAccountDatabase _account,ITokensDatabase _tokensDatabase)
    {
        account=_account;
        tokensDatabase = _tokensDatabase;
    }      
    
    [HttpGet]
    public async Task<IEnumerable<AccountModel>> Get()
    {
        return await account.Get();
    }


    [HttpPost]
    [Route("Accounts/register")]
    public async Task<ActionResult<AccountModel>> Create(AccountModel accountModel)
    {
        return await account.Create(accountModel);
    }
    
   /* [HttpPost]
    [Route("Accounts/login")]
    public async Task<ActionResult<AccountModel>> Login(AccountModel accountModel)
    {
        var token = tokensDatabase.Authenticate(accountModel);
        if (token == null)
        {
            return Unauthorized();
        }

        return accountModel;
    }*/
    
    
    
   
}