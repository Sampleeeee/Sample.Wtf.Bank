using Microsoft.AspNetCore.Components;
using Sample.Wtf.Bank.App.Services;

namespace Sample.Wtf.Bank.App.Components;

public partial class Navbar
{
    [Inject] protected BrainService _brain { get; set; }
}