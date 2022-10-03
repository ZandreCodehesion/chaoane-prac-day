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
}