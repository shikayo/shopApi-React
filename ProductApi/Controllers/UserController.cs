using Microsoft.AspNetCore.Mvc;
using ProductApi.DataAccess.Repository;
using ProductApi.Domain.Models;

namespace ProductApi.Controllers;


[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IRepository<User> _repository;

    public UserController(IRepository<User> repository)
    {
        _repository = repository;
    }
    
    
}