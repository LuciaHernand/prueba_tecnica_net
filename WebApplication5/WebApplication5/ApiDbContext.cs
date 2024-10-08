using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace WebApplication5
{

    public class ApiDbContext : DbContext
    {
        public DbSet<MBAOption> MBAOptions { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MBAOption>().ToTable("MBAOptions");
        }
    }
    
}
