using ProductApi.Domain.Models;

namespace ProductApi.DataAccess.Repository;

public interface IRepository<T> where T: class
{
    T GetById(Guid id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}