using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.entity
{
    internal class Doctor
    {
        int doctorID;
        string fname;
        string lname;
        string specialization;
        int contactnumber;

        public Doctor()
        {
            doctorID = 0;
            fname = string.Empty;
            lname = string.Empty;
            specialization = string.Empty;
            contactnumber = 0;
        }

        public Doctor(int did, string fn, string ln, string spec, int cn)
        {
            doctorID = did;
            fname = fn;
            lname = ln;
            specialization = spec;
            contactnumber = cn;
        }

        //getter and setter properties

        public int DoctorID
        {
            get { return doctorID; }
            set { doctorID = value; }               
        }

        public string Fname
        {
            get { return fname; }
            set { fname = value; }
        }

        public string Lname
        {
            get { return lname; }
            set { lname = value; }
        }

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public int Contactnumber
        {
            get { return contactnumber; }
            set { contactnumber = value; }               
        }



    }
}
