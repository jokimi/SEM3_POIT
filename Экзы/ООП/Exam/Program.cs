using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            STime time1 = new STime(16, 18, 3);
            time1.Print();

            STime time2 = new STime(10, 30, 45);
            time2.Print();

            Console.WriteLine("Время 1 равно Время 2? " + time1.Equals(time2));
            Console.WriteLine("Время 1 больше Время 2? " + (time1 > time2));

            Console.WriteLine("Время 1: " + time1.ToString());
            Console.WriteLine("Время 2: " + time2.ToString());

            List<Car> cars = new List<Car>
            {
                new Car(60, "Бензин", 2019, "Toyota", "ABC123"),
                new Car(50, "Дизель", 2018, "BMW", "XYZ456"),
                new Car(70, "Бензин", 2020, "Honda", "DEF789"),
                new Car(55, "Электро", 2021, "Tesla", "GHI012"),
                new Car(65, "Бензин", 2017, "BMW", "JKL345")
            };

            var carsWithBrandToyota = cars.Where(car => car.Brand == "Toyota");
            Console.WriteLine("Машины бренда Toyota:");
            foreach (var car in carsWithBrandToyota)
            {
                Console.WriteLine(car.ToString());
            }

            var groupedCars = cars.GroupBy(car => car.Brand).Skip(1);
            Console.WriteLine("Машины сгруппированы по бренду, первыЙ элемент пропущен:");
            foreach (var group in groupedCars)
            {
                Console.WriteLine("Бренд: " + group.Key);
                foreach (var car in group)
                {
                    Console.WriteLine(car.ToString());
                }
            }

            string filePath = "output.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Машины бренда Toyota:");
                foreach (var car in carsWithBrandToyota)
                {
                    writer.WriteLine(car.ToString());
                }

                writer.WriteLine("Машины сгруппированы по бренду, первый элемент пропущен:");
                foreach (var group in groupedCars)
                {
                    writer.WriteLine("Бренд: " + group.Key);
                    foreach (var car in group)
                    {
                        writer.WriteLine(car.ToString());
                    }
                }
            }

            Console.WriteLine("Результат записан в файл " + filePath);
        }
    }
}