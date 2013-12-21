namespace CostControl.Maintain 
{
    partial class Frm_MActual
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
            this.label5 = new System.Windows.Forms.Label();
            this.comB_Facility = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comB_Year = new System.Windows.Forms.ComboBox();
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
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_newbudget = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.Btn_search = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comB_FSystem = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_AddOk = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_UpdateOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_exceladd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mdata)).BeginInit();
            this.SuspendLayout();
            // 
            // comB_CC
            // 
            this.comB_CC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_CC.FormattingEnabled = true;
            this.comB_CC.Location = new System.Drawing.Point(216, 53);
            this.comB_CC.Name = "comB_CC";
            this.comB_CC.Size = new System.Drawing.Size(77, 20);
            this.comB_CC.TabIndex = 32;
            this.comB_CC.SelectedIndexChanged += new System.EventHandler(this.comB_CC_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "成本中心";
            // 
            // comB_Facility
            // 
            this.comB_Facility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Facility.FormattingEnabled = true;
            this.comB_Facility.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.comB_Facility.Location = new System.Drawing.Point(70, 51);
            this.comB_Facility.Name = "comB_Facility";
            this.comB_Facility.Size = new System.Drawing.Size(77, 20);
            this.comB_Facility.TabIndex = 29;
            this.comB_Facility.SelectedIndexChanged += new System.EventHandler(this.comB_Facility_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "工厂";
            // 
            // comB_Year
            // 
            this.comB_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_Year.FormattingEnabled = true;
            this.comB_Year.Location = new System.Drawing.Point(480, 56);
            this.comB_Year.Name = "comB_Year";
            this.comB_Year.Size = new System.Drawing.Size(77, 20);
            this.comB_Year.TabIndex = 34;
            this.comB_Year.SelectedIndexChanged += new System.EventHandler(this.comB_Year_SelectedIndexChanged);
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
            this.Column13});
            this.dgv_Mdata.Location = new System.Drawing.Point(33, 163);
            this.dgv_Mdata.Name = "dgv_Mdata";
            this.dgv_Mdata.RowTemplate.Height = 23;
            this.dgv_Mdata.Size = new System.Drawing.Size(823, 322);
            this.dgv_Mdata.TabIndex = 35;
            this.dgv_Mdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Mdata_CellContentClick);
            this.dgv_Mdata.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Mdata_CellEndEdit);
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
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(638, 106);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 39;
            this.btn_delete.Text = "删除本表";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_newbudget
            // 
            this.btn_newbudget.Location = new System.Drawing.Point(719, 106);
            this.btn_newbudget.Name = "btn_newbudget";
            this.btn_newbudget.Size = new System.Drawing.Size(75, 23);
            this.btn_newbudget.TabIndex = 38;
            this.btn_newbudget.Text = "增加新表";
            this.btn_newbudget.UseVisualStyleBackColor = true;
            this.btn_newbudget.Click += new System.EventHandler(this.btn_newbudget_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(546, 106);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 37;
            this.btn_update.Text = "修改数据";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // Btn_search
            // 
            this.Btn_search.Location = new System.Drawing.Point(588, 53);
            this.Btn_search.Name = "Btn_search";
            this.Btn_search.Size = new System.Drawing.Size(75, 23);
            this.Btn_search.TabIndex = 36;
            this.Btn_search.Text = "查询";
            this.Btn_search.UseVisualStyleBackColor = true;
            this.Btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 42;
            this.label4.Text = "年份";
            // 
            // comB_FSystem
            // 
            this.comB_FSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comB_FSystem.FormattingEnabled = true;
            this.comB_FSystem.Location = new System.Drawing.Point(342, 56);
            this.comB_FSystem.Name = "comB_FSystem";
            this.comB_FSystem.Size = new System.Drawing.Size(78, 20);
            this.comB_FSystem.TabIndex = 41;
            this.comB_FSystem.SelectedIndexChanged += new System.EventHandler(this.comB_FSystem_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "系统";
            // 
            // btn_AddOk
            // 
            this.btn_AddOk.Location = new System.Drawing.Point(678, 506);
            this.btn_AddOk.Name = "btn_AddOk";
            this.btn_AddOk.Size = new System.Drawing.Size(75, 23);
            this.btn_AddOk.TabIndex = 46;
            this.btn_AddOk.Text = "保存";
            this.btn_AddOk.UseVisualStyleBackColor = true;
            this.btn_AddOk.Visible = false;
            this.btn_AddOk.Click += new System.EventHandler(this.btn_AddOk_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(781, 506);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 44;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_UpdateOk
            // 
            this.btn_UpdateOk.Location = new System.Drawing.Point(678, 506);
            this.btn_UpdateOk.Name = "btn_UpdateOk";
            this.btn_UpdateOk.Size = new System.Drawing.Size(75, 23);
            this.btn_UpdateOk.TabIndex = 43;
            this.btn_UpdateOk.Text = "保存";
            this.btn_UpdateOk.UseVisualStyleBackColor = true;
            this.btn_UpdateOk.Visible = false;
            this.btn_UpdateOk.Click += new System.EventHandler(this.btn_UpdateOk_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(800, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "初始化新表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_exceladd
            // 
            this.btn_exceladd.Location = new System.Drawing.Point(719, 54);
            this.btn_exceladd.Name = "btn_exceladd";
            this.btn_exceladd.Size = new System.Drawing.Size(75, 23);
            this.btn_exceladd.TabIndex = 48;
            this.btn_exceladd.Text = "Excel导入";
            this.btn_exceladd.UseVisualStyleBackColor = true;
            this.btn_exceladd.Click += new System.EventHandler(this.btn_exceladd_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(800, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 49;
            this.button2.Text = "Excel导出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Frm_MActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 541);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_exceladd);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_AddOk);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_UpdateOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comB_FSystem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_newbudget);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.Btn_search);
            this.Controls.Add(this.dgv_Mdata);
            this.Controls.Add(this.comB_Year);
            this.Controls.Add(this.comB_CC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comB_Facility);
            this.Controls.Add(this.label1);
            this.Name = "Frm_MActual";
            this.Text = "Frm_RMFIN";
            this.Load += new System.EventHandler(this.Frm_RMFIN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comB_CC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comB_Facility;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comB_Year;
        private System.Windows.Forms.DataGridView dgv_Mdata;
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
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_newbudget;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button Btn_search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comB_FSystem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_AddOk;
       // private System.Windows.Forms.Button btn_withholdOK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_UpdateOk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_exceladd;
        private System.Windows.Forms.Button button2;
    }
}