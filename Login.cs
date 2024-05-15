using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.entity
{
    internal class Login
    {

        string uname;
        string password;
        string name;
        int age;

        public Login()
        {
            uname = string.Empty;
            password = string.Empty;
            name = string.Empty;
            age = 0;
        }

        public Login(string un, string p, string n, int a)
        {
            uname = un;
            password = p;
            name = n;
            age = a;
            
        }

        public string Username
        {
            get { return uname; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }               
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }


    }
}
