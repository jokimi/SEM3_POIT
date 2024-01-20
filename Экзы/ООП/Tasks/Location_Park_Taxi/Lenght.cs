using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_3
{
    public static class Lenght
    {
        public static int len(int Startx, int x,int Starty, int y)
        {
            return ((int)Math.Sqrt(Math.Pow(Startx - x, 2) + Math.Pow(Starty - y, 2)));
        }
    }
}
