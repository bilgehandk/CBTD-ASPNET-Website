using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;

        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
        }


        public void Initialize()
        {
            _db.Database.EnsureCreated();

            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }

            if (_db.Categories.Any())
            {
                return; //DB has been seeded
            }

            if (_db.Manifactors.Any())
            {
                return;
            }

            var Categories = new List<Category>
            {

            new Category { Name = "Non-Alcoholic Beverages", DisplayOrder = 1 },
            new Category { Name = "Wine", DisplayOrder = 2 },
            new Category { Name = "Snacks", DisplayOrder = 3 }
            };

            var Manufactors = new List<Manifactor>
            {
                new Manifactor { Name = "Sprite", DisplayOrder = 1 },
                new Manifactor { Name = "Kavaklidere", DisplayOrder = 2 },
                new Manifactor { Name = "Eti", DisplayOrder = 3 }
            };

            foreach (var c in Categories)
            {
                _db.Categories.Add(c);
            }

            foreach (var man in Manufactors)
            {
                _db.Manifactors.Add(man);
            }

            //manufacturers
            //products

            _db.SaveChanges();
        }
    }
}


