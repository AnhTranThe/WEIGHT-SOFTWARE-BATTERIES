namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    partial class frm_mail_SMS
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
            this.lblx_user_mail = new System.Windows.Forms.Label();
            this.lblx_mail_pass = new System.Windows.Forms.Label();
            this.lblx_ccmail = new System.Windows.Forms.Label();
            this.lblx_tomail = new System.Windows.Forms.Label();
            this.lblx_subject = new System.Windows.Forms.Label();
            this.txt_sender_mail = new System.Windows.Forms.TextBox();
            this.txt_cc_mail = new System.Windows.Forms.TextBox();
            this.txt_to_mail = new System.Windows.Forms.TextBox();
            this.txt_subject_mail = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_readpath_mail = new System.Windows.Forms.Button();
            this.btn_savepath_mail = new System.Windows.Forms.Button();
            this.lblx_mail_information = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.show_password_checkbox = new System.Windows.Forms.CheckBox();
            this.txt_password_mail = new System.Windows.Forms.TextBox();
            this.lblx_acidchuyen = new System.Windows.Forms.Label();
            this.txt_acidchuyen = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblx_user_mail
            // 
            this.lblx_user_mail.AutoSize = true;
            this.lblx_user_mail.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_user_mail.ForeColor = System.Drawing.Color.Blue;
            this.lblx_user_mail.Location = new System.Drawing.Point(102, 83);
            this.lblx_user_mail.Name = "lblx_user_mail";
            this.lblx_user_mail.Size = new System.Drawing.Size(154, 26);
            this.lblx_user_mail.TabIndex = 6;
            this.lblx_user_mail.Text = "Mail chuyền :";
            // 
            // lblx_mail_pass
            // 
            this.lblx_mail_pass.AutoSize = true;
            this.lblx_mail_pass.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_mail_pass.ForeColor = System.Drawing.Color.Blue;
            this.lblx_mail_pass.Location = new System.Drawing.Point(102, 169);
            this.lblx_mail_pass.Name = "lblx_mail_pass";
            this.lblx_mail_pass.Size = new System.Drawing.Size(181, 26);
            this.lblx_mail_pass.TabIndex = 7;
            this.lblx_mail_pass.Text = "Mật khẩu Mail :";
            // 
            // lblx_ccmail
            // 
            this.lblx_ccmail.AutoSize = true;
            this.lblx_ccmail.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_ccmail.ForeColor = System.Drawing.Color.Blue;
            this.lblx_ccmail.Location = new System.Drawing.Point(102, 426);
            this.lblx_ccmail.Name = "lblx_ccmail";
            this.lblx_ccmail.Size = new System.Drawing.Size(109, 26);
            this.lblx_ccmail.TabIndex = 8;
            this.lblx_ccmail.Text = "Cc  Mail:";
            // 
            // lblx_tomail
            // 
            this.lblx_tomail.AutoSize = true;
            this.lblx_tomail.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_tomail.ForeColor = System.Drawing.Color.Blue;
            this.lblx_tomail.Location = new System.Drawing.Point(102, 252);
            this.lblx_tomail.Name = "lblx_tomail";
            this.lblx_tomail.Size = new System.Drawing.Size(100, 26);
            this.lblx_tomail.TabIndex = 10;
            this.lblx_tomail.Text = "To Mail:";
            // 
            // lblx_subject
            // 
            this.lblx_subject.AutoSize = true;
            this.lblx_subject.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_subject.ForeColor = System.Drawing.Color.Blue;
            this.lblx_subject.Location = new System.Drawing.Point(103, 512);
            this.lblx_subject.Name = "lblx_subject";
            this.lblx_subject.Size = new System.Drawing.Size(99, 26);
            this.lblx_subject.TabIndex = 11;
            this.lblx_subject.Text = "Chủ đề :";
            // 
            // txt_sender_mail
            // 
            this.txt_sender_mail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_sender_mail.BackColor = System.Drawing.Color.White;
            this.txt_sender_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sender_mail.Location = new System.Drawing.Point(361, 87);
            this.txt_sender_mail.Name = "txt_sender_mail";
            this.txt_sender_mail.Size = new System.Drawing.Size(1386, 34);
            this.txt_sender_mail.TabIndex = 14;
            // 
            // txt_cc_mail
            // 
            this.txt_cc_mail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_cc_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cc_mail.Location = new System.Drawing.Point(361, 426);
            this.txt_cc_mail.Name = "txt_cc_mail";
            this.txt_cc_mail.Size = new System.Drawing.Size(1386, 34);
            this.txt_cc_mail.TabIndex = 16;
            this.txt_cc_mail.Enter += new System.EventHandler(this.txt_cc_mail_Enter);
            this.txt_cc_mail.Leave += new System.EventHandler(this.txt_cc_mail_Leave);
            // 
            // txt_to_mail
            // 
            this.txt_to_mail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_to_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_to_mail.Location = new System.Drawing.Point(361, 256);
            this.txt_to_mail.Name = "txt_to_mail";
            this.txt_to_mail.Size = new System.Drawing.Size(1386, 34);
            this.txt_to_mail.TabIndex = 18;
            // 
            // txt_subject_mail
            // 
            this.txt_subject_mail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_subject_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_subject_mail.Location = new System.Drawing.Point(361, 516);
            this.txt_subject_mail.Name = "txt_subject_mail";
            this.txt_subject_mail.Size = new System.Drawing.Size(1386, 34);
            this.txt_subject_mail.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Controls.Add(this.btn_readpath_mail);
            this.panel1.Controls.Add(this.btn_savepath_mail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 589);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1902, 101);
            this.panel1.TabIndex = 23;
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_exit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Location = new System.Drawing.Point(1394, 26);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(244, 54);
            this.btn_exit.TabIndex = 27;
            this.btn_exit.Text = "Thoát";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_readpath_mail
            // 
            this.btn_readpath_mail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_readpath_mail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_readpath_mail.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_readpath_mail.Location = new System.Drawing.Point(829, 26);
            this.btn_readpath_mail.Name = "btn_readpath_mail";
            this.btn_readpath_mail.Size = new System.Drawing.Size(244, 54);
            this.btn_readpath_mail.TabIndex = 25;
            this.btn_readpath_mail.Text = "Đọc thông tin";
            this.btn_readpath_mail.UseVisualStyleBackColor = false;
            this.btn_readpath_mail.Click += new System.EventHandler(this.btn_readpath_Click);
            // 
            // btn_savepath_mail
            // 
            this.btn_savepath_mail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_savepath_mail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_savepath_mail.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_savepath_mail.Location = new System.Drawing.Point(264, 26);
            this.btn_savepath_mail.Name = "btn_savepath_mail";
            this.btn_savepath_mail.Size = new System.Drawing.Size(244, 54);
            this.btn_savepath_mail.TabIndex = 24;
            this.btn_savepath_mail.Text = "Lưu thông tin";
            this.btn_savepath_mail.UseVisualStyleBackColor = false;
            this.btn_savepath_mail.Click += new System.EventHandler(this.btn_savepath_Click);
            // 
            // lblx_mail_information
            // 
            this.lblx_mail_information.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_mail_information.ForeColor = System.Drawing.Color.Black;
            this.lblx_mail_information.Location = new System.Drawing.Point(703, 18);
            this.lblx_mail_information.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx_mail_information.Name = "lblx_mail_information";
            this.lblx_mail_information.Size = new System.Drawing.Size(496, 35);
            this.lblx_mail_information.TabIndex = 24;
            this.lblx_mail_information.Text = "Thông tin Mail";
            this.lblx_mail_information.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // show_password_checkbox
            // 
            this.show_password_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_password_checkbox.AutoSize = true;
            this.show_password_checkbox.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show_password_checkbox.ForeColor = System.Drawing.Color.Blue;
            this.show_password_checkbox.Location = new System.Drawing.Point(1785, 175);
            this.show_password_checkbox.Name = "show_password_checkbox";
            this.show_password_checkbox.Size = new System.Drawing.Size(84, 30);
            this.show_password_checkbox.TabIndex = 40;
            this.show_password_checkbox.Text = "Hiện";
            this.show_password_checkbox.UseVisualStyleBackColor = true;
            this.show_password_checkbox.CheckedChanged += new System.EventHandler(this.show_password_checkbox_CheckedChanged);
            // 
            // txt_password_mail
            // 
            this.txt_password_mail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_password_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password_mail.Location = new System.Drawing.Point(361, 173);
            this.txt_password_mail.Margin = new System.Windows.Forms.Padding(4);
            this.txt_password_mail.Name = "txt_password_mail";
            this.txt_password_mail.Size = new System.Drawing.Size(1386, 34);
            this.txt_password_mail.TabIndex = 41;
            this.txt_password_mail.UseSystemPasswordChar = true;
            // 
            // lblx_acidchuyen
            // 
            this.lblx_acidchuyen.AutoSize = true;
            this.lblx_acidchuyen.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_acidchuyen.ForeColor = System.Drawing.Color.Blue;
            this.lblx_acidchuyen.Location = new System.Drawing.Point(101, 341);
            this.lblx_acidchuyen.Name = "lblx_acidchuyen";
            this.lblx_acidchuyen.Size = new System.Drawing.Size(153, 26);
            this.lblx_acidchuyen.TabIndex = 42;
            this.lblx_acidchuyen.Text = "Acid chuyền :";
            // 
            // txt_acidchuyen
            // 
            this.txt_acidchuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_acidchuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_acidchuyen.Location = new System.Drawing.Point(361, 345);
            this.txt_acidchuyen.Name = "txt_acidchuyen";
            this.txt_acidchuyen.Size = new System.Drawing.Size(1386, 34);
            this.txt_acidchuyen.TabIndex = 43;
            // 
            // frm_mail_SMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1902, 690);
            this.ControlBox = false;
            this.Controls.Add(this.txt_acidchuyen);
            this.Controls.Add(this.lblx_acidchuyen);
            this.Controls.Add(this.txt_password_mail);
            this.Controls.Add(this.show_password_checkbox);
            this.Controls.Add(this.lblx_mail_information);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_subject_mail);
            this.Controls.Add(this.txt_to_mail);
            this.Controls.Add(this.txt_cc_mail);
            this.Controls.Add(this.txt_sender_mail);
            this.Controls.Add(this.lblx_subject);
            this.Controls.Add(this.lblx_tomail);
            this.Controls.Add(this.lblx_ccmail);
            this.Controls.Add(this.lblx_mail_pass);
            this.Controls.Add(this.lblx_user_mail);
            this.Name = "frm_mail_SMS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CẤU HÌNH GỬI MAIL & SMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_mail_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblx_user_mail;
        private System.Windows.Forms.Label lblx_mail_pass;
        private System.Windows.Forms.Label lblx_ccmail;
        private System.Windows.Forms.Label lblx_tomail;
        private System.Windows.Forms.Label lblx_subject;
        private System.Windows.Forms.TextBox txt_sender_mail;
        private System.Windows.Forms.TextBox txt_cc_mail;
        private System.Windows.Forms.TextBox txt_to_mail;
        private System.Windows.Forms.TextBox txt_subject_mail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_readpath_mail;
        private System.Windows.Forms.Button btn_savepath_mail;
        private System.Windows.Forms.Label lblx_mail_information;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.CheckBox show_password_checkbox;
        private System.Windows.Forms.TextBox txt_password_mail;
        private System.Windows.Forms.Label lblx_acidchuyen;
        private System.Windows.Forms.TextBox txt_acidchuyen;
    }
}