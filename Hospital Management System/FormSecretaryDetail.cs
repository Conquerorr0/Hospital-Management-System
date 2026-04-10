using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Management_System
{
    public partial class FormSecretaryDetail : Form
    {
        DatabaseConnection db = null;
        private int _id;
        public FormSecretaryDetail(int id)
        {
            InitializeComponent();
            db = new DatabaseConnection();
            _id = id;
        }


        private void FormSecretaryDetail_Load(object sender, EventArgs e)
        {
            getInfo();
        }

        private void getInfo()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_secretary WHERE id = '" + _id + "'", db.connection());
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                lblName.Text = reader["name_surname"].ToString();
                lblTC.Text = reader["tc"].ToString();
            }

            reader.Close();
            db.connection().Close();
        }


    }
}
