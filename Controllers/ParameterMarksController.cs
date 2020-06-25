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
    public class ParameterMarksController : ControllerBase
    {
        private readonly DataContext _context;

        public ParameterMarksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ParameterMarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParameterBenchmark>>> GetParameterBenchmark()
        {
            return await _context.ParameterBenchmark.ToListAsync();
        }

        // GET: api/ParameterMarks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParameterBenchmark>> GetParameterBenchmark(int id)
        {
            var parameterBenchmark = await _context.ParameterBenchmark.FindAsync(id);

            if (parameterBenchmark == null)
            {
                return NotFound();
            }

            return parameterBenchmark;
        }

        // PUT: api/ParameterMarks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParameterBenchmark(int id, ParameterBenchmark parameterBenchmark)
        {
            if (id != parameterBenchmark.Id)
            {
                return BadRequest();
            }

            _context.Entry(parameterBenchmark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParameterBenchmarkExists(id))
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

        // POST: api/ParameterMarks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ParameterBenchmark>> PostParameterBenchmark(ParameterBenchmark parameterBenchmark)
        {
            _context.ParameterBenchmark.Add(parameterBenchmark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParameterBenchmark", new { id = parameterBenchmark.Id }, parameterBenchmark);
        }

        // DELETE: api/ParameterMarks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ParameterBenchmark>> DeleteParameterBenchmark(int id)
        {
            var parameterBenchmark = await _context.ParameterBenchmark.FindAsync(id);
            if (parameterBenchmark == null)
            {
                return NotFound();
            }

            _context.ParameterBenchmark.Remove(parameterBenchmark);
            await _context.SaveChangesAsync();

            return parameterBenchmark;
        }

        private bool ParameterBenchmarkExists(int id)
        {
            return _context.ParameterBenchmark.Any(e => e.Id == id);
        }
    }
}
