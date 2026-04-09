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
    public partial class FormPatientInfoSet : Form
    {
        DatabaseConnection db = null;
        private string patient_tc;
        public FormPatientInfoSet()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_patient SET name = @p1, surname = @p2, tc = @p3, phone = @p4, password = @p5, gender = @p6", db.connection());
            
            if(IsFormValid())
            {
                cmd.Parameters.AddWithValue("@p1", txtName.Text);
                cmd.Parameters.AddWithValue("@p2", txtSurname.Text);
                cmd.Parameters.AddWithValue("@p3", txtTC.Text);
                cmd.Parameters.AddWithValue("@p4", txtPhone.Text);
                cmd.Parameters.AddWithValue("@p5", txtPassword.Text);
                cmd.Parameters.AddWithValue("@p6", cmbGender.Text);
                MessageBox.Show("Güncelleme başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!");
            }

            cmd.ExecuteNonQuery();

            db.connection().Close();
        }

        private void fillAreas()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_patient WHERE tc = '" + patient_tc + "'", db.connection());
            SqlDataReader reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {
                txtName.Text = reader["name"].ToString();
                txtSurname.Text = reader["surname"].ToString();
                txtTC.Text = reader["tc"].ToString();
                txtPhone.Text = reader["phone"].ToString();
                txtPassword.Text = reader["password"].ToString();
                cmbGender.Text = reader["gender"].ToString();
            }
            reader.Close();
            db.connection().Close();
        }

        private bool IsFormValid()
        {
            return !string.IsNullOrWhiteSpace(txtName.Text) &&
                   !string.IsNullOrWhiteSpace(txtSurname.Text) &&
                   !string.IsNullOrWhiteSpace(txtTC.Text) &&
                   !string.IsNullOrWhiteSpace(txtPhone.Text) &&
                   !string.IsNullOrWhiteSpace(txtPassword.Text) &&
                   !string.IsNullOrWhiteSpace(cmbGender.Text);
        }

        public string TC { set { patient_tc = value; } }

        private void FormPatientInfoSet_Load(object sender, EventArgs e)
        {
            db = new DatabaseConnection();
            fillAreas();
        }
    }
}
