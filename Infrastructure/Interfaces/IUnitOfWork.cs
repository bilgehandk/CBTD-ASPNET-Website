using Infrastructure.Models;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        //ADD Models/Tables here as you create them so UnitOfWork will have access
        public IGenericRepository<Category> Category { get; }
        public IGenericRepository<Manifactor> Manufacturer { get; }
        public IGenericRepository<Product> Product { get; }

        //save changes to the data source

        int Commit();

        Task<int> CommitAsync();

    }
}