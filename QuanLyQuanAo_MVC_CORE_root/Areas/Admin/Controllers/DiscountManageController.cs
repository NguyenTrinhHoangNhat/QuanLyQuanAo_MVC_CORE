using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuanLyQuanAo_MVC_CORE.Models;
using QuanLyQuanAo_MVC_CORE.Helper.Authentication;
namespace QuanLyQuanAo_MVC_CORE.Controllers;
[Authentication]
public class DiscountManageController : Controller
{
    private readonly ILogger<DiscountManageController> _logger;
    private ApplicationDbContext _dbContext;
    private readonly IWebHostEnvironment _hostEnvironment;
    public DiscountManageController(ILogger<DiscountManageController> logger, ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _dbContext = dbContext;
        _hostEnvironment = hostEnvironment;
    }

    public IActionResult Index(int? page)
    {
        int pageSize = 5;
        int pageNumber = (page ?? 1);
        var products = _dbContext.Discounts.Where(r => r.IsDelete == 0).ToList();
        ViewBag.TotalPages = (int)Math.Ceiling((double)products.Count() / pageSize);

        var pagedProducts = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.PageNumber = pageNumber;
        return View(pagedProducts);
    }
    public IActionResult AddDiscount()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EditDiscount(string Id)
    {
        var discount = _dbContext.Discounts.FirstOrDefault(r => r.Id == Id);
        return View(discount);
    }
    [HttpGet]
    public IActionResult DeleteDiscount(string Id)
    {
        var discount = _dbContext.Discounts.FirstOrDefault(r => r.Id == Id);
        return View(discount);
    }

    [HttpPost]
    public IActionResult AddDiscountSubmit(Discount newDiscount)
    {
        Discount discount = new Discount
        {
            IsPercent = newDiscount.IsPercent,
            CodeName = newDiscount.CodeName,
            NameDiscount = newDiscount.NameDiscount,
            IsDelete = 0,
            Price = newDiscount.Price
        };
        _dbContext.Discounts.Add(discount);
        _dbContext.SaveChanges();
        return Redirect("/Admin/DiscountManage/Index");
    }

    [HttpPost]
    public IActionResult EditDiscountSubmit(Discount updateDiscount)
    {
        var discount = _dbContext.Discounts.FirstOrDefault(r => r.Id == updateDiscount.Id);
        discount.IsPercent = updateDiscount.IsPercent;
        discount.CodeName = updateDiscount.CodeName;
        discount.NameDiscount = updateDiscount.NameDiscount;
        discount.Price = updateDiscount.Price;
        _dbContext.SaveChanges();
        return Redirect("/Admin/DiscountManage/Index");
    }

    [HttpPost]
    public IActionResult DeleteDiscountSubmit(string Id)
    {
        var discount = _dbContext.Discounts.FirstOrDefault(r => r.Id == Id);
        discount.IsDelete = 1;
        _dbContext.SaveChanges();
        return Redirect("/Admin/DiscountManage/Index");
    }


}
