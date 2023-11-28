using _1670_ApplicationDevelopment_Lab.Models;

namespace _1670_ApplicationDevelopment_Lab.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
