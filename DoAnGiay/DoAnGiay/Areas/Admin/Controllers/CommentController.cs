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
    public class CommentController : Controller
    {
        private readonly DPContext _context;

        public CommentController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Comment
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.Comment.Include(c => c.Shoe);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/Comment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentModel = await _context.Comment
                .Include(c => c.Shoe)
                .FirstOrDefaultAsync(m => m.IdComment == id);
            if (commentModel == null)
            {
                return NotFound();
            }

            return View(commentModel);
        }

        // GET: Admin/Comment/Create
        public IActionResult Create()
        {
            ViewData["IdShoe"] = new SelectList(_context.Shoe, "IdShoe", "Name");
            return View();
        }

        // POST: Admin/Comment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdComment,Title,Content,IdShoe")] CommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdShoe"] = new SelectList(_context.Shoe, "IdShoe", "Name", commentModel.IdShoe);
            return View(commentModel);
        }

        // GET: Admin/Comment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentModel = await _context.Comment.FindAsync(id);
            if (commentModel == null)
            {
                return NotFound();
            }
            ViewData["IdShoe"] = new SelectList(_context.Shoe, "IdShoe", "Name", commentModel.IdShoe);
            return View(commentModel);
        }

        // POST: Admin/Comment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdComment,Title,Content,IdShoe")] CommentModel commentModel)
        {
            if (id != commentModel.IdComment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentModelExists(commentModel.IdComment))
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
            ViewData["IdShoe"] = new SelectList(_context.Shoe, "IdShoe", "Name", commentModel.IdShoe);
            return View(commentModel);
        }

        // GET: Admin/Comment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentModel = await _context.Comment
                .Include(c => c.Shoe)
                .FirstOrDefaultAsync(m => m.IdComment == id);
            if (commentModel == null)
            {
                return NotFound();
            }

            return View(commentModel);
        }

        // POST: Admin/Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commentModel = await _context.Comment.FindAsync(id);
            _context.Comment.Remove(commentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentModelExists(int id)
        {
            return _context.Comment.Any(e => e.IdComment == id);
        }
    }
}
