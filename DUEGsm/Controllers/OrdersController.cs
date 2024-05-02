using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DUEGsm.Data;
using DUEGsm.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DUEGsm.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<Order>> DisplayOrdersDependOnRole(ClaimsPrincipal user)
        {
            var currentUser = await _userManager.GetUserAsync(user);

            if (await _userManager.IsInRoleAsync(currentUser, "Admin"))
            {
                var orders = await (_context.Order.Include(o => o.ApplicationUser)
                                                  .Include(order => order.OrderProducts)
                                                  .ThenInclude(orderProducts => orderProducts.Mobiles))
                                                  .ToListAsync();
                orders.ForEach(x => x.Mobiles = x.OrderProducts.Select(x => { return x.Mobiles; }).ToList());
                return orders;
            }
            else
            {
                var userOrders = await (_context.Order.Include(o => o.ApplicationUser)
                                                  .Include(order => order.OrderProducts)
                                                  .ThenInclude(orderProducts => orderProducts.Mobiles))
                                                  .Where(o => o.ApplicationUser.Id == currentUser.Id)
                                                  .ToListAsync();
                userOrders.ForEach(x => x.Mobiles = x.OrderProducts.Select(x => { return x.Mobiles; }).ToList());
                return userOrders;
            }
        }

        public async Task<List<Order>> GetConnectedOrders()
        {
            var orders = await (_context.Order.Include(o => o.ApplicationUser)
                                                  .Include(order => order.OrderProducts)
                                                  .ThenInclude(orderProducts => orderProducts.Mobiles))
                                                  .ToListAsync();

            orders.ForEach(x => x.Mobiles = x.OrderProducts.Select(x => { return x.Mobiles; }).ToList());

            return orders;
        }

        public async Task<IActionResult> Index()
        {
            var user = User;
            var orders = await DisplayOrdersDependOnRole(user);
            return View(orders);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = (await GetConnectedOrders()).FirstOrDefault(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }


        /*// GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Status,OrderDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            return View(order);
        }*/

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Status,OrderDate")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Order'  is null.");
            }
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            try
            {
                return (_context.Order?.Any(e => e.Id == id)).GetValueOrDefault();
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }
    }
}
