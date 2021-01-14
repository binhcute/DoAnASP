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
    public class ProducerController : Controller
    {
        private readonly DPContext _context;

        public ProducerController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Producer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producer.ToListAsync());
        }

        // GET: Admin/Producer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producerModel = await _context.Producer
                .FirstOrDefaultAsync(m => m.IdPro == id);
            if (producerModel == null)
            {
                return NotFound();
            }

            return View(producerModel);
        }

        // GET: Admin/Producer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Producer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPro,Name,Description,Date")] ProducerModel producerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producerModel);
        }

        // GET: Admin/Producer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producerModel = await _context.Producer.FindAsync(id);
            if (producerModel == null)
            {
                return NotFound();
            }
            return View(producerModel);
        }

        // POST: Admin/Producer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPro,Name,Description,Date")] ProducerModel producerModel)
        {
            if (id != producerModel.IdPro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducerModelExists(producerModel.IdPro))
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
            return View(producerModel);
        }

        // GET: Admin/Producer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producerModel = await _context.Producer
                .FirstOrDefaultAsync(m => m.IdPro == id);
            if (producerModel == null)
            {
                return NotFound();
            }

            return View(producerModel);
        }

        // POST: Admin/Producer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerModel = await _context.Producer.FindAsync(id);
            _context.Producer.Remove(producerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducerModelExists(int id)
        {
            return _context.Producer.Any(e => e.IdPro == id);
        }
    }
}
