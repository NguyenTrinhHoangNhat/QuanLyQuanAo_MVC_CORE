using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuanLyQuanAo_MVC_CORE.Models;
using QuanLyQuanAo_MVC_CORE.Helper.Authentication;
namespace QuanLyQuanAo_MVC_CORE.Controllers;
[Authentication]
public class ProductTypeManageController : Controller
{
    private readonly ILogger<ProductTypeManageController> _logger;
    private ApplicationDbContext _dbContext;
    public ProductTypeManageController(ILogger<ProductTypeManageController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index(int? page)
    {
        int pageSize = 5;
        int pageNumber = (page ?? 1);
        var products = _dbContext.ProductTypes.Where(r => r.IsDelete == 0).ToList();
        ViewBag.TotalPages = (int)Math.Ceiling((double)products.Count() / pageSize);

        var pagedProducts = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.PageNumber = pageNumber;
        return View(pagedProducts);
    }
    public IActionResult AddProductType()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EditProductType(string Id){
        var productT= _dbContext.ProductTypes.FirstOrDefault(r=>r.Id == Id);
        return View(productT);
    }
    [HttpGet]
    public IActionResult DeleteProductType(string Id){
        var productT= _dbContext.ProductTypes.FirstOrDefault(r=>r.Id == Id);
        return View(productT);
    }
    [HttpPost]


    [HttpPost]
    public IActionResult AddProductTypeSubmit(ProductType newProT)
    {
        ProductType proT = new ProductType
        {
            ProductTypesName = newProT.ProductTypesName,
            IsDelete = 0,
        };
        _dbContext.ProductTypes.Add(proT);
        _dbContext.SaveChanges();
        return Redirect("/Admin/ProductTypeManage/Index");
    }

    [HttpPost]
    public IActionResult EditProductTypeSubmit(ProductType proT){
        var productT= _dbContext.ProductTypes.FirstOrDefault(r=>r.Id == proT.Id);
        productT.ProductTypesName = proT.ProductTypesName;
        _dbContext.SaveChanges();
        return Redirect("/Admin/ProductTypeManage/Index");
    }
    [HttpPost]
    public IActionResult DeleteProductTypeSubmit(string Id){
        var productT= _dbContext.ProductTypes.FirstOrDefault(r=>r.Id == Id);
        productT.IsDelete = 1;
        _dbContext.SaveChanges();
        return Redirect("/Admin/ProductTypeManage/Index");
    }
}
