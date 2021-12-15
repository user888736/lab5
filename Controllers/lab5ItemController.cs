using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab5.Models;

namespace lab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class lab5ItemController : ControllerBase
    {
        private readonly lab5Context _context;

        public lab5ItemController(lab5Context context)
        {
            _context = context;
        }

        // GET: api/lab5Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<lab5Item>>> Getlab5Items()
        {
            return await _context.lab5Items.ToListAsync();
        }

        // GET: api/lab5Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<lab5Item>> Getlab5Item(long id)
        {
            var lab5Item = await _context.lab5Items.FindAsync(id);

            if (lab5Item == null)
            {
                return NotFound();
            }

            return lab5Item;
        }

        // PUT: api/lab5Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlab5Item(long id, lab5Item lab5Item)
        {
            if (id != lab5Item.Id)
            {
                return BadRequest();
            }

            _context.Entry(lab5Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!lab5ItemExists(id))
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

        // POST: api/lab5Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<lab5Item>> Postlab5Item(lab5Item lab5Item)
        {
            _context.lab5Items.Add(lab5Item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlab5Item", new { id = lab5Item.Id }, lab5Item);
        }

        // DELETE: api/lab5Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelab5Item(long id)
        {
            var lab5Item = await _context.lab5Items.FindAsync(id);
            if (lab5Item == null)
            {
                return NotFound();
            }

            _context.lab5Items.Remove(lab5Item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool lab5ItemExists(long id)
        {
            return _context.lab5Items.Any(e => e.Id == id);
        }
    }
}
