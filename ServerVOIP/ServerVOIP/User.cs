using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerVOIP
{
    public class User
    {
        public string Username;
        public string IP;
        public int online;

        public User(string username, string Ip)
        {
            Username = username;
            IP = Ip;
        }
    }
}
