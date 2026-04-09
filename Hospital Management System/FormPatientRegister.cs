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
    public partial class FormPatientRegister : Form
    {
        DatabaseConnection db = null;
        public FormPatientRegister()
        {
            InitializeComponent();
            db = new DatabaseConnection();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_patient (name, surname, tc, phone, password, gender) values (@p1, @p2, @p3, @p4, @p5, @p6)", db.connection());
            
            cmd.Parameters.AddWithValue("@p1", txtName.Text);
            cmd.Parameters.AddWithValue("@p2", txtSurname.Text);
            cmd.Parameters.AddWithValue("@p3", txtTC.Text);
            cmd.Parameters.AddWithValue("@p4", txtPhone.Text);
            cmd.Parameters.AddWithValue("@p5", txtPassword.Text);
            cmd.Parameters.AddWithValue("@p6", cmbGender.Text);

            cmd.ExecuteNonQuery();

            db.connection().Close();

            MessageBox.Show("Kaydınız gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormPatientSign patientSign = new FormPatientSign();
            patientSign.Show();
            this.Hide();
        }
    }
}
