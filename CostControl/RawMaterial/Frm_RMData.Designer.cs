namespace CostControl.RawMaterial
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
			this.Btn_search = new System.Windows.Forms.Button();
			this.comB_RpType = new System.Windows.Forms.ComboBox();
			this.comB_Year = new System.Windows.Forms.ComboBox();
			this.comB_Product = new System.Windows.Forms.ComboBox();
			this.comB_Facility = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_Save = new System.Windows.Forms.Button();
			this.btn_Exceladd = new System.Windows.Forms.Button();
			this.btn_update = new System.Windows.Forms.Button();
			this.btn_newbudget = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.comB_CC = new System.Windows.Forms.ComboBox();
			this.btn_delete = new System.Windows.Forms.Button();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_ExcelOut = new System.Windows.Forms.Button();
			this.dgv_rmdata = new System.Windows.Forms.DataGridView();
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
			((System.ComponentModel.ISupportInitialize)(this.dgv_rmdata)).BeginInit();
			this.SuspendLayout();
			// 
			// Btn_search
			// 
			this.Btn_search.Location = new System.Drawing.Point(537, 84);
			this.Btn_search.Name = "Btn_search";
			this.Btn_search.Size = new System.Drawing.Size(75, 23);
			this.Btn_search.TabIndex = 18;
			this.Btn_search.Text = "查询";
			this.Btn_search.UseVisualStyleBackColor = true;
			this.Btn_search.Click += new System.EventHandler(this.Btn_Search_Click);
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
            "R"});
			this.comB_RpType.Location = new System.Drawing.Point(623, 43);
			this.comB_RpType.Name = "comB_RpType";
			this.comB_RpType.Size = new System.Drawing.Size(77, 20);
			this.comB_RpType.TabIndex = 17;
			this.comB_RpType.SelectedIndexChanged += new System.EventHandler(this.comB_report_SelectedIndexChanged);
			// 
			// comB_Year
			// 
			this.comB_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comB_Year.FormattingEnabled = true;
			this.comB_Year.Location = new System.Drawing.Point(485, 42);
			this.comB_Year.Name = "comB_Year";
			this.comB_Year.Size = new System.Drawing.Size(77, 20);
			this.comB_Year.TabIndex = 16;
			this.comB_Year.SelectedIndexChanged += new System.EventHandler(this.comB_Year_SelectedIndexChanged);
			// 
			// comB_Product
			// 
			this.comB_Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comB_Product.FormattingEnabled = true;
			this.comB_Product.Location = new System.Drawing.Point(370, 42);
			this.comB_Product.Name = "comB_Product";
			this.comB_Product.Size = new System.Drawing.Size(77, 20);
			this.comB_Product.TabIndex = 15;
			this.comB_Product.SelectedIndexChanged += new System.EventHandler(this.comB_Product_SelectedIndexChanged);
			// 
			// comB_Facility
			// 
			this.comB_Facility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comB_Facility.FormattingEnabled = true;
			this.comB_Facility.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.comB_Facility.Location = new System.Drawing.Point(95, 40);
			this.comB_Facility.Name = "comB_Facility";
			this.comB_Facility.Size = new System.Drawing.Size(77, 20);
			this.comB_Facility.TabIndex = 14;
			this.comB_Facility.SelectedIndexChanged += new System.EventHandler(this.comB_Facility_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(564, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 13;
			this.label4.Text = "报表类型";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(450, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 12;
			this.label3.Text = "年度";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(335, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 11;
			this.label2.Text = "产品";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(60, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 10;
			this.label1.Text = "工厂";
			// 
			// btn_Save
			// 
			this.btn_Save.Location = new System.Drawing.Point(694, 460);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(75, 23);
			this.btn_Save.TabIndex = 20;
			this.btn_Save.Text = "保存";
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// btn_Exceladd
			// 
			this.btn_Exceladd.Location = new System.Drawing.Point(706, 39);
			this.btn_Exceladd.Name = "btn_Exceladd";
			this.btn_Exceladd.Size = new System.Drawing.Size(94, 27);
			this.btn_Exceladd.TabIndex = 21;
			this.btn_Exceladd.Text = "导入Excel数据";
			this.btn_Exceladd.UseVisualStyleBackColor = true;
			this.btn_Exceladd.Click += new System.EventHandler(this.btn_Excel_Click);
			// 
			// btn_update
			// 
			this.btn_update.Location = new System.Drawing.Point(633, 84);
			this.btn_update.Name = "btn_update";
			this.btn_update.Size = new System.Drawing.Size(75, 23);
			this.btn_update.TabIndex = 22;
			this.btn_update.Text = "修改数据";
			this.btn_update.UseVisualStyleBackColor = true;
			this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
			// 
			// btn_newbudget
			// 
			this.btn_newbudget.Location = new System.Drawing.Point(806, 84);
			this.btn_newbudget.Name = "btn_newbudget";
			this.btn_newbudget.Size = new System.Drawing.Size(75, 23);
			this.btn_newbudget.TabIndex = 24;
			this.btn_newbudget.Text = "增加新预算";
			this.btn_newbudget.UseVisualStyleBackColor = true;
			this.btn_newbudget.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(182, 45);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 25;
			this.label5.Text = "成本中心";
			// 
			// comB_CC
			// 
			this.comB_CC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comB_CC.FormattingEnabled = true;
			this.comB_CC.Location = new System.Drawing.Point(241, 42);
			this.comB_CC.Name = "comB_CC";
			this.comB_CC.Size = new System.Drawing.Size(77, 20);
			this.comB_CC.TabIndex = 26;
			this.comB_CC.SelectedIndexChanged += new System.EventHandler(this.comB_CC_SelectedIndexChanged);
			// 
			// btn_delete
			// 
			this.btn_delete.Location = new System.Drawing.Point(725, 84);
			this.btn_delete.Name = "btn_delete";
			this.btn_delete.Size = new System.Drawing.Size(75, 23);
			this.btn_delete.TabIndex = 27;
			this.btn_delete.Text = "删除本表";
			this.btn_delete.UseVisualStyleBackColor = true;
			this.btn_delete.Click += new System.EventHandler(this.btn_del_Click);
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(806, 460);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 28;
			this.btn_Cancel.Text = "取消";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_ExcelOut
			// 
			this.btn_ExcelOut.Location = new System.Drawing.Point(806, 40);
			this.btn_ExcelOut.Name = "btn_ExcelOut";
			this.btn_ExcelOut.Size = new System.Drawing.Size(92, 26);
			this.btn_ExcelOut.TabIndex = 29;
			this.btn_ExcelOut.Text = "导出Excel数据";
			this.btn_ExcelOut.UseVisualStyleBackColor = true;
			this.btn_ExcelOut.Click += new System.EventHandler(this.btn_ExcelOut_Click);
			// 
			// dgv_rmdata
			// 
			this.dgv_rmdata.AllowUserToAddRows = false;
			this.dgv_rmdata.AllowUserToDeleteRows = false;
			this.dgv_rmdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_rmdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
			this.dgv_rmdata.Location = new System.Drawing.Point(58, 125);
			this.dgv_rmdata.Name = "dgv_rmdata";
			this.dgv_rmdata.RowTemplate.Height = 23;
			this.dgv_rmdata.Size = new System.Drawing.Size(823, 322);
			this.dgv_rmdata.TabIndex = 19;
			this.dgv_rmdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_rmdata_CellContentClick);
			this.dgv_rmdata.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_rmdata_CellEndEdit);
			this.dgv_rmdata.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_rmdata_KeyDown);
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "科目";
			this.Column1.HeaderText = "科目";
			this.Column1.Name = "Column1";
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "1月";
			this.Column2.HeaderText = "1月";
			this.Column2.Name = "Column2";
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "2月";
			this.Column3.HeaderText = "2月";
			this.Column3.Name = "Column3";
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "3月";
			this.Column4.HeaderText = "3月";
			this.Column4.Name = "Column4";
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "4月";
			this.Column5.HeaderText = "4月";
			this.Column5.Name = "Column5";
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "5月";
			this.Column6.HeaderText = "5月";
			this.Column6.Name = "Column6";
			// 
			// Column7
			// 
			this.Column7.DataPropertyName = "6月";
			this.Column7.HeaderText = "6月";
			this.Column7.Name = "Column7";
			// 
			// Column8
			// 
			this.Column8.DataPropertyName = "7月";
			this.Column8.HeaderText = "7月";
			this.Column8.Name = "Column8";
			// 
			// Column9
			// 
			this.Column9.DataPropertyName = "8月";
			this.Column9.HeaderText = "8月";
			this.Column9.Name = "Column9";
			// 
			// Column10
			// 
			this.Column10.DataPropertyName = "9月";
			this.Column10.HeaderText = "9月";
			this.Column10.Name = "Column10";
			// 
			// Column11
			// 
			this.Column11.DataPropertyName = "10月";
			this.Column11.HeaderText = "10月";
			this.Column11.Name = "Column11";
			// 
			// Column12
			// 
			this.Column12.DataPropertyName = "11月";
			this.Column12.HeaderText = "11月";
			this.Column12.Name = "Column12";
			// 
			// Column13
			// 
			this.Column13.DataPropertyName = "12月";
			this.Column13.HeaderText = "12月";
			this.Column13.Name = "Column13";
			// 
			// Frm_RMData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(927, 495);
			this.Controls.Add(this.btn_ExcelOut);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_delete);
			this.Controls.Add(this.comB_CC);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btn_newbudget);
			this.Controls.Add(this.btn_update);
			this.Controls.Add(this.btn_Exceladd);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.dgv_rmdata);
			this.Controls.Add(this.Btn_search);
			this.Controls.Add(this.comB_RpType);
			this.Controls.Add(this.comB_Year);
			this.Controls.Add(this.comB_Product);
			this.Controls.Add(this.comB_Facility);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Frm_RMData";
			this.Text = "RMData";
			this.Load += new System.EventHandler(this.RMData_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv_rmdata)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_search;
        private System.Windows.Forms.ComboBox comB_RpType;
        private System.Windows.Forms.ComboBox comB_Year;
        private System.Windows.Forms.ComboBox comB_Product;
        private System.Windows.Forms.ComboBox comB_Facility;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Exceladd;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_newbudget;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comB_CC;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_ExcelOut;
		private System.Windows.Forms.DataGridView dgv_rmdata;
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