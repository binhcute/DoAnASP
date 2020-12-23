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
    public class MaterialController : Controller
    {
        private readonly DPContext _context;

        public MaterialController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Material
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaterialModel.ToListAsync());
        }

        // GET: Admin/Material/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialModel = await _context.MaterialModel
                .FirstOrDefaultAsync(m => m.IdMaterial == id);
            if (materialModel == null)
            {
                return NotFound();
            }

            return View(materialModel);
        }

        // GET: Admin/Material/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Material/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaterial,Name,Description")] MaterialModel materialModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialModel);
        }

        // GET: Admin/Material/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialModel = await _context.MaterialModel.FindAsync(id);
            if (materialModel == null)
            {
                return NotFound();
            }
            return View(materialModel);
        }

        // POST: Admin/Material/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaterial,Name,Description")] MaterialModel materialModel)
        {
            if (id != materialModel.IdMaterial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialModelExists(materialModel.IdMaterial))
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
            return View(materialModel);
        }

        // GET: Admin/Material/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialModel = await _context.MaterialModel
                .FirstOrDefaultAsync(m => m.IdMaterial == id);
            if (materialModel == null)
            {
                return NotFound();
            }

            return View(materialModel);
        }

        // POST: Admin/Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialModel = await _context.MaterialModel.FindAsync(id);
            _context.MaterialModel.Remove(materialModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialModelExists(int id)
        {
            return _context.MaterialModel.Any(e => e.IdMaterial == id);
        }
    }
}
