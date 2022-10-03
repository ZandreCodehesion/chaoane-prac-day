using Microsoft.EntityFrameworkCore.ChangeTracking;
using PracticalDay.Model;

namespace PracticalDay.Database;

public class AuthorsDatabase : IAuthors
{
    private readonly ContextDb authorContext;

    public AuthorsDatabase(ContextDb _authorContext)
    {
        authorContext = _authorContext;
    }


    public async Task<AuthorsModel> Create(AuthorsModel author)
    {
        var user = authorContext.AccountModel.Find(author.CreatedBy);
        if (user != null )
        {
            AuthorsModel authors = new AuthorsModel();
            authors.AuthorId = new Guid();

            authors.ActivateTo= author.ActivateTo;

            authors.ActiveFrom = author.ActiveFrom;

            authors.AuthorName = author.AuthorName;

            authors.CreatedBy = user.UserId;
            
            authorContext.AuthorsModel.Add(authors);
            await authorContext.SaveChangesAsync();
            return authors;
        }
        
        return null;
    }

    public async Task<AuthorsModel> Get(Guid id)
    {
        return (await authorContext.AuthorsModel.FindAsync(id))!;
    }

    public async Task<EntityEntry<AuthorsModel>> Delete(Guid guid)
    {
        var author = authorContext.AuthorsModel.Find(guid);
        if (author == null)
        {
            return null;
        }
        return authorContext.AuthorsModel.Remove(author);
    }
}

   