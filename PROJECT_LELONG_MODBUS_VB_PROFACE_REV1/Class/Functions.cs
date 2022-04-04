 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Windows.Forms;
//using EasyModbus;
using System.IO;
using OPCAutomation;
//using System.Globalization;
//using System.Resources;
//using System.Reflection;
namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1.Class
{
    public class Functions
    {
        
        
        
     //   public static ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
     //   public static CultureInfo cul;            //declare culture info
        public static bool VI_cul, EN_cul;
        public static string MSLH, quy_cach, nguoi_tt, SoCa, Phanloaivao_May1, Phanloaira_May1, Phanloaivao_May2, Phanloaira_May2;
        public static string exit_caption_cul, exit_text_cul, info_caption_cul, excel_text_cul, login_success_cul, login_fail_cul, export_excel_sucessful_cul, ask_delete_mslh_text_cul, insert_mslh_textstring_cul, delete_all_mslh_textstring_cul, update_mslh_textstring_cul;
      
        public OPCAutomation.OPCServer AnOPCServer;
        public static OPCAutomation.OPCServer ConnectedOPCServer;
        public static OPCAutomation.OPCGroup ConnectedGroup;

        public static string Groupname;
        public static int ItemCount;

        public static Array OPCItemIDs = Array.CreateInstance(typeof(string), 10);
        public static Array ItemServerHandles = Array.CreateInstance(typeof(Int32), 10);
        public static Array ItemServerErrors = Array.CreateInstance(typeof(Int32), 10);
        public static Array ClientHandles = Array.CreateInstance(typeof(Int32), 10);
        public static Array RequestedDataTypes = Array.CreateInstance(typeof(Int16), 10);
        public static Array AccessPaths = Array.CreateInstance(typeof(string), 10);
        public static Array WriteItems = Array.CreateInstance(typeof(string), 10);

        public static double TB_Dat_May1, TB_Thap_May1, TB_Cao_May1, TB_Dat_May2, TB_Thap_May2, TB_Cao_May2;

       // public static double  TongBinh_OUTPUT_May1, TongBinh_OUTPUT_May2;
        //TongBinh_INPUT_May1, TongBinh_INPUT_May2,
        public static double TongBinh_INPUT_May1_Ca1, TongBinh_INPUT_May1_Ca2, TongBinh_INPUT_May2_Ca1, TongBinh_INPUT_May2_Ca2;
     
        public static double TongBinh_OUTPUT_May1_Ca1, TongBinh_OUTPUT_May1_Ca2, TongBinh_OUTPUT_May2_Ca1, TongBinh_OUTPUT_May2_Ca2;

        public static double TongBinhLoi_2May, TongBinhLoi_May1, TongBinhLoi_May2;

        public static double Binhloi_o1_May1, Binhloi_o2_May1, Binhloi_o3_May1, Binhloi_o4_May1, Binhloi_o5_May1;

        public static double Binhloi_o1_May1_opc, Binhloi_o2_May1_opc, Binhloi_o3_May1_opc, Binhloi_o4_May1_opc, Binhloi_o5_May1_opc;

        public static double Binhloi_o1_May2, Binhloi_o2_May2, Binhloi_o3_May2, Binhloi_o4_May2, Binhloi_o5_May2;

        public static double Binhloi_o1_May2_opc, Binhloi_o2_May2_opc, Binhloi_o3_May2_opc, Binhloi_o4_May2_opc, Binhloi_o5_May2_opc;






        public static int TT_PLVao_May1, TT_PLRa_May1, TT_PLVao_May2, TT_PLRa_May2;

        public static double  TL_Axit_TC, DSD_Binhvao, DST_Binhvao, DSH_Binhvao, DSL_Binhvao, DSD_Binhra, DST_Binhra, DSH_Binhra, DSL_Binhra;
        public static double  TL_Axit_TC_opc, TLBinh_ChuaCoAxit_opc, DSD_Binhvao_opc, DST_Binhvao_opc, DSH_Binhvao_opc, DSL_Binhvao_opc, DSD_Binhra_opc, DST_Binhra_opc, DSH_Binhra_opc, DSL_Binhra_opc;
        public static double TLBinh_ChuaCoAxit;
        //MAY 1
        public static double TLB_Dau_May1, TLB_Sau_May1, TL_Axit_May1, SL_Phanloaivao_May1, SL_Phanloaira_May1;
        public static double TLB_Dau_May1_opc, TLB_Sau_May1_opc, TL_Axit_May1_opc ;
        public static double GT_CanVao_May1, GT_CanVao_May1_opc;
        public static double TL_o1_May1, TL_o2_May1, TL_o3_May1, TL_o4_May1, TL_o5_May1, TL_o6_May1, TL_o7_May1, TL_o8_May1, TL_o9_May1, TL_o10_May1;
        public static double TL_o1_May1_opc, TL_o2_May1_opc, TL_o3_May1_opc, TL_o4_May1_opc, TL_o5_May1_opc, TL_o6_May1_opc, TL_o7_May1_opc, TL_o8_May1_opc, TL_o9_May1_opc, TL_o10_May1_opc;

        //MAY 2

        public static double TLB_Dau_May2, TLB_Sau_May2, TL_Axit_May2, SL_Phanloaivao_May2, SL_Phanloaira_May2;
        public static double TLB_Dau_May2_opc, TLB_Sau_May2_opc, TL_Axit_May2_opc;
        public static double GT_CanVao_May2, GT_CanVao_May2_opc;
        public static double TL_o1_May2, TL_o2_May2, TL_o3_May2, TL_o4_May2, TL_o5_May2, TL_o6_May2, TL_o7_May2, TL_o8_May2, TL_o9_May2, TL_o10_May2;
        public static double TL_o1_May2_opc, TL_o2_May2_opc, TL_o3_May2_opc, TL_o4_May2_opc, TL_o5_May2_opc, TL_o6_May2_opc, TL_o7_May2_opc, TL_o8_May2_opc, TL_o9_May2_opc, TL_o10_May2_opc;


        //
        public static double Ca1_spdacan, Ca1_spdat, Ca1_spthap, Ca1_spcao, Ca2_spdacan, Ca2_spdat, Ca2_spthap, Ca2_spcao;


        
     
      
        public static int BitAdd_INPUT_May1;
        public static int BitAdd_OUTPUT_May1;
        public static int BitAdd_INPUT_May2;
        public static int BitAdd_OUTPUT_May2;
        public static int BitAdd_Baoloi;
        public static int BitAdd_baoexcel_Ca1;
        public static int BitAdd_baoexcel_Ca2;
        public static int BitAdd_Ca1;
        public static int BitAdd_Ca2;
        public static int BitAdd_xoa_cpk1;
        public static int BitAdd_xoa_cpk2;
        public static int Bit_Thapphan;

        ///


        public static string may1_baoloi, may2_baoloi;
        public static string may1_baoloi_o1, may1_baoloi_o2, may1_baoloi_o3, may1_baoloi_o4, may1_baoloi_o5;
        public static string may2_baoloi_o1, may2_baoloi_o2, may2_baoloi_o3, may2_baoloi_o4, may2_baoloi_o5;
        public static string may1_baoloi_o1_opc, may1_baoloi_o2_opc, may1_baoloi_o3_opc, may1_baoloi_o4_opc, may1_baoloi_o5_opc;
        public static string may2_baoloi_o1_opc, may2_baoloi_o2_opc, may2_baoloi_o3_opc, may2_baoloi_o4_opc, may2_baoloi_o5_opc;
        // variable time 

        public static string date, time, date1, AM_PM;
        public static string gio, phut, giay, ngay, thang, nam;

        public static int int_gio, int_phut, int_giay, int_ngay, int_thang, int_nam;



        // Calculate CPK
        public static double DST_Cal_May1, DSD_Cal_May1, CDTC_Cal_May1;

        public static double DST_Cal_May2, DSD_Cal_May2, CDTC_Cal_May2;

        public static double DSL_Cal_May1, DSH_Cal_May1;

        public static double DSL_Cal_May2, DSH_Cal_May2;



        public static int z1_Ca1 ;
        public static int z1_Ca2;
        public static int z2_Ca1 ;
        public static int z2_Ca2;

        public static double[] CDTT_May1;
        public static double[] CDTT_May2;

        public static double SUM_May1_Ca1, SUMSQUARES_May1_Ca1, SQUARESUMS_May1_Ca1;
        public static double AVE_May1_Ca1;
        public static double STD_May1_Ca1, CPK1_May1_Ca1, CPK2_May1_Ca1, CPK_May1_Ca1;
        public static double NUMERATOR_May1_Ca1, DENOMINATOR_May1_Ca1;

        public static double SUM_May1_Ca2, SUMSQUARES_May1_Ca2, SQUARESUMS_May1_Ca2;
        public static double AVE_May1_Ca2;
        public static double STD_May1_Ca2, CPK1_May1_Ca2, CPK2_May1_Ca2, CPK_May1_Ca2;
        public static double NUMERATOR_May1_Ca2, DENOMINATOR_May1_Ca2;


        public static double SUM_May2_Ca1, SUMSQUARES_May2_Ca1, SQUARESUMS_May2_Ca1 ;
        public static double AVE_May2_Ca1 ;
        public static double STD_May2_Ca1, CPK1_May2_Ca1, CPK2_May2_Ca1, CPK_May2_Ca1;
        public static double NUMERATOR_May2_Ca1, DENOMINATOR_May2_Ca1;

        public static double SUM_May2_Ca2, SUMSQUARES_May2_Ca2, SQUARESUMS_May2_Ca2;
        public static double AVE_May2_Ca2;
        public static double STD_May2_Ca2, CPK1_May2_Ca2, CPK2_May2_Ca2, CPK_May2_Ca2;
        public static double NUMERATOR_May2_Ca2, DENOMINATOR_May2_Ca2;
       
      
    
         /////////////////////////////////////////////////////////////////////////////////////////////
    

        public static SQLiteConnection Con;  //Khai báo đối tượng kết nối        
        
     
       // public static int checkopc = 1;



        public static void ConnectSQL()
        {

            Con = new SQLiteConnection();   

            Con.ConnectionString = ketnoisql.str;

            Con.Open();              

        }
       

        
        public static void DisconnectOPC() 
        {
           
               
                Con.Close();   	//Đóng kết nối
                Con.Dispose(); 	//Giải phóng tài nguyên
                Con = null;

                if (ConnectedOPCServer != null)
                {
                    try
                    {
                        ConnectedOPCServer.Disconnect();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("OPC server disconnect failed with exception: " + ex.Message, "SimpleOPCInterface Exception", MessageBoxButtons.OK);
                    }
                    finally
                    {
                        ConnectedOPCServer = null;
                    }

                }

        }
      
        public static void DisconnectSQL()
        {

            Con.Close();   	//Đóng kết nối
            Con.Dispose(); 	//Giải phóng tài nguyên
            Con = null;
           
        }
       
       
        
        //Lấy dữ liệu vào bảng

        public static DataTable GetDataToTable(string sql)
        {
            SQLiteDataAdapter dap = new SQLiteDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            dap.SelectCommand = new SQLiteCommand();
            dap.SelectCommand.Connection = Functions.Con; //Kết nối cơ sở dữ liệu
            dap.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }
        //Hàm kiểm tra khoá trùng


        public static DataTable GetDataTocombobox(string sql)
    {
        SQLiteDataAdapter dap = new SQLiteDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
        //Tạo đối tượng thuộc lớp SqlCommand
        dap.SelectCommand = new SQLiteCommand();
        dap.SelectCommand.Connection = Functions.Con; //Kết nối cơ sở dữ liệu
        dap.SelectCommand.CommandText = sql; //Lệnh SQL
      //  Khai báo đối tượng table thuộc lớp DataTable
        DataTable table = new DataTable();
        dap.Fill(table);
        return table;
    }



        public static DataTable FilterData_Date(string sql)
    {

        SQLiteDataAdapter dap = new SQLiteDataAdapter(sql, Con);
       // DataSet ds= new DataSet();
        DataTable table = new DataTable();
        dap.SelectCommand = new SQLiteCommand();
        dap.SelectCommand.Connection = Functions.Con; //Kết nối cơ sở dữ liệu
        dap.SelectCommand.CommandText = sql; //Lệnh SQL
        dap.Fill(table);
        return table;
        
    }
        public static DataTable FilterData_combobox(string sql)
    {

        SQLiteDataAdapter dap = new SQLiteDataAdapter(sql, Con);
       // SqlCommand cmd; 
        DataTable table = new DataTable();
      
        dap.Fill(table);
        return table;

    }


        public static bool CheckKey(string sql)
        {
            SQLiteDataAdapter dap = new SQLiteDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        //Hàm thực hiện câu lệnh SQL
        public static void RunSQL(string sql)
        {
            SQLiteCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SQLiteCommand();
            cmd.Connection = Con; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }

        public static void RunSqlDel(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = Functions.Con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Dữ liệu đang được dùng, không thể xoá...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
       

        
        
   
      

    }
}
