using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class SomeString : IComparer
    {
        public string str = "";
        public int countProb;

        public override bool Equals(object? obj)
        {
            if(obj is SomeString ss)
            {
                if(ss.str.Length == this.str.Length && ss.str[0] == this.str[0] && ss.str[ss.str.Length-1] == this.str[this.str.Length-1])
                    return true;
            }
            return false;
        }
        public SomeString(string stroke)
        {
            this.str = stroke;
            countProb = stroke.CountProb();
        }


        public int Compare(object? x, object? y)
        {
            if (x is SomeString sx && y is SomeString sy)
            {
                return Compare(x, y);
            }

            throw new Exception("Объекты не являются экземплярмаи класса SomeString!");
        }

        public static string operator +(SomeString a, char b)
        {
            if(a == null)
            {
                throw new Exception("Строка пустая!");
            }
            return a.str + b;
        }

        public static string operator -(SomeString a)
        {
            if (a == null)
            {
                throw new Exception("Строка пустая!");
            }
            string newStr = a.str.Substring(1);
            return newStr;
        }

    }

    static class Dop
    {
        public static int CountProb(this string str)
        {
            int count = 0, i =0;
            while(i!=str.Length)
            {
                if (str[i] == ' ')
                    count++;

                i++;
            }
            return count;
        }

        public static string deleteZnak(this string str)
        {
            string newStr = "";
            int i = 0, j = 0;
            bool flag = false;
            char[] arr = { '.', ',', '!', ':', '-' };
            while(i!= str.Length)
            {
                while(j != arr.Length)
                {
                    if (str[i] == arr[j])
                    {
                        flag = true;
                    }
                    j++;
                }
                j = 0;

                if(!flag)
                {
                    newStr += str[i];
                }
                i++;
                flag = false;
            }

            return newStr;
        }
    }
}
