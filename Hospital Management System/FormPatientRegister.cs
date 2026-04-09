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
    public partial class FormPatientRegister : Form
    {
        public FormPatientRegister()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            FormPatientSign patientSign = new FormPatientSign();
            patientSign.Show();
            this.Hide();
        }
    }
}
