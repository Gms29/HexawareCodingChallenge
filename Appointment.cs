using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.entity
{
    internal class Appointment
    {
        int appointmentId;
        int patientId;
        int doctorID;
        DateTime appointmentdate;
        string description;

        public Appointment()
        {
            appointmentId = 0;
            patientId = 0;
            doctorID = 0;
            appointmentdate = DateTime.MinValue;
            description = string.Empty;
        }

        public Appointment(int aid, int pid, int did, DateTime ad, string d)
        {
            appointmentId = aid;
            patientId = pid;
            doctorID = did;                
            appointmentdate = ad;
            description = d;
        }

        public int AppointmendID
        {
            get { return appointmentId; }
            set { appointmentId = value; }
        }

        public int PatientID
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public int DoctorID
        {
            get { return doctorID; }
            set { doctorID = value; }
        }

        public DateTime AppointmentDate
        {
            get { return appointmentdate; }
            set { appointmentdate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
