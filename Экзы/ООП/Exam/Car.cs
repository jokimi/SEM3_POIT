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
    public class Car : Transport
    {
        public string Brand { get; set; }
        public string Number { get; set; }

        public Car(double averageSpeed, string fuelType, int year, string brand, string number)
            : base(averageSpeed, fuelType, year)
        {
            Brand = brand;
            Number = number;
        }

        public override void Move()
        {
            Console.WriteLine("Машина едет");
        }

        public override string ToString()
        {
            return $"{Brand}, Номер: {Number}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Car other)
            {
                return Brand == other.Brand && Number == other.Number;
            }
            return false;
        }
    }
}