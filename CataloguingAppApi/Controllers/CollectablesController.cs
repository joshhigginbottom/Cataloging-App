#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CataloguingAppApi.Models;

namespace CataloguingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectablesController : ControllerBase
    {
        private readonly appContext _context;

        public CollectablesController(appContext context)
        {
            _context = context;
        }

        // GET: api/Collectables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collectable>>> GetCollectables()
        {
            return await _context.Collectables.ToListAsync();
        }

        // GET: api/Collectables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Collectable>> GetCollectable(int id)
        {
            var collectable = await _context.Collectables.FindAsync(id);

            if (collectable == null)
            {
                return NotFound();
            }

            return collectable;
        }

        // PUT: api/Collectables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollectable(int id, Collectable collectable)
        {
            if (id != collectable.Id)
            {
                return BadRequest();
            }

            _context.Entry(collectable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectableExists(id))
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

        // POST: api/Collectables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Collectable>> PostCollectable(Collectable collectable)
        {
            _context.Collectables.Add(collectable);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCollectable), new { id = collectable.Id }, collectable);
        }

        // DELETE: api/Collectables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollectable(int id)
        {
            var collectable = await _context.Collectables.FindAsync(id);
            if (collectable == null)
            {
                return NotFound();
            }

            _context.Collectables.Remove(collectable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollectableExists(int id)
        {
            return _context.Collectables.Any(e => e.Id == id);
        }
    }
}
