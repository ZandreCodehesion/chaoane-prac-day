using Microsoft.EntityFrameworkCore;

namespace PracticalDay.Model;


public class AuthorsModel
{
    public Guid AuthorId { get; set;}
    public String AuthorName { get; set;}
    public DateTime ActiveFrom { get; set;}
    public DateTime ActivateTo { get; set;}
    public  Guid  CreatedBy { get; set;}
}