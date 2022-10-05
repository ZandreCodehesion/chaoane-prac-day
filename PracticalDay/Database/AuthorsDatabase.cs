using Microsoft.EntityFrameworkCore.ChangeTracking;
using PracticalDay.Model;

namespace PracticalDay.Database;

public class AuthorsDatabase : IAuthors
{
    private readonly ContextDb _authorContext;

    public AuthorsDatabase(ContextDb authorContext)
    {
        this._authorContext = authorContext;
    }


    public async Task<AuthorsModel?> Create(AuthorsModel author)
    {
        var user = _authorContext.AccountModel.Find(author.CreatedBy);
       
        if (user != null )
        {
            AuthorsModel authors = new AuthorsModel();
            authors.AuthorId = new Guid();

            authors.ActivateTo= author.ActivateTo;

            authors.ActiveFrom = author.ActiveFrom;

            authors.AuthorName = author.AuthorName;

            authors.CreatedBy = user.UserId;
            
            _authorContext.AuthorsModel.Add(authors);
            await _authorContext.SaveChangesAsync();
            return authors;
        }
        
        return null;
    }

    public async Task<AuthorsModel> Get(Guid id)
    {
        return (await _authorContext.AuthorsModel.FindAsync(id))!;
    }

    public async Task<bool> Delete(Guid guid)
    {
        var author = _authorContext.AuthorsModel.Find(guid);
        if (author == null)
        {
            return false;
        }
        _authorContext.AuthorsModel.Remove(author);
        return true;
    }
}

   