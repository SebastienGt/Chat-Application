using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class User
    {
        string name;
        string pass;
        string email;

        public User(string n, string p, string e)
        {
            name = n;
            pass = p;
            email = e;
        }

        public string GetName()
        {
            return name;
        }
        public string GetPass()
        {
            return pass;
        }
        public string GetMail()
        {
            return email;
        }
        public bool IsTheSame(string username, string pass)
        {
            if (username == name && pass == this.pass)
            {
                return true;
            }
            return false;
        }
    }
}
