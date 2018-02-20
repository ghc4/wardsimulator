using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalWard {
    public partial class FormCalculo : Form {

        Dictionary<int, int> pacientesNivel = new Dictionary<int, int>();
        public FormWard parentForm;


        public FormCalculo() {
            InitializeComponent();
        }

        private void FormCalculo_Load(object sender, EventArgs e) {

        }

        public void setPacientesNivel(List<int> pacientesNivel) {
            pacientes.Text = pacientesNivel.Count().ToString();

            int pPcm = 0;
            int pPci = 0;
            int pPcsi = 0;
            int pPcit = 0;

            decimal dhorasPcm = 3.8m;
            decimal dhorasPci = 5.6m;
            decimal dhorasPcsi = 9.4m;
            decimal dhorasPcit = 17.9m;

            int horasTotalPcm = 0;
            int horasTotalPci = 0;
            int horasTotalPcsi = 0;
            int horasTotalPcit = 0;

            int prevalencia = 0;
            decimal prevalenciaFator = 0;

            decimal ithe = 0;
            decimal ids = 0;
            decimal ijst = 0;
            decimal iist = 0;
            decimal ikm = 0;
            decimal iqp = 0;
            decimal iqp6 = 0;
            decimal iqp24 = 0;
            decimal nsup = 0;
            decimal ntec = 0;


            foreach (var i in pacientesNivel) {
                if (i == 1) pPcm++;
                if (i == 2) pPci++;
                if (i == 3) pPcsi++;
                if (i == 4) pPcit++;
            }

            horasTotalPcm = ((int)(pPcm * dhorasPcm));
            horasTotalPci = ((int)(pPci * dhorasPci));
            horasTotalPcsi = ((int)(pPcsi * dhorasPcsi));
            horasTotalPcit = ((int)(pPcit * dhorasPcit));

            prevalencia = Math.Max(Math.Max(Math.Max(pPcm, pPci), pPcsi), pPcit);

            if (prevalencia == pPcm) { prevalenciaFator = 35; } else if (prevalencia == pPci) { prevalenciaFator = 35; } else if (prevalencia == pPcsi) { prevalenciaFator = 44; } else if (prevalencia == pPcit) { prevalenciaFator = 55; }

            ithe = horasTotalPcm + horasTotalPci + horasTotalPcsi + horasTotalPcit;

            iist = 1.15m;
            ids = 7;
            ijst = 36;

            ikm = (decimal)(ids / ijst * iist);
            iqp = Math.Ceiling(ithe * ikm);


            pacientesPcm.Text = pPcm.ToString();
            pacientesPci.Text = pPci.ToString();
            pacientesPcsi.Text = pPcsi.ToString();
            pacientesPcit.Text = pPcit.ToString();

            careHoursPcm.Text = dhorasPcm.ToString();
            careHoursPci.Text = dhorasPci.ToString();
            careHoursPcsi.Text = dhorasPcsi.ToString();
            careHoursPcit.Text = dhorasPcit.ToString();


            horasPcm.Text = horasTotalPcm.ToString();
            horasPci.Text = horasTotalPci.ToString();
            horasPcsi.Text = horasTotalPcsi.ToString();
            horasPcit.Text = horasTotalPcit.ToString();

            if (prevalencia == pPcm) { infoPcm.Text = "Prevalente"; } else if (prevalencia == pPci) { infoPci.Text = "Prevalente"; } else if (prevalencia == pPcsi) { infoPcsi.Text = "Prevalente"; } else if (prevalencia == pPcit) { infoPcit.Text = "Prevalente"; }


            ist.Text = iist.ToString();
            ds.Text = ids.ToString();
            jst.Text = ijst.ToString();
            the.Text = ithe.ToString();
            km.Text = ikm.ToString();
            qp.Text = iqp.ToString();

            iqp24 = iqp;
            qp24.Text = iqp24.ToString();
            proporcao24.Text = prevalenciaFator.ToString();
            nsup = Math.Round(iqp24 * (prevalenciaFator / 100));
            ntec = (iqp24 - nsup);
            nivelSuperior24.Text = nsup.ToString();
            nivelMedio24.Text = ntec.ToString();

            iqp6 = Math.Ceiling(iqp / 4);
            qp6.Text = iqp6.ToString();
            proporcao6.Text = prevalenciaFator.ToString();
            nsup = Math.Round(iqp6 * (prevalenciaFator / 100));
            ntec = Math.Ceiling(iqp6 - nsup);
            nivelSuperior6.Text = nsup.ToString();
            nivelMedio6.Text = ntec.ToString();

            parentForm.nEnfermeiros = (int)nsup;
            parentForm.nTecnicos = (int)ntec;

        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
