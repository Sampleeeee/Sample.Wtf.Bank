namespace Sample.Wtf.Bank.Entities.Api;

public class UpdateUserArguments
{
    public string Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    public char? MiddleInitial { get; set; }
    
    public string? Username { get; set; }
    public string? Password { get; set; }

    public List<string>? Accounts { get; set; }
}