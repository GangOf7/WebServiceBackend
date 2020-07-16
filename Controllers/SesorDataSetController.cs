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

namespace PiratesBay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesorDataSetController : ControllerBase
    {
        private readonly DataContext _Context;
        public ILogger<SesorDataSetController> _Logger { get; }

        public SesorDataSetController(DataContext Context, ILogger<SesorDataSetController> logger)
        {
            _Context = Context;
            _Logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SensorResponse response)
        {
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

    }
}
