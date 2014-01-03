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
        List<string> Title;

        public Frm_EChart(List<string > title, float [,] f)
        {
            InitializeComponent();
            chartdata = f;
            Title = title;
        }

        private void Frm_Chart_Load(object sender, EventArgs e)
        {
           
            for (int i = 0; i < Title.Count; i++)
            {
                Series series = EChart.Series.Add(Title[i]);
                series.ChartType = SeriesChartType.Column;
                for (int j = 0; j < 12; j++)
                {
                    series.Points.Add(chartdata[i, j]);
                    series.Points[j].ToolTip = chartdata[i, j].ToString();
                }
                
            }

            //EChart.ChartAreas[0].AxisX.Minimum = 1;
            //EChart.ChartAreas[0].AxisX.Maximum = 13;

            //chartArea1.AxisY.Minimum = min;
            //chartArea1.AxisY.Maximum = AutoSize;
            //chart1.Series["Series1"].Points[2].AxisLabel = "My Axis Label\nLabel Line #2";
            EChart.ChartAreas[0].AxisX.Interval = 1;

            // Add chart control to the form


        }
    }
}
