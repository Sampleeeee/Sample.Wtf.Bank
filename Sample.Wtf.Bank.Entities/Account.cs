using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Wtf.Bank.Entities;

[Table( "Accounts" )]
public class Account
{
    [Required, Key] public string Id { get; set; } = null!;
    
    public ICollection<UserAccount> UserAccounts { get; set; } = null!;
    
    [Required] public string Name { get; set; } = null!;
    [Required] public string LastFour { get; set; } = null!;

    public List<Transaction> Transactions { get; set; } = new();
}