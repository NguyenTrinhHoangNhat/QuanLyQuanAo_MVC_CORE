using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuanLyQuanAo_MVC_CORE.Models;

namespace QuanLyQuanAo_MVC_CORE.Controllers;

public class ProductCOntroller : Controller
{
    private readonly ILogger<ProductCOntroller> _logger;
private readonly ApplicationDbContext _dbContext;
    public ProductCOntroller(ILogger<ProductCOntroller> logger,ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index(string idProduct)
{
    var product = _dbContext.Products.FirstOrDefault(r => r.Id == idProduct);

    if (product != null)
    {
        var brandProduct = _dbContext.Brands.FirstOrDefault(r => r.Id == product.IdBrand);
        var proTypeProduct = _dbContext.ProductTypes.FirstOrDefault(r => r.Id == product.IdProductTypes);
        var listProductRE = _dbContext.Products.ToList().Where(r=>r.IdBrand == product.IdBrand && r.Id != product.Id);
        if (brandProduct != null)
        {
            ViewBag.brandProduct = brandProduct;
        }

        if (proTypeProduct != null)
        {
            ViewBag.proTypeProduct = proTypeProduct;
        }
        ViewBag.listProductRE = listProductRE;
        return View(product);
    }

    return NotFound(); 
}

}
