using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public interface INumber
    {
        public int Number
        { get; set; }
    }

    public class Bill : INumber
    {
        public int num;
        public int Number
        {
            set
            {
                if (value >= 0 && (value == 5 || value == 10 || value == 20 || value == 50 || value == 100))
                {
                    num = value;
                }

                else
                {
                    throw new Exception("Нет такой купюры!");
                }
            }

            get
            {
                    return num;
            }
        }

        public Bill(int Number)
        {
            this.Number = Number;
        }
    }

    class Wallet<T> where T : Bill
    {
        public List<T> collection = new List<T>();

        public void Delete()
        {
            if (collection.Count == 0)
            {
                throw new Exception("No elements");
            }
            else
            {
                var minEl = (from c in collection select c.num).Min();

                foreach (var i in collection)
                {
                    if (i.num == minEl)
                    {
                        collection.Remove(i);
                    }
                }
            }
        }

        public void Add(T el)
        {
            int sum = 0;
            foreach(var i in collection)
            {
                sum+= i.num;
            }

            if ((sum + el.num) > 200)
            {
                throw new ToMuchMoney("Слишком много денег!");
            }
            collection.Add(el);
        }
    }

    class ToMuchMoney : Exception
    {
        public ToMuchMoney(string meassage) : base(meassage)
        {

        }
    }
}
