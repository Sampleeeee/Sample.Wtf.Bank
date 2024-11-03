namespace Sample.Wtf.Bank.App;

public class ClientConfig
{
    public static ClientConfig Current = new();
    public string ApiRoute { get; set; } = "http://api.localhost:5010";
}