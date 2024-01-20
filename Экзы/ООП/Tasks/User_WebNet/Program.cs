using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json.Serialization;
using Zadacha_2;
using static System.Net.Mime.MediaTypeNames;

namespace Exam
{
    class Program
    {
        static void Main(string[]argv)
        {
            User user1= new User("BSTU@gmail.by","123456", User.znach.signin);
            User user2 = new User("Minsk@gmail.by", "aa111", User.znach.signout);
            User user3 = new User("Grodno@tut.by", "123456", User.znach.signin);
            User user4 = new User("Beloded@tut.by", "1111111", User.znach.signout);
            User user5 = new User("Patsei@yandex.by", "12345sss6", User.znach.signin);
            User[] us = { user1, user2, user3, user4, user5 };

            Console.WriteLine(user1.CompareTo(user2));
            Console.WriteLine(user2.CompareTo(user3));
            Console.WriteLine(user3.CompareTo(user4));
            Console.WriteLine(user4.CompareTo(user5));

            WebNet github= new WebNet();
            github.Add(user1);
            github.Add(user2);
            github.Add(user3);
            github.Add(user4);
            github.Add(user5);

            foreach(var g in github.users)
            {
                Console.WriteLine(g.ToString());
            }

            var count = (from g in github.users where g.status == User.znach.signin select g).Count();
            Console.WriteLine("Количество signIn: " + count);

            string fileName = "Ser.json";
            string json = JsonConvert.SerializeObject(us);
            Console.WriteLine("Объект сериализован!");
            Console.WriteLine(json);
            File.WriteAllText(fileName, json);

            var data = JsonConvert.DeserializeObject(json);
            Console.WriteLine("Объект десериализован:");
            Console.WriteLine("Название: " + data.ToString());


        }
    }
}