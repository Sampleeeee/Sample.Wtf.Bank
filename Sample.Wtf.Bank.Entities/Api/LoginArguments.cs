namespace Sample.Wtf.Bank.Entities.Api;

public record LoginArguments
{
    public LoginArguments()
    {
    }

    public LoginArguments( string username, string password )
    {
        Username = username;
        Password = password;
    }

    public string Username { get; set; }
    public string Password { get; set; }
}