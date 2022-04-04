using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PROJECT_LELONG_MODBUS_VB_PROFACE_REV1.Class;

namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    public partial class frm_user_define : Form
    {
        System.Data.DataTable tbl_changepassword;
        Resize_function form_resize_1;
        public frm_user_define()
        {
            InitializeComponent();
            form_resize_1 = new Resize_function(this);
            this.Load += Load_Inititial_Size_fucntion;
            this.Resize += Resize_function;
        }
        private void Load_Inititial_Size_fucntion(object sender, EventArgs e)
        {

            form_resize_1.get_initial_size();
        }
        private void Resize_function(object sender, EventArgs e)
        {

            form_resize_1.resize();
        }
        private void frm_user_define_Load(object sender, EventArgs e)
        {
           
            try
            {
                
                txt_quyen.Enabled = false;
                Functions.ConnectSQL();
                LoadDataGridView();

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
            
                lblx_id.Text= "ID";
                lblx_tendangnhap.Text = "Tên đăng nhập";
                lblx_matkhau.Text = "Mật khẩu";
                lblx_quyen.Text = "Quyền";
                this.Text = "Thông tin tài khoản hệ thống";
                save_user_account_ToolStrip.Text = "Lưu";
                exit_toolStrip.Text = "Thoát";
            }
            else if (Functions.EN_cul == true)
            {
         
                lblx_id.Text = "ID";
                lblx_tendangnhap.Text = "User account";
                lblx_matkhau.Text = "Password";
                lblx_quyen.Text = "Permission";
                this.Text = "System account information";
                save_user_account_ToolStrip.Text = "Save";
                exit_toolStrip.Text = "Exit";

            }
         
        

        }
        private void LoadDataGridView()
        {

            string sql;
         
           sql = "SELECT ID,tendangnhap,matkhau,quyen FROM quanlynguoidung";
           tbl_changepassword = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
           dataGridView.DataSource = tbl_changepassword; //Nguồn dữ liệu            

           if (Functions.VI_cul == true)
           {
               dataGridView.Columns[0].HeaderText = "ID";
               dataGridView.Columns[1].HeaderText = "Tên đăng nhập";
               dataGridView.Columns[2].HeaderText = "Mật khẩu";
               dataGridView.Columns[3].HeaderText = "Quyền hạn";
           }
           else if (Functions.EN_cul == true)
           {
               dataGridView.Columns[0].HeaderText = "ID";
               dataGridView.Columns[1].HeaderText = "User account";
               dataGridView.Columns[2].HeaderText = "Password";
               dataGridView.Columns[3].HeaderText = "Permission";

           }

           dataGridView.Columns[0].Width = 100;
           dataGridView.Columns[1].Width = 200;
           dataGridView.Columns[2].Width = 200;
           dataGridView.Columns[3].Width = 120;

           dataGridView.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
           dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp

       
           dataGridView.Refresh();

        }
        private void dataGridView_Click(object sender, EventArgs e)
        {
            if (tbl_changepassword.Rows.Count == 0) //Nếu không có dữ liệu
            {
                if(Functions.VI_cul == true)
                {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_ID.Text = dataGridView.CurrentRow.Cells["ID"].Value.ToString();
                txt_tendangnhap.Text = dataGridView.CurrentRow.Cells["tendangnhap"].Value.ToString();
                txt_matkhau.Text = dataGridView.CurrentRow.Cells["matkhau"].Value.ToString();
                txt_quyen.Text = dataGridView.CurrentRow.Cells["quyen"].Value.ToString();
                }
                else if(Functions.EN_cul == true)
                {
                    MessageBox.Show("No data save !", Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView.Columns[0].HeaderText = "ID";
                    dataGridView.Columns[1].HeaderText = "User account";
                    dataGridView.Columns[2].HeaderText = "Password";
                    dataGridView.Columns[3].HeaderText = "Permission";

                }
                return;
            }
         
            
        }

        private void btn_save(object sender, EventArgs e)
        {
            if (Functions.VI_cul == true)
            {
              if (tbl_changepassword.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txt_tendangnhap.Text.Trim().Length==0) 
                {
                    MessageBox.Show("Bạn chưa nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txt_matkhau.Text.Trim().Length == 0) 
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
               
              

                
                if (MessageBox.Show("Bạn có muốn cập nhật tài khoản không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "UPDATE quanlynguoidung SET tendangnhap='" + txt_tendangnhap.Text + "',matkhau='" + txt_matkhau.Text + "'WHERE ID='" + txt_ID.Text + "'";
                    Class.Functions.RunSQL(sql);
                 
                    LoadDataGridView();

                    ResetValue();
                }
            }
            else if (Functions.EN_cul== true)
            {
                if (tbl_changepassword.Rows.Count == 0)
                {
                    MessageBox.Show("No data save", Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txt_tendangnhap.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please type your user account", Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txt_matkhau.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please type your password", Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }




                if (MessageBox.Show("Do you want to update account ?", Functions.info_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "UPDATE quanlynguoidung SET tendangnhap='" + txt_tendangnhap.Text + "',matkhau='" + txt_matkhau.Text + "'WHERE ID='" + txt_ID.Text + "'";
                    Class.Functions.RunSQL(sql);

                    LoadDataGridView();

                    ResetValue();
                }


            }
            }
          private void ResetValue()
        {
            txt_tendangnhap.Text = "";
            txt_matkhau.Text = "";
            txt_quyen.Text = "";
            txt_ID.Text = "";
          

        }




        private void btn_exit(object sender, EventArgs e)
        {
           Functions.DisconnectSQL();
           this.Close();
        }

        
      
      
    }
}
