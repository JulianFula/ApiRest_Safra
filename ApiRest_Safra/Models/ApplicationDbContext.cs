using ApiRest_Safra.Models.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Bill> Bills { get; set; }
    public DbSet<Client_DbContext> Client { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Bill_Product> Bill_Product { get; set; }
    public DbSet<User_DbContext> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar relaciones y claves

        modelBuilder.Entity<Bill_Product>()
            .HasKey(bp => new { bp.Bill_Id, bp.Product_Id });

        modelBuilder.Entity<Bill_Product>()
            .HasOne(bp => bp.Bill)
            .WithMany(b => b.Bill_Products)
            .HasForeignKey(bp => bp.Bill_Id);

        modelBuilder.Entity<Bill_Product>()
            .HasOne(bp => bp.Product)
            .WithMany(p => p.Bill_Products)
            .HasForeignKey(bp => bp.Product_Id);

        modelBuilder.Entity<Bill>()
            .HasOne(b => b.Client)
            .WithMany(c => c.Bills)
            .HasForeignKey(b => b.Client_Id);

        modelBuilder.Entity<User_DbContext>()
              .HasKey(u => u.UsrUserId);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}