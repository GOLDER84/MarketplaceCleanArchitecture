using Microsoft.EntityFrameworkCore;
using Marketplace.Domain;

namespace Marketplace.Infrastructure;
public class DatabaseManager :DbContext
{
    // static readonly string connectionString = "Server=localhost; User ID=root; Password=Aref@4466; Database=market";

    public DbSet<User> Users { get; set; }
    public DbSet<Item> Items { get; set; }

    public DatabaseManager(DbContextOptions<DatabaseManager> options) : base(options)
    {
        
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //     
    //     // optionsBuilder.UseNpgsql("Host=localhost;Database=market;Username=postgres;Password=root");
    // }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.username).IsRequired().HasMaxLength(50);
            entity.Property(e => e.password).IsRequired().HasMaxLength(50);
            entity.Property(e => e.age).IsRequired();
            entity.Property(e => e.credit).IsRequired().HasDefaultValue(0);
            entity.Property(e => e.email).IsRequired().HasMaxLength(100);
        });
        
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Items");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.price).IsRequired();
            entity.Property(e => e.description).IsRequired().HasMaxLength(500);
        });
    }
    
    public void InitializeDatabase()
    {
        Database.Migrate();
    }
}
