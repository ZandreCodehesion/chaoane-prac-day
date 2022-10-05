namespace PracticalDay.Model;

public class AuthResponse
{
    public string token { get; set;}
    
    public string username { get; set;}
    
    public TimeSpan expires { get; set;}
    
}