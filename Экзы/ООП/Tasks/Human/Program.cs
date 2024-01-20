using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TutorApp
{
    public class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Tutor : Human
    {
        public int Level { get; set; }
        public double Average { get; private set; }

        public Tutor(string name, int age, int level)
        {
            Name = name;
            Age = age;
            Level = level;
        }

        public void AddToAverage(double value)
        {
            Average += value;
        }

        public void SubtractFromAverage(double value)
        {
            Average -= value;
        }

        public static Tutor operator ++(Tutor tutor)
        {
            tutor.AddToAverage(1);
            return tutor;
        }

        public static Tutor operator --(Tutor tutor)
        {
            tutor.SubtractFromAverage(1);
            return tutor;
        }
    }

    public class Director
    {
        public event Action Up;
        public event Action Down;

        public void Promote()
        {
            Up?.Invoke();
        }

        public void Demote()
        {
            Down?.Invoke();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Human> people = new List<Human>
            {
                new Tutor("John", 30, 1),
                new Tutor("Alice", 25, 2),
                new Tutor("Bob", 35, 1),
                new Human { Name = "Emma", Age = 23 },
                new Human { Name = "David", Age = 28 }
            };

            Console.WriteLine("People:");

            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

                if (person is Tutor tutor)
                {
                    Console.WriteLine($"Level: {tutor.Level}");
                }
            }

            Console.WriteLine();

            List<Tutor> tutors = people.OfType<Tutor>().ToList();

            Console.WriteLine("Tutors:");

            foreach (var tutor in tutors)
            {
                Console.WriteLine($"Name: {tutor.Name}, Age: {tutor.Age}, Level: {tutor.Level}");
            }

            Console.WriteLine();

            tutors[0].AddToAverage(4.5);
            tutors[1].AddToAverage(3.7);
            tutors[2].AddToAverage(4.2);

            Console.WriteLine("Tutors' averages before operators:");
            foreach (var tutor in tutors)
            {
                Console.WriteLine($"Name: {tutor.Name}, Average: {tutor.Average}");
            }

            Console.WriteLine();

            tutors[0]++;
            tutors[1]--;
            tutors[2]++;

            Console.WriteLine("Tutors' averages after operators:");
            foreach (var tutor in tutors)
            {
                Console.WriteLine($"Name: {tutor.Name}, Average: {tutor.Average}");
            }

            Console.WriteLine();

            Director director = new Director();

            director.Up += () => tutors[0]++;
            director.Down += () => tutors[1]--;

            Console.WriteLine("Tutors' averages after director's actions:");
            foreach (var tutor in tutors)
            {
                Console.WriteLine($"Name: {tutor.Name}, Average: {tutor.Average}");
            }

            Console.WriteLine();

            double averageScore = tutors.Average(tutor => tutor.Average);
            Console.WriteLine($"Average score: {averageScore}");

            Console.WriteLine();

            string json = JsonSerializer.Serialize(people);

            // Запись сериализованной строки в файл
            File.WriteAllText("people.json", json);

            Console.WriteLine("Data has been serialized and saved to 'people.json' file.");
        }
    }
}