using System.ComponentModel.DataAnnotations;

namespace PracticalDay.Model;

public class BooksModel
{
    [Key]
    public Guid BookId { get; set;}

    public String BookName { get; set; }
    public string Publisher { get; set;}

    public DateTime DatePublished { get; set;}

    public int CopiesSold { get; set;}

    public Guid Author { get; set;}

    public Guid UserId { get; set;}

}