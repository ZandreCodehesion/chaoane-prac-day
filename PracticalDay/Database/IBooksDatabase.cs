using Microsoft.EntityFrameworkCore.ChangeTracking;
using PracticalDay.Model;

namespace PracticalDay.Database;

public interface IBooksDatabase
{
    Task<BooksModel> Create(BooksModel authorsModel);
    Task<IEnumerable<BooksModel>> Get();
    Task<BooksModel> Get(Guid booksId);
    Task<BooksModel> Get(Guid authorsId,Guid booksId);
}