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

    public void Add(Product product)
    {
        product.Id=Guid.NewGuid();
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public void Update(Product product)
    {
        var p = _context.Products.SingleOrDefault(x=>x.Id==product.Id);

        p.Title = product.Title;
        p.Category = product.Category;
        p.Description = product.Description;
        p.Image = product.Image;
        p.Price = product.Price;

        _context.Update(p);
        
        _context.SaveChanges();
    }
}