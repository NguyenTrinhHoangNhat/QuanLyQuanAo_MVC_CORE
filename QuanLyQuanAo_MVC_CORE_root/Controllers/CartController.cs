using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuanLyQuanAo_MVC_CORE.Models;
using QuanLyQuanAo_MVC_CORE.Helper.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
namespace QuanLyQuanAo_MVC_CORE.Controllers;
[Authentication]
public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;
    private ApplicationDbContext _dbContext;

    public CartController(ILogger<CartController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var UserId = HttpContext.Session.GetString("UserId");
        Console.WriteLine("Mã là" + UserId);
        var query = from product in _dbContext.Products
                    join cartDetail in _dbContext.CartDetails on product.Id equals cartDetail.IdProduct
                    join cart in _dbContext.Carts on cartDetail.IdCart equals cart.Id
                    where cart.UserId == UserId && cart.IsOrder == 0
                    select new
                    {
                        Product = product,
                        CartDetail = cartDetail,
                        Cart = cart
                    };

        var result = query.ToList();
        ViewBag.ListProduct = result;
        var cartUser = _dbContext.Carts.FirstOrDefault(r => r.IsOrder == 0 && r.UserId == UserId);
        return View(cartUser);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductToCart(string productId, int quantity, double price)
    {
        var UserId = HttpContext.Session.GetString("UserId");
        var cartNotOrder = await _dbContext.Carts.FirstOrDefaultAsync(r => r.IsOrder == 0 && r.UserId == UserId);

        if (cartNotOrder == null)
        {
            Cart newCart = new Cart
            {
                IsOrder = 0,
                TotalProducts = 0,
                UserId = UserId,
            };
            await _dbContext.Carts.AddAsync(newCart);
            await _dbContext.SaveChangesAsync();
            var cart = await _dbContext.Carts.FirstOrDefaultAsync(r => r.IsOrder == 0 && r.UserId == UserId);
            CartDetail newCartDetail = new CartDetail
            {
                IdCart = cart.Id,
                IdProduct = productId,
                Quantity = quantity,
                TotalMoney = quantity * price,
            };
            newCart.TotalProducts += newCartDetail.TotalMoney;
            await _dbContext.CartDetails.AddAsync(newCartDetail);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            var existProduct = await _dbContext.CartDetails.FirstOrDefaultAsync(r => r.IdProduct == productId && r.IdCart == cartNotOrder.Id);
            if (existProduct == null)
            {
                CartDetail newCartDetail = new CartDetail
                {
                    IdCart = cartNotOrder.Id,
                    IdProduct = productId,
                    Quantity = quantity,
                    TotalMoney = quantity * price,
                };
                cartNotOrder.TotalProducts += newCartDetail.TotalMoney;
                await _dbContext.CartDetails.AddAsync(newCartDetail);
            }
            else
            {
                cartNotOrder.TotalProducts = cartNotOrder.TotalProducts - existProduct.TotalMoney + (quantity * price);
                existProduct.Quantity = quantity;
                existProduct.TotalMoney = quantity * price;
            }
            await _dbContext.SaveChangesAsync();
        }
        return Redirect("/Cart/Index");
    }
    [HttpGet]
    public async Task<IActionResult> RemoveProductInCart(string idProduct)
    {
        var UserId = HttpContext.Session.GetString("UserId");
        var cartNotOrder = await _dbContext.Carts.FirstOrDefaultAsync(r => r.IsOrder == 0 && r.UserId == UserId);
        var product = await _dbContext.Products.FirstOrDefaultAsync(r => r.Id == idProduct);
        if (cartNotOrder != null)
        {
            var productinCart = await _dbContext.CartDetails.FirstOrDefaultAsync(r => r.IdProduct == idProduct && r.IdCart == cartNotOrder.Id);
            cartNotOrder.TotalProducts -= product.Price * productinCart.Quantity;
            _dbContext.CartDetails.Remove(productinCart);
            _dbContext.SaveChanges();
        }
        return RedirectToAction("Index", "Cart");
    }
}
