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
    public partial class Frm_MGBarChart : Form
    {
        List<float> sumdt;
        List<string >sumname;

        public Frm_MGBarChart(List<float > f_sumdt,List<string > s_sumname)
        {
            InitializeComponent();
            sumdt = f_sumdt;
            sumname = s_sumname;
        }

        private void Frm_MBarChart_Load(object sender, EventArgs e)
        {
            // Create a Chart
            chart1 = new Chart();

            // Create Chart Area
            ChartArea chartArea1 = new ChartArea();

            // Add Chart Area to the Chart
            chart1.ChartAreas.Add(chartArea1);

            // Create a data series
            Series series1 = new Series();


            series1.Name = "sum";

            series1.Points.DataBindXY(sumname, sumdt);
            series1.ChartType = SeriesChartType.Pie;


            //series1.LabelFormat = "P3";
            //series1.IsValueShownAsLabel = true;
            series1["PieLabelStyle"] = "Outside";
            series1["PieLineColor"] = "Black";
            series1.Label = "#PERCENT"+ "#VALX";
            series1.IsValueShownAsLabel = true;
            // Add series to the chart
            chart1.Series.Add(series1);
            

            // Set chart control location
            chart1.Location = new System.Drawing.Point(16, 16);

            // Set Chart control size
            chart1.Size = new System.Drawing.Size(600, 400);

            //chart1.ChartAreas["chartArea1"].AxisY.Minimum = 0;
            //chart1.ChartAreas["chartArea1"].AxisY.Maximum = 100;

            //chart1.Series["Series1"].Points[2].AxisLabel = "My Axis Label\nLabel Line #2";


            // Add chart control to the form
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.chart1 });

        }
    }
}
