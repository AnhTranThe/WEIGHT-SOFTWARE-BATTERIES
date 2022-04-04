using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using PROJECT_LELONG_MODBUS_VB_PROFACE_REV1.Class;

namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    public partial class frm_EXCEL_Path : Form
    {
       
        public frm_EXCEL_Path()
        {
            InitializeComponent();
        }

        private void form_EXCEL_Path_Load(object sender, EventArgs e)
        {
      
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));
            txt_Path.Text = read.ReadToEnd();
            read.Close();
            
            if (txt_Path.Text.Trim().Length == 0)
            {
                MessageBox.Show("Đường dẫn chưa có. Hãy thêm đường dẫn đến thư mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            switch_language();
            
        }
        private void switch_language()
        {
            if (Functions.VI_cul == true)
            {
             
                lblx_save_config.Text = "CẤU HÌNH LƯU TRỮ";
                lblx_excel_folder_location.Text = "Đường dẫn thư mục EXCEL :";
                btn_savepath.Text = "Lưu đường dẫn";
                btn_readpath.Text = "Đọc đường dẫn";
                btn_exit.Text = "Thoát";
              
            }
            else if (Functions.EN_cul == true)
            {
             
                lblx_save_config.Text = "SAVE CONFIGURATION";
                lblx_excel_folder_location.Text = "EXCEL directory path :";
                btn_savepath.Text = "Save file path";
                btn_readpath.Text = "Read file path";
                btn_exit.Text = "Exit";

            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (Functions.VI_cul == true)
            {
                if (txt_Path.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
                {
                    MessageBox.Show("Bạn chưa nhập đường dẫn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Path.Focus();
                    return;
                }
                if (MessageBox.Show("Bạn có muốn lưu đường dẫn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StreamWriter write = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"), false);
                    write.WriteLine(txt_Path.Text);
                    write.Close();

                }
            }
            else if (Functions.EN_cul == true)
            {

                if (txt_Path.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
                {
                    MessageBox.Show("You have not entered the path",Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Path.Focus();
                    return;
                }
                if (MessageBox.Show("Do you want to save the path?", Functions.info_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StreamWriter write = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"), false);
                    write.WriteLine(txt_Path.Text);
                    write.Close();

                }

            }


        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Excel_Folder.txt"));
            txt_Path.Text = read.ReadToEnd();
            read.Close();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog() { Description = "Chọn đường dẫn đến file." })
            {

                if (folder.ShowDialog() == DialogResult.OK)
                {

                    txt_Path.Text = folder.SelectedPath;
                }

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
   
    }
}
