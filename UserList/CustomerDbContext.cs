using Microsoft.EntityFrameworkCore;
using UserList;

public class CustomerDbContext : DbContext
{
    private const string ConnectionString = "Host=127.0.0.1;Database=customer;Username=vk;Password=customerdb";

    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .ToTable("customers");

        modelBuilder.Entity<Customer>()
            .Property(c => c.Id)
            .HasColumnName("id");  

        modelBuilder.Entity<Customer>()
            .Property(c => c.Name)
            .HasColumnName("name"); 

        modelBuilder.Entity<Customer>()
            .Property(c => c.PhoneNumber)
            .HasColumnName("phonenumber"); 

        
        base.OnModelCreating(modelBuilder);
    }
}
