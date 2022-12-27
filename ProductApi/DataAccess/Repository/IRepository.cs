using ProductApi.Domain.Models;

namespace ProductApi.DataAccess.Repository;

public interface IRepository<T> where T: class
{
    T GetById(Guid id);
    IEnumerable<T> GetAll();
    void AddProduct(T entity);
    void DeleteProduct(T entity);
}