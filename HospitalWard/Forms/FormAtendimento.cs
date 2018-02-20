using Newtonsoft.Json.Linq;
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
    public partial class FormAtendimento : Form {
        public JObject data = new JObject();
        public DataStore ds = new DataStore();

        public FormAtendimento() {
            InitializeComponent();
        }


        public void setData(JObject d) {
            data = d;

            JObject jpaciente = (JObject)data["pacientes"]["001"];

            descricao.Text = jpaciente["descricao"].ToString();
            enunciado.Text = jpaciente["estados"]["001"]["enunciado"].ToString();
            atendimentoOpcao01.Text = jpaciente["estados"]["001"]["opcao01"].ToString();
            atendimentoOpcao02.Text = jpaciente["estados"]["001"]["opcao02"].ToString();
            atendimentoOpcao03.Text = jpaciente["estados"]["001"]["opcao03"].ToString();
            atendimentoOpcao04.Text = jpaciente["estados"]["001"]["opcao04"].ToString();

        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
