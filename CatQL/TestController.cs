namespace WebApplication1.Controllers;

using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class CatController : ControllerBase
{
    private readonly DataContext _dataContext;

    private readonly ILogger<CatController> _logger;

    public CatController(ILogger<CatController> logger, DataContext dataContext)
    {
        _logger = logger;
        _dataContext = dataContext;
    }

    [HttpGet]
    public IEnumerable<Cat> Get()
    {
        _dataContext.Database.Migrate();
        _dataContext.Cats.Add(new Cat { Name = "Test", Id = 1 });
        return _dataContext.Cats;
    }
}