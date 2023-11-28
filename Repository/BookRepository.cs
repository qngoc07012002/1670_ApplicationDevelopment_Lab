using _1670_ApplicationDevelopment_Lab.Data;
using _1670_ApplicationDevelopment_Lab.Models;
using _1670_ApplicationDevelopment_Lab.Repository.IRepository;

namespace _1670_ApplicationDevelopment_Lab.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public BookRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Book book)
        {
            _dbContext.Update(book);
        }
    }
}
