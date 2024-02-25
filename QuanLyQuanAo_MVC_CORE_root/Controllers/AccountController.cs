using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanAo_MVC_CORE.Models;
namespace QuanLyQuanAo_MVC_CORE.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private ApplicationDbContext _dbContext;
    public AccountController(ILogger<AccountController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    public IActionResult Profile()
    {
        var UserId = HttpContext.Session.GetString("UserId");
        var user = _dbContext.Users.FirstOrDefault(r=>r.Id == HttpContext.Session.GetString("UserId"));
        ViewBag.ListOrder = _dbContext.Carts.Where(r=>r.UserId == UserId && r.IsOrder == 1 ).ToList();
        
        var query = from product in _dbContext.Products
                    join cartDetail in _dbContext.CartDetails on product.Id equals cartDetail.IdProduct
                    join cart in _dbContext.Carts on cartDetail.IdCart equals cart.Id
                    where cart.UserId == UserId && cart.IsOrder == 1
                    select new
                    {
                        Product = product,
                        CartDetail = cartDetail,
                        Cart = cart
                    };
        var result = query.ToList();
        ViewBag.ListProduct = result;
        return View(user);
    }
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("Login");
    }

    [HttpPost]
    public async Task<IActionResult> LoginSubmit(string email, string password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(r => r.Email == email && r.Pass == password);

        if (user != null)
        {
         var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);
            HttpContext.Session.SetString("UserId", user.Id);
            HttpContext.Session.SetString("Username", user.Username);
            if (role.RoleName == "Admin")
            {
                HttpContext.Session.SetString("Role", "Admin");
                return Redirect("/Admin/ProductManage/Index");
            }
            else
            {
                HttpContext.Session.SetString("Role", "Customer");
                return RedirectToAction("Index", "Home");
            }
        }
        else
        {
            ViewBag.error = "Mật khẩu hoặc tài khoản không đúng";
            return View("Login");
        }
    }

    [HttpPost]
    public async Task<IActionResult> RegisterSubmit(User newUser, string PassRen)
    {
        if (newUser.Pass != PassRen)
        {
            ViewBag.error = "Mật khẩu nhập lại không đúng";
            return View("Register");
        }
        else
        {
            var userEmail = await _dbContext.Users.FirstOrDefaultAsync(r => r.Email == newUser.Email);
            if (userEmail != null)
            {
                ViewBag.error = "Email này đã được sử dụng";
                return View("Register");
            }
            else
            {
                var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == "Customer");
                User user = new User
                {
                    Username = newUser.Username,
                    Pass = newUser.Pass,
                    Email = newUser.Email,
                    AddressUser = "",
                    IsDelete = 0,
                    PhoneNumber = "",
                    RoleId = role.Id,
                    ImgUrl = "",
                    ImgName = ""
                };
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                var userNew = await _dbContext.Users.FirstOrDefaultAsync(r => r.Email == user.Email && r.Pass == user.Pass);
                HttpContext.Session.SetString("UserId", user.Id);
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Role", "Customer");
                return RedirectToAction("Index", "Home");
            }
        }
    }

    public IActionResult ListOrder()
    {
        
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> SubmitInfo(User user){
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
            return Redirect("/Account/Profile");
        }
    }
}
