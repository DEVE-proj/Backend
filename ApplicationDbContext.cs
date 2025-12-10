using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>(entity =>
        {

            entity.ToTable("users");

            entity.HasKey(e => e.Id).HasName("id");
            entity.Property(e => e.Name).HasColumnName("name").IsRequired();
            entity.Property(e => e.Login).HasColumnName("login").IsRequired();
            entity.Property(e => e.Password).HasColumnName("password").IsRequired();
            entity.Property(e => e.userTableId).HasColumnName("user_table_id").IsRequired();
        });
    }
}