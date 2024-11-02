using Microsoft.EntityFrameworkCore;
using Sample.Wtf.Bank.Entities;

namespace Sample.Wtf.Bank.Server;

public class DatabaseContext : DbContext
{
    public DatabaseContext( DbContextOptions<DatabaseContext> options ) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserAccount>()
            .HasKey( x => new { x.UserId, x.AccountId } );

        modelBuilder.Entity<UserAccount>()
            .HasOne( x => x.User )
            .WithMany( x => x.UserAccounts )
            .HasForeignKey( x => x.UserId );
        
        modelBuilder.Entity<UserAccount>()
            .HasOne( x => x.Account )
            .WithMany( x => x.UserAccounts  )
            .HasForeignKey( x => x.AccountId );
        
        modelBuilder.Entity<Account>()
            .HasMany( a => a.Transactions )
            .WithOne( t => t.Account )
            .HasForeignKey( t => t.AccountId );
    }
}