using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuanLyQuanAo_MVC_CORE.Models;
using QuanLyQuanAo_MVC_CORE.Helper.Authentication;
namespace QuanLyQuanAo_MVC_CORE.Controllers;
[Authentication]
public class BrandManageController : Controller
{
    private readonly ILogger<BrandManageController> _logger;
    private ApplicationDbContext _dbContext;
    private readonly IWebHostEnvironment _hostEnvironment;
    public BrandManageController(ILogger<BrandManageController> logger, ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _dbContext = dbContext;
        _hostEnvironment = hostEnvironment;
    }

    public IActionResult Index(int? page)
    {
        int pageSize = 5;
        int pageNumber = (page ?? 1);
        var products = _dbContext.Brands.Where(r => r.IsDelete == 0).ToList();
        ViewBag.TotalPages = (int)Math.Ceiling((double)products.Count() / pageSize);

        var pagedProducts = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.PageNumber = pageNumber;
        return View(pagedProducts);
    }

    public IActionResult AddBrand()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EditBrand(string Id)
    {
        var brand = _dbContext.Brands.FirstOrDefault(r => r.Id == Id);
        return View(brand);
    }

    [HttpGet]
    public IActionResult DeleteBrand(string Id)
    {
        var brand = _dbContext.Brands.FirstOrDefault(r => r.Id == Id);
        return View(brand);
    }

    [HttpPost]
    public IActionResult AddBrandSubmit(Brand newBrand, IFormFile brandImg)
    {
        string webRootPath = _hostEnvironment.WebRootPath;
        string imagePath = Path.Combine(webRootPath, "img", "Brand");
        string uniqueFileName = Guid.NewGuid().ToString() + "_" + brandImg.FileName;
        string filePath = Path.Combine(imagePath, uniqueFileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            brandImg.CopyTo(stream);
        }
        Brand brand = new Brand
        {
            BrandName = newBrand.BrandName,
            ImgName = uniqueFileName,
            ImgUrl = uniqueFileName,
            IsDelete = 0,
        };
        _dbContext.Brands.Add(brand);
        _dbContext.SaveChanges();
        return Redirect("/Admin/BrandManage/Index");
    }

    [HttpPost]
    public IActionResult EditBrandSubmit(Brand updateBrand, IFormFile brandImg)
    {
        var brand = _dbContext.Brands.FirstOrDefault(r => r.Id == updateBrand.Id);
        if (brandImg != null)
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            string imagePath = Path.Combine(webRootPath, "img", "Brand");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + brandImg.FileName;
            string filePath = Path.Combine(imagePath, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                brandImg.CopyTo(stream);
            }
            brand.ImgName = uniqueFileName;
            brand.ImgUrl = uniqueFileName;
        }
        brand.BrandName = updateBrand.BrandName;
        _dbContext.SaveChanges();
        return Redirect("/Admin/BrandManage/Index");
    }

    [HttpPost]
    public IActionResult DeleteBrandSubmit(string Id)
    {
        var brand = _dbContext.Brands.FirstOrDefault(r => r.Id == Id);
        brand.IsDelete = 1;
        _dbContext.SaveChanges();
        return Redirect("/Admin/BrandManage/Index");
    }
}
