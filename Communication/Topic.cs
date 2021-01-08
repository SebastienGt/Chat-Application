using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class Topic
    {
        string name;
        public List<string> users = new List<string>();

        public Topic(string n)
        {
            name = n;
        }

        public void AddUser(string username)
        {
            if (!users.Contains(username))
                users.Add(username);
        }
    }
}
