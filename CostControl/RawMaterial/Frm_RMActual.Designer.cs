namespace CostControl.RawMaterial
{
    partial class Frm_RMActual
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
            this.btn_ExcelOut = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.comB_CC = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_newActual = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_Exceladd = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
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
            this.Btn_search = new System.Windows.Forms.Button();
            this.comB_Year = new System.Windows.Forms.ComboBox();
            this.comB_Product = new System.Windows.Forms.ComboBox();
            this.comB_Facility = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rmdata)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ExcelOut
            // 
            this.btn_ExcelOut.Location = new System.Drawing.Point(749, 17);
            this.btn_ExcelOut.Name = "btn_ExcelOut";
            this.btn_ExcelOut.Size = new System.Drawing.Size(92, 26);
            this.btn_ExcelOut.TabIndex = 48;
            this.btn_ExcelOut.Text = "导出Excel数据";
            this.btn_ExcelOut.UseVisualStyleBackColor = true;
            this.btn_ExcelOut.Click += new System.EventHandler(this.btn_ExcelOut_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(766, 439);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 47;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(685, 63);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 46;
            this.btn_delete.Text = "删除本表";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // comB_CC
            // 
            this.comB_CC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_CC.FormattingEnabled = true;
            this.comB_CC.Location = new System.Drawing.Point(201, 21);
            this.comB_CC.Name = "comB_CC";
            this.comB_CC.Size = new System.Drawing.Size(77, 20);
            this.comB_CC.TabIndex = 45;
            this.comB_CC.SelectedIndexChanged += new System.EventHandler(this.comB_CC_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 44;
            this.label5.Text = "成本中心";
            // 
            // btn_newActual
            // 
            this.btn_newActual.Location = new System.Drawing.Point(766, 63);
            this.btn_newActual.Name = "btn_newActual";
            this.btn_newActual.Size = new System.Drawing.Size(75, 23);
            this.btn_newActual.TabIndex = 43;
            this.btn_newActual.Text = "增加新表";
            this.btn_newActual.UseVisualStyleBackColor = true;
            this.btn_newActual.Click += new System.EventHandler(this.btn_newbudget_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(604, 63);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 42;
            this.btn_update.Text = "修改数据";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_Exceladd
            // 
            this.btn_Exceladd.Location = new System.Drawing.Point(645, 17);
            this.btn_Exceladd.Name = "btn_Exceladd";
            this.btn_Exceladd.Size = new System.Drawing.Size(94, 27);
            this.btn_Exceladd.TabIndex = 41;
            this.btn_Exceladd.Text = "导入Excel数据";
            this.btn_Exceladd.UseVisualStyleBackColor = true;
            this.btn_Exceladd.Click += new System.EventHandler(this.btn_Exceladd_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(654, 439);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 40;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
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
            this.dgv_rmdata.Location = new System.Drawing.Point(18, 104);
            this.dgv_rmdata.Name = "dgv_rmdata";
            this.dgv_rmdata.RowTemplate.Height = 23;
            this.dgv_rmdata.Size = new System.Drawing.Size(823, 322);
            this.dgv_rmdata.TabIndex = 39;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "科目";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "1";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "2";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "3";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "4";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "5";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "6";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "7";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "8";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "9";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "10";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "11";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "12";
            this.Column13.Name = "Column13";
            // 
            // Btn_search
            // 
            this.Btn_search.Location = new System.Drawing.Point(545, 20);
            this.Btn_search.Name = "Btn_search";
            this.Btn_search.Size = new System.Drawing.Size(75, 23);
            this.Btn_search.TabIndex = 38;
            this.Btn_search.Text = "查询";
            this.Btn_search.UseVisualStyleBackColor = true;
            this.Btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // comB_Year
            // 
            this.comB_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Year.FormattingEnabled = true;
            this.comB_Year.Location = new System.Drawing.Point(445, 21);
            this.comB_Year.Name = "comB_Year";
            this.comB_Year.Size = new System.Drawing.Size(77, 20);
            this.comB_Year.TabIndex = 36;
            this.comB_Year.SelectedIndexChanged += new System.EventHandler(this.comB_Year_SelectedIndexChanged);
            // 
            // comB_Product
            // 
            this.comB_Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Product.FormattingEnabled = true;
            this.comB_Product.Location = new System.Drawing.Point(330, 21);
            this.comB_Product.Name = "comB_Product";
            this.comB_Product.Size = new System.Drawing.Size(77, 20);
            this.comB_Product.TabIndex = 35;
            this.comB_Product.SelectedIndexChanged += new System.EventHandler(this.comB_Product_SelectedIndexChanged);
            // 
            // comB_Facility
            // 
            this.comB_Facility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Facility.FormattingEnabled = true;
            this.comB_Facility.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.comB_Facility.Location = new System.Drawing.Point(55, 19);
            this.comB_Facility.Name = "comB_Facility";
            this.comB_Facility.Size = new System.Drawing.Size(77, 20);
            this.comB_Facility.TabIndex = 34;
            this.comB_Facility.SelectedIndexChanged += new System.EventHandler(this.comB_Facility_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "年度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "产品";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "工厂";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Frm_RMActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 481);
            this.Controls.Add(this.btn_ExcelOut);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.comB_CC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_newActual);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_Exceladd);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.dgv_rmdata);
            this.Controls.Add(this.Btn_search);
            this.Controls.Add(this.comB_Year);
            this.Controls.Add(this.comB_Product);
            this.Controls.Add(this.comB_Facility);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_RMActual";
            this.Text = "Frm_RMActual";
            this.Load += new System.EventHandler(this.Frm_RMActual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rmdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ExcelOut;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.ComboBox comB_CC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_newActual;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_Exceladd;
        private System.Windows.Forms.Button btn_Save;
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
        private System.Windows.Forms.Button Btn_search;
        private System.Windows.Forms.ComboBox comB_Year;
        private System.Windows.Forms.ComboBox comB_Product;
        private System.Windows.Forms.ComboBox comB_Facility;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}