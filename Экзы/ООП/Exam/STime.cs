using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Exam;

namespace Exam
{
    public class STime
    {
        private int hours;
        private int minutes;
        private int seconds;

        public int Hours
        {
            get { return hours; }
            set
            {
                if (value >= 0 && value <= 23)
                    hours = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(Hours), "Недопустимое значение!");
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value >= 0 && value <= 59)
                    minutes = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(Minutes), "Недопустимое значение!");
            }
        }

        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (value >= 0 && value <= 59)
                    seconds = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(Seconds), "Недопустимое значение!");
            }
        }

        public STime()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }

        public STime(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public void Print()
        {
            Console.WriteLine($"{Hours} часов {Minutes} минут {Seconds} секунд");
        }

        public override string ToString()
        {
            return $"{Hours} часов {Minutes} минут {Seconds} секунд";
        }

        public override bool Equals(object obj)
        {
            if (obj is STime other)
            {
                return Hours == other.Hours &&
                    Minutes == other.Minutes
                    && Seconds == other.Seconds;
            }
            return false;
        }

        public static bool operator >(STime time1, STime time2)
        {
            if (time1.Hours > time2.Hours)
                return true;
            else if (time1.Hours < time2.Hours)
                return false;
            else
            {
                if (time1.Minutes > time2.Minutes)
                    return true;
                else if (time1.Minutes < time2.Minutes)
                    return false;
                else
                    return time1.Seconds > time2.Seconds;
            }
        }
        public static bool operator <(STime time1, STime time2)
        {
            if (time1.Hours < time2.Hours)
                return true;
            else if (time1.Hours > time2.Hours)
                return false;
            else
            {
                if (time1.Minutes < time2.Minutes)
                    return true;
                else if (time1.Minutes > time2.Minutes)
                    return false;
                else
                    return time1.Seconds < time2.Seconds;
            }
        }
    }
}