using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CostControl.Electric;
using CostControl.Maintain;
using CostControl.Management;
using CostControl.RawMaterial;

namespace CostControl.Analysis
{
    public partial class Frm_ANATable : Form
    {
        public string ENo;
        public string FNo;
        public string PNo;
        public string Year1;
        public string Year2;
        public string Reporttype1;
        public string Reporttype2;
        public string CCNo;
        DataTable DT1;
        DataTable DT2;
        float[,] FDT1 = new float[5, 13];
        float[,] FDT2 = new float[5, 13];
        float[,] f1 = new float[5, 13];
        float[,] f2 = new float[5, 13];
        float[,] f3 = new float[5, 13];

        public Frm_ANATable(string ENo1)
        {
            InitializeComponent();
            ENo = ENo1;
        }

        private void RMTable_Load(object sender, EventArgs e)
        {
            string sql = "select distinct Fname from Facility";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Facility.Items.Add(temp.Rows[i]["FName"].ToString());
            }

            comB_report1.Text = "T1";
            comB_report2.Text = "T1";


        }

        private bool getPK1()//获取四个主键，做了个封装
        {
            if (FNo == "" || CCNo == "" || Year1 == "" || Reporttype1 == "")
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
            if (FNo == "" || CCNo == ""|| Year2 == "" || Reporttype2 == "")
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
            string data = null;
            if (getPK1())
            {
                DataSet r = new DataSet();
                switch (Reporttype1)
                {
                    case "T1":
                        r = GetANAData.Budget(CCNo, PNo, Year1);
                        break;
                    case "RF1":
                        r = GetANAData.MiddleBudget(CCNo, PNo, Year1, 3);
                        break;
                    case "RF2":
                        r = GetANAData.MiddleBudget(CCNo, PNo, Year1, 6);
                        break;
                    case "E3":
                        r = GetANAData.MiddleBudget(CCNo, PNo, Year1, 9);
                        break;
                    case "R":
                        r = GetANAData.Actual(CCNo, PNo, Year1);
                        break;
                }
                
                if (r.Tables.Count > 0)
                {
                    for (int y = 0; y < r.Tables.Count; y++)
                    {
                        if (r.Tables[y].Rows.Count > 0)
                        {
                            dgv_rmdata1.Rows.Add(r.Tables[y].Rows.Count);
                            for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                            {
                                float sum = 0f;
                                for (int k = 0; k < 14; k++)
                                {
                                    dgv_rmdata1[k, i].Value = r.Tables[y].Rows[i][k];
                                    if(k > 1)
                                    {
                                        data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                        sum += float.Parse(data);
                                    }
                                }
                                dgv_rmdata1[14, i].Value = sum;
                            }
                        }
                        else
                        { MessageBox.Show("数据为空！"); }
                    }
                }

                //DT1 = r;
                //FDT1 = GetANAData.DTto2DFloat(DT1);
            }
        }

        private void btn_dataok2_Click(object sender, EventArgs e)
        {
            string data = null;
            if (getPK2())
            {
                DataSet r = new DataSet();

                switch (Reporttype2)
                {
                    case "T1":
                        r = GetANAData.Budget(CCNo, PNo, Year2);
                        break;
                    case "RF1":
                        r = GetANAData.MiddleBudget(CCNo, PNo, Year2, 3);
                        break;
                    case "RF2":
                        r = GetANAData.MiddleBudget(CCNo, PNo, Year2, 6);
                        break;
                    case "E3":
                        r = GetANAData.MiddleBudget(CCNo, PNo, Year2, 9);
                        break;
                    case "R":
                        r = GetANAData.Actual(CCNo, PNo, Year2);
                        break;
                }

                if (r.Tables.Count > 0)
                {
                    for (int y = 0; y < r.Tables.Count; y++)
                    {
                        if (r.Tables[y].Rows.Count > 0)
                        {
                            dgv_rmdata2.Rows.Add(r.Tables[y].Rows.Count);
                            for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                            {
                                float sum = 0f;
                                for (int k = 0; k < 14; k++)
                                {
                                    dgv_rmdata2[k, i].Value = r.Tables[y].Rows[i][k];
                                    if (k > 1)
                                    {
                                        data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                        sum += float.Parse(data);
                                    }
                                }
                                dgv_rmdata2[14, i].Value = sum;
                            }
                        }
                        else
                        { MessageBox.Show("数据为空！"); }
                    }
                }
                //DT2 = r;
                // FDT2 = GetANAData.DTto2DFloat(DT2);
            }
        }

