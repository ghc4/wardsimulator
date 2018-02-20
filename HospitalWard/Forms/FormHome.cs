using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalWard {
    public partial class FormHome : Form {
        public FormHome() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void btnAcesso_Click(object sender, EventArgs e) {
            FormWard f = new FormWard();
            this.Hide();
            f.Closed += (s, args) => this.Show();
            f.Show();
        }

        private void labelUsuario_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            FormAboutBox f = new FormAboutBox();
            f.ShowDialog();
        }
    }
}
