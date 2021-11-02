using CSWebApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProbabilityController : ControllerBase
    {
        

        private readonly ILogger<PassengerController> _logger;

        public ProbabilityController(ILogger<PassengerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{times:int}")]
        public decimal? GetProbability(int times)
        {
            ProbabilityService probabilityService = new ProbabilityService(times);
            return probabilityService.RunProbability();

        }
    }
}
