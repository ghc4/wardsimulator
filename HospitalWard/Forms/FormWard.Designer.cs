namespace HospitalWard
{
    partial class FormWard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWard));
            this.label1 = new System.Windows.Forms.Label();
            this.pbTempo = new System.Windows.Forms.ProgressBar();
            this.tbTempo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnParar = new System.Windows.Forms.Button();
            this.btZerar = new System.Windows.Forms.Button();
            this.btIniciar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trkFatorComplexidade = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.trkFatorTempo = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.btHelpControles = new System.Windows.Forms.Button();
            this.lblTecnicos = new System.Windows.Forms.Label();
            this.btCalcular = new System.Windows.Forms.Button();
            this.lblEnfermeiros = new System.Windows.Forms.Label();
            this.lblPacientes = new System.Windows.Forms.Label();
            this.trkTecnicos = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.trkEnfermeiros = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.trkPacientes = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.timerPrincipal = new System.Windows.Forms.Timer(this.components);
            this.tbMouseX = new System.Windows.Forms.TextBox();
            this.tbMouseY = new System.Windows.Forms.TextBox();
            this.btAdministrador = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chartAtendimentos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chartAtendimentoPorHora = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbLogData = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chartTempoMedioPorAtendimento = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkFatorComplexidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkFatorTempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkTecnicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkEnfermeiros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAtendimentos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAtendimentoPorHora)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTempoMedioPorAtendimento)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 58);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hospital Ward\r\nSimulator";
            // 
            // pbTempo
            // 
            this.pbTempo.Location = new System.Drawing.Point(168, 34);
            this.pbTempo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbTempo.Name = "pbTempo";
            this.pbTempo.Size = new System.Drawing.Size(230, 35);
            this.pbTempo.Step = 1;
            this.pbTempo.TabIndex = 3;
            // 
            // tbTempo
            // 
            this.tbTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTempo.Location = new System.Drawing.Point(9, 29);
            this.tbTempo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTempo.Name = "tbTempo";
            this.tbTempo.ReadOnly = true;
            this.tbTempo.Size = new System.Drawing.Size(148, 35);
            this.tbTempo.TabIndex = 4;
            this.tbTempo.Text = "00:00:00";
            this.tbTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnParar);
            this.groupBox1.Controls.Add(this.btZerar);
            this.groupBox1.Controls.Add(this.btIniciar);
            this.groupBox1.Controls.Add(this.tbTempo);
            this.groupBox1.Controls.Add(this.pbTempo);
            this.groupBox1.Location = new System.Drawing.Point(18, 172);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(406, 131);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tempo";
            // 
            // btnParar
            // 
            this.btnParar.Location = new System.Drawing.Point(218, 78);
            this.btnParar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(180, 35);
            this.btnParar.TabIndex = 7;
            this.btnParar.Text = "Stop/Continue";
            this.btnParar.UseVisualStyleBackColor = true;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // btZerar
            // 
            this.btZerar.Location = new System.Drawing.Point(112, 78);
            this.btZerar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btZerar.Name = "btZerar";
            this.btZerar.Size = new System.Drawing.Size(93, 35);
            this.btZerar.TabIndex = 6;
            this.btZerar.Text = "Reset";
            this.btZerar.UseVisualStyleBackColor = true;
            this.btZerar.Click += new System.EventHandler(this.cb_btZerar_Click);
            // 
            // btIniciar
            // 
            this.btIniciar.Location = new System.Drawing.Point(10, 78);
            this.btIniciar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btIniciar.Name = "btIniciar";
            this.btIniciar.Size = new System.Drawing.Size(93, 35);
            this.btIniciar.TabIndex = 5;
            this.btIniciar.Text = "Start";
            this.btIniciar.UseVisualStyleBackColor = true;
            this.btIniciar.Click += new System.EventHandler(this.cb_btIniciar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.trkFatorComplexidade);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.trkFatorTempo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btHelpControles);
            this.groupBox2.Controls.Add(this.lblTecnicos);
            this.groupBox2.Controls.Add(this.btCalcular);
            this.groupBox2.Controls.Add(this.lblEnfermeiros);
            this.groupBox2.Controls.Add(this.lblPacientes);
            this.groupBox2.Controls.Add(this.trkTecnicos);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.trkEnfermeiros);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.trkPacientes);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(18, 314);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(406, 585);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // trkFatorComplexidade
            // 
            this.trkFatorComplexidade.Location = new System.Drawing.Point(9, 506);
            this.trkFatorComplexidade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trkFatorComplexidade.Maximum = 5;
            this.trkFatorComplexidade.Minimum = -5;
            this.trkFatorComplexidade.Name = "trkFatorComplexidade";
            this.trkFatorComplexidade.Size = new System.Drawing.Size(388, 69);
            this.trkFatorComplexidade.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 482);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Complexity factor adjust";
            // 
            // trkFatorTempo
            // 
            this.trkFatorTempo.Location = new System.Drawing.Point(9, 394);
            this.trkFatorTempo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trkFatorTempo.Maximum = 5;
            this.trkFatorTempo.Minimum = -5;
            this.trkFatorTempo.Name = "trkFatorTempo";
            this.trkFatorTempo.Size = new System.Drawing.Size(388, 69);
            this.trkFatorTempo.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 369);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Time factor adjust";
            // 
            // btHelpControles
            // 
            this.btHelpControles.Location = new System.Drawing.Point(14, 74);
            this.btHelpControles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btHelpControles.Name = "btHelpControles";
            this.btHelpControles.Size = new System.Drawing.Size(38, 35);
            this.btHelpControles.TabIndex = 12;
            this.btHelpControles.Text = "?";
            this.btHelpControles.UseVisualStyleBackColor = true;
            this.btHelpControles.Click += new System.EventHandler(this.cb_btHelpControles_Click);
            // 
            // lblTecnicos
            // 
            this.lblTecnicos.AutoSize = true;
            this.lblTecnicos.Location = new System.Drawing.Point(9, 235);
            this.lblTecnicos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTecnicos.Name = "lblTecnicos";
            this.lblTecnicos.Size = new System.Drawing.Size(18, 20);
            this.lblTecnicos.TabIndex = 8;
            this.lblTecnicos.Text = "0";
            // 
            // btCalcular
            // 
            this.btCalcular.Location = new System.Drawing.Point(285, 92);
            this.btCalcular.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCalcular.Name = "btCalcular";
            this.btCalcular.Size = new System.Drawing.Size(112, 35);
            this.btCalcular.TabIndex = 11;
            this.btCalcular.Text = "Calculate";
            this.btCalcular.UseVisualStyleBackColor = true;
            this.btCalcular.Click += new System.EventHandler(this.cb_btCalcular_Click);
            // 
            // lblEnfermeiros
            // 
            this.lblEnfermeiros.AutoSize = true;
            this.lblEnfermeiros.Location = new System.Drawing.Point(9, 157);
            this.lblEnfermeiros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnfermeiros.Name = "lblEnfermeiros";
            this.lblEnfermeiros.Size = new System.Drawing.Size(18, 20);
            this.lblEnfermeiros.TabIndex = 7;
            this.lblEnfermeiros.Text = "0";
            // 
            // lblPacientes
            // 
            this.lblPacientes.AutoSize = true;
            this.lblPacientes.Location = new System.Drawing.Point(9, 49);
            this.lblPacientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPacientes.Name = "lblPacientes";
            this.lblPacientes.Size = new System.Drawing.Size(18, 20);
            this.lblPacientes.TabIndex = 6;
            this.lblPacientes.Text = "0";
            // 
            // trkTecnicos
            // 
            this.trkTecnicos.Location = new System.Drawing.Point(99, 215);
            this.trkTecnicos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trkTecnicos.Minimum = 1;
            this.trkTecnicos.Name = "trkTecnicos";
            this.trkTecnicos.Size = new System.Drawing.Size(298, 69);
            this.trkTecnicos.TabIndex = 5;
            this.trkTecnicos.Value = 1;
            this.trkTecnicos.ValueChanged += new System.EventHandler(this.cb_trkTecnicos_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 215);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Technicians";
            // 
            // trkEnfermeiros
            // 
            this.trkEnfermeiros.Location = new System.Drawing.Point(99, 137);
            this.trkEnfermeiros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trkEnfermeiros.Minimum = 1;
            this.trkEnfermeiros.Name = "trkEnfermeiros";
            this.trkEnfermeiros.Size = new System.Drawing.Size(298, 69);
            this.trkEnfermeiros.TabIndex = 3;
            this.trkEnfermeiros.Value = 1;
            this.trkEnfermeiros.ValueChanged += new System.EventHandler(this.cb_trkEnfermeiros_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nurses";
            // 
            // trkPacientes
            // 
            this.trkPacientes.Location = new System.Drawing.Point(99, 29);
            this.trkPacientes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trkPacientes.Maximum = 21;
            this.trkPacientes.Minimum = 3;
            this.trkPacientes.Name = "trkPacientes";
            this.trkPacientes.Size = new System.Drawing.Size(298, 69);
            this.trkPacientes.TabIndex = 1;
            this.trkPacientes.Value = 3;
            this.trkPacientes.ValueChanged += new System.EventHandler(this.cb_trkPacientes_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Patients";
            // 
            // timerPrincipal
            // 
            this.timerPrincipal.Tick += new System.EventHandler(this.cb_timerPrincipal_Tick);
            // 
            // tbMouseX
            // 
            this.tbMouseX.Location = new System.Drawing.Point(1618, 634);
            this.tbMouseX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMouseX.Name = "tbMouseX";
            this.tbMouseX.Size = new System.Drawing.Size(82, 26);
            this.tbMouseX.TabIndex = 8;
            this.tbMouseX.Visible = false;
            // 
            // tbMouseY
            // 
            this.tbMouseY.Location = new System.Drawing.Point(1526, 634);
            this.tbMouseY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMouseY.Name = "tbMouseY";
            this.tbMouseY.Size = new System.Drawing.Size(82, 26);
            this.tbMouseY.TabIndex = 9;
            this.tbMouseY.Visible = false;
            // 
            // btAdministrador
            // 
            this.btAdministrador.Location = new System.Drawing.Point(272, 128);
            this.btAdministrador.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAdministrador.Name = "btAdministrador";
            this.btAdministrador.Size = new System.Drawing.Size(153, 35);
            this.btAdministrador.TabIndex = 12;
            this.btAdministrador.Text = "Administrator";
            this.btAdministrador.UseVisualStyleBackColor = true;
            this.btAdministrador.Click += new System.EventHandler(this.cb_btAdministrador_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HospitalWard.Properties.Resources.logo_branco;
            this.pictureBox2.Location = new System.Drawing.Point(18, 18);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(122, 145);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::HospitalWard.Properties.Resources.ward;
            this.pictureBox1.Location = new System.Drawing.Point(892, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(846, 664);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.ClientSizeChanged += new System.EventHandler(this.cb_pictureBox1_ClientSizeChanged);
            this.pictureBox1.SizeChanged += new System.EventHandler(this.cb_pictureBox1_SizeChanged);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cb_pictureBox1_MouseMove);
            this.pictureBox1.Resize += new System.EventHandler(this.cb_pictureBox1_Resize);
            // 
            // chartAtendimentos
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "ChartArea1";
            this.chartAtendimentos.ChartAreas.Add(chartArea1);
            this.chartAtendimentos.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartAtendimentos.Legends.Add(legend1);
            this.chartAtendimentos.Location = new System.Drawing.Point(4, 24);
            this.chartAtendimentos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartAtendimentos.Name = "chartAtendimentos";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartAtendimentos.Series.Add(series1);
            this.chartAtendimentos.Size = new System.Drawing.Size(442, 186);
            this.chartAtendimentos.TabIndex = 13;
            this.chartAtendimentos.Text = "chartAtendimentos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chartAtendimentos);
            this.groupBox3.Location = new System.Drawing.Point(434, 18);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(450, 215);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Patients waiting for attendance";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chartAtendimentoPorHora);
            this.groupBox4.Location = new System.Drawing.Point(434, 243);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(450, 215);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Attendace by hour";
            // 
            // chartAtendimentoPorHora
            // 
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.Name = "ChartArea1";
            this.chartAtendimentoPorHora.ChartAreas.Add(chartArea2);
            this.chartAtendimentoPorHora.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartAtendimentoPorHora.Legends.Add(legend2);
            this.chartAtendimentoPorHora.Location = new System.Drawing.Point(4, 24);
            this.chartAtendimentoPorHora.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartAtendimentoPorHora.Name = "chartAtendimentoPorHora";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartAtendimentoPorHora.Series.Add(series2);
            this.chartAtendimentoPorHora.Size = new System.Drawing.Size(442, 186);
            this.chartAtendimentoPorHora.TabIndex = 13;
            this.chartAtendimentoPorHora.Text = "chartAtendimentoPorHora";
            // 
            // tbLogData
            // 
            this.tbLogData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLogData.Location = new System.Drawing.Point(434, 692);
            this.tbLogData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLogData.Multiline = true;
            this.tbLogData.Name = "tbLogData";
            this.tbLogData.ReadOnly = true;
            this.tbLogData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLogData.Size = new System.Drawing.Size(1306, 205);
            this.tbLogData.TabIndex = 16;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chartTempoMedioPorAtendimento);
            this.groupBox5.Location = new System.Drawing.Point(434, 468);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(450, 215);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Average attendance time";
            // 
            // chartTempoMedioPorAtendimento
            // 
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea3.Name = "ChartArea1";
            this.chartTempoMedioPorAtendimento.ChartAreas.Add(chartArea3);
            this.chartTempoMedioPorAtendimento.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chartTempoMedioPorAtendimento.Legends.Add(legend3);
            this.chartTempoMedioPorAtendimento.Location = new System.Drawing.Point(4, 24);
            this.chartTempoMedioPorAtendimento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartTempoMedioPorAtendimento.Name = "chartTempoMedioPorAtendimento";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartTempoMedioPorAtendimento.Series.Add(series3);
            this.chartTempoMedioPorAtendimento.Size = new System.Drawing.Size(442, 186);
            this.chartTempoMedioPorAtendimento.TabIndex = 13;
            this.chartTempoMedioPorAtendimento.Text = "chart2";
            // 
            // FormWard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1758, 917);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tbLogData);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btAdministrador);
            this.Controls.Add(this.tbMouseY);
            this.Controls.Add(this.tbMouseX);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormWard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Ward";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkFatorComplexidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkFatorTempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkTecnicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkEnfermeiros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAtendimentos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAtendimentoPorHora)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTempoMedioPorAtendimento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbTempo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btZerar;
        private System.Windows.Forms.Button btIniciar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTecnicos;
        private System.Windows.Forms.Label lblEnfermeiros;
        private System.Windows.Forms.Label lblPacientes;
        private System.Windows.Forms.TextBox tbMouseX;
        private System.Windows.Forms.TextBox tbMouseY;
        private System.Windows.Forms.Button btCalcular;
        private System.Windows.Forms.Button btAdministrador;
        private System.Windows.Forms.Button btHelpControles;
        public System.Windows.Forms.TextBox tbTempo;
        public System.Windows.Forms.TrackBar trkTecnicos;
        public System.Windows.Forms.TrackBar trkEnfermeiros;
        public System.Windows.Forms.TrackBar trkPacientes;
        public System.Windows.Forms.Timer timerPrincipal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAtendimentos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAtendimentoPorHora;
        private System.Windows.Forms.TextBox tbLogData;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTempoMedioPorAtendimento;
        private System.Windows.Forms.Button btnParar;
        public System.Windows.Forms.TrackBar trkFatorComplexidade;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TrackBar trkFatorTempo;
        private System.Windows.Forms.Label label6;
    }
}