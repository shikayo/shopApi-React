using ProductApi.Domain.Models;

namespace ProductApi.DataAccess.Repository;

public class ProductRepository : IRepository<Product>
{
    private AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public Product GetById(Guid guid)
    {
        var product = _context.Products.SingleOrDefault(x => x.Id == guid);
        return product;
    }

    public IEnumerable<Product> GetAll()
    {
        var allProducts = _context.Products.ToList();
        return allProducts;
    }

    public void AddProduct(Product product)
    {
        product.Id=Guid.NewGuid();
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}