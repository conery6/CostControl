﻿namespace CostControl.RawMaterial
{
    partial class Frm_RMData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comB_CC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comB_Facility = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comB_RpType = new System.Windows.Forms.ComboBox();
            this.comB_Year = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.dgv_rmdata = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Excelout = new System.Windows.Forms.Button();
            this.btn_SearchPeriod = new System.Windows.Forms.Button();
            this.comB_Month = new System.Windows.Forms.ComboBox();
            this.comB_Product = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rmdata)).BeginInit();
            this.SuspendLayout();
            // 
            // comB_CC
            // 
            this.comB_CC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_CC.FormattingEnabled = true;
            this.comB_CC.Location = new System.Drawing.Point(235, 40);
            this.comB_CC.Name = "comB_CC";
            this.comB_CC.Size = new System.Drawing.Size(365, 20);
            this.comB_CC.TabIndex = 8;
            this.comB_CC.SelectedIndexChanged += new System.EventHandler(this.comB_CC_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "成本中心";
            // 
            // comB_Facility
            // 
            this.comB_Facility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Facility.FormattingEnabled = true;
            this.comB_Facility.Items.AddRange(new object[] {
            "CG_Hynix WX",
            "CG_CHJ"});
            this.comB_Facility.Location = new System.Drawing.Point(79, 40);
            this.comB_Facility.Name = "comB_Facility";
            this.comB_Facility.Size = new System.Drawing.Size(91, 20);
            this.comB_Facility.TabIndex = 6;
            this.comB_Facility.SelectedIndexChanged += new System.EventHandler(this.comB_Facility_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "工厂";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "报表类型";
            // 
            // comB_RpType
            // 
            this.comB_RpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_RpType.FormattingEnabled = true;
            this.comB_RpType.Items.AddRange(new object[] {
            "T1",
            "RF1",
            "RF2",
            "E3",
            "Actual"});
            this.comB_RpType.Location = new System.Drawing.Point(342, 86);
            this.comB_RpType.Name = "comB_RpType";
            this.comB_RpType.Size = new System.Drawing.Size(64, 20);
            this.comB_RpType.TabIndex = 15;
            this.comB_RpType.SelectedIndexChanged += new System.EventHandler(this.comB_RpType_SelectedIndexChanged);
            // 
            // comB_Year
            // 
            this.comB_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Year.FormattingEnabled = true;
            this.comB_Year.Location = new System.Drawing.Point(195, 86);
            this.comB_Year.Name = "comB_Year";
            this.comB_Year.Size = new System.Drawing.Size(82, 20);
            this.comB_Year.TabIndex = 14;
            this.comB_Year.SelectedIndexChanged += new System.EventHandler(this.comB_Year_SelectedIndexChanged);
            this.comB_Year.TextChanged += new System.EventHandler(this.comB_Year_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "年份";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(542, 83);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(58, 23);
            this.btn_Search.TabIndex = 17;
            this.btn_Search.Text = "查询";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // dgv_rmdata
            // 
            this.dgv_rmdata.AllowUserToAddRows = false;
            this.dgv_rmdata.AllowUserToDeleteRows = false;
            this.dgv_rmdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_rmdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
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
            this.Column13});
            this.dgv_rmdata.Location = new System.Drawing.Point(46, 138);
            this.dgv_rmdata.Name = "dgv_rmdata";
            this.dgv_rmdata.ReadOnly = true;
            this.dgv_rmdata.RowHeadersVisible = false;
            this.dgv_rmdata.RowTemplate.Height = 23;
            this.dgv_rmdata.Size = new System.Drawing.Size(851, 387);
            this.dgv_rmdata.TabIndex = 38;
            this.dgv_rmdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_rmdata_CellContentClick);
            this.dgv_rmdata.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_rmdata_CellEndEdit);
            this.dgv_rmdata.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_rmdata_DataError);
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            dataGridViewCellStyle14.NullValue = null;
            this.Type.DefaultCellStyle = dataGridViewCellStyle14;
            this.Type.HeaderText = "科目编号";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TypeName";
            this.Column1.HeaderText = "科目";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "M1";
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column2.HeaderText = "1";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "M2";
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column3.HeaderText = "2";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "M3";
            dataGridViewCellStyle17.Format = "N2";
            dataGridViewCellStyle17.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column4.HeaderText = "3";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "M4";
            dataGridViewCellStyle18.Format = "N2";
            dataGridViewCellStyle18.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle18;
            this.Column5.HeaderText = "4";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "M5";
            dataGridViewCellStyle19.Format = "N2";
            dataGridViewCellStyle19.NullValue = null;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column6.HeaderText = "5";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "M6";
            dataGridViewCellStyle20.Format = "N2";
            dataGridViewCellStyle20.NullValue = null;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle20;
            this.Column7.HeaderText = "6";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "M7";
            dataGridViewCellStyle21.Format = "N2";
            dataGridViewCellStyle21.NullValue = null;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle21;
            this.Column8.HeaderText = "7";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "M8";
            dataGridViewCellStyle22.Format = "N2";
            dataGridViewCellStyle22.NullValue = null;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle22;
            this.Column9.HeaderText = "8";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "M9";
            dataGridViewCellStyle23.Format = "N2";
            dataGridViewCellStyle23.NullValue = null;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column10.HeaderText = "9";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "M10";
            dataGridViewCellStyle24.Format = "N2";
            dataGridViewCellStyle24.NullValue = null;
            this.Column11.DefaultCellStyle = dataGridViewCellStyle24;
            this.Column11.HeaderText = "10";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "M11";
            dataGridViewCellStyle25.Format = "N2";
            dataGridViewCellStyle25.NullValue = null;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle25;
            this.Column12.HeaderText = "11";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "M12";
            dataGridViewCellStyle26.Format = "N2";
            dataGridViewCellStyle26.NullValue = null;
            this.Column13.DefaultCellStyle = dataGridViewCellStyle26;
            this.Column13.HeaderText = "12";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Excelout
            // 
            this.Excelout.Location = new System.Drawing.Point(803, 81);
            this.Excelout.Name = "Excelout";
            this.Excelout.Size = new System.Drawing.Size(83, 29);
            this.Excelout.TabIndex = 41;
            this.Excelout.Text = "Excel导出";
            this.Excelout.UseVisualStyleBackColor = true;
            this.Excelout.Click += new System.EventHandler(this.Excelout_Click);
            // 
            // btn_SearchPeriod
            // 
            this.btn_SearchPeriod.Location = new System.Drawing.Point(412, 85);
            this.btn_SearchPeriod.Name = "btn_SearchPeriod";
            this.btn_SearchPeriod.Size = new System.Drawing.Size(59, 23);
            this.btn_SearchPeriod.TabIndex = 42;
            this.btn_SearchPeriod.Text = "查询";
            this.btn_SearchPeriod.UseVisualStyleBackColor = true;
            this.btn_SearchPeriod.Click += new System.EventHandler(this.btn_SearchPeriod_Click);
            // 
            // comB_Month
            // 
            this.comB_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Month.FormattingEnabled = true;
            this.comB_Month.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comB_Month.Location = new System.Drawing.Point(477, 86);
            this.comB_Month.Name = "comB_Month";
            this.comB_Month.Size = new System.Drawing.Size(59, 20);
            this.comB_Month.TabIndex = 43;
            this.comB_Month.SelectedIndexChanged += new System.EventHandler(this.comB_Month_SelectedIndexChanged);
            // 
            // comB_Product
            // 
            this.comB_Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Product.FormattingEnabled = true;
            this.comB_Product.Location = new System.Drawing.Point(79, 86);
            this.comB_Product.Name = "comB_Product";
            this.comB_Product.Size = new System.Drawing.Size(77, 20);
            this.comB_Product.TabIndex = 48;
            this.comB_Product.SelectedIndexChanged += new System.EventHandler(this.comB_Product_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "产品";
            // 
            // Frm_RMData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 608);
            this.Controls.Add(this.comB_Product);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comB_Month);
            this.Controls.Add(this.btn_SearchPeriod);
            this.Controls.Add(this.Excelout);
            this.Controls.Add(this.dgv_rmdata);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comB_RpType);
            this.Controls.Add(this.comB_Year);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comB_CC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comB_Facility);
            this.Controls.Add(this.label2);
            this.Name = "Frm_RMData";
            this.Text = "Frm_RMData";
            this.Load += new System.EventHandler(this.Frm_RMData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rmdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comB_CC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comB_Facility;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comB_RpType;
        private System.Windows.Forms.ComboBox comB_Year;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btn_Search;
		private System.Windows.Forms.DataGridView dgv_rmdata;
        private System.Windows.Forms.Button Excelout;
        private System.Windows.Forms.Button btn_SearchPeriod;
		private System.Windows.Forms.ComboBox comB_Month;
        private System.Windows.Forms.ComboBox comB_Product;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
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
    }
}