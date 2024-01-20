using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadachi_exam
{
    public class Air : Transport, IAirable, IAir
    {

        public string name;
        public int _CountOfPassanger;
        public int CountOfPassanger
        {
            set { _CountOfPassanger = value; }

            get { return _CountOfPassanger; }
        }
        public int _Speed;
        public int Speed
        {
            set { _Speed = value; }
            get { return _Speed; }
        }

        public condition _Status;
        public condition Status
        { get { return _Status; }
            set { _Status = value; }
        }
        public enum condition { fly, ready, stop, none };

        void IAirable.Check()
        {
            if (CountOfPassanger == 0 && Speed == 0)
            {
                Status = condition.stop;
            }

            else if (CountOfPassanger >= 0 && Speed == 0)
            {
                Status = condition.ready;
            }

            else if (CountOfPassanger >= 0 && Speed > 0)
            {
                Status = condition.fly;
            }

            else
            {
                Status = condition.none;
            }
        }
        public void Fly()
        {
            if(Status == condition.fly)
            {
                using (StreamWriter sw = new("file.txt", true))
                {
                    sw.WriteLine("Состояние: fly");
                }
              Console.WriteLine("Состояние: fly");
            }

            else if (Status == condition.ready)
            {
                using (StreamWriter sw = new("file.txt", true))
                {
                    sw.WriteLine("Состояние: ready");
                }
                Console.WriteLine("Состояние: ready");
            }

            else if (Status == condition.stop)
            {
                using (StreamWriter sw = new("file.txt", true))
                {
                    sw.WriteLine("Состояние: stop");
                }
                Console.WriteLine("Состояние: stop");
            }
            else if(Status == condition.none)
            {
                using (StreamWriter sw = new("file.txt", true))
                {
                    sw.WriteLine("Состояние не определено!");
                }
                throw new MyException("Состояние не определено!");
            }
        }

        void IAir.Check()
        {
            if (CountOfPassanger == 0 && Speed == 0)
            {
                Status = condition.stop;
            }

            else if (CountOfPassanger > 20 && Speed <100)
            {
                Status = condition.ready;
            }

            else if (CountOfPassanger >= 0 && Speed > 0)
            {
                Status = condition.fly;
            }

            else
            {
                Status = condition.none;
            }
        }

        public Air(int count, int speed, string n)
        {
            CountOfPassanger = count;
            Speed = speed;
            name = n;
        }
         
    }
}
