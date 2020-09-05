using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DemoOverDataApp.Models;
using DemoOverDataApp.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoOverdataApp.Calcolo;
using DemoOverDataApp.Shared;

namespace DemoOverDataApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizzaController : ControllerBase
    {
        private readonly ILoggerService _logger;
        public PolizzaController(ILoggerService logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SimulaPremio([FromBody] PolizzaDataDTO dataDTO)
        {
            _logger.LogInfo($"Attempted call to compute Insurance Policy {dataDTO.TipoPolizza} ");
            try
            {
                if (dataDTO == null)
                {
                    _logger.LogWarn($"Empty request was submitted");
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"Polizza data request was incomplete");
                    return BadRequest(ModelState);
                }

                // Call to Validazione and CalcolaPremio
                var validaPol = new ValidazioneUL(dataDTO);
                var response = validaPol.ValidazioneAndCalcoloPremio();
                if (response != null)
                {
                    _logger.LogInfo($"Successfully computed insurance premium for {dataDTO.TipoPolizza} type.");
                    return Created("simulapremio", response);
                }
                else
                {
                    _logger.LogWarn($"Couldn't proceed to compute. Check request parameters and retry.");
                    return Created("simulapremio", $"Couldn't proceed to compute. Check request parameters and retry.");
                }
               
            }
            catch (Exception e)
            {
                return InternalError($"{e.Message} - {e.InnerException}");
            }
        }

        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong. Please contact the Administrator");
        }

    }
}
