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
using System.Diagnostics;
using System.Data.SQLite;
using System.Data.SqlClient;
using PROJECT_LELONG_MODBUS_VB_PROFACE_REV1.Class;
using System.Security.Principal;
using OPCAutomation;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Management;
    
namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{

    
    //version 19/02/2022
    public partial class Form_home : Form
    {

        #region Element declaration
        resize_function_1 form_resize;
        string tendangnhap = "", matkhau = "", quyen = "";

        Task thread_export_EXCEL_May1, thread_export_EXCEL_May2;
        Microsoft.Office.Interop.Excel.Application oXL_May1;
        Workbook wb_May1;
        Worksheet ws_May1;
        Microsoft.Office.Interop.Excel.Application oXL_May2;
        Workbook wb_May2;
        Worksheet ws_May2;

        public string filepath;

        
     // test xem thay đổi những gì

        System.Data.DataTable tbl_baocaodulieu_May1_Ca1 = new System.Data.DataTable();
        System.Data.DataTable tbl_baocaodulieu_May1_Ca2 = new System.Data.DataTable();
        System.Data.DataTable tbl_baocaodulieu_May2_Ca1 = new System.Data.DataTable();

        System.Data.DataTable tbl_baocaodulieu_May2_Ca2 = new System.Data.DataTable();

       
        bool isDone_INPUT_May1_Ca1 = false;
        bool isDone_INPUT_May1_Ca2 = false;
        bool isDone_OUTPUT_May1_Ca1 = false;
        bool isDone_OUTPUT_May1_Ca2 = false;


        bool isDone_INPUT_May2_Ca1 = false;
        bool isDone_INPUT_May2_Ca2 = false;
        bool isDone_OUTPUT_May2_Ca1 = false;
        bool isDone_OUTPUT_May2_Ca2 = false;


     
        bool isDone_Baoloi = false;
        bool isDone_baocaoEXCEL_Ca1 = false;
        bool isDone_baocaoEXCEL_Ca2 = false;


        public string sender_mail, password_mail, to_mail, subject_mail, cc_mail, acid_chuyen_mail, telephone_sms, body_sms;

       
       
      
        
        #endregion

        #region PROServerEX CONNECT
        //==========================PROServerEX CONNECT=====================
        static int tagNumber = 109;      // Cài đặt số lượng tag của project
       
        static int PLCscantime = 50; 
        // Gọi các kết nối OPC
        public OPCAutomation.OPCServer AnOPCServer;
        public OPCAutomation.OPCServer OPCServer;
        public OPCAutomation.OPCGroups OPCGroup;
        public OPCAutomation.OPCGroup PLC;
        public string Groupname;

        static int arrlength = tagNumber + 1;
        Array OPtags = Pro_ServerEX.tagread(arrlength);
        Array tagID = Pro_ServerEX.tagID(arrlength);
        Array WriteItems = Array.CreateInstance(typeof(object), arrlength);
        Array tagHandles = Array.CreateInstance(typeof(Int32), arrlength);
        Array OPCError = Array.CreateInstance(typeof(Int32), arrlength);
        Array dataType = Array.CreateInstance(typeof(Int16), arrlength);
        Array AccessPaths = Array.CreateInstance(typeof(string), arrlength);

        Array arrcheck = Array.CreateInstance(typeof(object), arrlength);
       
        
  
        private void PROServerEX_Connect()
        {
            string IOServer = "Pro-face.OPCEx.1";
            string IOGroup = "OPCGroup1";
            OPCServer = new OPCAutomation.OPCServer();
            OPCServer.Connect(IOServer, "");
            PLC = OPCServer.OPCGroups.Add(IOGroup);
            PLC.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(dataScan);
         
        
            PLC.UpdateRate = PLCscantime;
            PLC.IsSubscribed = PLC.IsActive;
            PLC.OPCItems.DefaultIsActive = true;
            PLC.OPCItems.AddItems(tagNumber, ref OPtags, ref tagID,
                out tagHandles, out OPCError, dataType, AccessPaths);
        }
        #endregion

        #region OPC Server Element Scan Loop
        private void dataScan(int ID, int NumItems, ref Array tagID,
            ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
          
            for (int i = 1; i <= NumItems; i++)
            {
                // Khai báo biến chung
                int getTagID = Convert.ToInt32(tagID.GetValue(i));
                string tagValue = ItemValues.GetValue(i).ToString();
               
         

                 if (getTagID == 1)
                 {
                     Functions.BitAdd_INPUT_May1 = Convert.ToInt16(tagValue);
                 }
                 if (getTagID == 2)
                 {
                     Functions.BitAdd_OUTPUT_May1 = Convert.ToInt16(tagValue);
                 }
                 if (getTagID == 3)
                 {
                     Functions.BitAdd_INPUT_May2 = Convert.ToInt16(tagValue);
                 }
                 if (getTagID == 4)
                 {
                     Functions.BitAdd_OUTPUT_May2 = Convert.ToInt16(tagValue);
                 }


                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                
                if (getTagID == 11)
                {
                  
                        Functions.TL_Axit_May1_opc = Convert.ToDouble(tagValue);
                  
                }
                 if (getTagID == 12)
                 {
                   
                        Functions.TL_o1_May1_opc = Convert.ToDouble(tagValue);
                  
               
                 }
                 if (getTagID == 13)
                 {
                 
                        Functions.TL_o2_May1_opc = Convert.ToDouble(tagValue);
                    
                    
                 }
                 if (getTagID == 14)
                 {
                    
                        Functions.TL_o3_May1_opc = Convert.ToDouble(tagValue);
                    
                    
                 }
                 if (getTagID == 15)
                 {
                   
                        Functions.TL_o4_May1_opc = Convert.ToDouble(tagValue);
                    
                    
                 }
                 if (getTagID == 16)
                 {
                   
                    
                        Functions.TL_o5_May1_opc = Convert.ToDouble(tagValue);
                   
                    
                 }
                 if (getTagID == 17)
                 {
                
                        Functions.TL_o6_May1_opc = Convert.ToDouble(tagValue);
                   
                   
                 }
                 if (getTagID == 18)
                 {
                  
                        Functions.TL_o7_May1_opc = Convert.ToDouble(tagValue);
                    
                   
                 }
                 if (getTagID == 19)
                 {
            
                        Functions.TL_o8_May1_opc = Convert.ToDouble(tagValue);
                    
                   
                 }
                 if (getTagID == 20)
                 {
                        Functions.TL_o9_May1_opc = Convert.ToDouble(tagValue);
                    
              
                 }
                 if (getTagID == 21)
                 {
                  
                        Functions.TL_o10_May1_opc = Convert.ToDouble(tagValue);
                    
                    
                 }

                 
                 if (getTagID == 22)
                 {
                  
                        Functions.TL_Axit_May2_opc = Convert.ToDouble(tagValue);
                    
                  

                 }
                
                 if (getTagID == 23)
                 {
                   
                        Functions.TL_o1_May2_opc = Convert.ToDouble(tagValue);
                    
                
                 }
                 if (getTagID == 24)
                 {
                    
                        Functions.TL_o2_May2_opc = Convert.ToDouble(tagValue);
                    

                  
                 }
                 if (getTagID == 25)
                 {
                  
                        Functions.TL_o3_May2_opc = Convert.ToDouble(tagValue);
                    
                    
                 }
                 if (getTagID == 26)
                 {
                  
                        Functions.TL_o4_May2_opc = Convert.ToDouble(tagValue);
                    
                
                 }
                 if (getTagID == 27)
                 {
                  
                   
                        Functions.TL_o5_May2_opc = Convert.ToDouble(tagValue);
                    
                
                 }
                 if (getTagID == 28)
                 {
                    
                        Functions.TL_o6_May2_opc = Convert.ToDouble(tagValue);
                    
               
                 }
                 if (getTagID == 29)
                 {
                   
                        Functions.TL_o7_May2_opc = Convert.ToDouble(tagValue);
                    
                  
                 }
                 if (getTagID == 30)
                 {
                 
                        Functions.TL_o8_May2_opc = Convert.ToDouble(tagValue);
                    
                 
                 }
                 if (getTagID == 31)
                 {
                   
                        Functions.TL_o9_May2_opc = Convert.ToDouble(tagValue);
                    
                  
                 }
                 if (getTagID == 32)
                 {
                    
                        Functions.TL_o10_May2_opc = Convert.ToDouble(tagValue);
                    
                   
                 }
                 

                 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

                 if (getTagID == 33)
                 {
                     Functions.BitAdd_Baoloi = Convert.ToInt16(tagValue);
                 }

                 if (getTagID == 34)
                 {
                     Functions.BitAdd_baoexcel_Ca1 = Convert.ToInt16(tagValue);
                 }

                 if (getTagID == 35)
                 {
                     Functions.BitAdd_baoexcel_Ca2 = Convert.ToInt16(tagValue);
                 }

                 if (getTagID == 36)
                 {
                    
                        Functions.TLB_Dau_May1_opc = Convert.ToDouble(tagValue);
                    
                 }
                 if (getTagID == 37)
                 {
                  
                        Functions.TLB_Sau_May1_opc = Convert.ToDouble(tagValue);
                    
                 }


                 if (getTagID == 38)
                 {
                     Functions.SL_Phanloaivao_May1 = Convert.ToDouble(tagValue);


                 }
                 if (getTagID == 39)
                 {
                     Functions.SL_Phanloaira_May1 = Convert.ToDouble(tagValue);


                 }
                 if (getTagID == 40)
                 {
                     Functions.TT_PLVao_May1 = Convert.ToInt16(tagValue);

                 }
                 if (getTagID == 41)
                 {
                     Functions.TT_PLRa_May1 = Convert.ToInt16(tagValue);

                 }

                 if (getTagID == 42)
                 {
                    
                        Functions.TLB_Dau_May2_opc = Convert.ToDouble(tagValue);
                    
                  
                 }
                 if (getTagID == 43)
                 {
                        Functions.TLB_Sau_May2_opc = Convert.ToDouble(tagValue);
                    
                 }

                 if (getTagID == 44)
                 {
                     Functions.SL_Phanloaivao_May2 = Convert.ToDouble(tagValue);
                 }
                 if (getTagID == 45)
                 {
                     Functions.SL_Phanloaira_May2 = Convert.ToDouble(tagValue);

                 }
                 if (getTagID == 46)
                 {
                     Functions.TT_PLVao_May2 = Convert.ToInt16(tagValue);


                 }
                 if (getTagID == 47)
                 {
                     Functions.TT_PLRa_May2 = Convert.ToInt16(tagValue);
                 }
                 

                 if (getTagID == 48)
                 {
                     Functions.SoCa = tagValue;
                 }


                 if (getTagID == 49)
                 {
                     Functions.Ca1_spdacan = Convert.ToDouble(tagValue);

                 }
                 if (getTagID == 50)
                 {
                     Functions.Ca1_spdat = Convert.ToDouble(tagValue);

                 }


                 if (getTagID == 51)
                 {
                     Functions.Ca1_spthap = Convert.ToDouble(tagValue);

                 }

                 if (getTagID == 52)
                 {

                     Functions.Ca1_spcao = Convert.ToDouble(tagValue);
                 }


                 if (getTagID == 53)
                 {
                     Functions.Ca2_spdacan = Convert.ToDouble(tagValue);

                 }

                 if (getTagID == 54)
                 {
                     Functions.Ca2_spdat = Convert.ToDouble(tagValue);
                 }
                 if (getTagID == 55)
                 {
                     Functions.Ca2_spthap = Convert.ToDouble(tagValue);

                 }
                 if (getTagID == 56)
                 {
                     Functions.Ca2_spcao = Convert.ToDouble(tagValue);

                 }

                 if (getTagID == 57)
                 {
                     Functions.int_ngay = Convert.ToInt16(tagValue);
                 }
                 if (getTagID == 58)
                 {
                     Functions.int_thang = Convert.ToInt16(tagValue);
                 }
                 if (getTagID == 59)
                 {
                     Functions.int_nam = Convert.ToInt16(tagValue);
                 }
                 if (getTagID == 60)
                 {
                     Functions.int_gio = Convert.ToInt16(tagValue);
                 }
                 if (getTagID == 61)
                 {
                     Functions.int_phut = Convert.ToInt16(tagValue);
                 }
                 if (getTagID == 62)
                 {
                     Functions.int_giay = Convert.ToInt16(tagValue);
                 }

                 if (getTagID == 63)
                 {
                     Functions.MSLH = tagValue;

                 }

                 if (getTagID == 64)
                 {
                     Functions.quy_cach = tagValue;

                 }
                 if (getTagID == 65)
                 {
                     Functions.nguoi_tt = tagValue;

                 }




                 if (getTagID == 66)
                 {
                    
                      
                        Functions.TLBinh_ChuaCoAxit_opc = Convert.ToDouble(tagValue);
                    
                 }
                 if (getTagID == 67)
                 {
                  
                        Functions.TL_Axit_TC_opc = Convert.ToDouble(tagValue);
                    
                    
                 }
                 if (getTagID == 68)
                 {
                  
                        Functions.DSD_Binhvao_opc = Convert.ToDouble(tagValue);
                    
             

                 }
                 if (getTagID == 69)
                 {
                  
                        Functions.DST_Binhvao_opc = Convert.ToDouble(tagValue);
                    
                

                 }
                 if (getTagID == 70)
                 {
                    
                        Functions.DSH_Binhvao_opc = Convert.ToDouble(tagValue);
                    
                  

                 }
                 if (getTagID == 71)
                 {
                
                        Functions.DSL_Binhvao_opc = Convert.ToDouble(tagValue);
                    
                    
                 }
                 if (getTagID == 72)
                 {
               
                        Functions.DSD_Binhra_opc = Convert.ToDouble(tagValue);
                    
                 }
                 if (getTagID == 73)
                 {
                 
                        Functions.DST_Binhra_opc = Convert.ToDouble(tagValue);
                    
                 }
                 if (getTagID == 74)
                 {
               
                        Functions.DSH_Binhra_opc = Convert.ToDouble(tagValue);
                    
                    
                 }
                 if (getTagID == 75)
                 {
                    
                        Functions.DSL_Binhra_opc = Convert.ToDouble(tagValue);
                   
                    
                 }



                ///////////////////////////////////////////////////////////////////////////////////////////////////////
                /*
                                 if (getTagID == 76)   // TEST TONG BINH CAN VAO MAY 1 CA 1
                                 {


                                     Functions.TongBinh_INPUT_May1_Ca1 = Convert.ToDouble(tagValue);


                                 }

                                 if (getTagID == 77)    // TEST TONG BINH CAN VAO MAY 1 CA 2
                                 {
                                     Functions.TongBinh_INPUT_May1_Ca2 = Convert.ToDouble(tagValue);


                                 }
                                 if (getTagID == 78)    // TEST TONG BINH CAN RA MAY 1 CA 1
                                 {
                                     Functions.TongBinh_OUTPUT_May1_Ca1 = Convert.ToDouble(tagValue);



                                 }
                                 if (getTagID == 79)    // TEST TONG BINH CAN RA MAY 1 CA 2
                                 {
                                     Functions.TongBinh_OUTPUT_May1_Ca2 = Convert.ToDouble(tagValue);

                                 }


                                 if (getTagID == 80)   // TEST TONG BINH CAN VAO MAY 2 CA 1
                                 {
                                     Functions.TongBinh_INPUT_May2_Ca1 = Convert.ToDouble(tagValue);

                                 }

                                 if (getTagID == 81)    // TEST TONG BINH CAN VAO MAY 2 CA 2
                                 {
                                     Functions.TongBinh_INPUT_May2_Ca2 = Convert.ToDouble(tagValue);

                                 }
                                 if (getTagID == 82)    // TEST TONG BINH CAN RA MAY 2 CA 1
                                 {
                                     Functions.TongBinh_OUTPUT_May2_Ca1 = Convert.ToDouble(tagValue);

                                 }
                                 if (getTagID == 83)    // TEST TONG BINH CAN RA MAY 2 CA 2
                                 {
                                     Functions.TongBinh_OUTPUT_May2_Ca2 = Convert.ToDouble(tagValue);

                                 }


                                 ///////////////////////////////////////////////////////////////////////////////

                                 if (getTagID == 84)   // TEST GT CAN VAO MAY 1
                                 {
                                  
                                        Functions.GT_CanVao_May1_opc = Convert.ToDouble(tagValue);
                                    

                                 }

                                 if (getTagID == 85)   // TEST GT CAN RA MAY 1
                                 {
                                 
                                        Functions.TL_Axit_May1_opc = Convert.ToDouble(tagValue);
                                    
                                 }
                                 if (getTagID == 86)    // TEST GT CAN VAO MAY 2
                                 {
                                
                                        Functions.GT_CanVao_May2_opc = Convert.ToDouble(tagValue);
                                    
                                     

                                 }
                                 if (getTagID == 87)    // TEST GT CAN RA MAY 2
                                 {
                                 
                                        Functions.TL_Axit_May2_opc = Convert.ToDouble(tagValue);
                                    
                                 
                                 }
                                 */
                                
                //////////////////////////////////////////////////////////////////////////////////////////
                /*
                                 if (getTagID == 5)
                                 {

                                     Functions.TongBinh_INPUT_May1 = Convert.ToDouble(tagValue);

                                 }
                                 if (getTagID == 8)
                                 {
                                     Functions.TongBinh_INPUT_May2 = Convert.ToDouble(tagValue);

                                 }
                                */
                /////////////////////////////////////////////////////////


                
                if (getTagID == 6)
                 {
                     Functions.TongBinh_OUTPUT_May1_Ca1 = Convert.ToDouble(tagValue);

                 }
                 if (getTagID == 7)
                 {
                     Functions.TongBinh_OUTPUT_May1_Ca2 = Convert.ToDouble(tagValue);

                 }

                 if (getTagID == 9)
                 {
                     Functions.TongBinh_OUTPUT_May2_Ca1 = Convert.ToDouble(tagValue);

                 }
                 if (getTagID == 10)
                 {
                     Functions.TongBinh_OUTPUT_May2_Ca2 = Convert.ToDouble(tagValue);

                 }


                 //////////////////////////////////////////////////////

                 if (getTagID == 88)
                 {
                     Functions.TongBinh_INPUT_May1_Ca1 = Convert.ToDouble(tagValue) ;
                


                 }

                 if (getTagID == 89)
                 {
                     Functions.TongBinh_INPUT_May1_Ca2 = Convert.ToDouble(tagValue);
             

                 }

                 if (getTagID == 90)
                 {
                     Functions.TongBinh_INPUT_May2_Ca1 = Convert.ToDouble(tagValue);


                 }

                 if (getTagID == 91)
                 {
                     Functions.TongBinh_INPUT_May2_Ca2 = Convert.ToDouble(tagValue);


                 }
                 


                 /////////////////////////////////////////////////////////////////////////////////////////////

                 if (getTagID == 92)
                 {
                     Functions.BitAdd_Ca1 = Convert.ToInt16(tagValue);


                 }

                 if (getTagID == 93)
                 {
                     Functions.BitAdd_Ca2 = Convert.ToInt16(tagValue);


                 }
                 if (getTagID == 94)
                 {
                     Functions.BitAdd_xoa_cpk1 = Convert.ToInt16(tagValue);


                 }

                 if (getTagID == 95)
                 {
                     Functions.BitAdd_xoa_cpk2 = Convert.ToInt16(tagValue);


                 }


                /////////////////////////////////////////////////////////////////////////////////////////////////////


                 if (getTagID == 96)
                 {
                   
                        Functions.Binhloi_o1_May1_opc = Convert.ToDouble(tagValue);
                    
               


                 }
                 if (getTagID == 97)
                 {
                  
                        Functions.Binhloi_o2_May1_opc = Convert.ToDouble(tagValue);
                    
           


                 }
                 if (getTagID == 98)
                 {
                 
                        Functions.Binhloi_o3_May1_opc = Convert.ToDouble(tagValue);
                    
                 }
                 if (getTagID == 99)
                 {
                  
                        Functions.Binhloi_o4_May1_opc = Convert.ToDouble(tagValue);
                    

                 }
                 if (getTagID == 100)
                 {
               
                        Functions.Binhloi_o5_May1_opc = Convert.ToDouble(tagValue);
                    
                 }
                 if (getTagID == 101)
                 {
                   
                        Functions.Binhloi_o1_May2_opc = Convert.ToDouble(tagValue);
                    
                 }
                 if (getTagID == 102)
                 {
                    
                        Functions.Binhloi_o2_May2_opc = Convert.ToDouble(tagValue);
                    
                 }
                 if (getTagID == 103)
                 {
                    
                        Functions.Binhloi_o3_May2_opc = Convert.ToDouble(tagValue);
                    
                 }
                 if (getTagID == 104)
                 {
                   
                        Functions.Binhloi_o4_May2_opc = Convert.ToDouble(tagValue);
                    
                 }
                 if (getTagID == 105)
                 {
                    
                        Functions.Binhloi_o5_May2_opc = Convert.ToDouble(tagValue);
                    
                  

                 }
                 if (getTagID == 106)
                 {

                     Functions.TongBinhLoi_May1 = (Convert.ToInt16(tagValue));


                 }
                 if (getTagID == 107)
                 {
                     Functions.TongBinhLoi_May2 = (Convert.ToInt16(tagValue));


                 }
                 if (getTagID == 108)
                 {
                     Functions.TongBinhLoi_2May = (Convert.ToInt16(tagValue));


                 }
                 if (getTagID == 109)
                {
                    Functions.Bit_Thapphan = (Convert.ToInt16(tagValue));
                }
              

             }
            }
        #endregion


        private void change_decimal()    // change decimal between no decimal point  ->  1  decimal point
        {

            if (Functions.Bit_Thapphan == 1)
            {
                Functions.TL_Axit_May1 = Functions.TL_Axit_May1_opc / 10;

                Functions.TL_o1_May1 = Functions.TL_o1_May1_opc / 10;
                Functions.TL_o2_May1 = Functions.TL_o2_May1_opc / 10;
                Functions.TL_o3_May1 = Functions.TL_o3_May1_opc / 10;
                Functions.TL_o4_May1 = Functions.TL_o4_May1_opc / 10;
                Functions.TL_o5_May1 = Functions.TL_o5_May1_opc / 10;
                Functions.TL_o6_May1 = Functions.TL_o6_May1_opc / 10;
                Functions.TL_o7_May1 = Functions.TL_o7_May1_opc / 10;
                Functions.TL_o8_May1 = Functions.TL_o8_May1_opc / 10;
                Functions.TL_o9_May1 = Functions.TL_o9_May1_opc / 10;
                Functions.TL_o10_May1 = Functions.TL_o10_May1_opc / 10;

                Functions.TL_Axit_May2 = Functions.TL_Axit_May2_opc / 10;

                Functions.TL_o1_May2 = Functions.TL_o1_May2_opc / 10;
                Functions.TL_o2_May2 = Functions.TL_o2_May2_opc / 10;
                Functions.TL_o3_May2 = Functions.TL_o3_May2_opc / 10;
                Functions.TL_o4_May2 = Functions.TL_o4_May2_opc / 10;
                Functions.TL_o5_May2 = Functions.TL_o5_May2_opc / 10;
                Functions.TL_o6_May2 = Functions.TL_o6_May2_opc / 10;
                Functions.TL_o7_May2 = Functions.TL_o7_May2_opc / 10;
                Functions.TL_o8_May2 = Functions.TL_o8_May2_opc / 10;
                Functions.TL_o9_May2 = Functions.TL_o9_May2_opc / 10;
                Functions.TL_o10_May2 = Functions.TL_o10_May2_opc / 10;

                Functions.TLB_Dau_May1 = Functions.TLB_Dau_May1_opc / 10;
                Functions.TLB_Sau_May1 = Functions.TLB_Sau_May1_opc / 10;

                Functions.TLB_Dau_May2 = Functions.TLB_Dau_May2_opc / 10;
                Functions.TLB_Sau_May2 = Functions.TLB_Sau_May2_opc / 10;

                Functions.TLBinh_ChuaCoAxit = Functions.TLBinh_ChuaCoAxit_opc /10;  //,
                Functions.TL_Axit_TC = Functions.TL_Axit_TC_opc / 10;

                Functions.DSD_Binhvao = Functions.DSD_Binhvao_opc / 10;
                Functions.DST_Binhvao = Functions.DST_Binhvao_opc / 10;
                Functions.DSH_Binhvao = Functions.DSH_Binhvao_opc / 10;
                Functions.DSL_Binhvao = Functions.DSL_Binhvao_opc / 10;

                Functions.DSD_Binhra = Functions.DSD_Binhra_opc / 10;
                Functions.DST_Binhra = Functions.DST_Binhra_opc / 10;
                Functions.DSH_Binhra = Functions.DSH_Binhra_opc / 10;
                Functions.DSL_Binhra = Functions.DSL_Binhra_opc / 10;

                Functions.Binhloi_o1_May1 = Functions.Binhloi_o1_May1_opc / 10;
                Functions.Binhloi_o2_May1 = Functions.Binhloi_o2_May1_opc / 10;
                Functions.Binhloi_o3_May1 = Functions.Binhloi_o3_May1_opc / 10;
                Functions.Binhloi_o4_May1 = Functions.Binhloi_o4_May1_opc / 10;
                Functions.Binhloi_o5_May1 = Functions.Binhloi_o5_May1_opc / 10;

                Functions.Binhloi_o1_May2 = Functions.Binhloi_o1_May2_opc / 10;
                Functions.Binhloi_o2_May2 = Functions.Binhloi_o2_May2_opc / 10;
                Functions.Binhloi_o3_May2 = Functions.Binhloi_o3_May2_opc / 10;
                Functions.Binhloi_o4_May2 = Functions.Binhloi_o4_May2_opc / 10;
                Functions.Binhloi_o5_May2 = Functions.Binhloi_o5_May2_opc / 10;

                Functions.GT_CanVao_May1 = Functions.GT_CanVao_May1_opc / 10;
                Functions.GT_CanVao_May2 = Functions.GT_CanVao_May2_opc / 10;
            }
            else if (Functions.Bit_Thapphan == 0)
            {
                Functions.TL_Axit_May1 = Functions.TL_Axit_May1_opc;
                
                Functions.TL_o1_May1 = Functions.TL_o1_May1_opc ;
                Functions.TL_o2_May1 = Functions.TL_o2_May1_opc ;
                Functions.TL_o3_May1 = Functions.TL_o3_May1_opc ;
                Functions.TL_o4_May1 = Functions.TL_o4_May1_opc ;
                Functions.TL_o5_May1 = Functions.TL_o5_May1_opc ;
                Functions.TL_o6_May1 = Functions.TL_o6_May1_opc ;
                Functions.TL_o7_May1 = Functions.TL_o7_May1_opc ;
                Functions.TL_o8_May1 = Functions.TL_o8_May1_opc ;
                Functions.TL_o9_May1 = Functions.TL_o9_May1_opc ;
                Functions.TL_o10_May1 = Functions.TL_o10_May1_opc ;

                Functions.TL_Axit_May2 = Functions.TL_Axit_May2_opc ;

                Functions.TL_o1_May2 = Functions.TL_o1_May2_opc ;
                Functions.TL_o2_May2 = Functions.TL_o2_May2_opc ;
                Functions.TL_o3_May2 = Functions.TL_o3_May2_opc ;
                Functions.TL_o4_May2 = Functions.TL_o4_May2_opc ;
                Functions.TL_o5_May2 = Functions.TL_o5_May2_opc ;
                Functions.TL_o6_May2 = Functions.TL_o6_May2_opc ;
                Functions.TL_o7_May2 = Functions.TL_o7_May2_opc ;
                Functions.TL_o8_May2 = Functions.TL_o8_May2_opc ;
                Functions.TL_o9_May2 = Functions.TL_o9_May2_opc ;
                Functions.TL_o10_May2 = Functions.TL_o10_May2_opc ;

                Functions.TLB_Dau_May1 = Functions.TLB_Dau_May1_opc ;
                Functions.TLB_Sau_May1 = Functions.TLB_Sau_May1_opc ;

                Functions.TLB_Dau_May2 = Functions.TLB_Dau_May2_opc ;
                Functions.TLB_Sau_May2 = Functions.TLB_Sau_May2_opc ;

                Functions.TLBinh_ChuaCoAxit = Functions.TLBinh_ChuaCoAxit_opc;
                Functions.TL_Axit_TC = Functions.TL_Axit_TC_opc ;

                Functions.DSD_Binhvao = Functions.DSD_Binhvao_opc ;
                Functions.DST_Binhvao = Functions.DST_Binhvao_opc ;
                Functions.DSH_Binhvao = Functions.DSH_Binhvao_opc ;
                Functions.DSL_Binhvao = Functions.DSL_Binhvao_opc ;

                Functions.DSD_Binhra = Functions.DSD_Binhra_opc ;
                Functions.DST_Binhra = Functions.DST_Binhra_opc ;
                Functions.DSH_Binhra = Functions.DSH_Binhra_opc ;
                Functions.DSL_Binhra = Functions.DSL_Binhra_opc ;

                Functions.Binhloi_o1_May1 = Functions.Binhloi_o1_May1_opc ;
                Functions.Binhloi_o2_May1 = Functions.Binhloi_o2_May1_opc ;
                Functions.Binhloi_o3_May1 = Functions.Binhloi_o3_May1_opc ;
                Functions.Binhloi_o4_May1 = Functions.Binhloi_o4_May1_opc ;
                Functions.Binhloi_o5_May1 = Functions.Binhloi_o5_May1_opc ;

                Functions.Binhloi_o1_May2 = Functions.Binhloi_o1_May2_opc ;
                Functions.Binhloi_o2_May2 = Functions.Binhloi_o2_May2_opc ;
                Functions.Binhloi_o3_May2 = Functions.Binhloi_o3_May2_opc ;
                Functions.Binhloi_o4_May2 = Functions.Binhloi_o4_May2_opc ;
                Functions.Binhloi_o5_May2 = Functions.Binhloi_o5_May2_opc ;

                Functions.GT_CanVao_May1 = Functions.GT_CanVao_May1_opc;
                Functions.GT_CanVao_May2 = Functions.GT_CanVao_May2_opc;

            }



        }
        
        public Form_home(string tendangnhap,string matkhau, string quyen)   
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
            this.matkhau = matkhau;
            this.quyen = quyen;
            form_resize = new resize_function_1(this);
        
            this.Load += Load_Inititial_Size_fucntion;
            this.Resize += Resize_function;
          
        }

        private void Load_Inititial_Size_fucntion(object sender, EventArgs e)  // Get initial size function 
        {
           form_resize._get_initial_size();
    
        }
        private void Resize_function(object sender, EventArgs e)               // Resize form size after getting initial size form
        {
            form_resize._resize();
       
        }
       
   
        private void btn_manhinhmay_Click(object sender, EventArgs e)     
        {
            man_hinh_may_1 F= new man_hinh_may_1();
            F.Show();
           
        
        }   

        private void btn_baocaobangdulieu_Click(object sender, EventArgs e)
        {
            baocaobangdulieu F = new baocaobangdulieu();
            F.Show();
            //test kết nối
        }  

        private void btn_baocaoexcel_Click(object sender, EventArgs e)  
        {
        
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));
            string filepath = read.ReadToEnd();

            prc.StartInfo.FileName = Path.GetFullPath(filepath);
            if (Directory.Exists(filepath))
            {
                prc.Start();
                read.Close();
            }
            else
            {
                prc.Close();
                read.Close();

                if (MessageBox.Show(Functions.excel_text_cul, Functions.info_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frm_EXCEL_Path F = new frm_EXCEL_Path();
                    F.Show();
                }
            }
        }   
        
        private void HOME_Load(object sender, EventArgs e) 
        {
            
          //PROServerEX_Connect();
          btn_manhinhmay.Enabled = false;
          Thread.Sleep(1500);
          btn_manhinhmay.Enabled = true;
          

            if (Functions.excel_text_cul == null)
            {
                VI_ToolStripMenuItem.Checked = true;

                EN_ToolStripMenuItem.Checked = false;
            }
            else if (Functions.VI_cul == true)
            {
                VI_ToolStripMenuItem.Checked = true;

                EN_ToolStripMenuItem.Checked = false;

            }
            else if (Functions.EN_cul == true)
            {
                VI_ToolStripMenuItem.Checked = false;

                EN_ToolStripMenuItem.Checked = true;

            }
            
            switch_language();


                    Functions.z1_Ca1 = 1;
                    Functions.z2_Ca1 = 1;
                    Functions.z1_Ca2 = 1;
                    Functions.z2_Ca2 = 1;

                    Functions.CDTT_May1 = new double[999999];
                    Functions.CDTT_May2 = new double[999999];
        
                    Functions.SUM_May1_Ca1 =0; Functions.SUMSQUARES_May1_Ca1 = 0.00; Functions.SQUARESUMS_May1_Ca1 = 0.00;
                    Functions.AVE_May1_Ca1 = 0.00;
                    Functions.STD_May1_Ca1 = 0.00;  Functions.CPK1_May1_Ca1 =0.00;  Functions.CPK2_May1_Ca1 =0.00 ;  Functions.CPK_May1_Ca1 =0.00;
                    Functions.NUMERATOR_May1_Ca1 = 0.00;  Functions.DENOMINATOR_May1_Ca1=0.00;

                    Functions.SUM_May1_Ca2 = 0; Functions.SUMSQUARES_May1_Ca2 = 0.00; Functions.SQUARESUMS_May1_Ca2 = 0.00;
                    Functions.AVE_May1_Ca2 = 0.00;
                    Functions.STD_May1_Ca2 = 0.00; Functions.CPK1_May1_Ca2 = 0.00; Functions.CPK2_May1_Ca2 = 0.00; Functions.CPK_May1_Ca2 = 0.00;
                    Functions.NUMERATOR_May1_Ca2 = 0.00; Functions.DENOMINATOR_May1_Ca2 = 0.00;

                    Functions.SUM_May2_Ca1 = 0;  Functions.SUMSQUARES_May2_Ca1 = 0.00;  Functions.SQUARESUMS_May2_Ca1=0.00;
                    Functions.AVE_May2_Ca1 = 0.00;
                    Functions.STD_May2_Ca1 =0.00 ;  Functions.CPK1_May2_Ca1 =0.00 ;  Functions.CPK2_May2_Ca1 = 0.00;  Functions.CPK_May2_Ca1 = 0.00;
                    Functions.NUMERATOR_May2_Ca1 = 0.00; Functions.DENOMINATOR_May2_Ca1 = 0.00;

                    Functions.SUM_May2_Ca2 = 0; Functions.SUMSQUARES_May2_Ca2 = 0.00; Functions.SQUARESUMS_May2_Ca2 = 0.00;
                    Functions.AVE_May2_Ca2 = 0.00;
                    Functions.STD_May2_Ca2 = 0.00; Functions.CPK1_May2_Ca2 = 0.00; Functions.CPK2_May2_Ca2 = 0.00; Functions.CPK_May2_Ca2 = 0.00;
                    Functions.NUMERATOR_May2_Ca2 = 0.00; Functions.DENOMINATOR_May2_Ca2 = 0.00;

            try
            {
             
                    Functions.ConnectSQL();
                    if (quyen == "level 1")
                    {
                       
                       
                    }
                    else if (quyen == "level 2")
                    {

                        btn_mail_config.Enabled = false;
                        btn_change_pass.Enabled = false;
                    }
                    else if (quyen == "level 3")
                    {

                        btn_mail_config.Enabled = false;
                        btn_config_excel.Enabled = false;
                        btn_change_pass.Enabled = false;
                       
                   

                    }
                    timer_vavle.Start();
                  
                    timer_export_excel.Start();
                    timer_checkcalamviec.Start();
                    timer_baoloi.Start();
            

                   
            }

            catch (Exception ex)
            {
                Functions.DisconnectOPC();
                Functions.DisconnectSQL();
                timer_vavle.Stop();
                timer_baoloi.Stop();
           
                timer_export_excel.Stop();
              
                timer_checkcalamviec.Stop();
            }
          
        }

        private void switch_language() // CHANGE LANGUAGE  
        {
            if (VI_ToolStripMenuItem.Checked == true)    //in vietnamese
            {
                Functions.VI_cul = true;
                Functions.EN_cul = false;
                pictureBox2.Visible = true;
                pictureBox5.Visible = false;

                btn_manhinhmay.Text = "Màn hình máy";
                btn_baocaoexcel.Text = "Thư mục EXCEL";
                btn_baocaobangdulieu.Text = "Báo cáo bảng dữ liệu";
                btn_baocaodothi.Text = "Báo cáo đồ thị";
                btn_change_pass.Text = "Đổi mật khẩu";
                btn_config_excel.Text = "Cấu hình lưu trữ";
                btn_mail_config.Text = "Thông tin Mail";
                Language_Item.Text = "Ngôn Ngữ";
                VI_ToolStripMenuItem.Text = "Tiếng Việt";
                EN_ToolStripMenuItem.Text = "Tiếng Anh";
                logout_toolStripMenuItem.Text = "Đăng xuất";
                exit_ToolStripMenuItem.Text = "Thoát";
                this.Text = "Hệ thống cân lưu trọng lượng bình LELONG";
                Functions.exit_text_cul = "Bạn có muốn thoát chương trình không ?";
                Functions.exit_caption_cul = "Thoát hay không ?";
                Functions.excel_text_cul = "Không tìm được đường dẫn kết nối. Kiểm tra lại cấu hình đường dẫn lưu EXCEL ?";
                Functions.info_caption_cul = "Thông Báo";
            }
            else if (EN_ToolStripMenuItem.Checked == true)          //in english
            {
                Functions.VI_cul = false;
                Functions.EN_cul = true;
                pictureBox2.Visible = false;
                pictureBox5.Visible = true;

                btn_manhinhmay.Text = "Monitor screen";
                btn_baocaoexcel.Text = "EXCEL Folder";
                btn_baocaobangdulieu.Text = "Report datagridview";
                btn_baocaodothi.Text = "Report chart";
                btn_change_pass.Text = "Change password";
                btn_config_excel.Text = "Setting save path";
                btn_mail_config.Text = "Mail information";
                Language_Item.Text = "Language";
                VI_ToolStripMenuItem.Text = "Vietnammese";
                EN_ToolStripMenuItem.Text = "English";
                logout_toolStripMenuItem.Text = "Log outt";
                exit_ToolStripMenuItem.Text = "Exit";
                this.Text = "Acid weighing system LELONG";
                Functions.exit_text_cul = "Do you want to exit program ? ?";
                Functions.exit_caption_cul = "Exit : YES or NO ?";
                Functions.excel_text_cul = "No path connection found. Recheck the store EXCEL configuration ?";
                Functions.info_caption_cul = "Notification";
            }

         
            
        }

        
        private void btn_baocaodothi_Click(object sender, EventArgs e)
        {
            baocaodothi F = new baocaodothi();
            F.Show();
        
        }       // BUTTON REPORT CHART 
        
        private void btn_config_excel_Click(object sender, EventArgs e)
        {
            frm_EXCEL_Path F = new frm_EXCEL_Path();
            F.Show();
        }      // BUTTON COFIG SAVE EXCEL DIRECTORY

        private void btn_change_pass_Click(object sender, EventArgs e)          // BUTTON CHANGE PASSWORD 
        {
            frm_user_define F = new frm_user_define();
            F.Show();
        }
        
        private void btn_send_mail_Click(object sender, EventArgs e)            // BUTTON SEND MAIL
        {
               frm_mail_SMS F = new frm_mail_SMS();
               F.Show();
        }

       
        private void timer_vavle_Tick(object sender, EventArgs e)               // TIMER DATA CHANGE SCAN 
        {
            int zero = 0;
            int num = 20;

            change_decimal();
         
            if (Functions.SL_Phanloaivao_May1 == 1)
            {
                Functions.GT_CanVao_May1 = Functions.TL_o1_May1;
            }
            else if (Functions.SL_Phanloaivao_May1 == 2)
            {
                Functions.GT_CanVao_May1 = Functions.TL_o2_May1;
            }
            else if(Functions.SL_Phanloaivao_May1 == 3)
            {
                Functions.GT_CanVao_May1 = Functions.TL_o3_May1;
            }
            else if (Functions.SL_Phanloaivao_May1 == 4)
            {
                Functions.GT_CanVao_May1 = Functions.TL_o4_May1;
            }
            else if (Functions.SL_Phanloaivao_May1 == 5)
            {
                Functions.GT_CanVao_May1 = Functions.TL_o5_May1;
            }
            else if (Functions.SL_Phanloaivao_May1 == 6)
            {
                Functions.GT_CanVao_May1 = Functions.TL_o6_May1;
            }
            else if (Functions.SL_Phanloaivao_May1 == 7)
            {
                Functions.GT_CanVao_May1 = Functions.TL_o7_May1;
            }
            else if (Functions.SL_Phanloaivao_May1 == 8)
            {
                Functions.GT_CanVao_May1 = Functions.TL_o8_May1;
            }
            else if (Functions.SL_Phanloaivao_May1 == 9)
            {
                Functions.GT_CanVao_May1 = Functions.TL_o9_May1;
            }
            else if (Functions.SL_Phanloaivao_May1 == 10)
            {
                Functions.GT_CanVao_May1 = Functions.TL_o10_May1;
            }



            ////////////////////////////////////////////////////////////////////////


            if (Functions.SL_Phanloaivao_May2 == 1)
            {
                Functions.GT_CanVao_May2 = Functions.TL_o1_May2;
            }
            else if (Functions.SL_Phanloaivao_May2 == 2)
            {
                Functions.GT_CanVao_May2 = Functions.TL_o2_May2;
            }
            else if (Functions.SL_Phanloaivao_May2 == 3)
            {
                Functions.GT_CanVao_May2 = Functions.TL_o3_May2;
            }
            else if (Functions.SL_Phanloaivao_May2 == 4)
            {
                Functions.GT_CanVao_May2 = Functions.TL_o4_May2;
            }
            else if(Functions.SL_Phanloaivao_May2 == 5)
            {
                Functions.GT_CanVao_May2 = Functions.TL_o5_May2;
            }
            else if (Functions.SL_Phanloaivao_May2 == 6)
            {
                Functions.GT_CanVao_May2 = Functions.TL_o6_May2;
            }
            else if (Functions.SL_Phanloaivao_May2 == 7)
            {
                Functions.GT_CanVao_May2 = Functions.TL_o7_May2;
            }
            else if(Functions.SL_Phanloaivao_May2 == 8)
            {
                Functions.GT_CanVao_May2 = Functions.TL_o8_May2;
            }
            else if(Functions.SL_Phanloaivao_May2 == 9)
            {
                Functions.GT_CanVao_May2 = Functions.TL_o9_May2;
            }
            else if (Functions.SL_Phanloaivao_May2 == 10)
            {
                Functions.GT_CanVao_May2 = Functions.TL_o10_May2;
            }


            if (Functions.int_ngay < 10)
            {
                Functions.ngay = zero + Functions.int_ngay.ToString();
            }
            else if (Functions.int_ngay > 9)
            {
                Functions.ngay = Functions.int_ngay.ToString();
            }


            if (Functions.int_thang < 10)
            {
                Functions.thang = zero + Functions.int_thang.ToString();
            }
            else if (Functions.int_thang > 9)
            {
                Functions.thang = Functions.int_thang.ToString();
            }

            if (Functions.int_gio < 10)
            {
                Functions.gio = zero + Functions.int_gio.ToString();
                Functions.AM_PM = "AM";
            }
            else if (Functions.int_gio > 9)
            {
                Functions.gio = Functions.int_gio.ToString();
                if (Functions.int_gio >= 10 && Functions.int_gio <= 11)
                {

                    Functions.AM_PM = "AM";
                }
                else if (Functions.int_gio >= 12 && Functions.int_gio <= 24)
                {
                    Functions.AM_PM = "PM";
                }

            }

            if (Functions.int_phut < 10)
            {
                Functions.phut = zero + Functions.int_phut.ToString();
            }
            else if (Functions.int_phut > 9)
            {
                Functions.phut = Functions.int_phut.ToString();
            }

            if (Functions.int_giay < 10)
            {
                Functions.giay = zero + Functions.int_giay.ToString();
            }
            else if (Functions.int_giay > 9)
            {
                Functions.giay = Functions.int_giay.ToString();
            }


            ////////////////////////////////////////////////////////////PHAN LOAI 
            if (Functions.TT_PLVao_May1 == 1)
            {

                Functions.Phanloaivao_May1 = "OK";



            }
            if (Functions.TT_PLVao_May1 == 2)
            {

                Functions.Phanloaivao_May1 = "LO";

            }
            if (Functions.TT_PLVao_May1 == 3)
            {

                Functions.Phanloaivao_May1 = "HI";

            }

            /////////////////////////////////////////


            if (Functions.TT_PLRa_May1 == 1)
            {

                Functions.Phanloaira_May1 = "OK";



            }
            if (Functions.TT_PLRa_May1 == 2)
            {

                Functions.Phanloaira_May1 = "LO";

            }
            if (Functions.TT_PLRa_May1 == 3)
            {

                Functions.Phanloaira_May1 = "HI";

            }


            //MAY 2
            ////////////////////////////////////////////////////////


            if (Functions.TT_PLVao_May2 == 1)
            {

                Functions.Phanloaivao_May2 = "OK";


            }
            else if (Functions.TT_PLVao_May2 == 2)
            {

                Functions.Phanloaivao_May2 = "LO";

            }
            else if (Functions.TT_PLVao_May2 == 3)
            {

                Functions.Phanloaivao_May2 = "HI";

            }


            ///////////////////////////////////////////////////////


            if (Functions.TT_PLRa_May2 == 1)
            {

                Functions.Phanloaira_May2 = "OK";

            }
            if (Functions.TT_PLRa_May2 == 2)
            {

                Functions.Phanloaira_May2 = "LO";
            }

                if (Functions.TT_PLRa_May2 == 3)
                {

                    Functions.Phanloaira_May2 = "HI";

                }

            ////////////////////////////////////////////////

                Functions.nam = Functions.int_nam.ToString();
                string nam1 = num.ToString() + Functions.nam;

          

                Functions.date = Functions.thang + "/" + Functions.ngay + "/" + nam1;
                Functions.date1 = Functions.ngay + "/" + Functions.thang + "/" + nam1;
                Functions.time = Functions.gio + ":" + Functions.phut + ":" + Functions.giay + " " + Functions.AM_PM;

           

            if (Functions.BitAdd_xoa_cpk1 == 1)
                {
                    if (Functions.BitAdd_Ca1 == 1)
                    {

                        Functions.z1_Ca1 = 1;

                        //    Functions.CDTT_May1 = new double[999999];

                        Functions.SUM_May1_Ca1 = 0; Functions.SUMSQUARES_May1_Ca1 = 0.00; Functions.SQUARESUMS_May1_Ca1 = 0.00;
                        Functions.AVE_May1_Ca1 = 0.00;
                        Functions.STD_May1_Ca1 = 0.00; Functions.CPK1_May1_Ca1 = 0.00; Functions.CPK2_May1_Ca1 = 0.00; Functions.CPK_May1_Ca1 = 0.00;
                        Functions.NUMERATOR_May1_Ca1 = 0.00; Functions.DENOMINATOR_May1_Ca1 = 0.00;
                    }
                    if (Functions.BitAdd_Ca2 == 1)
                    {

                        Functions.z1_Ca2 = 1;

                        //  Functions.CDTT_May1 = new double[999999];

                        Functions.SUM_May1_Ca2 = 0; Functions.SUMSQUARES_May1_Ca2 = 0.00; Functions.SQUARESUMS_May1_Ca2 = 0.00;
                        Functions.AVE_May1_Ca2 = 0.00;
                        Functions.STD_May1_Ca2 = 0.00; Functions.CPK1_May1_Ca2 = 0.00; Functions.CPK2_May1_Ca2 = 0.00; Functions.CPK_May1_Ca2 = 0.00;
                        Functions.NUMERATOR_May1_Ca2 = 0.00; Functions.DENOMINATOR_May1_Ca2 = 0.00;
                    }

                }

                if (Functions.BitAdd_xoa_cpk2 == 1)
                {
                    if (Functions.BitAdd_Ca1 == 1)
                    {
                        Functions.z2_Ca1 = 1;

                        //  Functions.CDTT_May2 = new double[999999];

                        Functions.SUM_May2_Ca1 = 0; Functions.SUMSQUARES_May2_Ca1 = 0.00; Functions.SQUARESUMS_May2_Ca1 = 0.00;
                        Functions.AVE_May2_Ca1 = 0.00;
                        Functions.STD_May2_Ca1 = 0.00; Functions.CPK1_May2_Ca1 = 0.00; Functions.CPK2_May2_Ca1 = 0.00; Functions.CPK_May2_Ca1 = 0.00;
                        Functions.NUMERATOR_May2_Ca1 = 0.00; Functions.DENOMINATOR_May2_Ca1 = 0.00;

                    }
                    if (Functions.BitAdd_Ca2 == 1)
                    {

                        Functions.z2_Ca2 = 1;

                        //   Functions.CDTT_May2 = new double[999999];

                        Functions.SUM_May2_Ca2 = 0; Functions.SUMSQUARES_May2_Ca2 = 0.00; Functions.SQUARESUMS_May2_Ca2 = 0.00;
                        Functions.AVE_May2_Ca2 = 0.00;
                        Functions.STD_May2_Ca2 = 0.00; Functions.CPK1_May2_Ca2 = 0.00; Functions.CPK2_May2_Ca2 = 0.00; Functions.CPK_May2_Ca2 = 0.00;
                        Functions.NUMERATOR_May2_Ca2 = 0.00; Functions.DENOMINATOR_May2_Ca2 = 0.00;
                    }



                }

                if (Functions.BitAdd_Ca1 == 1)
                {
                  
                    IN1_Ca1();
                    OUT1_Ca1();
                    IN2_Ca1();
                    OUT2_Ca1();
                    
                }
                if (Functions.BitAdd_Ca2 == 1)
                {
                  
                    IN1_Ca2();
                    OUT1_Ca2();
                    IN2_Ca2();
                    OUT2_Ca2();
              
            }
              
            }

        #region IN - OUT SAVE DATA TO SQLITE CHANGE SHIFT

        private void IN1_Ca1() 
        {

            //  if (Functions.GT_CanVao_May1 != 0) //&& Functions.TongBinh_INPUT_May1 != 0
            
                if (Functions.BitAdd_INPUT_May1 == 1 && !isDone_INPUT_May1_Ca1 )
                {
                    themdulieusql_may1_IN_Ca1();

                    isDone_INPUT_May1_Ca1 = true;


                
            }

                else if (Functions.BitAdd_INPUT_May1 == 0 )
            {

                isDone_INPUT_May1_Ca1 = false;
            }
            
} 
        private void IN1_Ca2()
        {

            //  if (Functions.GT_CanVao_May1 != 0) //&& Functions.TongBinh_INPUT_May1 != 0

            if (Functions.BitAdd_INPUT_May1 == 1 && !isDone_INPUT_May1_Ca2  )
            {
                themdulieusql_may1_IN_Ca2();

                isDone_INPUT_May1_Ca2 = true;



            }

            else if (Functions.BitAdd_INPUT_May1 == 0 )
            {

                isDone_INPUT_May1_Ca2 = false;
            }

        }



        private void OUT1_Ca1()
        {
            //// BIEU DO CAN RA MAY 1
         //   if ((Functions.TL_Axit_May1) != 0 && Functions.TongBinh_OUTPUT_May1 != 0)
            
                if (Functions.BitAdd_OUTPUT_May1 == 1 && !isDone_OUTPUT_May1_Ca1)
                {

                    if (((Functions.TL_Axit_May1) <= (Functions.TL_Axit_TC + Functions.DSH_Binhra)) && ((Functions.TL_Axit_May1) >= (Functions.TL_Axit_TC + Functions.DSL_Binhra)))
                    {
                        Calculate_CPK_MAY1_CA1();
                    }
                    

                    themdulieusql_may1_OUT_Ca1();
                    themdulieusqltong();
                    isDone_OUTPUT_May1_Ca1 = true;

                }

                else if (Functions.BitAdd_OUTPUT_May1 == 0)
                {

                    isDone_OUTPUT_May1_Ca1 = false;

                
            }
          

        }
        private void OUT1_Ca2()
        {
         
            //   if ((Functions.TL_Axit_May1) != 0 && Functions.TongBinh_OUTPUT_May1 != 0)

            if (Functions.BitAdd_OUTPUT_May1 == 1 && !isDone_OUTPUT_May1_Ca2)
            {

                if (((Functions.TL_Axit_May1) <= (Functions.TL_Axit_TC + Functions.DSH_Binhra)) && ((Functions.TL_Axit_May1) >= (Functions.TL_Axit_TC + Functions.DSL_Binhra)))
                {
                    Calculate_CPK_MAY1_CA2();

                }
                
                themdulieusql_may1_OUT_Ca2();
                themdulieusqltong();
                isDone_OUTPUT_May1_Ca2 = true;

            }

            else if (Functions.BitAdd_OUTPUT_May1 == 0)
            {

                isDone_OUTPUT_May1_Ca2 = false;


            }


        }
    
        private void IN2_Ca1()
        {
           // if (Functions.GT_CanVao_May2 != 0 && Functions.TongBinh_INPUT_May2 != 0)
            
                if (Functions.BitAdd_INPUT_May2 == 1 && !isDone_INPUT_May2_Ca1)
                {

                    themdulieusql_may2_IN_Ca1();
                   
                    isDone_INPUT_May2_Ca1 = true;


                }
            
            else if (Functions.BitAdd_INPUT_May2 == 0)
            {

                isDone_INPUT_May2_Ca1 = false;

            }

        }
        private void IN2_Ca2()
        {
            // if (Functions.GT_CanVao_May2 != 0 && Functions.TongBinh_INPUT_May2 != 0)

            if (Functions.BitAdd_INPUT_May2 == 1 && !isDone_INPUT_May2_Ca2)
            {

                themdulieusql_may2_IN_Ca2();

                isDone_INPUT_May2_Ca2 = true;


            }

            else if (Functions.BitAdd_INPUT_May2 == 0)
            {

                isDone_INPUT_May2_Ca2 = false;

            }

        }
       
       
        private void OUT2_Ca1()
        {
        //    if ((Functions.TL_Axit_May2) != 0 && Functions.TongBinh_OUTPUT_May2 != 0)
            
                if (Functions.BitAdd_OUTPUT_May2 == 1 && !isDone_OUTPUT_May2_Ca1)
                {

                    if (((Functions.TL_Axit_May2) <= (Functions.TL_Axit_TC + Functions.DSH_Binhra)) && ((Functions.TL_Axit_May2) >= (Functions.TL_Axit_TC + Functions.DSL_Binhra)))
                    {
                        Calculate_CPK_MAY2_CA1();
                    } 

                    

                    themdulieusql_may2_OUT_Ca1();
                    themdulieusqltong();
                    isDone_OUTPUT_May2_Ca1 = true;


                }
            
            else if (Functions.BitAdd_OUTPUT_May2 == 0)
            {

                isDone_OUTPUT_May2_Ca1 = false;
            }
            
        }
        private void OUT2_Ca2()
        {
            //    if ((Functions.TL_Axit_May2) != 0 && Functions.TongBinh_OUTPUT_May2 != 0)

            if (Functions.BitAdd_OUTPUT_May2 == 1 && !isDone_OUTPUT_May2_Ca2)
            {

                if (((Functions.TL_Axit_May2) <= (Functions.TL_Axit_TC + Functions.DSH_Binhra)) && ((Functions.TL_Axit_May2) >= (Functions.TL_Axit_TC + Functions.DSL_Binhra)))
                {
                    Calculate_CPK_MAY2_CA2();
                }
                 

                

                themdulieusql_may2_OUT_Ca2();
                themdulieusqltong();
                isDone_OUTPUT_May2_Ca2 = true;


            }

            else if (Functions.BitAdd_OUTPUT_May2 == 0)
            {

                isDone_OUTPUT_May2_Ca2 = false;
            }

        }

     
        private void themdulieusqltong()
        {
            DateTime dateTimeNow = DateTime.Now; // lay thoi gian thuc ghi vao excel

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;


            string sql = "INSERT INTO quanlymanhinhtong (Ngay,ThoiGian,MaLoHang,SoCa) VALUES(@ngay,@thoigian,@mslh,@soca)";

           
            cmd = new SQLiteCommand(sql, con);

            DateTime dt = DateTime.Parse(Functions.date);
            string dt1 = dt.ToString("yyyy-MM-dd");
            string dt2 = Functions.date + " " + Functions.time;
            cmd.Parameters.AddWithValue("@ngay", dt1);
            cmd.Parameters.AddWithValue("@thoigian", dt2);
            
            // cmd.Parameters.AddWithValue("@gio", time);

            cmd.Parameters.AddWithValue("@mslh", Functions.MSLH);

            cmd.Parameters.AddWithValue("@soca", Functions.SoCa);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;


        }
       
        private void themdulieusql_may1_IN_Ca1()
        {
            DateTime dateTimeNow = DateTime.Now;

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;


            string sql = "INSERT INTO quanlymanhinhmay1_IN (Ngay,ThoiGian,MaLoHang,QuyCach,NguoiThaoTac,SoCa,TLBinhChuaCoAcid,"
            + "TLAcidTC,TLBinhVaoMay1,TLBinhDauMay1,TLBinhSauMay1,TLAcidMay1,DSD,DST,DSL,DSH,DSDBinhVao,DSTBinhVao,DSLBinhVao,DSHBinhVao,"
            + "SumMay1_IN)"
            + " VALUES (@ngay,@thoigian,@mslh, @qc, @ntt,@soca, @TLbinhchuacoacid,@TLacidtc,"
            + "@TLbinhvaomay1,@TLbinhdaumay1,@TLbinhsaumay1,@TLacidmay1,@dsd, @dst, @dsl, @dsh,@dsdbv,@dstbv,@dslbv,@dshbv,"
            + "@summay1_in)";

         

            cmd = new SQLiteCommand(sql, con);

            DateTime dt = DateTime.Parse(Functions.date);
            string dt1 = dt.ToString("yyyy-MM-dd");
            string dt2 = Functions.date + " " + Functions.time;
            cmd.Parameters.AddWithValue("@ngay", dt1);
            cmd.Parameters.AddWithValue("@thoigian", dt2);

            cmd.Parameters.AddWithValue("@mslh", Functions.MSLH);
            cmd.Parameters.AddWithValue("@qc", Functions.quy_cach);
            cmd.Parameters.AddWithValue("@ntt", Functions.nguoi_tt);
            cmd.Parameters.AddWithValue("@soca", Functions.SoCa);
         

            cmd.Parameters.AddWithValue("@TLbinhchuacoacid", Functions.TLBinh_ChuaCoAxit);
            cmd.Parameters.AddWithValue("@TLacidtc", Functions.TL_Axit_TC);

            cmd.Parameters.AddWithValue("@TLbinhvaomay1", Functions.GT_CanVao_May1);
            cmd.Parameters.AddWithValue("@TLbinhdaumay1", Functions.TLB_Dau_May1);
            cmd.Parameters.AddWithValue("@TLBinhsauMay1", Functions.TLB_Sau_May1);
            cmd.Parameters.AddWithValue("@TLacidmay1", Functions.TL_Axit_May1);



            cmd.Parameters.AddWithValue("@dsd", Functions.DSD_Binhra);
            cmd.Parameters.AddWithValue("@dst", Functions.DST_Binhra);
            cmd.Parameters.AddWithValue("@dsl", Functions.DSL_Binhra);
            cmd.Parameters.AddWithValue("@dsh", Functions.DSH_Binhra);

            cmd.Parameters.AddWithValue("@dsdbv", Functions.DSD_Binhvao);
            cmd.Parameters.AddWithValue("@dstbv", Functions.DST_Binhvao);
            cmd.Parameters.AddWithValue("@dslbv", Functions.DSL_Binhvao);
            cmd.Parameters.AddWithValue("@dshbv", Functions.DSH_Binhvao);

          

            cmd.Parameters.AddWithValue("@summay1_in", Functions.TongBinh_INPUT_May1_Ca1);


        
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;


        }
        private void themdulieusql_may1_IN_Ca2()
        {
            DateTime dateTimeNow = DateTime.Now;

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;


            string sql = "INSERT INTO quanlymanhinhmay1_IN (Ngay,ThoiGian,MaLoHang,QuyCach,NguoiThaoTac,SoCa,TLBinhChuaCoAcid,"
            + "TLAcidTC,TLBinhVaoMay1,TLBinhDauMay1,TLBinhSauMay1,TLAcidMay1,DSD,DST,DSL,DSH,DSDBinhVao,DSTBinhVao,DSLBinhVao,DSHBinhVao,"
            + "SumMay1_IN)"
            + " VALUES (@ngay,@thoigian,@mslh, @qc, @ntt,@soca, @TLbinhchuacoacid,@TLacidtc,"
            + "@TLbinhvaomay1,@TLbinhdaumay1,@TLbinhsaumay1,@TLacidmay1,@dsd, @dst, @dsl, @dsh,@dsdbv,@dstbv,@dslbv,@dshbv,"
            + "@summay1_in)";

            
            cmd = new SQLiteCommand(sql, con);

            DateTime dt = DateTime.Parse(Functions.date);
            string dt1 = dt.ToString("yyyy-MM-dd");
            string dt2 = Functions.date + " " + Functions.time;
            cmd.Parameters.AddWithValue("@ngay", dt1);
            cmd.Parameters.AddWithValue("@thoigian", dt2);

            cmd.Parameters.AddWithValue("@mslh", Functions.MSLH);
            cmd.Parameters.AddWithValue("@qc", Functions.quy_cach);
            cmd.Parameters.AddWithValue("@ntt", Functions.nguoi_tt);
            cmd.Parameters.AddWithValue("@soca", Functions.SoCa);
           

            cmd.Parameters.AddWithValue("@TLbinhchuacoacid", Functions.TLBinh_ChuaCoAxit);
            cmd.Parameters.AddWithValue("@TLacidtc", Functions.TL_Axit_TC);

            cmd.Parameters.AddWithValue("@TLbinhvaomay1", Functions.GT_CanVao_May1);
            cmd.Parameters.AddWithValue("@TLbinhdaumay1", Functions.TLB_Dau_May1);
            cmd.Parameters.AddWithValue("@TLBinhsauMay1", Functions.TLB_Sau_May1);
            cmd.Parameters.AddWithValue("@TLacidmay1", Functions.TL_Axit_May1);



            cmd.Parameters.AddWithValue("@dsd", Functions.DSD_Binhra);
            cmd.Parameters.AddWithValue("@dst", Functions.DST_Binhra);
            cmd.Parameters.AddWithValue("@dsl", Functions.DSL_Binhra);
            cmd.Parameters.AddWithValue("@dsh", Functions.DSH_Binhra);

            cmd.Parameters.AddWithValue("@dsdbv", Functions.DSD_Binhvao);
            cmd.Parameters.AddWithValue("@dstbv", Functions.DST_Binhvao);
            cmd.Parameters.AddWithValue("@dslbv", Functions.DSL_Binhvao);
            cmd.Parameters.AddWithValue("@dshbv", Functions.DSH_Binhvao);



            cmd.Parameters.AddWithValue("@summay1_in", Functions.TongBinh_INPUT_May1_Ca2);



            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;


        }

        private void themdulieusql_may1_OUT_Ca1()
        {
            DateTime dateTimeNow = DateTime.Now; 

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;


            string sql = "INSERT INTO quanlymanhinhmay1 (Ngay,ThoiGian,MaLoHang,QuyCach,NguoiThaoTac,SoCa,TLBinhChuaCoAcid,"
            + "TLAcidTC,TLBinhVaoMay1,TLBinhDauMay1,TLBinhSauMay1,TLAcidMay1,DSD,DST,DSL,DSH,DSDBinhVao,DSTBinhVao,DSLBinhVao,DSHBinhVao,PhanLoaiMay1,"
            + "SumMay1,STDMay1,AVEMay1,CPKMay1)"
            +" VALUES (@ngay,@thoigian,@mslh, @qc, @ntt,@soca, @TLbinhchuacoacid,@TLacidtc,"
            + "@TLbinhvaomay1,@TLbinhdaumay1,@TLbinhsaumay1,@TLacidmay1,@dsd, @dst, @dsl, @dsh,@dsdbv,@dstbv,@dslbv,@dshbv,@phanloaimay1,"
            + "@summay1,@stdmay1,@avemay1,@cpkmay1 )";
           
          
           
            cmd = new SQLiteCommand(sql, con);

            DateTime dt = DateTime.Parse(Functions.date);
            string dt1 = dt.ToString("yyyy-MM-dd");
            string dt2 = Functions.date +" "+ Functions.time;
            cmd.Parameters.AddWithValue("@ngay", dt1);
            cmd.Parameters.AddWithValue("@thoigian", dt2);

            cmd.Parameters.AddWithValue("@mslh", Functions.MSLH);
            cmd.Parameters.AddWithValue("@qc", Functions.quy_cach);
            cmd.Parameters.AddWithValue("@ntt", Functions.nguoi_tt);
            cmd.Parameters.AddWithValue("@soca", Functions.SoCa);
            

            cmd.Parameters.AddWithValue("@TLbinhchuacoacid", Functions.TLBinh_ChuaCoAxit);
            cmd.Parameters.AddWithValue("@TLacidtc", Functions.TL_Axit_TC);

            cmd.Parameters.AddWithValue("@TLbinhvaomay1", Functions.GT_CanVao_May1);
            cmd.Parameters.AddWithValue("@TLbinhdaumay1", Functions.TLB_Dau_May1);
            cmd.Parameters.AddWithValue("@TLBinhsauMay1", Functions.TLB_Sau_May1);
            cmd.Parameters.AddWithValue("@TLacidmay1", Functions.TL_Axit_May1);
           
           

            cmd.Parameters.AddWithValue("@dsd", Functions.DSD_Binhra);
            cmd.Parameters.AddWithValue("@dst", Functions.DST_Binhra);
            cmd.Parameters.AddWithValue("@dsl", Functions.DSL_Binhra);
            cmd.Parameters.AddWithValue("@dsh", Functions.DSH_Binhra);

            cmd.Parameters.AddWithValue("@dsdbv", Functions.DSD_Binhvao);
            cmd.Parameters.AddWithValue("@dstbv", Functions.DST_Binhvao);
            cmd.Parameters.AddWithValue("@dslbv", Functions.DSL_Binhvao);
            cmd.Parameters.AddWithValue("@dshbv", Functions.DSH_Binhvao);

            cmd.Parameters.AddWithValue("@phanloaimay1", Functions.Phanloaira_May1);
            
           cmd.Parameters.AddWithValue("@summay1", Functions.TongBinh_OUTPUT_May1_Ca1);


           cmd.Parameters.AddWithValue("@stdmay1", Functions.STD_May1_Ca1);

           cmd.Parameters.AddWithValue("@avemay1", Functions.AVE_May1_Ca1);

           cmd.Parameters.AddWithValue("@cpkmay1", Functions.CPK_May1_Ca1);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;


        }
        private void themdulieusql_may1_OUT_Ca2()
        {
            DateTime dateTimeNow = DateTime.Now;

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;


            string sql = "INSERT INTO quanlymanhinhmay1 (Ngay,ThoiGian,MaLoHang,QuyCach,NguoiThaoTac,SoCa,TLBinhChuaCoAcid,"
            + "TLAcidTC,TLBinhVaoMay1,TLBinhDauMay1,TLBinhSauMay1,TLAcidMay1,DSD,DST,DSL,DSH,DSDBinhVao,DSTBinhVao,DSLBinhVao,DSHBinhVao,PhanLoaiMay1,"
            + "SumMay1,STDMay1,AVEMay1,CPKMay1)"
            + " VALUES (@ngay,@thoigian,@mslh, @qc, @ntt,@soca, @TLbinhchuacoacid,@TLacidtc,"
            + "@TLbinhvaomay1,@TLbinhdaumay1,@TLbinhsaumay1,@TLacidmay1,@dsd, @dst, @dsl, @dsh,@dsdbv,@dstbv,@dslbv,@dshbv,@phanloaimay1,"
            + "@summay1,@stdmay1,@avemay1,@cpkmay1 )";

           
            cmd = new SQLiteCommand(sql, con);

            DateTime dt = DateTime.Parse(Functions.date);
            string dt1 = dt.ToString("yyyy-MM-dd");
            string dt2 = Functions.date + " " + Functions.time;
            cmd.Parameters.AddWithValue("@ngay", dt1);
            cmd.Parameters.AddWithValue("@thoigian", dt2);

            cmd.Parameters.AddWithValue("@mslh", Functions.MSLH);
            cmd.Parameters.AddWithValue("@qc", Functions.quy_cach);
            cmd.Parameters.AddWithValue("@ntt", Functions.nguoi_tt);
            cmd.Parameters.AddWithValue("@soca", Functions.SoCa);
           
            cmd.Parameters.AddWithValue("@TLbinhchuacoacid", Functions.TLBinh_ChuaCoAxit);
            cmd.Parameters.AddWithValue("@TLacidtc", Functions.TL_Axit_TC);

            cmd.Parameters.AddWithValue("@TLbinhvaomay1", Functions.GT_CanVao_May1);
            cmd.Parameters.AddWithValue("@TLbinhdaumay1", Functions.TLB_Dau_May1);
            cmd.Parameters.AddWithValue("@TLBinhsauMay1", Functions.TLB_Sau_May1);
            cmd.Parameters.AddWithValue("@TLacidmay1", Functions.TL_Axit_May1);



            cmd.Parameters.AddWithValue("@dsd", Functions.DSD_Binhra);
            cmd.Parameters.AddWithValue("@dst", Functions.DST_Binhra);
            cmd.Parameters.AddWithValue("@dsl", Functions.DSL_Binhra);
            cmd.Parameters.AddWithValue("@dsh", Functions.DSH_Binhra);

            cmd.Parameters.AddWithValue("@dsdbv", Functions.DSD_Binhvao);
            cmd.Parameters.AddWithValue("@dstbv", Functions.DST_Binhvao);
            cmd.Parameters.AddWithValue("@dslbv", Functions.DSL_Binhvao);
            cmd.Parameters.AddWithValue("@dshbv", Functions.DSH_Binhvao);

            cmd.Parameters.AddWithValue("@phanloaimay1", Functions.Phanloaira_May1);

            cmd.Parameters.AddWithValue("@summay1", Functions.TongBinh_OUTPUT_May1_Ca2);


            cmd.Parameters.AddWithValue("@stdmay1", Functions.STD_May1_Ca1);

            cmd.Parameters.AddWithValue("@avemay1", Functions.AVE_May1_Ca1);

            cmd.Parameters.AddWithValue("@cpkmay1", Functions.CPK_May1_Ca1);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;


        }
        
        private void themdulieusql_may2_IN_Ca1()
        {
            DateTime dateTimeNow = DateTime.Now;

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;


            string sql = "INSERT INTO quanlymanhinhmay2_IN (Ngay,ThoiGian,MaLoHang,QuyCach,NguoiThaoTac,SoCa,TLBinhChuaCoAcid,"
            + "TLAcidTC,TLBinhVaoMay2,TLBinhDauMay2,TLBinhSauMay2,TLAcidMay2,DSD,DST,DSL,DSH,DSDBinhVao,DSTBinhVao,DSLBinhVao,DSHBinhVao,"
            + "SumMay2_IN)"
            + " VALUES (@ngay,@thoigian,@mslh, @qc, @ntt,@soca,@TLbinhchuacoacid,@TLacidtc,"
            + "@TLbinhvaomay2,@TLbinhdaumay2,@TLbinhsaumay2,@TLacidmay2,@dsd, @dst, @dsl, @dsh,@dsdbv,@dstbv,@dslbv,@dshbv,"
            + "@summay2_in )";


            cmd = new SQLiteCommand(sql, con);

            DateTime dt = DateTime.Parse(Functions.date);
            string dt1 = dt.ToString("yyyy-MM-dd");
            string dt2 = Functions.date + " " + Functions.time;
            cmd.Parameters.AddWithValue("@ngay", dt1);
            cmd.Parameters.AddWithValue("@thoigian", dt2);

            cmd.Parameters.AddWithValue("@mslh", Functions.MSLH);
            cmd.Parameters.AddWithValue("@qc", Functions.quy_cach);
            cmd.Parameters.AddWithValue("@ntt", Functions.nguoi_tt);
            cmd.Parameters.AddWithValue("@soca", Functions.SoCa);
            

            cmd.Parameters.AddWithValue("@TLbinhchuacoacid", Functions.TLBinh_ChuaCoAxit);
            cmd.Parameters.AddWithValue("@TLacidtc", Functions.TL_Axit_TC);

            cmd.Parameters.AddWithValue("@TLbinhvaomay2", Functions.GT_CanVao_May2);
            cmd.Parameters.AddWithValue("@TLbinhdaumay2", Functions.TLB_Dau_May2);
            cmd.Parameters.AddWithValue("@TLBinhsauMay2", Functions.TLB_Sau_May2);
            cmd.Parameters.AddWithValue("@TLacidmay2", Functions.TL_Axit_May2);



            cmd.Parameters.AddWithValue("@dsd", Functions.DSD_Binhra);
            cmd.Parameters.AddWithValue("@dst", Functions.DST_Binhra);
            cmd.Parameters.AddWithValue("@dsl", Functions.DSL_Binhra);
            cmd.Parameters.AddWithValue("@dsh", Functions.DSH_Binhra);

            cmd.Parameters.AddWithValue("@dsdbv", Functions.DSD_Binhvao);
            cmd.Parameters.AddWithValue("@dstbv", Functions.DST_Binhvao);
            cmd.Parameters.AddWithValue("@dslbv", Functions.DSL_Binhvao);
            cmd.Parameters.AddWithValue("@dshbv", Functions.DSH_Binhvao);



            cmd.Parameters.AddWithValue("@summay2_in", Functions.TongBinh_INPUT_May2_Ca1);

          

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;



        }
        private void themdulieusql_may2_IN_Ca2()
        {
            DateTime dateTimeNow = DateTime.Now;

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;


            string sql = "INSERT INTO quanlymanhinhmay2_IN (Ngay,ThoiGian,MaLoHang,QuyCach,NguoiThaoTac,SoCa,TLBinhChuaCoAcid,"
            + "TLAcidTC,TLBinhVaoMay2,TLBinhDauMay2,TLBinhSauMay2,TLAcidMay2,DSD,DST,DSL,DSH,DSDBinhVao,DSTBinhVao,DSLBinhVao,DSHBinhVao,"
            + "SumMay2_IN)"
            + " VALUES (@ngay,@thoigian,@mslh, @qc, @ntt,@soca, @TLbinhchuacoacid,@TLacidtc,"
            + "@TLbinhvaomay2,@TLbinhdaumay2,@TLbinhsaumay2,@TLacidmay2,@dsd, @dst, @dsl, @dsh,@dsdbv,@dstbv,@dslbv,@dshbv,"
            + "@summay2_in )";


            cmd = new SQLiteCommand(sql, con);

            DateTime dt = DateTime.Parse(Functions.date);
            string dt1 = dt.ToString("yyyy-MM-dd");
            string dt2 = Functions.date + " " + Functions.time;
            cmd.Parameters.AddWithValue("@ngay", dt1);
            cmd.Parameters.AddWithValue("@thoigian", dt2);

            cmd.Parameters.AddWithValue("@mslh", Functions.MSLH);
            cmd.Parameters.AddWithValue("@qc", Functions.quy_cach);
            cmd.Parameters.AddWithValue("@ntt", Functions.nguoi_tt);
            cmd.Parameters.AddWithValue("@soca", Functions.SoCa);
           


            cmd.Parameters.AddWithValue("@TLbinhchuacoacid", Functions.TLBinh_ChuaCoAxit);
            cmd.Parameters.AddWithValue("@TLacidtc", Functions.TL_Axit_TC);

            cmd.Parameters.AddWithValue("@TLbinhvaomay2", Functions.GT_CanVao_May2);
            cmd.Parameters.AddWithValue("@TLbinhdaumay2", Functions.TLB_Dau_May2);
            cmd.Parameters.AddWithValue("@TLBinhsauMay2", Functions.TLB_Sau_May2);
            cmd.Parameters.AddWithValue("@TLacidmay2", Functions.TL_Axit_May2);



            cmd.Parameters.AddWithValue("@dsd", Functions.DSD_Binhra);
            cmd.Parameters.AddWithValue("@dst", Functions.DST_Binhra);
            cmd.Parameters.AddWithValue("@dsl", Functions.DSL_Binhra);
            cmd.Parameters.AddWithValue("@dsh", Functions.DSH_Binhra);

            cmd.Parameters.AddWithValue("@dsdbv", Functions.DSD_Binhvao);
            cmd.Parameters.AddWithValue("@dstbv", Functions.DST_Binhvao);
            cmd.Parameters.AddWithValue("@dslbv", Functions.DSL_Binhvao);
            cmd.Parameters.AddWithValue("@dshbv", Functions.DSH_Binhvao);



            cmd.Parameters.AddWithValue("@summay2_in", Functions.TongBinh_INPUT_May2_Ca2);



            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;



        }
       
        private void themdulieusql_may2_OUT_Ca1()
        {
            DateTime dateTimeNow = DateTime.Now;

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;


            string sql = "INSERT INTO quanlymanhinhmay2 (Ngay,ThoiGian,MaLoHang,QuyCach,NguoiThaoTac,SoCa,TLBinhChuaCoAcid,"
            + "TLAcidTC,TLBinhVaoMay2,TLBinhDauMay2,TLBinhSauMay2,TLAcidMay2,DSD,DST,DSL,DSH,DSDBinhVao,DSTBinhVao,DSLBinhVao,DSHBinhVao,PhanLoaiMay2,"
            + "SumMay2,STDMay2,AVEMay2,CPKMay2)"
            + " VALUES (@ngay,@thoigian,@mslh, @qc, @ntt,@soca, @TLbinhchuacoacid,@TLacidtc,"
            + "@TLbinhvaomay2,@TLbinhdaumay2,@TLbinhsaumay2,@TLacidmay2,@dsd, @dst, @dsl, @dsh,@dsdbv,@dstbv,@dslbv,@dshbv,@phanloaimay2,"
            + "@summay2,@stdmay2,@avemay2,@cpkmay2 )";


            cmd = new SQLiteCommand(sql, con);

            DateTime dt = DateTime.Parse(Functions.date);
            string dt1 = dt.ToString("yyyy-MM-dd");
            string dt2 = Functions.date + " " + Functions.time;
            cmd.Parameters.AddWithValue("@ngay", dt1);
            cmd.Parameters.AddWithValue("@thoigian", dt2);

            cmd.Parameters.AddWithValue("@mslh", Functions.MSLH);
            cmd.Parameters.AddWithValue("@qc", Functions.quy_cach);
            cmd.Parameters.AddWithValue("@ntt", Functions.nguoi_tt);
            cmd.Parameters.AddWithValue("@soca", Functions.SoCa);
            


            cmd.Parameters.AddWithValue("@TLbinhchuacoacid", Functions.TLBinh_ChuaCoAxit);
            cmd.Parameters.AddWithValue("@TLacidtc", Functions.TL_Axit_TC);

            cmd.Parameters.AddWithValue("@TLbinhvaomay2", Functions.GT_CanVao_May2);
            cmd.Parameters.AddWithValue("@TLbinhdaumay2", Functions.TLB_Dau_May2);
            cmd.Parameters.AddWithValue("@TLBinhsauMay2", Functions.TLB_Sau_May2);
            cmd.Parameters.AddWithValue("@TLacidmay2", Functions.TL_Axit_May2);



            cmd.Parameters.AddWithValue("@dsd", Functions.DSD_Binhra);
            cmd.Parameters.AddWithValue("@dst", Functions.DST_Binhra);
            cmd.Parameters.AddWithValue("@dsl", Functions.DSL_Binhra);
            cmd.Parameters.AddWithValue("@dsh", Functions.DSH_Binhra);

            cmd.Parameters.AddWithValue("@dsdbv", Functions.DSD_Binhvao);
            cmd.Parameters.AddWithValue("@dstbv", Functions.DST_Binhvao);
            cmd.Parameters.AddWithValue("@dslbv", Functions.DSL_Binhvao);
            cmd.Parameters.AddWithValue("@dshbv", Functions.DSH_Binhvao);

            cmd.Parameters.AddWithValue("@phanloaimay2", Functions.Phanloaira_May2);

            cmd.Parameters.AddWithValue("@summay2", Functions.TongBinh_OUTPUT_May2_Ca1);




            cmd.Parameters.AddWithValue("@stdmay2", Functions.STD_May2_Ca1);

            cmd.Parameters.AddWithValue("@avemay2", Functions.AVE_May2_Ca1);

            cmd.Parameters.AddWithValue("@cpkmay2", Functions.CPK_May2_Ca1);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;



        }
        private void themdulieusql_may2_OUT_Ca2()
        {
            DateTime dateTimeNow = DateTime.Now;

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;


            string sql = "INSERT INTO quanlymanhinhmay2 (Ngay,ThoiGian,MaLoHang,QuyCach,NguoiThaoTac,SoCa,TLBinhChuaCoAcid,"
            + "TLAcidTC,TLBinhVaoMay2,TLBinhDauMay2,TLBinhSauMay2,TLAcidMay2,DSD,DST,DSL,DSH,DSDBinhVao,DSTBinhVao,DSLBinhVao,DSHBinhVao,PhanLoaiMay2,"
            + "SumMay2,STDMay2,AVEMay2,CPKMay2)"
            + " VALUES (@ngay,@thoigian,@mslh, @qc, @ntt,@soca, @TLbinhchuacoacid,@TLacidtc,"
            + "@TLbinhvaomay2,@TLbinhdaumay2,@TLbinhsaumay2,@TLacidmay2,@dsd, @dst, @dsl, @dsh,@dsdbv,@dstbv,@dslbv,@dshbv,@phanloaimay2,"
            + "@summay2,@stdmay2,@avemay2,@cpkmay2 )";


            cmd = new SQLiteCommand(sql, con);

            DateTime dt = DateTime.Parse(Functions.date);
            string dt1 = dt.ToString("yyyy-MM-dd");
            string dt2 = Functions.date + " " + Functions.time;
            cmd.Parameters.AddWithValue("@ngay", dt1);
            cmd.Parameters.AddWithValue("@thoigian", dt2);

            cmd.Parameters.AddWithValue("@mslh", Functions.MSLH);
            cmd.Parameters.AddWithValue("@qc", Functions.quy_cach);
            cmd.Parameters.AddWithValue("@ntt", Functions.nguoi_tt);
            cmd.Parameters.AddWithValue("@soca", Functions.SoCa);
          


            cmd.Parameters.AddWithValue("@TLbinhchuacoacid", Functions.TLBinh_ChuaCoAxit);
            cmd.Parameters.AddWithValue("@TLacidtc", Functions.TL_Axit_TC);

            cmd.Parameters.AddWithValue("@TLbinhvaomay2", Functions.GT_CanVao_May2);
            cmd.Parameters.AddWithValue("@TLbinhdaumay2", Functions.TLB_Dau_May2);
            cmd.Parameters.AddWithValue("@TLBinhsauMay2", Functions.TLB_Sau_May2);
            cmd.Parameters.AddWithValue("@TLacidmay2", Functions.TL_Axit_May2);



            cmd.Parameters.AddWithValue("@dsd", Functions.DSD_Binhra);
            cmd.Parameters.AddWithValue("@dst", Functions.DST_Binhra);
            cmd.Parameters.AddWithValue("@dsl", Functions.DSL_Binhra);
            cmd.Parameters.AddWithValue("@dsh", Functions.DSH_Binhra);

            cmd.Parameters.AddWithValue("@dsdbv", Functions.DSD_Binhvao);
            cmd.Parameters.AddWithValue("@dstbv", Functions.DST_Binhvao);
            cmd.Parameters.AddWithValue("@dslbv", Functions.DSL_Binhvao);
            cmd.Parameters.AddWithValue("@dshbv", Functions.DSH_Binhvao);

            cmd.Parameters.AddWithValue("@phanloaimay2", Functions.Phanloaira_May2);

            cmd.Parameters.AddWithValue("@summay2", Functions.TongBinh_OUTPUT_May2_Ca2);




            cmd.Parameters.AddWithValue("@stdmay2", Functions.STD_May2_Ca1);

            cmd.Parameters.AddWithValue("@avemay2", Functions.AVE_May2_Ca1);

            cmd.Parameters.AddWithValue("@cpkmay2", Functions.CPK_May2_Ca1);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;



        }

        #endregion

        // CALCULATE CPK, AVE, STD

        private void Calculate_CPK_MAY1_CA1()
        {
           
                Functions.STD_May1_Ca1 = 0.00;
                Functions.CPK_May1_Ca1 = 0.00;
                Functions.CPK1_May1_Ca1 = 0.00;
                Functions.CPK2_May1_Ca1 = 0.00;

                Functions.DSD_Cal_May1 = Functions.DSD_Binhra;
                Functions.DST_Cal_May1 = Functions.DST_Binhra;

                Functions.CDTC_Cal_May1 = Functions.TL_Axit_TC;
                Functions.CDTT_May1[Functions.z1_Ca1] = Functions.TL_Axit_May1;


                Functions.SUM_May1_Ca1 += Functions.CDTT_May1[Functions.z1_Ca1];
                Functions.SQUARESUMS_May1_Ca1 = Functions.SUM_May1_Ca1 * Functions.SUM_May1_Ca1;
                Functions.SUMSQUARES_May1_Ca1 += (Functions.CDTT_May1[Functions.z1_Ca1] * Functions.CDTT_May1[Functions.z1_Ca1]);

                Functions.NUMERATOR_May1_Ca1 = (Functions.z1_Ca1 * Functions.SUMSQUARES_May1_Ca1) - Functions.SQUARESUMS_May1_Ca1;

                Functions.DENOMINATOR_May1_Ca1 = Functions.z1_Ca1 * (Functions.z1_Ca1 - 1);

                Functions.AVE_May1_Ca1 = Convert.ToDouble(String.Format("{0:0.000}", Functions.SUM_May1_Ca1 / Functions.z1_Ca1));



                Functions.STD_May1_Ca1 = Convert.ToDouble(String.Format("{0:0.000}", Math.Sqrt(Functions.NUMERATOR_May1_Ca1 / Functions.DENOMINATOR_May1_Ca1)));

                Functions.CPK1_May1_Ca1 = (Functions.DST_Cal_May1 - Functions.DSD_Cal_May1) / (3 * Functions.STD_May1_Ca1);
                Functions.CPK2_May1_Ca1 = (Functions.AVE_May1_Ca1 - Functions.CDTC_Cal_May1 - Functions.DSD_Cal_May1) / (3 * Functions.STD_May1_Ca1);

                if (Functions.CPK1_May1_Ca1 < Functions.CPK2_May1_Ca1)
                {
                    Functions.CPK_May1_Ca1 = Convert.ToDouble(String.Format("{0:0.000}", Functions.CPK1_May1_Ca1));

                }
                else if (Functions.CPK2_May1_Ca1 < Functions.CPK1_May1_Ca1)
                {
                    Functions.CPK_May1_Ca1 = Convert.ToDouble(String.Format("{0:0.000}", Functions.CPK2_May1_Ca1));

                }


                Functions.z1_Ca1++;
            
          
              


            
        }
        private void Calculate_CPK_MAY1_CA2()
        {
          
                Functions.STD_May1_Ca2 = 0.00;
                Functions.CPK_May1_Ca2 = 0.00;
                Functions.CPK1_May1_Ca2 = 0.00;
                Functions.CPK2_May1_Ca2 = 0.00;

                Functions.DSD_Cal_May1 = Functions.DSD_Binhra;
                Functions.DST_Cal_May1 = Functions.DST_Binhra;

                Functions.CDTC_Cal_May1 = Functions.TL_Axit_TC;

                Functions.CDTT_May1[Functions.z1_Ca2] = Functions.TL_Axit_May1;


                Functions.SUM_May1_Ca2 += Functions.CDTT_May1[Functions.z1_Ca2];
                Functions.SQUARESUMS_May1_Ca2 = Functions.SUM_May1_Ca2 * Functions.SUM_May1_Ca2;
                Functions.SUMSQUARES_May1_Ca2 += (Functions.CDTT_May1[Functions.z1_Ca2] * Functions.CDTT_May1[Functions.z1_Ca2]);

                Functions.NUMERATOR_May1_Ca2 = (Functions.z1_Ca2 * Functions.SUMSQUARES_May1_Ca2) - Functions.SQUARESUMS_May1_Ca2;

                Functions.DENOMINATOR_May1_Ca2 = Functions.z1_Ca2 * (Functions.z1_Ca2 - 1);

                Functions.AVE_May1_Ca2 = Convert.ToDouble(String.Format("{0:0.000}", Functions.SUM_May1_Ca2 / Functions.z1_Ca2));



                Functions.STD_May1_Ca2 = Convert.ToDouble(String.Format("{0:0.000}", Math.Sqrt(Functions.NUMERATOR_May1_Ca2 / Functions.DENOMINATOR_May1_Ca2)));

                Functions.CPK1_May1_Ca2 = (Functions.DST_Cal_May1 - Functions.DSD_Cal_May1) / (3 * Functions.STD_May1_Ca2);
                Functions.CPK2_May1_Ca2 = (Functions.AVE_May1_Ca2 - Functions.CDTC_Cal_May1 - Functions.DSD_Cal_May1) / (3 * Functions.STD_May1_Ca2);

                if (Functions.CPK1_May1_Ca2 < Functions.CPK2_May1_Ca2)
                {
                    Functions.CPK_May1_Ca2 = Convert.ToDouble(String.Format("{0:0.000}", Functions.CPK1_May1_Ca2));

                }
                else if (Functions.CPK2_May1_Ca2 < Functions.CPK1_May1_Ca2)
                {
                    Functions.CPK_May1_Ca2 = Convert.ToDouble(String.Format("{0:0.000}", Functions.CPK2_May1_Ca2));

                }


                Functions.z1_Ca2++;
            }
        

        private void Calculate_CPK_MAY2_CA1()
        {
         
                Functions.STD_May2_Ca1 = 0.00;
                Functions.CPK_May2_Ca1 = 0.00;
                Functions.CPK1_May2_Ca1 = 0.00;
                Functions.CPK2_May2_Ca1 = 0.00;

                Functions.DSD_Cal_May2 = Functions.DSD_Binhra;
                Functions.DST_Cal_May2 = Functions.DST_Binhra;

                Functions.CDTC_Cal_May2 = Functions.TL_Axit_TC;
                Functions.CDTT_May2[Functions.z2_Ca1] = Functions.TL_Axit_May2;


                Functions.SUM_May2_Ca1 += Functions.CDTT_May2[Functions.z2_Ca1];
                Functions.SQUARESUMS_May2_Ca1 = Functions.SUM_May2_Ca1 * Functions.SUM_May2_Ca1;
                Functions.SUMSQUARES_May2_Ca1 += (Functions.CDTT_May2[Functions.z2_Ca1] * Functions.CDTT_May2[Functions.z2_Ca1]);

                Functions.NUMERATOR_May2_Ca1 = (Functions.z2_Ca1 * Functions.SUMSQUARES_May2_Ca1) - Functions.SQUARESUMS_May2_Ca1;

                Functions.DENOMINATOR_May2_Ca1 = Functions.z2_Ca1 * (Functions.z2_Ca1 - 1);

                Functions.AVE_May2_Ca1 = Convert.ToDouble(String.Format("{0:0.000}", Functions.SUM_May2_Ca1 / Functions.z2_Ca1));

                // VALUE = Math.Pow(CDTT[z]- AVE, 2)+ VALUE ;

                Functions.STD_May2_Ca1 = Convert.ToDouble(String.Format("{0:0.000}", Math.Sqrt(Functions.NUMERATOR_May2_Ca1 / Functions.DENOMINATOR_May2_Ca1)));

                Functions.CPK1_May2_Ca1 = (Functions.DST_Cal_May2 - Functions.DSD_Cal_May2) / (3 * Functions.STD_May2_Ca1);
                Functions.CPK2_May2_Ca1 = (Functions.AVE_May2_Ca1 - Functions.CDTC_Cal_May2 - Functions.DSD_Cal_May2) / (3 * Functions.STD_May2_Ca1);

                if (Functions.CPK1_May2_Ca1 < Functions.CPK2_May2_Ca1)
                {
                    Functions.CPK_May2_Ca1 = Convert.ToDouble(String.Format("{0:0.000}", Functions.CPK1_May2_Ca1));

                }
                else if (Functions.CPK2_May2_Ca1 < Functions.CPK1_May2_Ca1)
                {
                    Functions.CPK_May2_Ca1 = Convert.ToDouble(String.Format("{0:0.000}", Functions.CPK2_May2_Ca1));

                }


                Functions.z2_Ca1++;
            
          
            
        }
        private void Calculate_CPK_MAY2_CA2()
        {
           
                Functions.STD_May2_Ca2 = 0.00;
                Functions.CPK_May2_Ca2 = 0.00;
                Functions.CPK1_May2_Ca2 = 0.00;
                Functions.CPK2_May2_Ca2 = 0.00;

                Functions.DSD_Cal_May2 = Functions.DSD_Binhra;
                Functions.DST_Cal_May2 = Functions.DST_Binhra;

                Functions.CDTC_Cal_May2 = Functions.TL_Axit_TC;
                Functions.CDTT_May2[Functions.z2_Ca2] = Functions.TL_Axit_May2;


                Functions.SUM_May2_Ca2 += Functions.CDTT_May2[Functions.z2_Ca2];
                Functions.SQUARESUMS_May2_Ca2 = Functions.SUM_May2_Ca2 * Functions.SUM_May2_Ca2;
                Functions.SUMSQUARES_May2_Ca2 += (Functions.CDTT_May2[Functions.z2_Ca2] * Functions.CDTT_May2[Functions.z2_Ca2]);

                Functions.NUMERATOR_May2_Ca2 = (Functions.z2_Ca2 * Functions.SUMSQUARES_May2_Ca2) - Functions.SQUARESUMS_May2_Ca2;

                Functions.DENOMINATOR_May2_Ca2 = Functions.z2_Ca2 * (Functions.z2_Ca2 - 1);

                Functions.AVE_May2_Ca2 = Convert.ToDouble(String.Format("{0:0.000}", Functions.SUM_May2_Ca2 / Functions.z2_Ca2));

                // VALUE = Math.Pow(CDTT[z]- AVE, 2)+ VALUE ;

                Functions.STD_May2_Ca2 = Convert.ToDouble(String.Format("{0:0.000}", Math.Sqrt(Functions.NUMERATOR_May2_Ca2 / Functions.DENOMINATOR_May2_Ca2)));

                Functions.CPK1_May2_Ca2 = (Functions.DST_Cal_May2 - Functions.DSD_Cal_May2) / (3 * Functions.STD_May2_Ca2);
                Functions.CPK2_May2_Ca2 = (Functions.AVE_May2_Ca2 - Functions.CDTC_Cal_May2 - Functions.DSD_Cal_May2) / (3 * Functions.STD_May2_Ca2);

                if (Functions.CPK1_May2_Ca2 < Functions.CPK2_May2_Ca2)
                {
                    Functions.CPK_May2_Ca2 = Convert.ToDouble(String.Format("{0:0.000}", Functions.CPK1_May2_Ca2));

                }
                else if (Functions.CPK2_May2_Ca2 < Functions.CPK1_May2_Ca2)
                {
                    Functions.CPK_May2_Ca2 = Convert.ToDouble(String.Format("{0:0.000}", Functions.CPK2_May2_Ca2));

                }


                Functions.z2_Ca2++;
            
            
               

            
        }
      
        
 
        private void send_mail()
        {
            
            try
            {
               StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"CC_Mail.txt"));

               
                
               
                sender_mail = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt")).ElementAt(0);
                password_mail = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt")).ElementAt(1);
                to_mail = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt")).ElementAt(2);
                subject_mail = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt")).ElementAt(3);
                acid_chuyen_mail = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt")).ElementAt(4);
                
               cc_mail  = read.ReadToEnd();
               read.Close();
                //cc_mail = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), @"CC_Mail.txt")).ElementAt(0);


                SmtpClient mailclient = new SmtpClient("smtp.gmail.com ", 587);  //   //  //    // vn.mail.klb.com.tw 
                mailclient.EnableSsl = true;
                mailclient.UseDefaultCredentials = false;
               
                mailclient.Credentials = new NetworkCredential(sender_mail.Trim(),password_mail.Trim());

               MailMessage message = new MailMessage(sender_mail.Trim(), to_mail.Trim());
             
                
                message.Subject = subject_mail.Trim();

                message.Body = "Mã số lô hàng :" + " " + Functions.MSLH + "\n"
                    + "Quy cách :" + " " + Functions.quy_cach + "\n"
                    + "Người thao tác :" + " " + Functions.nguoi_tt + "\n"
                    + "Số ca :" + " " + Functions.SoCa + "\n"
                    + "Acid chuyền :" + " " + acid_chuyen_mail.Trim() + "\n"
                    + "Nội dung : Trọng lượng acid không đạt";
                 

             //   message.Body = "a";
                //////////////////////////////////////////


                //Nếu có nhập Cc
                if (cc_mail.Trim() != "")
                {
                    //Cắt chuỗi Cc bằng dấu ";"
                    string[] cc = cc_mail.Trim().Split(';');
            
                    foreach (var _cc in cc )
                    {
                        message.CC.Add(_cc.ToString());
                    }
                

                }

                
                //////////////////////////////////////////

                mailclient.Send(message);

                MessageBox.Show("Mail đã được gửi đi", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
             

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi Mail thất bại", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
          

        }
       

    

        private void array_error_acid_wgt_out()  // AUTO BODY MESSAGE SEND TO LELONG MAIL
        {
            if (Functions.Binhloi_o1_May1 != 0)
            {
                Functions.may1_baoloi_o1 = ":" +" "+ Functions.Binhloi_o1_May1.ToString();
            }
            else
            {
                Functions.may1_baoloi_o1 = null;
            }
            if (Functions.Binhloi_o2_May1 != 0)
            {
                Functions.may1_baoloi_o2 = " " + "/" + " " + Functions.Binhloi_o2_May1.ToString();
            }
            else
            {
                Functions.may1_baoloi_o2 = null;
            }
            if (Functions.Binhloi_o3_May1 != 0)
            {
                Functions.may1_baoloi_o3 = " " + "/" + " " + Functions.Binhloi_o3_May1.ToString();
            }
            else
            {
                Functions.may1_baoloi_o3 = null;
            }
            if (Functions.Binhloi_o4_May1 != 0)
            {
                Functions.may1_baoloi_o4 = " " + "/" + " " + Functions.Binhloi_o4_May1.ToString();
            }
            else
            {
                Functions.may1_baoloi_o4 = null;
            }
            if (Functions.Binhloi_o5_May1 != 0)
            {
                Functions.may1_baoloi_o5 = " " + "/" + " " + Functions.Binhloi_o5_May1.ToString();
            }
            else
            {
                Functions.may1_baoloi_o5 = null;
            }


            ///////////////////////////////////////////////////////////////////////

            if (Functions.Binhloi_o1_May2 != 0)
            {
                Functions.may2_baoloi_o1 = ":" + " " + Functions.Binhloi_o1_May2.ToString();
            }
            else
            {
                Functions.may2_baoloi_o1 = null;
            }
            if (Functions.Binhloi_o2_May2 != 0)
            {
                Functions.may2_baoloi_o2 = " " + "/" + " " + Functions.Binhloi_o2_May2.ToString();
            }
            else
            {
                Functions.may2_baoloi_o2 = null;
            }
            if (Functions.Binhloi_o3_May2 != 0)
            {
                Functions.may2_baoloi_o3 = " " + "/" + " " + Functions.Binhloi_o3_May2.ToString();
            }
            else
            {
                Functions.may2_baoloi_o3 = null;
            }
            if (Functions.Binhloi_o4_May2 != 0)
            {
                Functions.may2_baoloi_o4 = " " + "/" + " " + Functions.Binhloi_o4_May2.ToString();
            }
            else
            {
                Functions.may2_baoloi_o4 = null;
            }
            if (Functions.Binhloi_o5_May2 != 0)
            {
                Functions.may2_baoloi_o5 = " " + "/" + " " + Functions.Binhloi_o5_May2.ToString();
            }
            else
            {
                Functions.may2_baoloi_o5 = null;
            }
        }                                
        private void send_mail_KLB()             // SEND MAIL FUNCTION TO LELONG MAIL
        {
            try
            {

                StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"CC_Mail.txt"));

                sender_mail = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt")).ElementAt(0);
                password_mail = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt")).ElementAt(1);
                to_mail = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt")).ElementAt(2);
                subject_mail = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt")).ElementAt(3);
                acid_chuyen_mail = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt")).ElementAt(4);

                cc_mail = read.ReadToEnd();
                read.Close();

                array_error_acid_wgt_out();



                ////////////////////////////////////////////////////


                if (Functions.TongBinhLoi_May1 != 0)
                {
                    Functions.may1_baoloi = "Máy 1 có" + " " + Functions.TongBinhLoi_May1 + " " + "Bình acid lỗi" + Functions.may1_baoloi_o1 + Functions.may1_baoloi_o2 + Functions.may1_baoloi_o3 + Functions.may1_baoloi_o4 + Functions.may1_baoloi_o5;
                }
                else
                {
                    Functions.may1_baoloi = "Máy 1 có 0 bình Acid lỗi";

                }



                if (Functions.TongBinhLoi_May2 != 0)
                {
                    Functions.may2_baoloi = "Máy 2 có" + " " + Functions.TongBinhLoi_May2 + " " + "Bình acid lỗi" + Functions.may2_baoloi_o1 + Functions.may2_baoloi_o2 + Functions.may2_baoloi_o3 + Functions.may2_baoloi_o4 + Functions.may2_baoloi_o5;
                }
                else
                {
                    Functions.may2_baoloi = "Máy 2 có 0 bình Acid lỗi";

                }

                
                MailMessage message = new MailMessage();
                message.From = new MailAddress("vn_wfs_mail@mail.klb.com.tw", "vn_wfs_mail"); // MAIL GỬI  //"vn_wfs_mail@mail.klb.com.tw","vn_wfs_mail"
                message.To.Add(to_mail.Trim());   // MAIL NHẬN
                message.Subject = subject_mail.Trim();

                // message.IsBodyHtml = true;

                message.Body = "Mã số lô hàng :" + " " + Functions.MSLH + "\n"
                    + "Quy cách :" + " " + Functions.quy_cach + "\n"
                    + "Người thao tác :" + " " + Functions.nguoi_tt + "\n"
                    + "Ca làm việc :" + " " + Functions.SoCa + "\n"
                    + "Acid chuyền :" + " " + acid_chuyen_mail.Trim() + "\n"
                    + "Nội dung :" + " " + "Trọng lượng Acid tiêu chuẩn :" + " " + Functions.TL_Axit_TC + "\n"
                    + "         (" + " " + "LCL :" + " " + Functions.DSD_Binhra + " " + "-" + " " + "UCL :"
                    + " " + Functions.DST_Binhra + " " + "-" + " " + "LSL :" + Functions.DSL_Binhra + " " + "-" + " " + "USL :" + Functions.DSH_Binhra + ")" + "\n"
                    + "Báo cáo : " + " " + Functions.TongBinhLoi_2May + " " + "Bình Acid bị lỗi." + "\n"
                    + Functions.may1_baoloi + "\n"
                    + Functions.may2_baoloi + "\n";

                // message.Body = "a";


                SmtpClient mailclient = new SmtpClient();
                mailclient.Host = "vn.mail.klb.com.tw"; //   smtp.gmail.com
                mailclient.Port = 25;

                mailclient.EnableSsl = false;
                //  mailclient.UseDefaultCredentials = false;
                mailclient.Credentials = new NetworkCredential(sender_mail.Trim(), password_mail.Trim()); // MAIL ĐĂNG NHẬP     "qatechautomation@gmail.com", "asmeautomation"


                //Nếu có nhập Cc
                if (cc_mail.Trim() != "")
                {
                    //Cắt chuỗi Cc bằng dấu ";"
                   
                    string[] bb = cc_mail.Trim().Split(';');

                   
                    foreach (var _bb in bb)
                    {
                        message.CC.Add(_bb.ToString());
                    }

                }


                //////////////////////////////////////////
                mailclient.Send(message);


            //    MessageBox.Show("Mail đã được gửi đi", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
             

            }


            catch (Exception ex)
            {
             //   MessageBox.Show("Gửi Mail thất bại", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }
    
        

        private void creat_foder()               // CREATE FOLDER SAVE EXCEL FILE
            // tao folder chua file excel 
        {
             
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));
            filepath = read.ReadToEnd();
         
            read.Close();

            DateTime tn = DateTime.Now;
            string time = tn.ToString("dd-MM-yyyy");

            string Location = Path.GetFullPath(filepath);

            string path_Ca1 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", time, "CA 1");

            string path_Ca2 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", time, "CA 2");

            string path_Ca1_May1 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", time, "CA 1", "MÁY 1");

            string path_Ca1_May2 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", time, "CA 1", "MÁY 2");

            string path_Ca2_May1 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", time, "CA 2", "MÁY 1");

            string path_Ca2_May2 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", time, "CA 2", "MÁY 2");

            //DateTime.Parse(Functions.date).ToString("yyyy-MM-dd")

            if (!Directory.Exists(path_Ca1_May1))
            {
                Directory.CreateDirectory(path_Ca1_May1);
            }
             if (!Directory.Exists(path_Ca1_May2))
            {
                Directory.CreateDirectory(path_Ca1_May2);
            }

             if (!Directory.Exists(path_Ca2_May1))
            {
                Directory.CreateDirectory(path_Ca2_May1);
            }
             if (!Directory.Exists(path_Ca2_May2))
            {
                Directory.CreateDirectory(path_Ca2_May2);

            }
           
          

        }         
        /*
         private void datagridview_may1_Ca1()
         {

             tbl_baocaodulieu_May1_Ca1.Clear();
             bcdl_dataGridView_May1_Ca1.DataSource = null;
             bcdl_dataGridView_May1_Ca1.Refresh();
             bcdl_dataGridView_May1_Ca1.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
             bcdl_dataGridView_May1_Ca1.EnableHeadersVisualStyles = false;
             DateTime tn = DateTime.Now;

             string time = tn.ToString("yyyy-MM-dd");

             SQLiteConnection con = new SQLiteConnection();
             con.ConnectionString = ketnoisql.str;
             con.Open();
             SQLiteCommand cmd = new SQLiteCommand();
             cmd.Connection = con;



             string sql = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay1 , TLBinhSauMay1, TLAcidMay1, TLAcidTC ,DSD, DST, DSL,DSH, PhanLoaiMay1, STDMay1, AVEMay1, CPKMay1 FROM quanlymanhinhmay1 WHERE SoCa = @soca AND Ngay =@ngay";

             cmd = new SQLiteCommand(sql, con);
             SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);
             cmd.Parameters.AddWithValue("@soca", 1);
             cmd.Parameters.AddWithValue("@ngay", time);



             dap.Fill(tbl_baocaodulieu_May1_Ca1);

             ///////////////////////////////////////
             DataView dv = new DataView(tbl_baocaodulieu_May1_Ca1);
             dv.Sort = "Stt";
             tbl_baocaodulieu_May1_Ca1 = dv.ToTable();
             bcdl_dataGridView_May1_Ca1.DataSource = tbl_baocaodulieu_May1_Ca1;

             ////////////////////////////////////////////////////////


             bcdl_dataGridView_May1_Ca1.Columns[0].HeaderText = "Số thứ tự";
             bcdl_dataGridView_May1_Ca1.Columns[1].HeaderText = "Thời gian";
             bcdl_dataGridView_May1_Ca1.Columns[2].HeaderText = "Mã số lô hàng";
             bcdl_dataGridView_May1_Ca1.Columns[3].HeaderText = "Quy cách";
             bcdl_dataGridView_May1_Ca1.Columns[4].HeaderText = "Người thao tác";
             bcdl_dataGridView_May1_Ca1.Columns[5].HeaderText = "Số Ca";
             bcdl_dataGridView_May1_Ca1.Columns[6].HeaderText = "TL Bình Đầu";
             bcdl_dataGridView_May1_Ca1.Columns[7].HeaderText = "TL Bình Sau";
             bcdl_dataGridView_May1_Ca1.Columns[8].HeaderText = "TL ACID";
             bcdl_dataGridView_May1_Ca1.Columns[9].HeaderText = "TL ACID TC";
             bcdl_dataGridView_May1_Ca1.Columns[10].HeaderText = "LCL";
             bcdl_dataGridView_May1_Ca1.Columns[11].HeaderText = "UCL";
             bcdl_dataGridView_May1_Ca1.Columns[12].HeaderText = "LSL";
             bcdl_dataGridView_May1_Ca1.Columns[13].HeaderText = "USL";
             bcdl_dataGridView_May1_Ca1.Columns[14].HeaderText = "Phân Loại";
             bcdl_dataGridView_May1_Ca1.Columns[15].HeaderText = "STD";
             bcdl_dataGridView_May1_Ca1.Columns[16].HeaderText = "AVE";
             bcdl_dataGridView_May1_Ca1.Columns[17].HeaderText = "CPK";



             bcdl_dataGridView_May1_Ca1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



             if (bcdl_dataGridView_May1_Ca1.ColumnCount > 1)
             {
                 for (int i = 0; i < bcdl_dataGridView_May1_Ca1.ColumnCount - 1; i++)
                     bcdl_dataGridView_May1_Ca1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                 bcdl_dataGridView_May1_Ca1.Columns[bcdl_dataGridView_May1_Ca1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             }

             if (bcdl_dataGridView_May1_Ca1.ColumnCount == 1)
             {
                 bcdl_dataGridView_May1_Ca1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             }
             bcdl_dataGridView_May1_Ca1.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
             bcdl_dataGridView_May1_Ca1.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

             int cellnum = 0;
             int rownum = 0;
             foreach (DataGridViewRow row in bcdl_dataGridView_May1_Ca1.Rows)
             {
                 cellnum = cellnum + 1;
                 bcdl_dataGridView_May1_Ca1.Rows[rownum].Cells[0].Value = cellnum;
                 rownum = rownum + 1;
             }
             bcdl_dataGridView_May1_Ca1.Refresh();
             con.Close();

         }

         private void datagridview_may2_Ca1()
         {

             tbl_baocaodulieu_May2_Ca1.Clear();
             bcdl_dataGridView_May2_Ca1.DataSource = null;
             bcdl_dataGridView_May2_Ca1.Refresh();
             bcdl_dataGridView_May2_Ca1.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
             bcdl_dataGridView_May2_Ca1.EnableHeadersVisualStyles = false;
             DateTime tn = DateTime.Now;

             string time = tn.ToString("yyyy-MM-dd");

             SQLiteConnection con = new SQLiteConnection();
             con.ConnectionString = ketnoisql.str;
             con.Open();
             SQLiteCommand cmd = new SQLiteCommand();
             cmd.Connection = con;



             string sql = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay2 , TLBinhSauMay2, TLAcidMay2, TLAcidTC ,DSD, DST, DSL,DSH, PhanLoaiMay2, STDMay2, AVEMay2, CPKMay2 FROM quanlymanhinhmay2 WHERE SoCa = @soca AND Ngay =@ngay";

             cmd = new SQLiteCommand(sql, con);
             SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);
             cmd.Parameters.AddWithValue("@soca", 1);
             cmd.Parameters.AddWithValue("@ngay", time);



             dap.Fill(tbl_baocaodulieu_May2_Ca1);

             ///////////////////////////////////////
             DataView dv = new DataView(tbl_baocaodulieu_May2_Ca1);
             dv.Sort = "Stt";
             tbl_baocaodulieu_May2_Ca1 = dv.ToTable();
             bcdl_dataGridView_May2_Ca1.DataSource = tbl_baocaodulieu_May2_Ca1;

             ////////////////////////////////////////////////////////


             bcdl_dataGridView_May2_Ca1.Columns[0].HeaderText = "Số thứ tự";
             bcdl_dataGridView_May2_Ca1.Columns[1].HeaderText = "Thời gian";
             bcdl_dataGridView_May2_Ca1.Columns[2].HeaderText = "Mã số lô hàng";
             bcdl_dataGridView_May2_Ca1.Columns[3].HeaderText = "Quy cách";
             bcdl_dataGridView_May2_Ca1.Columns[4].HeaderText = "Người thao tác";
             bcdl_dataGridView_May2_Ca1.Columns[5].HeaderText = "Số Ca";
             bcdl_dataGridView_May2_Ca1.Columns[6].HeaderText = "TL Bình Đầu";
             bcdl_dataGridView_May2_Ca1.Columns[7].HeaderText = "TL Bình Sau";
             bcdl_dataGridView_May2_Ca1.Columns[8].HeaderText = "TL ACID";
             bcdl_dataGridView_May2_Ca1.Columns[9].HeaderText = "TL ACID TC";
             bcdl_dataGridView_May2_Ca1.Columns[10].HeaderText = "LCL";
             bcdl_dataGridView_May2_Ca1.Columns[11].HeaderText = "UCL";
             bcdl_dataGridView_May2_Ca1.Columns[12].HeaderText = "LSL";
             bcdl_dataGridView_May2_Ca1.Columns[13].HeaderText = "USL";
             bcdl_dataGridView_May2_Ca1.Columns[14].HeaderText = "Phân Loại";
             bcdl_dataGridView_May2_Ca1.Columns[15].HeaderText = "STD";
             bcdl_dataGridView_May2_Ca1.Columns[16].HeaderText = "AVE";
             bcdl_dataGridView_May2_Ca1.Columns[17].HeaderText = "CPK";



             bcdl_dataGridView_May2_Ca1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



             if (bcdl_dataGridView_May2_Ca1.ColumnCount > 1)
             {
                 for (int i = 0; i < bcdl_dataGridView_May2_Ca1.ColumnCount - 1; i++)
                     bcdl_dataGridView_May2_Ca1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                 bcdl_dataGridView_May2_Ca1.Columns[bcdl_dataGridView_May2_Ca1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             }

             if (bcdl_dataGridView_May2_Ca1.ColumnCount == 1)
             {
                 bcdl_dataGridView_May2_Ca1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             }
             bcdl_dataGridView_May2_Ca1.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
             bcdl_dataGridView_May2_Ca1.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

             int cellnum = 0;
             int rownum = 0;
             foreach (DataGridViewRow row in bcdl_dataGridView_May2_Ca1.Rows)
             {
                 cellnum = cellnum + 1;
                 bcdl_dataGridView_May2_Ca1.Rows[rownum].Cells[0].Value = cellnum;
                 rownum = rownum + 1;
             }
             bcdl_dataGridView_May2_Ca1.Refresh();
             con.Close();

         }

         private void datagridview_may1_Ca2()
         {

             tbl_baocaodulieu_May1_Ca2.Clear();
             bcdl_dataGridView_May1_Ca2.DataSource = null;
             bcdl_dataGridView_May1_Ca2.Refresh();
             bcdl_dataGridView_May1_Ca2.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
             bcdl_dataGridView_May1_Ca2.EnableHeadersVisualStyles = false;
             DateTime tn = DateTime.Now;

             string time = tn.ToString("yyyy-MM-dd");

             SQLiteConnection con = new SQLiteConnection();
             con.ConnectionString = ketnoisql.str;
             con.Open();
             SQLiteCommand cmd = new SQLiteCommand();
             cmd.Connection = con;



             string sql = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay1 , TLBinhSauMay1, TLAcidMay1, TLAcidTC ,DSD, DST, DSL,DSH, PhanLoaiMay1, STDMay1, AVEMay1, CPKMay1 FROM quanlymanhinhmay1 WHERE SoCa = @soca AND Ngay =@ngay";

             cmd = new SQLiteCommand(sql, con);
             SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);
             cmd.Parameters.AddWithValue("@soca", 2);
             cmd.Parameters.AddWithValue("@ngay", time);



             dap.Fill(tbl_baocaodulieu_May1_Ca2);

             ///////////////////////////////////////
             DataView dv = new DataView(tbl_baocaodulieu_May1_Ca2);
             dv.Sort = "Stt";
             tbl_baocaodulieu_May1_Ca2 = dv.ToTable();
             bcdl_dataGridView_May1_Ca2.DataSource = tbl_baocaodulieu_May1_Ca2;

             ////////////////////////////////////////////////////////


             bcdl_dataGridView_May1_Ca2.Columns[0].HeaderText = "Số thứ tự";
             bcdl_dataGridView_May1_Ca2.Columns[1].HeaderText = "Thời gian";
             bcdl_dataGridView_May1_Ca2.Columns[2].HeaderText = "Mã số lô hàng";
             bcdl_dataGridView_May1_Ca2.Columns[3].HeaderText = "Quy cách";
             bcdl_dataGridView_May1_Ca2.Columns[4].HeaderText = "Người thao tác";
             bcdl_dataGridView_May1_Ca2.Columns[5].HeaderText = "Số Ca";
             bcdl_dataGridView_May1_Ca2.Columns[6].HeaderText = "TL Bình Đầu";
             bcdl_dataGridView_May1_Ca2.Columns[7].HeaderText = "TL Bình Sau";
             bcdl_dataGridView_May1_Ca2.Columns[8].HeaderText = "TL ACID";
             bcdl_dataGridView_May1_Ca2.Columns[9].HeaderText = "TL ACID TC";
             bcdl_dataGridView_May1_Ca2.Columns[10].HeaderText = "LCL";
             bcdl_dataGridView_May1_Ca2.Columns[11].HeaderText = "UCL";
             bcdl_dataGridView_May1_Ca2.Columns[12].HeaderText = "LSL";
             bcdl_dataGridView_May1_Ca2.Columns[13].HeaderText = "USL";
             bcdl_dataGridView_May1_Ca2.Columns[14].HeaderText = "Phân Loại";
             bcdl_dataGridView_May1_Ca2.Columns[15].HeaderText = "STD";
             bcdl_dataGridView_May1_Ca2.Columns[16].HeaderText = "AVE";
             bcdl_dataGridView_May1_Ca2.Columns[17].HeaderText = "CPK";



             bcdl_dataGridView_May1_Ca2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1_Ca2.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



             if (bcdl_dataGridView_May1_Ca2.ColumnCount > 1)
             {
                 for (int i = 0; i < bcdl_dataGridView_May1_Ca2.ColumnCount - 1; i++)
                     bcdl_dataGridView_May1_Ca2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                 bcdl_dataGridView_May1_Ca2.Columns[bcdl_dataGridView_May1_Ca2.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             }

             if (bcdl_dataGridView_May1_Ca2.ColumnCount == 1)
             {
                 bcdl_dataGridView_May1_Ca2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             }
             bcdl_dataGridView_May1_Ca2.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
             bcdl_dataGridView_May1_Ca2.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

             int cellnum = 0;
             int rownum = 0;
             foreach (DataGridViewRow row in bcdl_dataGridView_May1_Ca2.Rows)
             {
                 cellnum = cellnum + 1;
                 bcdl_dataGridView_May1_Ca2.Rows[rownum].Cells[0].Value = cellnum;
                 rownum = rownum + 1;
             }
             bcdl_dataGridView_May1_Ca2.Refresh();
             con.Close();

         }

         private void datagridview_may2_Ca2()
         {

             tbl_baocaodulieu_May2_Ca2.Clear();
             bcdl_dataGridView_May2_Ca2.DataSource = null;
             bcdl_dataGridView_May2_Ca2.Refresh();
             bcdl_dataGridView_May2_Ca2.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
             bcdl_dataGridView_May2_Ca2.EnableHeadersVisualStyles = false;
             DateTime tn = DateTime.Now;

             string time = tn.ToString("yyyy-MM-dd");

             SQLiteConnection con = new SQLiteConnection();
             con.ConnectionString = ketnoisql.str;
             con.Open();
             SQLiteCommand cmd = new SQLiteCommand();
             cmd.Connection = con;



             string sql = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay2 , TLBinhSauMay2, TLAcidMay2, TLAcidTC ,DSD, DST, DSL,DSH, PhanLoaiMay2, STDMay2, AVEMay2, CPKMay2 FROM quanlymanhinhmay2 WHERE SoCa = @soca AND Ngay =@ngay";

             cmd = new SQLiteCommand(sql, con);
             SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);
             cmd.Parameters.AddWithValue("@soca", 2);
             cmd.Parameters.AddWithValue("@ngay", time);



             dap.Fill(tbl_baocaodulieu_May2_Ca2);

             ///////////////////////////////////////
             DataView dv = new DataView(tbl_baocaodulieu_May2_Ca2);
             dv.Sort = "Stt";
             tbl_baocaodulieu_May2_Ca2 = dv.ToTable();
             bcdl_dataGridView_May2_Ca2.DataSource = tbl_baocaodulieu_May2_Ca2;

             ////////////////////////////////////////////////////////


             bcdl_dataGridView_May2_Ca2.Columns[0].HeaderText = "Số thứ tự";
             bcdl_dataGridView_May2_Ca2.Columns[1].HeaderText = "Thời gian";
             bcdl_dataGridView_May2_Ca2.Columns[2].HeaderText = "Mã số lô hàng";
             bcdl_dataGridView_May2_Ca2.Columns[3].HeaderText = "Quy cách";
             bcdl_dataGridView_May2_Ca2.Columns[4].HeaderText = "Người thao tác";
             bcdl_dataGridView_May2_Ca2.Columns[5].HeaderText = "Số Ca";
             bcdl_dataGridView_May2_Ca2.Columns[6].HeaderText = "TL Bình Đầu";
             bcdl_dataGridView_May2_Ca2.Columns[7].HeaderText = "TL Bình Sau";
             bcdl_dataGridView_May2_Ca2.Columns[8].HeaderText = "TL ACID";
             bcdl_dataGridView_May2_Ca2.Columns[9].HeaderText = "TL ACID TC";
             bcdl_dataGridView_May2_Ca2.Columns[10].HeaderText = "LCL";
             bcdl_dataGridView_May2_Ca2.Columns[11].HeaderText = "UCL";
             bcdl_dataGridView_May2_Ca2.Columns[12].HeaderText = "LSL";
             bcdl_dataGridView_May2_Ca2.Columns[13].HeaderText = "USL";
             bcdl_dataGridView_May2_Ca2.Columns[14].HeaderText = "Phân Loại";
             bcdl_dataGridView_May2_Ca2.Columns[15].HeaderText = "STD";
             bcdl_dataGridView_May2_Ca2.Columns[16].HeaderText = "AVE";
             bcdl_dataGridView_May2_Ca2.Columns[17].HeaderText = "CPK";



             bcdl_dataGridView_May2_Ca2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2_Ca2.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



             if (bcdl_dataGridView_May2_Ca2.ColumnCount > 1)
             {
                 for (int i = 0; i < bcdl_dataGridView_May2_Ca2.ColumnCount - 1; i++)
                     bcdl_dataGridView_May2_Ca2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                 bcdl_dataGridView_May2_Ca2.Columns[bcdl_dataGridView_May2_Ca2.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             }

             if (bcdl_dataGridView_May2_Ca2.ColumnCount == 1)
             {
                 bcdl_dataGridView_May2_Ca2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             }
             bcdl_dataGridView_May2_Ca2.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
             bcdl_dataGridView_May2_Ca2.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

             int cellnum = 0;
             int rownum = 0;
             foreach (DataGridViewRow row in bcdl_dataGridView_May2_Ca2.Rows)
             {
                 cellnum = cellnum + 1;
                 bcdl_dataGridView_May2_Ca2.Rows[rownum].Cells[0].Value = cellnum;
                 rownum = rownum + 1;
             }
             bcdl_dataGridView_May2_Ca2.Refresh();
             con.Close();

         }
         */
        private void datagridview_may1_Ca1() // DATAGRIDVIEW MAY 1 SHIFT 1
        {

            tbl_baocaodulieu_May1_Ca1.Clear();
            bcdl_dataGridView_May1_Ca1.DataSource = null;
            bcdl_dataGridView_May1_Ca1.Refresh();
            bcdl_dataGridView_May1_Ca1.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
            bcdl_dataGridView_May1_Ca1.EnableHeadersVisualStyles = false;
            DateTime tn = DateTime.Now;

            string time = tn.ToString("yyyy-MM-dd");

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;



            string sql = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay1 , TLBinhSauMay1, TLAcidMay1, TLAcidTC ,DSD, DST, DSL,DSH, PhanLoaiMay1, STDMay1, AVEMay1, CPKMay1 FROM quanlymanhinhmay1 WHERE SoCa = @soca AND Ngay =@ngay";

            cmd = new SQLiteCommand(sql, con);
            SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@soca", 1);
            cmd.Parameters.AddWithValue("@ngay", time);



            dap.Fill(tbl_baocaodulieu_May1_Ca1);

            ///////////////////////////////////////
            DataView dv = new DataView(tbl_baocaodulieu_May1_Ca1);
            dv.Sort = "Stt";
            tbl_baocaodulieu_May1_Ca1 = dv.ToTable();
            bcdl_dataGridView_May1_Ca1.DataSource = tbl_baocaodulieu_May1_Ca1;

            ////////////////////////////////////////////////////////


            bcdl_dataGridView_May1_Ca1.Columns[0].HeaderText = "Số thứ tự";
            bcdl_dataGridView_May1_Ca1.Columns[1].HeaderText = "Thời gian";
            bcdl_dataGridView_May1_Ca1.Columns[2].HeaderText = "Mã số lô hàng";
            bcdl_dataGridView_May1_Ca1.Columns[3].HeaderText = "Quy cách";
            bcdl_dataGridView_May1_Ca1.Columns[4].HeaderText = "Người thao tác";
            bcdl_dataGridView_May1_Ca1.Columns[5].HeaderText = "Số Ca";
            bcdl_dataGridView_May1_Ca1.Columns[6].HeaderText = "TL Bình Đầu";
            bcdl_dataGridView_May1_Ca1.Columns[7].HeaderText = "TL Bình Sau";
            bcdl_dataGridView_May1_Ca1.Columns[8].HeaderText = "TL ACID";
            bcdl_dataGridView_May1_Ca1.Columns[9].HeaderText = "TL ACID TC";
            bcdl_dataGridView_May1_Ca1.Columns[10].HeaderText = "LCL";
            bcdl_dataGridView_May1_Ca1.Columns[11].HeaderText = "UCL";
            bcdl_dataGridView_May1_Ca1.Columns[12].HeaderText = "LSL";
            bcdl_dataGridView_May1_Ca1.Columns[13].HeaderText = "USL";
            bcdl_dataGridView_May1_Ca1.Columns[14].HeaderText = "Phân Loại";
            bcdl_dataGridView_May1_Ca1.Columns[15].HeaderText = "STD";
            bcdl_dataGridView_May1_Ca1.Columns[16].HeaderText = "AVE";
            bcdl_dataGridView_May1_Ca1.Columns[17].HeaderText = "CPK";



            bcdl_dataGridView_May1_Ca1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            if (bcdl_dataGridView_May1_Ca1.ColumnCount > 1)
            {
                for (int i = 0; i < bcdl_dataGridView_May1_Ca1.ColumnCount - 1; i++)
                    bcdl_dataGridView_May1_Ca1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                bcdl_dataGridView_May1_Ca1.Columns[bcdl_dataGridView_May1_Ca1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (bcdl_dataGridView_May1_Ca1.ColumnCount == 1)
            {
                bcdl_dataGridView_May1_Ca1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            bcdl_dataGridView_May1_Ca1.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            bcdl_dataGridView_May1_Ca1.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

            int cellnum = 0;
            int rownum = 0;
            foreach (DataGridViewRow row in bcdl_dataGridView_May1_Ca1.Rows)
            {
                cellnum = cellnum + 1;
                bcdl_dataGridView_May1_Ca1.Rows[rownum].Cells[0].Value = cellnum;
                rownum = rownum + 1;
            }
            bcdl_dataGridView_May1_Ca1.Refresh();
            con.Close();

        }  

        private void datagridview_may2_Ca1() // DATAGRIDVIEW MAY 2 SHIFT 1
        {

            tbl_baocaodulieu_May2_Ca1.Clear();
            bcdl_dataGridView_May2_Ca1.DataSource = null;
            bcdl_dataGridView_May2_Ca1.Refresh();
            bcdl_dataGridView_May2_Ca1.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
            bcdl_dataGridView_May2_Ca1.EnableHeadersVisualStyles = false;
            DateTime tn = DateTime.Now;

            string time = tn.ToString("yyyy-MM-dd");

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;



            string sql = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay2 , TLBinhSauMay2, TLAcidMay2, TLAcidTC ,DSD, DST, DSL,DSH, PhanLoaiMay2, STDMay2, AVEMay2, CPKMay2 FROM quanlymanhinhmay2 WHERE SoCa = @soca AND Ngay =@ngay";

            cmd = new SQLiteCommand(sql, con);
            SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@soca", 1);
            cmd.Parameters.AddWithValue("@ngay", time);



            dap.Fill(tbl_baocaodulieu_May2_Ca1);

            ///////////////////////////////////////
            DataView dv = new DataView(tbl_baocaodulieu_May2_Ca1);
            dv.Sort = "Stt";
            tbl_baocaodulieu_May2_Ca1 = dv.ToTable();
            bcdl_dataGridView_May2_Ca1.DataSource = tbl_baocaodulieu_May2_Ca1;

            ////////////////////////////////////////////////////////


            bcdl_dataGridView_May2_Ca1.Columns[0].HeaderText = "Số thứ tự";
            bcdl_dataGridView_May2_Ca1.Columns[1].HeaderText = "Thời gian";
            bcdl_dataGridView_May2_Ca1.Columns[2].HeaderText = "Mã số lô hàng";
            bcdl_dataGridView_May2_Ca1.Columns[3].HeaderText = "Quy cách";
            bcdl_dataGridView_May2_Ca1.Columns[4].HeaderText = "Người thao tác";
            bcdl_dataGridView_May2_Ca1.Columns[5].HeaderText = "Số Ca";
            bcdl_dataGridView_May2_Ca1.Columns[6].HeaderText = "TL Bình Đầu";
            bcdl_dataGridView_May2_Ca1.Columns[7].HeaderText = "TL Bình Sau";
            bcdl_dataGridView_May2_Ca1.Columns[8].HeaderText = "TL ACID";
            bcdl_dataGridView_May2_Ca1.Columns[9].HeaderText = "TL ACID TC";
            bcdl_dataGridView_May2_Ca1.Columns[10].HeaderText = "LCL";
            bcdl_dataGridView_May2_Ca1.Columns[11].HeaderText = "UCL";
            bcdl_dataGridView_May2_Ca1.Columns[12].HeaderText = "LSL";
            bcdl_dataGridView_May2_Ca1.Columns[13].HeaderText = "USL";
            bcdl_dataGridView_May2_Ca1.Columns[14].HeaderText = "Phân Loại";
            bcdl_dataGridView_May2_Ca1.Columns[15].HeaderText = "STD";
            bcdl_dataGridView_May2_Ca1.Columns[16].HeaderText = "AVE";
            bcdl_dataGridView_May2_Ca1.Columns[17].HeaderText = "CPK";



            bcdl_dataGridView_May2_Ca1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            if (bcdl_dataGridView_May2_Ca1.ColumnCount > 1)
            {
                for (int i = 0; i < bcdl_dataGridView_May2_Ca1.ColumnCount - 1; i++)
                    bcdl_dataGridView_May2_Ca1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                bcdl_dataGridView_May2_Ca1.Columns[bcdl_dataGridView_May2_Ca1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (bcdl_dataGridView_May2_Ca1.ColumnCount == 1)
            {
                bcdl_dataGridView_May2_Ca1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            bcdl_dataGridView_May2_Ca1.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            bcdl_dataGridView_May2_Ca1.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

            int cellnum = 0;
            int rownum = 0;
            foreach (DataGridViewRow row in bcdl_dataGridView_May2_Ca1.Rows)
            {
                cellnum = cellnum + 1;
                bcdl_dataGridView_May2_Ca1.Rows[rownum].Cells[0].Value = cellnum;
                rownum = rownum + 1;
            }
            bcdl_dataGridView_May2_Ca1.Refresh();
            con.Close();

        }

        private void datagridview_may1_Ca2() // DATAGRIDVIEW MAY 1 SHIFT 2
        {

            tbl_baocaodulieu_May1_Ca2.Clear();
            bcdl_dataGridView_May1_Ca2.DataSource = null;
            bcdl_dataGridView_May1_Ca2.Refresh();
            bcdl_dataGridView_May1_Ca2.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
            bcdl_dataGridView_May1_Ca2.EnableHeadersVisualStyles = false;
            DateTime tn = DateTime.Now;

            string time = tn.ToString("yyyy-MM-dd");

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;



            string sql = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay1 , TLBinhSauMay1, TLAcidMay1, TLAcidTC ,DSD, DST, DSL,DSH, PhanLoaiMay1, STDMay1, AVEMay1, CPKMay1 FROM quanlymanhinhmay1 WHERE SoCa = @soca AND Ngay =@ngay";

            cmd = new SQLiteCommand(sql, con);
            SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@soca", 2);
            cmd.Parameters.AddWithValue("@ngay", time);



            dap.Fill(tbl_baocaodulieu_May1_Ca2);

            ///////////////////////////////////////
            DataView dv = new DataView(tbl_baocaodulieu_May1_Ca2);
            dv.Sort = "Stt";
            tbl_baocaodulieu_May1_Ca2 = dv.ToTable();
            bcdl_dataGridView_May1_Ca2.DataSource = tbl_baocaodulieu_May1_Ca2;

            ////////////////////////////////////////////////////////


            bcdl_dataGridView_May1_Ca2.Columns[0].HeaderText = "Số thứ tự";
            bcdl_dataGridView_May1_Ca2.Columns[1].HeaderText = "Thời gian";
            bcdl_dataGridView_May1_Ca2.Columns[2].HeaderText = "Mã số lô hàng";
            bcdl_dataGridView_May1_Ca2.Columns[3].HeaderText = "Quy cách";
            bcdl_dataGridView_May1_Ca2.Columns[4].HeaderText = "Người thao tác";
            bcdl_dataGridView_May1_Ca2.Columns[5].HeaderText = "Số Ca";
            bcdl_dataGridView_May1_Ca2.Columns[6].HeaderText = "TL Bình Đầu";
            bcdl_dataGridView_May1_Ca2.Columns[7].HeaderText = "TL Bình Sau";
            bcdl_dataGridView_May1_Ca2.Columns[8].HeaderText = "TL ACID";
            bcdl_dataGridView_May1_Ca2.Columns[9].HeaderText = "TL ACID TC";
            bcdl_dataGridView_May1_Ca2.Columns[10].HeaderText = "LCL";
            bcdl_dataGridView_May1_Ca2.Columns[11].HeaderText = "UCL";
            bcdl_dataGridView_May1_Ca2.Columns[12].HeaderText = "LSL";
            bcdl_dataGridView_May1_Ca2.Columns[13].HeaderText = "USL";
            bcdl_dataGridView_May1_Ca2.Columns[14].HeaderText = "Phân Loại";
            bcdl_dataGridView_May1_Ca2.Columns[15].HeaderText = "STD";
            bcdl_dataGridView_May1_Ca2.Columns[16].HeaderText = "AVE";
            bcdl_dataGridView_May1_Ca2.Columns[17].HeaderText = "CPK";



            bcdl_dataGridView_May1_Ca2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May1_Ca2.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            if (bcdl_dataGridView_May1_Ca2.ColumnCount > 1)
            {
                for (int i = 0; i < bcdl_dataGridView_May1_Ca2.ColumnCount - 1; i++)
                    bcdl_dataGridView_May1_Ca2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                bcdl_dataGridView_May1_Ca2.Columns[bcdl_dataGridView_May1_Ca2.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (bcdl_dataGridView_May1_Ca2.ColumnCount == 1)
            {
                bcdl_dataGridView_May1_Ca2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            bcdl_dataGridView_May1_Ca2.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            bcdl_dataGridView_May1_Ca2.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

            int cellnum = 0;
            int rownum = 0;
            foreach (DataGridViewRow row in bcdl_dataGridView_May1_Ca2.Rows)
            {
                cellnum = cellnum + 1;
                bcdl_dataGridView_May1_Ca2.Rows[rownum].Cells[0].Value = cellnum;
                rownum = rownum + 1;
            }
            bcdl_dataGridView_May1_Ca2.Refresh();
            con.Close();

        }

        private void datagridview_may2_Ca2() // DATAGRIDVIEW MAY 2 SHIFT 2
        {

            tbl_baocaodulieu_May2_Ca2.Clear();
            bcdl_dataGridView_May2_Ca2.DataSource = null;
            bcdl_dataGridView_May2_Ca2.Refresh();
            bcdl_dataGridView_May2_Ca2.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
            bcdl_dataGridView_May2_Ca2.EnableHeadersVisualStyles = false;
            DateTime tn = DateTime.Now;

            string time = tn.ToString("yyyy-MM-dd");

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;



            string sql = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay2 , TLBinhSauMay2, TLAcidMay2, TLAcidTC ,DSD, DST, DSL,DSH, PhanLoaiMay2, STDMay2, AVEMay2, CPKMay2 FROM quanlymanhinhmay2 WHERE SoCa = @soca AND Ngay =@ngay";

            cmd = new SQLiteCommand(sql, con);
            SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@soca", 2);
            cmd.Parameters.AddWithValue("@ngay", time);



            dap.Fill(tbl_baocaodulieu_May2_Ca2);

            ///////////////////////////////////////
            DataView dv = new DataView(tbl_baocaodulieu_May2_Ca2);
            dv.Sort = "Stt";
            tbl_baocaodulieu_May2_Ca2 = dv.ToTable();
            bcdl_dataGridView_May2_Ca2.DataSource = tbl_baocaodulieu_May2_Ca2;

            ////////////////////////////////////////////////////////


            bcdl_dataGridView_May2_Ca2.Columns[0].HeaderText = "Số thứ tự";
            bcdl_dataGridView_May2_Ca2.Columns[1].HeaderText = "Thời gian";
            bcdl_dataGridView_May2_Ca2.Columns[2].HeaderText = "Mã số lô hàng";
            bcdl_dataGridView_May2_Ca2.Columns[3].HeaderText = "Quy cách";
            bcdl_dataGridView_May2_Ca2.Columns[4].HeaderText = "Người thao tác";
            bcdl_dataGridView_May2_Ca2.Columns[5].HeaderText = "Số Ca";
            bcdl_dataGridView_May2_Ca2.Columns[6].HeaderText = "TL Bình Đầu";
            bcdl_dataGridView_May2_Ca2.Columns[7].HeaderText = "TL Bình Sau";
            bcdl_dataGridView_May2_Ca2.Columns[8].HeaderText = "TL ACID";
            bcdl_dataGridView_May2_Ca2.Columns[9].HeaderText = "TL ACID TC";
            bcdl_dataGridView_May2_Ca2.Columns[10].HeaderText = "LCL";
            bcdl_dataGridView_May2_Ca2.Columns[11].HeaderText = "UCL";
            bcdl_dataGridView_May2_Ca2.Columns[12].HeaderText = "LSL";
            bcdl_dataGridView_May2_Ca2.Columns[13].HeaderText = "USL";
            bcdl_dataGridView_May2_Ca2.Columns[14].HeaderText = "Phân Loại";
            bcdl_dataGridView_May2_Ca2.Columns[15].HeaderText = "STD";
            bcdl_dataGridView_May2_Ca2.Columns[16].HeaderText = "AVE";
            bcdl_dataGridView_May2_Ca2.Columns[17].HeaderText = "CPK";



            bcdl_dataGridView_May2_Ca2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bcdl_dataGridView_May2_Ca2.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            if (bcdl_dataGridView_May2_Ca2.ColumnCount > 1)
            {
                for (int i = 0; i < bcdl_dataGridView_May2_Ca2.ColumnCount - 1; i++)
                    bcdl_dataGridView_May2_Ca2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                bcdl_dataGridView_May2_Ca2.Columns[bcdl_dataGridView_May2_Ca2.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (bcdl_dataGridView_May2_Ca2.ColumnCount == 1)
            {
                bcdl_dataGridView_May2_Ca2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            bcdl_dataGridView_May2_Ca2.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            bcdl_dataGridView_May2_Ca2.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

            int cellnum = 0;
            int rownum = 0;
            foreach (DataGridViewRow row in bcdl_dataGridView_May2_Ca2.Rows)
            {
                cellnum = cellnum + 1;
                bcdl_dataGridView_May2_Ca2.Rows[rownum].Cells[0].Value = cellnum;
                rownum = rownum + 1;
            }
            bcdl_dataGridView_May2_Ca2.Refresh();
            con.Close();

        }


        /*
        private void baocaoEXCEL_May1_Ca1_Copy()
        {


                datagridview_may1_Ca1();
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                Excel.Application excell = new Excel.Application();
                DateTime tn = DateTime.Now;

                Workbook wb;
                Worksheet ws;
                string filename;
                StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));
                filepath = read.ReadToEnd();

                //prc.StartInfo.FileName = Path.GetFullPath(filepath);

                string Location = Path.GetFullPath(filepath);
               
                string path_may1 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", DateTime.Parse(Functions.date).ToString("yyyy-MM-dd"), "CA 1", "MÁY 1");

                if (Directory.Exists(path_may1))
                {
              
                 
               

                  
                    
                    string time = tn.ToString("dd-MM-yyyy");

              

                    filename = time;

                 //   copyAlltoClipboard_May1_Ca1();

                    File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT1.xlsx"), Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx", true);  // tao file tu file REFERENCE
                  
                    object misValue = System.Reflection.Missing.Value;


                    wb = excell.Workbooks.Open(Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx");                      // mo file excel 
                    wb.Application.Visible = false;  // chay ngam file excel                                                                
                    ws = wb.Worksheets[1];
                    excell.DisplayAlerts = false;   // tat canh bao ve file excel

                    Excel.Range CR = (Excel.Range)ws.Cells[3, 2];
                    CR.Select();
                    ws.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                    wb.Save();
                    read.Close();
                    excell.Quit();
                    Clipboard.Clear();

                    Thread.Sleep(1000);
                    baocaoEXCEL_May2_Ca1_Copy();
                   
                                       
               
                }
                else
                {
                    prc.Close();
                    read.Close();
                   // Clipboard.Clear();

                    if (MessageBox.Show(Functions.excel_text_cul, Functions.info_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frm_EXCEL_Path F5 = new frm_EXCEL_Path();
                        F5.ShowDialog();
                    }
                }


        }

        private void baocaoEXCEL_May2_Ca1_Copy()
        {


            datagridview_may2_Ca1();
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            Excel.Application excell = new Excel.Application();
            DateTime tn = DateTime.Now;

            Workbook wb;
            Worksheet ws;
            string filename;
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));
            filepath = read.ReadToEnd();

            //prc.StartInfo.FileName = Path.GetFullPath(filepath);

            string Location = Path.GetFullPath(filepath);

            string path_may1 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", DateTime.Parse(Functions.date).ToString("yyyy-MM-dd"), "CA 1", "MÁY 2");

            if (Directory.Exists(path_may1))
            {

                




                string time = tn.ToString("dd-MM-yyyy");



                filename = time;

                copyAlltoClipboard_May2_Ca1();

                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT2.xlsx"), Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx", true);  // tao file tu file REFERENCE

                object misValue = System.Reflection.Missing.Value;


                wb = excell.Workbooks.Open(Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx");                      // mo file excel 
                wb.Application.Visible = false;  // chay ngam file excel                                                                
                ws = wb.Worksheets[1];
                excell.DisplayAlerts = false;   // tat canh bao ve file excel

                Excel.Range CR = (Excel.Range)ws.Cells[3, 2];
                CR.Select();
                ws.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                wb.Save();
                read.Close();
                excell.Quit();

                Clipboard.Clear();

                System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                foreach (System.Diagnostics.Process p in process)
                {
                    if (!string.IsNullOrEmpty(p.ProcessName))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                    }
                }
            
            }
            else
            {
                prc.Close();
                read.Close();
               // Clipboard.Clear();

             
            }


        }

        private void baocaoEXCEL_May1_Ca2_Copy()
        {


            datagridview_may1_Ca2();
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            Excel.Application excell = new Excel.Application();
            DateTime tn = DateTime.Now;

            Workbook wb;
            Worksheet ws;
            string filename;
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));
            filepath = read.ReadToEnd();

            //prc.StartInfo.FileName = Path.GetFullPath(filepath);

            string Location = Path.GetFullPath(filepath);

            string path_may1 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", DateTime.Parse(Functions.date).ToString("yyyy-MM-dd"), "CA 2", "MÁY 1");

            if (Directory.Exists(path_may1))
            {

             




                string time = tn.ToString("dd-MM-yyyy");



                filename = time;

                copyAlltoClipboard_May1_Ca2();

                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT1.xlsx"), Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx", true);  // tao file tu file REFERENCE

                object misValue = System.Reflection.Missing.Value;


                wb = excell.Workbooks.Open(Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx");                      // mo file excel 
                wb.Application.Visible = false;  // chay ngam file excel                                                                
                ws = wb.Worksheets[1];
                excell.DisplayAlerts = false;   // tat canh bao ve file excel

                Excel.Range CR = (Excel.Range)ws.Cells[3, 2];
                CR.Select();
                ws.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                wb.Save();
                read.Close();
                excell.Quit();
                Clipboard.Clear();

                Thread.Sleep(1000);
                
                baocaoEXCEL_May2_Ca2_Copy();



            }
            else
            {
                prc.Close();
                read.Close();
                // Clipboard.Clear();

                if (MessageBox.Show(Functions.excel_text_cul, Functions.info_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frm_EXCEL_Path F5 = new frm_EXCEL_Path();
                    F5.ShowDialog();
                }
            }


        }

        private void baocaoEXCEL_May2_Ca2_Copy()
        {


            datagridview_may2_Ca2();
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            Excel.Application excell = new Excel.Application();
            DateTime tn = DateTime.Now;

            Workbook wb;
            Worksheet ws;
            string filename;
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));
            filepath = read.ReadToEnd();

            //prc.StartInfo.FileName = Path.GetFullPath(filepath);

            string Location = Path.GetFullPath(filepath);

            string path_may1 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", DateTime.Parse(Functions.date).ToString("yyyy-MM-dd"), "CA 2", "MÁY 2");

            if (Directory.Exists(path_may1))
            {

           




                string time = tn.ToString("dd-MM-yyyy");



                filename = time;

                copyAlltoClipboard_May2_Ca2();

                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT2.xlsx"), Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx", true);  // tao file tu file REFERENCE

                object misValue = System.Reflection.Missing.Value;


                wb = excell.Workbooks.Open(Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx");                      // mo file excel 
                wb.Application.Visible = false;  // chay ngam file excel                                                                
                ws = wb.Worksheets[1];
                excell.DisplayAlerts = false;   // tat canh bao ve file excel

                Excel.Range CR = (Excel.Range)ws.Cells[3, 2];
                CR.Select();
                ws.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                wb.Save();
                read.Close();
                excell.Quit();

                Clipboard.Clear();

                System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                foreach (System.Diagnostics.Process p in process)
                {
                    if (!string.IsNullOrEmpty(p.ProcessName))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                    }
                }
               
            }
            else
            {
                prc.Close();
                read.Close();
                // Clipboard.Clear();


            }


        }
        */

        private void baocaoEXCEL_Ca1_Array()// REPORT EXCEL SHIFT 1
        {
            
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));

            DateTime tn = DateTime.Now;
            filepath = read.ReadToEnd();

            read.Close();


            string time = tn.ToString("dd-MM-yyyy");

            string Location = Path.GetFullPath(filepath);

            string path_Ca1 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", time, "CA 1");
            
            string path_may1 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", time, "CA 1", "MÁY 1");
            //DateTime.Parse(Functions.date).ToString("yyyy-MM-dd")
            string path_may2 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", time, "CA 1", "MÁY 2");

            if (Directory.Exists(path_may1))
            {


                oXL_May1 = new Microsoft.Office.Interop.Excel.Application();
                oXL_May1.Visible = false;


                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT1.xlsx"), Path.GetFullPath(path_may1) + "/" + time + ".xlsx", true);  // tao file tu file REFERENCE

                wb_May1 = oXL_May1.Workbooks.Open(Path.GetFullPath(path_may1) + "/" + time + ".xlsx");                      // mo file excel 
                wb_May1.Application.Visible = false;  // chay ngam file excel                                                                
                ws_May1 = wb_May1.Worksheets[1];
                oXL_May1.DisplayAlerts = false;   // tat canh bao ve file excel


                thread_export_EXCEL_May1 = new Task(ThreadExportExcel_May1_Ca1);

                thread_export_EXCEL_May1.Start();

            }

            else
            {
                read.Close();
                if (MessageBox.Show(Functions.excel_text_cul, Functions.info_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frm_EXCEL_Path F5 = new frm_EXCEL_Path();
                    F5.Show();
                }
            }


            if (Directory.Exists(path_may2))
            {


                oXL_May2 = new Microsoft.Office.Interop.Excel.Application();
                oXL_May2.Visible = false;
                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT2.xlsx"), Path.GetFullPath(path_may2) + "/" + time + ".xlsx", true);  // tao file tu file REFERENCE

                wb_May2 = oXL_May2.Workbooks.Open(Path.GetFullPath(path_may2) + "/" + time + ".xlsx");                      // mo file excel 
                wb_May2.Application.Visible = false;  // chay ngam file excel                                                                
                ws_May2 = wb_May2.Worksheets[1];
                oXL_May2.DisplayAlerts = false;   // tat canh bao ve file excel


                thread_export_EXCEL_May2 = new Task(ThreadExportExcel_May2_Ca1);

                thread_export_EXCEL_May2.Start();


            }
            Task.WaitAll(thread_export_EXCEL_May1, thread_export_EXCEL_May2);
            isDone_baocaoEXCEL_Ca1 = true;
            


        }

        private void baocaoEXCEL_Ca2_Array()// REPORT EXCEL SHIFT 2
        {

           
            
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));
           
            DateTime tn = DateTime.Now;
             string time = tn.ToString("dd-MM-yyyy");
          
            filepath = read.ReadToEnd();
            read.Close();
            string Location = Path.GetFullPath(filepath);

            string path_may1 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", time, "CA 2", "MÁY 1");

            string path_may2 = Path.Combine(Location, "BÁO CÁO EXCEL THEO CA", time, "CA 2", "MÁY 2");

            if (Directory.Exists(path_may1))
            {
                oXL_May1 = new Microsoft.Office.Interop.Excel.Application();
                oXL_May1.Visible = false;


                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT1.xlsx"), Path.GetFullPath(path_may1) + "/" + time + ".xlsx", true);  // tao file tu file REFERENCE

                wb_May1 = oXL_May1.Workbooks.Open(Path.GetFullPath(path_may1) + "/" + time + ".xlsx");                      // mo file excel 
                wb_May1.Application.Visible = false;  // chay ngam file excel                                                                
                ws_May1 = wb_May1.Worksheets[1];
                oXL_May1.DisplayAlerts = false;   // tat canh bao ve file excel

               
                thread_export_EXCEL_May1 = new Task(ThreadExportExcel_May1_Ca2);

                   thread_export_EXCEL_May1.Start();
              
            }
                
                else
                {
                read.Close();

                if (MessageBox.Show(Functions.excel_text_cul, Functions.info_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frm_EXCEL_Path F5 = new frm_EXCEL_Path();
                        F5.Show();
                    }
                }
            

                if (Directory.Exists(path_may2))
                {
                oXL_May2 = new Microsoft.Office.Interop.Excel.Application();
                oXL_May2.Visible = false;

                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT2.xlsx"), Path.GetFullPath(path_may2) + "/" + time + ".xlsx", true);  // tao file tu file REFERENCE

                    wb_May2 = oXL_May2.Workbooks.Open(Path.GetFullPath(path_may2) + "/" + time + ".xlsx");                      // mo file excel 
                    wb_May2.Application.Visible = false;  // chay ngam file excel                                                                
                    ws_May2 = wb_May2.Worksheets[1];
                    oXL_May2.DisplayAlerts = false;   // tat canh bao ve file excel

                  
                      thread_export_EXCEL_May2 = new Task(ThreadExportExcel_May2_Ca2);
                      thread_export_EXCEL_May2.Start();

            }
            Task.WaitAll(thread_export_EXCEL_May1, thread_export_EXCEL_May2);
            isDone_baocaoEXCEL_Ca2 = true;

          


        }
        private void ThreadExportExcel_May1_Ca1() // THREAD EXPORT EXCEL MAY 1 SHIFT 1
        {
            var Dg_array_May1 = new object[bcdl_dataGridView_May1_Ca1.RowCount, bcdl_dataGridView_May1_Ca1.ColumnCount + 1];

            foreach (DataGridViewRow i in bcdl_dataGridView_May1_Ca1.Rows)
            {
                if (i.IsNewRow) continue;
                foreach (DataGridViewCell j in i.Cells)
                {
                    Dg_array_May1[j.RowIndex, j.ColumnIndex] = j.Value.ToString();

                }
            }
            Microsoft.Office.Interop.Excel.Range chartRange_May1_ca1;

            int rowCount = Dg_array_May1.GetLength(0);
            int columnCount = Dg_array_May1.GetLength(1);
            chartRange_May1_ca1 = (Microsoft.Office.Interop.Excel.Range)ws_May1.Cells[2, 1]; //I have header info on row 1, so start row 2
            chartRange_May1_ca1 = chartRange_May1_ca1.get_Resize(rowCount, columnCount);
            chartRange_May1_ca1.set_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault, Dg_array_May1);


            wb_May1.Save();

            oXL_May1.Quit();
        }

       

        private void ThreadExportExcel_May1_Ca2() // THREAD EXPORT EXCEL MAY 1 SHIFT 2
        {
            var Dg_array_May1 = new object[bcdl_dataGridView_May1_Ca2.RowCount, bcdl_dataGridView_May1_Ca2.ColumnCount + 1];

            foreach (DataGridViewRow i in bcdl_dataGridView_May1_Ca2.Rows)
            {
                if (i.IsNewRow) continue;
                foreach (DataGridViewCell j in i.Cells)
                {
                    Dg_array_May1[j.RowIndex, j.ColumnIndex] = j.Value.ToString();

                }
            }
            Microsoft.Office.Interop.Excel.Range chartRange_May1_ca2;

            int rowCount = Dg_array_May1.GetLength(0);
            int columnCount = Dg_array_May1.GetLength(1);
            chartRange_May1_ca2 = (Microsoft.Office.Interop.Excel.Range)ws_May1.Cells[2, 1]; //I have header info on row 1, so start row 2
            chartRange_May1_ca2 = chartRange_May1_ca2.get_Resize(rowCount, columnCount);
            chartRange_May1_ca2.set_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault, Dg_array_May1);


            wb_May1.Save();

            oXL_May1.Quit();
        }
        private void ThreadExportExcel_May2_Ca1() // THREAD EXPORT EXCEL MAY 2 SHIFT 1
        {
            var Dg_array_May2 = new object[bcdl_dataGridView_May2_Ca1.RowCount, bcdl_dataGridView_May2_Ca1.ColumnCount + 1];
            foreach (DataGridViewRow i in bcdl_dataGridView_May2_Ca1.Rows)
            {
                if (i.IsNewRow) continue;
                foreach (DataGridViewCell j in i.Cells)
                {
                    Dg_array_May2[j.RowIndex, j.ColumnIndex] = j.Value.ToString();

                }
            }
            Microsoft.Office.Interop.Excel.Range chartRange_May2_ca1;

            int rowCount = Dg_array_May2.GetLength(0);
            int columnCount = Dg_array_May2.GetLength(1);
            chartRange_May2_ca1 = (Microsoft.Office.Interop.Excel.Range)ws_May2.Cells[2, 1]; //I have header info on row 1, so start row 2
            chartRange_May2_ca1 = chartRange_May2_ca1.get_Resize(rowCount, columnCount);
            chartRange_May2_ca1.set_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault, Dg_array_May2);


            wb_May2.Save();

            oXL_May2.Quit();

        }
        private void ThreadExportExcel_May2_Ca2() // THREAD EXPORT EXCEL MAY 2 SHIFT 2
        {
            var Dg_array_May2 = new object[bcdl_dataGridView_May2_Ca2.RowCount, bcdl_dataGridView_May2_Ca2.ColumnCount + 1];
            foreach (DataGridViewRow i in bcdl_dataGridView_May2_Ca2.Rows)
            {
                if (i.IsNewRow) continue;
                foreach (DataGridViewCell j in i.Cells)
                {
                    Dg_array_May2[j.RowIndex, j.ColumnIndex] = j.Value.ToString();

                }
            }
            Microsoft.Office.Interop.Excel.Range chartRange_May2_ca2;

            int rowCount = Dg_array_May2.GetLength(0);
            int columnCount = Dg_array_May2.GetLength(1);
            chartRange_May2_ca2 = (Microsoft.Office.Interop.Excel.Range)ws_May2.Cells[2, 1]; //I have header info on row 1, so start row 2
            chartRange_May2_ca2 = chartRange_May2_ca2.get_Resize(rowCount, columnCount);
            chartRange_May2_ca2.set_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault, Dg_array_May2);


            wb_May2.Save();

            oXL_May2.Quit();

        }
        private void timer_export_excel_Tick(object sender, EventArgs e) // TIMER SCAN LOOP EXPORT EXCEL 
        {
            
            if (Functions.BitAdd_baoexcel_Ca1 == 1 && !isDone_baocaoEXCEL_Ca1  )
            {

                creat_foder();
                datagridview_may1_Ca1();
                datagridview_may2_Ca1();
                
                Thread th_one= new Thread(baocaoEXCEL_Ca1_Array);
                th_one.SetApartmentState(ApartmentState.STA);
                th_one.Start();
                th_one.Join();
                
                Task.Factory.StartNew(new System.Action(() =>

                {
                    System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                    foreach (System.Diagnostics.Process p in process)
                    {
                        if (!string.IsNullOrEmpty(p.ProcessName))
                        {
                            try
                            {
                                p.Kill();
                            }
                            catch { }
                        }
                    }


                }));




            }
            if (Functions.BitAdd_baoexcel_Ca1 == 0)
            {
                isDone_baocaoEXCEL_Ca1 = false;
            }
        


            if (Functions.BitAdd_baoexcel_Ca2 == 1 && !isDone_baocaoEXCEL_Ca2)
            {
                
                creat_foder();
                datagridview_may1_Ca2();
                datagridview_may2_Ca2();
                
                Thread th_two = new Thread(baocaoEXCEL_Ca2_Array);
                th_two.SetApartmentState(ApartmentState.STA);
                th_two.Start();
                th_two.Join();
                
                Task.Factory.StartNew(new System.Action(() =>

                {
                    System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                    foreach (System.Diagnostics.Process p in process)
                    {
                        if (!string.IsNullOrEmpty(p.ProcessName))
                        {
                            try
                            {
                                p.Kill();
                            }
                            catch { }
                        }
                    }


                }));

                
            }
            if (Functions.BitAdd_baoexcel_Ca2 == 0)
            {
                isDone_baocaoEXCEL_Ca2 = false;
            }
            
        }
        
        private void VI_ToolStripMenuItem_Click(object sender, EventArgs e)     // BUTTON CHANGE TO VIETNAMESE
        {
        

                VI_ToolStripMenuItem.Checked = true;
                EN_ToolStripMenuItem.Checked = false;
                switch_language();
           
        }

        private void EN_ToolStripMenuItem_Click(object sender, EventArgs e)     // BUTTON CHANGE TO ENGLISH
        {
           
                VI_ToolStripMenuItem.Checked = false;
                EN_ToolStripMenuItem.Checked = true;
                switch_language();
            

        }

        private void timer_checkcalamviec_Tick(object sender, EventArgs e)      // TIMER SCAN LOOP CHECK WORKSHIFTS 
        {
            if (Functions.BitAdd_baoexcel_Ca1 == 1)
            {

                Functions.z1_Ca1 = 1;

            //    Functions.CDTT_May1 = new double[999999];

                Functions.SUM_May1_Ca1 = 0; Functions.SUMSQUARES_May1_Ca1 = 0.00; Functions.SQUARESUMS_May1_Ca1 = 0.00;
                Functions.AVE_May1_Ca1 = 0.00;
                Functions.STD_May1_Ca1 = 0.00; Functions.CPK1_May1_Ca1 = 0.00; Functions.CPK2_May1_Ca1 = 0.00; Functions.CPK_May1_Ca1 = 0.00;
                Functions.NUMERATOR_May1_Ca1 = 0.00; Functions.DENOMINATOR_May1_Ca1 = 0.00;



                Functions.z2_Ca1 = 1;

              //  Functions.CDTT_May2 = new double[999999];

                Functions.SUM_May2_Ca1 = 0; Functions.SUMSQUARES_May2_Ca1 = 0.00; Functions.SQUARESUMS_May2_Ca1 = 0.00;
                Functions.AVE_May2_Ca1 = 0.00;
                Functions.STD_May2_Ca1 = 0.00; Functions.CPK1_May2_Ca1 = 0.00; Functions.CPK2_May2_Ca1 = 0.00; Functions.CPK_May2_Ca1 = 0.00;
                Functions.NUMERATOR_May2_Ca1 = 0.00; Functions.DENOMINATOR_May2_Ca1 = 0.00;
            }
            else if (Functions.BitAdd_baoexcel_Ca2 == 1)
            {

                Functions.z1_Ca2 = 1;

              //  Functions.CDTT_May1 = new double[999999];

                Functions.SUM_May1_Ca2 = 0; Functions.SUMSQUARES_May1_Ca2 = 0.00; Functions.SQUARESUMS_May1_Ca2 = 0.00;
                Functions.AVE_May1_Ca2 = 0.00;
                Functions.STD_May1_Ca2 = 0.00; Functions.CPK1_May1_Ca2 = 0.00; Functions.CPK2_May1_Ca2 = 0.00; Functions.CPK_May1_Ca2 = 0.00;
                Functions.NUMERATOR_May1_Ca2 = 0.00; Functions.DENOMINATOR_May1_Ca2 = 0.00;



                Functions.z2_Ca2 = 1;

             //   Functions.CDTT_May2 = new double[999999];

                Functions.SUM_May2_Ca2 = 0; Functions.SUMSQUARES_May2_Ca2 = 0.00; Functions.SQUARESUMS_May2_Ca2 = 0.00;
                Functions.AVE_May2_Ca2 = 0.00;
                Functions.STD_May2_Ca2 = 0.00; Functions.CPK1_May2_Ca2 = 0.00; Functions.CPK2_May2_Ca2 = 0.00; Functions.CPK_May2_Ca2 = 0.00;
                Functions.NUMERATOR_May2_Ca2 = 0.00; Functions.DENOMINATOR_May2_Ca2 = 0.00;

            }
        }

        private void logout_toolStripMenuItem_Click(object sender, EventArgs e) // BUTTON LOG OUT
        {
            frm_dangnhaphethong F1 = new frm_dangnhaphethong();
            F1.Show();
            this.Close();
        }

        private void exit_ToolStripMenuItem_Click(object sender, EventArgs e)   // BUTTON EXIT PROGRAM
        {

            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                foreach (System.Diagnostics.Process p in process)
                {
                    if (!string.IsNullOrEmpty(p.ProcessName))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                    }
                }

                System.Windows.Forms.Application.Exit();
             
            }
        }

       

        private void timer_baoloi_Tick(object sender, EventArgs e) // TIMER ALARM ERRORS 
        {
            if (Functions.BitAdd_Baoloi == 1 && !isDone_Baoloi)
            {
               // send_mail();
                send_mail_KLB();
                isDone_Baoloi = true;
                Thread.Sleep(4000);


            }

            else if (Functions.BitAdd_Baoloi == 0)
            {

                isDone_Baoloi = false;


            }

        }

      
   
    }

    }

 