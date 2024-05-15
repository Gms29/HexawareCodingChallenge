using Hospital_Management.entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.dao
{

    internal class LoginImpl : ILogin
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public LoginImpl()
        {
            sqlConnection = new SqlConnection("Server=MSI;Database=GoBako;Trusted_Connection=True");
            cmd = new SqlCommand();
        }

        public bool Verify(string uname, string pass)
        {
            try
            {
                cmd.CommandText = "Select * from Users WHERE uname = @un AND pass = @pw;";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@un", uname);
                cmd.Parameters.AddWithValue("@pw", pass);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }

                else
                {
                    throw new exception.UserNotFound("User not found, Please enter correct details or Register");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " Error handled");
            }

            finally
            {
                sqlConnection.Close();
         
            }


            return false;
        }
    }
}
