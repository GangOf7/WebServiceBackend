using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PiratesBay.Data;
using PiratesBay.Models.BackGround;
using PiratesBay.Models.ViewModel;

namespace PiratesBay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceGrpahsController : ControllerBase
    {
        private readonly DataContext _context;
        public ILogger<DeviceDetailsController> _Logger { get; }

        public DeviceGrpahsController(DataContext context, ILogger<DeviceDetailsController> logger)
        {
            _context = context;
            _Logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var dataFromDB = await _context.SensorData
                                        .Where(w => w.Device_Id == Id)
                                        .Select(s => s.Param_Id)
                                        .Distinct()
                                        .ToListAsync();

                if (dataFromDB.Count > 0)
                {
                    return Ok(dataFromDB);
                }
                else
                {
                    return NotFound(0);
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Problem in getting the data from Sensor for parameter list of device : {ex.Message}");
                return BadRequest("Data not found");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphInput input)
        {
            try
            {
                var graphResponse = new GraphResponse
                {
                    DeviceID = input.DeviceID,
                    DeviceName = (await _context.Device_info.FindAsync(input.DeviceID)).Device_Name,
                    ParamID = input.ParameterID,
                    ParamName = (await _context.Parameter_Masters.FindAsync(input.ParameterID)).Param_Name,
                    ParameterValues = new List<ParamForGraph>()
                };

                switch (input.Type)
                {
                    case "Daily":

                        graphResponse.ParameterValues = await _context.SensorData
                                                    .Where(w => w.Device_Id == input.DeviceID && w.Param_Id == input.ParameterID)
                                                    .Select(s => new ParamForGraph
                                                    {
                                                        date = s.DataEntryTime,
                                                        value = s.Input_Value
                                                    }).ToListAsync();

                        return Ok(graphResponse);

                    default:
                        return BadRequest("Please select type as : Daily / Weekly / Monthly");
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Problem in getting the data for graph : {ex.Message}");
                return BadRequest("Data not present for the mentioned criteria");
            }
        }

    }
}
