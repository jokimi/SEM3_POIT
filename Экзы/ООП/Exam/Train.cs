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
    public class Train : Transport
    {
        public string Number { get; set; }
        public int NumberOfCars { get; set; }
        public int NumberOfPassengers { get; set; }

        public Train(double averageSpeed, string fuelType, int year,
            string number, int numberOfCars, int numberOfPassengers)
            : base(averageSpeed, fuelType, year)
        {
            Number = number;
            NumberOfCars = numberOfCars;
            NumberOfPassengers = numberOfPassengers;
        }

        public override void Move()
        {
            Console.WriteLine("Поезд едет.");
        }

        public override string ToString()
        {
            return $"Поезд {Number}, Вагоны: {NumberOfCars}, Пассажиры: {NumberOfPassengers}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Train other)
            {
                return Number == other.Number &&
                    NumberOfCars == other.NumberOfCars
                    && NumberOfPassengers == other.NumberOfPassengers;
            }
            return false;
        }
    }
}