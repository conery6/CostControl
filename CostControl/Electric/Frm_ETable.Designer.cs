namespace CostControl.Electric
{
    partial class Frm_ETable
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
            this.comB_Month2 = new System.Windows.Forms.ComboBox();
            this.comB_Month1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_addalll = new System.Windows.Forms.Button();
            this.clb_CCItem = new System.Windows.Forms.CheckedListBox();
            this.dgv_edata1 = new System.Windows.Forms.DataGridView();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btn_dataok2 = new System.Windows.Forms.Button();
            this.btn_dataok1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comB_Facility = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comB_CC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_edata2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comB_Year2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comB_Year1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_edata1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_edata2)).BeginInit();
            this.SuspendLayout();
            // 
            // comB_Month2
            // 
            this.comB_Month2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Month2.FormattingEnabled = true;
            this.comB_Month2.Items.AddRange(new object[] {
            "A0",
            "A1",
            "A2",
            "A3",
            "A4",
            "A5",
            "A6",
            "A7",
            "A8",
            "A9",
            "A10",
            "A11",
            "A12"});
            this.comB_Month2.Location = new System.Drawing.Point(700, 114);
            this.comB_Month2.Name = "comB_Month2";
            this.comB_Month2.Size = new System.Drawing.Size(86, 20);
            this.comB_Month2.TabIndex = 108;
            this.comB_Month2.SelectedIndexChanged += new System.EventHandler(this.comB_RpType2_SelectedIndexChanged);
            // 
            // comB_Month1
            // 
            this.comB_Month1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Month1.FormattingEnabled = true;
            this.comB_Month1.Items.AddRange(new object[] {
            "A0",
            "A1",
            "A2",
            "A3",
            "A4",
            "A5",
            "A6",
            "A7",
            "A8",
            "A9",
            "A10",
            "A11",
            "A12"});
            this.comB_Month1.Location = new System.Drawing.Point(700, 73);
            this.comB_Month1.Name = "comB_Month1";
            this.comB_Month1.Size = new System.Drawing.Size(86, 20);
            this.comB_Month1.TabIndex = 107;
            this.comB_Month1.SelectedIndexChanged += new System.EventHandler(this.comB_RpType1_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(240, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 106;
            this.label11.Text = "成本中心";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(414, 111);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(49, 23);
            this.btn_clear.TabIndex = 105;
            this.btn_clear.Text = "清空";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_addalll
            // 
            this.btn_addalll.Location = new System.Drawing.Point(414, 76);
            this.btn_addalll.Name = "btn_addalll";
            this.btn_addalll.Size = new System.Drawing.Size(49, 23);
            this.btn_addalll.TabIndex = 104;
            this.btn_addalll.Text = "全选";
            this.btn_addalll.UseVisualStyleBackColor = true;
            this.btn_addalll.Click += new System.EventHandler(this.btn_addalll_Click);
            // 
            // clb_CCItem
            // 
            this.clb_CCItem.FormattingEnabled = true;
            this.clb_CCItem.Location = new System.Drawing.Point(90, 58);
            this.clb_CCItem.Name = "clb_CCItem";
            this.clb_CCItem.Size = new System.Drawing.Size(307, 84);
            this.clb_CCItem.TabIndex = 102;
            // 
            // dgv_edata1
            // 
            this.dgv_edata1.AllowUserToAddRows = false;
            this.dgv_edata1.AllowUserToDeleteRows = false;
            this.dgv_edata1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_edata1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column14,
            this.Type,
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
            this.dgv_edata1.Location = new System.Drawing.Point(23, 152);
            this.dgv_edata1.Name = "dgv_edata1";
            this.dgv_edata1.ReadOnly = true;
            this.dgv_edata1.RowTemplate.Height = 23;
            this.dgv_edata1.Size = new System.Drawing.Size(980, 182);
            this.dgv_edata1.TabIndex = 101;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "TypeName";
            this.Column14.HeaderText = "类型名称";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "类型";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "M1";
            this.Column2.HeaderText = "1";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "M2";
            this.Column3.HeaderText = "2";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "M3";
            this.Column4.HeaderText = "3";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "M4";
            this.Column5.HeaderText = "4";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "M5";
            this.Column6.HeaderText = "5";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "M6";
            this.Column7.HeaderText = "6";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "M7";
            this.Column8.HeaderText = "7";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "M8";
            this.Column9.HeaderText = "8";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "M9";
            this.Column10.HeaderText = "9";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "M10";
            this.Column11.HeaderText = "10";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "M11";
            this.Column12.HeaderText = "11";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "M12";
            this.Column13.HeaderText = "12";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // btn_dataok2
            // 
            this.btn_dataok2.Location = new System.Drawing.Point(833, 113);
            this.btn_dataok2.Name = "btn_dataok2";
            this.btn_dataok2.Size = new System.Drawing.Size(60, 23);
            this.btn_dataok2.TabIndex = 100;
            this.btn_dataok2.Text = "确定";
            this.btn_dataok2.UseVisualStyleBackColor = true;
            this.btn_dataok2.Click += new System.EventHandler(this.btn_dataok2_Click);
            // 
            // btn_dataok1
            // 
            this.btn_dataok1.Location = new System.Drawing.Point(833, 73);
            this.btn_dataok1.Name = "btn_dataok1";
            this.btn_dataok1.Size = new System.Drawing.Size(60, 23);
            this.btn_dataok1.TabIndex = 99;
            this.btn_dataok1.Text = "确定";
            this.btn_dataok1.UseVisualStyleBackColor = true;
            this.btn_dataok1.Click += new System.EventHandler(this.btn_dataok1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(665, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 98;
            this.label7.Text = "期次";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(665, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 95;
            this.label6.Text = "期次";
            // 
            // comB_Facility
            // 
            this.comB_Facility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Facility.FormattingEnabled = true;
            this.comB_Facility.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.comB_Facility.Items.AddRange(new object[] {
            "CG_Hynix WX",
            "CG_CHJ"});
            this.comB_Facility.Location = new System.Drawing.Point(90, 21);
            this.comB_Facility.Name = "comB_Facility";
            this.comB_Facility.Size = new System.Drawing.Size(128, 20);
            this.comB_Facility.TabIndex = 92;
            this.comB_Facility.SelectedIndexChanged += new System.EventHandler(this.comB_Facility_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 91;
            this.label3.Text = "项目";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 90;
            this.label4.Text = "工厂";
            // 
            // comB_CC
            // 
            this.comB_CC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_CC.FormattingEnabled = true;
            this.comB_CC.Location = new System.Drawing.Point(316, 21);
            this.comB_CC.Name = "comB_CC";
            this.comB_CC.Size = new System.Drawing.Size(332, 20);
            this.comB_CC.TabIndex = 112;
            this.comB_CC.SelectedIndexChanged += new System.EventHandler(this.comB_CC_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(482, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 88;
            this.label1.Text = "基准数据";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(482, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 89;
            this.label2.Text = "比较数据";
            // 
            // dgv_edata2
            // 
            this.dgv_edata2.AllowUserToAddRows = false;
            this.dgv_edata2.AllowUserToDeleteRows = false;
            this.dgv_edata2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_edata2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Column1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn28});
            this.dgv_edata2.Location = new System.Drawing.Point(23, 340);
            this.dgv_edata2.Name = "dgv_edata2";
            this.dgv_edata2.ReadOnly = true;
            this.dgv_edata2.RowTemplate.Height = 23;
            this.dgv_edata2.Size = new System.Drawing.Size(980, 182);
            this.dgv_edata2.TabIndex = 117;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TypeName";
            this.dataGridViewTextBoxColumn2.HeaderText = "类型名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Type";
            this.Column1.HeaderText = "类型";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "M1";
            this.dataGridViewTextBoxColumn3.HeaderText = "1";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "M2";
            this.dataGridViewTextBoxColumn4.HeaderText = "2";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "M3";
            this.dataGridViewTextBoxColumn5.HeaderText = "3";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "M4";
            this.dataGridViewTextBoxColumn6.HeaderText = "4";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "M5";
            this.dataGridViewTextBoxColumn7.HeaderText = "5";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "M6";
            this.dataGridViewTextBoxColumn8.HeaderText = "6";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "M7";
            this.dataGridViewTextBoxColumn9.HeaderText = "7";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "M8";
            this.dataGridViewTextBoxColumn10.HeaderText = "8";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "M9";
            this.dataGridViewTextBoxColumn11.HeaderText = "9";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "M10";
            this.dataGridViewTextBoxColumn12.HeaderText = "10";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "M11";
            this.dataGridViewTextBoxColumn13.HeaderText = "11";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "M12";
            this.dataGridViewTextBoxColumn28.HeaderText = "12";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // comB_Year2
            // 
            this.comB_Year2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Year2.FormattingEnabled = true;
            this.comB_Year2.Location = new System.Drawing.Point(581, 114);
            this.comB_Year2.Name = "comB_Year2";
            this.comB_Year2.Size = new System.Drawing.Size(77, 20);
            this.comB_Year2.TabIndex = 97;
            this.comB_Year2.SelectedIndexChanged += new System.EventHandler(this.comB_Year2_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(545, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 96;
            this.label8.Text = "年度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 93;
            this.label5.Text = "年度";
            // 
            // comB_Year1
            // 
            this.comB_Year1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Year1.FormattingEnabled = true;
            this.comB_Year1.Location = new System.Drawing.Point(581, 73);
            this.comB_Year1.Name = "comB_Year1";
            this.comB_Year1.Size = new System.Drawing.Size(77, 20);
            this.comB_Year1.TabIndex = 94;
            this.comB_Year1.SelectedIndexChanged += new System.EventHandler(this.comB_Year1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(700, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 38);
            this.button1.TabIndex = 118;
            this.button1.Text = "CHJ导出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(833, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 38);
            this.button2.TabIndex = 119;
            this.button2.Text = "海力士导出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Frm_ETable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 522);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_edata2);
            this.Controls.Add(this.comB_CC);
            this.Controls.Add(this.comB_Month2);
            this.Controls.Add(this.comB_Month1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_addalll);
            this.Controls.Add(this.clb_CCItem);
            this.Controls.Add(this.dgv_edata1);
            this.Controls.Add(this.btn_dataok2);
            this.Controls.Add(this.btn_dataok1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comB_Year2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comB_Year1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comB_Facility);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_ETable";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Frm_ETable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_edata1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_edata2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comB_Month2;
        private System.Windows.Forms.ComboBox comB_Month1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_addalll;
        private System.Windows.Forms.CheckedListBox clb_CCItem;
        private System.Windows.Forms.DataGridView dgv_edata1;
        private System.Windows.Forms.Button btn_dataok2;
        private System.Windows.Forms.Button btn_dataok1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comB_Facility;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comB_CC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_edata2;
        private System.Windows.Forms.ComboBox comB_Year2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comB_Year1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
    }
}