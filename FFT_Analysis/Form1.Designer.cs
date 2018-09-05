namespace FFT_Analysis
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.FromArduinoButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.DataPointsLabel = new System.Windows.Forms.Label();
            this.GatherDataTimer = new System.Windows.Forms.Timer(this.components);
            this.TaskLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.label2 = new System.Windows.Forms.Label();
            this.PrefixTextBox = new System.Windows.Forms.MaskedTextBox();
            this.FromFileButton = new System.Windows.Forms.Button();
            this.StopCollectingButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LegendTextBox1 = new System.Windows.Forms.TextBox();
            this.LegendLabel1 = new System.Windows.Forms.Label();
            this.LegendLabel2 = new System.Windows.Forms.Label();
            this.LegendTextBox2 = new System.Windows.Forms.TextBox();
            this.LegendLabel3 = new System.Windows.Forms.Label();
            this.LegendTextBox3 = new System.Windows.Forms.TextBox();
            this.LegendLabel4 = new System.Windows.Forms.Label();
            this.LegendTextBox4 = new System.Windows.Forms.TextBox();
            this.LegendLabel5 = new System.Windows.Forms.Label();
            this.LegendTextBox5 = new System.Windows.Forms.TextBox();
            this.LegendLabel6 = new System.Windows.Forms.Label();
            this.LegendTextBox6 = new System.Windows.Forms.TextBox();
            this.LegendLabel7 = new System.Windows.Forms.Label();
            this.LegendTextBox7 = new System.Windows.Forms.TextBox();
            this.SetButton1 = new System.Windows.Forms.Button();
            this.SetButton2 = new System.Windows.Forms.Button();
            this.SetButton3 = new System.Windows.Forms.Button();
            this.SetButton4 = new System.Windows.Forms.Button();
            this.SetButton5 = new System.Windows.Forms.Button();
            this.SetButton6 = new System.Windows.Forms.Button();
            this.SetButton7 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ToleranceTextBox = new System.Windows.Forms.TextBox();
            this.SaveDataCheckBox = new System.Windows.Forms.CheckBox();
            this.NumDataPointsTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PointsToPlotTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.xValueLabel = new System.Windows.Forms.Label();
            this.yValueLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SetSettingsButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.NumMinutesLabel = new System.Windows.Forms.Label();
            this.StartFrequencyButton = new System.Windows.Forms.Button();
            this.EndFrequencyButton = new System.Windows.Forms.Button();
            this.StartFreqTextBox = new System.Windows.Forms.TextBox();
            this.EndFreqTextBox = new System.Windows.Forms.TextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.NumPeaksTextBox = new System.Windows.Forms.TextBox();
            this.ResetAppTimer = new System.Windows.Forms.Timer(this.components);
            this.BaudRate = new System.Windows.Forms.Label();
            this.BaudRateComboBox = new System.Windows.Forms.ComboBox();
            this.TimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.DiskSpaceLabel = new System.Windows.Forms.Label();
            this.ConnectionTextBox = new System.Windows.Forms.TextBox();
            this.SaveTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.FFTDataCheckBox = new System.Windows.Forms.CheckBox();
            this.FFTChartCheckBox = new System.Windows.Forms.CheckBox();
            this.PeakDataCheckBox = new System.Windows.Forms.CheckBox();
            this.PeakChartCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // FromArduinoButton
            // 
            this.FromArduinoButton.Location = new System.Drawing.Point(12, 58);
            this.FromArduinoButton.Name = "FromArduinoButton";
            this.FromArduinoButton.Size = new System.Drawing.Size(121, 41);
            this.FromArduinoButton.TabIndex = 0;
            this.FromArduinoButton.Text = "Sensor";
            this.FromArduinoButton.UseVisualStyleBackColor = true;
            this.FromArduinoButton.Click += new System.EventHandler(this.FromArduinoButton_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(338, 299);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(504, 366);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Data Points:";
            // 
            // DataPointsLabel
            // 
            this.DataPointsLabel.AutoSize = true;
            this.DataPointsLabel.Location = new System.Drawing.Point(84, 165);
            this.DataPointsLabel.Name = "DataPointsLabel";
            this.DataPointsLabel.Size = new System.Drawing.Size(13, 13);
            this.DataPointsLabel.TabIndex = 4;
            this.DataPointsLabel.Text = "0";
            // 
            // GatherDataTimer
            // 
            this.GatherDataTimer.Interval = 1;
            this.GatherDataTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TaskLabel
            // 
            this.TaskLabel.AutoSize = true;
            this.TaskLabel.Location = new System.Drawing.Point(84, 9);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(44, 13);
            this.TaskLabel.TabIndex = 5;
            this.TaskLabel.Text = "Nothing";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current Task:";
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(336, 9);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(692, 273);
            this.chart2.TabIndex = 7;
            this.chart2.Text = "chart2";
            this.chart2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseClick);
            // 
            // MainTab
            // 
            this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MainTab.Location = new System.Drawing.Point(0, 272);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(332, 393);
            this.MainTab.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Data File Prefix:";
            // 
            // PrefixTextBox
            // 
            this.PrefixTextBox.Location = new System.Drawing.Point(16, 225);
            this.PrefixTextBox.Name = "PrefixTextBox";
            this.PrefixTextBox.Size = new System.Drawing.Size(100, 20);
            this.PrefixTextBox.TabIndex = 10;
            // 
            // FromFileButton
            // 
            this.FromFileButton.Location = new System.Drawing.Point(139, 58);
            this.FromFileButton.Name = "FromFileButton";
            this.FromFileButton.Size = new System.Drawing.Size(116, 41);
            this.FromFileButton.TabIndex = 11;
            this.FromFileButton.Text = "File";
            this.FromFileButton.UseVisualStyleBackColor = true;
            this.FromFileButton.Click += new System.EventHandler(this.FromFileButton_Click);
            // 
            // StopCollectingButton
            // 
            this.StopCollectingButton.Location = new System.Drawing.Point(261, 58);
            this.StopCollectingButton.Name = "StopCollectingButton";
            this.StopCollectingButton.Size = new System.Drawing.Size(62, 41);
            this.StopCollectingButton.TabIndex = 12;
            this.StopCollectingButton.Text = "Stop Collecting";
            this.StopCollectingButton.UseVisualStyleBackColor = true;
            this.StopCollectingButton.Click += new System.EventHandler(this.StopCollectingButton_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(905, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Legend";
            // 
            // LegendTextBox1
            // 
            this.LegendTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendTextBox1.Location = new System.Drawing.Point(848, 342);
            this.LegendTextBox1.Name = "LegendTextBox1";
            this.LegendTextBox1.Size = new System.Drawing.Size(100, 20);
            this.LegendTextBox1.TabIndex = 14;
            // 
            // LegendLabel1
            // 
            this.LegendLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendLabel1.AutoSize = true;
            this.LegendLabel1.Location = new System.Drawing.Point(879, 326);
            this.LegendLabel1.Name = "LegendLabel1";
            this.LegendLabel1.Size = new System.Drawing.Size(0, 13);
            this.LegendLabel1.TabIndex = 15;
            // 
            // LegendLabel2
            // 
            this.LegendLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendLabel2.AutoSize = true;
            this.LegendLabel2.Location = new System.Drawing.Point(879, 367);
            this.LegendLabel2.Name = "LegendLabel2";
            this.LegendLabel2.Size = new System.Drawing.Size(0, 13);
            this.LegendLabel2.TabIndex = 17;
            // 
            // LegendTextBox2
            // 
            this.LegendTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendTextBox2.Location = new System.Drawing.Point(848, 383);
            this.LegendTextBox2.Name = "LegendTextBox2";
            this.LegendTextBox2.Size = new System.Drawing.Size(100, 20);
            this.LegendTextBox2.TabIndex = 16;
            // 
            // LegendLabel3
            // 
            this.LegendLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendLabel3.AutoSize = true;
            this.LegendLabel3.Location = new System.Drawing.Point(879, 407);
            this.LegendLabel3.Name = "LegendLabel3";
            this.LegendLabel3.Size = new System.Drawing.Size(0, 13);
            this.LegendLabel3.TabIndex = 19;
            // 
            // LegendTextBox3
            // 
            this.LegendTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendTextBox3.Location = new System.Drawing.Point(848, 423);
            this.LegendTextBox3.Name = "LegendTextBox3";
            this.LegendTextBox3.Size = new System.Drawing.Size(100, 20);
            this.LegendTextBox3.TabIndex = 18;
            // 
            // LegendLabel4
            // 
            this.LegendLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendLabel4.AutoSize = true;
            this.LegendLabel4.Location = new System.Drawing.Point(879, 448);
            this.LegendLabel4.Name = "LegendLabel4";
            this.LegendLabel4.Size = new System.Drawing.Size(0, 13);
            this.LegendLabel4.TabIndex = 21;
            // 
            // LegendTextBox4
            // 
            this.LegendTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendTextBox4.Location = new System.Drawing.Point(848, 464);
            this.LegendTextBox4.Name = "LegendTextBox4";
            this.LegendTextBox4.Size = new System.Drawing.Size(100, 20);
            this.LegendTextBox4.TabIndex = 20;
            // 
            // LegendLabel5
            // 
            this.LegendLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendLabel5.AutoSize = true;
            this.LegendLabel5.Location = new System.Drawing.Point(879, 488);
            this.LegendLabel5.Name = "LegendLabel5";
            this.LegendLabel5.Size = new System.Drawing.Size(0, 13);
            this.LegendLabel5.TabIndex = 23;
            // 
            // LegendTextBox5
            // 
            this.LegendTextBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendTextBox5.Location = new System.Drawing.Point(848, 504);
            this.LegendTextBox5.Name = "LegendTextBox5";
            this.LegendTextBox5.Size = new System.Drawing.Size(100, 20);
            this.LegendTextBox5.TabIndex = 22;
            // 
            // LegendLabel6
            // 
            this.LegendLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendLabel6.AutoSize = true;
            this.LegendLabel6.Location = new System.Drawing.Point(879, 530);
            this.LegendLabel6.Name = "LegendLabel6";
            this.LegendLabel6.Size = new System.Drawing.Size(0, 13);
            this.LegendLabel6.TabIndex = 25;
            // 
            // LegendTextBox6
            // 
            this.LegendTextBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendTextBox6.Location = new System.Drawing.Point(848, 546);
            this.LegendTextBox6.Name = "LegendTextBox6";
            this.LegendTextBox6.Size = new System.Drawing.Size(100, 20);
            this.LegendTextBox6.TabIndex = 24;
            // 
            // LegendLabel7
            // 
            this.LegendLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendLabel7.AutoSize = true;
            this.LegendLabel7.Location = new System.Drawing.Point(879, 569);
            this.LegendLabel7.Name = "LegendLabel7";
            this.LegendLabel7.Size = new System.Drawing.Size(0, 13);
            this.LegendLabel7.TabIndex = 27;
            // 
            // LegendTextBox7
            // 
            this.LegendTextBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LegendTextBox7.Location = new System.Drawing.Point(848, 585);
            this.LegendTextBox7.Name = "LegendTextBox7";
            this.LegendTextBox7.Size = new System.Drawing.Size(100, 20);
            this.LegendTextBox7.TabIndex = 26;
            // 
            // SetButton1
            // 
            this.SetButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SetButton1.Location = new System.Drawing.Point(963, 326);
            this.SetButton1.Name = "SetButton1";
            this.SetButton1.Size = new System.Drawing.Size(49, 36);
            this.SetButton1.TabIndex = 28;
            this.SetButton1.Text = "Set1";
            this.SetButton1.UseVisualStyleBackColor = true;
            this.SetButton1.Click += new System.EventHandler(this.SetButton1_Click);
            // 
            // SetButton2
            // 
            this.SetButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SetButton2.Location = new System.Drawing.Point(963, 367);
            this.SetButton2.Name = "SetButton2";
            this.SetButton2.Size = new System.Drawing.Size(49, 36);
            this.SetButton2.TabIndex = 29;
            this.SetButton2.Text = "Set2";
            this.SetButton2.UseVisualStyleBackColor = true;
            this.SetButton2.Click += new System.EventHandler(this.SetButton2_Click);
            // 
            // SetButton3
            // 
            this.SetButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SetButton3.Location = new System.Drawing.Point(963, 407);
            this.SetButton3.Name = "SetButton3";
            this.SetButton3.Size = new System.Drawing.Size(49, 36);
            this.SetButton3.TabIndex = 30;
            this.SetButton3.Text = "Set 3";
            this.SetButton3.UseVisualStyleBackColor = true;
            this.SetButton3.Click += new System.EventHandler(this.SetButton3_Click);
            // 
            // SetButton4
            // 
            this.SetButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SetButton4.Location = new System.Drawing.Point(963, 448);
            this.SetButton4.Name = "SetButton4";
            this.SetButton4.Size = new System.Drawing.Size(49, 36);
            this.SetButton4.TabIndex = 31;
            this.SetButton4.Text = "Set4";
            this.SetButton4.UseVisualStyleBackColor = true;
            this.SetButton4.Click += new System.EventHandler(this.SetButton4_Click);
            // 
            // SetButton5
            // 
            this.SetButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SetButton5.Location = new System.Drawing.Point(963, 488);
            this.SetButton5.Name = "SetButton5";
            this.SetButton5.Size = new System.Drawing.Size(49, 36);
            this.SetButton5.TabIndex = 32;
            this.SetButton5.Text = "Set5";
            this.SetButton5.UseVisualStyleBackColor = true;
            this.SetButton5.Click += new System.EventHandler(this.SetButton5_Click);
            // 
            // SetButton6
            // 
            this.SetButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SetButton6.Location = new System.Drawing.Point(963, 530);
            this.SetButton6.Name = "SetButton6";
            this.SetButton6.Size = new System.Drawing.Size(49, 36);
            this.SetButton6.TabIndex = 33;
            this.SetButton6.Text = "Set6";
            this.SetButton6.UseVisualStyleBackColor = true;
            this.SetButton6.Click += new System.EventHandler(this.SetButton6_Click);
            // 
            // SetButton7
            // 
            this.SetButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SetButton7.Location = new System.Drawing.Point(963, 569);
            this.SetButton7.Name = "SetButton7";
            this.SetButton7.Size = new System.Drawing.Size(49, 36);
            this.SetButton7.TabIndex = 34;
            this.SetButton7.Text = "Set 7";
            this.SetButton7.UseVisualStyleBackColor = true;
            this.SetButton7.Click += new System.EventHandler(this.SetButton7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Peak Tolerance:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Hz";
            // 
            // ToleranceTextBox
            // 
            this.ToleranceTextBox.Location = new System.Drawing.Point(102, 185);
            this.ToleranceTextBox.Name = "ToleranceTextBox";
            this.ToleranceTextBox.Size = new System.Drawing.Size(55, 20);
            this.ToleranceTextBox.TabIndex = 38;
            this.ToleranceTextBox.Text = "2";
            this.ToleranceTextBox.TextChanged += new System.EventHandler(this.ToleranceTextBox_TextChanged);
            // 
            // SaveDataCheckBox
            // 
            this.SaveDataCheckBox.AutoSize = true;
            this.SaveDataCheckBox.Location = new System.Drawing.Point(243, 144);
            this.SaveDataCheckBox.Name = "SaveDataCheckBox";
            this.SaveDataCheckBox.Size = new System.Drawing.Size(77, 17);
            this.SaveDataCheckBox.TabIndex = 39;
            this.SaveDataCheckBox.Text = "Save Data";
            this.SaveDataCheckBox.UseVisualStyleBackColor = true;
            this.SaveDataCheckBox.CheckedChanged += new System.EventHandler(this.SaveDataCheckBox_CheckedChanged);
            // 
            // NumDataPointsTextBox
            // 
            this.NumDataPointsTextBox.Location = new System.Drawing.Point(12, 120);
            this.NumDataPointsTextBox.Name = "NumDataPointsTextBox";
            this.NumDataPointsTextBox.Size = new System.Drawing.Size(121, 20);
            this.NumDataPointsTextBox.TabIndex = 41;
            this.NumDataPointsTextBox.Text = "5000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Number of Data Points";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Time:";
            // 
            // PointsToPlotTextBox
            // 
            this.PointsToPlotTextBox.Location = new System.Drawing.Point(87, 140);
            this.PointsToPlotTextBox.Name = "PointsToPlotTextBox";
            this.PointsToPlotTextBox.Size = new System.Drawing.Size(46, 20);
            this.PointsToPlotTextBox.TabIndex = 48;
            this.PointsToPlotTextBox.Text = "500";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Points to Plot:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(762, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "X Value:";
            // 
            // xValueLabel
            // 
            this.xValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xValueLabel.AutoSize = true;
            this.xValueLabel.Location = new System.Drawing.Point(815, 269);
            this.xValueLabel.Name = "xValueLabel";
            this.xValueLabel.Size = new System.Drawing.Size(27, 13);
            this.xValueLabel.TabIndex = 52;
            this.xValueLabel.Text = "N/A";
            // 
            // yValueLabel
            // 
            this.yValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yValueLabel.AutoSize = true;
            this.yValueLabel.Location = new System.Drawing.Point(905, 269);
            this.yValueLabel.Name = "yValueLabel";
            this.yValueLabel.Size = new System.Drawing.Size(27, 13);
            this.yValueLabel.TabIndex = 53;
            this.yValueLabel.Text = "N/A";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(858, 269);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 54;
            this.label14.Text = "Y Value:";
            // 
            // SetSettingsButton
            // 
            this.SetSettingsButton.Location = new System.Drawing.Point(261, 102);
            this.SetSettingsButton.Name = "SetSettingsButton";
            this.SetSettingsButton.Size = new System.Drawing.Size(62, 42);
            this.SetSettingsButton.TabIndex = 55;
            this.SetSettingsButton.Text = "Set Settings";
            this.SetSettingsButton.UseVisualStyleBackColor = true;
            this.SetSettingsButton.Click += new System.EventHandler(this.SetSettingsButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(261, 9);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(62, 46);
            this.ResetButton.TabIndex = 56;
            this.ResetButton.Text = "Reset App";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // NumMinutesLabel
            // 
            this.NumMinutesLabel.AutoSize = true;
            this.NumMinutesLabel.Location = new System.Drawing.Point(175, 102);
            this.NumMinutesLabel.Name = "NumMinutesLabel";
            this.NumMinutesLabel.Size = new System.Drawing.Size(28, 13);
            this.NumMinutesLabel.TabIndex = 57;
            this.NumMinutesLabel.Text = "0:20";
            // 
            // StartFrequencyButton
            // 
            this.StartFrequencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartFrequencyButton.Location = new System.Drawing.Point(398, 270);
            this.StartFrequencyButton.Name = "StartFrequencyButton";
            this.StartFrequencyButton.Size = new System.Drawing.Size(93, 23);
            this.StartFrequencyButton.TabIndex = 58;
            this.StartFrequencyButton.Text = "Start Frequency";
            this.StartFrequencyButton.UseVisualStyleBackColor = true;
            this.StartFrequencyButton.Click += new System.EventHandler(this.StartFrequencyButton_Click);
            // 
            // EndFrequencyButton
            // 
            this.EndFrequencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EndFrequencyButton.Location = new System.Drawing.Point(548, 269);
            this.EndFrequencyButton.Name = "EndFrequencyButton";
            this.EndFrequencyButton.Size = new System.Drawing.Size(87, 23);
            this.EndFrequencyButton.TabIndex = 59;
            this.EndFrequencyButton.Text = "End Frequency";
            this.EndFrequencyButton.UseVisualStyleBackColor = true;
            this.EndFrequencyButton.Click += new System.EventHandler(this.EndFrequencyButton_Click);
            // 
            // StartFreqTextBox
            // 
            this.StartFreqTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartFreqTextBox.Location = new System.Drawing.Point(497, 272);
            this.StartFreqTextBox.Name = "StartFreqTextBox";
            this.StartFreqTextBox.Size = new System.Drawing.Size(36, 20);
            this.StartFreqTextBox.TabIndex = 60;
            this.StartFreqTextBox.Text = "0";
            // 
            // EndFreqTextBox
            // 
            this.EndFreqTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EndFreqTextBox.Location = new System.Drawing.Point(641, 271);
            this.EndFreqTextBox.Name = "EndFreqTextBox";
            this.EndFreqTextBox.Size = new System.Drawing.Size(30, 20);
            this.EndFreqTextBox.TabIndex = 61;
            this.EndFreqTextBox.Text = "125";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.Location = new System.Drawing.Point(677, 270);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(41, 23);
            this.ApplyButton.TabIndex = 62;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(136, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 63;
            this.label12.Text = "Number Of Peaks:";
            // 
            // NumPeaksTextBox
            // 
            this.NumPeaksTextBox.Location = new System.Drawing.Point(229, 118);
            this.NumPeaksTextBox.Name = "NumPeaksTextBox";
            this.NumPeaksTextBox.Size = new System.Drawing.Size(27, 20);
            this.NumPeaksTextBox.TabIndex = 64;
            this.NumPeaksTextBox.Text = "5";
            this.NumPeaksTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ResetAppTimer
            // 
            this.ResetAppTimer.Interval = 1;
            this.ResetAppTimer.Tick += new System.EventHandler(this.ResetAppTimer_Tick);
            // 
            // BaudRate
            // 
            this.BaudRate.AutoSize = true;
            this.BaudRate.Location = new System.Drawing.Point(136, 140);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(61, 13);
            this.BaudRate.TabIndex = 65;
            this.BaudRate.Text = "Baud Rate:";
            // 
            // BaudRateComboBox
            // 
            this.BaudRateComboBox.FormattingEnabled = true;
            this.BaudRateComboBox.Location = new System.Drawing.Point(139, 155);
            this.BaudRateComboBox.Name = "BaudRateComboBox";
            this.BaudRateComboBox.Size = new System.Drawing.Size(73, 21);
            this.BaudRateComboBox.TabIndex = 66;
            this.BaudRateComboBox.Text = "19200";
            // 
            // TimeoutTimer
            // 
            this.TimeoutTimer.Interval = 3000;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(848, 618);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 67;
            this.label13.Text = "Free Disk Space:";
            // 
            // DiskSpaceLabel
            // 
            this.DiskSpaceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DiskSpaceLabel.AutoSize = true;
            this.DiskSpaceLabel.Location = new System.Drawing.Point(943, 618);
            this.DiskSpaceLabel.Name = "DiskSpaceLabel";
            this.DiskSpaceLabel.Size = new System.Drawing.Size(13, 13);
            this.DiskSpaceLabel.TabIndex = 68;
            this.DiskSpaceLabel.Text = "0";
            // 
            // ConnectionTextBox
            // 
            this.ConnectionTextBox.BackColor = System.Drawing.Color.Ivory;
            this.ConnectionTextBox.Location = new System.Drawing.Point(181, 12);
            this.ConnectionTextBox.Multiline = true;
            this.ConnectionTextBox.Name = "ConnectionTextBox";
            this.ConnectionTextBox.Size = new System.Drawing.Size(74, 37);
            this.ConnectionTextBox.TabIndex = 69;
            this.ConnectionTextBox.Text = "No Connection";
            this.ConnectionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SaveTimeCheckBox
            // 
            this.SaveTimeCheckBox.AutoSize = true;
            this.SaveTimeCheckBox.Enabled = false;
            this.SaveTimeCheckBox.Location = new System.Drawing.Point(243, 164);
            this.SaveTimeCheckBox.Name = "SaveTimeCheckBox";
            this.SaveTimeCheckBox.Size = new System.Drawing.Size(49, 17);
            this.SaveTimeCheckBox.TabIndex = 70;
            this.SaveTimeCheckBox.Text = "Time";
            this.SaveTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // FFTDataCheckBox
            // 
            this.FFTDataCheckBox.AutoSize = true;
            this.FFTDataCheckBox.Enabled = false;
            this.FFTDataCheckBox.Location = new System.Drawing.Point(243, 184);
            this.FFTDataCheckBox.Name = "FFTDataCheckBox";
            this.FFTDataCheckBox.Size = new System.Drawing.Size(71, 17);
            this.FFTDataCheckBox.TabIndex = 71;
            this.FFTDataCheckBox.Text = "FFT Data";
            this.FFTDataCheckBox.UseVisualStyleBackColor = true;
            // 
            // FFTChartCheckBox
            // 
            this.FFTChartCheckBox.AutoSize = true;
            this.FFTChartCheckBox.Enabled = false;
            this.FFTChartCheckBox.Location = new System.Drawing.Point(243, 204);
            this.FFTChartCheckBox.Name = "FFTChartCheckBox";
            this.FFTChartCheckBox.Size = new System.Drawing.Size(73, 17);
            this.FFTChartCheckBox.TabIndex = 72;
            this.FFTChartCheckBox.Text = "FFT Chart";
            this.FFTChartCheckBox.UseVisualStyleBackColor = true;
            // 
            // PeakDataCheckBox
            // 
            this.PeakDataCheckBox.AutoSize = true;
            this.PeakDataCheckBox.Enabled = false;
            this.PeakDataCheckBox.Location = new System.Drawing.Point(243, 224);
            this.PeakDataCheckBox.Name = "PeakDataCheckBox";
            this.PeakDataCheckBox.Size = new System.Drawing.Size(77, 17);
            this.PeakDataCheckBox.TabIndex = 73;
            this.PeakDataCheckBox.Text = "Peak Data";
            this.PeakDataCheckBox.UseVisualStyleBackColor = true;
            // 
            // PeakChartCheckBox
            // 
            this.PeakChartCheckBox.AutoSize = true;
            this.PeakChartCheckBox.Enabled = false;
            this.PeakChartCheckBox.Location = new System.Drawing.Point(243, 244);
            this.PeakChartCheckBox.Name = "PeakChartCheckBox";
            this.PeakChartCheckBox.Size = new System.Drawing.Size(79, 17);
            this.PeakChartCheckBox.TabIndex = 74;
            this.PeakChartCheckBox.Text = "Peak Chart";
            this.PeakChartCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 677);
            this.Controls.Add(this.PeakChartCheckBox);
            this.Controls.Add(this.PeakDataCheckBox);
            this.Controls.Add(this.FFTChartCheckBox);
            this.Controls.Add(this.FFTDataCheckBox);
            this.Controls.Add(this.SaveTimeCheckBox);
            this.Controls.Add(this.ConnectionTextBox);
            this.Controls.Add(this.DiskSpaceLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.BaudRateComboBox);
            this.Controls.Add(this.BaudRate);
            this.Controls.Add(this.NumPeaksTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.EndFreqTextBox);
            this.Controls.Add(this.StartFreqTextBox);
            this.Controls.Add(this.EndFrequencyButton);
            this.Controls.Add(this.StartFrequencyButton);
            this.Controls.Add(this.NumMinutesLabel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SetSettingsButton);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.yValueLabel);
            this.Controls.Add(this.xValueLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PointsToPlotTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NumDataPointsTextBox);
            this.Controls.Add(this.SaveDataCheckBox);
            this.Controls.Add(this.ToleranceTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SetButton7);
            this.Controls.Add(this.SetButton6);
            this.Controls.Add(this.SetButton5);
            this.Controls.Add(this.SetButton4);
            this.Controls.Add(this.SetButton3);
            this.Controls.Add(this.SetButton2);
            this.Controls.Add(this.SetButton1);
            this.Controls.Add(this.LegendLabel7);
            this.Controls.Add(this.LegendTextBox7);
            this.Controls.Add(this.LegendLabel6);
            this.Controls.Add(this.LegendTextBox6);
            this.Controls.Add(this.LegendLabel5);
            this.Controls.Add(this.LegendTextBox5);
            this.Controls.Add(this.LegendLabel4);
            this.Controls.Add(this.LegendTextBox4);
            this.Controls.Add(this.LegendLabel3);
            this.Controls.Add(this.LegendTextBox3);
            this.Controls.Add(this.LegendLabel2);
            this.Controls.Add(this.LegendTextBox2);
            this.Controls.Add(this.LegendLabel1);
            this.Controls.Add(this.LegendTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StopCollectingButton);
            this.Controls.Add(this.FromFileButton);
            this.Controls.Add(this.PrefixTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MainTab);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TaskLabel);
            this.Controls.Add(this.DataPointsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.FromArduinoButton);
            this.Name = "Form1";
            this.Text = "Pump Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FromArduinoButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DataPointsLabel;
        private System.Windows.Forms.Timer GatherDataTimer;
        private System.Windows.Forms.Label TaskLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox PrefixTextBox;
        private System.Windows.Forms.Button FromFileButton;
        private System.Windows.Forms.Button StopCollectingButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LegendTextBox1;
        private System.Windows.Forms.Label LegendLabel1;
        private System.Windows.Forms.Label LegendLabel2;
        private System.Windows.Forms.TextBox LegendTextBox2;
        private System.Windows.Forms.Label LegendLabel3;
        private System.Windows.Forms.TextBox LegendTextBox3;
        private System.Windows.Forms.Label LegendLabel4;
        private System.Windows.Forms.TextBox LegendTextBox4;
        private System.Windows.Forms.Label LegendLabel5;
        private System.Windows.Forms.TextBox LegendTextBox5;
        private System.Windows.Forms.Label LegendLabel6;
        private System.Windows.Forms.TextBox LegendTextBox6;
        private System.Windows.Forms.Label LegendLabel7;
        private System.Windows.Forms.TextBox LegendTextBox7;
        private System.Windows.Forms.Button SetButton1;
        private System.Windows.Forms.Button SetButton2;
        private System.Windows.Forms.Button SetButton3;
        private System.Windows.Forms.Button SetButton4;
        private System.Windows.Forms.Button SetButton5;
        private System.Windows.Forms.Button SetButton6;
        private System.Windows.Forms.Button SetButton7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ToleranceTextBox;
        private System.Windows.Forms.CheckBox SaveDataCheckBox;
        private System.Windows.Forms.TextBox NumDataPointsTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PointsToPlotTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label xValueLabel;
        private System.Windows.Forms.Label yValueLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button SetSettingsButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label NumMinutesLabel;
        private System.Windows.Forms.Button StartFrequencyButton;
        private System.Windows.Forms.Button EndFrequencyButton;
        private System.Windows.Forms.TextBox StartFreqTextBox;
        private System.Windows.Forms.TextBox EndFreqTextBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox NumPeaksTextBox;
        private System.Windows.Forms.Timer ResetAppTimer;
        private System.Windows.Forms.Label BaudRate;
        private System.Windows.Forms.ComboBox BaudRateComboBox;
        private System.Windows.Forms.Timer TimeoutTimer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label DiskSpaceLabel;
        private System.Windows.Forms.TextBox ConnectionTextBox;
        private System.Windows.Forms.CheckBox SaveTimeCheckBox;
        private System.Windows.Forms.CheckBox FFTDataCheckBox;
        private System.Windows.Forms.CheckBox FFTChartCheckBox;
        private System.Windows.Forms.CheckBox PeakDataCheckBox;
        private System.Windows.Forms.CheckBox PeakChartCheckBox;
    }
}

