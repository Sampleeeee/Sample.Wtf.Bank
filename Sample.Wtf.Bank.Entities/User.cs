using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Wtf.Bank.Entities;

[Table( "Users" )]
public class User
{
    [Required, Key] public string Id { get; set; } = null!;
    
    [Required] public string NameId { get; set; } = null!;
    public Name Name { get; set; } = null!;

    [Required] public string Username { get; set; } = null!;
    [Required] public string Password { get; set; } = null!;
}