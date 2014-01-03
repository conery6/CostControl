using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace CostControl.RawMaterial
{
    public partial class Frm_RMChart : Form
    {
        public float[,] chartdata;
		private string[] chartInfo;

        public Frm_RMChart(float [,] f,string [] chartInfo)
        {
            InitializeComponent();
            chartdata = f;
			this.chartInfo = chartInfo;
        }

        private void Frm_Chart_Load(object sender, EventArgs e)
        {

			string title = chartInfo[0];
			this.Text = title;
			RMChart.Titles.Add(title);
			Series series1 = RMChart.Series[0];
			Series series2 = RMChart.Series[1];
			Series series3 = RMChart.Series[2];
			Series series4 = RMChart.Series[3];
			Series series5 = RMChart.Series[4];
			series1.Name = chartInfo[1];
			series2.Name = chartInfo[2];
			series3.Name = chartInfo[3];
			series4.Name = chartInfo[4];
			series5.Name = chartInfo[5];
			

			// Add data points to the first series
			for (int i = 0; i < 12; i++)
			{
				series1.Points.Add(chartdata[0, i+1]);
				series2.Points.Add(chartdata[1, i + 1]);
				series3.Points.Add(chartdata[2, i + 1]);
				series4.Points.Add(chartdata[3, i + 1]);
				series5.Points.Add(chartdata[4, i + 1]);
				series1.Points[i].AxisLabel = "M" + (i + 1);
				series1.Points[i].ToolTip = chartdata[0, i + 1].ToString();
				series2.Points[i].ToolTip = chartdata[1, i + 1].ToString();
				series3.Points[i].ToolTip = chartdata[2, i + 1].ToString();
				series4.Points[i].ToolTip = chartdata[3, i + 1].ToString();
				series5.Points[i].ToolTip = chartdata[4, i + 1].ToString();

			}
        }
    }
}
