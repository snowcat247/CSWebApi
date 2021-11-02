using CSWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSWebApi.Service
{
    public class SeatAllocationService
    {

        List<Passenger> passengers = new List<Passenger>();
        List<int> usedSeats = new List<int>();
        

        public SeatAllocationService()
        {
            setPassengers();

        }

        private void setPassengers()
        {
            for(int proposedPassenger = 1; proposedPassenger <= 100; proposedPassenger++)
            {
                Passenger passenger = new Passenger();
                passenger.PassengerId = proposedPassenger;
                passengers.Add(passenger);
            }
        }

        public bool passengerHasSeat()
        {
            Passenger passenger = passengers.LastOrDefault();
            
            if(passenger.PassengerId == passenger.PassengerAssignedSeatNumber)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void AllocateRemainingSeats()
        {
            try
            {
                foreach (var passenger in passengers)
                {
                    if (passenger.PassengerAssignedSeatNumber == 0)
                    {
                        if (usedSeats.Contains(passenger.PassengerId))
                        {
                            passenger.PassengerAssignedSeatNumber = getRandomSeat();
                            
                        }
                        else
                        {
                            passenger.PassengerAssignedSeatNumber = passenger.PassengerId;
                            
                        }
                    }

                    usedSeats.Add(passenger.PassengerAssignedSeatNumber);

                }

            }
            catch(Exception e)
            {
                Console.WriteLine("error" + e.Message);
            }
            
        }

        public void AllocateFirstRandomSeat()
        {
           
         passengers.Find(a => a.PassengerId == 1).PassengerAssignedSeatNumber = getRandomSeat();

         usedSeats.Add(passengers.Where(b=>b.PassengerId==1).First().PassengerAssignedSeatNumber);

        }

        public int getRandomSeat()
        {

            try
            {
                int randomSeat = 0;

                Random randomSeatGenerator = new Random();
                bool isAllocated = false;
                while (isAllocated == false)
                {
                    randomSeat = randomSeatGenerator.Next(1, 100);
                    if (!usedSeats.Contains(randomSeat))
                    {
                        isAllocated = true;
                    }

                }

               // usedSeats.Add(randomSeat);

                return randomSeat;
            }
            catch(Exception e)
            {
                Console.WriteLine("error in random seat generator " + e.ToString());
                return 0;
            }
            

        }



    }
}
