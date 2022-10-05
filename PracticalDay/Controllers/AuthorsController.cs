using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PracticalDay.Database;
using PracticalDay.Model;

namespace PracticalDay.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthors _authors;
    public AuthorsController(IAuthors authors)
    {
        this._authors=authors;
    }
    [HttpPost]
    public async Task<ActionResult<AuthorsModel>> Create(AuthorsModel accountModel) => await _authors.Create(accountModel) ?? throw new InvalidOperationException();

    [HttpGet("{AuthorId}")]
    public async Task<AuthorsModel> Get(Guid id)
    {
        return await _authors.Get(id);
    }
    [HttpDelete("{AuthorId}")]
    public async Task<bool> Delete(Guid guid)
    {
        return await _authors.Delete(guid);
    }
}