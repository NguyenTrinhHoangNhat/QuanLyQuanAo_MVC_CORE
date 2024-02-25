using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanAo_MVC_CORE.Models;
using QuanLyQuanAo_MVC_CORE.Helper.Authentication;

namespace QuanLyQuanAo_MVC_CORE.Controllers;
[Authentication]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private ApplicationDbContext _dbContext;
    public UserController(ILogger<UserController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index(int? page)
    {
        int pageSize = 5;
        int pageNumber = (page ?? 1);
        var products = _dbContext.Users.Where(r=>r.IsDelete == 0).ToList();
        ViewBag.Roles = _dbContext.Roles.ToList();
        ViewBag.TotalPages = (int)Math.Ceiling((double)products.Count() / pageSize);
        var pagedProducts = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        ViewBag.PageNumber = pageNumber;
        return View(pagedProducts);
    }
    public IActionResult EditUser(string uid)
    {
        var user = _dbContext.Users.FirstOrDefault(r => r.Id == uid);
        ViewBag.Roles = _dbContext.Roles.ToList();
        return View(user);
    }
    public IActionResult DeleteUser(string uid)
    {
        var user = _dbContext.Users.FirstOrDefault(r => r.Id == uid);
        return View(user);
    }
    public IActionResult AddUser()
    {
        ViewBag.Roles = _dbContext.Roles.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddUserSubmit(User user)
    {
        user.IsDelete = 0;
        user.ImgName = "Image User";
        user.ImgUrl = "Image User";
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return Redirect("/Admin/User/Index");
    } 

    [HttpPost]
    public async Task<IActionResult> EditUserSubmit(User user)
    {
        var userCurrent = await _dbContext.Users.FirstOrDefaultAsync(r=>r.Id == user.Id);
        if (userCurrent == null)
        {
            return NotFound("Không tìm tháy người dùng");
        }else{
            userCurrent.ImgName = user.ImgName;
            userCurrent.ImgUrl = user.ImgUrl;
            userCurrent.AddressUser = user.AddressUser;
            userCurrent.PhoneNumber = user.PhoneNumber;
            userCurrent.RoleId = user.RoleId;
            userCurrent.Pass = user.Pass;
            userCurrent.Email = user.Email;
            user.ImgName = "Image User";
        user.ImgUrl = "Image User";
            userCurrent.Username = user.Username;
            await _dbContext.SaveChangesAsync();
            return Redirect("/Admin/User/Index");
        }
    }
    [HttpPost]
    public async Task<IActionResult> DeleteUserSubmit(string uid)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(r => r.Id == uid);
        user.IsDelete = 1;
        await _dbContext.SaveChangesAsync();
        return Redirect("/Admin/User/Index");
    }
}
