using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Park <T>
    {
        public List<T> collection= new ();

        public void Add(T el)
        {
            collection.Add(el);
        }

        public void Clear()
        {
            collection.Clear();
        }

        public void Delete(T el)
        {
            collection.Remove(el);
        }

        public void Find(Predicate <T> match)
        {
            collection.Find(match);
        }
    }
    public class Taxi
    {
        public string number;
        public Location location;
        public condition status;
        public enum condition {busy, free };

        public Taxi(string num, condition stat, int lat, int lon, int speed)
        {
            number = num;
            status = stat;
            location = new Location(lat, lon, speed);
        }

        public override string ToString()
        {
            Console.WriteLine("Номер: " + number);
            Console.WriteLine("Сатус: " + status);
            Console.WriteLine("Широта: " + location.lat);
            Console.WriteLine("Долгота: " + location.lon);
            Console.WriteLine("Скорость: " + location.speed);
            return "";
        }
    }
    public class Location
    {
        public int lat;
        public int lon; 
        public int speed;

       public Location(int lat, int lon, int speed)
        {
            this.lat = lat;
            this.lon = lon;
            this.speed = speed;
        }
    }
}
