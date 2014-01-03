namespace CostControl.Management
{
    partial class Frm_MGBarChart
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.MGBarChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.MGBarChart)).BeginInit();
			this.SuspendLayout();
			// 
			// MGBarChart
			// 
			chartArea1.Area3DStyle.Enable3D = true;
			chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
			chartArea1.Name = "ChartArea1";
			this.MGBarChart.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.MGBarChart.Legends.Add(legend1);
			this.MGBarChart.Location = new System.Drawing.Point(0, 0);
			this.MGBarChart.Name = "MGBarChart";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.MGBarChart.Series.Add(series1);
			this.MGBarChart.Size = new System.Drawing.Size(700, 400);
			this.MGBarChart.TabIndex = 0;
			this.MGBarChart.Text = "chart1";
			// 
			// Frm_MGBarChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(704, 402);
			this.Controls.Add(this.MGBarChart);
			this.Name = "Frm_MGBarChart";
			this.Text = "MChart";
			this.Load += new System.EventHandler(this.Frm_MBarChart_Load);
			((System.ComponentModel.ISupportInitialize)(this.MGBarChart)).EndInit();
			this.ResumeLayout(false);

        }


        #endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart MGBarChart;
    }
}