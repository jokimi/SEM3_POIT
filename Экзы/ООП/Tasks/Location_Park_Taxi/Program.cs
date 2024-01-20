using System;
using System.Collections.Generic;
using System.Text;
using Zadacha_3;

namespace Exam
{
    class Program
    {
        static void Main(string[] argv)
        {
            Park<Taxi> uber = new Park<Taxi>();
            Taxi t1 = new("7074AM-7", Taxi.condition.free, 500, 300, 30); //1- широта(x), 2 - долгота(y)
            Taxi t2 = new("7174AM-4", Taxi.condition.busy, 600, 400, 90);
            Taxi t3 = new("3575BM-3", Taxi.condition.busy, 700, 500, 10);
            Taxi t4 = new("9074CC-6", Taxi.condition.free, 800, 600, 60);

            uber.Add(t1);
            uber.Add(t2);
            uber.Add(t3);
            uber.Add(t4);
            uber.Find((Taxi) => Taxi != null);

            (int x, int y) UserLocat = (550, 900);
            (int dist, string name) d1 = (Lenght.len(550, t2.location.lat,900, t2.location.lon), "t1");
            (int dist, string name) d2 = ((int)Math.Sqrt(Math.Pow(550 - t2.location.lat, 2) + Math.Pow(900 - t2.location.lon, 2)), "t2");
            (int dist, string name) d3 = ((int)Math.Sqrt(Math.Pow(550 - t3.location.lat, 2) + Math.Pow(900 - t3.location.lon, 2)), "t3");
            (int dist, string name) d4 = ((int)Math.Sqrt(Math.Pow(550 - t4.location.lat, 2) + Math.Pow(900 - t4.location.lon, 2)), "t4");

            List<(int, string)> newCol = new()
            {
                d1, d2, d3, d4
            };

            newCol.Sort();
            int count = 0;
            string name_ = "";
            foreach (var c in newCol)
            {
                count++;
                Console.WriteLine(c.ToString());
                if (count == 1)
                {
                    name_ = c.Item2;
                }
            }

            using (StreamWriter wr = new ("File.txt", false))
            {
                if(name_ == "t1")
                {
                    wr.WriteLine("Имя водителя: t1");
                    wr.WriteLine("Номер авто: " + t1.number);
                    wr.WriteLine("Статус: " + t1.status);
                    wr.WriteLine("Расстояние до водителя: " + d1.dist);
                }

                if (name_ == "t2")
                {
                    wr.WriteLine("Имя водителя: t2");
                    wr.WriteLine("Номер авто: " + t2.number);
                    wr.WriteLine("Статус: " + t2.status);
                    wr.WriteLine("Расстояние до водителя: " + d2.dist);
                }

                if (name_ == "t3")
                {
                    wr.WriteLine("Имя водителя: t3");
                    wr.WriteLine("Номер авто: " + t3.number);
                    wr.WriteLine("Статус: " + t3.status);
                    wr.WriteLine("Расстояние до водителя: " + d3.dist);
                }

                if (name_ == "t4")
                {
                    wr.WriteLine("Имя водителя: t4");
                    wr.WriteLine("Номер авто: " + t4.number);
                    wr.WriteLine("Статус: " + t4.status);
                    wr.WriteLine("Расстояние до водителя: " + d4.dist);
                }

            }


        }
    }
}