using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.exception
{
    internal class AppointIDNotFound : ApplicationException
    {
        public AppointIDNotFound()
        {

        }

        public AppointIDNotFound(string msg) : base(msg) 
        { 
        
        }
    }   
}
