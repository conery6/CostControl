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


            // Create a Chart
            chart1 = new Chart();

            // Create Chart Area
            ChartArea chartArea1 = new ChartArea();

            // Add Chart Area to the Chart
            chart1.ChartAreas.Add(chartArea1);

            List<Series> listSer = new List<Series>();

            Legend legend1 = new Legend();
            legend1.Name = "aaa";
            chart1.Legends.Add(legend1);


            for (int i=0 ; i < Title .Count  ; i ++)
            {
                listSer.Add(new Series(Title[i]));
                for (int j = 0; j < 12; j++)
                {
                    listSer[i] .Points.Add(chartdata[i, j]);
                }
                listSer[i].Legend = "aaa";
                listSer[i].ChartType = SeriesChartType.Column;
                chart1.Series.Add(listSer[i]);
                
            }

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
