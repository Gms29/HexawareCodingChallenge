using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.dao
{
    internal interface ILogin
    {
        bool Verify(string uname, string pass);        

    }
}
