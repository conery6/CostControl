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
        int max;
        int min;

        public Frm_RMChart(float [,] f,int maxi,int mini)
        {
            InitializeComponent();
            chartdata = f;
            max = maxi;
            min = mini;
        }

        private void Frm_Chart_Load(object sender, EventArgs e)
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
            Series series3 = new Series();
            Series series4 = new Series();
            Series series5 = new Series();


            series1.Name = "Purchase Cost";
            series2.Name = "Purchase Price";
            series3.Name = "Purchase Quantity";
            series4.Name = "Sales Quantity";
            series5.Name = "availability";

            // Add data points to the first series
            for (int i = 1; i < 13; i++)
            {
                series1.Points.Add(chartdata[0, i]);
                series2.Points.Add(chartdata[1, i]);
                series3.Points.Add(chartdata[2, i]);
                series4.Points.Add(chartdata[3, i]);
                series5.Points.Add(chartdata[4, i]);
                //series1.Points[i].AxisLabel =i.ToString ()+  "月";
            }

            series1.ChartType = SeriesChartType.Line;
            series2.ChartType = SeriesChartType.Line;
            series3.ChartType = SeriesChartType.Column;
            series4.ChartType = SeriesChartType.Column;
            series5.ChartType = SeriesChartType.Column;


            series1.MarkerStyle = MarkerStyle.Circle;
            series1.MarkerSize = 5;
            series1.MarkerColor = Color.Magenta;
            //series1.MarkerBorderColor = Color.Red;
            series1.MarkerBorderWidth = 1;

            series2.MarkerStyle = MarkerStyle.Circle;
            series2.MarkerSize = 5;
            series2.MarkerColor = Color.Magenta;
            //series2.MarkerBorderColor = Color.Red;
            series2.MarkerBorderWidth = 1;

            Legend legend1 = new Legend();
            legend1.Name = "aaa";
            chart1.Legends.Add(legend1);

            series1.Legend = "aaa";
            series2.Legend = "aaa";
            series3.Legend = "aaa";
            series4.Legend = "aaa";
            series5.Legend = "aaa";

            

            // Add series to the chart
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);
            chart1.Series.Add(series3);
            chart1.Series.Add(series4);
            chart1.Series.Add(series5);

            // Set chart control location
            chart1.Location = new System.Drawing.Point(16, 16);

            // Set Chart control size
            chart1.Size = new System.Drawing.Size(800, 600);

            //chart1.ChartAreas["chartArea1"].AxisY.Minimum = 0;
            //chart1.ChartAreas["chartArea1"].AxisY.Maximum = 100;

            //chartArea1.AxisY.Minimum = min;
            //chartArea1.AxisY.Maximum = AutoSize;
            //chart1.Series["Series1"].Points[2].AxisLabel = "My Axis Label\nLabel Line #2";

            chartArea1.AxisX.Interval = 1;

            // Add chart control to the form
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.chart1 });


        }
    }
}
