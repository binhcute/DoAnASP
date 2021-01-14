using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnGiay.Areas.Admin.Data;
using DoAnGiay.Areas.Admin.Models;

namespace DoAnGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SaleController : Controller
    {
        private readonly DPContext _context;

        public SaleController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Sale
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sale.ToListAsync());
        }

        // GET: Admin/Sale/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleModel = await _context.Sale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleModel == null)
            {
                return NotFound();
            }

            return View(saleModel);
        }

        // GET: Admin/Sale/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PriceSale,Description,Date")] SaleModel saleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleModel);
        }

        // GET: Admin/Sale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleModel = await _context.Sale.FindAsync(id);
            if (saleModel == null)
            {
                return NotFound();
            }
            return View(saleModel);
        }

        // POST: Admin/Sale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PriceSale,Description,Date")] SaleModel saleModel)
        {
            if (id != saleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleModelExists(saleModel.Id))
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
            return View(saleModel);
        }

        // GET: Admin/Sale/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleModel = await _context.Sale
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleModel == null)
            {
                return NotFound();
            }

            return View(saleModel);
        }

        // POST: Admin/Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleModel = await _context.Sale.FindAsync(id);
            _context.Sale.Remove(saleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleModelExists(int id)
        {
            return _context.Sale.Any(e => e.Id == id);
        }
    }
}
