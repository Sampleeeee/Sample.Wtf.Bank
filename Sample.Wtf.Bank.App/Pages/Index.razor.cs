using System.Diagnostics;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Sample.Wtf.Bank.Entities.Api;

namespace Sample.Wtf.Bank.App.Pages;

public partial class Index
{
    [Inject] protected HttpClient Http { get; set; }

    private string _username;
    private string _password;
    
    private async Task LoginAsync()
    {
        Console.WriteLine( "Logging in " );
        var response = await Http.PostAsJsonAsync( "/login", new LoginArguments( _username, _password ) );
        Console.WriteLine( await response.Content.ReadAsStringAsync() );
    }
}