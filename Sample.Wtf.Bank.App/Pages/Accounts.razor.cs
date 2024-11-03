using Microsoft.AspNetCore.Components;

namespace Sample.Wtf.Bank.App.Pages;

public partial class Accounts
{
    [Parameter] public string UserId { get; set; }
}