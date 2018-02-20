using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalWard {
    public partial class FormClassificacao : Form {
        public JObject data = new JObject();
        public DataStore ds = new DataStore();

        public FormClassificacao() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        public void setData(JObject d) {
            data = d;
            JObject jpaciente = (JObject)data["pacientes"]["001"];
            descricao.Text = jpaciente["descricao"].ToString();
        }
    }
}
