using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PiratesBay.Data;
using PiratesBay.Models;
using PiratesBay.Models.ViewModel;

namespace PiratesBay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesByDeviceController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<ValuesByDeviceController> _logger;

        public ValuesByDeviceController(DataContext dataContext, ILogger<ValuesByDeviceController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var SensorDetails = await _dataContext.SensorData.Include("Parameter_Master").Where(w => w.Device_Id == id).ToListAsync();
                if (SensorDetails != null)
                {
                    var DeviceDetails = await _dataContext.Device_info
                                                .Where(w => w.Id == id)
                                                .Select(s => new DeviceWiseData
                                                {
                                                    Area = s.Area,
                                                    Country = s.Country,
                                                    Device_Id = s.Id,
                                                    Device_Name = s.Device_Name,
                                                    lastupdatedon = s.lastupdatedon,
                                                    Latitude = s.Latitude,
                                                    Longitude = s.Longitude,
                                                    State = s.State,
                                                    Status = s.Status,
                                                    ParameterNames = new List<ParametersValue>(),
                                                    Entries = new List<EntryTime>()

                                                }).FirstOrDefaultAsync();

                    var names = SensorDetails.Select(s => s.Parameter_Master.Param_Name).Distinct().ToList();
                    foreach(var name in names)
                    {
                        var pUnit = SensorDetails.Where(n => n.Parameter_Master.Param_Name == name).Select(s => s.Parameter_Master.Unit).FirstOrDefault();

                        var Param_values = new ParametersValue { Name = name, Unit = pUnit };
                         
                        DeviceDetails.ParameterNames.Add(Param_values);
                            
                    }
                    //SensorDetails.Select(s => new ParametersValue
                    //{

                    //    Name = s.Parameter_Master.Param_Name,
                    //    Unit = s.Parameter_Master.Unit

                    //}
                    // ).Distinct().ToList(),
               
                    var dates = SensorDetails.Select(s => s.DataEntryTime).Distinct().ToList();


                    foreach (var date in dates)
                    {
                        var entry = new EntryTime { datetime = date, Params = new List<ParamsForDevice>() };

                        entry.Params = SensorDetails
                                    .Where(w => w.DataEntryTime == date)
                                    .Select(s => new ParamsForDevice
                                    {
                                        ParameterName = s.Parameter_Master.Param_Name,
                                        Value = s.Input_Value,
                                        color = "Green"
                                    }).ToList();
                        DeviceDetails.Entries.Add(entry);
                    }

                    return Ok(DeviceDetails);
                }
                else
                {
                    return NotFound("No details found for this device");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error while getting the data{ex.Message}");
                return BadRequest("No data available for the device");
            }



        }
    }
}