        private void chkB_T1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB_T1.Checked == true)
            {
                //float[,] f = GetANAData.FReportTable1(FDT1, FDT2);
                //f1 = f;
                //dgv_rmdata3.Rows[0].Visible = true;
                //for (int j = 1; j < 6; j++)
                //{
                //    dgv_rmdata3.Rows[j].Visible = true;
                //    for (int i = 1; i < 13; i++)
                //    {
                //        dgv_rmdata3[i, j].Value = f[j - 1, i];
                //    }

                //}
                DataTable dt = new DataTable();
                dt.Columns.Add("product");
                dt.Columns.Add("catagory");
                dt.Columns.Add("sub");
                dt.Columns.Add("percent");
                for(int i=0; i<dgv_rmdata1.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = dgv_rmdata1[0, i].Value;
                    dr[1] = dgv_rmdata1[1, i].Value;
                    dr[2] = float.Parse(dgv_rmdata2[14, i].Value.ToString()) - float.Parse(dgv_rmdata1[14, i].Value.ToString());
                    dr[3] = (float.Parse(dgv_rmdata2[14, i].Value.ToString()) - float.Parse(dgv_rmdata1[14, i].Value.ToString())) / float.Parse(dgv_rmdata2[14, i].Value.ToString());
                    dt.Rows.Add(dr);
                }
                //bind datasource
                dgv_rmdata3.DataSource = dt;
            }
            else
            {
                for (int j = 0; j < 6; j++)
                {
                    dgv_rmdata3.Rows[j].Visible = false;
                }
            }
        }

        private void chkB_T2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB_T2.Checked == true)
            {
                //DataTable r = GetANAData.ReportTable2(DT1,DT2);
                float[,] f = GetANAData.FReportTable2(FDT1, FDT2);
                f2 = f;
                dgv_rmdata3.Rows[6].Visible = true;

                //for (int j = 7; j < 12; j++)
                //{
                //    dgv_rmdata2.Rows[j].Visible = true;
                //    for (int i = 1; i < 13; i++)
                //    {
                //        dgv_rmdata2[i, j].Value = r.Rows[j-7][i];
                //    }
                //}

                for (int j = 7; j < 12; j++)
                {
                    dgv_rmdata3.Rows[j].Visible = true;
                    for (int i = 1; i < 13; i++)
                    {
                        dgv_rmdata3[i, j].Value = f[j - 7, i];
                    }
                }
            }
            else
            {
                for (int j = 6; j < 12; j++)
                {
                    dgv_rmdata3.Rows[j].Visible = false;
                }
            }
        }



        private void btn_TP1_Click(object sender, EventArgs e)
        {
            Frm_ANAChart M_Chart = new Frm_ANAChart(f1, 1, -1);
            M_Chart.Show();
        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetANAData.FNo(comB_Facility.Text);
            comB_CC.Items.Clear();
            CCNo = "";
            string sql = "select CCName from CostCenter where  FNo ='" + FNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_CC.Items.Add(temp.Rows[i]["CCName"].ToString());
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



        private void btn_data1_Click(object sender, EventArgs e)
        {
            Frm_ANAChart M_Chart = new Frm_ANAChart(FDT1, 100, 0);
            M_Chart.Show();
        }

        private void btn_data2_Click(object sender, EventArgs e)
        {
            Frm_ANAChart M_Chart = new Frm_ANAChart(FDT2, 100, 0);
            M_Chart.Show();
        }

        private void btn_tp2_Click(object sender, EventArgs e)
        {
            Frm_ANAChart M_Chart = new Frm_ANAChart(f2, 1, -1);
            M_Chart.Show();
        }

        private void btn_tp3_Click(object sender, EventArgs e)
        {
            Frm_ANAChart M_Chart = new Frm_ANAChart(f3, 1, -1);
            M_Chart.Show();
        }

        private void comB_CC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //原料管理
            CCNo = GetRMData.CCNo(comB_CC.Text);
            clb_Product.Items.Clear();
            PNo = "";
            string sqlrma = " select distinct PName from RMBudget, Product,CostCenter where CostCenter.CCNo =RMBudget.CCNo and Product.PNo =RMBudget.PNo and CCName='" + comB_CC.Text + "' ";
            DataTable temprma = ODbcmd.SelectToDataTable(sqlrma);
            for (int i = 0; i < temprma.Rows.Count; i++)
            {
                clb_Product.Items.Add(temprma.Rows[i]["PName"].ToString());
            }

            //管理控制
            CCNo = GetMGData.CCNo(comB_CC.Text);
            clb_Manage.Items.Clear();
            string sqlm = " select distinct IName from MGBudget where CCNo='" + CCNo + "'";
            DataTable tempm = ODbcmd.SelectToDataTable(sqlm);
            for (int i = 0; i < tempm.Rows.Count; i++)
            {
                clb_Manage.Items.Add(tempm.Rows[i]["IName"].ToString());
            }

            //电费控制
            CCNo = GetElectricData.CCNo(comB_CC.Text);
            clb_Electric.Items.Clear();
            string sqle = "select distinct Item,year from EBudget where CCNo ='" + CCNo + "'";
            DataTable tempe = ODbcmd.SelectToDataTable(sqle);
            for (int i = 0; i < tempe.Rows.Count; i++)
            {
                clb_Electric.Items.Add(tempe.Rows[i]["Item"].ToString());
            }

            //维修管理
            clb_Maintain.Items.Clear();

            CCNo = GetMaintainData.CCNo(comB_CC.Text);

            string sql = " select distinct FSName from FacilitySystem, Equipment where FacilitySystem.FSNo =Equipment.FSNo and CCNo='" + CCNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int j = 0; j < temp.Rows.Count; j++)
            {
                clb_Maintain.Items.Add(temp.Rows[j]["FSName"].ToString());
            }

            //load year
            comB_Year1.Items.Clear();
            comB_Year2.Items.Clear();
            Year1 = "";
            Year2 = "";
            string sqly = " select distinct Year from RMBudget";
            DataTable tempy = ODbcmd.SelectToDataTable(sqly);
            for (int i = 0; i < tempy.Rows.Count; i++)
            {
                comB_Year1.Items.Add(tempy.Rows[i]["Year"].ToString());
                comB_Year2.Items.Add(tempy.Rows[i]["Year"].ToString());
            }
        }

        private void btn_ExcelOut_Click(object sender, EventArgs e)
        {
            if (dgv_rmdata1[1, 1].Value == null)
            {
                MessageBox.Show("数据为空!");
                return;
            }
            string info = "工厂:" + comB_Facility.Text + "|" +
                "成本中心:" + comB_CC.Text + "|" +
                "年度:" + comB_Year1.Text + "|" +
                "报表类型:" + comB_report1.Text;
            ExcelControl a = new ExcelControl();
            a.SaveAsExcel(dgv_rmdata1, info);

        }
    }
}
