using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Sample.Wtf.Bank.Entities;
using Sample.Wtf.Bank.Entities.Api;

namespace Sample.Wtf.Bank.App.Services;

public class BrainService
{
    public string? UserId { get; set; }
     
    private HttpClient _http { get; set; }
    
    public BrainService( HttpClient http )
    {
        _http = http;
    }

    public async Task<List<UserResult>?> GetUsersAsync() =>
        await _http.GetFromJsonAsync<List<UserResult>>( "/getallusers" );

    public async Task<UserResult?> CreateUserAsync( CreateUserArguments args )
    {
        var response = await _http.PostAsJsonAsync( "/createuser", args );
        return await response.Content.ReadFromJsonAsync<UserResult>();
    }

    public async Task<List<Account>?> GetAccountsAsync() =>
        await _http.GetFromJsonAsync<List<Account>>( "/getallaccounts" );
        
}