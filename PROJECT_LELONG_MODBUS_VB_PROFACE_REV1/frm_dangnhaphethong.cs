using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using PROJECT_LELONG_MODBUS_VB_PROFACE_REV1.Class;
using System.Management;
using System.Net.NetworkInformation;


namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    public partial class frm_dangnhaphethong : Form
    {
        resize_function_1 form_resize;
       
        public static string Tendangnhap, Matkhau, Quyen;
    
        public frm_dangnhaphethong()
        {
            InitializeComponent();
            form_resize = new resize_function_1(this);

            this.Load += Load_Inititial_Size_fucntion;
            this.Resize += Resize_function;
        }
        private void Load_Inititial_Size_fucntion(object sender, EventArgs e)
        {
            form_resize._get_initial_size();

        }
        private void Resize_function(object sender, EventArgs e)
        {
            form_resize._resize();

        }

         
        private void frm_dangnhaphethong_Load(object sender, EventArgs e)
        {
          
           
            if (Functions.excel_text_cul == null)
            {
                Functions.VI_cul = true;

                Functions.EN_cul = false;
            }

                SQLiteConnection con = new SQLiteConnection();
                con.ConnectionString = ketnoisql.str;
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = con;
                string sql = "SELECT tendangnhap,matkhau  FROM quanlynguoidung  WHERE (ID = " + 3 + ")";

                cmd = new SQLiteCommand(sql, con);
                SQLiteDataReader dap = cmd.ExecuteReader();

                while (dap.Read())
                {
                    txtTenDangNhap.Text = dap["tendangnhap"].ToString();

                    txtMatKhau.Text = dap["matkhau"].ToString();

                }
                con.Close();
               
                switch_language();
            
              

            }
           
      
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Functions.exit_text_cul, Functions.exit_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
        private void switch_language()
        {
         
            

            if (Functions.VI_cul == true)
            {
                  label2.Text = "Tên Đăng Nhập";
                  label3.Text = "Mật khẩu";
                  label1.Text = "ĐĂNG NHẬP HỆ THỐNG";
                   show_password_checkbox.Text = "Hiện";
                  btnDangNhap.Text ="Đăng nhập";
                  btnThoat.Text = "Thoát";
                  Functions.login_success_cul ="Đăng nhập thành công";
                  Functions.login_fail_cul = "Thông Tin Đăng Nhập Không Đúng.Vui Lòng Kiểm Tra Lại !";
            }
            if (Functions.EN_cul == true)
            {
                label2.Text = "User name";
                label3.Text = "Password";
                label1.Text = "LOG IN SYSTEM WINDOW";
                show_password_checkbox.Text = "Show";
                btnDangNhap.Text = "Log in";
                btnThoat.Text = "Exit";
                Functions.login_success_cul = "Login successfully";
                Functions.login_fail_cul = "Log in fail. Please check again ! !";

            }
          
        
       
          
        
            
           

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = ketnoisql.str;
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;
            string sql = "SELECT * FROM quanlynguoidung WHERE tendangnhap='" + txtTenDangNhap.Text + "' AND matkhau='" + txtMatKhau.Text + "' ";

            cmd = new SQLiteCommand(sql, con);
            SQLiteDataAdapter dap = new SQLiteDataAdapter(cmd);

            System.Data.DataTable dt = new System.Data.DataTable();
            dap.Fill(dt);
      
     
             if (dt.Rows.Count>0)
            {
                MessageBox.Show(Functions.login_success_cul, Functions.info_caption_cul);
                Form_home home = new Form_home(dt.Rows[0][1].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                Tendangnhap = dt.Rows[0][1].ToString();
                Matkhau = dt.Rows[0][1].ToString();
                Quyen = dt.Rows[0][2].ToString();
                home.Show();
                this.Hide();
                

            }
            else
            {
                MessageBox.Show(Functions.login_fail_cul, Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void show_password_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (show_password_checkbox.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }

        }

       
        }

        
    }

