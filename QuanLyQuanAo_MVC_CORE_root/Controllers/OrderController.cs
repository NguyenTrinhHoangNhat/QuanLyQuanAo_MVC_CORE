using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuanLyQuanAo_MVC_CORE.Models;
using QuanLyQuanAo_MVC_CORE.Helper.Authentication;
using Microsoft.EntityFrameworkCore;
namespace QuanLyQuanAo_MVC_CORE.Controllers;
[Authentication]
public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public OrderController(ILogger<OrderController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var userId = HttpContext.Session.GetString("UserId");
        var user = await _dbContext.Users.FirstOrDefaultAsync(r => r.Id == userId);
        var cartUser = await _dbContext.Carts.FirstOrDefaultAsync(r => r.IsOrder == 0 && r.UserId == userId);
        var query = from product in _dbContext.Products
                    join cartDetail in _dbContext.CartDetails on product.Id equals cartDetail.IdProduct
                    join cart in _dbContext.Carts on cartDetail.IdCart equals cart.Id
                    where cart.UserId == userId && cart.IsOrder == 0
                    select new
                    {
                        Product = product,
                        CartDetail = cartDetail,
                        Cart = cart
                    };

        var result = query.ToList();
        ViewBag.ListProduct = result;
        ViewBag.CartUser = cartUser;
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> CheckoutOrder(User updateUser, string cartId,string idDiscount)
    {
        var userId = HttpContext.Session.GetString("UserId");
        var user = await _dbContext.Users.FirstOrDefaultAsync(r => r.Id == userId);
        var cartUser = await _dbContext.Carts.FirstOrDefaultAsync(r => r.IsOrder == 0 && r.UserId == userId);
        if (string.IsNullOrEmpty(updateUser.AddressUser) || string.IsNullOrEmpty(updateUser.PhoneNumber) || string.IsNullOrEmpty(updateUser.Username))
        {
            var query = from product in _dbContext.Products
                        join cartDetail in _dbContext.CartDetails on product.Id equals cartDetail.IdProduct
                        join cart in _dbContext.Carts on cartDetail.IdCart equals cart.Id
                        where cart.UserId == userId && cart.IsOrder == 0
                        select new
                        {
                            Product = product,
                            CartDetail = cartDetail,
                            Cart = cart
                        };

            var result = query.ToList();
            ViewBag.ListProduct = result;
            var itemsError = new List<string>();
            if (string.IsNullOrEmpty(updateUser.AddressUser)) itemsError.Add("* Vui lòng nhập địa chỉ vào");
            if (string.IsNullOrEmpty(updateUser.PhoneNumber)) itemsError.Add("* Vui lòng nhập số điện thoại vào");
            if (string.IsNullOrEmpty(updateUser.Username)) itemsError.Add("* Vui lòng nhập tên vào");
            ViewBag.CartUser = cartUser;
            ViewBag.Error = itemsError;
            return View("Index", user);
        }else{
            OrderUser newOrder = new OrderUser{
                IdCart = cartUser.Id,
                IdDiscount = idDiscount,
                OrderDate = new DateTime(),
                Total = cartUser.TotalProducts,
            };
            if(!string.IsNullOrEmpty(idDiscount)){
                var discount = _dbContext.Discounts.FirstOrDefault(r=>r.Id == idDiscount);
                if(discount.IsPercent == 0){
                    newOrder.Total -= (newOrder.Total * (discount.Price / 100)) ;
                }else{
                    newOrder.Total -= discount.Price;
                }
            }
            user.Username = updateUser.Username;
            user.AddressUser = updateUser.AddressUser;
            user.PhoneNumber = updateUser.PhoneNumber;
            cartUser.IsOrder = 1;
            _dbContext.Users.Update(user);
            _dbContext.OrderUsers.Add(newOrder);
            await _dbContext.SaveChangesAsync();
            return View("Success");
        }
    }
}
