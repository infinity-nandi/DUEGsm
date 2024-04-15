using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DUEGsm.Data;
using DUEGsm.Models;

namespace DUEGsm.Controllers
{
    public class MobilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MobilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mobiles
        public async Task<IActionResult> Index(string searchString, string productModell, int orderValue, int filterValue)
        {
            var mobile = from m in _context.Mobiles
                           select m;

            IQueryable<string> typeQuery = from tq in _context.Mobiles
                                           orderby tq.Modell
                                           select tq.Modell;

            IQueryable<string> brandQuery = from bq in _context.Mobiles
                                            orderby bq.Brand
                                            select bq.Brand;


            switch (orderValue)
            {
                case 0:
                    break;
                case 1:
                    mobile = mobile.OrderByDescending(x => x.UploadDate);
                    break;
                case 2:
                    mobile = mobile.OrderByDescending(x => x.Price);
                    break;
                case 3:
                    mobile = mobile.OrderBy(x => x.Price);
                    break;
                case 4:
                    mobile = mobile.OrderBy(x => x.Modell);
                    break;
                case 5:
                    mobile = mobile.OrderByDescending(x => x.Modell);
                    break;
            }

            switch (filterValue)
            {
                case 0:
                    break;
                case 1:
                    mobile = mobile.Where(x => x.Brand == "Apple");
                    break;
                case 2:
                    mobile = mobile.Where(x => x.Brand == "Huawei");
                    break;
                case 3:
                    mobile = mobile.Where(x => x.Brand == "Samsung");
                    break;
                case 4:
                    mobile = mobile.Where(x => x.Brand == "Xiomi");
                    break;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                mobile = mobile.Where(x => x.Brand!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(productModell))
            {
                mobile = mobile.Where(pt => pt.Modell == productModell);
            }

            var brandSearch = new MobilViewModel
            {
                Modell = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Mobile = await mobile.ToListAsync()
            };

            return View(brandSearch);
        }

        // GET: Mobiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mobiles == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }

        // GET: Mobiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mobiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Modell,Color,OperatingSystem,Screen,Processor,FrontCamera,BackCamera,Stroage,Description")] Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobile);
        }

        // GET: Mobiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mobiles == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobiles.FindAsync(id);
            if (mobile == null)
            {
                return NotFound();
            }
            return View(mobile);
        }

        // POST: Mobiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Modell,Color,OperatingSystem,Screen,Processor,FrontCamera,BackCamera,Stroage,Description")] Mobile mobile)
        {
            if (id != mobile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobileExists(mobile.Id))
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
            return View(mobile);
        }

        // GET: Mobiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mobiles == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }

        // POST: Mobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mobiles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mobiles'  is null.");
            }
            var mobile = await _context.Mobiles.FindAsync(id);
            if (mobile != null)
            {
                _context.Mobiles.Remove(mobile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobileExists(int id)
        {
          return (_context.Mobiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
