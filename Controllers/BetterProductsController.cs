using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmCentralProto.Data;
using FarmCentralProto.Models;
using Microsoft.AspNetCore.Authorization;

namespace FarmCentralProto.Controllers
{
    [Authorize]
    public class BetterProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BetterProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BetterProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BetterProduct.Include(b => b.Farmer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BetterProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BetterProduct == null)
            {
                return NotFound();
            }

            var betterProduct = await _context.BetterProduct
                .Include(b => b.Farmer)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (betterProduct == null)
            {
                return NotFound();
            }

            return View(betterProduct);
        }

        // GET: BetterProducts/Create
        public IActionResult Create()
        {
            ViewData["FarmerID"] = new SelectList(_context.Farmer, "FarmerID", "FarmerID");
            return View();
        }

        // POST: BetterProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,FarmerID,Name,Description,Price")] BetterProduct betterProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(betterProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmerID"] = new SelectList(_context.Farmer, "FarmerID", "FarmerID", betterProduct.FarmerID);
            return View(betterProduct);
        }

        // GET: BetterProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BetterProduct == null)
            {
                return NotFound();
            }

            var betterProduct = await _context.BetterProduct.FindAsync(id);
            if (betterProduct == null)
            {
                return NotFound();
            }
            ViewData["FarmerID"] = new SelectList(_context.Farmer, "FarmerID", "FarmerID", betterProduct.FarmerID);
            return View(betterProduct);
        }

        // POST: BetterProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,FarmerID,Name,Description,Price")] BetterProduct betterProduct)
        {
            if (id != betterProduct.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(betterProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BetterProductExists(betterProduct.ProductID))
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
            ViewData["FarmerID"] = new SelectList(_context.Farmer, "FarmerID", "FarmerID", betterProduct.FarmerID);
            return View(betterProduct);
        }

        // GET: BetterProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BetterProduct == null)
            {
                return NotFound();
            }

            var betterProduct = await _context.BetterProduct
                .Include(b => b.Farmer)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (betterProduct == null)
            {
                return NotFound();
            }

            return View(betterProduct);
        }

        // POST: BetterProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BetterProduct == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BetterProduct'  is null.");
            }
            var betterProduct = await _context.BetterProduct.FindAsync(id);
            if (betterProduct != null)
            {
                _context.BetterProduct.Remove(betterProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BetterProductExists(int id)
        {
          return (_context.BetterProduct?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
