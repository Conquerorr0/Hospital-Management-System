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
    public partial class FormDoctorSingIn : Form
    {
        DatabaseConnection db = null;
        public FormDoctorSingIn()
        {
            InitializeComponent();
            db = new DatabaseConnection();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_doctor WHERE tc = @tc AND password = @password", db.connection());
            cmd.Parameters.AddWithValue("@tc", txtTC.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                FormDoctorDetail formDoctor = new FormDoctorDetail(reader["id"].ToString());
                formDoctor.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Hatalı T.C. No veya Şifre", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.connection().Close();
        }
    }
}
