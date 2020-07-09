using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiratesBay.Data;

namespace PiratesBay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceSettingsController : ControllerBase
    {
        private readonly DataContext _context;

        public DeviceSettingsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get()
        {
            return Ok(30);
        }
    }
}
