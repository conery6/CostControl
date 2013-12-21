﻿namespace CostControl.Maintain
{
    partial class Frm_MData
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
            this.dgv_Mdata = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.comB_Facility = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comB_CC = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comB_FSystem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comB_Year = new System.Windows.Forms.ComboBox();
            this.comB_RpType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_exceladd = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_newbudget = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_UpdateOk = new System.Windows.Forms.Button();
            this.btn_withhold = new System.Windows.Forms.Button();
            this.btn_withholdOK = new System.Windows.Forms.Button();
            this.btn_AddOk = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_whithholdlook = new System.Windows.Forms.Button();
            this.Excelout = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mdata)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Mdata
            // 
            this.dgv_Mdata.AllowUserToAddRows = false;
            this.dgv_Mdata.AllowUserToDeleteRows = false;
            this.dgv_Mdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Mdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.dgv_Mdata.Location = new System.Drawing.Point(25, 140);
            this.dgv_Mdata.Name = "dgv_Mdata";
            this.dgv_Mdata.RowTemplate.Height = 23;
            this.dgv_Mdata.Size = new System.Drawing.Size(908, 382);
            this.dgv_Mdata.TabIndex = 0;
            this.dgv_Mdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Mdata_CellContentClick);
            this.dgv_Mdata.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Mdata_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "设备名";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "类型";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "1月";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "2月";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "3月";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "4月";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "5月";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "6月";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "7月";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "8月";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "9月";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "10月";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "11月";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "12月";
            this.Column14.Name = "Column14";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "工厂";
            // 
            // comB_Facility
            // 
            this.comB_Facility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Facility.FormattingEnabled = true;
            this.comB_Facility.Location = new System.Drawing.Point(64, 42);
            this.comB_Facility.Name = "comB_Facility";
            this.comB_Facility.Size = new System.Drawing.Size(76, 20);
            this.comB_Facility.TabIndex = 2;
            this.comB_Facility.SelectedIndexChanged += new System.EventHandler(this.comB_Facility_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "成本中心";
            // 
            // comB_CC
            // 
            this.comB_CC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_CC.FormattingEnabled = true;
            this.comB_CC.Location = new System.Drawing.Point(220, 42);
            this.comB_CC.Name = "comB_CC";
            this.comB_CC.Size = new System.Drawing.Size(332, 20);
            this.comB_CC.TabIndex = 4;
            this.comB_CC.SelectedIndexChanged += new System.EventHandler(this.comB_CC_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "系统";
            // 
            // comB_FSystem
            // 
            this.comB_FSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_FSystem.FormattingEnabled = true;
            this.comB_FSystem.Location = new System.Drawing.Point(68, 91);
            this.comB_FSystem.Name = "comB_FSystem";
            this.comB_FSystem.Size = new System.Drawing.Size(78, 20);
            this.comB_FSystem.TabIndex = 6;
            this.comB_FSystem.SelectedIndexChanged += new System.EventHandler(this.comB_FSystem_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "年份";
            // 
            // comB_Year
            // 
            this.comB_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Year.FormattingEnabled = true;
            this.comB_Year.Location = new System.Drawing.Point(206, 91);
            this.comB_Year.Name = "comB_Year";
            this.comB_Year.Size = new System.Drawing.Size(82, 20);
            this.comB_Year.TabIndex = 8;
            this.comB_Year.SelectedIndexChanged += new System.EventHandler(this.comB_Year_SelectedIndexChanged);
            this.comB_Year.TextChanged += new System.EventHandler(this.comB_Year_TextChanged);
            // 
            // comB_RpType
            // 
            this.comB_RpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_RpType.FormattingEnabled = true;
            this.comB_RpType.Items.AddRange(new object[] {
            "预算表 T1",
            "预算表 RF1",
            "预算表 RF2",
            "预算表 E1",
            "预提表",
            "Actual表",
            "实际值表"});
            this.comB_RpType.Location = new System.Drawing.Point(374, 91);
            this.comB_RpType.Name = "comB_RpType";
            this.comB_RpType.Size = new System.Drawing.Size(86, 20);
            this.comB_RpType.TabIndex = 9;
            this.comB_RpType.SelectedIndexChanged += new System.EventHandler(this.comB_RpType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "报表类型";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(477, 91);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 12;
            this.btn_Search.Text = "查询";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_exceladd
            // 
            this.btn_exceladd.Location = new System.Drawing.Point(573, 91);
            this.btn_exceladd.Name = "btn_exceladd";
            this.btn_exceladd.Size = new System.Drawing.Size(75, 23);
            this.btn_exceladd.TabIndex = 13;
            this.btn_exceladd.Text = "Excel导入";
            this.btn_exceladd.UseVisualStyleBackColor = true;
            this.btn_exceladd.Click += new System.EventHandler(this.btn_exceladd_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(573, 37);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 14;
            this.btn_update.Text = "修改数据";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(664, 37);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 15;
            this.btn_delete.Text = "删除数据";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_newbudget
            // 
            this.btn_newbudget.Location = new System.Drawing.Point(834, 91);
            this.btn_newbudget.Name = "btn_newbudget";
            this.btn_newbudget.Size = new System.Drawing.Size(75, 23);
            this.btn_newbudget.TabIndex = 16;
            this.btn_newbudget.Text = "初始化新表";
            this.btn_newbudget.UseVisualStyleBackColor = true;
            this.btn_newbudget.Visible = false;
            this.btn_newbudget.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(779, 539);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 30;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_UpdateOk
            // 
            this.btn_UpdateOk.Location = new System.Drawing.Point(676, 539);
            this.btn_UpdateOk.Name = "btn_UpdateOk";
            this.btn_UpdateOk.Size = new System.Drawing.Size(75, 23);
            this.btn_UpdateOk.TabIndex = 29;
            this.btn_UpdateOk.Text = "保存";
            this.btn_UpdateOk.UseVisualStyleBackColor = true;
            this.btn_UpdateOk.Visible = false;
            this.btn_UpdateOk.Click += new System.EventHandler(this.btn_UpdateOk_Click);
            // 
            // btn_withhold
            // 
            this.btn_withhold.Location = new System.Drawing.Point(753, 37);
            this.btn_withhold.Name = "btn_withhold";
            this.btn_withhold.Size = new System.Drawing.Size(75, 23);
            this.btn_withhold.TabIndex = 31;
            this.btn_withhold.Text = "设计预提表";
            this.btn_withhold.UseVisualStyleBackColor = true;
            this.btn_withhold.Click += new System.EventHandler(this.btn_withhold_Click);
            // 
            // btn_withholdOK
            // 
            this.btn_withholdOK.Location = new System.Drawing.Point(505, 539);
            this.btn_withholdOK.Name = "btn_withholdOK";
            this.btn_withholdOK.Size = new System.Drawing.Size(75, 23);
            this.btn_withholdOK.TabIndex = 32;
            this.btn_withholdOK.Text = "保存";
            this.btn_withholdOK.UseVisualStyleBackColor = true;
            this.btn_withholdOK.Visible = false;
            this.btn_withholdOK.Click += new System.EventHandler(this.btn_withholdOK_Click);
            // 
            // btn_AddOk
            // 
            this.btn_AddOk.Location = new System.Drawing.Point(592, 539);
            this.btn_AddOk.Name = "btn_AddOk";
            this.btn_AddOk.Size = new System.Drawing.Size(75, 23);
            this.btn_AddOk.TabIndex = 33;
            this.btn_AddOk.Text = "保存";
            this.btn_AddOk.UseVisualStyleBackColor = true;
            this.btn_AddOk.Visible = false;
            this.btn_AddOk.Click += new System.EventHandler(this.btn_AddOk_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(842, 37);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 34;
            this.btn_add.Text = "增加新预算";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click_1);
            // 
            // btn_whithholdlook
            // 
            this.btn_whithholdlook.Location = new System.Drawing.Point(753, 91);
            this.btn_whithholdlook.Name = "btn_whithholdlook";
            this.btn_whithholdlook.Size = new System.Drawing.Size(75, 23);
            this.btn_whithholdlook.TabIndex = 35;
            this.btn_whithholdlook.Text = "查看预提表";
            this.btn_whithholdlook.UseVisualStyleBackColor = true;
            this.btn_whithholdlook.Visible = false;
            this.btn_whithholdlook.Click += new System.EventHandler(this.btn_whithholdlook_Click);
            // 
            // Excelout
            // 
            this.Excelout.Location = new System.Drawing.Point(664, 91);
            this.Excelout.Name = "Excelout";
            this.Excelout.Size = new System.Drawing.Size(75, 23);
            this.Excelout.TabIndex = 36;
            this.Excelout.Text = "Excel导出";
            this.Excelout.UseVisualStyleBackColor = true;
            this.Excelout.Click += new System.EventHandler(this.Excelout_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Frm_MData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 571);
            this.Controls.Add(this.Excelout);
            this.Controls.Add(this.btn_whithholdlook);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_AddOk);
            this.Controls.Add(this.btn_withholdOK);
            this.Controls.Add(this.btn_withhold);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_UpdateOk);
            this.Controls.Add(this.btn_newbudget);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_exceladd);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comB_RpType);
            this.Controls.Add(this.comB_Year);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comB_FSystem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comB_CC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comB_Facility);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_Mdata);
            this.Name = "Frm_MData";
            this.Text = "MData";
            this.Load += new System.EventHandler(this.MData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Mdata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comB_Facility;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comB_CC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comB_FSystem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comB_Year;
        private System.Windows.Forms.ComboBox comB_RpType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_exceladd;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_newbudget;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_UpdateOk;
        private System.Windows.Forms.Button btn_withhold;
        private System.Windows.Forms.Button btn_withholdOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.Button btn_AddOk;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_whithholdlook;
        private System.Windows.Forms.Button Excelout;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}