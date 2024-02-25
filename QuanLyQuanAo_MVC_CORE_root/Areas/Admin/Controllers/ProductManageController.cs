using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuanLyQuanAo_MVC_CORE.Models;
using QuanLyQuanAo_MVC_CORE.Helper.Authentication;
namespace QuanLyQuanAo_MVC_CORE.Controllers;
[Authentication]
public class ProductManageController : Controller
{
    private readonly ILogger<ProductManageController> _logger;
    private ApplicationDbContext _dbContext;
    private readonly IWebHostEnvironment _hostEnvironment;
    public ProductManageController(ILogger<ProductManageController> logger, ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _dbContext = dbContext;
        _hostEnvironment = hostEnvironment;
    }

    public IActionResult Index(int? page)
    {
        int pageSize = 5;
        int pageNumber = (page ?? 1);
        var products = _dbContext.Products.Where(r => r.IsDelete == 0).ToList();

        ViewBag.TotalPages = (int)Math.Ceiling((double)products.Count() / pageSize);

        var pagedProducts = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.PageNumber = pageNumber;
        return View(pagedProducts);
    }
    public IActionResult AddProduct()
    {
        ViewBag.ListBrand = _dbContext.Brands.ToList();
        ViewBag.ListProductType = _dbContext.ProductTypes.ToList();
        return View();
    }
    [HttpGet]
    public IActionResult DeleteProduct(string proId)
    {
        var product = _dbContext.Products.FirstOrDefault(r=>r.Id == proId);
        return View(product);
    }
    [HttpGet]
    public IActionResult EditProduct(string proId)
    {
        var product = _dbContext.Products.Find(proId);
        ViewBag.ListBrand = _dbContext.Brands.ToList();
        ViewBag.ListProductType = _dbContext.ProductTypes.ToList();
        return View(product);
    }

    [HttpPost]
    public IActionResult AddProductSubmit(Product newProduct, List<string> listColor, List<string> listSize, IFormFile ProImg)
    {
        //  if (!ModelState.IsValid)
        // {
        //      ViewBag.ListBrand = _dbContext.Brands.ToList();
        //      ViewBag.ListProductType = _dbContext.ProductTypes.ToList();
        //     return View("AddProduct");
        // }
        string webRootPath = _hostEnvironment.WebRootPath;
        string imagePath = Path.Combine(webRootPath, "img", "product");
        string uniqueFileName = Guid.NewGuid().ToString() + "_" + ProImg.FileName;
        string filePath = Path.Combine(imagePath, uniqueFileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            ProImg.CopyTo(stream);
        }
        Product product = new Product
        {
            Amout = newProduct.Amout,
            ColorList = string.Join("-", listColor),
            SizeList = string.Join("-", listSize),
            Description = newProduct.Description,
            IdBrand = newProduct.IdBrand,
            IdProductTypes = newProduct.IdProductTypes,
            ImgUrl = uniqueFileName,
            ImgName = uniqueFileName,
            Discount = 0,
            IsDelete = 0,
            NumberLove = 0,
            Price = newProduct.Price,
            ProductName = newProduct.ProductName,

        };
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        return Redirect("/Admin/ProductManage/Index");
    }


    [HttpPost]
    public IActionResult EditProductSubmit(Product newProduct, List<string> listColor, List<string> listSize, IFormFile ProImg)
    {
        //  if (!ModelState.IsValid)
        // {
        //      ViewBag.ListBrand = _dbContext.Brands.ToList();
        //      ViewBag.ListProductType = _dbContext.ProductTypes.ToList();
        //     return View("AddProduct");
        // }
        var product = _dbContext.Products.FirstOrDefault(r=>r.Id == newProduct.Id);
        if (ProImg != null)
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            string imagePath = Path.Combine(webRootPath, "img", "product");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + ProImg.FileName;
            string filePath = Path.Combine(imagePath, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                ProImg.CopyTo(stream);
            }
            product.ImgUrl = uniqueFileName;
            product.ImgName = uniqueFileName;
        }
        product.Amout = newProduct.Amout;
        product.ColorList = string.Join("-", listColor);
        product.SizeList = string.Join("-", listSize);
        product.Description = newProduct.Description;
        product.IdBrand = newProduct.IdBrand;
        product.IdProductTypes = newProduct.IdProductTypes;
        product.NumberLove = 0;
        product.Price = newProduct.Price;
        product.ProductName = newProduct.ProductName;
        _dbContext.SaveChanges();
        return Redirect("/Admin/ProductManage/Index");
    }
    [HttpPost]
    public IActionResult DeleteProductSubmit(string Id)
    {
        var product = _dbContext.Products.FirstOrDefault(r => r.Id == Id);
        product.IsDelete = 1;
        _dbContext.SaveChanges();
        return Redirect("/Admin/ProductManage/Index");
    }
}
