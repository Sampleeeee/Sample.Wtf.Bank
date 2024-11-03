using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Sample.Wtf.Bank.Entities;

[Table( "Accounts" )]
public class Account
{
    [Required, Key] public string Id { get; set; } = null!;
    
    [JsonIgnore]
    public ICollection<UserAccount> UserAccounts { get; set; } = null!;
    
    [Required] public string Name { get; set; } = null!;
    [Required] public string LastFour { get; set; } = null!;

    [JsonIgnore]
    public List<Transaction> Transactions { get; set; } = new();
}