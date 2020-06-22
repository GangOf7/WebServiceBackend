using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PiratesBay.Data.IRepositories;
using PiratesBay.Models;
using PiratesBay.Services.Communication;

namespace PiratesBay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _Logger;

        public IUnitOfWork _UnitOfWork { get; }
        public Communicate _Communicate { get; }
        public TwilioSettings _TwilioOptions { get; }

        public ValuesController(IUnitOfWork unitOfWork, ILogger<ValuesController> logger, Communicate communicate)
        {
            _UnitOfWork = unitOfWork;
            _Logger = logger;
            _Communicate = communicate;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> GetAction()
        {
            try
            {
                var values = await _UnitOfWork.values.GetAllAsync();
                _Logger.LogInformation("Testing ValuesController Passed");
                return Ok(values);
            }
            catch (Exception ex)
            {
                _Logger.LogError($"\r\nError occured while trying to process request:\r\n" +
                    $"==============================================================================\r\n" +
                    $"Controller Section : Values\r\n" +
                    $"Method : Get\r\n" +
                    $"Parameter Required : No\r\n" +
                    $"Error message : {ex.Message}");

                return BadRequest($"\r\nError occured while trying to process request:\r\n" +
                    $"==============================================================================\r\n" +
                    $"Controller Section : Values\r\n" +
                    $"Method : Get\r\n" +
                    $"Parameter Required : No\r\n" +
                    $"Error message : {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            try
            {

                var value = await _UnitOfWork.values.GetAsync(id);
                _Logger.LogInformation("Testing ValuesController Passed with ID");
                return Ok(value);
            }
            catch (Exception ex)
            {
                _Logger.LogError($"\r\nError occured while trying to process request:\r\n" +
                    $"==============================================================================\r\n" +
                    $"Controller Section : Values\r\n" +
                    $"Method : Get\r\n" +
                    $"Parameter Required : Yes : ID {id}\r\n" +
                    $"Error message : {ex.Message}\r\n");

                return BadRequest($"\r\nError occured while trying to process request:\r\n" +
                    $"==============================================================================\r\n" +
                    $"Controller Section : Values\r\n" +
                    $"Method : Get\r\n" +
                    $"Parameter Required : Yes : ID {id}\r\n" +
                    $"Error message : {ex.Message}\r\n");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Value value)
        {
            try
            {
                await _UnitOfWork.values.AddAsync(value);
                await _UnitOfWork.SaveAsyn();
                _Logger.LogInformation($"Testing ValuesController Post passed for value{value.Name}");


                _Communicate.SendSMS(value);   // ASYNC call, not awaited


                return Created("New data added successfully", value);
            }
            catch (Exception ex)
            {
                _Logger.LogError($"\r\nError occured while trying to process request:\r\n" +
                    $"==============================================================================\r\n" +
                    $"Controller Section : Values\r\n" +
                    $"Method : POST\r\n" +
                    $"Parameter Required : Yes : From Body\r\n" +
                    $"Error message : {ex.Message}\r\n");

                return BadRequest($"\r\nError occured while trying to process request:\r\n" +
                    $"==============================================================================\r\n" +
                    $"Controller Section : Values\r\n" +
                    $"Method : POST\r\n" +
                    $"Parameter Required : Yes : From Body\r\n" +
                    $"Error message : {ex.Message}\r\n");
            }
        }

    }
}