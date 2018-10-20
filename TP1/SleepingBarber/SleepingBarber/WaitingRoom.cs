using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingBarber
{
    public class WaitingRoom
    {
        List<Chair> seats;
        private int nbFreeSeat = 0;
        public int maxSeats = 0;

        public WaitingRoom(List<Chair> seats, int maxSeats)
        {
            this.seats = seats;
            this.maxSeats = maxSeats;
            nbFreeSeat = maxSeats;
        }

        public bool hasFreeSeat()
        {
            return nbFreeSeat > 0;
        }

        public bool takeSeat()
        {
            if (hasFreeSeat())
            {
                foreach(Chair ch in seats)
                {
                    if (ch.takeChair())
                    {
                        nbFreeSeat--;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool freeSeat()
        {
            foreach (Chair ch in seats)
            {
                if (ch.freeChair())
                {
                    nbFreeSeat++;
                    return true;
                }
            }
            
            return false;
        }




    }
}
