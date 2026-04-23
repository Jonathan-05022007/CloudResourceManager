using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudResourceManager.Models;
using CloudResourcesManager.Models;

namespace CloudResourceManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagedDatabasesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ManagedDatabasesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ManagedDatabases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagedDatabase>>> GetManagedDatabases()
        {
            return await _context.ManagedDatabases.ToListAsync();
        }

        // GET: api/ManagedDatabases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagedDatabase>> GetManagedDatabase(int id)
        {
            var managedDatabase = await _context.ManagedDatabases.FindAsync(id);

            if (managedDatabase == null)
            {
                return NotFound();
            }

            return managedDatabase;
        }

        // PUT: api/ManagedDatabases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagedDatabase(int id, ManagedDatabase managedDatabase)
        {
            if (id != managedDatabase.Id)
            {
                return BadRequest();
            }

            _context.Entry(managedDatabase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagedDatabaseExists(id))
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

        // POST: api/ManagedDatabases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManagedDatabase>> PostManagedDatabase(ManagedDatabase managedDatabase)
        {
            _context.ManagedDatabases.Add(managedDatabase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManagedDatabase", new { id = managedDatabase.Id }, managedDatabase);
        }

        // DELETE: api/ManagedDatabases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagedDatabase(int id)
        {
            var managedDatabase = await _context.ManagedDatabases.FindAsync(id);
            if (managedDatabase == null)
            {
                return NotFound();
            }

            _context.ManagedDatabases.Remove(managedDatabase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagedDatabaseExists(int id)
        {
            return _context.ManagedDatabases.Any(e => e.Id == id);
        }
    }
}
