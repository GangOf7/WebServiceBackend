using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiratesBay.Data;
using PiratesBay.Models;

namespace PiratesBay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarningsController : ControllerBase
    {
        private readonly DataContext _context;

        public WarningsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Warnings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarningMaster>>> GetWarningMaster()
        {
            return await _context.WarningMaster.ToListAsync();
        }

        // GET: api/Warnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WarningMaster>> GetWarningMaster(int id)
        {
            var warningMaster = await _context.WarningMaster.FindAsync(id);

            if (warningMaster == null)
            {
                return NotFound();
            }

            return warningMaster;
        }

        // PUT: api/Warnings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarningMaster(int id, WarningMaster warningMaster)
        {
            if (id != warningMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(warningMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarningMasterExists(id))
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

        // POST: api/Warnings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WarningMaster>> PostWarningMaster(WarningMaster warningMaster)
        {
            _context.WarningMaster.Add(warningMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWarningMaster", new { id = warningMaster.Id }, warningMaster);
        }

        // DELETE: api/Warnings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WarningMaster>> DeleteWarningMaster(int id)
        {
            var warningMaster = await _context.WarningMaster.FindAsync(id);
            if (warningMaster == null)
            {
                return NotFound();
            }

            _context.WarningMaster.Remove(warningMaster);
            await _context.SaveChangesAsync();

            return warningMaster;
        }

        private bool WarningMasterExists(int id)
        {
            return _context.WarningMaster.Any(e => e.Id == id);
        }
    }
}
