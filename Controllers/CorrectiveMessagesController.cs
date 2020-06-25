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
    public class CorrectiveMessagesController : ControllerBase
    {
        private readonly DataContext _context;

        public CorrectiveMessagesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CorrectiveMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorrectiveMessage>>> GetCorrectiveMessage()
        {
            return await _context.CorrectiveMessage.ToListAsync();
        }

        // GET: api/CorrectiveMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CorrectiveMessage>> GetCorrectiveMessage(int id)
        {
            var correctiveMessage = await _context.CorrectiveMessage.FindAsync(id);

            if (correctiveMessage == null)
            {
                return NotFound();
            }

            return correctiveMessage;
        }

        // PUT: api/CorrectiveMessages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorrectiveMessage(int id, CorrectiveMessage correctiveMessage)
        {
            if (id != correctiveMessage.Id)
            {
                return BadRequest();
            }

            _context.Entry(correctiveMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorrectiveMessageExists(id))
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

        // POST: api/CorrectiveMessages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CorrectiveMessage>> PostCorrectiveMessage(CorrectiveMessage correctiveMessage)
        {
            _context.CorrectiveMessage.Add(correctiveMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCorrectiveMessage", new { id = correctiveMessage.Id }, correctiveMessage);
        }

        // DELETE: api/CorrectiveMessages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CorrectiveMessage>> DeleteCorrectiveMessage(int id)
        {
            var correctiveMessage = await _context.CorrectiveMessage.FindAsync(id);
            if (correctiveMessage == null)
            {
                return NotFound();
            }

            _context.CorrectiveMessage.Remove(correctiveMessage);
            await _context.SaveChangesAsync();

            return correctiveMessage;
        }

        private bool CorrectiveMessageExists(int id)
        {
            return _context.CorrectiveMessage.Any(e => e.Id == id);
        }
    }
}
