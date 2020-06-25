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
    public class UserDeviceMapController : ControllerBase
    {
        private readonly DataContext _context;

        public UserDeviceMapController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UserDeviceMap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDeviceMapping>>> GetUserDeviceMapping()
        {
            return await _context.UserDeviceMapping.ToListAsync();
        }

        // GET: api/UserDeviceMap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDeviceMapping>> GetUserDeviceMapping(int id)
        {
            var userDeviceMapping = await _context.UserDeviceMapping.FindAsync(id);

            if (userDeviceMapping == null)
            {
                return NotFound();
            }

            return userDeviceMapping;
        }

        // PUT: api/UserDeviceMap/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDeviceMapping(int id, UserDeviceMapping userDeviceMapping)
        {
            if (id != userDeviceMapping.Id)
            {
                return BadRequest();
            }

            _context.Entry(userDeviceMapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDeviceMappingExists(id))
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

        // POST: api/UserDeviceMap
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserDeviceMapping>> PostUserDeviceMapping(UserDeviceMapping userDeviceMapping)
        {
            _context.UserDeviceMapping.Add(userDeviceMapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDeviceMapping", new { id = userDeviceMapping.Id }, userDeviceMapping);
        }

        // DELETE: api/UserDeviceMap/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDeviceMapping>> DeleteUserDeviceMapping(int id)
        {
            var userDeviceMapping = await _context.UserDeviceMapping.FindAsync(id);
            if (userDeviceMapping == null)
            {
                return NotFound();
            }

            _context.UserDeviceMapping.Remove(userDeviceMapping);
            await _context.SaveChangesAsync();

            return userDeviceMapping;
        }

        private bool UserDeviceMappingExists(int id)
        {
            return _context.UserDeviceMapping.Any(e => e.Id == id);
        }
    }
}
