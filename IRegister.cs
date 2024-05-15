using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.dao
{
    internal interface IRegister
    {

        bool AddUser(string username, string password, string name, int age);
    }
}
