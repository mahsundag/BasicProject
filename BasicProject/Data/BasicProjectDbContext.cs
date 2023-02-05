using Microsoft.EntityFrameworkCore;
using BasicProject.Model;

namespace BasicProject.Data
{
    public class BasicProjectDbContext : DbContext
    {
        public BasicProjectDbContext(DbContextOptions<BasicProjectDbContext> dbContextOptions):base(dbContextOptions) 
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=MAHSUN\\SQLEXPRESS;Database=BasicProjectDb;Trusted_Connection=true;TrustServerCertificate=true");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Address> Addresses { get; set; }    
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
