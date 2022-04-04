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
//using EasyModbus;
using OPCAutomation;
using System.Data.SQLite;
using System.Data.SqlClient;
using PROJECT_LELONG_MODBUS_VB_PROFACE_REV1.Class;
//using System.Globalization;
//using System.Resources;
//using System.Reflection;




namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    public partial class man_hinh_may_1 : Form
    {

        #region ELEMENT DECLAREMENT
        bool isDone_INPUT_May1_Ca1 = false;
        bool isDone_INPUT_May1_Ca2 = false;
        bool isDone_OUTPUT_May1_Ca1 = false;
        bool isDone_OUTPUT_May1_Ca2 = false;
        bool isDone_INPUT_May2_Ca1 = false;
        bool isDone_INPUT_May2_Ca2 = false;
        bool isDone_OUTPUT_May2_Ca1 = false;
        bool isDone_OUTPUT_May2_Ca2 = false;



        resize_function_1 form_resize_1;


        public double toa_do_X_canvao_May1_Ca1;  //TONG BINH VAO MAY 1 CA 1
        public double toa_do_X_canvao_May1_Ca2;

        public double toa_do_X_canra_May1_Ca1;   //          RA MAY 1
        public double toa_do_X_canra_May1_Ca2;

        public double toa_do_X_canvao_May2_Ca1;  //          VAO MAY 2
        public double toa_do_X_canvao_May2_Ca2;

        public double toa_do_X_canra_May2_Ca1;   //          RA MAY 2
        public double toa_do_X_canra_May2_Ca2;



        // variable design chart
        double TIL_1, TILL_1, TIH_1, TIHH_1; // limit range INPUT MAY1 
        double TOL_1, TOLL_1, TOH_1, TOHH_1; // limit range OUTPUT MAY1

        double TIL_2, TILL_2, TIH_2, TIHH_2; // limit range INPUT MAY2
        double TOL_2, TOLL_2, TOH_2, TOHH_2; // limit range OUTPUT MAY2

        // variable draw live chart

        string IHH, ILL, IH, IL, TLBTC_INPUT, TLB_INPUT_MAY1, TLB_INPUT_MAY2;
        string OHH, OLL, OH, OL, TLBTC_OUTPUT, TLB_OUTPUT_MAY1, TLB_OUTPUT_MAY2;

        #endregion

        public man_hinh_may_1()
        {

            form_resize_1 = new resize_function_1(this);
            this.Load += Load_Inititial_Size_fucntion;
            this.Resize += Resize_function;
            InitializeComponent();

        }

        private void Load_Inititial_Size_fucntion(object sender, EventArgs e)// LOAD INITIAL SIZE FORN
        {

            form_resize_1._get_initial_size();
        }   
        private void Resize_function(object sender, EventArgs e) // RESIZE SIZE FORM
        {

            form_resize_1._resize();
        }
        
        private void man_hinh_may_1_Load(object sender, EventArgs e) // LOAD man hinh may 1
        {
            lbl_AVE_may1.Text = null;
            lbl_AVE_may2.Text = null;
            lbl_CPK_may1.Text = null;
            lbl_CPK_may2.Text = null;
    

            try
            {
                timer_valve.Start();
                if (Functions.BitAdd_Ca1 == 1)
                {
                    Design_chart_IN_May1_Ca1();
                    Design_chart_OUT_May1_Ca1();

                    Design_chart_IN_May2_Ca1();
                    Design_chart_OUT_May2_Ca1();
                }
                 if (Functions.BitAdd_Ca2 == 1)
                {
                    Design_chart_IN_May1_Ca2();
                    Design_chart_OUT_May1_Ca2();

                    Design_chart_IN_May2_Ca2();
                    Design_chart_OUT_May2_Ca2();
                }


                timer_drawchart_May1.Start();

                timer_drawchart_May2.Start();

                timer_reset_chart.Start();


            }

            catch (Exception ex)
            {



                timer_valve.Stop();
                timer_drawchart_May1.Stop();

                timer_drawchart_May2.Stop();

                timer_reset_chart.Stop();
                this.Close();

            }
            switch_language();
        }
        private void switch_language() // CHANGE LANGUAGE 
        {
            if (Functions.VI_cul == true)
            {
                lblx_mslh.Text = "Mã Số Lô Hàng";
                lblx_qc.Text = "Quy cách";

                lblx_ntt.Text = "Người thao tác";
                lblx_TLvtc.Text = "Bình vào TC";
                lblx_soca.Text = "Số Ca";
                lblx_TLacidtc.Text = "TL Acid TC";
                lblx_ca1.Text = "Ca 1";
                lblx_spcan1.Text = "SP Cân";
                lblx_spdat1.Text = "SP Đạt";
                lblx_spthap1.Text = "SP Thấp";
                lblx_spcao1.Text = "SP Cao";
                lblx_ca2.Text = "Ca 2";
                lblx_spcan2.Text = "SP Cân";
                lblx_spdat2.Text = "SP Đạt";
                lblx_spthap2.Text = "SP thấp";
                lblx_spcao2.Text = "SP cao";
                lblx_TLbinhHT_May1.Text = "TL Bình HT";
                lblx_PL_May1.Text = "Phân Loại";
                lblx_TLbinhdau_May1.Text = "TL Bình Đầu";
                lblx_TLbinhsau_May1.Text = "TL Bình Sau";
                lblx_TLAcid_May1.Text = "TL Acid";
                lblx_PLra_May1.Text = "PL Ra";
                lblx_SL_PLra_May1.Text = "SL. PL ra";



                lblx_TLbinhHT_May2.Text = "TL Bình HT";
                lblx_PL_May2.Text = "Phân Loại";
                lblx_TLbinhdau_May2.Text = "TL Bình Đầu";
                lblx_TLbinhsau_May2.Text = "TL Bình Sau";
                lblx_TLAcid_May2.Text = "TL Acid";
                lblx_PLra_May2.Text = "PL Ra";
                lblx_SL_PLra_May2.Text = "SL. PL ra";
                this.Text = "Màn hình máy";

            }
            else if (Functions.EN_cul == true)
            {
                lblx_mslh.Text = "Article Number Code";
                lblx_qc.Text = "Specification";

                lblx_ntt.Text = "The Operator";
                lblx_TLvtc.Text = "STD IN WGT";
                lblx_soca.Text = "Shiftwork";
                lblx_TLacidtc.Text = "STD Acid WGT";
                lblx_ca1.Text = "1st Shift";
                lblx_spcan1.Text = "Total";
                lblx_spdat1.Text = "OK";
                lblx_spthap1.Text = "Low";
                lblx_spcao1.Text = "High";
                lblx_ca2.Text = "2nd Shift";
                lblx_spcan2.Text = "Total";
                lblx_spdat2.Text = "OK";
                lblx_spthap2.Text = "Low";
                lblx_spcao2.Text = "High";
                lblx_TLbinhHT_May1.Text = "Current WGT";
                lblx_PL_May1.Text = "Classify";
                lblx_TLbinhdau_May1.Text = "First WGT";
                lblx_TLbinhsau_May1.Text = "After WGT";
                lblx_TLAcid_May1.Text = "Acid WGT";
                lblx_PLra_May1.Text = "Sort Out";
                lblx_SL_PLra_May1.Text = "NO Sort Out";



                lblx_TLbinhHT_May2.Text = "Current WGT";
                lblx_PL_May2.Text = "Classify";
                lblx_TLbinhdau_May2.Text = "First WGT";
                lblx_TLbinhsau_May2.Text = "After WGT";
                lblx_TLAcid_May2.Text = "Acid WGT";
                lblx_PLra_May2.Text = "Sort Out";
                lblx_SL_PLra_May2.Text = "NO Sort Out";
                this.Text = "Monitor screen";

            }
           


        }

        // DESIGN CHART IN - OUT 

        private void Design_chart_IN_May1_Ca1()
        {

            TILL_1 = Functions.TLBinh_ChuaCoAxit + Functions.DSL_Binhvao;  //TLBVTC + DSL_I
            TIHH_1 = Functions.TLBinh_ChuaCoAxit + Functions.DSH_Binhvao;  //TLBVTC + DSH_I
            TIL_1 = Functions.DSL_Binhvao;    // DSL_I
            TIH_1 = Functions.DSH_Binhvao;    //DSH_I

            toa_do_X_canvao_May1_Ca1 = Functions.TongBinh_INPUT_May1_Ca1+1 ;



            chart_INPUT_MAY1.ChartAreas[0].AxisY.Minimum = TIL_1 + TILL_1;
            chart_INPUT_MAY1.ChartAreas[0].AxisY.Maximum = TIH_1 + TIHH_1;
            chart_INPUT_MAY1.ChartAreas[0].AxisX.Minimum = toa_do_X_canvao_May1_Ca1;



            chart_INPUT_MAY1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            chart_INPUT_MAY1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;



            double bientructung_INPUT = (2 * TIH_1) / 4;



            int bientructungnguyen_INPUT = (int)bientructung_INPUT;



            chart_INPUT_MAY1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_INPUT_MAY1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart_INPUT_MAY1.ChartAreas[0].AxisY.MinorGrid.Interval = bientructungnguyen_INPUT;


            chart_INPUT_MAY1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart_INPUT_MAY1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart_INPUT_MAY1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;


            //chia khoang truc Y_input
            chart_INPUT_MAY1.ChartAreas[0].AxisY.Interval = bientructungnguyen_INPUT;
            chart_INPUT_MAY1.ChartAreas[0].AxisX.Interval = 1;



        }       
        private void Design_chart_IN_May1_Ca2()
        {

            TILL_1 = Functions.TLBinh_ChuaCoAxit + Functions.DSL_Binhvao;  //TLBVTC + DSL_I
            TIHH_1 = Functions.TLBinh_ChuaCoAxit + Functions.DSH_Binhvao;  //TLBVTC + DSH_I
            TIL_1 = Functions.DSL_Binhvao;    // DSL_I
            TIH_1 = Functions.DSH_Binhvao;    //DSH_I

            toa_do_X_canvao_May1_Ca2 = Functions.TongBinh_INPUT_May1_Ca2+1 ;



            chart_INPUT_MAY1.ChartAreas[0].AxisY.Minimum = TIL_1 + TILL_1;
            chart_INPUT_MAY1.ChartAreas[0].AxisY.Maximum = TIH_1 + TIHH_1;
            chart_INPUT_MAY1.ChartAreas[0].AxisX.Minimum = toa_do_X_canvao_May1_Ca2;



            chart_INPUT_MAY1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            chart_INPUT_MAY1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;



            double bientructung_INPUT = (2 * TIH_1) / 4;



            int bientructungnguyen_INPUT = (int)bientructung_INPUT;



            chart_INPUT_MAY1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_INPUT_MAY1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart_INPUT_MAY1.ChartAreas[0].AxisY.MinorGrid.Interval = bientructungnguyen_INPUT;


            chart_INPUT_MAY1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart_INPUT_MAY1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart_INPUT_MAY1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;


            //chia khoang truc Y_input
            chart_INPUT_MAY1.ChartAreas[0].AxisY.Interval = bientructungnguyen_INPUT;
            chart_INPUT_MAY1.ChartAreas[0].AxisX.Interval = 1;



        }
        private void Design_chart_OUT_May1_Ca1()
        {



            TOLL_1 = Functions.TL_Axit_TC + Functions.DSL_Binhra;  //TLBRTC + DSL_O
            TOHH_1 = Functions.TL_Axit_TC + Functions.DSH_Binhra;  //TLBRTC + DSH_O
            TOL_1 = Functions.DSL_Binhra;    // DSL_O
            TOH_1 = Functions.DSH_Binhra;    //DSH_O


            toa_do_X_canra_May1_Ca1 = Functions.TongBinh_OUTPUT_May1_Ca1+1 ;





            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.Minimum = TOL_1 + TOLL_1;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.Maximum = TOH_1 + TOHH_1;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.Minimum = toa_do_X_canra_May1_Ca1;




            chart_OUTPUT_MAY1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            chart_OUTPUT_MAY1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;



            double bientructung_OUTPUT = (2 * TOH_1) / 4;



            int bientructungnguyen_OUTPUT = (int)bientructung_OUTPUT;



            // Convert.ToInt16(String.Format("{0:0}", bientructung_OUTPUT))
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.MinorGrid.Interval = bientructungnguyen_OUTPUT;


            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;





            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.Interval = bientructungnguyen_OUTPUT;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.Interval = 1;

        }
        private void Design_chart_OUT_May1_Ca2()
        {



            TOLL_1 = Functions.TL_Axit_TC + Functions.DSL_Binhra;  //TLBRTC + DSL_O
            TOHH_1 = Functions.TL_Axit_TC + Functions.DSH_Binhra;  //TLBRTC + DSH_O
            TOL_1 = Functions.DSL_Binhra;    // DSL_O
            TOH_1 = Functions.DSH_Binhra;    //DSH_O


            toa_do_X_canra_May1_Ca2 = Functions.TongBinh_OUTPUT_May1_Ca2+1 ;





            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.Minimum = TOL_1 + TOLL_1;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.Maximum = TOH_1 + TOHH_1;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.Minimum = toa_do_X_canra_May1_Ca2;




            chart_OUTPUT_MAY1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            chart_OUTPUT_MAY1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;



            double bientructung_OUTPUT = (2 * TOH_1) / 4;



            int bientructungnguyen_OUTPUT = (int)bientructung_OUTPUT;



            // Convert.ToInt16(String.Format("{0:0}", bientructung_OUTPUT))
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.MinorGrid.Interval = bientructungnguyen_OUTPUT;


            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;





            chart_OUTPUT_MAY1.ChartAreas[0].AxisY.Interval = bientructungnguyen_OUTPUT;
            chart_OUTPUT_MAY1.ChartAreas[0].AxisX.Interval = 1;

        }
        private void Design_chart_IN_May2_Ca1()
        {

            TILL_2 = Functions.TLBinh_ChuaCoAxit + Functions.DSL_Binhvao;  //TLBVTC + DSL_I
            TIHH_2 = Functions.TLBinh_ChuaCoAxit + Functions.DSH_Binhvao;  //TLBVTC + DSH_I
            TIL_2 = Functions.DSL_Binhvao;    // DSL_I
            TIH_2 = Functions.DSH_Binhvao;    //DSH_I



            toa_do_X_canvao_May2_Ca1 = Functions.TongBinh_INPUT_May2_Ca1 +1;



            chart_INPUT_MAY2.ChartAreas[0].AxisY.Minimum = TIL_1 + TILL_1;
            chart_INPUT_MAY2.ChartAreas[0].AxisY.Maximum = TIH_1 + TIHH_1;
            chart_INPUT_MAY2.ChartAreas[0].AxisX.Minimum = toa_do_X_canvao_May2_Ca1;





            chart_INPUT_MAY2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            chart_INPUT_MAY2.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;


            double bientructung_INPUT = (2 * TIH_1) / 4;



            int bientructungnguyen_INPUT = (int)bientructung_INPUT;





            chart_INPUT_MAY2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_INPUT_MAY2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart_INPUT_MAY2.ChartAreas[0].AxisY.MinorGrid.Interval = bientructungnguyen_INPUT;





            chart_INPUT_MAY2.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart_INPUT_MAY2.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart_INPUT_MAY2.ChartAreas[0].AxisX.MinorGrid.Enabled = true;




            chart_INPUT_MAY2.ChartAreas[0].AxisY.Interval = bientructungnguyen_INPUT;
            chart_INPUT_MAY2.ChartAreas[0].AxisX.Interval = 1;



        }
        private void Design_chart_IN_May2_Ca2()
        {

            TILL_2 = Functions.TLBinh_ChuaCoAxit + Functions.DSL_Binhvao;  //TLBVTC + DSL_I
            TIHH_2 = Functions.TLBinh_ChuaCoAxit + Functions.DSH_Binhvao;  //TLBVTC + DSH_I
            TIL_2 = Functions.DSL_Binhvao;    // DSL_I
            TIH_2 = Functions.DSH_Binhvao;    //DSH_I



            toa_do_X_canvao_May2_Ca2 = Functions.TongBinh_INPUT_May2_Ca2+1 ;



            chart_INPUT_MAY2.ChartAreas[0].AxisY.Minimum = TIL_1 + TILL_1;
            chart_INPUT_MAY2.ChartAreas[0].AxisY.Maximum = TIH_1 + TIHH_1;
            chart_INPUT_MAY2.ChartAreas[0].AxisX.Minimum = toa_do_X_canvao_May2_Ca2;





            chart_INPUT_MAY2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            chart_INPUT_MAY2.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;


            double bientructung_INPUT = (2 * TIH_1) / 4;



            int bientructungnguyen_INPUT = (int)bientructung_INPUT;





            chart_INPUT_MAY2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_INPUT_MAY2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart_INPUT_MAY2.ChartAreas[0].AxisY.MinorGrid.Interval = bientructungnguyen_INPUT;





            chart_INPUT_MAY2.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart_INPUT_MAY2.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart_INPUT_MAY2.ChartAreas[0].AxisX.MinorGrid.Enabled = true;




            chart_INPUT_MAY2.ChartAreas[0].AxisY.Interval = bientructungnguyen_INPUT;
            chart_INPUT_MAY2.ChartAreas[0].AxisX.Interval = 1;



        }
        private void Design_chart_OUT_May2_Ca1()
        {



            TOLL_2 = Functions.TL_Axit_TC + Functions.DSL_Binhra;  //TLBRTC + DSL_O
            TOHH_2 = Functions.TL_Axit_TC + Functions.DSH_Binhra;  //TLBRTC + DSH_O
            TOL_2 = Functions.DSL_Binhra;    // DSL_O
            TOH_2 = Functions.DSH_Binhra;    //DSH_O


            toa_do_X_canra_May2_Ca1 = Functions.TongBinh_OUTPUT_May2_Ca1+1 ;

            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.Minimum = TOL_1 + TOLL_1;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.Maximum = TOH_1 + TOHH_1;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.Minimum = toa_do_X_canra_May2_Ca1;




            chart_OUTPUT_MAY2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            chart_OUTPUT_MAY2.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;



            double bientructung_OUTPUT = (2 * TOH_2) / 4;



            int bientructungnguyen_OUTPUT = (int)bientructung_OUTPUT;


            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.MinorGrid.Interval = bientructungnguyen_OUTPUT;




            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.MinorGrid.Enabled = true;



            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.Interval = bientructungnguyen_OUTPUT;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.Interval = 1;


        }
        private void Design_chart_OUT_May2_Ca2()
        {



            TOLL_2 = Functions.TL_Axit_TC + Functions.DSL_Binhra;  //TLBRTC + DSL_O
            TOHH_2 = Functions.TL_Axit_TC + Functions.DSH_Binhra;  //TLBRTC + DSH_O
            TOL_2 = Functions.DSL_Binhra;    // DSL_O
            TOH_2 = Functions.DSH_Binhra;    //DSH_O


            toa_do_X_canra_May2_Ca2 = Functions.TongBinh_OUTPUT_May2_Ca2+1 ;

            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.Minimum = TOL_1 + TOLL_1;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.Maximum = TOH_1 + TOHH_1;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.Minimum = toa_do_X_canra_May2_Ca2;




            chart_OUTPUT_MAY2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            chart_OUTPUT_MAY2.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;



            double bientructung_OUTPUT = (2 * TOH_2) / 4;



            int bientructungnguyen_OUTPUT = (int)bientructung_OUTPUT;


            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.MinorGrid.Interval = bientructungnguyen_OUTPUT;




            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.MinorGrid.Interval = 1;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.MinorGrid.Enabled = true;



            chart_OUTPUT_MAY2.ChartAreas[0].AxisY.Interval = bientructungnguyen_OUTPUT;
            chart_OUTPUT_MAY2.ChartAreas[0].AxisX.Interval = 1;


        }
 

        private void timer_valve_Tick(object sender, EventArgs e) // TIMER DATA SCAN LOOP
        {

            // variable draw live chart



            lbl_phanloaivao_may1.Text = Functions.Phanloaivao_May1;
            lbl_phanloaivao_may2.Text = Functions.Phanloaivao_May2;
            lbl_phanloaira_may1.Text = Functions.Phanloaira_May1;
            lbl_phanloaira_may2.Text = Functions.Phanloaira_May2;

            IH = (Functions.TLBinh_ChuaCoAxit + Functions.DST_Binhvao).ToString();
            IHH = (Functions.TLBinh_ChuaCoAxit + Functions.DSH_Binhvao).ToString();
            IL = (Functions.TLBinh_ChuaCoAxit + Functions.DSD_Binhvao).ToString();
            ILL = (Functions.TLBinh_ChuaCoAxit + Functions.DSL_Binhvao).ToString();

            TLBTC_INPUT = Functions.TLBinh_ChuaCoAxit.ToString();
            TLB_INPUT_MAY1 = Functions.GT_CanVao_May1.ToString();

            TLB_INPUT_MAY2 = Functions.GT_CanVao_May2.ToString();

            OH = (Functions.TL_Axit_TC + Functions.DST_Binhra).ToString();
            OHH = (Functions.TL_Axit_TC + Functions.DSH_Binhra).ToString();
            OL = (Functions.TL_Axit_TC + Functions.DSD_Binhra).ToString();
            OLL = (Functions.TL_Axit_TC + Functions.DSL_Binhra).ToString();

            TLBTC_OUTPUT = Functions.TL_Axit_TC.ToString();
            TLB_OUTPUT_MAY1 = Functions.TL_Axit_May1.ToString();
            TLB_OUTPUT_MAY2 = Functions.TL_Axit_May2.ToString();



            lbl_mslh.Text = Functions.MSLH.Trim();
            lbl_qc.Text = Functions.quy_cach.Trim(); 
            lbl_ntt.Text = Functions.nguoi_tt.Trim(); 
            lbl_soca.Text = Functions.SoCa; 


            if (Functions.Bit_Thapphan == 1)
            {
                lbl_tlbtc.Text = String.Format("{0:0.0}", Functions.TLBinh_ChuaCoAxit);
                lbl_dsd_binhvao.Text = String.Format("{0:0.0}", Functions.DSD_Binhvao);
                lbl_dst_binhvao.Text = String.Format("{0:0.0}", Functions.DST_Binhvao);
                lbl_axitTC.Text = String.Format("{0:0.0}", Functions.TL_Axit_TC);
                lbl_dsd_binhra.Text = String.Format("{0:0.0}", Functions.DSD_Binhra);
                lbl_dst_binhra.Text = String.Format("{0:0.0}", Functions.DST_Binhra);

                lbl_tlbinhHT_may1.Text = String.Format("{0:0.0}", Functions.GT_CanVao_May1);
                lbl_tlbinhdau_may1.Text = String.Format("{0:0.0}", Functions.TLB_Dau_May1);
                lbl_tlbinhsau_may1.Text = String.Format("{0:0.0}", Functions.TLB_Sau_May1);
                lbl_TLaxit_may1.Text = String.Format("{0:0.0}", Functions.TL_Axit_May1);

                lbl_o1_may1.Text = String.Format("{0:0.0}", Functions.TL_o1_May1);
                lbl_o2_may1.Text = String.Format("{0:0.0}", Functions.TL_o2_May1);
                lbl_o3_may1.Text = String.Format("{0:0.0}", Functions.TL_o3_May1);
                lbl_o4_may1.Text = String.Format("{0:0.0}", Functions.TL_o4_May1);
                lbl_o5_may1.Text = String.Format("{0:0.0}", Functions.TL_o5_May1);
                lbl_o6_may1.Text = String.Format("{0:0.0}", Functions.TL_o6_May1);
                lbl_o7_may1.Text = String.Format("{0:0.0}", Functions.TL_o7_May1);
                lbl_o8_may1.Text = String.Format("{0:0.0}", Functions.TL_o8_May1);
                lbl_o9_may1.Text = String.Format("{0:0.0}", Functions.TL_o9_May1); 
                lbl_o10_may1.Text = String.Format("{0:0.0}", Functions.TL_o10_May1);

                lbl_tlbinhHT_may2.Text = String.Format("{0:0.0}", Functions.GT_CanVao_May2);
                lbl_tlbinhdau_may2.Text = String.Format("{0:0.0}", Functions.TLB_Dau_May2);
                lbl_tlbinhsau_may2.Text = String.Format("{0:0.0}", Functions.TLB_Sau_May2);
                lbl_TLaxit_may2.Text = String.Format("{0:0.0}", Functions.TL_Axit_May2);


                lbl_o1_may2.Text = String.Format("{0:0.0}", Functions.TL_o1_May2);
                lbl_o2_may2.Text = String.Format("{0:0.0}", Functions.TL_o2_May2);
                lbl_o3_may2.Text = String.Format("{0:0.0}", Functions.TL_o3_May2);
                lbl_o4_may2.Text = String.Format("{0:0.0}", Functions.TL_o4_May2);
                lbl_o5_may2.Text = String.Format("{0:0.0}", Functions.TL_o5_May2);
                lbl_o6_may2.Text = String.Format("{0:0.0}", Functions.TL_o6_May2);
                lbl_o7_may2.Text = String.Format("{0:0.0}", Functions.TL_o7_May2);
                lbl_o8_may2.Text = String.Format("{0:0.0}", Functions.TL_o8_May2);
                lbl_o9_may2.Text = String.Format("{0:0.0}", Functions.TL_o9_May2);
                lbl_o10_may2.Text = String.Format("{0:0.0}", Functions.TL_o10_May2);

            }

            else if (Functions.Bit_Thapphan == 0)
            {
                lbl_tlbtc.Text = Functions.TLBinh_ChuaCoAxit.ToString();
                lbl_dsd_binhvao.Text = Functions.DSD_Binhvao.ToString();
                lbl_dst_binhvao.Text = Functions.DST_Binhvao.ToString();
                lbl_axitTC.Text = Functions.TL_Axit_TC.ToString();
                lbl_dsd_binhra.Text = Functions.DSD_Binhra.ToString();
                lbl_dst_binhra.Text = Functions.DST_Binhra.ToString();

                lbl_tlbinhHT_may1.Text = Functions.GT_CanVao_May1.ToString();
                lbl_tlbinhdau_may1.Text = Functions.TLB_Dau_May1.ToString();
                lbl_tlbinhsau_may1.Text = Functions.TLB_Sau_May1.ToString();
                lbl_TLaxit_may1.Text = Functions.TL_Axit_May1.ToString();

                lbl_o1_may1.Text = Functions.TL_o1_May1.ToString();
                lbl_o2_may1.Text = Functions.TL_o2_May1.ToString();
                lbl_o3_may1.Text = Functions.TL_o3_May1.ToString();
                lbl_o4_may1.Text = Functions.TL_o4_May1.ToString();
                lbl_o5_may1.Text = Functions.TL_o5_May1.ToString();
                lbl_o6_may1.Text = Functions.TL_o6_May1.ToString();
                lbl_o7_may1.Text = Functions.TL_o7_May1.ToString();
                lbl_o8_may1.Text = Functions.TL_o8_May1.ToString();
                lbl_o9_may1.Text = Functions.TL_o9_May1.ToString();
                lbl_o10_may1.Text = Functions.TL_o10_May1.ToString();

                lbl_tlbinhHT_may2.Text = Functions.GT_CanVao_May2.ToString();
                lbl_tlbinhdau_may2.Text = Functions.TLB_Dau_May2.ToString();
                lbl_tlbinhsau_may2.Text = Functions.TLB_Sau_May2.ToString();
                lbl_TLaxit_may2.Text = Functions.TL_Axit_May2.ToString();
               

                lbl_o1_may2.Text = Functions.TL_o1_May2.ToString();
                lbl_o2_may2.Text = Functions.TL_o2_May2.ToString();
                lbl_o3_may2.Text = Functions.TL_o3_May2.ToString();
                lbl_o4_may2.Text = Functions.TL_o4_May2.ToString();
                lbl_o5_may2.Text = Functions.TL_o5_May2.ToString();
                lbl_o6_may2.Text = Functions.TL_o6_May2.ToString();
                lbl_o7_may2.Text = Functions.TL_o7_May2.ToString();
                lbl_o8_may2.Text = Functions.TL_o8_May2.ToString();
                lbl_o9_may2.Text = Functions.TL_o9_May2.ToString();
                lbl_o10_may2.Text = Functions.TL_o10_May2.ToString();

            }
           
           

            /////////////////////// ĐẾM SP ĐÃ CÂN , OK , CAO VÀ THẤP

            lbl_ca1_dacan.Text = Functions.Ca1_spdacan.ToString();
            lbl_ca1_dat.Text = Functions.Ca1_spdat.ToString();
            lbl_ca1_thap.Text = Functions.Ca1_spthap.ToString();
            lbl_ca1_cao.Text = Functions.Ca1_spcao.ToString();
            lbl_ca2_dacan.Text = Functions.Ca2_spdacan.ToString();
            lbl_ca2_dat.Text = Functions.Ca2_spdat.ToString();
            lbl_ca2_thap.Text = Functions.Ca2_spthap.ToString();
            lbl_ca2_cao.Text = Functions.Ca2_spcao.ToString();


            //////////////////////////////////////////

            
            lbl_SLphanloaira_may1.Text = Functions.SL_Phanloaira_May1.ToString();
            lbl_SLphanloaira_may2.Text = Functions.SL_Phanloaira_May2.ToString();

            if (Functions.SL_Phanloaivao_May1 == 0)
            {
                lbl_o1_may1.BackColor = Color.White;

                lbl_o2_may1.BackColor = Color.White;
                lbl_o3_may1.BackColor = Color.White;
                lbl_o4_may1.BackColor = Color.White;
                lbl_o5_may1.BackColor = Color.White;
                lbl_o6_may1.BackColor = Color.White;
                lbl_o7_may1.BackColor = Color.White;
                lbl_o8_may1.BackColor = Color.White;
                lbl_o9_may1.BackColor = Color.White;
                lbl_o10_may1.BackColor = Color.White;

            }

            if (Functions.SL_Phanloaivao_May1 == 1)
            {
                lbl_o1_may1.BackColor = Color.PaleGreen;

                lbl_o2_may1.BackColor = Color.White;
                lbl_o3_may1.BackColor = Color.White;
                lbl_o4_may1.BackColor = Color.White;
                lbl_o5_may1.BackColor = Color.White;
                lbl_o6_may1.BackColor = Color.White;
                lbl_o7_may1.BackColor = Color.White;
                lbl_o8_may1.BackColor = Color.White;
                lbl_o9_may1.BackColor = Color.White;
                lbl_o10_may1.BackColor = Color.White;

            }
             if (Functions.SL_Phanloaivao_May1 == 2)
            {
                lbl_o1_may1.BackColor = Color.White;

                lbl_o2_may1.BackColor = Color.PaleGreen;
                lbl_o3_may1.BackColor = Color.White;
                lbl_o4_may1.BackColor = Color.White;
                lbl_o5_may1.BackColor = Color.White;
                lbl_o6_may1.BackColor = Color.White;
                lbl_o7_may1.BackColor = Color.White;
                lbl_o8_may1.BackColor = Color.White;
                lbl_o9_may1.BackColor = Color.White;
                lbl_o10_may1.BackColor = Color.White;
            }
             if (Functions.SL_Phanloaivao_May1 == 3)
            {
                lbl_o1_may1.BackColor = Color.White;

                lbl_o2_may1.BackColor = Color.White;
                lbl_o3_may1.BackColor = Color.PaleGreen;
                lbl_o4_may1.BackColor = Color.White;
                lbl_o5_may1.BackColor = Color.White;
                lbl_o6_may1.BackColor = Color.White;
                lbl_o7_may1.BackColor = Color.White;
                lbl_o8_may1.BackColor = Color.White;
                lbl_o9_may1.BackColor = Color.White;
                lbl_o10_may1.BackColor = Color.White;
            }
             if (Functions.SL_Phanloaivao_May1 == 4)
            {
                lbl_o1_may1.BackColor = Color.White;

                lbl_o2_may1.BackColor = Color.White;
                lbl_o3_may1.BackColor = Color.White;
                lbl_o4_may1.BackColor = Color.PaleGreen;
                lbl_o5_may1.BackColor = Color.White;
                lbl_o6_may1.BackColor = Color.White;
                lbl_o7_may1.BackColor = Color.White;
                lbl_o8_may1.BackColor = Color.White;
                lbl_o9_may1.BackColor = Color.White;
                lbl_o10_may1.BackColor = Color.White;
            }
             if (Functions.SL_Phanloaivao_May1 == 5)
            {
                lbl_o1_may1.BackColor = Color.White;

                lbl_o2_may1.BackColor = Color.White;
                lbl_o3_may1.BackColor = Color.White;
                lbl_o4_may1.BackColor = Color.White;
                lbl_o5_may1.BackColor = Color.PaleGreen;
                lbl_o6_may1.BackColor = Color.White;
                lbl_o7_may1.BackColor = Color.White;
                lbl_o8_may1.BackColor = Color.White;
                lbl_o9_may1.BackColor = Color.White;
                lbl_o10_may1.BackColor = Color.White;
            }
             if (Functions.SL_Phanloaivao_May1 == 6)
            {
                lbl_o1_may1.BackColor = Color.White;

                lbl_o2_may1.BackColor = Color.White;
                lbl_o3_may1.BackColor = Color.White;
                lbl_o4_may1.BackColor = Color.White;
                lbl_o5_may1.BackColor = Color.White;
                lbl_o6_may1.BackColor = Color.PaleGreen;
                lbl_o7_may1.BackColor = Color.White;
                lbl_o8_may1.BackColor = Color.White;
                lbl_o9_may1.BackColor = Color.White;
                lbl_o10_may1.BackColor = Color.White;
            }
             if (Functions.SL_Phanloaivao_May1 == 7)
            {
                lbl_o1_may1.BackColor = Color.White;

                lbl_o2_may1.BackColor = Color.White;
                lbl_o3_may1.BackColor = Color.White;
                lbl_o4_may1.BackColor = Color.White;
                lbl_o5_may1.BackColor = Color.White;
                lbl_o6_may1.BackColor = Color.White;
                lbl_o7_may1.BackColor = Color.PaleGreen;
                lbl_o8_may1.BackColor = Color.White;
                lbl_o9_may1.BackColor = Color.White;
                lbl_o10_may1.BackColor = Color.White;
            }
             if (Functions.SL_Phanloaivao_May1 == 8)
            {
                lbl_o1_may1.BackColor = Color.White;

                lbl_o2_may1.BackColor = Color.White;
                lbl_o3_may1.BackColor = Color.White;
                lbl_o4_may1.BackColor = Color.White;
                lbl_o5_may1.BackColor = Color.White;
                lbl_o6_may1.BackColor = Color.White;
                lbl_o7_may1.BackColor = Color.White;
                lbl_o8_may1.BackColor = Color.PaleGreen;
                lbl_o9_may1.BackColor = Color.White;
                lbl_o10_may1.BackColor = Color.White;
            }
             if (Functions.SL_Phanloaivao_May1 == 9)
            {
                lbl_o1_may1.BackColor = Color.White;

                lbl_o2_may1.BackColor = Color.White;
                lbl_o3_may1.BackColor = Color.White;
                lbl_o4_may1.BackColor = Color.White;
                lbl_o5_may1.BackColor = Color.White;
                lbl_o6_may1.BackColor = Color.White;
                lbl_o7_may1.BackColor = Color.White;
                lbl_o8_may1.BackColor = Color.White;
                lbl_o9_may1.BackColor = Color.PaleGreen;
                lbl_o10_may1.BackColor = Color.White;
            } 
             if (Functions.SL_Phanloaivao_May1 == 10)
            {
                lbl_o1_may1.BackColor = Color.White;

                lbl_o2_may1.BackColor = Color.White;
                lbl_o3_may1.BackColor = Color.White;
                lbl_o4_may1.BackColor = Color.White;
                lbl_o5_may1.BackColor = Color.White;
                lbl_o6_may1.BackColor = Color.White;
                lbl_o7_may1.BackColor = Color.White;
                lbl_o8_may1.BackColor = Color.White;
                lbl_o9_may1.BackColor = Color.White;
                lbl_o10_may1.BackColor = Color.PaleGreen;
            }


            if (Functions.SL_Phanloaivao_May2 == 0)
            {
                lbl_o1_may2.BackColor = Color.White;

                lbl_o2_may2.BackColor = Color.White;
                lbl_o3_may2.BackColor = Color.White;
                lbl_o4_may2.BackColor = Color.White;
                lbl_o5_may2.BackColor = Color.White;
                lbl_o6_may2.BackColor = Color.White;
                lbl_o7_may2.BackColor = Color.White;
                lbl_o8_may2.BackColor = Color.White;
                lbl_o9_may2.BackColor = Color.White;
                lbl_o10_may2.BackColor = Color.White;

            }


            if (Functions.SL_Phanloaivao_May2 == 1)
            {
                lbl_o1_may2.BackColor = Color.PaleGreen;

                lbl_o2_may2.BackColor = Color.White;
                lbl_o3_may2.BackColor = Color.White;
                lbl_o4_may2.BackColor = Color.White;
                lbl_o5_may2.BackColor = Color.White;
                lbl_o6_may2.BackColor = Color.White;
                lbl_o7_may2.BackColor = Color.White;
                lbl_o8_may2.BackColor = Color.White;
                lbl_o9_may2.BackColor = Color.White;
                lbl_o10_may2.BackColor = Color.White;

            }
             if (Functions.SL_Phanloaivao_May2 == 2)
            {
                lbl_o1_may2.BackColor = Color.White;

                lbl_o2_may2.BackColor = Color.PaleGreen;
                lbl_o3_may2.BackColor = Color.White;
                lbl_o4_may2.BackColor = Color.White;
                lbl_o5_may2.BackColor = Color.White;
                lbl_o6_may2.BackColor = Color.White;
                lbl_o7_may2.BackColor = Color.White;
                lbl_o8_may2.BackColor = Color.White;
                lbl_o9_may2.BackColor = Color.White;
                lbl_o10_may2.BackColor = Color.White;

            }
             if (Functions.SL_Phanloaivao_May2 == 3)
            {
                lbl_o1_may2.BackColor = Color.White;

                lbl_o2_may2.BackColor = Color.White;
                lbl_o3_may2.BackColor = Color.PaleGreen;
                lbl_o4_may2.BackColor = Color.White;
                lbl_o5_may2.BackColor = Color.White;
                lbl_o6_may2.BackColor = Color.White;
                lbl_o7_may2.BackColor = Color.White;
                lbl_o8_may2.BackColor = Color.White;
                lbl_o9_may2.BackColor = Color.White;
                lbl_o10_may2.BackColor = Color.White;

            }
             if (Functions.SL_Phanloaivao_May2 == 4)
            {
                lbl_o1_may2.BackColor = Color.White;

                lbl_o2_may2.BackColor = Color.White;
                lbl_o3_may2.BackColor = Color.White;
                lbl_o4_may2.BackColor = Color.PaleGreen;
                lbl_o5_may2.BackColor = Color.White;
                lbl_o6_may2.BackColor = Color.White;
                lbl_o7_may2.BackColor = Color.White;
                lbl_o8_may2.BackColor = Color.White;
                lbl_o9_may2.BackColor = Color.White;
                lbl_o10_may2.BackColor = Color.White;

            }
             if (Functions.SL_Phanloaivao_May2 == 5)
            {
                lbl_o1_may2.BackColor = Color.White;

                lbl_o2_may2.BackColor = Color.White;
                lbl_o3_may2.BackColor = Color.White;
                lbl_o4_may2.BackColor = Color.White;
                lbl_o5_may2.BackColor = Color.PaleGreen;
                lbl_o6_may2.BackColor = Color.White;
                lbl_o7_may2.BackColor = Color.White;
                lbl_o8_may2.BackColor = Color.White;
                lbl_o9_may2.BackColor = Color.White;
                lbl_o10_may2.BackColor = Color.White;

            }
             if (Functions.SL_Phanloaivao_May2 == 6)
            {
                lbl_o1_may2.BackColor = Color.White;

                lbl_o2_may2.BackColor = Color.White;
                lbl_o3_may2.BackColor = Color.White;
                lbl_o4_may2.BackColor = Color.White;
                lbl_o5_may2.BackColor = Color.White;
                lbl_o6_may2.BackColor = Color.PaleGreen;
                lbl_o7_may2.BackColor = Color.White;
                lbl_o8_may2.BackColor = Color.White;
                lbl_o9_may2.BackColor = Color.White;
                lbl_o10_may2.BackColor = Color.White;

            }
             if (Functions.SL_Phanloaivao_May2 == 7)
            {
                lbl_o1_may2.BackColor = Color.White;

                lbl_o2_may2.BackColor = Color.White;
                lbl_o3_may2.BackColor = Color.White;
                lbl_o4_may2.BackColor = Color.White;
                lbl_o5_may2.BackColor = Color.White;
                lbl_o6_may2.BackColor = Color.White;
                lbl_o7_may2.BackColor = Color.PaleGreen;
                lbl_o8_may2.BackColor = Color.White;
                lbl_o9_may2.BackColor = Color.White;
                lbl_o10_may2.BackColor = Color.White;

            }
             if (Functions.SL_Phanloaivao_May2 == 8)
            {
                lbl_o1_may2.BackColor = Color.White;

                lbl_o2_may2.BackColor = Color.White;
                lbl_o3_may2.BackColor = Color.White;
                lbl_o4_may2.BackColor = Color.White;
                lbl_o5_may2.BackColor = Color.White;
                lbl_o6_may2.BackColor = Color.White;
                lbl_o7_may2.BackColor = Color.White;
                lbl_o8_may2.BackColor = Color.PaleGreen;
                lbl_o9_may2.BackColor = Color.White;
                lbl_o10_may2.BackColor = Color.White;

            }
             if (Functions.SL_Phanloaivao_May2 == 9)
            {
                lbl_o1_may2.BackColor = Color.White;

                lbl_o2_may2.BackColor = Color.White;
                lbl_o3_may2.BackColor = Color.White;
                lbl_o4_may2.BackColor = Color.White;
                lbl_o5_may2.BackColor = Color.White;
                lbl_o6_may2.BackColor = Color.White;
                lbl_o7_may2.BackColor = Color.White;
                lbl_o8_may2.BackColor = Color.White;
                lbl_o9_may2.BackColor = Color.PaleGreen;
                lbl_o10_may2.BackColor = Color.White;

            }
             if (Functions.SL_Phanloaivao_May2 == 10)
            {
                lbl_o1_may2.BackColor = Color.White;

                lbl_o2_may2.BackColor = Color.White;
                lbl_o3_may2.BackColor = Color.White;
                lbl_o4_may2.BackColor = Color.White;
                lbl_o5_may2.BackColor = Color.White;
                lbl_o6_may2.BackColor = Color.White;
                lbl_o7_may2.BackColor = Color.White;
                lbl_o8_may2.BackColor = Color.White;
                lbl_o9_may2.BackColor = Color.White;
                lbl_o10_may2.BackColor = Color.PaleGreen;

            }


            ////////////////////// CPK, AVE, STD
            if (Functions.BitAdd_Ca1 == 1)
            {
                lbl_STD_may1.Text = Functions.STD_May1_Ca1.ToString();
                lbl_AVE_may1.Text = Functions.AVE_May1_Ca1.ToString();
                lbl_CPK_may1.Text = Functions.CPK_May1_Ca1.ToString();
                lbl_STD_may2.Text = Functions.STD_May2_Ca1.ToString();
                lbl_AVE_may2.Text = Functions.AVE_May2_Ca1.ToString();
                lbl_CPK_may2.Text = Functions.CPK_May2_Ca1.ToString();
            }
             if (Functions.BitAdd_Ca2 == 1)
            {
                lbl_STD_may1.Text = Functions.STD_May1_Ca2.ToString();
                lbl_AVE_may1.Text = Functions.AVE_May1_Ca2.ToString();
                lbl_CPK_may1.Text = Functions.CPK_May1_Ca2.ToString();
                lbl_STD_may2.Text = Functions.STD_May2_Ca2.ToString();
                lbl_AVE_may2.Text = Functions.AVE_May2_Ca2.ToString();
                lbl_CPK_may2.Text = Functions.CPK_May2_Ca2.ToString();

            }

         

               
         





        }

     
        // DRAW CHART IN - OUT 

        private void IN1_Ca1()
        {


           

            if (Functions.BitAdd_INPUT_May1 == 1 && !isDone_INPUT_May1_Ca1)
            {

                double INPUT_MAY1;

                double DIHH_MAY1, DIH_MAY1, DILL_MAY1, DIL_MAY1, DTCI_MAY1;

                if (IHH == null || IH == null || ILL == null || IL == null || TLBTC_INPUT == null || TLB_INPUT_MAY1 == null)
                {

                    IHH = "0";
                    IH = "0";
                    ILL = "0";
                    IL = "0";
                    TLBTC_INPUT = "0";
                    TLB_INPUT_MAY1 = "0";
                }


                INPUT_MAY1 = double.Parse(TLB_INPUT_MAY1);
                DIHH_MAY1 = double.Parse(IHH); //hh
                DIH_MAY1 = double.Parse(IH); //h
                DILL_MAY1 = double.Parse(ILL); //ll
                DIL_MAY1 = double.Parse(IL);//l
                DTCI_MAY1 = double.Parse(TLBTC_INPUT);//tlbtc



                chart_INPUT_MAY1.Series["TLBinhVao"].Points.AddXY(toa_do_X_canvao_May1_Ca1, INPUT_MAY1);                   //(X,INPUT/10=Y)
                chart_INPUT_MAY1.Series["TLBinhTieuChuan"].Points.AddXY(toa_do_X_canvao_May1_Ca1, DTCI_MAY1);
                chart_INPUT_MAY1.Series["LSL/USL"].Points.AddXY(toa_do_X_canvao_May1_Ca1, DIHH_MAY1);
                chart_INPUT_MAY1.Series["LL"].Points.AddXY(toa_do_X_canvao_May1_Ca1, DILL_MAY1);
                chart_INPUT_MAY1.Series["LCL/UCL"].Points.AddXY(toa_do_X_canvao_May1_Ca1, DIH_MAY1);
                chart_INPUT_MAY1.Series["L"].Points.AddXY(toa_do_X_canvao_May1_Ca1, DIL_MAY1);


                toa_do_X_canvao_May1_Ca1++;



                /// ham lay 20 diem cuoi cung của do thi

                if (chart_INPUT_MAY1.Series["TLBinhVao"].Points.Count > 20 & chart_INPUT_MAY1.Series["LSL/USL"].Points.Count > 20 & chart_INPUT_MAY1.Series["LL"].Points.Count > 20 & chart_INPUT_MAY1.Series["LCL/UCL"].Points.Count > 20 & chart_INPUT_MAY1.Series["L"].Points.Count > 20 & chart_INPUT_MAY1.Series["TLBinhTieuChuan"].Points.Count > 20)
                {



                    chart_INPUT_MAY1.ChartAreas[0].AxisX.Minimum = chart_INPUT_MAY1.ChartAreas[0].AxisX.Maximum - 20;
                    chart_INPUT_MAY1.ChartAreas[0].AxisX.ScaleView.Position = chart_INPUT_MAY1.Series[0].Points.Count - 20;


                }

                isDone_INPUT_May1_Ca1 = true;
            }

             if (Functions.BitAdd_INPUT_May1 == 0)
            {

                isDone_INPUT_May1_Ca1 = false;
            }



        }
        private void IN1_Ca2()
        {


            //// BIEU DO CAN VAO MAY 1
            //     if (double.Parse(TLB_INPUT_MAY1) != 0 )//&& Functions.TongBinh_INPUT_May1 != 0
            // {

            if (Functions.BitAdd_INPUT_May1 == 1 && !isDone_INPUT_May1_Ca2)
            {

                double INPUT_MAY1;

                double DIHH_MAY1, DIH_MAY1, DILL_MAY1, DIL_MAY1, DTCI_MAY1;

                if (IHH == null || IH == null || ILL == null || IL == null || TLBTC_INPUT == null || TLB_INPUT_MAY1 == null)
                {

                    IHH = "0";
                    IH = "0";
                    ILL = "0";
                    IL = "0";
                    TLBTC_INPUT = "0";
                    TLB_INPUT_MAY1 = "0";
                }


                INPUT_MAY1 = double.Parse(TLB_INPUT_MAY1);
                DIHH_MAY1 = double.Parse(IHH); //hh
                DIH_MAY1 = double.Parse(IH); //h
                DILL_MAY1 = double.Parse(ILL); //ll
                DIL_MAY1 = double.Parse(IL);//l
                DTCI_MAY1 = double.Parse(TLBTC_INPUT);//tlbtc



                chart_INPUT_MAY1.Series["TLBinhVao"].Points.AddXY(toa_do_X_canvao_May1_Ca2, INPUT_MAY1);                   //(X,INPUT/10=Y)
                chart_INPUT_MAY1.Series["TLBinhTieuChuan"].Points.AddXY(toa_do_X_canvao_May1_Ca2, DTCI_MAY1);
                chart_INPUT_MAY1.Series["LSL/USL"].Points.AddXY(toa_do_X_canvao_May1_Ca2, DIHH_MAY1);
                chart_INPUT_MAY1.Series["LL"].Points.AddXY(toa_do_X_canvao_May1_Ca2, DILL_MAY1);
                chart_INPUT_MAY1.Series["LCL/UCL"].Points.AddXY(toa_do_X_canvao_May1_Ca2, DIH_MAY1);
                chart_INPUT_MAY1.Series["L"].Points.AddXY(toa_do_X_canvao_May1_Ca2, DIL_MAY1);


                toa_do_X_canvao_May1_Ca2++;



                /// ham lay 20 diem cuoi cung của do thi

                if (chart_INPUT_MAY1.Series["TLBinhVao"].Points.Count > 20 & chart_INPUT_MAY1.Series["LSL/USL"].Points.Count > 20 & chart_INPUT_MAY1.Series["LL"].Points.Count > 20 & chart_INPUT_MAY1.Series["LCL/UCL"].Points.Count > 20 & chart_INPUT_MAY1.Series["L"].Points.Count > 20 & chart_INPUT_MAY1.Series["TLBinhTieuChuan"].Points.Count > 20)
                {



                    chart_INPUT_MAY1.ChartAreas[0].AxisX.Minimum = chart_INPUT_MAY1.ChartAreas[0].AxisX.Maximum - 20;
                    chart_INPUT_MAY1.ChartAreas[0].AxisX.ScaleView.Position = chart_INPUT_MAY1.Series[0].Points.Count - 20;


                }

                isDone_INPUT_May1_Ca2 = true;
            }

             if (Functions.BitAdd_INPUT_May1 == 0)
            {

                isDone_INPUT_May1_Ca2 = false;
            }



        }
        private void OUT1_Ca1()
        {


            //// BIEU DO CAN RA MAY 1
            // if (double.Parse(TLB_OUTPUT_MAY1) != 0 )//&& Functions.TongBinh_OUTPUT_May1 != 0

            if (Functions.BitAdd_OUTPUT_May1 == 1 && !isDone_OUTPUT_May1_Ca1)
            {

                double OUTPUT_MAY1;

                double DOHH_MAY1, DOH_MAY1, DOLL_MAY1, DOL_MAY1, DTCO_MAY1;

                if (OHH == null || OH == null || OLL == null || OL == null || TLBTC_OUTPUT == null || TLB_OUTPUT_MAY1 == null)
                {

                    OHH = "0";
                    OH = "0";
                    OLL = "0";
                    OL = "0";
                    TLBTC_OUTPUT = "0";
                    TLB_OUTPUT_MAY1 = "0";
                }


                OUTPUT_MAY1 = double.Parse(TLB_OUTPUT_MAY1);
                DOHH_MAY1 = double.Parse(OHH); //hh
                DOH_MAY1 = double.Parse(OH); //h
                DOLL_MAY1 = double.Parse(OLL); //ll
                DOL_MAY1 = double.Parse(OL);//l
                DTCO_MAY1 = double.Parse(TLBTC_OUTPUT);//tlbtc



                chart_OUTPUT_MAY1.Series["TLBinhVao"].Points.AddXY(toa_do_X_canra_May1_Ca1, OUTPUT_MAY1);                   //(X,INPUT/10=Y)
                chart_OUTPUT_MAY1.Series["TLBinhTieuChuan"].Points.AddXY(toa_do_X_canra_May1_Ca1, DTCO_MAY1);
                chart_OUTPUT_MAY1.Series["LSL/USL"].Points.AddXY(toa_do_X_canra_May1_Ca1, DOHH_MAY1);
                chart_OUTPUT_MAY1.Series["LL"].Points.AddXY(toa_do_X_canra_May1_Ca1, DOLL_MAY1);
                chart_OUTPUT_MAY1.Series["LCL/UCL"].Points.AddXY(toa_do_X_canra_May1_Ca1, DOH_MAY1);
                chart_OUTPUT_MAY1.Series["L"].Points.AddXY(toa_do_X_canra_May1_Ca1, DOL_MAY1);


                toa_do_X_canra_May1_Ca1++;



                /// ham lay 20 diem cuoi cung của do thi

                if (chart_OUTPUT_MAY1.Series["TLBinhVao"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["LSL/USL"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["LL"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["LCL/UCL"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["L"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["TLBinhTieuChuan"].Points.Count > 20)
                {



                    chart_OUTPUT_MAY1.ChartAreas[0].AxisX.Minimum = chart_OUTPUT_MAY1.ChartAreas[0].AxisX.Maximum - 20;
                    chart_OUTPUT_MAY1.ChartAreas[0].AxisX.ScaleView.Position = chart_OUTPUT_MAY1.Series[0].Points.Count - 20;

                }


                isDone_OUTPUT_May1_Ca1 = true;
            }

             if (Functions.BitAdd_OUTPUT_May1 == 0)
            {

                isDone_OUTPUT_May1_Ca1 = false;
            }




        }
        private void OUT1_Ca2()
        {


            //// BIEU DO CAN RA MAY 1
            // if (double.Parse(TLB_OUTPUT_MAY1) != 0 )//&& Functions.TongBinh_OUTPUT_May1 != 0

            if (Functions.BitAdd_OUTPUT_May1 == 1 && !isDone_OUTPUT_May1_Ca2)
            {

                double OUTPUT_MAY1;

                double DOHH_MAY1, DOH_MAY1, DOLL_MAY1, DOL_MAY1, DTCO_MAY1;

                if (OHH == null || OH == null || OLL == null || OL == null || TLBTC_OUTPUT == null || TLB_OUTPUT_MAY1 == null)
                {

                    OHH = "0";
                    OH = "0";
                    OLL = "0";
                    OL = "0";
                    TLBTC_OUTPUT = "0";
                    TLB_OUTPUT_MAY1 = "0";
                }


                OUTPUT_MAY1 = double.Parse(TLB_OUTPUT_MAY1);
                DOHH_MAY1 = double.Parse(OHH); //hh
                DOH_MAY1 = double.Parse(OH); //h
                DOLL_MAY1 = double.Parse(OLL); //ll
                DOL_MAY1 = double.Parse(OL);//l
                DTCO_MAY1 = double.Parse(TLBTC_OUTPUT);//tlbtc



                chart_OUTPUT_MAY1.Series["TLBinhVao"].Points.AddXY(toa_do_X_canra_May1_Ca2, OUTPUT_MAY1);                   //(X,INPUT/10=Y)
                chart_OUTPUT_MAY1.Series["TLBinhTieuChuan"].Points.AddXY(toa_do_X_canra_May1_Ca2, DTCO_MAY1);
                chart_OUTPUT_MAY1.Series["LSL/USL"].Points.AddXY(toa_do_X_canra_May1_Ca2, DOHH_MAY1);
                chart_OUTPUT_MAY1.Series["LL"].Points.AddXY(toa_do_X_canra_May1_Ca2, DOLL_MAY1);
                chart_OUTPUT_MAY1.Series["LCL/UCL"].Points.AddXY(toa_do_X_canra_May1_Ca2, DOH_MAY1);
                chart_OUTPUT_MAY1.Series["L"].Points.AddXY(toa_do_X_canra_May1_Ca2, DOL_MAY1);


                toa_do_X_canra_May1_Ca2++;



                /// ham lay 20 diem cuoi cung của do thi

                if (chart_OUTPUT_MAY1.Series["TLBinhVao"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["LSL/USL"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["LL"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["LCL/UCL"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["L"].Points.Count > 20 & chart_OUTPUT_MAY1.Series["TLBinhTieuChuan"].Points.Count > 20)
                {



                    chart_OUTPUT_MAY1.ChartAreas[0].AxisX.Minimum = chart_OUTPUT_MAY1.ChartAreas[0].AxisX.Maximum - 20;
                    chart_OUTPUT_MAY1.ChartAreas[0].AxisX.ScaleView.Position = chart_OUTPUT_MAY1.Series[0].Points.Count - 20;

                }


                isDone_OUTPUT_May1_Ca2 = true;
            }

             if (Functions.BitAdd_OUTPUT_May1 == 0)
            {

                isDone_OUTPUT_May1_Ca2 = false;
            }




        }
        private void IN2_Ca1()
        {


            if (Functions.BitAdd_INPUT_May2 == 1 && !isDone_INPUT_May2_Ca1)
            {

                double INPUT_MAY2;

                double DIHH_MAY2, DIH_MAY2, DILL_MAY2, DIL_MAY2, DTCI_MAY2;

                if (IHH == null || IH == null || ILL == null || IL == null || TLBTC_INPUT == null || TLB_INPUT_MAY2 == null)
                {

                    IHH = "0";
                    IH = "0";
                    ILL = "0";
                    IL = "0";
                    TLBTC_INPUT = "0";
                    TLB_INPUT_MAY2 = "0";
                }


                INPUT_MAY2 = double.Parse(TLB_INPUT_MAY2);
                DIHH_MAY2 = double.Parse(IHH); //hh
                DIH_MAY2 = double.Parse(IH); //h
                DILL_MAY2 = double.Parse(ILL); //ll
                DIL_MAY2 = double.Parse(IL);//l
                DTCI_MAY2 = double.Parse(TLBTC_INPUT);//tlbtc



                chart_INPUT_MAY2.Series["TLBinhVao"].Points.AddXY(toa_do_X_canvao_May2_Ca1, INPUT_MAY2);                   //(X,INPUT/10=Y)
                chart_INPUT_MAY2.Series["TLBinhTieuChuan"].Points.AddXY(toa_do_X_canvao_May2_Ca1, DTCI_MAY2);
                chart_INPUT_MAY2.Series["LSL/USL"].Points.AddXY(toa_do_X_canvao_May2_Ca1, DIHH_MAY2);
                chart_INPUT_MAY2.Series["LL"].Points.AddXY(toa_do_X_canvao_May2_Ca1, DILL_MAY2);
                chart_INPUT_MAY2.Series["LCL/UCL"].Points.AddXY(toa_do_X_canvao_May2_Ca1, DIH_MAY2);
                chart_INPUT_MAY2.Series["L"].Points.AddXY(toa_do_X_canvao_May2_Ca1, DIL_MAY2);


                toa_do_X_canvao_May2_Ca1++;



                /// ham lay 20 diem cuoi cung của do thi

                if (chart_INPUT_MAY2.Series["TLBinhVao"].Points.Count > 20 & chart_INPUT_MAY2.Series["LSL/USL"].Points.Count > 20 & chart_INPUT_MAY2.Series["LL"].Points.Count > 20 & chart_INPUT_MAY2.Series["LCL/UCL"].Points.Count > 20 & chart_INPUT_MAY2.Series["L"].Points.Count > 20 & chart_INPUT_MAY2.Series["TLBinhTieuChuan"].Points.Count > 20)
                {



                    chart_INPUT_MAY2.ChartAreas[0].AxisX.Minimum = chart_INPUT_MAY2.ChartAreas[0].AxisX.Maximum - 20;
                    chart_INPUT_MAY2.ChartAreas[0].AxisX.ScaleView.Position = chart_INPUT_MAY2.Series[0].Points.Count - 20;


                }

                isDone_INPUT_May2_Ca1 = true;
            }

             if (Functions.BitAdd_INPUT_May2 == 0)
            {

                isDone_INPUT_May2_Ca1 = false;
            }





        }
        private void IN2_Ca2()
        {


            if (Functions.BitAdd_INPUT_May2 == 1 && !isDone_INPUT_May2_Ca2)
            {

                double INPUT_MAY2;

                double DIHH_MAY2, DIH_MAY2, DILL_MAY2, DIL_MAY2, DTCI_MAY2;

                if (IHH == null || IH == null || ILL == null || IL == null || TLBTC_INPUT == null || TLB_INPUT_MAY2 == null)
                {

                    IHH = "0";
                    IH = "0";
                    ILL = "0";
                    IL = "0";
                    TLBTC_INPUT = "0";
                    TLB_INPUT_MAY2 = "0";
                }


                INPUT_MAY2 = double.Parse(TLB_INPUT_MAY2);
                DIHH_MAY2 = double.Parse(IHH); //hh
                DIH_MAY2 = double.Parse(IH); //h
                DILL_MAY2 = double.Parse(ILL); //ll
                DIL_MAY2 = double.Parse(IL);//l
                DTCI_MAY2 = double.Parse(TLBTC_INPUT);//tlbtc



                chart_INPUT_MAY2.Series["TLBinhVao"].Points.AddXY(toa_do_X_canvao_May2_Ca2, INPUT_MAY2);                   //(X,INPUT/10=Y)
                chart_INPUT_MAY2.Series["TLBinhTieuChuan"].Points.AddXY(toa_do_X_canvao_May2_Ca2, DTCI_MAY2);
                chart_INPUT_MAY2.Series["LSL/USL"].Points.AddXY(toa_do_X_canvao_May2_Ca2, DIHH_MAY2);
                chart_INPUT_MAY2.Series["LL"].Points.AddXY(toa_do_X_canvao_May2_Ca2, DILL_MAY2);
                chart_INPUT_MAY2.Series["LCL/UCL"].Points.AddXY(toa_do_X_canvao_May2_Ca2, DIH_MAY2);
                chart_INPUT_MAY2.Series["L"].Points.AddXY(toa_do_X_canvao_May2_Ca2, DIL_MAY2);


                toa_do_X_canvao_May2_Ca2++;



                /// ham lay 20 diem cuoi cung của do thi

                if (chart_INPUT_MAY2.Series["TLBinhVao"].Points.Count > 20 & chart_INPUT_MAY2.Series["LSL/USL"].Points.Count > 20 & chart_INPUT_MAY2.Series["LL"].Points.Count > 20 & chart_INPUT_MAY2.Series["LCL/UCL"].Points.Count > 20 & chart_INPUT_MAY2.Series["L"].Points.Count > 20 & chart_INPUT_MAY2.Series["TLBinhTieuChuan"].Points.Count > 20)
                {



                    chart_INPUT_MAY2.ChartAreas[0].AxisX.Minimum = chart_INPUT_MAY2.ChartAreas[0].AxisX.Maximum - 20;
                    chart_INPUT_MAY2.ChartAreas[0].AxisX.ScaleView.Position = chart_INPUT_MAY2.Series[0].Points.Count - 20;


                }

                isDone_INPUT_May2_Ca2 = true;
            }

             if (Functions.BitAdd_INPUT_May2 == 0)
            {

                isDone_INPUT_May2_Ca2 = false;
            }



        }
        private void OUT2_Ca1()
        {


            //// BIEU DO CAN RA MAY 2
            // if (double.Parse(TLB_OUTPUT_MAY2) != 0)//&& Functions.TongBinh_OUTPUT_May2 != 0


            if (Functions.BitAdd_OUTPUT_May2 == 1 && !isDone_OUTPUT_May2_Ca1)
            {

                double OUTPUT_MAY2;

                double DOHH_MAY2, DOH_MAY2, DOLL_MAY2, DOL_MAY2, DTCO_MAY2;

                if (OHH == null || OH == null || OLL == null || OL == null || TLBTC_OUTPUT == null || TLB_OUTPUT_MAY2 == null)
                {

                    OHH = "0";
                    OH = "0";
                    OLL = "0";
                    OL = "0";
                    TLBTC_OUTPUT = "0";
                    TLB_OUTPUT_MAY2 = "0";
                }


                OUTPUT_MAY2 = double.Parse(TLB_OUTPUT_MAY2);
                DOHH_MAY2 = double.Parse(OHH); //hh
                DOH_MAY2 = double.Parse(OH); //h
                DOLL_MAY2 = double.Parse(OLL); //ll
                DOL_MAY2 = double.Parse(OL);//l
                DTCO_MAY2 = double.Parse(TLBTC_OUTPUT);//tlbtc



                chart_OUTPUT_MAY2.Series["TLBinhVao"].Points.AddXY(toa_do_X_canra_May2_Ca1, OUTPUT_MAY2);                   //(X,INPUT/10=Y)
                chart_OUTPUT_MAY2.Series["TLBinhTieuChuan"].Points.AddXY(toa_do_X_canra_May2_Ca1, DTCO_MAY2);
                chart_OUTPUT_MAY2.Series["LSL/USL"].Points.AddXY(toa_do_X_canra_May2_Ca1, DOHH_MAY2);
                chart_OUTPUT_MAY2.Series["LL"].Points.AddXY(toa_do_X_canra_May2_Ca1, DOLL_MAY2);
                chart_OUTPUT_MAY2.Series["LCL/UCL"].Points.AddXY(toa_do_X_canra_May2_Ca1, DOH_MAY2);
                chart_OUTPUT_MAY2.Series["L"].Points.AddXY(toa_do_X_canra_May2_Ca1, DOL_MAY2);


                toa_do_X_canra_May2_Ca1++;

                /// ham lay 20 diem cuoi cung của do thi

                if (chart_OUTPUT_MAY2.Series["TLBinhVao"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["LSL/USL"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["LL"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["LCL/UCL"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["L"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["TLBinhTieuChuan"].Points.Count > 20)
                {

                    chart_OUTPUT_MAY2.ChartAreas[0].AxisX.Minimum = chart_OUTPUT_MAY2.ChartAreas[0].AxisX.Maximum - 20;
                    chart_OUTPUT_MAY2.ChartAreas[0].AxisX.ScaleView.Position = chart_OUTPUT_MAY2.Series[0].Points.Count - 20;


                }

                isDone_OUTPUT_May2_Ca1 = true;
            }

             if (Functions.BitAdd_OUTPUT_May2 == 0)
            {

                isDone_OUTPUT_May2_Ca1 = false;
            }




        }
        private void OUT2_Ca2()
        {


            //// BIEU DO CAN RA MAY 2
            // if (double.Parse(TLB_OUTPUT_MAY2) != 0)//&& Functions.TongBinh_OUTPUT_May2 != 0


            if (Functions.BitAdd_OUTPUT_May2 == 1 && !isDone_OUTPUT_May2_Ca2)
            {

                double OUTPUT_MAY2;

                double DOHH_MAY2, DOH_MAY2, DOLL_MAY2, DOL_MAY2, DTCO_MAY2;

                if (OHH == null || OH == null || OLL == null || OL == null || TLBTC_OUTPUT == null || TLB_OUTPUT_MAY2 == null)
                {

                    OHH = "0";
                    OH = "0";
                    OLL = "0";
                    OL = "0";
                    TLBTC_OUTPUT = "0";
                    TLB_OUTPUT_MAY2 = "0";
                }


                OUTPUT_MAY2 = double.Parse(TLB_OUTPUT_MAY2);
                DOHH_MAY2 = double.Parse(OHH); //hh
                DOH_MAY2 = double.Parse(OH); //h
                DOLL_MAY2 = double.Parse(OLL); //ll
                DOL_MAY2 = double.Parse(OL);//l
                DTCO_MAY2 = double.Parse(TLBTC_OUTPUT);//tlbtc



                chart_OUTPUT_MAY2.Series["TLBinhVao"].Points.AddXY(toa_do_X_canra_May2_Ca2, OUTPUT_MAY2);                   //(X,INPUT/10=Y)
                chart_OUTPUT_MAY2.Series["TLBinhTieuChuan"].Points.AddXY(toa_do_X_canra_May2_Ca2, DTCO_MAY2);
                chart_OUTPUT_MAY2.Series["LSL/USL"].Points.AddXY(toa_do_X_canra_May2_Ca2, DOHH_MAY2);
                chart_OUTPUT_MAY2.Series["LL"].Points.AddXY(toa_do_X_canra_May2_Ca2, DOLL_MAY2);
                chart_OUTPUT_MAY2.Series["LCL/UCL"].Points.AddXY(toa_do_X_canra_May2_Ca2, DOH_MAY2);
                chart_OUTPUT_MAY2.Series["L"].Points.AddXY(toa_do_X_canra_May2_Ca2, DOL_MAY2);


                toa_do_X_canra_May2_Ca2++;

                /// ham lay 20 diem cuoi cung của do thi

                if (chart_OUTPUT_MAY2.Series["TLBinhVao"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["LSL/USL"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["LL"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["LCL/UCL"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["L"].Points.Count > 20 & chart_OUTPUT_MAY2.Series["TLBinhTieuChuan"].Points.Count > 20)
                {

                    chart_OUTPUT_MAY2.ChartAreas[0].AxisX.Minimum = chart_OUTPUT_MAY2.ChartAreas[0].AxisX.Maximum - 20;
                    chart_OUTPUT_MAY2.ChartAreas[0].AxisX.ScaleView.Position = chart_OUTPUT_MAY2.Series[0].Points.Count - 20;


                }

                isDone_OUTPUT_May2_Ca2 = true;
            }

             if (Functions.BitAdd_OUTPUT_May2 == 0)
            {

                isDone_OUTPUT_May2_Ca2 = false;
            }




        }

      
        private void timer_drawchart_May1_Tick(object sender, EventArgs e) // TIMER DRAW REAL CHART MAY 1
        {
            if (Functions.BitAdd_Ca1 ==1)
            {
                IN1_Ca1();
                OUT1_Ca1();
            }
             if (Functions.BitAdd_Ca2 == 1)
            {
                IN1_Ca2();
                OUT1_Ca2();
            }

        }

        private void timer_drawchart_May2_Tick(object sender, EventArgs e) // TIMER DRAW REAL CHART MAY 2
        {
            if (Functions.BitAdd_Ca1 == 1)
            {
                IN2_Ca1();
                OUT2_Ca1();
            }
             if (Functions.BitAdd_Ca2 == 1)
            {
                IN2_Ca2();
                OUT2_Ca2();
            }
        }

        private void timer_reset_chart_Tick(object sender, EventArgs e) // TIMER RESETCHART
        {

            if (Functions.BitAdd_baoexcel_Ca1 == 1)
            {

                chart_INPUT_MAY1.Series["TLBinhVao"].Points.Clear();
                chart_INPUT_MAY1.Series["TLBinhTieuChuan"].Points.Clear();
                chart_INPUT_MAY1.Series["LSL/USL"].Points.Clear();
                chart_INPUT_MAY1.Series["LL"].Points.Clear();
                chart_INPUT_MAY1.Series["LCL/UCL"].Points.Clear();
                chart_INPUT_MAY1.Series["L"].Points.Clear();


                chart_INPUT_MAY2.Series["TLBinhVao"].Points.Clear();
                chart_INPUT_MAY2.Series["TLBinhTieuChuan"].Points.Clear();
                chart_INPUT_MAY2.Series["LSL/USL"].Points.Clear();
                chart_INPUT_MAY2.Series["LL"].Points.Clear();
                chart_INPUT_MAY2.Series["LCL/UCL"].Points.Clear();
                chart_INPUT_MAY2.Series["L"].Points.Clear();


                chart_OUTPUT_MAY1.Series["TLBinhVao"].Points.Clear();
                chart_OUTPUT_MAY1.Series["TLBinhTieuChuan"].Points.Clear();
                chart_OUTPUT_MAY1.Series["LSL/USL"].Points.Clear();
                chart_OUTPUT_MAY1.Series["LL"].Points.Clear();
                chart_OUTPUT_MAY1.Series["LCL/UCL"].Points.Clear();
                chart_OUTPUT_MAY1.Series["L"].Points.Clear();


                chart_OUTPUT_MAY2.Series["TLBinhVao"].Points.Clear();
                chart_OUTPUT_MAY2.Series["TLBinhTieuChuan"].Points.Clear();
                chart_OUTPUT_MAY2.Series["LSL/USL"].Points.Clear();
                chart_OUTPUT_MAY2.Series["LL"].Points.Clear();
                chart_OUTPUT_MAY2.Series["LCL/UCL"].Points.Clear();
                chart_OUTPUT_MAY2.Series["L"].Points.Clear();



                timer_drawchart_May1.Stop();
                timer_drawchart_May2.Stop();

                Design_chart_IN_May1_Ca2();
                Design_chart_IN_May2_Ca2();
                Design_chart_OUT_May1_Ca2();
                Design_chart_OUT_May2_Ca2();

               timer_drawchart_May1.Start();
               timer_drawchart_May2.Start();





            }
            if (Functions.BitAdd_baoexcel_Ca2 == 1)
            {

                chart_INPUT_MAY1.Series["TLBinhVao"].Points.Clear();
                chart_INPUT_MAY1.Series["TLBinhTieuChuan"].Points.Clear();
                chart_INPUT_MAY1.Series["LSL/USL"].Points.Clear();
                chart_INPUT_MAY1.Series["LL"].Points.Clear();
                chart_INPUT_MAY1.Series["LCL/UCL"].Points.Clear();
                chart_INPUT_MAY1.Series["L"].Points.Clear();


                chart_INPUT_MAY2.Series["TLBinhVao"].Points.Clear();
                chart_INPUT_MAY2.Series["TLBinhTieuChuan"].Points.Clear();
                chart_INPUT_MAY2.Series["LSL/USL"].Points.Clear();
                chart_INPUT_MAY2.Series["LL"].Points.Clear();
                chart_INPUT_MAY2.Series["LCL/UCL"].Points.Clear();
                chart_INPUT_MAY2.Series["L"].Points.Clear();


                chart_OUTPUT_MAY1.Series["TLBinhVao"].Points.Clear();
                chart_OUTPUT_MAY1.Series["TLBinhTieuChuan"].Points.Clear();
                chart_OUTPUT_MAY1.Series["LSL/USL"].Points.Clear();
                chart_OUTPUT_MAY1.Series["LL"].Points.Clear();
                chart_OUTPUT_MAY1.Series["LCL/UCL"].Points.Clear();
                chart_OUTPUT_MAY1.Series["L"].Points.Clear();


                chart_OUTPUT_MAY2.Series["TLBinhVao"].Points.Clear();
                chart_OUTPUT_MAY2.Series["TLBinhTieuChuan"].Points.Clear();
                chart_OUTPUT_MAY2.Series["LSL/USL"].Points.Clear();
                chart_OUTPUT_MAY2.Series["LL"].Points.Clear();
                chart_OUTPUT_MAY2.Series["LCL/UCL"].Points.Clear();
                chart_OUTPUT_MAY2.Series["L"].Points.Clear();



               timer_drawchart_May1.Stop();
               timer_drawchart_May2.Stop();

                Design_chart_IN_May1_Ca1();
                Design_chart_IN_May2_Ca1();
                Design_chart_OUT_May1_Ca1();
                Design_chart_OUT_May2_Ca1();

                timer_drawchart_May1.Start();
               timer_drawchart_May2.Start();



            }

            if (Functions.BitAdd_Ca1 == 1)
            {
                if (Functions.TongBinh_INPUT_May1_Ca1 == 0)
                {

                    chart_INPUT_MAY1.Series["TLBinhVao"].Points.Clear();
                    chart_INPUT_MAY1.Series["TLBinhTieuChuan"].Points.Clear();
                    chart_INPUT_MAY1.Series["LSL/USL"].Points.Clear();
                    chart_INPUT_MAY1.Series["LL"].Points.Clear();
                    chart_INPUT_MAY1.Series["LCL/UCL"].Points.Clear();
                    chart_INPUT_MAY1.Series["L"].Points.Clear();
                    Design_chart_IN_May1_Ca1();

                  
                }
                if (Functions.TongBinh_INPUT_May2_Ca1 == 0)
                {

                    chart_INPUT_MAY2.Series["TLBinhVao"].Points.Clear();
                    chart_INPUT_MAY2.Series["TLBinhTieuChuan"].Points.Clear();
                    chart_INPUT_MAY2.Series["LSL/USL"].Points.Clear();
                    chart_INPUT_MAY2.Series["LL"].Points.Clear();
                    chart_INPUT_MAY2.Series["LCL/UCL"].Points.Clear();
                    chart_INPUT_MAY2.Series["L"].Points.Clear();
                    
                    Design_chart_IN_May2_Ca1();


                }
                if (Functions.TongBinh_OUTPUT_May1_Ca1 == 0)
                {

                    chart_OUTPUT_MAY1.Series["TLBinhVao"].Points.Clear();
                    chart_OUTPUT_MAY1.Series["TLBinhTieuChuan"].Points.Clear();
                    chart_OUTPUT_MAY1.Series["LSL/USL"].Points.Clear();
                    chart_OUTPUT_MAY1.Series["LL"].Points.Clear();
                    chart_OUTPUT_MAY1.Series["LCL/UCL"].Points.Clear();
                    chart_OUTPUT_MAY1.Series["L"].Points.Clear();

                    //       timer_drawchart_May1.Stop();
                    
                        Design_chart_OUT_May1_Ca1();
                    
                    //  timer_drawchart_May1.Start();

                }
                if (Functions.TongBinh_OUTPUT_May2_Ca1 == 0)
                {

                    chart_OUTPUT_MAY2.Series["TLBinhVao"].Points.Clear();
                    chart_OUTPUT_MAY2.Series["TLBinhTieuChuan"].Points.Clear();
                    chart_OUTPUT_MAY2.Series["LSL/USL"].Points.Clear();
                    chart_OUTPUT_MAY2.Series["LL"].Points.Clear();
                    chart_OUTPUT_MAY2.Series["LCL/UCL"].Points.Clear();
                    chart_OUTPUT_MAY2.Series["L"].Points.Clear();

                    //   timer_drawchart_May2.Stop();

                  
                        Design_chart_OUT_May2_Ca1();

                }
                
            }
            if (Functions.BitAdd_Ca2 == 1)
            {
                if (Functions.TongBinh_INPUT_May1_Ca2 == 0)
                {

                    chart_INPUT_MAY1.Series["TLBinhVao"].Points.Clear();
                    chart_INPUT_MAY1.Series["TLBinhTieuChuan"].Points.Clear();
                    chart_INPUT_MAY1.Series["LSL/USL"].Points.Clear();
                    chart_INPUT_MAY1.Series["LL"].Points.Clear();
                    chart_INPUT_MAY1.Series["LCL/UCL"].Points.Clear();
                    chart_INPUT_MAY1.Series["L"].Points.Clear();
                    Design_chart_IN_May1_Ca2();


                }
                if (Functions.TongBinh_INPUT_May2_Ca2 == 0)
                {

                    chart_INPUT_MAY2.Series["TLBinhVao"].Points.Clear();
                    chart_INPUT_MAY2.Series["TLBinhTieuChuan"].Points.Clear();
                    chart_INPUT_MAY2.Series["LSL/USL"].Points.Clear();
                    chart_INPUT_MAY2.Series["LL"].Points.Clear();
                    chart_INPUT_MAY2.Series["LCL/UCL"].Points.Clear();
                    chart_INPUT_MAY2.Series["L"].Points.Clear();

                    Design_chart_IN_May2_Ca2();


                }
                if (Functions.TongBinh_OUTPUT_May1_Ca2 == 0)
                {

                    chart_OUTPUT_MAY1.Series["TLBinhVao"].Points.Clear();
                    chart_OUTPUT_MAY1.Series["TLBinhTieuChuan"].Points.Clear();
                    chart_OUTPUT_MAY1.Series["LSL/USL"].Points.Clear();
                    chart_OUTPUT_MAY1.Series["LL"].Points.Clear();
                    chart_OUTPUT_MAY1.Series["LCL/UCL"].Points.Clear();
                    chart_OUTPUT_MAY1.Series["L"].Points.Clear();

                    //       timer_drawchart_May1.Stop();

                    Design_chart_OUT_May1_Ca2();

                    //  timer_drawchart_May1.Start();

                }
                if (Functions.TongBinh_OUTPUT_May2_Ca2 == 0)
                {

                    chart_OUTPUT_MAY2.Series["TLBinhVao"].Points.Clear();
                    chart_OUTPUT_MAY2.Series["TLBinhTieuChuan"].Points.Clear();
                    chart_OUTPUT_MAY2.Series["LSL/USL"].Points.Clear();
                    chart_OUTPUT_MAY2.Series["LL"].Points.Clear();
                    chart_OUTPUT_MAY2.Series["LCL/UCL"].Points.Clear();
                    chart_OUTPUT_MAY2.Series["L"].Points.Clear();

                    //   timer_drawchart_May2.Stop();


                    Design_chart_OUT_May2_Ca2();

                }

            }
            

            
        }

           

        }

      
    }


