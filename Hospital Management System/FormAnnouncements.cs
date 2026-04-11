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
    public partial class FormAnnouncements : Form
    {
        DatabaseConnection db = null;
        public FormAnnouncements()
        {
            InitializeComponent();
            db = new DatabaseConnection();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tbl_announcement", db.connection());
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            db.connection().Close();
        }
    }
}
