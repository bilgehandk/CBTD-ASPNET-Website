using Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<Category> Categories { get; set; }  //the physical DB table will be named Categories
        public DbSet<Manifactor> Manifactors { get; set; }  //the physical DB table will be named Categories
    }
}
