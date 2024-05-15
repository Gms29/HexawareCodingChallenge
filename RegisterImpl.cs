using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management.dao
{
    internal class RegisterImpl : IRegister
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public RegisterImpl()
        {
            sqlConnection = new SqlConnection("Server=MSI;Database=GoBako;Trusted_Connection=True");
            cmd = new SqlCommand();
        }

        public bool AddUser(string username, string password, string name, int age)
        {
            cmd.CommandText = "INSERT INTO Users VALUES (@un,@pw,@n,@a);";
            cmd.Connection = sqlConnection;
            cmd.Parameters.AddWithValue("@un", username);
            cmd.Parameters.AddWithValue("@pw", password);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@a", age);
            sqlConnection.Open();

            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            if (status > 0)
                return true;
            else
                return false;

        }
    }
}
