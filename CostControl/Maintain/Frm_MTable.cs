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
        public string CCNo = "*";
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

                dgv_rmdata1.Rows.Clear();
                barsum.Clear();
                DataTable sumdt = new DataTable();
                DataTable sumall = new DataTable();

                float[] spa = new float[12];
                float[] sub = new float[12];
                float[] all = new float[12];

                for (int i = 0; i < clb_FSystem.CheckedItems.Count; i++)
                {
                    FSNo = GetMaintainData.FSNo(clb_FSystem.CheckedItems[i].ToString());
                    switch (comB_RpType1.Text)
                    {
                        case "预算表 T1":
                            sumdt = GetMaintainData.Budget(FNo, FSNo, Year1, CCNo);
                            break;
                        case "预算表 RF1":
                            sumdt = GetMaintainData.MiddleBudget(FNo, FSNo, CCNo, Year1, 3);
                            break;
                        case "预算表 RF2":
                            sumdt = GetMaintainData.MiddleBudget(FNo, FSNo, CCNo, Year1, 6);
                            break;
                        case "预算表 E1":
                            sumdt = GetMaintainData.MiddleBudget(FNo, FSNo, CCNo, Year1, 9);
                            break;
                        case "预提表":
                            sumdt = GetMaintainData.Withhold(FNo, FSNo, Year1, CCNo);
                            break;
                        case "Actual表":
                            sumdt = GetMaintainData.Actual_FIN(FNo, FSNo, Year1, CCNo);
                            break;
                        case "实际值表":
                            sumdt = GetMaintainData.Actual_ACE(FNo, FSNo, Year1, CCNo);
                            break;
                    }

                    if (sumdt.Rows.Count == 0)
                    {
                        MessageBox.Show(clb_FSystem.CheckedItems[i].ToString()+"没有数据！", "提示");
                    }
                    else
                    {

                        sumall = GetMaintainData.sumall(sumdt, clb_FSystem.CheckedItems[i].ToString());
                        int r = dgv_rmdata1.Rows.Count;

                        for (int j = r ; j < sumall.Rows.Count+r ; j++)
                        {
                            dgv_rmdata1.Rows.Add();
                            dgv_rmdata1[0, j].Value = sumall.Rows[j%3]["EqName"].ToString();
                            dgv_rmdata1[1, j].Value = sumall.Rows[j%3]["Type"].ToString();
                            for (int k = 2; k < 14; k++)
                            {

                                dgv_rmdata1[k, j].Value = sumall.Rows[j%3]["M" + (k - 1).ToString()].ToString();
                                if (sumall.Rows[j % 3]["Type"].ToString() == "spa")
                                {
                                    spa[k - 2] += Convert.ToSingle (sumall.Rows[j % 3]["M" + (k - 1).ToString()]);
                                }
                                if (sumall.Rows[j % 3]["Type"].ToString() == "sub")
                                {
                                    sub[k - 2] += Convert.ToSingle(sumall.Rows[j % 3]["M" + (k - 1).ToString()]);
                                }
                                all[k - 2] = spa[k - 2] + sub[k - 2];
                                
                            }
                            
                        }
                        barsum.Add(Convert.ToSingle(sumall.Rows[2][14].ToString()));
                        
                    }
                    
                }
                dgv_rmdata1.Rows.Add("sum", "spa", spa[0], spa[1], spa[2], spa[3], spa[4], spa[5], spa[6], spa[7], spa[8], spa[9], spa[10], spa[11]);
                dgv_rmdata1.Rows.Add("sum", "sub", sub[0], sub[1], sub[2], sub[3], sub[4], sub[5], sub[6], sub[7], sub[8], sub[9], sub[10], sub[11]);
                dgv_rmdata1.Rows.Add("sum", "all", all[0], all[1], all[2], all[3], all[4], all[5], all[6], all[7], all[8], all[9], all[10], all[11]);
                for (int i = 1; i < 12; i++)
                {
                    spa[i] = spa[i] + spa[i - 1];
                    sub[i] = spa[i] + spa[i - 1];
                    all[i] = all[i] + all[i - 1];
                }
                dgv_rmdata1.Rows.Add("sum累加", "spa", spa[0], spa[1], spa[2], spa[3], spa[4], spa[5], spa[6], spa[7], spa[8], spa[9], spa[10], spa[11]);
                dgv_rmdata1.Rows.Add("sum累加", "sub", sub[0], sub[1], sub[2], sub[3], sub[4], sub[5], sub[6], sub[7], sub[8], sub[9], sub[10], sub[11]);
                dgv_rmdata1.Rows.Add("sum累加", "all", all[0], all[1], all[2], all[3], all[4], all[5], all[6], all[7], all[8], all[9], all[10], all[11]);



                F1spa=spa ;
                F1sub =sub ;
                F1all =all ;

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

                dgv_rmdata2.Rows.Clear();
                DataTable sumdt = new DataTable();
                DataTable sumall = new DataTable();

                float [] spa = new float [12];
                float [] sub = new float [12] ;
                float [] all = new float [12];

                for (int i = 0; i < clb_FSystem.CheckedItems.Count; i++)
                {
                    FSNo = GetMaintainData.FSNo(clb_FSystem.CheckedItems[i].ToString());
                    switch (comB_RpType2.Text)
                    {
                        case "预算表 T1":
                            sumdt = GetMaintainData.Budget(FNo, FSNo, Year2, CCNo);
                            break;
                        case "预算表 RF1":
                            sumdt = GetMaintainData.MiddleBudget(FNo, FSNo, CCNo, Year2, 3);
                            break;
                        case "预算表 RF2":
                            sumdt = GetMaintainData.MiddleBudget(FNo, FSNo, CCNo, Year2, 6);
                            break;
                        case "预算表 E1":
                            sumdt = GetMaintainData.MiddleBudget(FNo, FSNo, CCNo, Year2, 9);
                            break;
                        case "预提表":
                            sumdt = GetMaintainData.Withhold(FNo, FSNo, Year2, CCNo);
                            break;
                        case "Actual表":
                            sumdt = GetMaintainData.Actual_FIN(FNo, FSNo, Year2, CCNo);
                            break;
                        case "实际值表":
                            sumdt = GetMaintainData.Actual_ACE(FNo, FSNo, Year2, CCNo);
                            break;
                    }

                    if (sumdt.Rows.Count == 0)
                    {
                        MessageBox.Show(clb_FSystem.CheckedItems[i].ToString() + "没有数据！", "提示");
                    }
                    else
                    {

                        sumall = GetMaintainData.sumall(sumdt, clb_FSystem.CheckedItems[i].ToString());
                        int r = dgv_rmdata2.Rows.Count;

                        for (int j = r; j < sumall.Rows.Count + r; j++)
                        {
                            dgv_rmdata2.Rows.Add();
                            dgv_rmdata2[0, j].Value = sumall.Rows[j % 3]["EqName"].ToString();
                            dgv_rmdata2[1, j].Value = sumall.Rows[j % 3]["Type"].ToString();
                            for (int k = 2; k < 14; k++)
                            {

                                dgv_rmdata2[k, j].Value = sumall.Rows[j % 3]["M" + (k - 1).ToString()].ToString();
                                if (sumall.Rows[j % 3]["Type"].ToString() == "spa")
                                {
                                    spa[k - 2] += Convert.ToSingle (sumall.Rows[j % 3]["M" + (k - 1).ToString()]);
                                }
                                if (sumall.Rows[j % 3]["Type"].ToString() == "sub")
                                {
                                    sub[k - 2] += Convert.ToSingle(sumall.Rows[j % 3]["M" + (k - 1).ToString()]);
                                }
                                all[k - 2] = spa[k - 2] + sub[k - 2];
                            }
                        }
                    }
                }
                dgv_rmdata2.Rows.Add("sum", "spa", spa[0], spa[1], spa[2], spa[3], spa[4], spa[5], spa[6], spa[7], spa[8], spa[9], spa[10], spa[11]);
                dgv_rmdata2.Rows.Add("sum", "sub", sub[0], sub[1], sub[2], sub[3], sub[4], sub[5], sub[6], sub[7], sub[8], sub[9], sub[10], sub[11]);
                dgv_rmdata2.Rows.Add("sum", "all", all[0], all[1], all[2], all[3], all[4], all[5], all[6], all[7], all[8], all[9], all[10], all[11]);
                for (int i = 1; i < 12; i++)
                {
                    spa[i] = spa[i] + spa[i - 1];
                    sub[i] = spa[i] + spa[i - 1];
                    all[i] = all[i] + all[i - 1];
                }
                dgv_rmdata2.Rows.Add("sum累加", "spa", spa[0], spa[1], spa[2], spa[3], spa[4], spa[5], spa[6], spa[7], spa[8], spa[9], spa[10], spa[11]);
                dgv_rmdata2.Rows.Add("sum累加", "sub", sub[0], sub[1], sub[2], sub[3], sub[4], sub[5], sub[6], sub[7], sub[8], sub[9], sub[10], sub[11]);
                dgv_rmdata2.Rows.Add("sum累加", "all", all[0], all[1], all[2], all[3], all[4], all[5], all[6], all[7], all[8], all[9], all[10], all[11]);


                F2spa =spa ;
                F2sub =sub ;
                F2all =all ;

                //for (int i = 0; i < 12; i++)
                //{
                //    float sum = 0;
                //    for (int j = 0; j < dgv_rmdata2.Rows.Count; j++)
                //    {
                //        sum += FDT2[j, i];
                //    }
                //    sum2[i] = sum;
                //}
            }
        }

        private void btn_Chart_Click(object sender, EventArgs e)
        {
            string[] chartInfo = { comB_Facility.Text,"", Year1 + Reporttype1, Year2 + Reporttype2 };
            Frm_MChart m_Frm_MGChart = new Frm_MChart(F1all, F2all, chartInfo);
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
            clb_FSystem.Items.Clear();
            for (int i = 0; i < clb_CC.CheckedItems.Count; i++)
            {
                CCNo = GetMaintainData.CCNo(clb_CC.CheckedItems[i].ToString());

                string sql = " select distinct FSName from FacilitySystem, Equipment where FacilitySystem.FSNo =Equipment.FSNo and CCNo='" + CCNo + "'";
                DataTable temp = ODbcmd.SelectToDataTable(sql);
                for (int j = 0; j < temp.Rows.Count; j++)
                {
                    clb_FSystem.Items.Add(temp.Rows[j]["FSName"].ToString());
                }
            }
        }
    }
}
