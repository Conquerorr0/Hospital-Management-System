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
    public partial class FormDoctorPanel : Form
    {
        DatabaseConnection db = null;
        public FormDoctorPanel()
        {
            InitializeComponent();
            db = new DatabaseConnection();
        }

        private void FormDoctorPanel_Load(object sender, EventArgs e)
        {
            getTable();

            db.connection().Close();
        }

        private void getTable()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_doctor", db.connection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells["surname"].Value.ToString();
            cmbField.Text = dataGridView1.Rows[e.RowIndex].Cells["field"].Value.ToString();
            txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();
            txtTC.Text = dataGridView1.Rows[e.RowIndex].Cells["tc"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_doctor (name, surname, field, tc, password) values (@p1, @p2, @p3, @p4, @p5)", db.connection());

            cmd.Parameters.AddWithValue("@p1", txtName.Text);
            cmd.Parameters.AddWithValue("@p2", txtSurname.Text);
            cmd.Parameters.AddWithValue("@p3", cmbField.Text);
            cmd.Parameters.AddWithValue("@p4", txtTC.Text);
            cmd.Parameters.AddWithValue("@p5", txtPassword.Text);

            cmd.ExecuteNonQuery();

            db.connection().Close();

            getTable();

            MessageBox.Show("Başarılı bir şekilde eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tbl_doctor WHERE tc = '" + txtTC.Text + "'", db.connection());

            cmd.ExecuteNonQuery();

            db.connection().Close();

            getTable();

            MessageBox.Show("Başarılı bir şekilde silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           if(!string.IsNullOrEmpty(txtTC.Text))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tbl_doctor SET name = @p1, surname = @p2, field = @p3, tc = @p4, password = @p5 WHERE tc = '" + txtTC.Text + "'", db.connection());

                cmd.Parameters.AddWithValue("@p1", txtName.Text);
                cmd.Parameters.AddWithValue("@p2", txtSurname.Text);
                cmd.Parameters.AddWithValue("@p3", cmbField.Text);
                cmd.Parameters.AddWithValue("@p4", txtTC.Text);
                cmd.Parameters.AddWithValue("@p5", txtPassword.Text);

                cmd.ExecuteNonQuery();

                db.connection().Close();

                getTable();

                MessageBox.Show("Başarılı bir şekilde güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("T.C. No alanı boş olamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
