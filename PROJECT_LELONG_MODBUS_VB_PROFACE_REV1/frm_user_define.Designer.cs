namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1
{
    partial class frm_user_define
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.save_user_account_ToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_toolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.lblx_id = new System.Windows.Forms.Label();
            this.txt_quyen = new System.Windows.Forms.TextBox();
            this.txt_matkhau = new System.Windows.Forms.TextBox();
            this.txt_tendangnhap = new System.Windows.Forms.TextBox();
            this.lblx_quyen = new System.Windows.Forms.Label();
            this.lblx_matkhau = new System.Windows.Forms.Label();
            this.lblx_tendangnhap = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save_user_account_ToolStrip,
            this.exit_toolStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(773, 31);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // save_user_account_ToolStrip
            // 
            this.save_user_account_ToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.save_user_account_ToolStrip.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_user_account_ToolStrip.ForeColor = System.Drawing.Color.Red;
            this.save_user_account_ToolStrip.Name = "save_user_account_ToolStrip";
            this.save_user_account_ToolStrip.Size = new System.Drawing.Size(57, 27);
            this.save_user_account_ToolStrip.Text = "Lưu";
            this.save_user_account_ToolStrip.Click += new System.EventHandler(this.btn_save);
            // 
            // exit_toolStrip
            // 
            this.exit_toolStrip.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_toolStrip.ForeColor = System.Drawing.Color.Red;
            this.exit_toolStrip.Name = "exit_toolStrip";
            this.exit_toolStrip.Size = new System.Drawing.Size(72, 27);
            this.exit_toolStrip.Text = "Thoát";
            this.exit_toolStrip.Click += new System.EventHandler(this.btn_exit);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.groupBox1.Controls.Add(this.txt_ID);
            this.groupBox1.Controls.Add(this.lblx_id);
            this.groupBox1.Controls.Add(this.txt_quyen);
            this.groupBox1.Controls.Add(this.txt_matkhau);
            this.groupBox1.Controls.Add(this.txt_tendangnhap);
            this.groupBox1.Controls.Add(this.lblx_quyen);
            this.groupBox1.Controls.Add(this.lblx_matkhau);
            this.groupBox1.Controls.Add(this.lblx_tendangnhap);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(773, 574);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txt_ID
            // 
            this.txt_ID.BackColor = System.Drawing.Color.White;
            this.txt_ID.Location = new System.Drawing.Point(163, 14);
            this.txt_ID.Multiline = true;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(81, 26);
            this.txt_ID.TabIndex = 45;
            // 
            // lblx_id
            // 
            this.lblx_id.AutoSize = true;
            this.lblx_id.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_id.ForeColor = System.Drawing.Color.Blue;
            this.lblx_id.Location = new System.Drawing.Point(13, 18);
            this.lblx_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx_id.Name = "lblx_id";
            this.lblx_id.Size = new System.Drawing.Size(41, 22);
            this.lblx_id.TabIndex = 44;
            this.lblx_id.Text = "ID :";
            // 
            // txt_quyen
            // 
            this.txt_quyen.Location = new System.Drawing.Point(163, 164);
            this.txt_quyen.Multiline = true;
            this.txt_quyen.Name = "txt_quyen";
            this.txt_quyen.Size = new System.Drawing.Size(243, 26);
            this.txt_quyen.TabIndex = 43;
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.Location = new System.Drawing.Point(163, 116);
            this.txt_matkhau.Multiline = true;
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.Size = new System.Drawing.Size(243, 26);
            this.txt_matkhau.TabIndex = 42;
            // 
            // txt_tendangnhap
            // 
            this.txt_tendangnhap.Location = new System.Drawing.Point(163, 64);
            this.txt_tendangnhap.Multiline = true;
            this.txt_tendangnhap.Name = "txt_tendangnhap";
            this.txt_tendangnhap.Size = new System.Drawing.Size(243, 26);
            this.txt_tendangnhap.TabIndex = 41;
            // 
            // lblx_quyen
            // 
            this.lblx_quyen.AutoSize = true;
            this.lblx_quyen.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_quyen.ForeColor = System.Drawing.Color.Blue;
            this.lblx_quyen.Location = new System.Drawing.Point(13, 164);
            this.lblx_quyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx_quyen.Name = "lblx_quyen";
            this.lblx_quyen.Size = new System.Drawing.Size(73, 22);
            this.lblx_quyen.TabIndex = 40;
            this.lblx_quyen.Text = "Quyền :";
            // 
            // lblx_matkhau
            // 
            this.lblx_matkhau.AutoSize = true;
            this.lblx_matkhau.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_matkhau.ForeColor = System.Drawing.Color.Blue;
            this.lblx_matkhau.Location = new System.Drawing.Point(13, 117);
            this.lblx_matkhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx_matkhau.Name = "lblx_matkhau";
            this.lblx_matkhau.Size = new System.Drawing.Size(105, 22);
            this.lblx_matkhau.TabIndex = 39;
            this.lblx_matkhau.Text = "Mật khẩu : ";
            // 
            // lblx_tendangnhap
            // 
            this.lblx_tendangnhap.AutoSize = true;
            this.lblx_tendangnhap.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblx_tendangnhap.ForeColor = System.Drawing.Color.Blue;
            this.lblx_tendangnhap.Location = new System.Drawing.Point(13, 67);
            this.lblx_tendangnhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx_tendangnhap.Name = "lblx_tendangnhap";
            this.lblx_tendangnhap.Size = new System.Drawing.Size(142, 22);
            this.lblx_tendangnhap.TabIndex = 38;
            this.lblx_tendangnhap.Text = "Tên đăng nhập :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(767, 371);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(3, 16);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(761, 352);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.Click += new System.EventHandler(this.dataGridView_Click);
            // 
            // frm_user_define
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 605);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frm_user_define";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "change_password";
            this.Load += new System.EventHandler(this.frm_user_define_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem save_user_account_ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem exit_toolStrip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblx_quyen;
        private System.Windows.Forms.Label lblx_matkhau;
        private System.Windows.Forms.Label lblx_tendangnhap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txt_quyen;
        private System.Windows.Forms.TextBox txt_matkhau;
        private System.Windows.Forms.TextBox txt_tendangnhap;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Label lblx_id;
    }
}