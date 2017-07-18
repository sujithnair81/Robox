using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHours
{
    class Program
    {
        static void Main(string[] args)
        {
            List<StoreHours> st = new List<StoreHours>();
            var st1 = new StoreHours(1, new TimeSpan(10,10,1) , new TimeSpan(21, 10,1));
            var st2 = new StoreHours(2, new TimeSpan(10, 10, 1), new TimeSpan(21, 10, 1));
            var st4 = new StoreHours(3, new TimeSpan(10, 10, 1), new TimeSpan(21, 10, 1));
            var st3 = new StoreHours(4, new TimeSpan(10, 10, 1), new TimeSpan(21, 10, 1));
            var st5 = new StoreHours(5, new TimeSpan(10, 10, 1), new TimeSpan(21, 10, 1));
            var st6 = new StoreHours(6, new TimeSpan(10, 10, 1), new TimeSpan(21, 10, 1));
            var st7 = new StoreHours(7);

            Console.ReadLine();
        }


    }

    public enum Day
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday  = 4,
        Friday =5 ,
        Saturday = 6,
        Sunday = 7


    }
    public class StoreHours
    {
        private int _dayOfWeek;
        private TimeSpan  _startTime, _endTime;
        private bool _closed;
        public StoreHours(int dayOfWeek, TimeSpan  startTime, TimeSpan  endTime)
        {
            ValidateDay(dayOfWeek);
            ValidateTimeSpan(startTime, endTime);
            _dayOfWeek = dayOfWeek;
            _startTime = startTime;
            _endTime = endTime;


        }

        public StoreHours(int dayOfWeek)
        {
            ValidateDay(dayOfWeek);
            _dayOfWeek = dayOfWeek;
            _closed = true;
        }

        void ValidateDay(int day)
        {
            if (day < 0 || day > 7)
            {
                throw new Exception("Invalid day");
            }
        }

        void ValidateTimeSpan(TimeSpan start, TimeSpan end)
        {
            if (start > end)
            {
                throw new Exception("Invalid timespan");
            }
        }


    }
}
