using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PiratesBay.Data;
using PiratesBay.Models.ViewModel;

namespace PiratesBay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserViewController : ControllerBase

    {
        public DataContext _context { get; }
        public ILogger<UserViewController> Logger { get; }

        public UserViewController(DataContext context, ILogger<UserViewController> logger)
        {
            _context = context;
            Logger = logger;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            try
            {
                var devices = await _context.UserDeviceMapping
                                            .Where(w => w.User_Id == id)
                                            .Select(s => s.Device_Id)
                                            .ToListAsync();

                var paramBenchMark = await _context.ParameterBenchmark.ToListAsync();
                //var correctiveActions = await _context.cor

                var userView = await _context.UserInfo
                                            .Where(w => w.Id == id)
                                            .Select(s => new UserView
                                            {
                                                ID = s.Id,
                                                EmailID = s.EmailAddress,
                                                Name = s.Name,
                                                DeviceCount = devices.Count(),
                                                DeviceDetail = new List<DeviceDetails>(),
                                            }).FirstOrDefaultAsync();

                foreach (var device in devices)
                {
                    var deviceDetails = _context.Device_info.Where(w => w.Id == device).Select(i => new DeviceDetails
                    {
                        Area = i.Area,
                        Country = i.Country,
                        Device_Name = i.Device_Name,
                        State = i.State,
                        Id = i.Id,
                        Color = "Green",
                        Status=i.Status,
                        ParameterValues = new List<ParametersValue>()
                    }).FirstOrDefault();

                    var parameters = await _context.SensorData
                                                    .Where(w => w.Device_Id == device)
                                                    .Select(s => s.Param_Id)
                                                    .Distinct()
                                                    .ToListAsync();

                    foreach (var param in parameters)
                    {
                        var paramDetails = _context.SensorData
                                            .Where(w => w.Device_Id == device && w.Param_Id == param)
                                            .OrderByDescending(o => o.DataEntryTime)
                                            .Select(s => new ParametersValue
                                            {
                                                LastValue = s.Input_Value,
                                                InputTime = s.DataEntryTime,
                                                Color = "Green",
                                                Action = false
                                            }).FirstOrDefault();

                        paramDetails.Name = await _context.Parameter_Masters
                                                    .Where(w => w.Id == param)
                                                    .Select(s => s.Param_Name)
                                                    .FirstOrDefaultAsync();

                        var HighRed = paramBenchMark.Where(w => w.Param_Id == param).Select(s => s.Red_Threshold_High).FirstOrDefault();
                        var LowRed = paramBenchMark.Where(w => w.Param_Id == param).Select(s => s.Red_Threshold_Low).FirstOrDefault();
                        var HighAmber = paramBenchMark.Where(w => w.Param_Id == param).Select(s => s.Amber_Threshold_High).FirstOrDefault();
                        var LowAmber = paramBenchMark.Where(w => w.Param_Id == param).Select(s => s.Amber_Threshold_Low).FirstOrDefault();

                        if (paramDetails.LastValue > HighRed || paramDetails.LastValue < LowRed)
                        {
                            paramDetails.Color = "Red";
                            paramDetails.Action = true;
                        }
                        else if (paramDetails.LastValue > HighAmber || paramDetails.LastValue < LowAmber)
                        {
                            paramDetails.Color = "Amber";
                            paramDetails.Action = true;
                        }


                        deviceDetails.ParameterValues.Add(paramDetails);
                    }

                    userView.DeviceDetail.Add(deviceDetails);
                }


                return Ok(userView);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error found while fetching data for UserView : {ex.Message}");
                return BadRequest("Error occured");
            }
        }
    }
}
