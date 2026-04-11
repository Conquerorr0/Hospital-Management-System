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
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            getInfo();
            getFields();
            getDoctors();
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

        private void getFields()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_field", db.connection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbField.Items.Add(reader["name"]);
            }
            reader.Close();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            
            db.connection().Close();
        }

        private void getDoctors()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_doctor", db.connection());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;

            
            db.connection().Close();
        }
        private void fillCmbDoctor()
        {
            SqlCommand cmdDoctor = new SqlCommand("SELECT * FROM tbl_doctor WHERE field = @field", db.connection());
            cmdDoctor.Parameters.AddWithValue("@field", cmbField.Text);

            SqlDataReader reader = cmdDoctor.ExecuteReader();
            while (reader.Read())
            {
                cmbDoctor.Items.Add(reader["name"] + " " + reader["surname"]);
            }
            reader.Close();
        }

        private void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            try
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

                MessageBox.Show("Randevu başarılı bir şekilde oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoctor.Items.Clear();
            fillCmbDoctor();
        }

        private void btnCreateAnnouncment_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_announcement (announcement) values (@a1)", db.connection());
            cmd.Parameters.AddWithValue("@a1", txtAnnouncment.Text);
            cmd.ExecuteNonQuery();
            db.connection().Close();
            MessageBox.Show("Duyuru başarılı bir şekilde oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDoctorPanel_Click(object sender, EventArgs e)
        {
            FormDoctorPanel formDoctor = new FormDoctorPanel();
            formDoctor.Show();
        }

        private void btnFieldPanel_Click(object sender, EventArgs e)
        {
            FormField formField = new FormField();
            formField.Show();
        }

        private void btnOppointmentPanel_Click(object sender, EventArgs e)
        {
            FormAppointmentList list = new FormAppointmentList();
            list.Show();
        }
    }
}
