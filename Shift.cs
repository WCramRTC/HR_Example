using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Example
{
    public class Shift
    {
        DateTime _start;
        DateTime _end;
        bool isWorking;
        bool shiftEnded;


        const int minutesInHour = 60;

        public bool IsWorking { get => isWorking; set => isWorking = value; }
        public bool ShiftEnded { get => shiftEnded; set => shiftEnded = value; }
        public DateTime End { get => _end; set => _end = value; }

        public Shift()
        {
            isWorking = false;
        }
        

        public Shift(DateTime start)
        {
            _start = start;
            isWorking = true;
        }

        public Shift(DateTime start, DateTime end)
        {
            _start = start;
            _end = end;
            isWorking = false;
        }

        // Method to clock out

        public void ClockIn()
        {
            _start = DateTime.Now;
            isWorking = true;
        }

        public void ClockOut()
        {
            _end = DateTime.Now;
            isWorking = false;
            shiftEnded = true;
        }

        // Returning seperate parts of our time span

        public int Hours()
        {
            return ShiftLength().Hours;
        }

        public int Minutes()
        {
            return ShiftLength().Minutes % minutesInHour;

            // 5 hours - 300 minutes
            // 5:10 - 310 minutes
            // Just return the 10 minutes?
        }

        // Methods only for formatted Display Information

        public string ShiftStarted()
        {
            return $"Shift Start : {_start.ToShortTimeString()}";
        }

        public string ShiftEnds()
        {
            return $"Shift End : {_end.ToShortTimeString()}";
        }

        public string ShiftTotal()
        {
            return $"Shift Total : {Hours()}:{Minutes()}";
        } // ShiftTotal()


        private TimeSpan ShiftLength()
        {
            return _end - _start;
        }

    } // class

} // namespace
