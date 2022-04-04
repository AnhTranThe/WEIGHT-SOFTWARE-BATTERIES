using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Net;

using PROJECT_LELONG_MODBUS_VB_PROFACE_REV1.Class;



namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    public partial class frm_mail_SMS : Form
    {
        resize_function_1 form_resize_1;

        public frm_mail_SMS()
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
       
        private void frm_mail_Load(object sender, EventArgs e)
        {
            btn_readpath_mail.Enabled = true;
            btn_savepath_mail.Enabled = true;
           
     
         
            switch_language();
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"CC_Mail.txt"));
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt"));


            txt_sender_mail.Text = lines[0];
            txt_password_mail.Text =lines[1];
            txt_to_mail.Text =lines[2];
            
            txt_subject_mail.Text =lines[3];
            txt_acidchuyen.Text =lines[4];
        
          


            txt_cc_mail.Text = read.ReadToEnd();


         
         
            
            
            read.Close();
           



            if (txt_sender_mail.Text.Trim().Length == 0 || txt_password_mail.Text.Trim().Length == 0 || txt_to_mail.Text.Trim().Length == 0 || txt_subject_mail.Text.Trim().Length == 0 ||  txt_acidchuyen.Text.Trim().Length == 0 )
            {
                MessageBox.Show("Thông tin chưa đầy đủ. Vui lòng cập nhật lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_readpath_mail.Enabled = false;
            }
        }
        private void switch_language()
        {
            if (Functions.VI_cul == true)
            {
                lblx_user_mail.Text = "Mail chuyền :";
                lblx_mail_pass.Text = "Mật khẩu Mail :";
                lblx_acidchuyen.Text = "Acid chuyền :";
                lblx_subject.Text = "Chủ đề :";
             
            
                show_password_checkbox.Text = "Hiện";
                btn_savepath_mail.Text = "Lưu thông tin";
                btn_readpath_mail.Text ="Đọc thông tin";
                btn_exit.Text = "Thoát";
                lblx_mail_information.Text = "Thông tin Mail";
                this.Text ="Cấu hình gửi Mail ";

            }
            else if (Functions.EN_cul == true)
            {
                lblx_user_mail.Text = "Mail chain :";
                lblx_mail_pass.Text = "Mail password :";
                lblx_acidchuyen.Text = "Acid chain :";
                lblx_subject.Text = "Subjects :";
             
               // lblx_body_message.Text = "Message :";
                show_password_checkbox.Text = "Show";
                btn_savepath_mail.Text = "Save information";
                btn_readpath_mail.Text = "Read information";
                btn_exit.Text = "Exit";
                lblx_mail_information.Text = " Mail information";
                this.Text = "Configuration send Mail ";
              
              

            }

          
        }
        private void btn_savepath_Click(object sender, EventArgs e)
        {
            if (Functions.VI_cul == true)
            {
                if (txt_sender_mail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mail của chuyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_sender_mail.Focus();

                    return;
                }
               else if (txt_acidchuyen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên acid chuyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_acidchuyen.Focus();
                    return;
                }


                else if(txt_password_mail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mật khẩu mail của chuyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_password_mail.Focus();
                    return;
                }



                else if(txt_to_mail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ mail người nhận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_to_mail.Focus();
                    return;
                }


                else if(txt_subject_mail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập chủ đề Mail & SMS", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_subject_mail.Focus();
                    return;
                }

              
               





                if (MessageBox.Show("Bạn có muốn lưu đường dẫn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StreamWriter write = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt"), false);
                    write.WriteLine(txt_sender_mail.Text);
                    write.WriteLine(txt_password_mail.Text);
                    write.WriteLine(txt_to_mail.Text);

                    write.WriteLine(txt_subject_mail.Text);
                    write.WriteLine(txt_acidchuyen.Text);
                    write.Close();

                    StreamWriter write2 = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), @"CC_Mail.txt"), false);

                    write2.WriteLine(txt_cc_mail.Text.Trim());

                    write2.Close();

                    btn_readpath_mail.Enabled = true;
                    MessageBox.Show("Lưu thông tin thành công", " Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }



            /////////////////////////////////////
            
            else if (Functions.EN_cul == true)
            {
                if (txt_sender_mail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter the chain's email", Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_sender_mail.Focus();

                    return;
                }
                if (txt_acidchuyen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter acid chain", Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_acidchuyen.Focus();
                    return;
                }


                if (txt_password_mail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter the chain's email password", Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_password_mail.Focus();
                    return;
                }



                if (txt_to_mail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter the recipient's email address", Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_to_mail.Focus();
                    return;
                }


                if (txt_subject_mail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must enter the subject Mail & SMS", Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_subject_mail.Focus();
                    return;
                }

                
            





                if (MessageBox.Show("Do you want to save the link ?", Functions.info_caption_cul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StreamWriter write = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt"), false);
                    write.WriteLine(txt_sender_mail.Text);
                    write.WriteLine(txt_password_mail.Text);
                    write.WriteLine(txt_to_mail.Text);

                    write.WriteLine(txt_subject_mail.Text);
                    write.WriteLine(txt_acidchuyen.Text);
                   
                    write.Close();

                    StreamWriter write2 = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), @"CC_Mail.txt"), false);

                    write2.WriteLine(txt_cc_mail.Text);

                    write2.Close();

                    btn_readpath_mail.Enabled = true;
                    MessageBox.Show("Save successful !", Functions.info_caption_cul, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btn_readpath_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), @"CC_Mail.txt"));
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), @"Path_Mail_SMS.txt"));


            txt_sender_mail.Text = lines[0];
            txt_password_mail.Text = lines[1];
            txt_to_mail.Text = lines[2];

            txt_subject_mail.Text = lines[3];
            txt_acidchuyen.Text = lines[4];
           


            txt_cc_mail.Text = read.ReadToEnd();

            read.Close();
        //    read1.Close();

        }

                   

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void show_password_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (show_password_checkbox.Checked)
            {
                txt_password_mail.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password_mail.UseSystemPasswordChar = true;
            }

        }

        private ToolTip tt;

        private void txt_cc_mail_Enter(object sender, EventArgs e)
        {
            tt = new ToolTip();
            Point pt = new Point(-1000, -100);
            pt.Offset(txt_cc_mail.Width - 1, txt_cc_mail.Height - 1);
            tt.AutoPopDelay = 10000;
            tt.InitialDelay = 200;
            tt.ShowAlways = true;
            tt.ReshowDelay = 200;
            tt.IsBalloon = true;
            tt.UseAnimation = true;
            tt.ToolTipIcon = ToolTipIcon.Info;
            tt.ToolTipTitle = "Hướng dẫn sử dụng";
          
            tt.Show(string.Empty, txt_cc_mail);
            tt.Show("Nhập dấu chấm phẩy ' ; ' giữa các mail CC !", txt_cc_mail,pt);

           
          
        }

        private void txt_cc_mail_Leave(object sender, EventArgs e)
        {
            tt.Dispose();
        }


    

       
    }
}
