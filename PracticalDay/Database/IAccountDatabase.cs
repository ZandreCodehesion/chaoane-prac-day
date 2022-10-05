
using Microsoft.AspNetCore.Mvc;
using PracticalDay.Model;

namespace PracticalDay.Database;
public interface IAccountDatabase
{
    Task<AccountModel> Create(AccountModel accountModel);
    Task<IEnumerable<AccountModel>> Get();
    public AuthResponse Login(AccountModel accountModel);
    
}