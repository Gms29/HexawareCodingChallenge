using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.entity
{
    internal class Patient
    {
        int patientID;
        string fname;
        string lname;
        DateTime dateObirth;
        string gender;
        int pnumber;
        string address;

        public Patient()
        {
            patientID = 0;
            fname = string.Empty;
            lname = string.Empty;
            dateObirth = DateTime.MinValue;
            gender = string.Empty;
            pnumber = 0;
            address = string.Empty;

        }

        public Patient(int pid, string fn, string ln, DateTime dob, string g, int pnum, string add)
        {
            patientID = pid;
            fname = fn;
            lname = ln;
            dateObirth = dob;
            gender = g;
            pnumber = pnum;
            address = add;
        }


        //getter and setter properties
        public int PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }

        public string FName
        {
            get { return fname; }
            set { fname = value; }
        }

        public string LName
        {
            get { return lname; }
            set { lname = value; }            
        }

        public DateTime DateObirth
        {
            get { return dateObirth; }
            set { dateObirth = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int Pnumber
        {
            get { return pnumber; }
            set { pnumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}
