namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    partial class baocaodothi
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.quanlymanhinhmayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chart_OUTPUT_MAY1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_OUTPUT_MAY2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_update_mslh = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.grp_UserInfo = new System.Windows.Forms.GroupBox();
            this.lblx_tgketthuc = new System.Windows.Forms.Label();
            this.lblx_tgbatdau = new System.Windows.Forms.Label();
            this.lblx_soca = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quanlymanhinhmayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OUTPUT_MAY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OUTPUT_MAY2)).BeginInit();
            this.grp_UserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(185, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(165, 27);
            this.comboBox1.TabIndex = 9;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CalendarFont = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerStart.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(737, 11);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(145, 27);
            this.dateTimePickerStart.TabIndex = 11;
            this.dateTimePickerStart.CloseUp += new System.EventHandler(this.dateTimePickerStart_CloseUp);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CalendarFont = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(1048, 11);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(145, 27);
            this.dateTimePickerEnd.TabIndex = 13;
            this.dateTimePickerEnd.CloseUp += new System.EventHandler(this.dateTimePickerEnd_CloseUp);
            // 
            // quanlymanhinhmayBindingSource
            // 
            this.quanlymanhinhmayBindingSource.DataMember = "quanlymanhinhmay";
            // 
            // chart_OUTPUT_MAY1
            // 
            this.chart_OUTPUT_MAY1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chart_OUTPUT_MAY1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            this.chart_OUTPUT_MAY1.BorderlineWidth = 2;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.ScaleBreakStyle.Spacing = 1D;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.ScaleBreakStyle.Spacing = 1D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.BorderColor = System.Drawing.Color.NavajoWhite;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chart_OUTPUT_MAY1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart_OUTPUT_MAY1.Legends.Add(legend1);
            this.chart_OUTPUT_MAY1.Location = new System.Drawing.Point(0, 45);
            this.chart_OUTPUT_MAY1.Name = "chart_OUTPUT_MAY1";
            series1.BorderColor = System.Drawing.Color.White;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.MarkerBorderWidth = 2;
            series1.MarkerColor = System.Drawing.Color.Black;
            series1.MarkerSize = 9;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "TLBinhVao";
            series1.SmartLabelStyle.CalloutLineWidth = 10;
            series1.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)(((((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Right) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Left) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopRight)));
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Black;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "TLBinhTieuChuan";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.Legend = "Legend1";
            series3.Name = "LSL/USL";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "LL";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Yellow;
            series5.Legend = "Legend1";
            series5.Name = "LCL/UCL";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Yellow;
            series6.IsVisibleInLegend = false;
            series6.Legend = "Legend1";
            series6.Name = "L";
            this.chart_OUTPUT_MAY1.Series.Add(series1);
            this.chart_OUTPUT_MAY1.Series.Add(series2);
            this.chart_OUTPUT_MAY1.Series.Add(series3);
            this.chart_OUTPUT_MAY1.Series.Add(series4);
            this.chart_OUTPUT_MAY1.Series.Add(series5);
            this.chart_OUTPUT_MAY1.Series.Add(series6);
            this.chart_OUTPUT_MAY1.Size = new System.Drawing.Size(1529, 400);
            this.chart_OUTPUT_MAY1.TabIndex = 262;
            this.chart_OUTPUT_MAY1.Text = " ";
            this.chart_OUTPUT_MAY1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // chart_OUTPUT_MAY2
            // 
            this.chart_OUTPUT_MAY2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chart_OUTPUT_MAY2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            this.chart_OUTPUT_MAY2.BorderlineWidth = 2;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.ScaleBreakStyle.Spacing = 1D;
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX2.ScaleBreakStyle.Spacing = 1D;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.MinorGrid.Enabled = true;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.BorderColor = System.Drawing.Color.NavajoWhite;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.chart_OUTPUT_MAY2.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart_OUTPUT_MAY2.Legends.Add(legend2);
            this.chart_OUTPUT_MAY2.Location = new System.Drawing.Point(0, 433);
            this.chart_OUTPUT_MAY2.Name = "chart_OUTPUT_MAY2";
            series7.BorderColor = System.Drawing.Color.White;
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.Blue;
            series7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series7.IsValueShownAsLabel = true;
            series7.LabelForeColor = System.Drawing.Color.Blue;
            series7.Legend = "Legend1";
            series7.MarkerBorderWidth = 2;
            series7.MarkerColor = System.Drawing.Color.Black;
            series7.MarkerSize = 9;
            series7.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series7.Name = "TLBinhVao";
            series7.SmartLabelStyle.CalloutLineWidth = 10;
            series7.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)(((((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Right) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Left) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopRight)));
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Black;
            series8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series8.Legend = "Legend1";
            series8.Name = "TLBinhTieuChuan";
            series9.BorderWidth = 3;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.Red;
            series9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series9.Legend = "Legend1";
            series9.Name = "LSL/USL";
            series10.BorderWidth = 3;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Color = System.Drawing.Color.Red;
            series10.IsVisibleInLegend = false;
            series10.Legend = "Legend1";
            series10.Name = "LL";
            series11.BorderWidth = 3;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Color = System.Drawing.Color.Yellow;
            series11.Legend = "Legend1";
            series11.Name = "LCL/UCL";
            series12.BorderWidth = 3;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Color = System.Drawing.Color.Yellow;
            series12.IsVisibleInLegend = false;
            series12.Legend = "Legend1";
            series12.Name = "L";
            this.chart_OUTPUT_MAY2.Series.Add(series7);
            this.chart_OUTPUT_MAY2.Series.Add(series8);
            this.chart_OUTPUT_MAY2.Series.Add(series9);
            this.chart_OUTPUT_MAY2.Series.Add(series10);
            this.chart_OUTPUT_MAY2.Series.Add(series11);
            this.chart_OUTPUT_MAY2.Series.Add(series12);
            this.chart_OUTPUT_MAY2.Size = new System.Drawing.Size(1527, 400);
            this.chart_OUTPUT_MAY2.TabIndex = 263;
            this.chart_OUTPUT_MAY2.Text = " ";
            this.chart_OUTPUT_MAY2.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // btn_update_mslh
            // 
            this.btn_update_mslh.BackColor = System.Drawing.Color.Green;
            this.btn_update_mslh.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update_mslh.ForeColor = System.Drawing.Color.Yellow;
            this.btn_update_mslh.Location = new System.Drawing.Point(3, 9);
            this.btn_update_mslh.Name = "btn_update_mslh";
            this.btn_update_mslh.Size = new System.Drawing.Size(176, 29);
            this.btn_update_mslh.TabIndex = 264;
            this.btn_update_mslh.Text = "Cập nhật MSLH";
            this.btn_update_mslh.UseVisualStyleBackColor = false;
            this.btn_update_mslh.Click += new System.EventHandler(this.btn_update_mslh_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox2.Location = new System.Drawing.Point(488, 11);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox2.Size = new System.Drawing.Size(85, 27);
            this.comboBox2.TabIndex = 266;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // grp_UserInfo
            // 
            this.grp_UserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.grp_UserInfo.Controls.Add(this.lblx_tgketthuc);
            this.grp_UserInfo.Controls.Add(this.lblx_tgbatdau);
            this.grp_UserInfo.Controls.Add(this.lblx_soca);
            this.grp_UserInfo.Controls.Add(this.btn_update_mslh);
            this.grp_UserInfo.Controls.Add(this.comboBox1);
            this.grp_UserInfo.Controls.Add(this.dateTimePickerEnd);
            this.grp_UserInfo.Controls.Add(this.dateTimePickerStart);
            this.grp_UserInfo.Controls.Add(this.comboBox2);
            this.grp_UserInfo.Location = new System.Drawing.Point(0, -2);
            this.grp_UserInfo.Name = "grp_UserInfo";
            this.grp_UserInfo.Size = new System.Drawing.Size(1890, 44);
            this.grp_UserInfo.TabIndex = 291;
            this.grp_UserInfo.TabStop = false;
            // 
            // lblx_tgketthuc
            // 
            this.lblx_tgketthuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblx_tgketthuc.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_tgketthuc.ForeColor = System.Drawing.Color.Black;
            this.lblx_tgketthuc.Location = new System.Drawing.Point(883, 10);
            this.lblx_tgketthuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx_tgketthuc.Name = "lblx_tgketthuc";
            this.lblx_tgketthuc.Size = new System.Drawing.Size(164, 29);
            this.lblx_tgketthuc.TabIndex = 267;
            this.lblx_tgketthuc.Text = "Thời gian kết thúc";
            this.lblx_tgketthuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblx_tgbatdau
            // 
            this.lblx_tgbatdau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblx_tgbatdau.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_tgbatdau.ForeColor = System.Drawing.Color.Black;
            this.lblx_tgbatdau.Location = new System.Drawing.Point(577, 9);
            this.lblx_tgbatdau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx_tgbatdau.Name = "lblx_tgbatdau";
            this.lblx_tgbatdau.Size = new System.Drawing.Size(161, 29);
            this.lblx_tgbatdau.TabIndex = 267;
            this.lblx_tgbatdau.Text = "Thời gian bắt đầu";
            this.lblx_tgbatdau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblx_soca
            // 
            this.lblx_soca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblx_soca.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_soca.ForeColor = System.Drawing.Color.Black;
            this.lblx_soca.Location = new System.Drawing.Point(357, 10);
            this.lblx_soca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx_soca.Name = "lblx_soca";
            this.lblx_soca.Size = new System.Drawing.Size(129, 29);
            this.lblx_soca.TabIndex = 267;
            this.lblx_soca.Text = "Số ca làm việc";
            this.lblx_soca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // baocaodothi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.grp_UserInfo);
            this.Controls.Add(this.chart_OUTPUT_MAY2);
            this.Controls.Add(this.chart_OUTPUT_MAY1);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "baocaodothi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÁO CÁO ĐỒ THỊ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.baocaodothi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quanlymanhinhmayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OUTPUT_MAY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OUTPUT_MAY2)).EndInit();
            this.grp_UserInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;

        private System.Windows.Forms.BindingSource quanlymanhinhmayBindingSource;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_OUTPUT_MAY1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_OUTPUT_MAY2;
        private System.Windows.Forms.Button btn_update_mslh;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox grp_UserInfo;
        private System.Windows.Forms.Label lblx_soca;
        private System.Windows.Forms.Label lblx_tgketthuc;
        private System.Windows.Forms.Label lblx_tgbatdau;
    }
}