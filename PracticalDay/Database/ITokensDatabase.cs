using PracticalDay.Model;
using PracticalDay.tokens;

namespace PracticalDay.Database;

public interface ITokensDatabase
{
    TokensModel? Authenticate(AccountModel users); 
}