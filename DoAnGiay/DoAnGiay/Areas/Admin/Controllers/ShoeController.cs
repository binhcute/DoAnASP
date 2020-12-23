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
    public class ShoeController : Controller
    {
        private readonly DPContext _context;

        public ShoeController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Shoe
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.Shoe.Include(s => s.Color).Include(s => s.Material).Include(s => s.Producer).Include(s => s.Size).Include(s => s.TypeShoe);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/Shoe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeModel = await _context.Shoe
                .Include(s => s.Color)
                .Include(s => s.Material)
                .Include(s => s.Producer)
                .Include(s => s.Size)
                .Include(s => s.TypeShoe)
                .FirstOrDefaultAsync(m => m.IdShoe == id);
            if (shoeModel == null)
            {
                return NotFound();
            }

            return View(shoeModel);
        }

        // GET: Admin/Shoe/Create
        public IActionResult Create()
        {
            ViewData["Colors"] = new SelectList(_context.Color, "IdColor", "Name");
            ViewData["Materials"] = new SelectList(_context.MaterialModel, "IdMaterial", "Name");
            ViewData["Pro"] = new SelectList(_context.Producer, "IdPro", "Name");
            ViewData["Sizes"] = new SelectList(_context.Size, "IdSize", "IdSize");
            ViewData["Type"] = new SelectList(_context.TypeShoe, "IdType", "Name");
            return View();
        }

        // POST: Admin/Shoe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdShoe,Name,Date,Img,Price,Sizes,Colors,Video,NumberSeri,Shoelate,Version,Materials,Type,Pro,Description,Status")] ShoeModel shoeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Colors"] = new SelectList(_context.Color, "IdColor", "Name", shoeModel.Colors);
            ViewData["Materials"] = new SelectList(_context.MaterialModel, "IdMaterial", "Name", shoeModel.Materials);
            ViewData["Pro"] = new SelectList(_context.Producer, "IdPro", "Name", shoeModel.Pro);
            ViewData["Sizes"] = new SelectList(_context.Size, "IdSize", "IdSize", shoeModel.Sizes);
            ViewData["Type"] = new SelectList(_context.TypeShoe, "IdType", "Name", shoeModel.Type);
            return View(shoeModel);
        }

        // GET: Admin/Shoe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeModel = await _context.Shoe.FindAsync(id);
            if (shoeModel == null)
            {
                return NotFound();
            }
            ViewData["Colors"] = new SelectList(_context.Color, "IdColor", "Name", shoeModel.Colors);
            ViewData["Materials"] = new SelectList(_context.MaterialModel, "IdMaterial", "Name", shoeModel.Materials);
            ViewData["Pro"] = new SelectList(_context.Producer, "IdPro", "Name", shoeModel.Pro);
            ViewData["Sizes"] = new SelectList(_context.Size, "IdSize", "IdSize", shoeModel.Sizes);
            ViewData["Type"] = new SelectList(_context.TypeShoe, "IdType", "Name", shoeModel.Type);
            return View(shoeModel);
        }

        // POST: Admin/Shoe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdShoe,Name,Date,Img,Price,Sizes,Colors,Video,NumberSeri,Shoelate,Version,Materials,Type,Pro,Description,Status")] ShoeModel shoeModel)
        {
            if (id != shoeModel.IdShoe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoeModelExists(shoeModel.IdShoe))
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
            ViewData["Colors"] = new SelectList(_context.Color, "IdColor", "Name", shoeModel.Colors);
            ViewData["Materials"] = new SelectList(_context.MaterialModel, "IdMaterial", "Name", shoeModel.Materials);
            ViewData["Pro"] = new SelectList(_context.Producer, "IdPro", "Name", shoeModel.Pro);
            ViewData["Sizes"] = new SelectList(_context.Size, "IdSize", "IdSize", shoeModel.Sizes);
            ViewData["Type"] = new SelectList(_context.TypeShoe, "IdType", "Name", shoeModel.Type);
            return View(shoeModel);
        }

        // GET: Admin/Shoe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoeModel = await _context.Shoe
                .Include(s => s.Color)
                .Include(s => s.Material)
                .Include(s => s.Producer)
                .Include(s => s.Size)
                .Include(s => s.TypeShoe)
                .FirstOrDefaultAsync(m => m.IdShoe == id);
            if (shoeModel == null)
            {
                return NotFound();
            }

            return View(shoeModel);
        }

        // POST: Admin/Shoe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoeModel = await _context.Shoe.FindAsync(id);
            _context.Shoe.Remove(shoeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoeModelExists(int id)
        {
            return _context.Shoe.Any(e => e.IdShoe == id);
        }
    }
}
