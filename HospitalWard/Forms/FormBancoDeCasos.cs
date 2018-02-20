using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace HospitalWard {
    public partial class FormBancoDeCasos : Form {
        public JObject data = new JObject();
        public DataStore ds = new DataStore();

        public FormBancoDeCasos() {
            InitializeComponent();
            ds.read();
        }

        public void setData(JObject d) {
            data = d;
            JObject o = (JObject)data["pacientes"];
            IList<string> keys = ds.getKeys(o);
            foreach (string i in keys) {
                dgvPacientes.Rows.Add(i, data["pacientes"][i]["nome"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            FormBancoDeCasosItem f = new FormBancoDeCasosItem();
            f.ShowDialog();
        }



        private void button2_Click(object sender, EventArgs e) {
            //string nomePaciente = Prompt.ShowDialog("Adicionar paciente", "Nome do Paciente:");
            //ListViewItem lvi = new ListViewItem();
            string name = "";
            string idx = "";
            bool exists = false;
            for (int i = 1; i < 500; i++) {
                idx = i.ToString("000");
                name = "Novo Paciente";
                exists = false;
                foreach (DataGridViewRow row in dgvPacientes.Rows) {
                    if (row.Cells[0].Value.ToString().Equals(idx)) {
                        exists = true;
                        break;
                    }
                }
                if (!exists) {
                    break;
                }
            }

            data["pacientes"][idx] = new JObject();
            data["pacientes"][idx]["nome"] = name;

            dgvPacientes.Rows.Add(idx, name);

        }

        private void button1_Click_1(object sender, EventArgs e) {
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            data.Add("apple", "1");
            data.Add("windows", "5");

            Dictionary<string, dynamic> datax = new Dictionary<string, dynamic>();
            datax.Add("apple", "1");
            datax.Add("windows", "5");

            data.Add("teste", datax);

            var json = new JavaScriptSerializer().Serialize(data);
            Console.WriteLine(json);

            string ss = @"{""user"": {""id"": 12345, ""screen_name"": ""twitpicuser""}}";
            var serializer = new JavaScriptSerializer();
            dynamic result = serializer.DeserializeObject(ss);
            Console.WriteLine(result["user"]["id"]);
            Console.WriteLine(result);


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void FormBancoDeCasos_Load(object sender, EventArgs e) {

        }


        private void dgvPacientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            string item = dgvPacientes.SelectedRows[0].Cells[0].Value.ToString();

            FormBancoDeCasosItem f = new FormBancoDeCasosItem();
            f.setPaciente(data, item);
            f.ShowDialog();
            this.Close();
        }
    }


    public static class Prompt {
        public static string ShowDialog(string caption, string text) {
            Form prompt = new Form() {
                Width = 550,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Width = 350, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 80, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Height = 40, Top = 150, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }




}
