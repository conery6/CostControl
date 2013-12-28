namespace CostControl.Management
{
    partial class Frm_MGActual
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_newactual = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_exceladd = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.comB_Year = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comB_CC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comB_Facility = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_MGData = new System.Windows.Forms.DataGridView();
            this.clm_IName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_M12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MGData)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(791, 521);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 52;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(679, 521);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 51;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Visible = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 50;
            this.button1.Text = "Excel导出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_newactual
            // 
            this.btn_newactual.Location = new System.Drawing.Point(786, 75);
            this.btn_newactual.Name = "btn_newactual";
            this.btn_newactual.Size = new System.Drawing.Size(75, 23);
            this.btn_newactual.TabIndex = 49;
            this.btn_newactual.Text = "增加新表";
            this.btn_newactual.UseVisualStyleBackColor = true;
            this.btn_newactual.Click += new System.EventHandler(this.btn_newactual_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(693, 75);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 48;
            this.btn_delete.Text = "删除数据";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(599, 75);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 47;
            this.btn_update.Text = "修改数据";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_exceladd
            // 
            this.btn_exceladd.Location = new System.Drawing.Point(413, 75);
            this.btn_exceladd.Name = "btn_exceladd";
            this.btn_exceladd.Size = new System.Drawing.Size(75, 23);
            this.btn_exceladd.TabIndex = 46;
            this.btn_exceladd.Text = "Excel导入";
            this.btn_exceladd.UseVisualStyleBackColor = true;
            this.btn_exceladd.Click += new System.EventHandler(this.btn_exceladd_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(741, 27);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 45;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // comB_Year
            // 
            this.comB_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Year.FormattingEnabled = true;
            this.comB_Year.Location = new System.Drawing.Point(616, 29);
            this.comB_Year.Name = "comB_Year";
            this.comB_Year.Size = new System.Drawing.Size(82, 20);
            this.comB_Year.TabIndex = 42;
            this.comB_Year.SelectedIndexChanged += new System.EventHandler(this.comB_Year_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(581, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "年份";
            // 
            // comB_CC
            // 
            this.comB_CC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_CC.FormattingEnabled = true;
            this.comB_CC.Location = new System.Drawing.Point(229, 30);
            this.comB_CC.Name = "comB_CC";
            this.comB_CC.Size = new System.Drawing.Size(328, 20);
            this.comB_CC.TabIndex = 40;
            this.comB_CC.SelectedIndexChanged += new System.EventHandler(this.comB_CC_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "成本中心";
            // 
            // comB_Facility
            // 
            this.comB_Facility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Facility.FormattingEnabled = true;
            this.comB_Facility.Location = new System.Drawing.Point(71, 30);
            this.comB_Facility.Name = "comB_Facility";
            this.comB_Facility.Size = new System.Drawing.Size(76, 20);
            this.comB_Facility.TabIndex = 38;
            this.comB_Facility.SelectedIndexChanged += new System.EventHandler(this.comB_Facility_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "工厂";
            // 
            // dgv_MGData
            // 
            this.dgv_MGData.AllowUserToAddRows = false;
            this.dgv_MGData.AllowUserToDeleteRows = false;
            this.dgv_MGData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MGData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_IName,
            this.clm_M1,
            this.clm_M2,
            this.clm_M3,
            this.clm_M4,
            this.clm_M5,
            this.clm_M6,
            this.clm_M7,
            this.clm_M8,
            this.clm_M9,
            this.clm_M10,
            this.clm_M11,
            this.clm_M12});
            this.dgv_MGData.Location = new System.Drawing.Point(21, 123);
            this.dgv_MGData.Name = "dgv_MGData";
            this.dgv_MGData.ReadOnly = true;
            this.dgv_MGData.RowTemplate.Height = 23;
            this.dgv_MGData.Size = new System.Drawing.Size(858, 382);
            this.dgv_MGData.TabIndex = 36;
            this.dgv_MGData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_MGData_CellEndEdit);
            // 
            // clm_IName
            // 
            this.clm_IName.DataPropertyName = "IName";
            this.clm_IName.HeaderText = "项目名称";
            this.clm_IName.Name = "clm_IName";
            this.clm_IName.ReadOnly = true;
            this.clm_IName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clm_M1
            // 
            this.clm_M1.DataPropertyName = "M1";
            this.clm_M1.HeaderText = "1月";
            this.clm_M1.Name = "clm_M1";
            this.clm_M1.ReadOnly = true;
            // 
            // clm_M2
            // 
            this.clm_M2.DataPropertyName = "M2";
            this.clm_M2.HeaderText = "2月";
            this.clm_M2.Name = "clm_M2";
            this.clm_M2.ReadOnly = true;
            // 
            // clm_M3
            // 
            this.clm_M3.DataPropertyName = "M3";
            this.clm_M3.HeaderText = "3月";
            this.clm_M3.Name = "clm_M3";
            this.clm_M3.ReadOnly = true;
            // 
            // clm_M4
            // 
            this.clm_M4.DataPropertyName = "M4";
            this.clm_M4.HeaderText = "4月";
            this.clm_M4.Name = "clm_M4";
            this.clm_M4.ReadOnly = true;
            // 
            // clm_M5
            // 
            this.clm_M5.DataPropertyName = "M5";
            this.clm_M5.HeaderText = "5月";
            this.clm_M5.Name = "clm_M5";
            this.clm_M5.ReadOnly = true;
            // 
            // clm_M6
            // 
            this.clm_M6.DataPropertyName = "M6";
            this.clm_M6.HeaderText = "6月";
            this.clm_M6.Name = "clm_M6";
            this.clm_M6.ReadOnly = true;
            // 
            // clm_M7
            // 
            this.clm_M7.DataPropertyName = "M7";
            this.clm_M7.HeaderText = "7月";
            this.clm_M7.Name = "clm_M7";
            this.clm_M7.ReadOnly = true;
            // 
            // clm_M8
            // 
            this.clm_M8.DataPropertyName = "M8";
            this.clm_M8.HeaderText = "8月";
            this.clm_M8.Name = "clm_M8";
            this.clm_M8.ReadOnly = true;
            // 
            // clm_M9
            // 
            this.clm_M9.DataPropertyName = "M9";
            this.clm_M9.HeaderText = "9月";
            this.clm_M9.Name = "clm_M9";
            this.clm_M9.ReadOnly = true;
            // 
            // clm_M10
            // 
            this.clm_M10.DataPropertyName = "M10";
            this.clm_M10.HeaderText = "10月";
            this.clm_M10.Name = "clm_M10";
            this.clm_M10.ReadOnly = true;
            // 
            // clm_M11
            // 
            this.clm_M11.DataPropertyName = "M11";
            this.clm_M11.HeaderText = "11月";
            this.clm_M11.Name = "clm_M11";
            this.clm_M11.ReadOnly = true;
            // 
            // clm_M12
            // 
            this.clm_M12.DataPropertyName = "M12";
            this.clm_M12.HeaderText = "12月";
            this.clm_M12.Name = "clm_M12";
            this.clm_M12.ReadOnly = true;
            // 
            // Frm_MGActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 555);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_newactual);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_exceladd);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.comB_Year);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comB_CC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comB_Facility);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_MGData);
            this.Name = "Frm_MGActual";
            this.Text = "Frm_MGActual";
            this.Load += new System.EventHandler(this.Frm_MGActual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MGData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_newactual;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_exceladd;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ComboBox comB_Year;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comB_CC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comB_Facility;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_MGData;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_IName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M8;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M9;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M10;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M11;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_M12;
    }
}