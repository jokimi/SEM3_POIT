using System;
using System.Collections.Generic;
using System.Linq;

namespace CarApp
{
    public enum CarStatus
    {
        Free,
        Busy
    }

    public class Car
    {
        public decimal PricePerDay { get; set; }
        public string Number { get; set; }
        public CarStatus Status { get; set; }

        public decimal GetPrice(int days)
        {
            return days * PricePerDay;
        }
    }

    public class LuxCar : Car
    {
        public decimal Insurance { get; set; }

        public new decimal GetPrice(int days)
        {
            return days * PricePerDay + Insurance;
        }
    }

    public class CarSharing<T> : List<T> where T : Car
    {
        public void ShowCarStatus()
        {
            var freeCars = this.Where(c => c.Status == CarStatus.Free);
            var busyCars = this.Where(c => c.Status == CarStatus.Busy);

            Console.WriteLine("Free cars:");
            foreach (var car in freeCars)
            {
                Console.WriteLine($"Number: {car.Number}, Status: {car.Status}");
            }

            Console.WriteLine("Busy cars:");
            foreach (var car in busyCars)
            {
                Console.WriteLine($"Number: {car.Number}, Status: {car.Status}");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (CarSharing<T>)obj;
            return this.SequenceEqual(other);
        }

        public override int GetHashCode()
        {
            return this.Aggregate(0, (current, car) => current ^ car.GetHashCode());
        }
    }

    public class Manager
    {
        public event Action<Car> Discount;

        public void ApplyDiscount(Car car)
        {
            Discount?.Invoke(car);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CarSharing<Car> carSharing = new CarSharing<Car>
            {
                new Car { PricePerDay = 50, Number = "A123", Status = CarStatus.Free },
                new Car { PricePerDay = 60, Number = "B456", Status = CarStatus.Busy },
                new Car { PricePerDay = 70, Number = "C789", Status = CarStatus.Free },
                new LuxCar { PricePerDay = 100, Number = "L001", Insurance = 20, Status = CarStatus.Free },
                new LuxCar { PricePerDay = 120, Number = "L002", Insurance = 30, Status = CarStatus.Busy }
            };

            Console.WriteLine("Car prices:");
            foreach (var car in carSharing)
            {
                Console.WriteLine($"Number: {car.Number}, Price per day: {car.PricePerDay}");
            }

            int days = 3;
            Console.WriteLine($"Calculating price for {days} day(s):");
            foreach (var car in carSharing)
            {
                decimal price = car.GetPrice(days);
                Console.WriteLine($"Number: {car.Number}, Price: {price}");
            }

            Console.WriteLine("Car status:");
            carSharing.ShowCarStatus();

            Manager manager = new Manager();
            manager.Discount += car => car.PricePerDay -= 10;
            manager.Discount += car =>
            {
                if (car is LuxCar luxCar)
                {
                    luxCar.Insurance = 0;
                }
            };

            Console.WriteLine("Applying discounts:");
            foreach (var car in carSharing)
            {
                manager.ApplyDiscount(car);
                Console.WriteLine($"Number: {car.Number}, Price per day: {car.PricePerDay}, Insurance: {(car is LuxCar luxCar ? luxCar.Insurance.ToString() : "N/A")}");
            }

            Console.WriteLine("Top 5 most expensive cars:");
            var top5ExpensiveCars = carSharing.OrderByDescending(car => car.GetPrice(1)).Take(5);
            foreach (var car in top5ExpensiveCars)
            {
                Console.WriteLine($"Number: {car.Number}, Price per day: {car.PricePerDay}");
            }
        }
    }
}