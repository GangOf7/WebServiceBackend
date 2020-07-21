using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PiratesBay.Data;
using PiratesBay.Models;
using PiratesBay.Models.BackGround;
using PiratesBay.Services.Communication;

namespace PiratesBay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDataSetController : ControllerBase
    {
        private readonly DataContext _Context;
        private readonly Communicate _communicate;
        public ILogger<SensorDataSetController> _Logger { get; }

        public SensorDataSetController(DataContext Context, ILogger<SensorDataSetController> logger, Communicate communicate)
        {
            _Context = Context;
            _Logger = logger;
            _communicate = communicate;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SensorResponse response)
        {
            try
            {
                var existingData = await _Context.SensorData
                                    .Where(w => w.Device_Id == response.DeviceId && w.DataEntryTime == response.dateTime)
                                    .ToListAsync();
                if (existingData.Count > 0) return BadRequest("Data already present with this date and time for this device");


                foreach (var paramData in response.DataSet)
                {
                    SensorData sensorData = new SensorData
                    {
                        DataEntryTime = response.dateTime,
                        Device_Id = response.DeviceId,
                        Input_Value = paramData.Value,
                        Param_Id = paramData.ParameterID
                    };
                    _Context.SensorData.Add(sensorData);
                }
                var deviceInfo = await _Context.Device_info.FindAsync(response.DeviceId);
                deviceInfo.lastupdatedon = response.dateTime;
                deviceInfo.GUID = Guid.NewGuid().ToString();

                _Context.Device_info.Update(deviceInfo);

                await _Context.SaveChangesAsync();

                SensorReply sensorReply = new SensorReply
                {
                    deviceID = response.DeviceId,
                    NewGuid = deviceInfo.GUID,
                    Interval = 30,
                    ThresHoldSets = await _Context.ParameterBenchmark.ToListAsync()
                };

                return Ok(sensorReply);
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Error in data {ex.Message}");
                return BadRequest($"Error in data{ex.Message}");
            }
            
        }

    }
}
