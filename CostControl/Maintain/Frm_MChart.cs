using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CostControl.Maintain
{
    public partial class Frm_MChart : Form
    {
        public float[] F1;
        public float[] F2;
        string[] chartInfo;

        public Frm_MChart(float[] f1, float[] f2, string[] chartInfo)
        {
            InitializeComponent();
            F1 = f1;
            F2 = f2;
            this.chartInfo = chartInfo;
        }

        private void Frm_MChart_Load(object sender, EventArgs e)
        {
            MGChart.Titles.Add(chartInfo[0] + "  " +  "成本对比");
            Series series1 = MGChart.Series[0];
            Series series2 = MGChart.Series[1];
            series1.Name = chartInfo[1];
            if (chartInfo[2] != chartInfo[1]) { series2.Name = chartInfo[2]; }

            // Add data points to the first series
            for (int i = 0; i < 12; i++)
            {

                series1.Points.Add(F1[i]);
                series2.Points.Add(F2[i]);
                series1.Points[i].AxisLabel = "M" + (i + 1);
                series2.Points[i].AxisLabel = "M" + (i + 1);
                series1.Points[i].ToolTip = F1[i].ToString();
                series2.Points[i].ToolTip = F1[i].ToString();

            }
        }
    }
}
