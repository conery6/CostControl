namespace CostControl.Electric
{
    partial class Frm_EActual
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
            this.comB_CC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comB_Facility = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comB_Year = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_UpdateOk = new System.Windows.Forms.Button();
            this.dgv_Edata = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Itemnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btn_addOK = new System.Windows.Forms.Button();
            this.Excelout = new System.Windows.Forms.Button();
            this.Exceladd = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Edata)).BeginInit();
            this.SuspendLayout();
            // 
            // comB_CC
            // 
            this.comB_CC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_CC.FormattingEnabled = true;
            this.comB_CC.Location = new System.Drawing.Point(235, 39);
            this.comB_CC.Name = "comB_CC";
            this.comB_CC.Size = new System.Drawing.Size(171, 20);
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
            "CG_Hynix WX"});
            this.comB_Facility.Location = new System.Drawing.Point(79, 40);
            this.comB_Facility.Name = "comB_Facility";
            this.comB_Facility.Size = new System.Drawing.Size(76, 20);
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
            // comB_Year
            // 
            this.comB_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Year.FormattingEnabled = true;
            this.comB_Year.Location = new System.Drawing.Point(448, 39);
            this.comB_Year.Name = "comB_Year";
            this.comB_Year.Size = new System.Drawing.Size(82, 20);
            this.comB_Year.TabIndex = 14;
            this.comB_Year.SelectedIndexChanged += new System.EventHandler(this.comB_Year_SelectedIndexChanged);
            this.comB_Year.TextChanged += new System.EventHandler(this.comB_Year_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "年份";
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(729, 40);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 19;
            this.btn_delete.Text = "删除数据";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(648, 40);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 18;
            this.btn_update.Text = "修改数据";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(536, 37);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 17;
            this.btn_Search.Text = "查询";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(810, 40);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 35;
            this.btn_add.Text = "增加新预算";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(822, 573);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 37;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Visible = false;
            // 
            // btn_UpdateOk
            // 
            this.btn_UpdateOk.Location = new System.Drawing.Point(719, 573);
            this.btn_UpdateOk.Name = "btn_UpdateOk";
            this.btn_UpdateOk.Size = new System.Drawing.Size(75, 23);
            this.btn_UpdateOk.TabIndex = 36;
            this.btn_UpdateOk.Text = "保存";
            this.btn_UpdateOk.UseVisualStyleBackColor = true;
            this.btn_UpdateOk.Visible = false;
            // 
            // dgv_Edata
            // 
            this.dgv_Edata.AllowUserToAddRows = false;
            this.dgv_Edata.AllowUserToDeleteRows = false;
            this.dgv_Edata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Edata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Itemnum,
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
            this.dgv_Edata.Location = new System.Drawing.Point(46, 138);
            this.dgv_Edata.Name = "dgv_Edata";
            this.dgv_Edata.ReadOnly = true;
            this.dgv_Edata.RowTemplate.Height = 23;
            this.dgv_Edata.Size = new System.Drawing.Size(851, 387);
            this.dgv_Edata.TabIndex = 38;
            this.dgv_Edata.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Edata_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Item";
            this.Column1.HeaderText = "科目";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Itemnum
            // 
            this.Itemnum.DataPropertyName = "Itemnum";
            this.Itemnum.HeaderText = "Itemnum";
            this.Itemnum.Name = "Itemnum";
            this.Itemnum.ReadOnly = true;
            this.Itemnum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Itemnum.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "M1";
            this.Column2.HeaderText = "1";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "M2";
            this.Column3.HeaderText = "2";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "M3";
            this.Column4.HeaderText = "3";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "M4";
            this.Column5.HeaderText = "4";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "M5";
            this.Column6.HeaderText = "5";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "M6";
            this.Column7.HeaderText = "6";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "M7";
            this.Column8.HeaderText = "7";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "M8";
            this.Column9.HeaderText = "8";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "M9";
            this.Column10.HeaderText = "9";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "M10";
            this.Column11.HeaderText = "10";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "M11";
            this.Column12.HeaderText = "11";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "M12";
            this.Column13.HeaderText = "12";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btn_addOK
            // 
            this.btn_addOK.Location = new System.Drawing.Point(617, 573);
            this.btn_addOK.Name = "btn_addOK";
            this.btn_addOK.Size = new System.Drawing.Size(75, 23);
            this.btn_addOK.TabIndex = 39;
            this.btn_addOK.Text = "保存";
            this.btn_addOK.UseVisualStyleBackColor = true;
            this.btn_addOK.Visible = false;
            this.btn_addOK.Click += new System.EventHandler(this.btn_addOK_Click);
            // 
            // Excelout
            // 
            this.Excelout.Location = new System.Drawing.Point(810, 90);
            this.Excelout.Name = "Excelout";
            this.Excelout.Size = new System.Drawing.Size(75, 23);
            this.Excelout.TabIndex = 43;
            this.Excelout.Text = "Excel导出";
            this.Excelout.UseVisualStyleBackColor = true;
            this.Excelout.Click += new System.EventHandler(this.Excelout_Click);
            // 
            // Exceladd
            // 
            this.Exceladd.Location = new System.Drawing.Point(729, 90);
            this.Exceladd.Name = "Exceladd";
            this.Exceladd.Size = new System.Drawing.Size(75, 23);
            this.Exceladd.TabIndex = 42;
            this.Exceladd.Text = "Excel导入";
            this.Exceladd.UseVisualStyleBackColor = true;
            this.Exceladd.Click += new System.EventHandler(this.Exceladd_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Frm_EActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 608);
            this.Controls.Add(this.Excelout);
            this.Controls.Add(this.Exceladd);
            this.Controls.Add(this.btn_addOK);
            this.Controls.Add(this.dgv_Edata);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_UpdateOk);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.comB_Year);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comB_CC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comB_Facility);
            this.Controls.Add(this.label2);
            this.Name = "Frm_EActual";
            this.Text = "Frm_EActual";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Edata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comB_CC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comB_Facility;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comB_Year;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_UpdateOk;
        private System.Windows.Forms.DataGridView dgv_Edata;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Itemnum;
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
        private System.Windows.Forms.Button btn_addOK;
        private System.Windows.Forms.Button Excelout;
        private System.Windows.Forms.Button Exceladd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}