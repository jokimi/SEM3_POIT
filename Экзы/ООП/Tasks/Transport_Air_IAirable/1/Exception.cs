using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadachi_exam
{
    class MyException :Exception
    {
        public int value;
        public int value_1;
        public MyException(string messsage, int val) : base(messsage)
        {
            value = val;
        }

        public MyException(string messsage, int val, int val2) : base(messsage)
        {
            value = val;
            value_1 = val2;
        }

        public MyException(string messsage) : base(messsage)
        {
        }
    }
}
