using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuanLyQuanAo_MVC_CORE.Models;

namespace QuanLyQuanAo_MVC_CORE.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var listProduct = _dbContext.Products.ToList();
        var listProductType = _dbContext.ProductTypes.ToList();
        ViewBag.ListProductType = listProductType;
        return View(listProduct);
    }

    [HttpPost]
    public IActionResult SearchProduct(string key)
    {
        var product = _dbContext.Products.Where(r => r.ProductName.Contains(key)).ToList();
        ViewBag.key = key;
        return View(product);
    }
    
}
