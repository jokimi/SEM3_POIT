using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TimeApp
{
    class Time : IComparable<Time>
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
                    throw new ArgumentException("Hours must be between 0 and 23.");
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
                    throw new ArgumentException("Minutes must be between 0 and 59.");
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
                    throw new ArgumentException("Seconds must be between 0 and 59.");
            }
        }

        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int CompareTo(Time other)
        {
            if (Hours == other.Hours && Minutes == other.Minutes)
                return 0;
            else if (Hours > other.Hours || (Hours == other.Hours && Minutes > other.Minutes))
                return 1;
            else
                return -1;
        }

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Создание объекта Time и проверка свойств
            Time time1 = new Time(10, 30, 15);
            Console.WriteLine($"Time 1: {time1}");

            try
            {
                time1.Hours = 25; // Некорректное значение - вызов исключения
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Time time2 = new Time(10, 30, 45);
            Console.WriteLine($"Time 2: {time2}");

            // 2. Сравнение двух объектов Time
            int compareResult = time1.CompareTo(time2);
            Console.WriteLine($"Compare result: {compareResult}");

            // 3. Создание массива времен и использование LINQ для выборки
            Time[] times = new Time[]
            {
                new Time(2, 15, 0),
                new Time(8, 45, 30),
                new Time(13, 0, 0),
                new Time(18, 30, 45),
                new Time(23, 0, 15),
                new Time(1, 30, 0)
            };

            var nightTimes = times.Where(t => t.Hours >= 24 || t.Hours < 5).OrderBy(t => t.Hours).ThenBy(t => t.Minutes);
            var morningTimes = times.Where(t => t.Hours >= 5 && t.Hours < 12).OrderBy(t => t.Hours).ThenBy(t => t.Minutes);
            var dayTimes = times.Where(t => t.Hours >= 12 && t.Hours < 18).OrderBy(t => t.Hours).ThenBy(t => t.Minutes);
            var eveningTimes = times.Where(t => t.Hours >= 18 && t.Hours < 24).OrderBy(t => t.Hours).ThenBy(t => t.Minutes);

            Console.WriteLine("Night Times:");
            foreach (var time in nightTimes)
            {
                Console.WriteLine(time);
            }

            Console.WriteLine("Morning Times:");
            foreach (var time in morningTimes)
            {
                Console.WriteLine(time);
            }

            Console.WriteLine("Day Times:");
            foreach (var time in dayTimes)
            {
                Console.WriteLine(time);
            }

            Console.WriteLine("Evening Times:");
            foreach (var time in eveningTimes)
            {
                Console.WriteLine(time);
            }

            // 4. Сериализация объекта Time в JSON
            string json = JsonSerializer.Serialize(time1);
            Console.WriteLine("Serialized JSON: " + json);

            // Запись результатов в файл
            File.WriteAllText("times.txt", $"Night Times:\n{string.Join("\n", nightTimes)}\n\nMorning Times:\n{string.Join("\n", morningTimes)}\n\nDay Times:\n{string.Join("\n", dayTimes)}\n\nEvening Times:\n{string.Join("\n", eveningTimes)}");
            // Сериализация объекта Time в JSON и запись в файл
            json = JsonSerializer.Serialize(time1);
            File.WriteAllText("time.json", json);
        }
    }    
}