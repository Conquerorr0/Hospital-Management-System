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
    public partial class FormPatientSign : Form
    {
        DatabaseConnection db = null;

        public FormPatientSign()
        {
            InitializeComponent();
            db = new DatabaseConnection();
        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPatientRegister formPatient = new FormPatientRegister();
            formPatient.Show();
            
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_patient WHERE tc = @p1 AND password = @p2", db.connection());

            cmd.Parameters.AddWithValue("@p1", txtTC.Text);
            cmd.Parameters.AddWithValue("@p2", txtPassword.Text);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                FormPatientDetail detail = new FormPatientDetail(Convert.ToInt16(reader["id"]));
                detail.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı T.C. & Şifre");
            }

            db.connection().Close();
        }
    }
}
