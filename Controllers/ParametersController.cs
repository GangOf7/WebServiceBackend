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
    public class ParametersController : ControllerBase
    {
        private readonly DataContext _context;

        public ParametersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Parameters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parameter_Master>>> GetParameter_Masters()
        {
            return await _context.Parameter_Masters.ToListAsync();
        }

        // GET: api/Parameters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parameter_Master>> GetParameter_Master(int id)
        {
            var parameter_Master = await _context.Parameter_Masters.FindAsync(id);

            if (parameter_Master == null)
            {
                return NotFound();
            }

            return parameter_Master;
        }

        // PUT: api/Parameters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParameter_Master(int id, Parameter_Master parameter_Master)
        {
            if (id != parameter_Master.Id)
            {
                return BadRequest();
            }

            _context.Entry(parameter_Master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Parameter_MasterExists(id))
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

        // POST: api/Parameters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Parameter_Master>> PostParameter_Master(Parameter_Master parameter_Master)
        {
            _context.Parameter_Masters.Add(parameter_Master);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParameter_Master", new { id = parameter_Master.Id }, parameter_Master);
        }

        // DELETE: api/Parameters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parameter_Master>> DeleteParameter_Master(int id)
        {
            var parameter_Master = await _context.Parameter_Masters.FindAsync(id);
            if (parameter_Master == null)
            {
                return NotFound();
            }

            _context.Parameter_Masters.Remove(parameter_Master);
            await _context.SaveChangesAsync();

            return parameter_Master;
        }

        private bool Parameter_MasterExists(int id)
        {
            return _context.Parameter_Masters.Any(e => e.Id == id);
        }
    }
}
