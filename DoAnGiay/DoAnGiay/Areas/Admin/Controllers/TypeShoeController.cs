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
    public class TypeShoeController : Controller
    {
        private readonly DPContext _context;

        public TypeShoeController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/TypeShoe
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeShoe.ToListAsync());
        }

        // GET: Admin/TypeShoe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeShoeModel = await _context.TypeShoe
                .FirstOrDefaultAsync(m => m.IdType == id);
            if (typeShoeModel == null)
            {
                return NotFound();
            }

            return View(typeShoeModel);
        }

        // GET: Admin/TypeShoe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TypeShoe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdType,Name,Status")] TypeShoeModel typeShoeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeShoeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeShoeModel);
        }

        // GET: Admin/TypeShoe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeShoeModel = await _context.TypeShoe.FindAsync(id);
            if (typeShoeModel == null)
            {
                return NotFound();
            }
            return View(typeShoeModel);
        }

        // POST: Admin/TypeShoe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdType,Name,Status")] TypeShoeModel typeShoeModel)
        {
            if (id != typeShoeModel.IdType)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeShoeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeShoeModelExists(typeShoeModel.IdType))
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
            return View(typeShoeModel);
        }

        // GET: Admin/TypeShoe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeShoeModel = await _context.TypeShoe
                .FirstOrDefaultAsync(m => m.IdType == id);
            if (typeShoeModel == null)
            {
                return NotFound();
            }

            return View(typeShoeModel);
        }

        // POST: Admin/TypeShoe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeShoeModel = await _context.TypeShoe.FindAsync(id);
            _context.TypeShoe.Remove(typeShoeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeShoeModelExists(int id)
        {
            return _context.TypeShoe.Any(e => e.IdType == id);
        }
    }
}
