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
    public partial class FormField : Form
    {
        DatabaseConnection db = null;
        public FormField()
        {
            InitializeComponent();
            db = new DatabaseConnection();
            getTable();
            getFields();
        }

        private void getTable()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_field", db.connection());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dt);
            dataGridView1.DataSource = dt;


            db.connection().Close();
        }

        private void getFields()
        {
            SqlCommand cmd = new SqlCommand("SELECT name FROM tbl_field", db.connection());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cmbField.Items.Add(reader["name"]);
            }

            reader.Close();
            db.connection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cmbField.Text))
            {
                
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_field (name) VALUES (@field)", db.connection());
                cmd.Parameters.AddWithValue("@field", cmbField.Text);
                cmd.ExecuteNonQuery();

                db.connection().Close();
                MessageBox.Show("Başarılı bir şekilde eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Branş eklemek için branş ismi girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbField.Text))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_field WHERE name = '" + cmbField.Text + "'", db.connection());
                cmd.ExecuteNonQuery();

                db.connection().Close();

                MessageBox.Show("Başarılı bir şekilde silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Silme işlemi için mutlaka bir branş seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            getTable();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbField.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string oldValue = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (!string.IsNullOrEmpty(cmbField.Text))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tbl_field SET name = @newName WHERE name = @oldName", db.connection());

                cmd.Parameters.AddWithValue("@newName", cmbField.Text);
                cmd.Parameters.AddWithValue("@oldName", oldValue);

                cmd.ExecuteNonQuery();

                db.connection().Close();

                MessageBox.Show("Başarılı bir şekilde güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi için mutlaka bir branş seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            getTable();
        }
    }
}
