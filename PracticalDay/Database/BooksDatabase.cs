using Microsoft.EntityFrameworkCore;
using PracticalDay.Model;

namespace PracticalDay.Database;

public class BooksDatabase : IBooksDatabase
{
    private readonly ContextDb _contextDb;

    public BooksDatabase(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<BooksModel> Create(BooksModel books)
    {
        
        var authors = _contextDb.AuthorsModel.Find(books.Author);
        var user = _contextDb.AccountModel.Find(books.UserId);
        
       
        if (authors != null && user != null)
        {
            BooksModel book = new BooksModel();

            book.BookId = new Guid();

            book.DatePublished = books.DatePublished;

            book.CopiesSold = books.CopiesSold;

            book.Publisher = books.Publisher;

            book.BookName = books.BookName;

            book.Author = authors.AuthorId;

            book.UserId = user.UserId;
            
            
              _contextDb.BooksModel.Add(book);
              await _contextDb.SaveChangesAsync();
              return book;
        }
        
        return null;
    }

    public async Task<IEnumerable<BooksModel>> Get()
    {
        return await _contextDb.BooksModel.ToListAsync();
    }

    public async Task<BooksModel> Get(Guid booksId)
    {
        var book = _contextDb.BooksModel.Find(booksId);

        if (book != null)
        {
            return await _contextDb.BooksModel.FindAsync(booksId);
        }

        return null;
    }

    public async Task<BooksModel> Get(Guid authorsId, Guid booksId)
    {
        var authors = _contextDb.AuthorsModel.Find(authorsId);
        var book = _contextDb.BooksModel.Find(booksId);

        if (book != null && authors != null)
        {
            return await _contextDb.BooksModel.FindAsync(booksId);
        }

        return null;
    }
}