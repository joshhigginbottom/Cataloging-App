#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CataloguingAppApi.Data;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace CataloguingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoriesController : ODataController
    {
        private readonly appContext _context;

        public DirectoriesController(appContext context)
        {
            _context = context;
        }

        // GET: api/Collectables
        [HttpGet]
        [EnableQuery]
        public IQueryable<Data.Directory> GetDirectories()
        {
            return _context.Directories;
        }

        // GET: api/Collectables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Data.Directory>> GetDirectory(int id)
        {
            var directory = await _context.Directories.FindAsync(id);

            if (directory == null)
            {
                return NotFound();
            }

            return directory;
        }

        // PUT: api/Collectables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectory(int id, Data.Directory directory)
        {
            if (id != directory.Hierarchynodeid)
            {
                return BadRequest();
            }

            _context.Entry(directory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectoryExists(id))
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
        public async Task<ActionResult<Data.Directory>> PostDirectory(Data.Directory directory)
        {
            _context.Directories.Add(directory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDirectory), new { id = directory.Hierarchynodeid }, directory);
        }

        // DELETE: api/Collectables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirectory(int id)
        {
            var directory = await _context.Directories.FindAsync(id);
            if (directory == null)
            {
                return NotFound();
            }

            _context.Directories.Remove(directory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectoryExists(int id)
        {
            return _context.Directories.Any(e => e.Hierarchynodeid == id);
        }
    }
}
