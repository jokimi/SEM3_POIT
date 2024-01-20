using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

namespace Exam
{
    class Program
    {
        static void Main()
        {
            try
            {
                Bill b1 = new(5);
                Bill b2 = new(10);
                Bill b3 = new(20);
                Bill b4 = new(50);
                Bill b5 = new(100);
                Bill b6 = new(100);

                Wallet<Bill> wallet= new Wallet<Bill>();
                wallet.Add(b1);
                wallet.Add(b2);
                wallet.Add(b3);
                wallet.Add(b4);
                wallet.Add(b5);
               

                //foreach (Bill b in wallet.collection)
                //{
                //    Console.WriteLine(b.num);
                //}

                var k1 = (from s in wallet.collection where s.num == 5 select s).Count();
                var k2 = (from s in wallet.collection where s.num == 10 select s).Count();
                var k3 = (from s in wallet.collection where s.num == 20 select s).Count();
                var k4 = (from s in wallet.collection where s.num == 50 select s).Count();
                var k5 = (from s in wallet.collection where s.num == 100 select s).Count();

                Console.WriteLine(k5);

                string fileName = "File.json";
                string json = JsonConvert.SerializeObject(wallet);
                Console.WriteLine("Объект сериализован!");
                File.WriteAllText(fileName, json);
                Console.WriteLine("Объект десериализован:");
                var data = JsonConvert.DeserializeObject(json);
                Console.WriteLine("Название: " + data);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}