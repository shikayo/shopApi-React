using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductApi.DataAccess.Repository;
using ProductApi.Domain.Models;

namespace ProductApi.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private IRepository<Product> _repository;

    public ProductController(IRepository<Product> repository)
    {
        _repository = repository;
    }

    private void SeedToDb()
    {
        if (_repository.GetAll().ToList().Count == 0)
        {
            _repository.AddProduct( new Product
            {
                    Id = Guid.NewGuid(),
                    Title = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                    Price = 109.95,
                    Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
                    Category = "men's clothing",
                    Image = "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg",
            });
            _repository.AddProduct(new Product
            {
                Id    = Guid.NewGuid(),
                Title = "Mens Casual Premium Slim Fit T-Shirts",
                Price = 22.3,
                Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.",
                Category = "men's clothing",
                Image = "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg"
            });
        }
    }

    [HttpGet]
    public IEnumerable<Product> GetAll()
    {
        SeedToDb();
        var products = _repository.GetAll();

        return products;
    }

    [HttpPost]
    public HttpResponseMessage AddProduct(Product product)
    {
        _repository.AddProduct(product);
    
        return new HttpResponseMessage(HttpStatusCode.OK);
    }

    [HttpPost("Delete")]
    public HttpResponseMessage DeleteProduct(Product product)
    {
        _repository.DeleteProduct(product);

        return new HttpResponseMessage(HttpStatusCode.OK);
    }
}