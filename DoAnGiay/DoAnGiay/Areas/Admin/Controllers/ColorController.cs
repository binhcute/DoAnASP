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
    public class ColorController : Controller
    {
        private readonly DPContext _context;

        public ColorController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Color
        public async Task<IActionResult> Index()
        {
            return View(await _context.Color.ToListAsync());
        }

        // GET: Admin/Color/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorModel = await _context.Color
                .FirstOrDefaultAsync(m => m.IdColor == id);
            if (colorModel == null)
            {
                return NotFound();
            }

            return View(colorModel);
        }

        // GET: Admin/Color/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Color/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdColor,Name,Status")] ColorModel colorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colorModel);
        }

        // GET: Admin/Color/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorModel = await _context.Color.FindAsync(id);
            if (colorModel == null)
            {
                return NotFound();
            }
            return View(colorModel);
        }

        // POST: Admin/Color/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdColor,Name,Status")] ColorModel colorModel)
        {
            if (id != colorModel.IdColor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorModelExists(colorModel.IdColor))
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
            return View(colorModel);
        }

        // GET: Admin/Color/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorModel = await _context.Color
                .FirstOrDefaultAsync(m => m.IdColor == id);
            if (colorModel == null)
            {
                return NotFound();
            }

            return View(colorModel);
        }

        // POST: Admin/Color/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colorModel = await _context.Color.FindAsync(id);
            _context.Color.Remove(colorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColorModelExists(int id)
        {
            return _context.Color.Any(e => e.IdColor == id);
        }
    }
}
