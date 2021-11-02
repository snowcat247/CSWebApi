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
    public class PassengerController : ControllerBase
    {
        

        private readonly ILogger<PassengerController> _logger;

        public PassengerController(ILogger<PassengerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public bool Get()
        {
            SeatAllocationService seatAllocationService = new SeatAllocationService();
            seatAllocationService.AllocateFirstRandomSeat();
            seatAllocationService.AllocateRemainingSeats();

            return seatAllocationService.passengerHasSeat();

        }
    }
}
