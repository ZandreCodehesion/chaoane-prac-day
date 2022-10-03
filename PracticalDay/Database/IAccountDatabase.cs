
using PracticalDay.Model;

namespace PracticalDay.Database;
public interface IAccountDatabase
{
    Task<AccountModel> Create(AccountModel accountModel);

}