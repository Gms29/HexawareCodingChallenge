using Hospital_Management.entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.dao
{
    internal class HospitalServiceImpl : IHospitalService
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public HospitalServiceImpl()
        {
            sqlConnection = new SqlConnection("Server=MSI;Database=GoBako;Trusted_Connection=True");
            cmd = new SqlCommand();
        }

        public Appointment getAppointmentById(int appointmentId)
        {
            Appointment ReqAppointment = new Appointment();

            try
            {
                cmd.CommandText = "Select * from Appointments WHERE aid = @ai;";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@ai", appointmentId);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                

                if (reader.Read())
                {
                    ReqAppointment.AppointmendID = (int)reader["aid"];
                    ReqAppointment.PatientID = (int)reader["apid"];
                    ReqAppointment.DoctorID = (int)reader["adid"];
                    ReqAppointment.AppointmentDate = (DateTime)reader["ad"];
                    ReqAppointment.Description = (string)reader["adesc"];
                }

                else
                    throw new exception.AppointIDNotFound($"Appointment with ID {appointmentId} not found.");

            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " Error handled");
            }

            finally
            {
                sqlConnection.Close();                
            }

            return ReqAppointment;

        }

        public List<Appointment> getAppointmentsForDoctors(int doctorId)
        {
            cmd.CommandText = "Select * from Appointments WHERE adid = @did;";
            cmd.Connection = sqlConnection;
            cmd.Parameters.AddWithValue("@did", doctorId);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Appointment> ReqApps = new List<Appointment>();

            while (reader.Read())
            {
                Appointment ReqDAppointment = new Appointment();
                ReqDAppointment.AppointmendID = (int)reader["aid"];
                ReqDAppointment.PatientID = (int)reader["apid"];
                ReqDAppointment.DoctorID = (int)reader["adid"];
                ReqDAppointment.AppointmentDate = (DateTime)reader["ad"];
                ReqDAppointment.Description = (string)reader["adesc"];
                ReqApps.Add(ReqDAppointment);
            }

            sqlConnection.Close ();
            return ReqApps;

        }

        public List<Appointment> getAppointmentsForPatient(int patientId)
        {
            cmd.CommandText = "Select * from Appointments WHERE apid = @pid;";
            cmd.Connection = sqlConnection;
            cmd.Parameters.AddWithValue("@pid", patientId);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Appointment> ReqPApps = new List<Appointment>();

            while (reader.Read())
            {
                Appointment ReqPAppointment = new Appointment();
                ReqPAppointment.AppointmendID = (int)reader["aid"];
                ReqPAppointment.PatientID = (int)reader["apid"];
                ReqPAppointment.DoctorID = (int)reader["adid"];
                ReqPAppointment.AppointmentDate = (DateTime)reader["ad"];
                ReqPAppointment.Description = (string)reader["adesc"];
                ReqPApps.Add(ReqPAppointment);
            }

            sqlConnection.Close();
            return ReqPApps;
        }

        public bool scheduleAppointment(Appointment appointment)
        {
            cmd.CommandText = "Insert into Appointments Values (@ai,@pid,@did,@da,@adesc);";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@ai", appointment.AppointmendID);
            cmd.Parameters.AddWithValue("@pid", appointment.PatientID); 
            cmd.Parameters.AddWithValue("@did", appointment.DoctorID);
            cmd.Parameters.AddWithValue("@da", appointment.AppointmentDate);
            cmd.Parameters.AddWithValue("@adesc", appointment.Description);
            
            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            if (status > 0)
                return true;
            else
                return false;     
                                 
        }

        public bool updateAppointment(Appointment appointment)
        {
            cmd.CommandText = "UPDATE Appointments SET apid = @pid, adid = @did, ad = @da, adesc = @adesc WHERE aid = @ai;";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@pid", appointment.PatientID);
            cmd.Parameters.AddWithValue("@did", appointment.DoctorID);
            cmd.Parameters.AddWithValue("@da", appointment.AppointmentDate);
            cmd.Parameters.AddWithValue("@adesc", appointment.Description);
            cmd.Parameters.AddWithValue("@ai", appointment.AppointmendID);

            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            if (status > 0) 
                return true;
            else
                return false;
            
        }

        public bool cancelAppointment(int appointmentId)
        {
            cmd.CommandText = "delete from Appointments where aid = @ai;";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@ai", appointmentId);          

            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            if (status > 0)
                return true;
            else
                return false;
        }

        public List<Doctor> getDoctorDetails()
        {
            cmd.CommandText = "Select * from Doctor;";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Doctor> Docs = new List<Doctor>();

            while (reader.Read())
            {
                Doctor d = new Doctor();
                d.DoctorID = (int)reader["did"];
                d.Fname = (string)reader["dfname"];
                d.Lname = (string)reader["dlname"];
                d.Specialization = (string)reader["spec"];
                d.Contactnumber = Convert.ToInt32(reader["cn"]);
                Docs.Add(d);
            }

            sqlConnection.Close();
            return Docs;
        }

        public bool AddPatient(Patient patient)
        {
            cmd.CommandText = "Insert into Patient Values (@pid,@pfname,@plname,@dob,@gender,@pnum,@padd);";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@pid", patient.PatientID);
            cmd.Parameters.AddWithValue("@pfname", patient.FName);
            cmd.Parameters.AddWithValue("@plname", patient.LName);
            cmd.Parameters.AddWithValue("@dob", patient.DateObirth);
            cmd.Parameters.AddWithValue("@gender", patient.Gender);
            cmd.Parameters.AddWithValue("@pnum", patient.Pnumber);
            cmd.Parameters.AddWithValue("@padd", patient.Address);

            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            if (status > 0)
                return true;
            else
                return false;


        }
    }
}
