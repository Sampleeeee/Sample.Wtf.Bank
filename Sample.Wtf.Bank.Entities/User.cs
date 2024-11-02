using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Wtf.Bank.Entities;

[Table( "Users" )]
public class User
{
    [Required, Key] public string Id { get; set; } = null!;

    [Required] public string FirstName { get; set; } = null!;
    [Required] public string LastName { get; set; } = null!;
    public char? MiddleInitial { get; set; }

    [Required] public string Username { get; set; } = null!;
    [Required] public string Password { get; set; } = null!;

    public ICollection<UserAccount> UserAccounts { get; set; } = null!;
}