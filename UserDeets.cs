using Hospital_Management.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.HospitalManagementApp
{
    internal class UserDeets
    {

        public void Menu()
        {
            Console.WriteLine("Welcome to GoBako International Hospital: ");
            Console.WriteLine("Your health is our utmost priority");

             

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter 1. Login");
                Console.WriteLine("Please enter 2. Register");

                int ch = int.Parse(Console.ReadLine());

                if (ch == 1)
                {
                    Console.WriteLine("Enter Username");
                    string un = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string pw = Console.ReadLine();

                    LoginImpl obj = new LoginImpl();

                    while (true)
                    {
                        if (obj.Verify(un, pw))
                        {
                            Console.WriteLine("User Login Successful");
                            Menu m = new Menu();
                            m.Enter();
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Please try again with correct details");
                            continue;
                        }

                    }

                    Console.WriteLine("Thankyou for interacting with us. BYE");
                    break;

                }

                if (ch == 2)
                {
                    Console.WriteLine("Enter Username");
                    string un = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string pw = Console.ReadLine();
                    Console.WriteLine("Enter Name");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Age");
                    int a = int.Parse(Console.ReadLine());

                    RegisterImpl r = new RegisterImpl();
                    if (r.AddUser(un, pw, n, a))
                        Console.WriteLine("User Added");                          
                    

                    continue;
                }

            }
            
            


        }
            
    }
}
