using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Wtf.Bank.Entities;

[Table( "Transactions" )]
public class Transaction
{
    [Required, Key] public string Id { get; set; } = null!;
    
    [Required] public string AccountId { get; set; } = null!;
    public Account Account { get; set; } = null!;

    [Required] public string Name { get; set; } = null!;
    [Required] public int DaysAgo { get; set; }
    [Required] public float Amount { get; set; }
}