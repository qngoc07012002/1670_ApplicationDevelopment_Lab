namespace _1670_ApplicationDevelopment_Lab.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }

        IBookRepository BookRepository { get; }

        void Save();


    }
}
