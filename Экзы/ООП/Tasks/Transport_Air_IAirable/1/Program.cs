using System.Collections;
using System.Text;
using Zadachi_exam;

namespace exam
{
    class Program
    {
        static void Main(string[] argv)
        {
            IAir a1 = new Air(0,0,"Vadim");
            IAirable a2 = new Air(0, 100, "Aleksey");
            IAir a3 = new Air(25, 0, "Dima");
            IAirable a4 = new Air(-4, 230, "Aleksandr");
            IAirable a5 = new Air(30, 80, "Aleksandr");

            try
            {
                a1.Check();
                a2.Check();
                a3.Check();
                a4.Check();
                a5.Check();

                a1.Fly();
                a2.Fly();
                a3.Fly();
                a4.Fly();
                a5.Fly();
            }
            catch (MyException ex)
            { 
                Console.WriteLine(ex.Message);
            }

            //ex5
            List<Air>col= new();
            col.Add((Air)a1);
            col.Add((Air)a2);
            col.Add((Air)a3);
            col.Add((Air)a4);
            col.Add((Air)a5);

            var count = (from c in col
                        where c.Status == Air.condition.fly
                        select c).Count();

            Console.WriteLine("\nКоличество: " + count);

            var srSkor = (from c in col select c.Speed).Average();
            Console.WriteLine("Средняя скорость " + srSkor);
        }
    }

}
