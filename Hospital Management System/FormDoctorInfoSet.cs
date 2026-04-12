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
    public partial class FormDoctorInfoSet : Form
    {
        DatabaseConnection db = null;
        private string id;
        public FormDoctorInfoSet(string id)
        {
            InitializeComponent();
            this.id = id;
            db = new DatabaseConnection();
            getFields();
            getInfo();
        }

        private void getInfo()
        {
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("ID boş geldi!");
                return;
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_doctor WHERE id = @id", db.connection());
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtName.Text = reader["name"].ToString();
                txtSurname.Text = reader["surname"].ToString();
                cmbField.Text = reader["field"].ToString();
                txtTC.Text = reader["tc"].ToString();
                txtPassword.Text = reader["password"].ToString();
            }
            reader.Close();
            db.connection().Close();
        }

        private void getFields()
        {
            SqlCommand cmd = new SqlCommand("SELECT name FROM tbl_field", db.connection());
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                cmbField.Items.Add(reader["name"].ToString());
            }

            reader.Close();
            db.connection().Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_doctor SET name=@name, surname=@surname, field=@field, tc=@tc, password=@password WHERE id=@id", db.connection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@field", cmbField.Text);
            cmd.Parameters.AddWithValue("@tc", txtTC.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Güncelleme başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.connection().Close();
        }
    }
}
