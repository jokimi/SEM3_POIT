using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_2
{
    class WebNet
    {
        public LinkedList<User> users = new LinkedList<User>();
        public void Add(User user)
        {
            users.AddFirst(user);
        }

        public void Remove(User user)
        {
            users.Remove(user);
        }
    }
}
