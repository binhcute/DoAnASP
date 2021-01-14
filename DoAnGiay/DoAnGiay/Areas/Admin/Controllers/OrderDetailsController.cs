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
    public class OrderDetailsController : Controller
    {
        private readonly DPContext _context;

        public OrderDetailsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/OrderDetails
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.OrderDetail.Include(o => o.Shoe);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetailsModel = await _context.OrderDetail
                .Include(o => o.Shoe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDetailsModel == null)
            {
                return NotFound();
            }

            return View(orderDetailsModel);
        }

        // GET: Admin/OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["Shoes"] = new SelectList(_context.Shoe, "IdShoe", "Name");
            return View();
        }

        // POST: Admin/OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdOrder,Shoes,SumMoney,Status")] OrderDetailsModel orderDetailsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetailsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Shoes"] = new SelectList(_context.Shoe, "IdShoe", "Name", orderDetailsModel.Shoes);
            return View(orderDetailsModel);
        }

        // GET: Admin/OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetailsModel = await _context.OrderDetail.FindAsync(id);
            if (orderDetailsModel == null)
            {
                return NotFound();
            }
            ViewData["Shoes"] = new SelectList(_context.Shoe, "IdShoe", "Name", orderDetailsModel.Shoes);
            return View(orderDetailsModel);
        }

        // POST: Admin/OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdOrder,Shoes,SumMoney,Status")] OrderDetailsModel orderDetailsModel)
        {
            if (id != orderDetailsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetailsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailsModelExists(orderDetailsModel.Id))
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
            ViewData["Shoes"] = new SelectList(_context.Shoe, "IdShoe", "Name", orderDetailsModel.Shoes);
            return View(orderDetailsModel);
        }

        // GET: Admin/OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetailsModel = await _context.OrderDetail
                .Include(o => o.Shoe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDetailsModel == null)
            {
                return NotFound();
            }

            return View(orderDetailsModel);
        }

        // POST: Admin/OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetailsModel = await _context.OrderDetail.FindAsync(id);
            _context.OrderDetail.Remove(orderDetailsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailsModelExists(int id)
        {
            return _context.OrderDetail.Any(e => e.Id == id);
        }
    }
}
