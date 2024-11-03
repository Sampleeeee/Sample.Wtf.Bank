namespace Sample.Wtf.Bank.Entities.Api;

public record CreateUserArguments
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    
    public char? MiddleInitial { get; set; }

    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}