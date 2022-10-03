using PracticalDay.Model;


namespace PracticalDay.Database;

public class AccountDatabase : IAccountDatabase
{

    private readonly AccountContext  accountContext;


    public AccountDatabase(AccountContext _accountContext)
    {
        accountContext = _accountContext;       
    }



    public async Task<AccountModel> Create(AccountModel accountModel)
    {

        accountContext.AccountModel.Add(accountModel);
        await accountContext.SaveChangesAsync();
        return accountModel;
    }
}