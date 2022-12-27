using ProductApi.Domain.Models;

namespace ProductApi.DataAccess.Repository;

public class UserRepository : IRepository<User>
{
    public User GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public void AddProduct(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(User user)
    {
        throw new NotImplementedException();
    }
}