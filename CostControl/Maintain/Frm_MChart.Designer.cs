﻿namespace CostControl.Maintain
{
    partial class Frm_MChart
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MGChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.MGChart)).BeginInit();
            this.SuspendLayout();
            // 
            // MGChart
            // 
            this.MGChart.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.Area3DStyle.PointGapDepth = 150;
            chartArea1.Area3DStyle.WallWidth = 10;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.Title = "月份";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            chartArea1.AxisY.Title = "总计";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.MGChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.MGChart.Legends.Add(legend1);
            this.MGChart.Location = new System.Drawing.Point(66, 11);
            this.MGChart.Name = "MGChart";
            this.MGChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.MarkerSize = 8;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.MarkerSize = 8;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Series2";
            series2.YValuesPerPoint = 4;
            this.MGChart.Series.Add(series1);
            this.MGChart.Series.Add(series2);
            this.MGChart.Size = new System.Drawing.Size(666, 389);
            this.MGChart.TabIndex = 1;
            this.MGChart.Text = "chart2";
            // 
            // Frm_MChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(799, 411);
            this.Controls.Add(this.MGChart);
            this.Name = "Frm_MChart";
            this.Text = "MChart";
            this.Load += new System.EventHandler(this.Frm_MChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MGChart)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;


        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart MGChart;

    }
}