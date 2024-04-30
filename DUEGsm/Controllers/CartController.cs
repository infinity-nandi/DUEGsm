using DUEGsm.Data;
using DUEGsm.Data.Enum;
using DUEGsm.Helper;
using DUEGsm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DUEGsm.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Mobile>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            if (cart != null)
            {
                ViewBag.total = cart.Sum(item => item.Price);
            }
            else
            {
                ViewBag.total = 0;
            }

            return View();
        }

        [Route("buy/{id}")]
        public async Task<IActionResult> Buy(int id)
        {
            List<Mobile>? cart = SessionHelper.GetObjectFromJson<List<Mobile>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Mobile>();
            }
            var productToAdd = await _context.Mobiles.FindAsync(id);
            if (productToAdd != null)
                cart.Add(productToAdd);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Mobile>? cart = SessionHelper.GetObjectFromJson<List<Mobile>>(HttpContext.Session, "cart");
            int index = isExist(id);

            if (index != -1)
            {
                cart?.RemoveAt(index);

                if (cart?.Count == 0)
                {
                    HttpContext.Session.Remove("cart");
                }
                else
                {
                    if (cart != null)
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
            }

            return RedirectToAction("Index");
        }

        [Route("order-success")]
        public IActionResult OrderSuccess()
        {
            return View(); // Return the view for the order success page
        }

        public async Task<IActionResult> CreateOrder()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Mobile>>(HttpContext.Session, "cart");
            Order order = new()
            {
                UserId = (await _userManager.GetUserAsync(User)).Id,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Folyamatban.ToString()
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            if (cart != null)
            {
                foreach (var item in cart)
                {
                    OrderProduct orderProducts = new()
                    {
                        ProductID = item.Id,
                        OrderID = order.Id
                    };
                    _context.OrderProduct.Add(orderProducts);

                }
            }

            await _context.SaveChangesAsync();

            SessionHelper.ClearSession(HttpContext.Session, "cart");

            return RedirectToAction("OrderSuccess");
        }

        private int isExist(int id)
        {
            List<Mobile>? cart = SessionHelper.GetObjectFromJson<List<Mobile>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart?.Count; i++)
            {
                if (cart[i].Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
