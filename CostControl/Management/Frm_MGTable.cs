using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CostControl.Management
{
    public partial class Frm_MGTable : Form
    {
        public string ENo = "";
        public string FNo;
        public string CCNo;
        public string Year1;
        public string Year2;
        public string Reporttype1;
        public string Reporttype2;
        DataTable DT1;
        DataTable DT2;
        float[,] FDT1 = new float[10, 13];
        float[,] FDT2 = new float[10, 13];
        float[,] f1 = new float[10, 13];
        float[,] f2 = new float[10, 13];
        float[,] f3 = new float[10, 13];
        float[] sum1 = new float[12];
        float[] sum2 = new float[12];
        List<float> sumbar = new List<float>();
        List<string> sumbarname = new List<string>();
        string currentType = "";
        string currentType2 = "";
        public Frm_MGTable()
        {
            InitializeComponent();
        }

        private bool getPK1()//获取四个主键，做了个封装
        {
            if (comB_Year1.Text == "" || comB_Facility.Text == "" || comB_CC.Text == "" || comB_report1.Text == "")
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool getPK2()//获取四个主键，做了个封装
        {
            if (comB_Year2.Text == "" || comB_Facility.Text == "" || comB_CC.Text == "" || comB_report2.Text == "")
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btn_dataok1_Click(object sender, EventArgs e)
        {
            if (getPK1())
            {
                DataTable dt = new DataTable();
                for (int i = 0; i < dgv_mgdata1.Columns.Count; i++)
                {
                    dgv_mgdata1.Columns[i].ReadOnly = true;
                    dgv_mgdata1.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                if (getPK1())
                {

                    if (Reporttype1 == "Actual")
                    {
                        dt = GetMGData.Period(FNo, CCNo, Year1, "A12");
                    }
                    else
                    {
                        dt = GetMGData.Period(FNo, CCNo, Year1, Reporttype1);
                    }
                    dgv_mgdata1.DataSource = dt;
                }
                int acMonth = 0;
                switch (Reporttype1)
                {
                    case "T1": acMonth = 0; break;
                    case "RF1": acMonth = 3; break;
                    case "RF2": acMonth = 6; break;
                    case "E3": acMonth = 9; break;
                    case "Actual": acMonth = 12; break;
                }

                dgv_mgdata1.Columns[0].ReadOnly = true;
                dgv_mgdata1.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;

                for (int i = 1; i <= acMonth; i++)
                {
                    dgv_mgdata1.Columns[i].ReadOnly = true;
                    dgv_mgdata1.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
                DT1 = dt;
                FDT1 = GetMGData.DTto2DFloat(DT1);

                for (int i = 0; i < 12; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < dgv_mgdata1.Rows.Count; j++)
                    {
                        sum += FDT1[j, i];
                    }
                    sum1[i] = sum;
                }
                currentType = Reporttype1;
            }
        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetMGData.FNo(comB_Facility.Text);
            comB_CC.Items.Clear();
            string sql = "select CCName from CostCenter where  FNo ='" + FNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_CC.Items.Add(temp.Rows[i]["CCName"].ToString());
            }
        }

        private void btn_dataok2_Click(object sender, EventArgs e)
        {

            if (getPK2())
            {

                DataTable dt = new DataTable();
                for (int i = 0; i < dgv_mgdata2.Columns.Count; i++)
                {
                    dgv_mgdata2.Columns[i].ReadOnly = true;
                    dgv_mgdata2.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                if (getPK1())
                {

                    if (Reporttype2 == "Actual")
                    {
                        dt = GetMGData.Period(FNo, CCNo, Year2, "A12");
                    }
                    else
                    {
                        dt = GetMGData.Period(FNo, CCNo, Year2, Reporttype2);
                    }
                    dgv_mgdata2.DataSource = dt;
                }
                int acMonth = 0;
                switch (Reporttype2)
                {
                    case "T1": acMonth = 0; break;
                    case "RF1": acMonth = 3; break;
                    case "RF2": acMonth = 6; break;
                    case "E3": acMonth = 9; break;
                    case "Actual": acMonth = 12; break;
                }

                dgv_mgdata2.Columns[0].ReadOnly = true;
                dgv_mgdata2.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;

                for (int i = 1; i <= acMonth; i++)
                {
                    dgv_mgdata2.Columns[i].ReadOnly = true;
                    dgv_mgdata2.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }


                DT2 = dt;
                FDT2 = GetMGData.DTto2DFloat(DT2);

                for (int i = 0; i < 12; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < dgv_mgdata2.Rows.Count; j++)
                    {
                        sum += FDT2[j, i];
                    }
                    sum2[i] = sum;
                }
                currentType2 = Reporttype2;
            }
        }

        private void chkB_T1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Frm_MGTable_Load(object sender, EventArgs e)
        {
            string sql = "select distinct Fname from Facility";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Facility.Items.Add(temp.Rows[i]["FName"].ToString());
            }
        }

        private void comB_CC_SelectedIndexChanged(object sender, EventArgs e)
        {
            CCNo = GetMGData.CCNo(comB_CC.Text);
            comB_Year1.Items.Clear();
            comB_Year2.Items.Clear();
            string sql = " select distinct Year from MGPeriod where CCNo='" + CCNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Year1.Items.Add(temp.Rows[i]["Year"].ToString());
                comB_Year2.Items.Add(temp.Rows[i]["Year"].ToString());
            }

        }

        private void comB_report1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype1 = comB_report1.Text;
        }

        private void comB_report2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype2 = comB_report2.Text;
        }

        private void comB_Year1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year1 = comB_Year1.Text;
        }

        private void comB_Year2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year2 = comB_Year2.Text;
        }

        private void btn_createchart_Click(object sender, EventArgs e)
        {
            string[] chartInfo = { comB_Facility.Text, comB_CC.Text, Year1 + currentType, Year2 + currentType2 };
            Frm_MGChart m_Frm_MGChart = new Frm_MGChart(sum1, sum2, chartInfo);
            m_Frm_MGChart.Show();
        }

        private void btn_barchart_Click(object sender, EventArgs e)
        {
            Frm_MGBarChart m_Frm_MGBarChar = new Frm_MGBarChart(sumbar, sumbarname);
            m_Frm_MGBarChar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (getPK1() && getPK2())
            {
                ExcelHelper excel = new ExcelHelper();
                ExcelHelper.ChartInfo chartInfo = new ExcelHelper.ChartInfo();
                string[] infoHeader = { "工厂", "成本中心", "年份", "报表" };
                object[] content1 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), currentType };
                object[] content2 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year2.Text), currentType2 };
                chartInfo.infoHeader = infoHeader;
                chartInfo.baseInfo = content1;
                chartInfo.compareInfo = content2;
                chartInfo.chartTitle = comB_Facility.Text + "  " + comB_CC.Text + "总计比较";
                chartInfo.baseSeries = comB_Year1.Text + " " + currentType;
                chartInfo.compareSeries = comB_Year2.Text + " " + currentType2;
                DataTable dt1 = (DataTable)dgv_mgdata1.DataSource;
                DataTable dt2 = (DataTable)dgv_mgdata2.DataSource;
                excel.ExportExcelWithChart(dt1, dt2, chartInfo);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comB_Year1.Text == "" || comB_Facility.Text == "" || comB_CC.Text == "" || comb_Month1.Text == "")
            {
                MessageBox.Show("参数不全！");
            }
            else
            {
                for (int i = 0; i < dgv_mgdata1.Columns.Count; i++)
                {
                    dgv_mgdata1.Columns[i].ReadOnly = true;
                    dgv_mgdata1.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                comB_Year1.DropDownStyle = ComboBoxStyle.DropDownList;
                DataTable r = new DataTable();
                string reportMonth = comb_Month1.Text;
                switch (reportMonth)
                {
                    case "3":
                        r = GetMGData.Period(FNo, CCNo, Year1, "RF1");
                        break;
                    case "6":
                        r = GetMGData.Period(FNo, CCNo, Year1, "RF2");
                        break;
                    case "9":
                        r = GetMGData.Period(FNo, CCNo, Year1, "E3");
                        break;
                    default:
                        r = GetMGData.Period(FNo, CCNo, Year1, "A" + reportMonth);
                        break;
                }
                dgv_mgdata1.DataSource = r;
                int acMonth = int.Parse(reportMonth);

                dgv_mgdata1.Columns[0].ReadOnly = true;
                dgv_mgdata1.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;

                for (int i = 1; i <= acMonth; i++)
                {
                    dgv_mgdata1.Columns[i].ReadOnly = true;
                    dgv_mgdata1.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
                for (int i = 0; i < 12; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < dgv_mgdata1.Rows.Count; j++)
                    {
                        sum += FDT1[j, i];
                    }
                    sum1[i] = sum;
                }
                currentType = "A" + reportMonth;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comB_Year2.Text == "" || comB_Facility.Text == "" || comB_CC.Text == "" || comb_Month2.Text == "")
            {
                MessageBox.Show("参数不全！");
            }
            else
            {
                for (int i = 0; i < dgv_mgdata2.Columns.Count; i++)
                {
                    dgv_mgdata2.Columns[i].ReadOnly = true;
                    dgv_mgdata2.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                comB_Year1.DropDownStyle = ComboBoxStyle.DropDownList;
                DataTable r = new DataTable();
                string reportMonth = comb_Month2.Text;
                switch (reportMonth)
                {
                    case "3":
                        r = GetMGData.Period(FNo, CCNo, Year2, "RF1");
                        break;
                    case "6":
                        r = GetMGData.Period(FNo, CCNo, Year2, "RF2");
                        break;
                    case "9":
                        r = GetMGData.Period(FNo, CCNo, Year2, "E3");
                        break;
                    default:
                        r = GetMGData.Period(FNo, CCNo, Year2, "A" + reportMonth);
                        break;
                }
                dgv_mgdata2.DataSource = r;
                int acMonth = int.Parse(reportMonth);

                dgv_mgdata2.Columns[0].ReadOnly = true;
                dgv_mgdata2.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;

                for (int i = 1; i <= acMonth; i++)
                {
                    dgv_mgdata2.Columns[i].ReadOnly = true;
                    dgv_mgdata2.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
                for (int i = 0; i < 12; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < dgv_mgdata2.Rows.Count; j++)
                    {
                        sum += FDT2[j, i];
                    }
                    sum2[i] = sum;
                }
                currentType2 = "A" + reportMonth;
            }
        }
    }
}
