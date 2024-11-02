using Sample.Wtf.Bank.Entities;

namespace Sample.Wtf.Bank.App.Pages;

public partial class Admin
{
    public List<User> Users { get; set; }
    public List<Account> Accounts { get; set; }
    public List<Transaction> Transactions { get; set; }
}