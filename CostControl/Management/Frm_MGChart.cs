using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CostControl.Management
{
    public partial class Frm_MGChart : Form
    {
        public float[] F1;
        public float[] F2;
        public string label11 = string.Empty;
        public string label22 = string.Empty;

        public Frm_MGChart(float []f1,float []f2, string l1,string l2)
        {
            InitializeComponent();
            F1 = f1;
            F2 = f2;
            label11 = l1;
            label22 = l2;
        }

        private void Frm_MChart_Load(object sender, EventArgs e)
        {
            // Create a Chart
            chart1 = new Chart();

            // Create Chart Area
            ChartArea chartArea1 = new ChartArea();

            // Add Chart Area to the Chart
            chart1.ChartAreas.Add(chartArea1);

            // Create a data series
            Series series1 = new Series();
            Series series2 = new Series();


            series1.Name = label11;
            series2.Name = label22;

            // Add data points to the first series
            for (int i = 0; i < 12; i++)
            {
                series1.Points.Add(F1 [i]);
                series2.Points.Add(F2 [i]);

            }

            series1.ChartType = SeriesChartType.Line;
            series2.ChartType = SeriesChartType.Column;


            Legend legend1 = new Legend();
            legend1.Name = "aaa";
            chart1.Legends.Add(legend1);

            series1.Legend = "aaa";
            series2.Legend = "aaa";



            // Add series to the chart
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);

            series1.Label = "#VALY{N0}";
            series2.Label = "#VALY{N0}";
            //series1.Label = "#VALY{N0}";
            //series2.Label = "#VALY{N0}";

            // Set chart control location
            chart1.Location = new System.Drawing.Point(16, 16);

            // Set Chart control size
            chart1.Size = new System.Drawing.Size(600, 400);

            //chart1.ChartAreas["chartArea1"].AxisY.Minimum = 0;
            //chart1.ChartAreas["chartArea1"].AxisY.Maximum = 100;

            //chartArea1.AxisY.Minimum = min;
            //chartArea1.AxisY.Maximum = max;
            //chart1.Series["Series1"].Points[2].AxisLabel = "My Axis Label\nLabel Line #2";

            chartArea1.AxisX.Interval = 1;
            //chartArea1.AxisY.Interval = 100;

            // Add chart control to the form
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.chart1 });

        }
    }
}
