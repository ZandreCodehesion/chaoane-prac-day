using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PracticalDay.Model;


public class AccountModel
{
    [Key]
    public Guid UserId { get; set; }
    
    public String Username { get; set;}
    
    public String Password { get; set;}
    
}