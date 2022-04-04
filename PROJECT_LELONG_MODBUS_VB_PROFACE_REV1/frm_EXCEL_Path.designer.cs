namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    partial class frm_EXCEL_Path
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_browser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_readpath = new System.Windows.Forms.Button();
            this.btn_savepath = new System.Windows.Forms.Button();
            this.lblx_save_config = new System.Windows.Forms.Label();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.lblx_excel_folder_location = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(125, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "CẤU HÌNH THƯ MỤC EXCEL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_browser);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.lblx_save_config);
            this.groupBox2.Controls.Add(this.txt_Path);
            this.groupBox2.Controls.Add(this.lblx_excel_folder_location);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(732, 305);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btn_browser
            // 
            this.btn_browser.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browser.Location = new System.Drawing.Point(676, 119);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(33, 30);
            this.btn_browser.TabIndex = 3;
            this.btn_browser.Text = "...";
            this.btn_browser.UseVisualStyleBackColor = true;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_exit);
            this.groupBox1.Controls.Add(this.btn_readpath);
            this.groupBox1.Controls.Add(this.btn_savepath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 103);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Location = new System.Drawing.Point(506, 52);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(188, 40);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "Thoát";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_readpath
            // 
            this.btn_readpath.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_readpath.Location = new System.Drawing.Point(267, 52);
            this.btn_readpath.Name = "btn_readpath";
            this.btn_readpath.Size = new System.Drawing.Size(188, 40);
            this.btn_readpath.TabIndex = 1;
            this.btn_readpath.Text = "Đọc đường dẫn ";
            this.btn_readpath.UseVisualStyleBackColor = true;
            this.btn_readpath.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // btn_savepath
            // 
            this.btn_savepath.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_savepath.Location = new System.Drawing.Point(28, 52);
            this.btn_savepath.Name = "btn_savepath";
            this.btn_savepath.Size = new System.Drawing.Size(188, 40);
            this.btn_savepath.TabIndex = 0;
            this.btn_savepath.Text = "Lưu đường dẫn";
            this.btn_savepath.UseVisualStyleBackColor = true;
            this.btn_savepath.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lblx_save_config
            // 
            this.lblx_save_config.AutoSize = true;
            this.lblx_save_config.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_save_config.ForeColor = System.Drawing.Color.Blue;
            this.lblx_save_config.Location = new System.Drawing.Point(228, 48);
            this.lblx_save_config.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx_save_config.Name = "lblx_save_config";
            this.lblx_save_config.Size = new System.Drawing.Size(277, 31);
            this.lblx_save_config.TabIndex = 4;
            this.lblx_save_config.Text = "CẤU HÌNH LƯU TRỮ";
            this.lblx_save_config.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_Path
            // 
            this.txt_Path.Location = new System.Drawing.Point(294, 121);
            this.txt_Path.Multiline = true;
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(376, 29);
            this.txt_Path.TabIndex = 1;
            // 
            // lblx_excel_folder_location
            // 
            this.lblx_excel_folder_location.AutoSize = true;
            this.lblx_excel_folder_location.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_excel_folder_location.ForeColor = System.Drawing.Color.Blue;
            this.lblx_excel_folder_location.Location = new System.Drawing.Point(10, 126);
            this.lblx_excel_folder_location.Name = "lblx_excel_folder_location";
            this.lblx_excel_folder_location.Size = new System.Drawing.Size(278, 22);
            this.lblx_excel_folder_location.TabIndex = 0;
            this.lblx_excel_folder_location.Text = "Đường dẫn thư mục lưu EXCEL:";
            // 
            // frm_EXCEL_Path
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 305);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Name = "frm_EXCEL_Path";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.form_EXCEL_Path_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblx_save_config;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Label lblx_excel_folder_location;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_readpath;
        private System.Windows.Forms.Button btn_savepath;
        private System.Windows.Forms.Button btn_browser;
    }
}