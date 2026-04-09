using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hospital_Management_System
{
    class DatabaseConnection
    {
        //Data Source=kerem\SQLEXPRESS;Initial Catalog=HospitalManagementSystem;Integrated Security=True;Trust Server Certificate=True
        public SqlConnection connection()
        {
            SqlConnection conn = new SqlConnection("Data Source=kerem\\SQLEXPRESS;Initial Catalog=HospitalManagementSystem;Integrated Security=True;Trust Server Certificate=True");
            conn.Open();
            return conn;
        }
    }
}
