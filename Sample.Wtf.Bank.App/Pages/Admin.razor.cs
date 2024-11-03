using Microsoft.AspNetCore.Components;
using Sample.Wtf.Bank.Entities;
using Sample.Wtf.Bank.App.Services;
using Sample.Wtf.Bank.Entities.Api;

namespace Sample.Wtf.Bank.App.Pages;

public partial class Admin
{
    [Inject] protected BrainService _brain { get; set; }

    private bool _loaded = false;
    
    public List<UserResult> Users { get; set; }
    public List<Entities.Account> Accounts { get; set; }
    public List<Transaction> Transactions { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Users = await _brain.GetUsersAsync();
        Accounts = await _brain.GetAccountsAsync();

        _loaded = true;
    }

    private async Task OnUserCreated( UserResult user )
    {
        Users.Add( user );
        StateHasChanged();
    }
}