using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO.Ports;
using System.Threading;

using System.Data.SQLite;
using System.Data.SqlClient;


using PROJECT_LELONG_MODBUS_VB_PROFACE_REV1.Class;

namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    public partial class baocaodothi : Form
    {
       
        System.Data.DataTable tbl_bcdt_IN_MAY1 = new System.Data.DataTable();
        System.Data.DataTable tbl_bcdt_OUT_MAY1 = new System.Data.DataTable();
        System.Data.DataTable tbl_bcdt_IN_MAY2 = new System.Data.DataTable();
        System.Data.DataTable tbl_bcdt_OUT_MAY2 = new System.Data.DataTable();
     
        
        public bool date_start_changed = false;
        public bool date_end_changed = false;
        resize_function_1 form_resize_1;
        public baocaodothi()
        {
            InitializeComponent();
           form_resize_1 = new resize_function_1(this);
           this.Load += Load_Inititial_Size_fucntion;
           this.Resize += Resize_function;
            
        }
        private void Load_Inititial_Size_fucntion(object sender, EventArgs e)
        {

            form_resize_1._get_initial_size();
        }
        private void Resize_function(object sender, EventArgs e)
        {

            form_resize_1._resize();
        }

      


        private void baocaodothi_Load(object sender, EventArgs e)
        {
          
            try
            {
                
                Functions.ConnectSQL();
              
                dateTimePickerStart.CloseUp+= new System.EventHandler(dateTimePickerStart_CloseUp);
                dateTimePickerEnd.CloseUp += new System.EventHandler(dateTimePickerEnd_CloseUp);
              
                if (date_start_changed == true && date_end_changed == true)
                {
                    loadcombobox();
                }
                
            }
            catch (Exception ex)
            {
                Functions.DisconnectSQL();
                this.Close();

            }
            switch_language();
        }
        private void switch_language()
        {
            if (Functions.VI_cul == true)
            {
                btn_update_mslh.Text = "Cập nhật mã số lô hàng";
                lblx_soca.Text = "Số ca làm việc";
                lblx_tgbatdau.Text = "Thời gian bắt đầu";
                lblx_tgketthuc.Text = "Thời gian kết thúc";
                this.Text = "Báo cáo đồ thị";
              


            }
            else if (Functions.EN_cul == true)
            {
                btn_update_mslh.Text = "Update article number code";
                lblx_soca.Text = "Shiftwork No";
                lblx_tgbatdau.Text = "The Time begins";
                lblx_tgketthuc.Text = "The Time ends";
                this.Text = "Report chart";
              
            
            }

          
                 
        }

        private void dateTimePickerStart_CloseUp(object sender, EventArgs e)
        {
            date_start_changed = true;
        }
        private void dateTimePickerEnd_CloseUp(object sender, EventArgs e)
        {
            date_end_changed = true;
        }
        public void loadcombobox()
        {

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;

            string sql;
            sql = "SELECT DISTINCT MaLoHang FROM quanlymanhinhtong WHERE strftime('%Y-%m-%d', Ngay) between'" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'";

            cmd = new SQLiteCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
         
            SQLiteDataReader dap = cmd.ExecuteReader();

            while (dap.Read())
            {
               

                comboBox1.Items.Add(dap[0].ToString());

            }
            dap.Close();
            con.Close();
            
            date_start_changed = false;
            date_end_changed = false;
          

        }
      
        private void baocaodulieu_may1_OUT()
        {
            chart_OUTPUT_MAY1.Series["TLBinhVao"].Points.Clear();
            chart_OUTPUT_MAY1.Series["TLBinhTieuChuan"].Points.Clear();
            chart_OUTPUT_MAY1.Series["LSL/USL"].Points.Clear();
            chart_OUTPUT_MAY1.Series["LL"].Points.Clear();
            chart_OUTPUT_MAY1.Series["LCL/UCL"].Points.Clear();
            chart_OUTPUT_MAY1.Series["L"].Points.Clear();

            double TLBTC;
            double DSL;
            double DSH;
            double DSD;
            double DST;
            double SUM;

            tbl_bcdt_OUT_MAY1.Clear();
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;


            string sql = "SELECT MaLoHang, SoCa, TLAcidTC, TLBinhDauMay1 , TLBinhSauMay1, TLAcidMay1 ,DSD, DST, DSL,DSH, SumMay1 FROM quanlymanhinhmay1 WHERE MaLoHang = @mslh AND SoCa= @soca AND Ngay between'" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'";

            cmd = new SQLiteCommand(sql, con);

            cmd.Parameters.AddWithValue("@ngay", "between'" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'");
            cmd.Parameters.AddWithValue("@mslh", comboBox1.Text);
            cmd.Parameters.AddWithValue("@soca", comboBox2.Text);
            SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);

            dap.Fill(tbl_bcdt_OUT_MAY1);
            DataView dv = new DataView(tbl_bcdt_OUT_MAY1);
            dv.Sort = "SumMay1";
            tbl_bcdt_OUT_MAY1 = dv.ToTable();


            TLBTC = double.Parse(tbl_bcdt_OUT_MAY1.Rows[0]["TLAcidTC"].ToString());
            DSL = double.Parse(tbl_bcdt_OUT_MAY1.Rows[0]["DSL"].ToString());
            DSH = double.Parse(tbl_bcdt_OUT_MAY1.Rows[0]["DSH"].ToString());
            DSD = double.Parse(tbl_bcdt_OUT_MAY1.Rows[0]["DSD"].ToString());
            DST = double.Parse(tbl_bcdt_OUT_MAY1.Rows[0]["DST"].ToString());
            SUM = double.Parse(tbl_bcdt_OUT_MAY1.Rows[0]["SumMay1"].ToString());
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.Minimum = TLBTC + 2 * DSL;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.Maximum = TLBTC + 2 * DSH;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.Minimum = SUM;
            chart_OUTPUT_MAY1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            chart_OUTPUT_MAY1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;

            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.MinorGrid.Interval = (2 * DSH) / 5;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.Interval = (2 * DSH) / 5;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.Interval = 1;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;


            for (int i = 0; i < tbl_bcdt_OUT_MAY1.Rows.Count; i++)
            {

                double DIHH, DIH, DILL, DIL;
                double GTCanra_May1;
                DIHH = double.Parse(tbl_bcdt_OUT_MAY1.Rows[i]["TLAcidTC"].ToString()) + double.Parse(tbl_bcdt_OUT_MAY1.Rows[i]["DSH"].ToString());
                DILL = double.Parse(tbl_bcdt_OUT_MAY1.Rows[i]["TLAcidTC"].ToString()) + double.Parse(tbl_bcdt_OUT_MAY1.Rows[i]["DSL"].ToString());
                DIH = double.Parse(tbl_bcdt_OUT_MAY1.Rows[i]["TLAcidTC"].ToString()) + double.Parse(tbl_bcdt_OUT_MAY1.Rows[i]["DST"].ToString());
                DIL = double.Parse(tbl_bcdt_OUT_MAY1.Rows[i]["TLAcidTC"].ToString()) + double.Parse(tbl_bcdt_OUT_MAY1.Rows[i]["DSD"].ToString());
                GTCanra_May1 = double.Parse(tbl_bcdt_OUT_MAY1.Rows[i]["TLBinhSauMay1"].ToString()) - double.Parse(tbl_bcdt_OUT_MAY1.Rows[i]["TLBinhDauMay1"].ToString());


                chart_OUTPUT_MAY1.Series["TLBinhVao"].Points.AddXY(tbl_bcdt_OUT_MAY1.Rows[i]["SumMay1"], GTCanra_May1);
                chart_OUTPUT_MAY1.Series["TLBinhTieuChuan"].Points.AddXY(tbl_bcdt_OUT_MAY1.Rows[i]["SumMay1"], tbl_bcdt_OUT_MAY1.Rows[i]["TLAcidTC"]);
                chart_OUTPUT_MAY1.Series["LSL/USL"].Points.AddXY(tbl_bcdt_OUT_MAY1.Rows[i]["SumMay1"], DIHH);
                chart_OUTPUT_MAY1.Series["LL"].Points.AddXY(tbl_bcdt_OUT_MAY1.Rows[i]["SumMay1"], DILL);
                chart_OUTPUT_MAY1.Series["LCL/UCL"].Points.AddXY(tbl_bcdt_OUT_MAY1.Rows[i]["SumMay1"], DIH);
                chart_OUTPUT_MAY1.Series["L"].Points.AddXY(tbl_bcdt_OUT_MAY1.Rows[i]["SumMay1"], DIL);
                //chart_INPUT.Update();

            }
            if (chart_OUTPUT_MAY1.Series["TLBinhVao"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["LSL/USL"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["LL"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["LCL/UCL"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["L"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["TLBinhTieuChuan"].Points.Count > 20)
            {
                chart_OUTPUT_MAY1.ChartAreas[0].AxisX.ScaleView.Position = chart_OUTPUT_MAY1.Series[0].Points.Count - 20;
                chart_OUTPUT_MAY1.ChartAreas[0].AxisX.ScaleView.Size = 20;
                // chart_INPUT.ChartAreas[0].AxisX.Minimum = chart_INPUT.ChartAreas[0].AxisX.Maximum - 1.0;

            }
        }

        private void baocaodulieu_may2_OUT()
        {
            chart_OUTPUT_MAY2.Series["TLBinhVao"].Points.Clear();
            chart_OUTPUT_MAY2.Series["TLBinhTieuChuan"].Points.Clear();
            chart_OUTPUT_MAY2.Series["LSL/USL"].Points.Clear();
            chart_OUTPUT_MAY2.Series["LL"].Points.Clear();
            chart_OUTPUT_MAY2.Series["LCL/UCL"].Points.Clear();
            chart_OUTPUT_MAY2.Series["L"].Points.Clear();

            double TLBTC;
            double DSL;
            double DSH;
            double DSD;
            double DST;
            double SUM;

            tbl_bcdt_OUT_MAY2.Clear();
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;


            string sql = "SELECT MaLoHang, SoCa, TLAcidTC, TLBinhDauMay2 , TLBinhSauMay2, TLAcidMay2 ,DSD, DST, DSL,DSH, SumMay2 FROM quanlymanhinhmay2 WHERE MaLoHang = @mslh AND SoCa =@soca AND Ngay between'" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'";

            cmd = new SQLiteCommand(sql, con);

            cmd.Parameters.AddWithValue("@ngay", "between'" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'");
            cmd.Parameters.AddWithValue("@mslh", comboBox1.Text);
            cmd.Parameters.AddWithValue("@soca", comboBox2.Text);

            SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);

            dap.Fill(tbl_bcdt_OUT_MAY2);
            DataView dv = new DataView(tbl_bcdt_OUT_MAY2);
            dv.Sort = "SumMay2";
            tbl_bcdt_OUT_MAY2 = dv.ToTable();


            TLBTC = double.Parse(tbl_bcdt_OUT_MAY2.Rows[0]["TLAcidTC"].ToString());
            DSL = double.Parse(tbl_bcdt_OUT_MAY2.Rows[0]["DSL"].ToString());
            DSH = double.Parse(tbl_bcdt_OUT_MAY2.Rows[0]["DSH"].ToString());
            DSD = double.Parse(tbl_bcdt_OUT_MAY2.Rows[0]["DSD"].ToString());
            DST = double.Parse(tbl_bcdt_OUT_MAY2.Rows[0]["DST"].ToString());
            SUM = double.Parse(tbl_bcdt_OUT_MAY2.Rows[0]["SumMay2"].ToString());
           
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.Minimum = TLBTC + 2 * DSL;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.Maximum = TLBTC + 2 * DSH;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.Minimum = SUM;
            chart_OUTPUT_MAY2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            chart_OUTPUT_MAY2.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;

            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.MinorGrid.Interval = (2 * DSH) / 5;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.Interval = (2 * DSH) / 5;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.Interval = 1;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.MinorGrid.Enabled = true;


            for (int i = 0; i < tbl_bcdt_OUT_MAY2.Rows.Count; i++)
            {

                double DIHH, DIH, DILL, DIL;
                double GTCanra_May2;
                DIHH = double.Parse(tbl_bcdt_OUT_MAY2.Rows[i]["TLAcidTC"].ToString()) + double.Parse(tbl_bcdt_OUT_MAY2.Rows[i]["DSH"].ToString());
                DILL = double.Parse(tbl_bcdt_OUT_MAY2.Rows[i]["TLAcidTC"].ToString()) + double.Parse(tbl_bcdt_OUT_MAY2.Rows[i]["DSL"].ToString());
                DIH = double.Parse(tbl_bcdt_OUT_MAY2.Rows[i]["TLAcidTC"].ToString()) + double.Parse(tbl_bcdt_OUT_MAY2.Rows[i]["DST"].ToString());
                DIL = double.Parse(tbl_bcdt_OUT_MAY2.Rows[i]["TLAcidTC"].ToString()) + double.Parse(tbl_bcdt_OUT_MAY2.Rows[i]["DSD"].ToString());
                GTCanra_May2 = double.Parse(tbl_bcdt_OUT_MAY2.Rows[i]["TLBinhSauMay2"].ToString()) - double.Parse(tbl_bcdt_OUT_MAY2.Rows[i]["TLBinhDauMay2"].ToString());


                chart_OUTPUT_MAY2.Series["TLBinhVao"].Points.AddXY(tbl_bcdt_OUT_MAY2.Rows[i]["SumMay2"], GTCanra_May2);
                chart_OUTPUT_MAY2.Series["TLBinhTieuChuan"].Points.AddXY(tbl_bcdt_OUT_MAY2.Rows[i]["SumMay2"], tbl_bcdt_OUT_MAY2.Rows[i]["TLAcidTC"]);
                chart_OUTPUT_MAY2.Series["LSL/USL"].Points.AddXY(tbl_bcdt_OUT_MAY2.Rows[i]["SumMay2"], DIHH);
                chart_OUTPUT_MAY2.Series["LL"].Points.AddXY(tbl_bcdt_OUT_MAY2.Rows[i]["SumMay2"], DILL);
                chart_OUTPUT_MAY2.Series["LCL/UCL"].Points.AddXY(tbl_bcdt_OUT_MAY2.Rows[i]["SumMay2"], DIH);
                chart_OUTPUT_MAY2.Series["L"].Points.AddXY(tbl_bcdt_OUT_MAY2.Rows[i]["SumMay2"], DIL);
                //chart_INPUT.Update();

            }
            if (chart_OUTPUT_MAY2.Series["TLBinhVao"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["LSL/USL"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["LL"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["LCL/UCL"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["L"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["TLBinhTieuChuan"].Points.Count > 20)
            {
                chart_OUTPUT_MAY2.ChartAreas[0].AxisX.ScaleView.Position = chart_OUTPUT_MAY1.Series[0].Points.Count - 20;
                chart_OUTPUT_MAY2.ChartAreas[0].AxisX.ScaleView.Size = 20;
                // chart_INPUT.ChartAreas[0].AxisX.Minimum = chart_INPUT.ChartAreas[0].AxisX.Maximum - 1.0;

            }
        }

      


        private void btn_update_mslh_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
           
            loadcombobox();
        }


        private void button_exit_Click(object sender, EventArgs e)
        {
            Class.Functions.DisconnectSQL();
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            baocaodulieu_may1_OUT();



            baocaodulieu_may2_OUT();
        }


       


       

    
      

       
    }
     
}
