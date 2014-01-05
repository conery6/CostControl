using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace CostControl.Electric
{
    public partial class Frm_EChart : Form
    {
        public float[,] chartdata;
        private string[] chartInfo;

        public Frm_EChart(float [,] f,string [] chartInfo)
        {
            InitializeComponent();
            chartdata = f;
			this.chartInfo = chartInfo;
        }

        private void Frm_Chart_Load(object sender, EventArgs e)
        {
           
            string title = chartInfo[0];
			this.Text = title;
            MGChart.Titles.Add(title);
            Series series1 = MGChart.Series[0];
            Series series2 = MGChart.Series[1];
			series1.Name = chartInfo[1];
			series2.Name = chartInfo[2];
			

			// Add data points to the first series
			for (int i = 0; i < 12; i++)
			{
				series1.Points.Add(chartdata[0, i+1]);
				series2.Points.Add(chartdata[1, i + 1]);
				series1.Points[i].AxisLabel = "M" + (i + 1);
				series1.Points[i].ToolTip = chartdata[0, i + 1].ToString();
				series2.Points[i].ToolTip = chartdata[1, i + 1].ToString();
			}
        }
    }
}
