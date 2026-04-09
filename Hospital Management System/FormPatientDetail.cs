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
using System.Net.Http.Headers;

namespace Hospital_Management_System
{
    public partial class FormPatientDetail : Form
    {

        private int _patientId;
        DatabaseConnection db = null;
        public FormPatientDetail(int patientId)
        {
            InitializeComponent();
            db = new DatabaseConnection();
            _patientId = patientId;
        }

        private void FormPatientDetail_Load(object sender, EventArgs e)
        {
            try
            {
                getInfo();
                if (!string.IsNullOrEmpty(lblTC.Text))
                {
                    getPastAppointments();
                    getActiveAppointments();
                }
                getFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message + "\n" + ex.StackTrace);
            }

        }

        private void getInfo()
        {
            SqlCommand cmd = new SqlCommand("SELECT name, surname, tc FROM tbl_patient WHERE id = @p1", db.connection());

            cmd.Parameters.AddWithValue("@p1", _patientId);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                lblName.Text = reader["name"].ToString() + " " + reader["surname"];
                lblTC.Text = reader["tc"].ToString();
            }
            reader.Close();
            db.connection().Close();
        }

        private void getPastAppointments()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM tbl_appointments WHERE patient_tc = @tc AND status = 0",
                db.connection());

            cmd.Parameters.AddWithValue("@tc", lblTC.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            dataAppointmentHistory.DataSource = dt;

            db.connection().Close();
        }

        private void getActiveAppointments()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM tbl_appointments WHERE patient_tc = @tc AND status = 1",
                db.connection());

            cmd.Parameters.AddWithValue("@tc", lblTC.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            dataActiveAppointments.DataSource = dt;

            db.connection().Close();
        }

        private void getFields()
        {
            SqlCommand cmd = new SqlCommand("SELECT name FROM tbl_field", db.connection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbField.Items.Add(reader["name"].ToString());
            }
            reader.Close();
            db.connection().Close();
        }

        private void getDoctors()
        {
            cmbDoctor.Items.Clear();
            SqlCommand cmd = new SqlCommand("SELECT name, surname FROM tbl_doctor WHERE field = @p1", db.connection());
            cmd.Parameters.AddWithValue("@p1", cmbField.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbDoctor.Items.Add(reader["name"] + " " + reader["surname"]);
            }
            reader.Close();
            db.connection().Close();
        }


        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDoctors();
        }

        private void lblInfoSetUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPatientInfoSet formPatientInfo = new FormPatientInfoSet();
            formPatientInfo.TC = lblTC.Text;
            formPatientInfo.Show();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_appointments (date, time, field, doctor, status, patient_tc) VALUES (@date, @time, @field, @doctor, @status, @patient_tc)", db.connection());

            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd.MM.yyyy"));
            cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("HH:mm"));
            cmd.Parameters.AddWithValue("@field", cmbField.Text);
            cmd.Parameters.AddWithValue("@doctor", cmbDoctor.Text);
            cmd.Parameters.AddWithValue("@status", true);
            cmd.Parameters.AddWithValue("@patient_tc", lblTC.Text);

            cmd.ExecuteNonQuery();

            db.connection().Close();

            getActiveAppointments();
        }
    }
}
