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
    public class CorrectivesController : ControllerBase
    {
        private readonly DataContext _context;

        public CorrectivesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Correctives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warning_Corrective_Mapping>>> GetWarning_Corrective_Mapping()
        {
            return await _context.Warning_Corrective_Mapping.ToListAsync();
        }

        // GET: api/Correctives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Warning_Corrective_Mapping>> GetWarning_Corrective_Mapping(int id)
        {
            var warning_Corrective_Mapping = await _context.Warning_Corrective_Mapping.FindAsync(id);

            if (warning_Corrective_Mapping == null)
            {
                return NotFound();
            }

            return warning_Corrective_Mapping;
        }

        // PUT: api/Correctives/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarning_Corrective_Mapping(int id, Warning_Corrective_Mapping warning_Corrective_Mapping)
        {
            if (id != warning_Corrective_Mapping.Id)
            {
                return BadRequest();
            }

            _context.Entry(warning_Corrective_Mapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Warning_Corrective_MappingExists(id))
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

        // POST: api/Correctives
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Warning_Corrective_Mapping>> PostWarning_Corrective_Mapping(Warning_Corrective_Mapping warning_Corrective_Mapping)
        {
            _context.Warning_Corrective_Mapping.Add(warning_Corrective_Mapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWarning_Corrective_Mapping", new { id = warning_Corrective_Mapping.Id }, warning_Corrective_Mapping);
        }

        // DELETE: api/Correctives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Warning_Corrective_Mapping>> DeleteWarning_Corrective_Mapping(int id)
        {
            var warning_Corrective_Mapping = await _context.Warning_Corrective_Mapping.FindAsync(id);
            if (warning_Corrective_Mapping == null)
            {
                return NotFound();
            }

            _context.Warning_Corrective_Mapping.Remove(warning_Corrective_Mapping);
            await _context.SaveChangesAsync();

            return warning_Corrective_Mapping;
        }

        private bool Warning_Corrective_MappingExists(int id)
        {
            return _context.Warning_Corrective_Mapping.Any(e => e.Id == id);
        }
    }
}
