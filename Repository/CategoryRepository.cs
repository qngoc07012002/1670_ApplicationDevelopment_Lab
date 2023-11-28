using _1670_ApplicationDevelopment_Lab.Data;
using _1670_ApplicationDevelopment_Lab.Models;
using _1670_ApplicationDevelopment_Lab.Repository.IRepository;
using NPOI.SS.Formula.Functions;

namespace _1670_ApplicationDevelopment_Lab.Repository
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CategoryRepository(ApplicationDBContext dbContext) : base (dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Category category)
        {
            _dbContext.Update(category);
        }
    }
}
