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
    public partial class FormRelatorio : Form {
        public FormRelatorio() {
            InitializeComponent();

            //textLog.Text = Utils.textLog;
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void chart1_Click(object sender, EventArgs e) {

        }
    }
}
