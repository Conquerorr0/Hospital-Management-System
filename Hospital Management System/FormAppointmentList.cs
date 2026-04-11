using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class FormAppointmentList : Form
    {
        DatabaseConnection db = null;
        public FormAppointmentList()
        {
            InitializeComponent();
            db = new DatabaseConnection();
            DataTable dataTable = new DataTable();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_appointments", db.connection());
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tbl_appointments", db.connection());
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            db.connection().Close();
        }
    }
}
