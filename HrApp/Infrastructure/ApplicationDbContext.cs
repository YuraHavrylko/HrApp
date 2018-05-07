namespace HrApp.Infrastructure
{
    using System.Data.Entity;

    using HrApp.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("HRDataBase") { }

        public DbSet<AspNetRoles> AspNetRoles { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}