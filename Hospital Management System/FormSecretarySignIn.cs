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
    public partial class FormSecretarySignIn : Form
    {
        DatabaseConnection db = null;
        public FormSecretarySignIn()
        {
            InitializeComponent();
            db = new DatabaseConnection();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_secretary WHERE tc = @s1 AND password = @s2", db.connection());

            cmd.Parameters.AddWithValue("@s1", txtTC.Text);
            cmd.Parameters.AddWithValue("@s2", txtPassword.Text);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                FormSecretaryDetail detail = new FormSecretaryDetail(Convert.ToInt32(reader["id"]));
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
