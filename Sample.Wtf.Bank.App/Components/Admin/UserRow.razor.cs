using Microsoft.AspNetCore.Components;
using Sample.Wtf.Bank.Entities;
using Sample.Wtf.Bank.App.Services;
using Sample.Wtf.Bank.Entities.Api;

namespace Sample.Wtf.Bank.App.Components.Admin;

public partial class UserRow
{
    [Parameter] public bool Creating { get; set; } = false;
    [Parameter] public Action<UserResult>? OnUserCreated { get; set; }

    private UserResult? _user;
    
    [Parameter]
    public UserResult? User
    {
        get => _user;
        set
        {
            _user = value;

            if ( value is null )
                return;
            
            _id = value.Id;
            
            _firstName = value.FirstName;
            _lastName = value.LastName;
            
            _middleInitial = value.MiddleInitial;
            
            _username = value.Username;
            _password = value.Password;
        }
    }
    [Parameter] public string Class { get; set; } = string.Empty;
    [Inject] protected BrainService _brain { get; set; }

    private string _id;
    
    private string _firstName;
    private string _lastName;

    public char? _middleInitial = null;

    private string _username;
    private string _password;
    
    private async Task CreateUserAsync()
    {
        var args = new CreateUserArguments
        {
            FirstName = _firstName,
            LastName = _lastName,
            MiddleInitial = _middleInitial,
            Username = _username,
            Password = _password
        };
        
        Console.WriteLine( args.FirstName );
        
        var user = await _brain.CreateUserAsync( args );
        OnUserCreated?.Invoke( user! );
    }

    // private Task UpdateUserAsync()
    // {
    //     return Task.CompletedTask;
    // }
}