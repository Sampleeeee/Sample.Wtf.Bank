using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Wtf.Bank.Entities;

[Table( "UserAccounts" )]
public class UserAccount
{
    [Required, Key] public string Id { get; set; } = null!;
    
    [Required, ForeignKey( "Id" )]
    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
    
    [Required, ForeignKey( "Id" )]
    public string AccountId { get; set; } = null!;
    public Account Account { get; set; } = null!;
}