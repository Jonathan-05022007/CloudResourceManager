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
    public class VirtualMachinesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VirtualMachinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/VirtualMachines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VirtualMachine>>> GetVirtualMachines()
        {
            return await _context.VirtualMachines.ToListAsync();
        }

        // GET: api/VirtualMachines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VirtualMachine>> GetVirtualMachine(int id)
        {
            var virtualMachine = await _context.VirtualMachines.FindAsync(id);

            if (virtualMachine == null)
            {
                return NotFound();
            }

            return virtualMachine;
        }

        // PUT: api/VirtualMachines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVirtualMachine(int id, VirtualMachine virtualMachine)
        {
            if (id != virtualMachine.Id)
            {
                return BadRequest();
            }

            _context.Entry(virtualMachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VirtualMachineExists(id))
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

        // POST: api/VirtualMachines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VirtualMachine>> PostVirtualMachine(VirtualMachine virtualMachine)
        {
            _context.VirtualMachines.Add(virtualMachine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVirtualMachine", new { id = virtualMachine.Id }, virtualMachine);
        }

        // DELETE: api/VirtualMachines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVirtualMachine(int id)
        {
            var virtualMachine = await _context.VirtualMachines.FindAsync(id);
            if (virtualMachine == null)
            {
                return NotFound();
            }

            _context.VirtualMachines.Remove(virtualMachine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VirtualMachineExists(int id)
        {
            return _context.VirtualMachines.Any(e => e.Id == id);
        }
    }
}
