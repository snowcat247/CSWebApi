using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CSWebApi.Service
{
    public class ProbabilityService
    {
        private int falseCount = 0;
        private int trueCount = 0;
        private int numberofTimesToRun = 0;


        public ProbabilityService(int numberofTimesToRun)
        {
            this.numberofTimesToRun = numberofTimesToRun;



        }
        public decimal? RunProbability()
        {
            try
            {
                for (int timesRun = 1; timesRun <= numberofTimesToRun; timesRun++)
                {
                    SeatAllocationService seatAllocationService = new SeatAllocationService();
                    seatAllocationService.AllocateFirstRandomSeat();
                    seatAllocationService.AllocateRemainingSeats();
                    if (seatAllocationService.passengerHasSeat())
                    {
                        trueCount++;

                    }
                    else
                    {
                        falseCount++;
                    }


                }

                return trueCount / numberofTimesToRun;
            }

            catch(Exception e)
            {
                Console.WriteLine("Could not return a value");
                return null;
            }
        }
    }
}
