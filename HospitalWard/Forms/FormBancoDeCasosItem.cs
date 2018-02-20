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
    public partial class FormBancoDeCasosItem : Form {

        public string paciente;
        public JObject data = new JObject();
        DataStore ds = new DataStore();

        public FormBancoDeCasosItem() {
            InitializeComponent();
            ds.read();
        }


        public void setPaciente(JObject o, string s) {
            data = o;
            paciente = s;
            pacienteCodigo.Text = s;

            nome.Text = ds.getPacienteData(paciente, "nome");
            descricao.Text = ds.getPacienteData(paciente, "descricao");

            schein01.Text = ds.getPacienteData(paciente, "schein01");
            schein02.Text = ds.getPacienteData(paciente, "schein02");
            schein03.Text = ds.getPacienteData(paciente, "schein03");
            schein04.Text = ds.getPacienteData(paciente, "schein04");
            schein05.Text = ds.getPacienteData(paciente, "schein05");
            schein06.Text = ds.getPacienteData(paciente, "schein06");
            schein07.Text = ds.getPacienteData(paciente, "schein07");
            schein08.Text = ds.getPacienteData(paciente, "schein08");
            schein09.Text = ds.getPacienteData(paciente, "schein09");
            schein10.Text = ds.getPacienteData(paciente, "schein10");

            morse01.Text = ds.getPacienteData(paciente, "morse01");
            morse02.Text = ds.getPacienteData(paciente, "morse02");
            morse03.Text = ds.getPacienteData(paciente, "morse03");
            morse04.Text = ds.getPacienteData(paciente, "morse04");
            morse05.Text = ds.getPacienteData(paciente, "morse05");
            morse06.Text = ds.getPacienteData(paciente, "morse06");

            refreshDgvEstados();

        }


        private void refreshDgvEstados() {
            dgvEstados.Rows.Clear();
            JObject x = (JObject)data["pacientes"][paciente]["estados"];
            IList<string> keys = ds.getKeys(x);
            if (keys != null) {
                foreach (string i in keys) {
                    dgvEstados.Rows.Add(i, ds.getPacienteEstado(paciente, i, "nome"));
                }
            }
            dgvEstados.Refresh();
        }

        private void button2_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Confirma remover paciente?\nEste procedimento não pode ser revertido.", "Confirmação", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                //...
            } else if (result == DialogResult.No) {
                //...
            } else {
                //...
            }
        }

        private void btnApagarEstado_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Confirma remover estado?\nEste procedimento não pode ser revertido.", "Confirmação", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                //...
            } else if (result == DialogResult.No) {
                //...
            } else {
                //...
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            ds.setPacienteData(paciente, "nome", nome.Text);
            ds.setPacienteData(paciente, "descricao", descricao.Text);
            ds.setPacienteData(paciente, "schein01", schein01.Text);
            ds.setPacienteData(paciente, "schein02", schein02.Text);
            ds.setPacienteData(paciente, "schein03", schein03.Text);
            ds.setPacienteData(paciente, "schein04", schein04.Text);
            ds.setPacienteData(paciente, "schein05", schein05.Text);
            ds.setPacienteData(paciente, "schein06", schein06.Text);
            ds.setPacienteData(paciente, "schein07", schein07.Text);
            ds.setPacienteData(paciente, "schein08", schein08.Text);
            ds.setPacienteData(paciente, "schein09", schein09.Text);
            ds.setPacienteData(paciente, "schein10", schein10.Text);
            ds.setPacienteData(paciente, "morse01", morse01.Text);
            ds.setPacienteData(paciente, "morse02", morse02.Text);
            ds.setPacienteData(paciente, "morse03", morse03.Text);
            ds.setPacienteData(paciente, "morse04", morse04.Text);
            ds.setPacienteData(paciente, "morse05", morse05.Text);
            ds.setPacienteData(paciente, "morse06", morse06.Text);
            ds.save();
            MessageBox.Show("Registro salvo.");
        }

        private void btnAdicionarEstado_Click(object sender, EventArgs e) {
            string name = "";
            string idx = "";
            bool exists = false;
            for (int i = 1; i < 500; i++) {
                idx = i.ToString("000");
                name = "Novo estado";
                exists = false;
                foreach (DataGridViewRow row in dgvEstados.Rows) {
                    if (row.Cells[0].Value.ToString().Equals(idx)) {
                        exists = true;
                        break;
                    }
                }
                if (!exists) {
                    break;
                }
            }


            if (data["pacientes"][paciente]["estados"] == null) {
                data["pacientes"][paciente]["estados"] = new JObject();
            }
            data["pacientes"][paciente]["estados"][idx] = new JObject();
            data["pacientes"][paciente]["estados"][idx]["nome"] = name;
            ds.save();
            dgvEstados.Rows.Add(idx, name);
        }

        private void dgvEstados_CellClick(object sender, DataGridViewCellEventArgs e) {
            string estado = dgvEstados.SelectedRows[0].Cells[0].Value.ToString();
            estadoCodigo.Text = estado;
            estadoNome.Text = dgvEstados.SelectedRows[0].Cells[1].Value.ToString();
            descricaoEstado.Text = ds.getPacienteEstado(paciente, estado, "enunciado");

            opcao01.Text = ds.getPacienteEstado(paciente, estado, "opcao01");
            opcao01Informacao.Text = ds.getPacienteEstado(paciente, estado, "opcao01Informacao");
            opcao01NovoEstado.Text = ds.getPacienteEstado(paciente, estado, "opcao01NovoEstado");
            opcao02.Text = ds.getPacienteEstado(paciente, estado, "opcao02");
            opcao02Informacao.Text = ds.getPacienteEstado(paciente, estado, "opcao02Informacao");
            opcao02NovoEstado.Text = ds.getPacienteEstado(paciente, estado, "opcao02NovoEstado");
            opcao03.Text = ds.getPacienteEstado(paciente, estado, "opcao03");
            opcao03Informacao.Text = ds.getPacienteEstado(paciente, estado, "opcao03Informacao");
            opcao03NovoEstado.Text = ds.getPacienteEstado(paciente, estado, "opcao03NovoEstado");
            opcao04.Text = ds.getPacienteEstado(paciente, estado, "opcao04");
            opcao04Informacao.Text = ds.getPacienteEstado(paciente, estado, "opcao04Informacao");
            opcao04NovoEstado.Text = ds.getPacienteEstado(paciente, estado, "opcao04NovoEstado");
        }

        private void btnGravarEstado_Click(object sender, EventArgs e) {
            string estado = estadoCodigo.Text;
            ds.setPacienteEstado(paciente, estado, "nome", estadoNome.Text);
            ds.setPacienteEstado(paciente, estado, "enunciado", descricaoEstado.Text);
            ds.setPacienteEstado(paciente, estado, "opcao01", opcao01.Text);
            ds.setPacienteEstado(paciente, estado, "opcao01Informacao", opcao01Informacao.Text);
            ds.setPacienteEstado(paciente, estado, "opcao01NovoEstado", opcao01NovoEstado.Text);
            ds.setPacienteEstado(paciente, estado, "opcao02", opcao02.Text);
            ds.setPacienteEstado(paciente, estado, "opcao02Informacao", opcao02Informacao.Text);
            ds.setPacienteEstado(paciente, estado, "opcao02NovoEstado", opcao02NovoEstado.Text);
            ds.setPacienteEstado(paciente, estado, "opcao03", opcao03.Text);
            ds.setPacienteEstado(paciente, estado, "opcao03Informacao", opcao03Informacao.Text);
            ds.setPacienteEstado(paciente, estado, "opcao03NovoEstado", opcao03NovoEstado.Text);
            ds.setPacienteEstado(paciente, estado, "opcao04", opcao04.Text);
            ds.setPacienteEstado(paciente, estado, "opcao04Informacao", opcao04Informacao.Text);
            ds.setPacienteEstado(paciente, estado, "opcao04NovoEstado", opcao04NovoEstado.Text);
            ds.save();
            refreshDgvEstados();
            MessageBox.Show("Registro salvo.");
        }

        private void opcao02_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
