using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_2
{
    class User : IComparable
    {
        private string email;
        private string password;
        public znach status;
        public enum znach {signin, signout};

        public override string ToString()
        {
            Console.WriteLine(email);
            Console.WriteLine(password);
            Console.WriteLine(status);
            return "";
        }

        public override int GetHashCode()
        {
            return email.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if(obj is User)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(object? obj)
        {
            if (obj is User user) return email.CompareTo(user.email);
            else throw new ArgumentException("Некорректное значение параметра");
        }

        public User(string e, string pas, znach st)
        {
            email = e;
            password = pas;
            status = st;
        }
    }
}
