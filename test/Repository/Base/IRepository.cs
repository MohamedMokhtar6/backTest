using System.Linq.Expressions;

namespace test.Repository.Base
{
    public interface IRepository<T>where T : class
    {
        T FindById(int id);
        T SelectOne(Expression<Func<T, bool>> match);
        IEnumerable<T> FindAll();
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> FindAllAsync();
        IEnumerable<T> FindAll(params string[] agers);
        Task<IEnumerable<T>> FindAllAsync(params string[] agers);
        void AddOne(T MyItem);
        void UpdateOne(T MyItem);
        void DeleteOne(T MyItem);
        void AddList(IEnumerable<T> MyList);
        void UpdateList(IEnumerable<T> MyList);
        void DeleteList(IEnumerable<T> MyList);
    }
}
