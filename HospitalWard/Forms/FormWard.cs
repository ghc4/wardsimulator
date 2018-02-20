using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace HospitalWard {
    public partial class FormWard : Form {


        public DataStore ds = new DataStore();
        public Simulation simulation;
        Bitmap bmpWard = new Bitmap(Properties.Resources.ward);
        public bool initialized = false;

        Utils utils = new Utils();

        List<Point> pointsLeitos = new List<Point>
        {
            new Point(105, 1180),
            new Point(216, 1101),
            new Point(326, 1023),
            new Point(437, 944 ),
            new Point(548, 866 ),
            new Point(659, 787 ),
            new Point(769, 709 ),
            new Point(880, 630),

            new Point( 691, 1461),
            new Point( 801, 1383),
            new Point( 912, 1304),
            new Point(1023, 1226),
            new Point(1134, 1147),
            new Point(1244, 1069),

            new Point(1261, 1471),
            new Point(1371, 1393),
            new Point(1482, 1314),
            new Point(1593, 1236),

            new Point(1321, 321),
            new Point(1431, 243),
            new Point(1542, 164),
        };


        // METHODS

        public FormWard() {
            InitializeComponent();

            Utils.textBox = tbLogData;

            simulation = new Simulation(trkPacientes.Maximum,
                                        trkEnfermeiros.Maximum,
                                        trkTecnicos.Maximum);

            cb_trkPacientes_ValueChanged(null, null);
            cb_trkEnfermeiros_ValueChanged(null, null);
            cb_trkTecnicos_ValueChanged(null, null);

            redrawWard();

            ds.read();

            if (ds.data["pacientes"] == null)
                ds.data["pacientes"] = new JObject();

            initialized = true;

        }
        
        public void reset() {
            simulation.reset();
            tbLogData.Clear();
            timerPrincipal.Stop();
            tbTempo.Text = "00:00:00";
            pbTempo.Value = 0;
            trkPacientes.Enabled = true;
            trkEnfermeiros.Enabled = true;
            trkTecnicos.Enabled = true;
            chartAtendimentos.Series["Series1"].Points.Clear();
            chartAtendimentoPorHora.Series["Series1"].Points.Clear();
            chartTempoMedioPorAtendimento.Series["Series1"].Points.Clear();
            redrawWard();

        }

        private void putEnfermeiroFrente(Graphics g, int idx) {
            Point point = new Point(100 + (idx * 50), 420);
            g.DrawImage(new Bitmap(Properties.Resources.enfermeiraFrente), point);
            Font drawFont = new Font("Arial", 14, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            point.Y -= 30;
            g.DrawString(idx.ToString("00"), drawFont, drawBrush, point);
        }

        private void putTecnicoFrente(Graphics g, int idx) {
            Point point = new Point(100 + (idx * 50), 600);
            g.DrawImage(new Bitmap(Properties.Resources.tecnicaFrente), point);
            Font drawFont = new Font("Arial", 14, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            point.Y -= 30;
            g.DrawString(idx.ToString("00"), drawFont, drawBrush, point);
        }

        private void putEnfermeiro(Graphics g, int idx, int local) {
            Point point = pointsLeitos[local - 1];
            point.X += 160;
            point.Y += 30;
            g.DrawImage(new Bitmap(Properties.Resources.enfermeira), point);
            Font drawFont = new Font("Arial", 14, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            point.Y -= 30;
            g.DrawString(idx.ToString("00"), drawFont, drawBrush, point);
        }

        private void putTecnico(Graphics g, int idx, int local) {
            Point point = pointsLeitos[local - 1];
            point.X += 110;
            point.Y += 50;
            g.DrawImage(new Bitmap(Properties.Resources.tecnica), point);
            Font drawFont = new Font("Arial", 14, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            point.Y -= 30;
            g.DrawString(idx.ToString("00"), drawFont, drawBrush, point);
        }

        private void putMedico(Graphics g, int idx, int local) {
            Point point = pointsLeitos[local - 1];
            point.X += 40;
            point.Y += 30;
            g.DrawImage(new Bitmap(Properties.Resources.medicoOeste01), point);
            Font drawFont = new Font("Arial", 14, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            point.Y -= 30;
            g.DrawString(idx.ToString("00"), drawFont, drawBrush, point);
        }

        private void redrawWard() {

            if (!initialized) return;

            lblPacientes.Text = trkPacientes.Value.ToString();
            lblEnfermeiros.Text = trkEnfermeiros.Value.ToString();
            lblTecnicos.Text = trkTecnicos.Value.ToString();

            Bitmap bmp = (Bitmap)bmpWard.Clone();
            Graphics g = Graphics.FromImage(bmp);

            int cnt = 1;

            foreach (Point pointx in pointsLeitos) {
                var point = pointx;
                if (cnt <= trkPacientes.Value) {
                    Agent paciente = simulation.agents.getByType("paciente", cnt);
                    if (paciente.state == "idle") {
                        g.DrawImage(new Bitmap(Properties.Resources.camaDormindo), point);
                    } else {
                        g.DrawImage(new Bitmap(Properties.Resources.camaAcordado), point);
                    }
                    Font drawFont = new Font("Arial", 14, FontStyle.Bold);
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    point.Y -= 10;
                    point.X += 10;
                    g.DrawString(cnt.ToString("00"), drawFont, drawBrush, point);
                } else {
                    g.DrawImage(new Bitmap(Properties.Resources.camaVazia), point);
                }
                cnt += 1;
            }

            for (int i = 1; i <= trkEnfermeiros.Value; i++) {
                Agent enfermeiro = simulation.agents.getByType("enfermeiro", i);
                if (enfermeiro.local == 0) {
                    putEnfermeiroFrente(g, i);
                } else {
                    putEnfermeiro(g, i, enfermeiro.local);
                }
            }

            for (int i = 1; i <= trkTecnicos.Value; i++) {
                Agent tecnico = simulation.agents.getByType("tecnico", i);
                if (tecnico.local == 0) {
                    putTecnicoFrente(g, i);
                } else {
                    putTecnico(g, i, tecnico.local);
                }
            }

            g.Dispose();
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }
        
        public int nPacientes {
            get {
                return trkPacientes.Value;
            }
            set {
                if (value >= trkPacientes.Minimum && value <= trkPacientes.Maximum)
                    trkPacientes.Value = value;
            }
        }

        public int nEnfermeiros {
            get {
                return trkEnfermeiros.Value;
            }
            set {
                if (value >= trkEnfermeiros.Minimum && value <= trkEnfermeiros.Maximum)
                    trkEnfermeiros.Value = value;
            }
        }

        public int nTecnicos {
            get {
                return trkTecnicos.Value;
            }
            set {
                if (value >= trkTecnicos.Minimum && value <= trkTecnicos.Maximum)
                    trkTecnicos.Value = value;
            }
        }
        

        // CALLBACK EVENTS
        
        private void cb_btAdministrador_Click(object sender, EventArgs e) {
            FormBancoDeCasos f = new FormBancoDeCasos();
            f.setData(ds.data);
            f.ShowDialog();
        }

        private void cb_btCalcular_Click(object sender, EventArgs e) {
            FormCalculo f = new FormCalculo();
            f.parentForm = this;
            f.setPacientesNivel(simulation.agents.getPacientesNivel());
            f.ShowDialog();
        }

        private void cb_btHelpControles_Click(object sender, EventArgs e) {
            MessageBox.Show("Selecione a quantidade de pacientes para a simulação.\nQuando você altera a quantidade de pacientes, o simulador randomiza os pacientes e gera um novo cálculo de pessoal.");
        }

        private void cb_btIniciar_Click(object sender, EventArgs e) {
            timerPrincipal.Interval = simulation.timerRapido();
            simulation.reset();
            simulation.start();
            timerPrincipal.Start();
            trkPacientes.Enabled = false;
            trkEnfermeiros.Enabled = false;
            trkTecnicos.Enabled = false;
        }

        private void cb_btZerar_Click(object sender, EventArgs e) {
            reset();
        }

        private void cb_formAtendimento_FormClosing(object sender, EventArgs e) {
            timerPrincipal.Interval = simulation.timerRapido();
        }

        private void cb_formClassificacao_FormClosing(object sender, EventArgs e) {
            timerPrincipal.Interval = simulation.timerRapido();
        }

        private void cb_pictureBox1_ClientSizeChanged(object sender, EventArgs e) {
            redrawWard();
        }

        private void cb_pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            float wi = (float)pictureBox1.Image.Width;
            float hi = (float)pictureBox1.Image.Height;
            float wc = (float)pictureBox1.Width;
            float hc = (float)pictureBox1.Height;

            tbMouseX.Text = ((int)(e.X * (wi / wc))).ToString();
            tbMouseY.Text = ((int)(e.Y * (hi / hc))).ToString();
        }

        private void cb_pictureBox1_Resize(object sender, EventArgs e) {

        }

        private void cb_pictureBox1_SizeChanged(object sender, EventArgs e) {

        }

        private void cb_timerPrincipal_Tick(object sender, EventArgs e) {
            if (simulation.running && !simulation.pause) {
                simulation.mainLoop();

                if (simulation.redraw) {
                    redrawWard();
                    chartAtendimentos.Series["Series1"].Points.AddY(simulation.pacientesAguardandoAtendimento());
                    chartAtendimentoPorHora.Series["Series1"].Points.AddY(simulation.atentimentosPorHora());
                    chartTempoMedioPorAtendimento.Series["Series1"].Points.AddY(simulation.tempoMedioPorAtendimento());
                }


                tbTempo.Text = simulation.getTempoBr();
                pbTempo.Value = simulation.getTempoPercentual();

                switch (simulation.getAction()) {
                    case "atendimento":
                        timerPrincipal.Interval = simulation.timerNatural();
                        FormAtendimento fa = new FormAtendimento();
                        fa.setData(ds.data);
                        fa.FormClosing += cb_formAtendimento_FormClosing;
                        fa.ShowDialog();
                        break;

                    case "classificacao":
                        timerPrincipal.Interval = simulation.timerNatural();
                        FormClassificacao fc = new FormClassificacao();
                        fc.setData(ds.data);
                        fc.FormClosing += cb_formClassificacao_FormClosing;
                        fc.ShowDialog();
                        break;

                    case "final":
                        simulation.stop();
                        timerPrincipal.Stop();
                        trkPacientes.Enabled = true;
                        trkEnfermeiros.Enabled = true;
                        trkTecnicos.Enabled = true;
                        redrawWard();
                        FormRelatorio f = new FormRelatorio();
                        f.ShowDialog();
                        break;
                }
            }
        }

        private void cb_trkPacientes_ValueChanged(object sender, EventArgs e) {
            lblPacientes.Text = trkPacientes.Value.ToString();
            for (int i = 1; i <= trkPacientes.Maximum; i += 1) {
                if (i <= trkPacientes.Value) {
                    simulation.agents.enable("paciente", i);
                } else {
                    simulation.agents.disable("paciente", i);
                }
            }

            simulation.agents.pacientesShuffleLevel();
            redrawWard();
        }

        private void cb_trkEnfermeiros_ValueChanged(object sender, EventArgs e) {
            lblEnfermeiros.Text = trkEnfermeiros.Value.ToString();
            for (int i = 1; i <= trkEnfermeiros.Maximum; i += 1) {
                if (i <= trkEnfermeiros.Value) {
                    simulation.agents.enable("enfermeiro", i);
                } else {
                    simulation.agents.disable("enfermeiro", i);
                }
            }
            redrawWard();
        }
        
        private void cb_trkTecnicos_ValueChanged(object sender, EventArgs e) {
            lblTecnicos.Text = trkTecnicos.Value.ToString();
            for (int i = 1; i <= trkTecnicos.Maximum; i += 1) {
                if (i <= trkTecnicos.Value) {
                    simulation.agents.enable("tecnico", i);
                } else {
                    simulation.agents.disable("tecnico", i);
                }
            }
            redrawWard();
        }

        private void btnParar_Click(object sender, EventArgs e) {
            simulation.togglePause();
        }
    }
}
