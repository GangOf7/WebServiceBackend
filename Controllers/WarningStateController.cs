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
    public class WarningStateController : ControllerBase
    {
        private readonly DataContext _context;

        public WarningStateController(DataContext context)
        {
            _context = context;
        }

        // GET: api/WarningState
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarningStateDetails>>> GetWarningStateDetails()
        {
            return await _context.WarningStateDetails.ToListAsync();
        }

        // GET: api/WarningState/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WarningStateDetails>> GetWarningStateDetails(int id)
        {
            var warningStateDetails = await _context.WarningStateDetails.FindAsync(id);

            if (warningStateDetails == null)
            {
                return NotFound();
            }

            return warningStateDetails;
        }

        // PUT: api/WarningState/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarningStateDetails(int id, WarningStateDetails warningStateDetails)
        {
            if (id != warningStateDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(warningStateDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarningStateDetailsExists(id))
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

        // POST: api/WarningState
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WarningStateDetails>> PostWarningStateDetails(WarningStateDetails warningStateDetails)
        {
            _context.WarningStateDetails.Add(warningStateDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWarningStateDetails", new { id = warningStateDetails.Id }, warningStateDetails);
        }

        // DELETE: api/WarningState/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WarningStateDetails>> DeleteWarningStateDetails(int id)
        {
            var warningStateDetails = await _context.WarningStateDetails.FindAsync(id);
            if (warningStateDetails == null)
            {
                return NotFound();
            }

            _context.WarningStateDetails.Remove(warningStateDetails);
            await _context.SaveChangesAsync();

            return warningStateDetails;
        }

        private bool WarningStateDetailsExists(int id)
        {
            return _context.WarningStateDetails.Any(e => e.Id == id);
        }
    }
}
