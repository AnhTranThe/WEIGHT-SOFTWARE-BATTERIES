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
using OfficeOpenXml;
using System.Threading.Tasks;

namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    public partial class baocaobangdulieu : Form
    {
      
        System.Data.DataTable tbl_baocaodulieu_may1 = new System.Data.DataTable();
        System.Data.DataTable tbl_baocaodulieu_may2 = new System.Data.DataTable();
        Microsoft.Office.Interop.Excel.Application oXL_May1;
        Microsoft.Office.Interop.Excel.Application oXL_May2;
        Workbook wb_May1, wb_May2;
        Worksheet ws_May1, ws_May2;
        Task thread_export_EXCEL_May1, thread_export_EXCEL_May2;

        resize_function_1 form_resize_1;
     
        public string filepath;
        public bool date_start_changed = false;
        public bool date_end_changed = false;
        public bool isLoad_datagridview_1 = false;
        public bool isLoad_datagridview_2 = false;
        public baocaobangdulieu()
        {
            InitializeComponent();
          
        }
        private void Load_Inititial_Size_fucntion(object sender, EventArgs e)
        {

            form_resize_1._get_initial_size();
        }
        private void Resize_function(object sender, EventArgs e)
        {

            form_resize_1._resize();
        }
       
        private void baocaobangdulieu_Load(object sender, EventArgs e)
        {
            //test xem sự thay đổi
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
                updatemslh_ToolStripMenuItem.Text = "Cập nhật mã số lô hàng đã chạy";
                xuatexcel_ToolStripMenuItem.Text = "Xuất đơn hàng sang file Excel";
                xoadonhang_ToolStripMenuItem.Text = "Xoá đơn hàng theo mã số lô hàng đã chọn";
                xoaall_ToolStripMenuItem.Text = "Xoá tất cả đơn hàng đã thu thập dữ liệu";
                xemdonhangchay_ToolStripMenuItem.Text = "Xem tất cả mã số lô hàng đã lưu";
                lblx_soca.Text = "Số ca làm việc";
                lblx_tgbatdau.Text = "Thời gian bắt đầu";
                lblx_tgketthuc.Text = "Thời gian kết thúc";
                this.Text = "Báo cáo dữ liệu";
                Functions.export_excel_sucessful_cul = "Xuất file EXCEL thành công";
                Functions.ask_delete_mslh_text_cul = "Bạn có muốn xoá đơn hàng theo MSLH đã chọn không?";
                Functions.delete_all_mslh_textstring_cul ="Bạn có muốn xoá toàn bộ đơn hàng không ? Thao tác sẽ không hoàn lại được !";
             


            }
            else if (Functions.EN_cul == true)
            {
                updatemslh_ToolStripMenuItem.Text = "Update article number code";
                xuatexcel_ToolStripMenuItem.Text = "Export article number code Excel";
                xoadonhang_ToolStripMenuItem.Text = "Delete item code according to the article number code";
                xoaall_ToolStripMenuItem.Text = "Delete all collected  article number code";
                xemdonhangchay_ToolStripMenuItem.Text = "Read all collected article number code";
                lblx_soca.Text = "Shiftwork No";
                lblx_tgbatdau.Text = "The Time begins";
                lblx_tgketthuc.Text = "The Time ends";
                this.Text = "Report Datagridview";
                Functions.export_excel_sucessful_cul = "Export Data to Excel successful !";
                Functions.ask_delete_mslh_text_cul = "Do you want to delete selected article number code ?";
                Functions.delete_all_mslh_textstring_cul = "Do you want to delete all article number code? Actions are non-refundable!";
        

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


     private void LoadDataGridView_May1()
     {
         tbl_baocaodulieu_may1.Clear();
         bcdl_dataGridView_May1.DataSource = null;
         bcdl_dataGridView_May1.Refresh();
       
        
         string sql_May1;
        
         bcdl_dataGridView_May1.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
         bcdl_dataGridView_May1.EnableHeadersVisualStyles = false;

         sql_May1 = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay1 , TLBinhSauMay1, TLAcidMay1, TLAcidTC ,DSD, DST, DSL,"
         + "DSH, PhanLoaiMay1, STDMay1, AVEMay1, CPKMay1  FROM quanlymanhinhmay1";
         tbl_baocaodulieu_may1 = Class.Functions.GetDataToTable(sql_May1); //Đọc dữ liệu từ bảng
         bcdl_dataGridView_May1.DataSource = tbl_baocaodulieu_may1; //Nguồn dữ liệu            

         if (Functions.VI_cul == true)
         {
             bcdl_dataGridView_May1.Columns[0].HeaderText = "Số thứ tự";
             bcdl_dataGridView_May1.Columns[1].HeaderText = "Thời gian";
             bcdl_dataGridView_May1.Columns[2].HeaderText = "Mã số lô hàng";
             bcdl_dataGridView_May1.Columns[3].HeaderText = "Quy cách";
             bcdl_dataGridView_May1.Columns[4].HeaderText = "Người thao tác";
             bcdl_dataGridView_May1.Columns[5].HeaderText = "Số Ca";
             bcdl_dataGridView_May1.Columns[6].HeaderText = "TL Bình Đầu";
             bcdl_dataGridView_May1.Columns[7].HeaderText = "TL Bình Sau";
             bcdl_dataGridView_May1.Columns[8].HeaderText = "TL ACID";
             bcdl_dataGridView_May1.Columns[9].HeaderText = "TL ACID TC";
             bcdl_dataGridView_May1.Columns[10].HeaderText = "LCL";
             bcdl_dataGridView_May1.Columns[11].HeaderText = "UCL";
             bcdl_dataGridView_May1.Columns[12].HeaderText = "LSL";
             bcdl_dataGridView_May1.Columns[13].HeaderText = "USL";
             bcdl_dataGridView_May1.Columns[14].HeaderText = "Phân Loại";
             bcdl_dataGridView_May1.Columns[15].HeaderText = "STD";
             bcdl_dataGridView_May1.Columns[16].HeaderText = "AVE";
             bcdl_dataGridView_May1.Columns[17].HeaderText = "CPK";

            


             bcdl_dataGridView_May1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
         }
         else if (Functions.EN_cul == true)
         {
             bcdl_dataGridView_May1.Columns[0].HeaderText = "Numerical Order";
             bcdl_dataGridView_May1.Columns[1].HeaderText = "Time";
             bcdl_dataGridView_May1.Columns[2].HeaderText = "Article Number Code";
             bcdl_dataGridView_May1.Columns[3].HeaderText = "Specification";
             bcdl_dataGridView_May1.Columns[4].HeaderText = "The Operator";
             bcdl_dataGridView_May1.Columns[5].HeaderText = "Shiftwork";
             bcdl_dataGridView_May1.Columns[6].HeaderText = "First Weight";
             bcdl_dataGridView_May1.Columns[7].HeaderText = "After Weight";
             bcdl_dataGridView_May1.Columns[8].HeaderText = "Acid Weight";
             bcdl_dataGridView_May1.Columns[9].HeaderText = "Acid Stardard Weight";
             bcdl_dataGridView_May1.Columns[10].HeaderText = "LCL";
             bcdl_dataGridView_May1.Columns[11].HeaderText = "UCL";
             bcdl_dataGridView_May1.Columns[12].HeaderText = "LSL";
             bcdl_dataGridView_May1.Columns[13].HeaderText = "USL";
             bcdl_dataGridView_May1.Columns[14].HeaderText = "Classify";
             bcdl_dataGridView_May1.Columns[15].HeaderText = "STD";
             bcdl_dataGridView_May1.Columns[16].HeaderText = "AVE";
             bcdl_dataGridView_May1.Columns[17].HeaderText = "CPK";

         

             bcdl_dataGridView_May1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

         }
         //////////////////////////////////////////////////////////////
         
         
         if (bcdl_dataGridView_May1.ColumnCount > 1)
         {
             for (int i = 0; i < bcdl_dataGridView_May1.ColumnCount - 1; i++)
                 bcdl_dataGridView_May1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

             bcdl_dataGridView_May1.Columns[bcdl_dataGridView_May1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         }

         if (bcdl_dataGridView_May1.ColumnCount == 1)
         {
             bcdl_dataGridView_May1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         }

     



         bcdl_dataGridView_May1.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
         bcdl_dataGridView_May1.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

        





         int cellnum = 0;
         int rownum = 0;
         foreach (DataGridViewRow row in bcdl_dataGridView_May1.Rows)
         {
             cellnum = cellnum + 1;
             bcdl_dataGridView_May1.Rows[rownum].Cells[0].Value = cellnum;
             rownum = rownum + 1;
         }
        
        
     }
     private void LoadDataGridView_May2()
     {
         ////////////////////////
         tbl_baocaodulieu_may2.Clear();
         bcdl_dataGridView_May2.DataSource = null;
         bcdl_dataGridView_May2.Refresh();
         
         string sql_May2;
         bcdl_dataGridView_May2.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
         bcdl_dataGridView_May2.EnableHeadersVisualStyles = false;
       
         sql_May2 = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay2 , TLBinhSauMay2, TLAcidMay2, TLAcidTC ,DSD, DST, DSL,"
        + "DSH, PhanLoaiMay2, STDMay2, AVEMay2, CPKMay2  FROM quanlymanhinhmay2";
         tbl_baocaodulieu_may2 = Class.Functions.GetDataToTable(sql_May2); //Đọc dữ liệu từ bảng
         bcdl_dataGridView_May2.DataSource = tbl_baocaodulieu_may2; //Nguồn dữ liệu            
         if (Functions.VI_cul == true)
         {
             bcdl_dataGridView_May2.Columns[0].HeaderText = "Số thứ tự";
             bcdl_dataGridView_May2.Columns[1].HeaderText = "Thời gian";
             bcdl_dataGridView_May2.Columns[2].HeaderText = "Mã số lô hàng";
             bcdl_dataGridView_May2.Columns[3].HeaderText = "Quy cách";
             bcdl_dataGridView_May2.Columns[4].HeaderText = "Người thao tác";
             bcdl_dataGridView_May2.Columns[5].HeaderText = "Số Ca";
             bcdl_dataGridView_May2.Columns[6].HeaderText = "TL Bình Đầu";
             bcdl_dataGridView_May2.Columns[7].HeaderText = "TL Bình Sau";
             bcdl_dataGridView_May2.Columns[8].HeaderText = "TL ACID";
             bcdl_dataGridView_May2.Columns[9].HeaderText = "TL ACID TC";
             bcdl_dataGridView_May2.Columns[10].HeaderText = "LCL";
             bcdl_dataGridView_May2.Columns[11].HeaderText = "UCL";
             bcdl_dataGridView_May2.Columns[12].HeaderText = "LSL";
             bcdl_dataGridView_May2.Columns[13].HeaderText = "USL";
             bcdl_dataGridView_May2.Columns[14].HeaderText = "Phân Loại";
             bcdl_dataGridView_May2.Columns[15].HeaderText = "STD";
             bcdl_dataGridView_May2.Columns[16].HeaderText = "AVE";
             bcdl_dataGridView_May2.Columns[17].HeaderText = "CPK";

             // bcdl_dataGridView_May2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

             bcdl_dataGridView_May2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
         }
         else if (Functions.EN_cul == true)
         {
             bcdl_dataGridView_May2.Columns[0].HeaderText = "Numerical Order";
             bcdl_dataGridView_May2.Columns[1].HeaderText = "Time";
             bcdl_dataGridView_May2.Columns[2].HeaderText = "Article Number Code";
             bcdl_dataGridView_May2.Columns[3].HeaderText = "Specification";
             bcdl_dataGridView_May2.Columns[4].HeaderText = "The Operator";
             bcdl_dataGridView_May2.Columns[5].HeaderText = "Shiftwork";
             bcdl_dataGridView_May2.Columns[6].HeaderText = "First Weight";
             bcdl_dataGridView_May2.Columns[7].HeaderText = "After Weight";
             bcdl_dataGridView_May2.Columns[8].HeaderText = "Acid Weight";
             bcdl_dataGridView_May2.Columns[9].HeaderText = "Acid Stardard Weight";
             bcdl_dataGridView_May2.Columns[10].HeaderText = "LCL";
             bcdl_dataGridView_May2.Columns[11].HeaderText = "UCL";
             bcdl_dataGridView_May2.Columns[12].HeaderText = "LSL";
             bcdl_dataGridView_May2.Columns[13].HeaderText = "USL";
             bcdl_dataGridView_May2.Columns[14].HeaderText = "Classify";
             bcdl_dataGridView_May2.Columns[15].HeaderText = "STD";
             bcdl_dataGridView_May2.Columns[16].HeaderText = "AVE";
             bcdl_dataGridView_May2.Columns[17].HeaderText = "CPK";



             bcdl_dataGridView_May2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             bcdl_dataGridView_May2.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

         }
         if (bcdl_dataGridView_May2.ColumnCount > 1)
         {
             for (int i = 0; i < bcdl_dataGridView_May2.ColumnCount - 1; i++)
                 bcdl_dataGridView_May2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

             bcdl_dataGridView_May2.Columns[bcdl_dataGridView_May2.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         }

         if (bcdl_dataGridView_May2.ColumnCount == 1)
         {
             bcdl_dataGridView_May2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
         }
         bcdl_dataGridView_May2.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
         bcdl_dataGridView_May2.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

         int cellnum = 0;
         int rownum = 0;
        
         foreach (DataGridViewRow row in bcdl_dataGridView_May2.Rows)
         {
             cellnum = cellnum + 1;
             bcdl_dataGridView_May2.Rows[rownum].Cells[0].Value = cellnum;
             rownum = rownum + 1;
         }

     }

     private void baocaobangdulieu_dataGridView_RowPostPaint()
     {
         throw new NotImplementedException();
     }
          
        private void exit_button_Click(object sender, EventArgs e)
        {
            Class.Functions.DisconnectSQL();
            this.Close();
        }

        public void loadcombobox()
        {
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;
            
            string sql;
            sql = "SELECT DISTINCT MaLoHang FROM quanlymanhinhtong WHERE strftime('%Y-%m-%d', Ngay) between '" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'";

            cmd = new SQLiteCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            SQLiteDataReader dap = cmd.ExecuteReader();
           
      
            while (dap.Read()) 

            {
              
                comboBox1.Items.Add(dap[0].ToString());
                
               
               
           }
            dap.Close();
            con.Close();
          
            
           
        }
        private void baocaodulieu_may1()
        {
             isLoad_datagridview_1 = false;
             tbl_baocaodulieu_may1.Clear();
             bcdl_dataGridView_May1.DataSource = null;
             bcdl_dataGridView_May1.Refresh();
             bcdl_dataGridView_May1.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
             bcdl_dataGridView_May1.EnableHeadersVisualStyles = false;
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;

            string selectItem = comboBox1.Text;
         
            if (selectItem != "")
            {

                string sql = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay1 , TLBinhSauMay1, TLAcidMay1, TLAcidTC ,DSD, DST, DSL,DSH, PhanLoaiMay1, STDMay1, AVEMay1, CPKMay1 FROM quanlymanhinhmay1 WHERE MaLoHang = @mslh AND SoCa = @soca AND Ngay between'" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'";

                cmd = new SQLiteCommand(sql, con);
                SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@ngay", "between'" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'");
                cmd.Parameters.AddWithValue("@mslh", comboBox1.Text);
                cmd.Parameters.AddWithValue("@soca",comboBox2.Text);
                dap.Fill(tbl_baocaodulieu_may1);
                
                ///////////////////////////////////////
                DataView dv = new DataView(tbl_baocaodulieu_may1);
                dv.Sort = "Stt";
                tbl_baocaodulieu_may1 = dv.ToTable();
                 bcdl_dataGridView_May1.DataSource = tbl_baocaodulieu_may1;

                ////////////////////////////////////////////////////////

                 if (Functions.VI_cul == true)
                 {
                     bcdl_dataGridView_May1.Columns[0].HeaderText = "Số thứ tự";
                     bcdl_dataGridView_May1.Columns[1].HeaderText = "Thời gian";
                     bcdl_dataGridView_May1.Columns[2].HeaderText = "Mã số lô hàng";
                     bcdl_dataGridView_May1.Columns[3].HeaderText = "Quy cách";
                     bcdl_dataGridView_May1.Columns[4].HeaderText = "Người thao tác";
                     bcdl_dataGridView_May1.Columns[5].HeaderText = "Số Ca";
                     bcdl_dataGridView_May1.Columns[6].HeaderText = "TL Bình Đầu";
                     bcdl_dataGridView_May1.Columns[7].HeaderText = "TL Bình Sau";
                     bcdl_dataGridView_May1.Columns[8].HeaderText = "TL ACID";
                     bcdl_dataGridView_May1.Columns[9].HeaderText = "TL ACID TC";
                     bcdl_dataGridView_May1.Columns[10].HeaderText = "LCL";
                     bcdl_dataGridView_May1.Columns[11].HeaderText = "UCL";
                     bcdl_dataGridView_May1.Columns[12].HeaderText = "LSL";
                     bcdl_dataGridView_May1.Columns[13].HeaderText = "USL";
                     bcdl_dataGridView_May1.Columns[14].HeaderText = "Phân Loại";
                     bcdl_dataGridView_May1.Columns[15].HeaderText = "STD";
                     bcdl_dataGridView_May1.Columns[16].HeaderText = "AVE";
                     bcdl_dataGridView_May1.Columns[17].HeaderText = "CPK";

                

                     bcdl_dataGridView_May1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                 }
                 else if (Functions.EN_cul == true)
                 {
                     bcdl_dataGridView_May1.Columns[0].HeaderText = "Numerical Order";
                     bcdl_dataGridView_May1.Columns[1].HeaderText = "Time";
                     bcdl_dataGridView_May1.Columns[2].HeaderText = "Article Number Code";
                     bcdl_dataGridView_May1.Columns[3].HeaderText = "Specification";
                     bcdl_dataGridView_May1.Columns[4].HeaderText = "The Operator";
                     bcdl_dataGridView_May1.Columns[5].HeaderText = "Shiftwork";
                     bcdl_dataGridView_May1.Columns[6].HeaderText = "First Weight";
                     bcdl_dataGridView_May1.Columns[7].HeaderText = "After Weight";
                     bcdl_dataGridView_May1.Columns[8].HeaderText = "Acid Weight";
                     bcdl_dataGridView_May1.Columns[9].HeaderText = "Acid Stardard Weight";
                     bcdl_dataGridView_May1.Columns[10].HeaderText = "LCL";
                     bcdl_dataGridView_May1.Columns[11].HeaderText = "UCL";
                     bcdl_dataGridView_May1.Columns[12].HeaderText = "LSL";
                     bcdl_dataGridView_May1.Columns[13].HeaderText = "USL";
                     bcdl_dataGridView_May1.Columns[14].HeaderText = "Classify";
                     bcdl_dataGridView_May1.Columns[15].HeaderText = "STD";
                     bcdl_dataGridView_May1.Columns[16].HeaderText = "AVE";
                     bcdl_dataGridView_May1.Columns[17].HeaderText = "CPK";

                   
                     bcdl_dataGridView_May1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                     bcdl_dataGridView_May1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                 }
                if ( bcdl_dataGridView_May1.ColumnCount > 1)
                {
                    for (int i = 0; i <  bcdl_dataGridView_May1.ColumnCount - 1; i++)
                      bcdl_dataGridView_May1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                   bcdl_dataGridView_May1.Columns[ bcdl_dataGridView_May1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if ( bcdl_dataGridView_May1.ColumnCount == 1)
                {
                    bcdl_dataGridView_May1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                bcdl_dataGridView_May1.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
                 bcdl_dataGridView_May1.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
              
                int cellnum = 0;
                int rownum = 0;
                foreach (DataGridViewRow row in  bcdl_dataGridView_May1.Rows)
                {
                    cellnum = cellnum + 1;
                    bcdl_dataGridView_May1.Rows[rownum].Cells[0].Value = cellnum;
                    rownum = rownum + 1;
                }
                bcdl_dataGridView_May1.Refresh();
                con.Close();
                isLoad_datagridview_1 = true;
        }
        }
        private void baocaodulieu_may2()
        {
            isLoad_datagridview_2 = false;
            tbl_baocaodulieu_may2.Clear();
            bcdl_dataGridView_May2.DataSource = null;
            bcdl_dataGridView_May2.Refresh();
            bcdl_dataGridView_May2.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
            bcdl_dataGridView_May2.EnableHeadersVisualStyles = false;
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;

            string selectItem = comboBox1.Text;
            //baocaobangdulieu_dataGridView.Rows.Clear();

            if (selectItem != "All")
            {

                string sql = "SELECT Stt, ThoiGian, MaLoHang, QuyCach, NguoiThaoTac, SoCa ,TLBinhDauMay2 , TLBinhSauMay2, TLAcidMay2, TLAcidTC ,DSD, DST, DSL,DSH, PhanLoaiMay2, STDMay2, AVEMay2, CPKMay2 FROM quanlymanhinhmay2 WHERE MaLoHang = @mslh AND SoCa = @soca AND Ngay between'" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'";

                cmd = new SQLiteCommand(sql, con);
                SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@ngay", "between'" + dateTimePickerStart.Value.ToString("yyyy-MM-dd") + "' And '" + dateTimePickerEnd.Value.ToString("yyyy-MM-dd") + "'");
                cmd.Parameters.AddWithValue("@mslh", comboBox1.Text);
                cmd.Parameters.AddWithValue("@soca", comboBox2.Text);
                dap.Fill(tbl_baocaodulieu_may2);

                ///////////////////////////////////////
                DataView dv = new DataView(tbl_baocaodulieu_may2);
                dv.Sort = "Stt";
                tbl_baocaodulieu_may2 = dv.ToTable();
                bcdl_dataGridView_May2.DataSource = tbl_baocaodulieu_may2;

                ////////////////////////////////////////////////////////
                if (Functions.VI_cul == true)
                {
                    bcdl_dataGridView_May2.Columns[0].HeaderText = "Số thứ tự";
                    bcdl_dataGridView_May2.Columns[1].HeaderText = "Thời gian";
                    bcdl_dataGridView_May2.Columns[2].HeaderText = "Mã số lô hàng";
                    bcdl_dataGridView_May2.Columns[3].HeaderText = "Quy cách";
                    bcdl_dataGridView_May2.Columns[4].HeaderText = "Người thao tác";
                    bcdl_dataGridView_May2.Columns[5].HeaderText = "Số Ca";
                    bcdl_dataGridView_May2.Columns[6].HeaderText = "TL Bình Đầu";
                    bcdl_dataGridView_May2.Columns[7].HeaderText = "TL Bình Sau";
                    bcdl_dataGridView_May2.Columns[8].HeaderText = "TL ACID";
                    bcdl_dataGridView_May2.Columns[9].HeaderText = "TL ACID TC";
                    bcdl_dataGridView_May2.Columns[10].HeaderText = "LCL";
                    bcdl_dataGridView_May2.Columns[11].HeaderText = "UCL";
                    bcdl_dataGridView_May2.Columns[12].HeaderText = "LSL";
                    bcdl_dataGridView_May2.Columns[13].HeaderText = "USL";
                    bcdl_dataGridView_May2.Columns[14].HeaderText = "Phân Loại";
                    bcdl_dataGridView_May2.Columns[15].HeaderText = "STD";
                    bcdl_dataGridView_May2.Columns[16].HeaderText = "AVE";
                    bcdl_dataGridView_May2.Columns[17].HeaderText = "CPK";


                    bcdl_dataGridView_May2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else if (Functions.EN_cul == true)
                {
                    bcdl_dataGridView_May2.Columns[0].HeaderText = "Numerical Order";
                    bcdl_dataGridView_May2.Columns[1].HeaderText = "Time";
                    bcdl_dataGridView_May2.Columns[2].HeaderText = "Article Number Code";
                    bcdl_dataGridView_May2.Columns[3].HeaderText = "Specification";
                    bcdl_dataGridView_May2.Columns[4].HeaderText = "The Operator";
                    bcdl_dataGridView_May2.Columns[5].HeaderText = "Shiftwork";
                    bcdl_dataGridView_May2.Columns[6].HeaderText = "First Weight";
                    bcdl_dataGridView_May2.Columns[7].HeaderText = "After Weight";
                    bcdl_dataGridView_May2.Columns[8].HeaderText = "Acid Weight";
                    bcdl_dataGridView_May2.Columns[9].HeaderText = "Acid Stardard Weight";
                    bcdl_dataGridView_May2.Columns[10].HeaderText = "LCL";
                    bcdl_dataGridView_May2.Columns[11].HeaderText = "UCL";
                    bcdl_dataGridView_May2.Columns[12].HeaderText = "LSL";
                    bcdl_dataGridView_May2.Columns[13].HeaderText = "USL";
                    bcdl_dataGridView_May2.Columns[14].HeaderText = "Classify";
                    bcdl_dataGridView_May2.Columns[15].HeaderText = "STD";
                    bcdl_dataGridView_May2.Columns[16].HeaderText = "AVE";
                    bcdl_dataGridView_May2.Columns[17].HeaderText = "CPK";



                    bcdl_dataGridView_May2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    bcdl_dataGridView_May2.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                }
                if (bcdl_dataGridView_May2.ColumnCount > 1)
                {
                    for (int i = 0; i < bcdl_dataGridView_May2.ColumnCount - 1; i++)
                        bcdl_dataGridView_May2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                    bcdl_dataGridView_May2.Columns[bcdl_dataGridView_May2.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (bcdl_dataGridView_May2.ColumnCount == 1)
                {
                    bcdl_dataGridView_May2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                bcdl_dataGridView_May2.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
                bcdl_dataGridView_May2.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

                int cellnum = 0;
                int rownum = 0;
                foreach (DataGridViewRow row in bcdl_dataGridView_May2.Rows)
                {
                    cellnum = cellnum + 1;
                    bcdl_dataGridView_May2.Rows[rownum].Cells[0].Value = cellnum;
                    rownum = rownum + 1;
                }
                bcdl_dataGridView_May2.Refresh();
                con.Close();
                isLoad_datagridview_2 = true;
            }
        }
        
           

        private void updatemslh_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            loadcombobox();
           
            
        }
        private void creat_foder()  
          
        {
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));
            filepath = read.ReadToEnd();

            read.Close();

            string Location = Path.GetFullPath(filepath);
            
            string path_may1 = Path.Combine(Location, "BÁO CÁO EXCEL","MÁY 1",comboBox1.Text);
            string path_may2 = Path.Combine(Location, "BÁO CÁO EXCEL","MÁY 2",comboBox1.Text);
            if (!Directory.Exists(path_may1))
            {
                Directory.CreateDirectory(path_may1);
            }
             if (!Directory.Exists(path_may2))
            {
                Directory.CreateDirectory(path_may2);
            }
        }
        /*
        private void copyAlltoClipboard_May1()
        {
            bcdl_dataGridView_May1.SelectAll();

            DataObject dataObj = bcdl_dataGridView_May1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            bcdl_dataGridView_May1.ClearSelection();
        }
        
       
        private void export2Excel_may1_CopyPaste()
        {
            copyAlltoClipboard_May1();
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
            string path_may1 = Path.Combine(Location, "BÁO CÁO EXCEL","MÁY 1",comboBox1.Text);

            if (Directory.Exists(path_may1))
            {
                string time = tn.ToString("dd-MM-yy HH_mm_ss");
                string selectedText = this.comboBox1.Text.Trim();
                filename = selectedText+" "+ time;

                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT1.xlsx"), Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx", true);  // tao file tu file REFERENCE

                object misValue = System.Reflection.Missing.Value;


                wb = excell.Workbooks.Open(Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx");                      // mo file excel 
                wb.Application.Visible = false;  // chay ngam file excel                                                                
                ws = wb.Worksheets[1];
                excell.DisplayAlerts = false;   // tat canh bao ve file excel

                Excel.Range CR = (Excel.Range)ws.Cells[3, 1];
                CR.Select();
                ws.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true); 
              
                wb.Save();
                read.Close();
                excell.Quit();
                Clipboard.Clear();
                Thread.Sleep(1000);
                export2Excel_may2_CopyPaste();

               
            }
            else
            {
                prc.Close();
                read.Close();
                Clipboard.Clear();

                if (MessageBox.Show(Functions.excel_text_cul, Functions.info_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frm_EXCEL_Path F5 = new frm_EXCEL_Path();
                    F5.Show();
                }
            }


        }
        */
        /*
        private void copyAlltoClipboard_May2()
        {
            bcdl_dataGridView_May2.SelectAll();

            DataObject dataObj = bcdl_dataGridView_May2.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            bcdl_dataGridView_May2.ClearSelection();
        }
        private void export2Excel_may2_CopyPaste()
        {
            copyAlltoClipboard_May2();
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
            string path_may2 = Path.Combine(Location, "BÁO CÁO EXCEL", "MÁY 2", comboBox1.Text);

            if (Directory.Exists(path_may2))
            {
                string time = tn.ToString("dd-MM-yy HH_mm_ss");
                string selectedText = this.comboBox1.Text.Trim();
                filename = selectedText + " " + time;

                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT2.xlsx"), Path.GetFullPath(path_may2) + "/" + filename.Trim() + ".xlsx", true);  // tao file tu file REFERENCE
                wb = excell.Workbooks.Open(Path.GetFullPath(path_may2) + "/" + filename.Trim() + ".xlsx");                      // mo file excel 
                wb.Application.Visible = false;  // chay ngam file excel                                                                
                ws = wb.Worksheets[1];
                excell.DisplayAlerts = false;   // tat canh bao ve file excel

                Excel.Range CR = (Excel.Range)ws.Cells[3, 1];
                CR.Select();
                ws.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true); 
              


                wb.Save();
                read.Close();
                excell.Quit();
                Clipboard.Clear();
         
            }
            else
            {
                prc.Close();
                read.Close();
                Clipboard.Clear();
             
            }


        }
        */
        private void ThreadExportExcel_May1()
        {
            var Dg_array_May1 = new object[bcdl_dataGridView_May1.RowCount, bcdl_dataGridView_May1.ColumnCount + 1];
            
            foreach (DataGridViewRow i in bcdl_dataGridView_May1.Rows)
            {
                if (i.IsNewRow) continue;
                foreach (DataGridViewCell j in i.Cells)
                {
                    Dg_array_May1[j.RowIndex, j.ColumnIndex] = j.Value.ToString();

                }
            }
            Microsoft.Office.Interop.Excel.Range chartRange_May1;

            int rowCount = Dg_array_May1.GetLength(0);
            int columnCount = Dg_array_May1.GetLength(1);
            chartRange_May1 = (Microsoft.Office.Interop.Excel.Range)ws_May1.Cells[2, 1]; //I have header info on row 1, so start row 2
            chartRange_May1 = chartRange_May1.get_Resize(rowCount, columnCount);
            chartRange_May1.set_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault, Dg_array_May1);


            wb_May1.Save();

            oXL_May1.Quit();
        }
        private void ThreadExportExcel_May2()
        {
            var Dg_array_May2 = new object[bcdl_dataGridView_May2.RowCount, bcdl_dataGridView_May2.ColumnCount + 1];
            foreach (DataGridViewRow i in bcdl_dataGridView_May2.Rows)
            {
                if (i.IsNewRow) continue;
                foreach (DataGridViewCell j in i.Cells)
                {
                    Dg_array_May2[j.RowIndex, j.ColumnIndex] = j.Value.ToString();

                }
            }
            Microsoft.Office.Interop.Excel.Range chartRange_May2;

            int rowCount = Dg_array_May2.GetLength(0);
            int columnCount = Dg_array_May2.GetLength(1);
            chartRange_May2 = (Microsoft.Office.Interop.Excel.Range)ws_May2.Cells[2, 1]; //I have header info on row 1, so start row 2
            chartRange_May2 = chartRange_May2.get_Resize(rowCount, columnCount);
            chartRange_May2.set_Value(Microsoft.Office.Interop.Excel.XlRangeValueDataType.xlRangeValueDefault, Dg_array_May2);


            wb_May2.Save();

            oXL_May2.Quit();

        }
        private void export2EXCEL()
        {
          
            oXL_May1 = new Microsoft.Office.Interop.Excel.Application();
            oXL_May1.Visible = false;

           
            oXL_May2 = new Microsoft.Office.Interop.Excel.Application();
            oXL_May2.Visible = false;

           

        

            string filename;

            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));
            filepath = read.ReadToEnd();


            string Location = Path.GetFullPath(filepath);

            string path_may1 = Path.Combine(Location, "BÁO CÁO EXCEL", "MÁY 1", comboBox1.Text);
            string path_may2 = Path.Combine(Location, "BÁO CÁO EXCEL", "MÁY 2", comboBox1.Text);

            DateTime tn = DateTime.Now;
            string time = tn.ToString("dd-MM-yy HH_mm_ss");

            string selectedText = this.comboBox1.Text.Trim();
            
          
                if (Directory.Exists(path_may1))
                {

                    filename = selectedText + " " + time;

                    File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT1.xlsx"), Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx", true);  // tao file tu file REFERENCE

                    wb_May1 = oXL_May1.Workbooks.Open(Path.GetFullPath(path_may1) + "/" + filename.Trim() + ".xlsx");                      // mo file excel 
                    wb_May1.Application.Visible = false;  // chay ngam file excel                                                                
                    ws_May1 = wb_May1.Worksheets[1];
                    oXL_May1.DisplayAlerts = false;   // tat canh bao ve file excel

                thread_export_EXCEL_May1 = new Task(ThreadExportExcel_May1);
               
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

                filename = selectedText + " " + time;

                File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"REPORT2.xlsx"), Path.GetFullPath(path_may2) + "/" + filename.Trim() + ".xlsx", true);  // tao file tu file REFERENCE

                wb_May2 = oXL_May2.Workbooks.Open(Path.GetFullPath(path_may2) + "/" + filename.Trim() + ".xlsx");                      // mo file excel 
                wb_May2.Application.Visible = false;  // chay ngam file excel                                                                
                ws_May2 = wb_May2.Worksheets[1];
                oXL_May2.DisplayAlerts = false;   // tat canh bao ve file excel

                thread_export_EXCEL_May2 = new Task(ThreadExportExcel_May2);
                thread_export_EXCEL_May2.Start();
            }
            

          Task.WaitAll(thread_export_EXCEL_May1, thread_export_EXCEL_May2);
           
                MessageBox.Show(Functions.export_excel_sucessful_cul, Functions.info_caption_cul);
                read.Close();
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
        

           

        private void xuatexcel_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            creat_foder();
            export2EXCEL();
           
            

        }

        private void xoadonhang_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

              string sql, sql_may1, sql_may2;
              string selectItem = comboBox1.Text;


              if (selectItem != "")
              {

                  if (MessageBox.Show(Functions.ask_delete_mslh_text_cul,Functions.info_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                  {
                      sql = "DELETE FROM quanlymanhinhtong WHERE MaLoHang='" + comboBox1.Text + "'";
                      sql_may1 = "DELETE FROM quanlymanhinhmay1 WHERE MaLoHang='" + comboBox1.Text + "'";
                      sql_may2 = "DELETE FROM quanlymanhinhmay2 WHERE MaLoHang='" + comboBox1.Text + "'";
                      
                      
                      
                      Class.Functions.RunSqlDel(sql);
                      Class.Functions.RunSqlDel(sql_may1);
                      Class.Functions.RunSqlDel(sql_may2);
                      
                      
                      
                      comboBox1.Items.Clear();
                      comboBox1.ResetText();
                      loadcombobox();
                      reload_datagridview();
                     
                  }
                 

               
              }
              else if (selectItem == "")
              {
                  
                      MessageBox.Show(Functions.insert_mslh_textstring_cul, Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                      return;
                  
              }
        }
        private void reload_datagridview()
        {
            tbl_baocaodulieu_may1.Clear();
            bcdl_dataGridView_May1.DataSource = null;
            bcdl_dataGridView_May1.Refresh();
            tbl_baocaodulieu_may2.Clear();
            bcdl_dataGridView_May2.DataSource = null;
            bcdl_dataGridView_May2.Refresh();

        }

        private void xoaall_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql, sql_may1, sql_may2;

            if (MessageBox.Show(Functions.delete_all_mslh_textstring_cul, Functions.info_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM quanlymanhinhtong ";
                sql_may1 = "DELETE FROM quanlymanhinhmay1 ";
                sql_may2 = "DELETE FROM quanlymanhinhmay2 ";
                Class.Functions.RunSqlDel(sql);
                Class.Functions.RunSqlDel(sql_may1);
                Class.Functions.RunSqlDel(sql_may2);
                comboBox1.Items.Clear();
                comboBox1.ResetText();
                loadcombobox();
                reload_datagridview();

            }
        }

        private void xemdonhangchay_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataGridView_May1();
            LoadDataGridView_May2();
        }

      

        private void bcdl_dataGridView_May1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (isLoad_datagridview_1 == true)
            {
            foreach (DataGridViewRow Myrow in bcdl_dataGridView_May1.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if ((Myrow.Cells[14].Value).ToString() == "HI")// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                else if ((Myrow.Cells[14].Value).ToString() == "LO")
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Gold;
                }
                else if ((Myrow.Cells[14].Value).ToString() == "OK")
                {
                    Myrow.DefaultCellStyle.BackColor = Color.White;

                }
            }
            }


        }

        private void bcdl_dataGridView_May2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (isLoad_datagridview_2 == true)
            {
                foreach (DataGridViewRow Myrow in bcdl_dataGridView_May2.Rows)
                {            //Here 2 cell is target value and 1 cell is Volume
                    if ((Myrow.Cells[14].Value).ToString() == "HI")// Or your condition 
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    else if ((Myrow.Cells[14].Value).ToString() == "LO")
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.Gold;
                    }
                    else if ((Myrow.Cells[14].Value).ToString() == "OK")
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.White;

                    }
                }
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baocaodulieu_may1();
            baocaodulieu_may2();
        }

        
    }
}
