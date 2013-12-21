namespace CostControl.Management
{
    partial class Frm_MGTable
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
            this.btn_barchart = new System.Windows.Forms.Button();
            this.btn_dataok2 = new System.Windows.Forms.Button();
            this.btn_dataok1 = new System.Windows.Forms.Button();
            this.comB_report2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comB_Year2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comB_report1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comB_Year1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgv_mgdata1 = new System.Windows.Forms.DataGridView();
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
            this.btn_createchart = new System.Windows.Forms.Button();
            this.dgv_mgdata2 = new System.Windows.Forms.DataGridView();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mgdata1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mgdata2)).BeginInit();
            this.SuspendLayout();
            // 
            // comB_CC
            // 
            this.comB_CC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_CC.FormattingEnabled = true;
            this.comB_CC.Location = new System.Drawing.Point(225, 23);
            this.comB_CC.Name = "comB_CC";
            this.comB_CC.Size = new System.Drawing.Size(244, 20);
            this.comB_CC.TabIndex = 27;
            this.comB_CC.SelectedIndexChanged += new System.EventHandler(this.comB_CC_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "成本中心";
            // 
            // comB_Facility
            // 
            this.comB_Facility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Facility.FormattingEnabled = true;
            this.comB_Facility.Location = new System.Drawing.Point(69, 23);
            this.comB_Facility.Name = "comB_Facility";
            this.comB_Facility.Size = new System.Drawing.Size(76, 20);
            this.comB_Facility.TabIndex = 25;
            this.comB_Facility.SelectedIndexChanged += new System.EventHandler(this.comB_Facility_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "工厂";
            // 
            // btn_barchart
            // 
            this.btn_barchart.Location = new System.Drawing.Point(499, 26);
            this.btn_barchart.Name = "btn_barchart";
            this.btn_barchart.Size = new System.Drawing.Size(75, 23);
            this.btn_barchart.TabIndex = 30;
            this.btn_barchart.Text = "分布图";
            this.btn_barchart.UseVisualStyleBackColor = true;
            this.btn_barchart.Click += new System.EventHandler(this.btn_barchart_Click);
            // 
            // btn_dataok2
            // 
            this.btn_dataok2.Location = new System.Drawing.Point(394, 115);
            this.btn_dataok2.Name = "btn_dataok2";
            this.btn_dataok2.Size = new System.Drawing.Size(75, 23);
            this.btn_dataok2.TabIndex = 69;
            this.btn_dataok2.Text = "确定";
            this.btn_dataok2.UseVisualStyleBackColor = true;
            this.btn_dataok2.Click += new System.EventHandler(this.btn_dataok2_Click);
            // 
            // btn_dataok1
            // 
            this.btn_dataok1.Location = new System.Drawing.Point(394, 75);
            this.btn_dataok1.Name = "btn_dataok1";
            this.btn_dataok1.Size = new System.Drawing.Size(75, 23);
            this.btn_dataok1.TabIndex = 68;
            this.btn_dataok1.Text = "确定";
            this.btn_dataok1.UseVisualStyleBackColor = true;
            this.btn_dataok1.Click += new System.EventHandler(this.btn_dataok1_Click);
            // 
            // comB_report2
            // 
            this.comB_report2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_report2.FormattingEnabled = true;
            this.comB_report2.Items.AddRange(new object[] {
            "T1",
            "RF1",
            "RF2",
            "E3",
            "R"});
            this.comB_report2.Location = new System.Drawing.Point(287, 116);
            this.comB_report2.Name = "comB_report2";
            this.comB_report2.Size = new System.Drawing.Size(77, 20);
            this.comB_report2.TabIndex = 67;
            this.comB_report2.SelectedIndexChanged += new System.EventHandler(this.comB_report2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 66;
            this.label7.Text = "报表";
            // 
            // comB_Year2
            // 
            this.comB_Year2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Year2.FormattingEnabled = true;
            this.comB_Year2.Location = new System.Drawing.Point(142, 116);
            this.comB_Year2.Name = "comB_Year2";
            this.comB_Year2.Size = new System.Drawing.Size(77, 20);
            this.comB_Year2.TabIndex = 65;
            this.comB_Year2.SelectedIndexChanged += new System.EventHandler(this.comB_Year2_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(107, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 64;
            this.label8.Text = "年度";
            // 
            // comB_report1
            // 
            this.comB_report1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_report1.FormattingEnabled = true;
            this.comB_report1.Items.AddRange(new object[] {
            "T1",
            "RF1",
            "RF2",
            "E3",
            "R"});
            this.comB_report1.Location = new System.Drawing.Point(287, 75);
            this.comB_report1.Name = "comB_report1";
            this.comB_report1.Size = new System.Drawing.Size(77, 20);
            this.comB_report1.TabIndex = 63;
            this.comB_report1.SelectedIndexChanged += new System.EventHandler(this.comB_report1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "报表";
            // 
            // comB_Year1
            // 
            this.comB_Year1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Year1.FormattingEnabled = true;
            this.comB_Year1.Location = new System.Drawing.Point(143, 75);
            this.comB_Year1.Name = "comB_Year1";
            this.comB_Year1.Size = new System.Drawing.Size(77, 20);
            this.comB_Year1.TabIndex = 61;
            this.comB_Year1.SelectedIndexChanged += new System.EventHandler(this.comB_Year1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 60;
            this.label5.Text = "年度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 59;
            this.label4.Text = "比较数据";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 58;
            this.label9.Text = "基准数据";
            // 
            // dgv_mgdata1
            // 
            this.dgv_mgdata1.AllowUserToAddRows = false;
            this.dgv_mgdata1.AllowUserToDeleteRows = false;
            this.dgv_mgdata1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mgdata1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgv_mgdata1.Location = new System.Drawing.Point(26, 158);
            this.dgv_mgdata1.Name = "dgv_mgdata1";
            this.dgv_mgdata1.RowTemplate.Height = 23;
            this.dgv_mgdata1.Size = new System.Drawing.Size(744, 234);
            this.dgv_mgdata1.TabIndex = 70;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IName";
            this.Column1.HeaderText = "科目";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "M1";
            this.Column2.HeaderText = "1";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "M2";
            this.Column3.HeaderText = "2";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "M3";
            this.Column4.HeaderText = "3";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "M4";
            this.Column5.HeaderText = "4";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "M5";
            this.Column6.HeaderText = "5";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "M6";
            this.Column7.HeaderText = "6";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "M7";
            this.Column8.HeaderText = "7";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "M8";
            this.Column9.HeaderText = "8";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "M9";
            this.Column10.HeaderText = "9";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "M10";
            this.Column11.HeaderText = "10";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "M11";
            this.Column12.HeaderText = "11";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "M12";
            this.Column13.HeaderText = "12";
            this.Column13.Name = "Column13";
            // 
            // btn_createchart
            // 
            this.btn_createchart.Location = new System.Drawing.Point(499, 86);
            this.btn_createchart.Name = "btn_createchart";
            this.btn_createchart.Size = new System.Drawing.Size(70, 38);
            this.btn_createchart.TabIndex = 71;
            this.btn_createchart.Text = "生成图表";
            this.btn_createchart.UseVisualStyleBackColor = true;
            this.btn_createchart.Click += new System.EventHandler(this.btn_createchart_Click);
            // 
            // dgv_mgdata2
            // 
            this.dgv_mgdata2.AllowUserToAddRows = false;
            this.dgv_mgdata2.AllowUserToDeleteRows = false;
            this.dgv_mgdata2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mgdata2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26});
            this.dgv_mgdata2.Location = new System.Drawing.Point(26, 398);
            this.dgv_mgdata2.Name = "dgv_mgdata2";
            this.dgv_mgdata2.ReadOnly = true;
            this.dgv_mgdata2.RowTemplate.Height = 23;
            this.dgv_mgdata2.Size = new System.Drawing.Size(744, 206);
            this.dgv_mgdata2.TabIndex = 74;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "IName";
            this.Column14.HeaderText = "科目";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "M1";
            this.Column15.HeaderText = "1";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "M2";
            this.Column16.HeaderText = "2";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "M3";
            this.Column17.HeaderText = "3";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "M4";
            this.Column18.HeaderText = "4";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "M5";
            this.Column19.HeaderText = "5";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "M6";
            this.Column20.HeaderText = "6";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            // 
            // Column21
            // 
            this.Column21.DataPropertyName = "M7";
            this.Column21.HeaderText = "7";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            // 
            // Column22
            // 
            this.Column22.DataPropertyName = "M8";
            this.Column22.HeaderText = "8";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            // 
            // Column23
            // 
            this.Column23.DataPropertyName = "M9";
            this.Column23.HeaderText = "9";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            // 
            // Column24
            // 
            this.Column24.DataPropertyName = "M10";
            this.Column24.HeaderText = "10";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            // 
            // Column25
            // 
            this.Column25.DataPropertyName = "M11";
            this.Column25.HeaderText = "11";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            // 
            // Column26
            // 
            this.Column26.DataPropertyName = "M12";
            this.Column26.HeaderText = "12";
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            // 
            // Frm_MGTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 615);
            this.Controls.Add(this.dgv_mgdata2);
            this.Controls.Add(this.btn_createchart);
            this.Controls.Add(this.dgv_mgdata1);
            this.Controls.Add(this.btn_dataok2);
            this.Controls.Add(this.btn_dataok1);
            this.Controls.Add(this.comB_report2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comB_Year2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comB_report1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comB_Year1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_barchart);
            this.Controls.Add(this.comB_CC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comB_Facility);
            this.Controls.Add(this.label2);
            this.Name = "Frm_MGTable";
            this.Text = "MGTable";
            this.Load += new System.EventHandler(this.Frm_MGTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mgdata1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mgdata2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comB_CC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comB_Facility;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_barchart;
        private System.Windows.Forms.Button btn_dataok2;
        private System.Windows.Forms.Button btn_dataok1;
        private System.Windows.Forms.ComboBox comB_report2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comB_Year2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comB_report1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comB_Year1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgv_mgdata1;
        private System.Windows.Forms.Button btn_createchart;
        private System.Windows.Forms.DataGridView dgv_mgdata2;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
    }
}