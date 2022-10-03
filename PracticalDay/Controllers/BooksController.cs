using Microsoft.AspNetCore.Mvc;
using PracticalDay.Database;
using PracticalDay.Model;

namespace PracticalDay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBooksDatabase book;

    public BooksController(IBooksDatabase _books)
    {
        book=_books;
       
    }
    [HttpPost]
    [Route("/Books")]
    public async Task<ActionResult<BooksModel>> Create(BooksModel booksModel)
    {
        return await book.Create(booksModel);
    }

    [HttpGet("{AuthorId}")]
    public async Task<BooksModel> Get(Guid id)
    {
        return await book.Get(id);
    }
    
  [HttpGet("{AuthorsId}/{BooksId}")]
    public async Task<BooksModel> Get(Guid AuthorsId,Guid BooksId)
    {
        return await book.Get(AuthorsId,BooksId);
    }
    
    
    
    [HttpGet]
    public async Task<IEnumerable<BooksModel>> Get()
    {
        return await book.Get();
    }
    
    
    
    
}