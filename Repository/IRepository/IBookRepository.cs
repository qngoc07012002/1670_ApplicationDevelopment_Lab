using _1670_ApplicationDevelopment_Lab.Models;

namespace _1670_ApplicationDevelopment_Lab.Repository.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(Book book);
    }
}
