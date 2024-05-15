using Hospital_Management.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.dao
{
    internal interface IHospitalService
    {

        Appointment getAppointmentById(int appointmentId);

        List<Appointment> getAppointmentsForPatient(int patientId);

        List<Appointment> getAppointmentsForDoctors(int doctorId);

        bool scheduleAppointment(Appointment appointment);

        bool updateAppointment(Appointment appointment);

        bool cancelAppointment(int appointmentId);

        List<Doctor> getDoctorDetails();

        bool AddPatient(Patient patient);
      


    }
}
