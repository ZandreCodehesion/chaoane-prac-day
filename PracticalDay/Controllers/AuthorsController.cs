using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PracticalDay.Database;
using PracticalDay.Model;

namespace PracticalDay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthors authors;

    public AuthorsController(IAuthors _authors)
    {
        authors=_authors;
       
    }
    [HttpPost]
    public async Task<ActionResult<AuthorsModel>> Create(AuthorsModel accountModel)
    {
        Console.WriteLine("JJJJJJJJJJJkkkkkkkkkkkkkkkklllllll");
        return await authors.Create(accountModel);
    }

    [HttpGet("{id}")]
    public async Task<AuthorsModel> Get(Guid id)
    {
        return await authors.Get(id);
    }
    
    [HttpDelete("{id}")]

    public async Task<EntityEntry<AuthorsModel>> Delete(Guid guid)
    {
        return await authors.Delete(guid);
    }

}