using _1670_ApplicationDevelopment_Lab.Data;
using _1670_ApplicationDevelopment_Lab.Repository.IRepository;

namespace _1670_ApplicationDevelopment_Lab.Repository
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;
        public ICategoryRepository CategoryRepository { get; private set; }

        public IBookRepository BookRepository { get; private set; }

        public UnitOfWorks(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            CategoryRepository = new CategoryRepository(_dbContext);
            BookRepository = new BookRepository(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
