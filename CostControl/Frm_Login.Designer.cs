namespace CostControl
{
    partial class Frm_Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_id = new System.Windows.Forms.Label();
            this.Lbl_key = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.txtB_id = new System.Windows.Forms.TextBox();
            this.txtB_key = new System.Windows.Forms.TextBox();
            this.Lbl_title = new System.Windows.Forms.Label();
            this.Btn_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lbl_id
            // 
            this.Lbl_id.AutoSize = true;
            this.Lbl_id.Location = new System.Drawing.Point(70, 102);
            this.Lbl_id.Name = "Lbl_id";
            this.Lbl_id.Size = new System.Drawing.Size(41, 12);
            this.Lbl_id.TabIndex = 0;
            this.Lbl_id.Text = "员工号";
            // 
            // Lbl_key
            // 
            this.Lbl_key.AutoSize = true;
            this.Lbl_key.Location = new System.Drawing.Point(70, 147);
            this.Lbl_key.Name = "Lbl_key";
            this.Lbl_key.Size = new System.Drawing.Size(29, 12);
            this.Lbl_key.TabIndex = 1;
            this.Lbl_key.Text = "密码";
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(72, 195);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // txtB_id
            // 
            this.txtB_id.Location = new System.Drawing.Point(158, 99);
            this.txtB_id.Name = "txtB_id";
            this.txtB_id.Size = new System.Drawing.Size(100, 21);
            this.txtB_id.TabIndex = 4;
            // 
            // txtB_key
            // 
            this.txtB_key.Location = new System.Drawing.Point(158, 144);
            this.txtB_key.Name = "txtB_key";
            this.txtB_key.PasswordChar = '*';
            this.txtB_key.Size = new System.Drawing.Size(100, 21);
            this.txtB_key.TabIndex = 5;
            // 
            // Lbl_title
            // 
            this.Lbl_title.AutoSize = true;
            this.Lbl_title.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_title.Location = new System.Drawing.Point(42, 41);
            this.Lbl_title.Name = "Lbl_title";
            this.Lbl_title.Size = new System.Drawing.Size(253, 29);
            this.Lbl_title.TabIndex = 6;
            this.Lbl_title.Text = "成本预算控制系统";
            // 
            // Btn_clear
            // 
            this.Btn_clear.Location = new System.Drawing.Point(183, 195);
            this.Btn_clear.Name = "Btn_clear";
            this.Btn_clear.Size = new System.Drawing.Size(75, 23);
            this.Btn_clear.TabIndex = 3;
            this.Btn_clear.Text = "重置";
            this.Btn_clear.UseVisualStyleBackColor = true;
            this.Btn_clear.Click += new System.EventHandler(this.Btn_clear_Click);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 264);
            this.Controls.Add(this.Lbl_title);
            this.Controls.Add(this.txtB_key);
            this.Controls.Add(this.txtB_id);
            this.Controls.Add(this.Btn_clear);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.Lbl_key);
            this.Controls.Add(this.Lbl_id);
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_id;
        private System.Windows.Forms.Label Lbl_key;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox txtB_id;
        private System.Windows.Forms.TextBox txtB_key;
        private System.Windows.Forms.Label Lbl_title;
        private System.Windows.Forms.Button Btn_clear;
    }
}

