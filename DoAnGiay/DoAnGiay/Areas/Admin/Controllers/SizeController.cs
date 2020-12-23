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
    public class SizeController : Controller
    {
        private readonly DPContext _context;

        public SizeController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Size
        public async Task<IActionResult> Index()
        {
            return View(await _context.Size.ToListAsync());
        }

        // GET: Admin/Size/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sizeModel = await _context.Size
                .FirstOrDefaultAsync(m => m.IdSize == id);
            if (sizeModel == null)
            {
                return NotFound();
            }

            return View(sizeModel);
        }

        // GET: Admin/Size/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Size/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSize,NumSize")] SizeModel sizeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sizeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sizeModel);
        }

        // GET: Admin/Size/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sizeModel = await _context.Size.FindAsync(id);
            if (sizeModel == null)
            {
                return NotFound();
            }
            return View(sizeModel);
        }

        // POST: Admin/Size/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSize,NumSize")] SizeModel sizeModel)
        {
            if (id != sizeModel.IdSize)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sizeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SizeModelExists(sizeModel.IdSize))
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
            return View(sizeModel);
        }

        // GET: Admin/Size/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sizeModel = await _context.Size
                .FirstOrDefaultAsync(m => m.IdSize == id);
            if (sizeModel == null)
            {
                return NotFound();
            }

            return View(sizeModel);
        }

        // POST: Admin/Size/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sizeModel = await _context.Size.FindAsync(id);
            _context.Size.Remove(sizeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SizeModelExists(int id)
        {
            return _context.Size.Any(e => e.IdSize == id);
        }
    }
}
