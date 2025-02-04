using Microsoft.EntityFrameworkCore;
using MVC.DataAccess.Data;
using MVC.Models;

namespace MVC.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> tblCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { fldslno = 1, fldName = "Test", fldDisplayOrder = 1 },
                new Category { fldslno = 2, fldName = "Test1", fldDisplayOrder = 2 },
                new Category { fldslno = 3, fldName = "Test2", fldDisplayOrder = 3 }
                );
        }
    }
}
