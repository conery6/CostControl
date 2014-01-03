using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CostControl.Maintain
{
    public partial class Frm_MTable : Form
    {
        public Frm_MTable()
        {
            InitializeComponent();
        }

        public string FNo = "";
        public string FSNo = "";
        public string CCNo = "";
        public string Year = "";
        public string Year1 = "";
        public string Year2 = "";
        public string Reporttype = "";
        public string Reporttype1 = "";
        public string Reporttype2 = "";
        public List<float> barsum = new List<float> ();

        public float[] F1spa;
        public float[] F2spa;
        public float[] F1sub;
        public float[] F2sub;
        public float[] F1all;
        public float[] F2all;

        float[,] FDT1 = new float[10, 13];
        float[,] FDT2 = new float[10, 13];
        float[] sum1 = new float[12];
        float[] sum2 = new float[12];

        DataTable DT1;
        DataTable DT2;

        private void MTable_Load(object sender, EventArgs e)
        {
            string sql = "select distinct Fname from Facility";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Facility.Items.Add(temp.Rows[i]["FName"].ToString());
            }

            sql = "select distinct Year from MaintianPeriod";
            temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Year1.Items.Add(temp.Rows[i]["Year"].ToString());
                comB_Year2.Items.Add(temp.Rows[i]["Year"].ToString());
            }
            
        }



        public bool getPK1()
        {
            if (FNo == "" || clb_FSystem .CheckedItems .Count ==0 || Year1 == "" || Reporttype1 == "")
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool getPK2()
        {
            if (FNo == "" || clb_FSystem.CheckedItems.Count == 0 || Year2 == "" || Reporttype2 == "")
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

                barsum.Clear();
                FSNo = "";
                DataTable sumdt = new DataTable();
                DataTable sumall = new DataTable();

                float[] spa = new float[12];
                float[] sub = new float[12];
                float[] all = new float[12];

                for (int i = 0; i < clb_FSystem.CheckedItems.Count; i++)
                {
                    FSNo += "'" + GetMaintainData.FSNo(clb_FSystem.CheckedItems[i].ToString()) + "',";
                }
                FSNo = FSNo.Remove(FSNo.Length - 1);
                if (comB_RpType1.Text == "Actual")
                {
                    sumdt = GetMaintainData.GetData2(FNo, FSNo, Year1, CCNo, "A12");
                }
                else
                {
                    sumdt = GetMaintainData.GetData2(FNo, FSNo, Year1, CCNo, comB_RpType1.Text);
                }

                if (sumdt.Rows.Count == 0)
                {
                    MessageBox.Show("数据为空");
                }
                else
                {
                    dgv_rmdata1.DataSource = sumdt;
                }

                DT1 = sumdt;
                FDT1 = GetMaintainData.DTto2DFloat(DT1);

                for (int i = 0; i < 12; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < dgv_rmdata1.Rows.Count; j++)
                    {
                        sum += FDT1[j, i];
                    }
                    sum1[i] = sum;
                }
            }
        }


        private void btn_barchart_Click(object sender, EventArgs e)
        {
            List<string> barname = new List<string>();
            for (int i = 0; i < clb_FSystem.CheckedItems.Count; i++)
            {
                barname.Add(clb_FSystem.CheckedItems[i].ToString ());
            }

            Frm_MBarChart m_Frm_MBarChart = new Frm_MBarChart(barsum, barname);
            m_Frm_MBarChart.Show();
        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetMaintainData.FNo(comB_Facility.Text);
            clb_CC.Items.Clear();
            string sql = "select CCName from CostCenter where  FNo ='" + FNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                clb_CC.Items.Add(temp.Rows[i]["CCName"].ToString());
            }
        }



        private void comB_Report_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void clb_CC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv_rmdata1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clb_FSystem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comB_Year1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year1 = comB_Year1.Text;
        }

        private void comB_Year2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year2 = comB_Year2.Text;
        }

        private void comB_RpType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype1 = comB_RpType1.Text;
        }

        private void comB_RpType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype2 = comB_RpType2.Text;
        }

        private void btn_dataok2_Click(object sender, EventArgs e)
        {
            if (getPK2())
            {
                FSNo = "";

                DataTable sumdt = new DataTable();
                DataTable sumall = new DataTable();

                float [] spa = new float [12];
                float [] sub = new float [12] ;
                float [] all = new float [12];

                for (int i = 0; i < clb_FSystem.CheckedItems.Count; i++)
                {
                    FSNo += "'" + GetMaintainData.FSNo(clb_FSystem.CheckedItems[i].ToString()) + "',";
                }
                FSNo = FSNo.Remove(FSNo.Length - 1);
                if (comB_RpType2.Text == "Actual")
                {
                    sumdt = GetMaintainData.GetData2(FNo, FSNo, Year2, CCNo, "A12");
                }
                else
                {
                    sumdt = GetMaintainData.GetData2(FNo, FSNo, Year2, CCNo, comB_RpType2.Text);
                }

                if (sumdt.Rows.Count == 0)
                {
                    MessageBox.Show("数据为空");
                }
                else
                {
                    dgv_rmdata2.DataSource = sumdt;
                }

                DT2 = sumdt;
                FDT2 = GetMaintainData.DTto2DFloat(DT2);

                for (int i = 0; i < 12; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < dgv_rmdata2.Rows.Count; j++)
                    {
                        sum += FDT2[j, i];
                    }
                    sum2[i] = sum;
                }
            }
        }

        private void btn_Chart_Click(object sender, EventArgs e)
        {
            string[] chartInfo = { comB_Facility.Text,"", Year1 + Reporttype1, Year2 + Reporttype2 };
            Frm_MChart m_Frm_MGChart = new Frm_MChart(sum1, sum2, chartInfo);
            m_Frm_MGChart.Show();

        }

        private void btn_addalll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clb_FSystem.Items.Count; i++)
            {
                clb_FSystem.SetItemChecked(i, true);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clb_FSystem.Items.Count; i++)
            {
                clb_FSystem.SetItemChecked(i, false);
            }
        }

        private void btn_spaChart_Click(object sender, EventArgs e)
        {
            string[] chartInfo = { comB_Facility.Text, "", Year1 + Reporttype1, Year2 + Reporttype2 };
            Frm_MChart m_Frm_MGChart = new Frm_MChart(sum1, sum2, chartInfo);
            m_Frm_MGChart.Show();
        }

        private void btn_subChart_Click(object sender, EventArgs e)
        {
            string[] chartInfo = { comB_Facility.Text, "", Year1 + Reporttype1, Year2 + Reporttype2 };
            Frm_MChart m_Frm_MGChart = new Frm_MChart(sum1, sum2, chartInfo);
            m_Frm_MGChart.Show();
        }

        private void clb_CC_Click(object sender, EventArgs e)
        {

        }

        private void clb_CC_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void clb_CC_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clb_FSystem.Items.Clear();
            CCNo = "";
            if (clb_CC.CheckedItems.Count > 0)
            {
                for (int i = 0; i < clb_CC.CheckedItems.Count; i++)
                {
                    CCNo += "'" + GetMaintainData.CCNo(clb_CC.CheckedItems[i].ToString()) + "',";
                }
                CCNo = CCNo.Remove(CCNo.Length - 1);
                string sql = " select distinct FSName from FacilitySystem, Equipment where FacilitySystem.FSNo =Equipment.FSNo and CCNo in(" + CCNo + ")";
                DataTable temp = ODbcmd.SelectToDataTable(sql);
                for (int j = 0; j < temp.Rows.Count; j++)
                {
                    clb_FSystem.Items.Add(temp.Rows[j]["FSName"].ToString());
                }
            }
        }
    }
}
