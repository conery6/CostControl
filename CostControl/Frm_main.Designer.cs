namespace CostControl
{
    partial class Frm_main
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem_RM = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_RMBudget = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_RMActual = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_RMAnlys = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_MG = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_MNBudget = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_MNActual = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_MNAnlys = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_M = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_MBudget = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_MAcnt = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_MActual = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_MAnlys = new System.Windows.Forms.ToolStripMenuItem();
            this.电费管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_EBudget = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_EActual = new System.Windows.Forms.ToolStripMenuItem();
            this.电费分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Analy = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 426);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(637, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_RM,
            this.MenuItem_MG,
            this.MenuItem_M,
            this.电费管理ToolStripMenuItem,
            this.MenuItem_Analy});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(637, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItem_RM
            // 
            this.MenuItem_RM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_RMBudget,
            this.MenuItem_RMActual,
            this.MenuItem_RMAnlys});
            this.MenuItem_RM.Name = "MenuItem_RM";
            this.MenuItem_RM.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_RM.Text = "原料管理";
            // 
            // MenuItem_RMBudget
            // 
            this.MenuItem_RMBudget.Name = "MenuItem_RMBudget";
            this.MenuItem_RMBudget.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_RMBudget.Text = "预算表";
            this.MenuItem_RMBudget.Click += new System.EventHandler(this.MenuItem_RMData_Click);
            // 
            // MenuItem_RMActual
            // 
            this.MenuItem_RMActual.Name = "MenuItem_RMActual";
            this.MenuItem_RMActual.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_RMActual.Text = "实际表";
            this.MenuItem_RMActual.Click += new System.EventHandler(this.MenuItem_RMActual_Click);
            // 
            // MenuItem_RMAnlys
            // 
            this.MenuItem_RMAnlys.Name = "MenuItem_RMAnlys";
            this.MenuItem_RMAnlys.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_RMAnlys.Text = "原料分析";
            this.MenuItem_RMAnlys.Click += new System.EventHandler(this.MenuItem_RMAnlys_Click);
            // 
            // MenuItem_MG
            // 
            this.MenuItem_MG.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_MNBudget,
            this.MenuItem_MNActual,
            this.MenuItem_MNAnlys});
            this.MenuItem_MG.Name = "MenuItem_MG";
            this.MenuItem_MG.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_MG.Text = "管理控制";
            // 
            // MenuItem_MNBudget
            // 
            this.MenuItem_MNBudget.Name = "MenuItem_MNBudget";
            this.MenuItem_MNBudget.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_MNBudget.Text = "预算表";
            this.MenuItem_MNBudget.Click += new System.EventHandler(this.MenuItem_MNBudget_Click);
            // 
            // MenuItem_MNActual
            // 
            this.MenuItem_MNActual.Name = "MenuItem_MNActual";
            this.MenuItem_MNActual.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_MNActual.Text = "实际表";
            this.MenuItem_MNActual.Click += new System.EventHandler(this.MenuItem_MNActual_Click);
            // 
            // MenuItem_MNAnlys
            // 
            this.MenuItem_MNAnlys.Name = "MenuItem_MNAnlys";
            this.MenuItem_MNAnlys.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_MNAnlys.Text = "管理分析";
            this.MenuItem_MNAnlys.Click += new System.EventHandler(this.MenuItem_MNAnlys_Click);
            // 
            // MenuItem_M
            // 
            this.MenuItem_M.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_MBudget,
            this.MenuItem_MAcnt,
            this.MenuItem_MActual,
            this.MenuItem_MAnlys});
            this.MenuItem_M.Name = "MenuItem_M";
            this.MenuItem_M.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_M.Text = "维修控制";
            // 
            // MenuItem_MBudget
            // 
            this.MenuItem_MBudget.Name = "MenuItem_MBudget";
            this.MenuItem_MBudget.Size = new System.Drawing.Size(142, 22);
            this.MenuItem_MBudget.Text = "预算与预提";
            this.MenuItem_MBudget.Click += new System.EventHandler(this.MenuItem_MBudget_Click);
            // 
            // MenuItem_MAcnt
            // 
            this.MenuItem_MAcnt.Name = "MenuItem_MAcnt";
            this.MenuItem_MAcnt.Size = new System.Drawing.Size(142, 22);
            this.MenuItem_MAcnt.Text = "Actual(FIN)";
            this.MenuItem_MAcnt.Click += new System.EventHandler(this.MenuItem_MAcnt_Click);
            // 
            // MenuItem_MActual
            // 
            this.MenuItem_MActual.Name = "MenuItem_MActual";
            this.MenuItem_MActual.Size = new System.Drawing.Size(142, 22);
            this.MenuItem_MActual.Text = "Actual(ACE)";
            this.MenuItem_MActual.Click += new System.EventHandler(this.MenuItem_MActual_Click);
            // 
            // MenuItem_MAnlys
            // 
            this.MenuItem_MAnlys.Name = "MenuItem_MAnlys";
            this.MenuItem_MAnlys.Size = new System.Drawing.Size(142, 22);
            this.MenuItem_MAnlys.Text = "维修分析";
            this.MenuItem_MAnlys.Click += new System.EventHandler(this.MenuItem_MAnlys_Click);
            // 
            // 电费管理ToolStripMenuItem
            // 
            this.电费管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_EBudget,
            this.MenuItem_EActual,
            this.电费分析ToolStripMenuItem});
            this.电费管理ToolStripMenuItem.Name = "电费管理ToolStripMenuItem";
            this.电费管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.电费管理ToolStripMenuItem.Text = "电费管理";
            // 
            // MenuItem_EBudget
            // 
            this.MenuItem_EBudget.Name = "MenuItem_EBudget";
            this.MenuItem_EBudget.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_EBudget.Text = "预算表";
            this.MenuItem_EBudget.Click += new System.EventHandler(this.MenuItem_EBudget_Click);
            // 
            // MenuItem_EActual
            // 
            this.MenuItem_EActual.Name = "MenuItem_EActual";
            this.MenuItem_EActual.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_EActual.Text = "财务表";
            this.MenuItem_EActual.Click += new System.EventHandler(this.MenuItem_EActual_Click);
            // 
            // 电费分析ToolStripMenuItem
            // 
            this.电费分析ToolStripMenuItem.Name = "电费分析ToolStripMenuItem";
            this.电费分析ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.电费分析ToolStripMenuItem.Text = "电费分析";
            this.电费分析ToolStripMenuItem.Click += new System.EventHandler(this.电费分析ToolStripMenuItem_Click);
            // 
            // MenuItem_Analy
            // 
            this.MenuItem_Analy.Name = "MenuItem_Analy";
            this.MenuItem_Analy.Size = new System.Drawing.Size(68, 21);
            this.MenuItem_Analy.Text = "统计分析";
            this.MenuItem_Analy.Click += new System.EventHandler(this.MenuItem_Analy_Click);
            // 
            // Frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 448);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成本预算控制系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_main_FormClosed);
            this.Load += new System.EventHandler(this.Frm_main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_RM;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_RMBudget;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_RMActual;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_RMAnlys;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_MG;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_MNBudget;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_MNActual;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_MNAnlys;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_M;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_MBudget;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_MAcnt;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_MActual;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_MAnlys;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Analy;
        private System.Windows.Forms.ToolStripMenuItem 电费管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_EBudget;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_EActual;
        private System.Windows.Forms.ToolStripMenuItem 电费分析ToolStripMenuItem;
    }
}