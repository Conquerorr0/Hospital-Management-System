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
    public partial class FormDoctorDetail : Form
    {
        DatabaseConnection db = null;
        private string id;
        public FormDoctorDetail(string id)
        {
            InitializeComponent();
            db = new DatabaseConnection();
            this.id = id;
            getInfo();
            getAppointments();
        }

        private void getInfo()
        {

            SqlCommand cmd = new SqlCommand("SELECT name, surname, tc FROM tbl_doctor WHERE id = '" + id + "'", db.connection());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lblName.Text = reader["name"] + " " + reader["surname"];
                lblTC.Text = reader["tc"].ToString();
            }

            reader.Close();
            db.connection().Close();
        }

        private void getAppointments()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tbl_appointments", db.connection());
            adapter.Fill(dataTable);
            dataAppointmentsList.DataSource = dataTable;
        }

        private void dataAppointmentsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataAppointmentsList.Rows[e.RowIndex];

                string text = "Tarih: " + row.Cells["date"].Value.ToString() +
                            "\nSaat: " + row.Cells["time"].Value.ToString() +
                            "\nBranş: " + row.Cells["field"].Value.ToString() +
                            "\nDoktor: " + row.Cells["doctor"].Value.ToString() +
                            "\nHasta TC: " + row.Cells["patient_tc"].Value.ToString() +
                            "\nŞikayet: " + row.Cells["patient_complaint"].Value.ToString();
                txtDetail.Text = text; 
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FormRoleScreen roleScreen = new FormRoleScreen();
            roleScreen.Show();
            this.Hide();
        }

        private void btnAnnouncment_Click(object sender, EventArgs e)
        {
            FormAnnouncements formAnnouncements = new FormAnnouncements();
            formAnnouncements.Show();
        }

        private void btnSetInfo_Click(object sender, EventArgs e)
        {
            FormDoctorInfoSet form = new FormDoctorInfoSet(id);
            form.Show();
        }
    }
}
