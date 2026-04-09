using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class FormRoleScreen : Form
    {
        public FormRoleScreen()
        {
            InitializeComponent();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            FormPatientSign formPatient = new FormPatientSign();
            formPatient.Show();
            this.Hide();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            FormDoctorSingIn formDoctor = new FormDoctorSingIn();
            formDoctor.Show();
            this.Hide();
        }

        private void btnSecretary_Click(object sender, EventArgs e)
        {
            FormSecretarySignIn formSecretary = new FormSecretarySignIn();
            formSecretary.Show();
            this.Hide();
        }
    }
}
