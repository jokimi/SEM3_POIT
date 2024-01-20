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
    public abstract class Transport
    {
        public double AverageSpeed { get; set; }
        public string FuelType { get; set; }
        public int Year { get; set; }

        protected Transport(double averageSpeed, string fuelType, int year)
        {
            AverageSpeed = averageSpeed;
            FuelType = fuelType;
            Year = year;
        }

        public abstract void Move();
    }
}