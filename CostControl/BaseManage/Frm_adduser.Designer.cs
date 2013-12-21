namespace CostControl.BaseManage
{
    partial class frm_adduser
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
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_exceladd = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgv_adduser = new System.Windows.Forms.DataGridView();
            this.userno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authr2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authr3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authr4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_adduser)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(579, 211);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(64, 21);
            this.btn_save.TabIndex = 24;
            this.btn_save.Text = "保 存";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_exceladd
            // 
            this.btn_exceladd.Location = new System.Drawing.Point(423, 211);
            this.btn_exceladd.Name = "btn_exceladd";
            this.btn_exceladd.Size = new System.Drawing.Size(80, 22);
            this.btn_exceladd.TabIndex = 33;
            this.btn_exceladd.Text = "Excel导入";
            this.btn_exceladd.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(353, 211);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(64, 22);
            this.btn_add.TabIndex = 29;
            this.btn_add.Text = "添 加";
            this.btn_add.UseVisualStyleBackColor = true;
            // 
            // dgv_adduser
            // 
            this.dgv_adduser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_adduser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userno,
            this.username,
            this.userkey,
            this.authr1,
            this.authr2,
            this.authr3,
            this.authr4});
            this.dgv_adduser.Location = new System.Drawing.Point(22, 24);
            this.dgv_adduser.Name = "dgv_adduser";
            this.dgv_adduser.RowTemplate.Height = 23;
            this.dgv_adduser.Size = new System.Drawing.Size(621, 168);
            this.dgv_adduser.TabIndex = 34;
            // 
            // userno
            // 
            this.userno.HeaderText = "员工号";
            this.userno.Name = "userno";
            // 
            // username
            // 
            this.username.HeaderText = "姓名";
            this.username.Name = "username";
            // 
            // userkey
            // 
            this.userkey.HeaderText = "密码";
            this.userkey.Name = "userkey";
            // 
            // authr1
            // 
            this.authr1.HeaderText = "权限1";
            this.authr1.Name = "authr1";
            this.authr1.Width = 70;
            // 
            // authr2
            // 
            this.authr2.HeaderText = "权限2";
            this.authr2.Name = "authr2";
            this.authr2.Width = 70;
            // 
            // authr3
            // 
            this.authr3.HeaderText = "权限3";
            this.authr3.Name = "authr3";
            this.authr3.Width = 70;
            // 
            // authr4
            // 
            this.authr4.HeaderText = "权限4";
            this.authr4.Name = "authr4";
            this.authr4.Width = 70;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(509, 211);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(64, 22);
            this.btn_cancel.TabIndex = 35;
            this.btn_cancel.Text = "取 消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // frm_adduser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 243);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.dgv_adduser);
            this.Controls.Add(this.btn_exceladd);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_add);
            this.Name = "frm_adduser";
            this.Text = "adduser";
            this.Load += new System.EventHandler(this.frm_adduser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_adduser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btn_save;
        internal System.Windows.Forms.Button btn_exceladd;
        internal System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgv_adduser;
        private System.Windows.Forms.DataGridViewTextBoxColumn userno;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn userkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn authr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn authr2;
        private System.Windows.Forms.DataGridViewTextBoxColumn authr3;
        private System.Windows.Forms.DataGridViewTextBoxColumn authr4;
        internal System.Windows.Forms.Button btn_cancel;
    }
}