using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management.dao;
using Hospital_Management.entity;

namespace Hospital_Management.HospitalManagementApp
{
    internal class Menu
    {
        public void Enter()
        {
            HospitalServiceImpl obj = new HospitalServiceImpl();

            while(true)
            {
                Console.WriteLine("Enter 1 for Getting Appointment details");
                Console.WriteLine("Enter 2 for Checking Availabilty for Doctors");
                Console.WriteLine("Enter 3 for Getting Appointment for Patients ");
                Console.WriteLine("Enter 4 for Scheduling an Appointment");
                Console.WriteLine("Enter 5 for Updating Appointment Details");
                Console.WriteLine("Enter 6 for Cancelling an Appointment");
                Console.WriteLine("Enter 7 for Getting Doctor list and details");
                Console.WriteLine("Enter 0 for Exiting the menu");

                int uch = int.Parse(Console.ReadLine());

                if (uch == 0)
                {
                    Console.WriteLine("You are exiting Menue");
                    break;
                }

                else if (uch == 1)
                {
                    Console.WriteLine("Please enter Appointment ID");
                    int aptid = int.Parse(Console.ReadLine());
                    Appointment apt = new Appointment();
                    apt = obj.getAppointmentById(aptid);

                    Console.WriteLine($"Appointment ID: {apt.AppointmendID}");
                    Console.WriteLine($"Patient ID: {apt.PatientID}");  
                    Console.WriteLine($"Doctor ID: {apt.DoctorID}");
                    Console.WriteLine($"Appointment Date: {apt.AppointmentDate}");
                    Console.WriteLine($"Description: {apt.Description}");

                    continue;
                    
                }

                else if(uch == 2)
                {
                    Console.WriteLine("Please Enter Doctor ID");
                    int did = int.Parse(Console.ReadLine());

                    List<Appointment> apt = new List<Appointment>();
                    apt = obj.getAppointmentsForDoctors(did);

                    foreach (var apts in apt) 
                    {
                        Console.WriteLine($"Appointment ID: {apts.AppointmendID}");
                        Console.WriteLine($"Patient ID: {apts.PatientID}");
                        Console.WriteLine($"Doctor ID: {apts.DoctorID}");
                        Console.WriteLine($"Appointment Date: {apts.AppointmentDate}");
                        Console.WriteLine($"Description: {apts.Description}");
                    }

                    continue;
                }

                else if (uch == 3)
                {

                    Console.WriteLine("Please Enter Patient ID");
                    int pid = int.Parse(Console.ReadLine());

                    List<Appointment> apt = new List<Appointment>();
                    apt = obj.getAppointmentsForDoctors(pid);

                    foreach (var apts in apt)
                    {
                        Console.WriteLine($"Appointment ID: {apts.AppointmendID}");
                        Console.WriteLine($"Patient ID: {apts.PatientID}");
                        Console.WriteLine($"Doctor ID: {apts.DoctorID}");
                        Console.WriteLine($"Appointment Date: {apts.AppointmentDate}");
                        Console.WriteLine($"Description: {apts.Description}");
                    }

                    continue;

                }
                 
                else if (uch == 4)
                {

                    Console.WriteLine("Enter 1 or new patient");
                    Console.WriteLine("Enter 2 for Existing patient");
                    int pc = int.Parse(Console.ReadLine());

                    if (pc == 1 )
                    {
                        Patient p = new Patient();
                        Console.WriteLine("Enter Pid");
                        p.PatientID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter First name");
                        p.FName = Console.ReadLine();
                        Console.WriteLine("Enter Last name");
                        p.LName = Console.ReadLine();
                        Console.WriteLine("Enter Dob as yyyy-mm-dd");
                        p.DateObirth = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Gender");
                        p.Gender = Console.ReadLine();
                        Console.WriteLine("Enter phone number");
                        p.Pnumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Address");
                        p.Address = Console.ReadLine();

                        if (obj.AddPatient(p))
                            Console.WriteLine("Patient Succesfully Entered");
                        else
                            Console.WriteLine("Try Again");
                           

                    }

                    else
                    {
                        Appointment apt = new Appointment();

                        Console.WriteLine("Enter Appointment ID given");
                        apt.AppointmendID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Patient ID given");
                        apt.PatientID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Doctor ID given");
                        apt.DoctorID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Date of appointment");
                        apt.AppointmentDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter description of Appointment");
                        apt.Description = Console.ReadLine();

                        if (obj.scheduleAppointment(apt))
                            Console.WriteLine("Appointment Scheduled");
                        else
                            Console.WriteLine("Try Again");

                    }
                    

                    continue;
                    
                }

                else if (uch == 5)
                {
                    Appointment apt = new Appointment();

                    Console.WriteLine("Enter all details to update the appointment");
                    Console.WriteLine("Enter Appointment ID given");
                    apt.AppointmendID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Patient ID given");
                    apt.PatientID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Doctor ID given");
                    apt.DoctorID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Date of appointment");
                    apt.AppointmentDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter description of Appointment");
                    apt.Description = Console.ReadLine();

                    if (obj.scheduleAppointment(apt))
                        Console.WriteLine("Appointment Succesfully Updated");
                    else
                        Console.WriteLine("Try Again");

                    continue;

                }

                else if (uch == 6)
                {
                    Console.WriteLine("Please enter Appointment ID");
                    int aptid = int.Parse(Console.ReadLine());
                    if (obj.cancelAppointment(aptid))
                        Console.WriteLine("Appointment Cancelled");
                    else
                        Console.WriteLine("Try Again");

                    

                    continue;

                }

                else if(uch == 7)
                {
                    

                    List<Doctor> docs = new List<Doctor>();
                    docs = obj.getDoctorDetails();

                    foreach (var d in docs)
                    {
                        Console.Write($"Doctor ID: {d.DoctorID}     ");
                        Console.Write($"First Name: {d.Fname}     ");
                        Console.Write($"Last Name: {d.Lname}     ");
                        Console.Write($"Specialization: {d.Specialization}     ");
                        Console.WriteLine($"Contact Number: {d.Contactnumber}");
                    }

                    continue;

                }

                else
                {
                    Console.WriteLine("Enter correct choice");
                    continue;
                }

            }
            
        }
    }
}
