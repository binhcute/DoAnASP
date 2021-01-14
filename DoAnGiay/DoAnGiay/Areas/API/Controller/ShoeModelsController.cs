using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAnGiay.Areas.Admin.Data;
using DoAnGiay.Areas.Admin.Models;
using Newtonsoft.Json;

namespace DoAnGiay.Areas.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeModelsController : ControllerBase
    {
        private readonly DPContext _context;

        public ShoeModelsController(DPContext context)
        {
            _context = context;
        }

        // GET: api/ShoeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoeModel>>> GetShoe()
        {
            return await _context.Shoe.ToListAsync();
        }
        [HttpGet("GETdata")]
        public String searchAPI(String keyword)
        {
            var s = from cc in _context.Shoe
                    where cc.Name.Contains(keyword)
                    select cc;
            return JsonConvert.SerializeObject(s);
        }
        // GET: api/ShoeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoeModel>> GetShoeModel(int id)
        {
            var shoeModel = await _context.Shoe.FindAsync(id);

            if (shoeModel == null)
            {
                return NotFound();
            }

            return shoeModel;
        }

        // PUT: api/ShoeModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoeModel(int id, ShoeModel shoeModel)
        {
            if (id != shoeModel.IdShoe)
            {
                return BadRequest();
            }

            _context.Entry(shoeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoeModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShoeModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShoeModel>> PostShoeModel(ShoeModel shoeModel)
        {
            _context.Shoe.Add(shoeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoeModel", new { id = shoeModel.IdShoe }, shoeModel);
        }

        // DELETE: api/ShoeModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoeModel>> DeleteShoeModel(int id)
        {
            var shoeModel = await _context.Shoe.FindAsync(id);
            if (shoeModel == null)
            {
                return NotFound();
            }

            _context.Shoe.Remove(shoeModel);
            await _context.SaveChangesAsync();

            return shoeModel;
        }

        private bool ShoeModelExists(int id)
        {
            return _context.Shoe.Any(e => e.IdShoe == id);
        }
    }
}
