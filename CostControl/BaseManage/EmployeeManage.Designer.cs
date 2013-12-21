namespace CostControl.BaseManage
{
    partial class EmployeeManage
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
            this.dgv_userdata = new System.Windows.Forms.DataGridView();
            this.Eno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ekey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authr2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authr3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authr4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label1 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.tb_fastsearch = new System.Windows.Forms.TextBox();
            this.cb_authr1 = new System.Windows.Forms.CheckBox();
            this.cb_authr2 = new System.Windows.Forms.CheckBox();
            this.cb_authr3 = new System.Windows.Forms.CheckBox();
            this.cb_authr4 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.comB_FSystem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comB_CC = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comB_Facility = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userdata)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_userdata
            // 
            this.dgv_userdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_userdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eno,
            this.EName,
            this.Ekey,
            this.authr1,
            this.authr2,
            this.authr3,
            this.authr4});
            this.dgv_userdata.Location = new System.Drawing.Point(32, 112);
            this.dgv_userdata.Name = "dgv_userdata";
            this.dgv_userdata.RowTemplate.Height = 23;
            this.dgv_userdata.Size = new System.Drawing.Size(343, 157);
            this.dgv_userdata.TabIndex = 0;
            // 
            // Eno
            // 
            this.Eno.HeaderText = "员工号";
            this.Eno.Name = "Eno";
            // 
            // EName
            // 
            this.EName.HeaderText = "用户名";
            this.EName.Name = "EName";
            // 
            // Ekey
            // 
            this.Ekey.HeaderText = "密码";
            this.Ekey.Name = "Ekey";
            // 
            // authr1
            // 
            this.authr1.HeaderText = "权限1";
            this.authr1.Name = "authr1";
            // 
            // authr2
            // 
            this.authr2.HeaderText = "权限2";
            this.authr2.Name = "authr2";
            // 
            // authr3
            // 
            this.authr3.HeaderText = "权限3";
            this.authr3.Name = "authr3";
            // 
            // authr4
            // 
            this.authr4.HeaderText = "权限4";
            this.authr4.Name = "authr4";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Location = new System.Drawing.Point(30, 70);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(107, 12);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "帐号/姓名快速搜索";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(266, 67);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(50, 21);
            this.btn_search.TabIndex = 20;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // tb_fastsearch
            // 
            this.tb_fastsearch.Location = new System.Drawing.Point(143, 67);
            this.tb_fastsearch.Name = "tb_fastsearch";
            this.tb_fastsearch.Size = new System.Drawing.Size(82, 21);
            this.tb_fastsearch.TabIndex = 19;
            // 
            // cb_authr1
            // 
            this.cb_authr1.AutoSize = true;
            this.cb_authr1.Location = new System.Drawing.Point(26, 26);
            this.cb_authr1.Name = "cb_authr1";
            this.cb_authr1.Size = new System.Drawing.Size(54, 16);
            this.cb_authr1.TabIndex = 21;
            this.cb_authr1.Text = "权限1";
            this.cb_authr1.UseVisualStyleBackColor = true;
            // 
            // cb_authr2
            // 
            this.cb_authr2.AutoSize = true;
            this.cb_authr2.Location = new System.Drawing.Point(26, 58);
            this.cb_authr2.Name = "cb_authr2";
            this.cb_authr2.Size = new System.Drawing.Size(54, 16);
            this.cb_authr2.TabIndex = 22;
            this.cb_authr2.Text = "权限2";
            this.cb_authr2.UseVisualStyleBackColor = true;
            // 
            // cb_authr3
            // 
            this.cb_authr3.AutoSize = true;
            this.cb_authr3.Location = new System.Drawing.Point(26, 89);
            this.cb_authr3.Name = "cb_authr3";
            this.cb_authr3.Size = new System.Drawing.Size(54, 16);
            this.cb_authr3.TabIndex = 23;
            this.cb_authr3.Text = "权限3";
            this.cb_authr3.UseVisualStyleBackColor = true;
            // 
            // cb_authr4
            // 
            this.cb_authr4.AutoSize = true;
            this.cb_authr4.Location = new System.Drawing.Point(26, 121);
            this.cb_authr4.Name = "cb_authr4";
            this.cb_authr4.Size = new System.Drawing.Size(54, 16);
            this.cb_authr4.TabIndex = 24;
            this.cb_authr4.Text = "权限4";
            this.cb_authr4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_authr4);
            this.groupBox1.Controls.Add(this.cb_authr3);
            this.groupBox1.Controls.Add(this.cb_authr2);
            this.groupBox1.Controls.Add(this.cb_authr1);
            this.groupBox1.Location = new System.Drawing.Point(410, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 154);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "权限设置";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(323, 67);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(50, 21);
            this.btn_add.TabIndex = 26;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(379, 67);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(50, 21);
            this.btn_delete.TabIndex = 27;
            this.btn_delete.Text = "删除";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(435, 67);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(50, 21);
            this.btn_save.TabIndex = 28;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // comB_FSystem
            // 
            this.comB_FSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_FSystem.FormattingEnabled = true;
            this.comB_FSystem.Location = new System.Drawing.Point(379, 25);
            this.comB_FSystem.Name = "comB_FSystem";
            this.comB_FSystem.Size = new System.Drawing.Size(78, 20);
            this.comB_FSystem.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "系统";
            // 
            // comB_CC
            // 
            this.comB_CC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_CC.FormattingEnabled = true;
            this.comB_CC.Location = new System.Drawing.Point(234, 25);
            this.comB_CC.Name = "comB_CC";
            this.comB_CC.Size = new System.Drawing.Size(82, 20);
            this.comB_CC.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "成本中心";
            // 
            // comB_Facility
            // 
            this.comB_Facility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Facility.FormattingEnabled = true;
            this.comB_Facility.Location = new System.Drawing.Point(67, 25);
            this.comB_Facility.Name = "comB_Facility";
            this.comB_Facility.Size = new System.Drawing.Size(76, 20);
            this.comB_Facility.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 29;
            this.label4.Text = "工厂";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(491, 67);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(50, 21);
            this.btn_cancel.TabIndex = 35;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // EmployeeManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 294);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.comB_FSystem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comB_CC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comB_Facility);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.tb_fastsearch);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.dgv_userdata);
            this.Name = "EmployeeManage";
            this.Text = "EmployeeManage";
            this.Load += new System.EventHandler(this.EmployeeManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_userdata)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_userdata;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btn_search;
        internal System.Windows.Forms.TextBox tb_fastsearch;
        private System.Windows.Forms.CheckBox cb_authr1;
        private System.Windows.Forms.CheckBox cb_authr2;
        private System.Windows.Forms.CheckBox cb_authr3;
        private System.Windows.Forms.CheckBox cb_authr4;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btn_add;
        internal System.Windows.Forms.Button btn_delete;
        internal System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridViewTextBoxColumn Eno;
        private System.Windows.Forms.DataGridViewTextBoxColumn EName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ekey;
        private System.Windows.Forms.DataGridViewTextBoxColumn authr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn authr2;
        private System.Windows.Forms.DataGridViewTextBoxColumn authr3;
        private System.Windows.Forms.DataGridViewTextBoxColumn authr4;
        private System.Windows.Forms.ComboBox comB_FSystem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comB_CC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comB_Facility;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btn_cancel;
    }
}