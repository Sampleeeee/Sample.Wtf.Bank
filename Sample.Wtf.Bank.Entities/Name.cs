using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Wtf.Bank.Entities;

[Table( "Names" )]
public class Name
{
    [Required, Key] public string Id { get; set; } = null!;
    [Required] public string First { get; set; } = null!;
    public char? Middle { get; set; }
    [Required] public string Last { get; set; } = null!;

    public string GetFormalName() =>
        $"{Last}, {First}";

    public string GetFullName() =>
        $"{First} {Middle}. {Last}";
    
    public override string ToString()
    {
        return GetFormalName();
    }
}