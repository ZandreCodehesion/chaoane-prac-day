using Microsoft.AspNetCore.Mvc;
using PracticalDay.Database;
using PracticalDay.Model;

namespace PracticalDay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{

    private readonly IAccountDatabase account;
    
    public AccountController(IAccountDatabase _account)
    {
        account=_account;
    }      


    [HttpPost]
    public async Task<ActionResult<AccountModel>> Create(AccountModel accountModel)
    {
        return await account.Create(accountModel);
    }
    
   
}