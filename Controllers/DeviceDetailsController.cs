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
    public class DeviceDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public DeviceDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DeviceDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device_info>>> GetDevice_info()
        {
            return await _context.Device_info.ToListAsync();
        }

        // GET: api/DeviceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device_info>> GetDevice_info(int id)
        {
            var device_info = await _context.Device_info.FindAsync(id);

            if (device_info == null)
            {
                return NotFound();
            }

            return device_info;
        }

        // PUT: api/DeviceDetails/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice_info(int id, Device_info device_info)
        {
            if (id != device_info.Id)
            {
                return BadRequest();
            }

            _context.Entry(device_info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Device_infoExists(id))
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

        // POST: api/DeviceDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Device_info>> PostDevice_info(Device_info device_info)
        {
            _context.Device_info.Add(device_info);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevice_info", new { id = device_info.Id }, device_info);
        }

        // DELETE: api/DeviceDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Device_info>> DeleteDevice_info(int id)
        {
            var device_info = await _context.Device_info.FindAsync(id);
            if (device_info == null)
            {
                return NotFound();
            }
            var device_Mapping = await _context.UserDeviceMapping.Where(w => w.Device_Id == id).ToListAsync();
            _context.Device_info.Remove(device_info);
            if (device_Mapping.Count > 0)
            {
                _context.UserDeviceMapping.RemoveRange(device_Mapping);
            }
            await _context.SaveChangesAsync();
            return device_info;
        }

        private bool Device_infoExists(int id)
        {
            return _context.Device_info.Any(e => e.Id == id);
        }
    }
}
