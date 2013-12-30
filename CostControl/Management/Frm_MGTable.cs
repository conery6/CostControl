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
        List <float> sumbar = new List <float>();
        List <string >sumbarname = new List <string >();

        public Frm_MGTable()
        {
            InitializeComponent();
        }

        private bool getPK1()//获取四个主键，做了个封装
        {
            if (FNo == "" || CCNo == "" ||  Year1 == "" || Reporttype1 == "")
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
            if (FNo == "" || CCNo == "" || Year2 == "" || Reporttype2 == "")
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
                dgv_mgdata1.Rows.Clear();
                DataTable r = new DataTable();
                switch (Reporttype1)
                {
                    case "T1":
                        r = GetMGData.Budget(FNo, CCNo, Year1);
                        break;
                    case "RF1":
                        r = GetMGData.MiddleBudget(FNo, CCNo, Year1, 3);
                        break;
                    case "RF2":
                        r = GetMGData.MiddleBudget(FNo, CCNo, Year1, 6);
                        break;
                    case "E3":
                        r = GetMGData.MiddleBudget(FNo, CCNo, Year1, 9);
                        break;
                    case "R":
                        r = GetMGData.Actual(FNo, CCNo, Year1);
                        break;
                }

                if (r.Rows.Count > 0)
                {

                    for (int i = 0; i < r.Rows.Count; i++)
                    {
                        dgv_mgdata1.Rows.Add();

                    }
                    dgv_mgdata1.DataSource = r;
                }
                else
                { MessageBox.Show("数据为空！"); }

                DT1 = r;
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
                //do while (dgv_mgdata1 .Rows .Count >0)
                //{

                //}


                DataTable r2 = new DataTable();

                switch (Reporttype2)
                {
                    case "T1":
                        r2 = GetMGData.Budget(FNo, CCNo, Year2);
                        break;
                    case "RF1":
                        r2 = GetMGData.MiddleBudget(FNo, CCNo, Year2, 3);
                        break;
                    case "RF2":
                        r2 = GetMGData.MiddleBudget(FNo, CCNo, Year2, 6);
                        break;
                    case "E3":
                        r2 = GetMGData.MiddleBudget(FNo, CCNo, Year2, 9);
                        break;
                    case "R":
                        r2 = GetMGData.Actual(FNo, CCNo, Year2);
                        break;
                }

                if (r2.Rows.Count > 0)
                {
                    dgv_mgdata2.DataSource = r2;
                }
                else
                { MessageBox.Show("数据为空！"); }

                DT2 = r2;
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
            string sql = " select distinct Year from MGBudget where CCNo='" + CCNo + "'";
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
            string[] chartInfo = {comB_Facility.Text,comB_CC.Text,Year1 + Reporttype1, Year2 + Reporttype2 };
            Frm_MGChart m_Frm_MGChart = new Frm_MGChart(sum1, sum2, chartInfo);
            m_Frm_MGChart.Show();
        }

        private void btn_barchart_Click(object sender, EventArgs e)
        {
            Frm_MGBarChart m_Frm_MGBarChar = new Frm_MGBarChart(sumbar, sumbarname);
            m_Frm_MGBarChar.Show();
        }
    }
}
