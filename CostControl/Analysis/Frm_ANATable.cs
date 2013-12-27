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
                        r = GetANAData.PeriodData(CCNo, Reporttype1, Year1);
                        break;
                    case "RF1":
                        r = GetANAData.PeriodData(CCNo, Reporttype1, Year1);
                        break;
                    case "RF2":
                        r = GetANAData.PeriodData(CCNo, Reporttype1, Year1);
                        break;
                    case "E3":
                        r = GetANAData.PeriodData(CCNo, Reporttype1, Year1);
                        break;
                    case "R":
                        r = GetANAData.Actual(CCNo, PNo, Year1);
                        break;
                }
                
                if (r.Tables.Count > 0)
                {
                    for (int y = 0; y < r.Tables.Count; y++)
                    {
                        if (y == 0)
                        {
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_rmdata1.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 14; k++)
                                    {
                                        dgv_rmdata1[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_rmdata1[14, i].Value = sum;
                                }
                                //汇总
                                dgv_rmdata1[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_rmdata1[14, m].Value.ToString());
                                }
                                dgv_rmdata1[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                            else
                            { MessageBox.Show("数据为空！"); }
                        }
                        else if (y == 1)
                        {
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_mgdata1.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_mgdata1[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_mgdata1[13, i].Value = sum;
                                }
                                //汇总
                                dgv_mgdata1[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_mgdata1[13, m].Value.ToString());
                                }
                                dgv_mgdata1[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                            else
                            { MessageBox.Show("数据为空！"); }
                        }
                        else if (y == 2)
                        {
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_edata1.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_edata1[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_edata1[13, i].Value = sum;
                                }
                                //汇总
                                dgv_edata1[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_edata1[13, m].Value.ToString());
                                }
                                dgv_edata1[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                            else
                            { MessageBox.Show("数据为空！"); }
                        }
                        else if (y == 3)
                        {
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_mtdata1.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_mtdata1[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_mtdata1[13, i].Value = sum;
                                }
                                //汇总
                                dgv_mtdata1[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_mtdata1[13, m].Value.ToString());
                                }
                                dgv_mtdata1[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                            else
                            { MessageBox.Show("数据为空！"); }
                        }
                    }
                }
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
                        r = GetANAData.PeriodData(CCNo, Reporttype2, Year2);
                        break;
                    case "RF1":
                        r = GetANAData.PeriodData(CCNo, Reporttype2, Year2);
                        break;
                    case "RF2":
                        r = GetANAData.PeriodData(CCNo, Reporttype2, Year2);
                        break;
                    case "E3":
                        r = GetANAData.PeriodData(CCNo, Reporttype2, Year2);
                        break;
                    case "R":
                        r = GetANAData.Actual(CCNo, PNo, Year2);
                        break;
                }

                if (r.Tables.Count > 0)
                {
                    for (int y = 0; y < r.Tables.Count; y++)
                    {
                        if (y == 0)
                        {
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_rmdata2.Rows.Add(r.Tables[y].Rows.Count + 1);
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
                                //汇总
                                dgv_rmdata2[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_rmdata2[14, m].Value.ToString());
                                }
                                dgv_rmdata2[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                            else
                            { MessageBox.Show("数据为空！"); }
                        }
                        else if (y == 1)
                        {
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_mgdata2.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_mgdata2[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_mgdata2[13, i].Value = sum;
                                }
                                //汇总
                                dgv_mgdata2[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_mgdata2[13, m].Value.ToString());
                                }
                                dgv_mgdata2[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                            else
                            { MessageBox.Show("数据为空！"); }
                        }
                        else if (y == 2)
                        {
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_edata2.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_edata2[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_edata2[13, i].Value = sum;
                                }
                                //汇总
                                dgv_edata2[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_edata2[13, m].Value.ToString());
                                }
                                dgv_edata2[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                            else
                            { MessageBox.Show("数据为空！"); }
                        }
                        else if (y == 3)
                        {
                            if (r.Tables[y].Rows.Count > 0)
                            {
                                dgv_mtdata2.Rows.Add(r.Tables[y].Rows.Count + 1);
                                for (int i = 0; i < r.Tables[y].Rows.Count; i++)
                                {
                                    float sum = 0f;
                                    for (int k = 0; k < 13; k++)
                                    {
                                        dgv_mtdata2[k, i].Value = r.Tables[y].Rows[i][k];
                                        if (k > 1)
                                        {
                                            data = r.Tables[y].Rows[i][k].ToString() != "" ? r.Tables[y].Rows[i][k].ToString() : "0";
                                            sum += float.Parse(data);
                                        }
                                    }
                                    dgv_mtdata2[13, i].Value = sum;
                                }
                                //汇总
                                dgv_mtdata2[0, r.Tables[y].Rows.Count].Value = "总计：";
                                float sumtotal = 0f;
                                for (int m = 0; m < r.Tables[y].Rows.Count; m++)
                                {
                                    sumtotal += float.Parse(dgv_mtdata2[13, m].Value.ToString());
                                }
                                dgv_mtdata2[1, r.Tables[y].Rows.Count].Value = sumtotal;
                            }
                            else
                            { MessageBox.Show("数据为空！"); }
                        }
                    }
                }
            }
        }

        private void chkB_T1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB_T1.Checked == true)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("sub");
                dt.Columns.Add("percent");

                //原料管理
                if (dgv_rmdata2.Rows.Count > 0 && dgv_rmdata1.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "原料管理";
                    dr[1] = float.Parse(dgv_rmdata2[1, dgv_rmdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_rmdata1[1, dgv_rmdata1.Rows.Count - 1].Value.ToString());
                    if (float.Parse(dr[1].ToString()) == 0f)
                    {
                        dr[2] = 0;
                    }
                    else
                    {
                        dr[2] = (float.Parse(dgv_rmdata2[1, dgv_rmdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_rmdata1[1, dgv_rmdata1.Rows.Count - 1].Value.ToString())) / float.Parse(dgv_rmdata2[1, dgv_rmdata2.Rows.Count - 1].Value.ToString());
                    }
                    dt.Rows.Add(dr);
                }

                //管理控制
                if (dgv_mgdata2.Rows.Count > 0 && dgv_mgdata1.Rows.Count > 0)
                {
                    DataRow dr1 = dt.NewRow();
                    dr1[0] = "管理控制";
                    dr1[1] = float.Parse(dgv_mgdata2[1, dgv_mgdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_mgdata1[1, dgv_mgdata1.Rows.Count - 1].Value.ToString());
                    if (float.Parse(dr1[1].ToString()) == 0f)
                    {
                        dr1[2] = 0;
                    }
                    else
                    {
                        dr1[2] = (float.Parse(dgv_mgdata2[1, dgv_mgdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_mgdata1[1, dgv_mgdata1.Rows.Count - 1].Value.ToString())) / float.Parse(dgv_mgdata2[1, dgv_mgdata2.Rows.Count - 1].Value.ToString());
                    }
                    dt.Rows.Add(dr1);
                }

                //电费控制
                if (dgv_edata2.Rows.Count > 0 && dgv_edata1.Rows.Count > 0)
                {
                    DataRow dr2 = dt.NewRow();
                    dr2[0] = "电费控制";
                    dr2[1] = float.Parse(dgv_edata2[1, dgv_edata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_edata1[1, dgv_edata1.Rows.Count - 1].Value.ToString());
                    if (float.Parse(dr2[1].ToString()) == 0f)
                    {
                        dr2[2] = 0;
                    }
                    else
                    {
                        dr2[2] = (float.Parse(dgv_edata2[1, dgv_edata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_edata1[1, dgv_edata1.Rows.Count - 1].Value.ToString())) / float.Parse(dgv_edata2[1, dgv_edata2.Rows.Count - 1].Value.ToString());
                    }
                    dt.Rows.Add(dr2);
                }

                //维修管理
                if (dgv_mtdata2.Rows.Count > 0 && dgv_mtdata1.Rows.Count > 0)
                {
                    DataRow dr3 = dt.NewRow();
                    dr3[0] = "维修管理";
                    dr3[1] = float.Parse(dgv_mtdata2[1, dgv_mtdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_mtdata1[1, dgv_mtdata1.Rows.Count - 1].Value.ToString());
                    if (float.Parse(dr3[1].ToString()) == 0f)
                    {
                        dr3[2] = 0;
                    }
                    else
                    {
                        dr3[2] = (float.Parse(dgv_mtdata2[1, dgv_mtdata2.Rows.Count - 1].Value.ToString()) - float.Parse(dgv_mtdata1[1, dgv_mtdata1.Rows.Count - 1].Value.ToString())) / float.Parse(dgv_mtdata2[1, dgv_mtdata2.Rows.Count - 1].Value.ToString());
                    }
                    dt.Rows.Add(dr3);
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
            string sqlrma = " select distinct PName from RMPeriod, Product,CostCenter where CostCenter.CCNo =RMPeriod.CCNo and Product.PNo =RMPeriod.PNo and CCName='" + comB_CC.Text + "' ";
            DataTable temprma = ODbcmd.SelectToDataTable(sqlrma);
            for (int i = 0; i < temprma.Rows.Count; i++)
            {
                clb_Product.Items.Add(temprma.Rows[i]["PName"].ToString());
            }

            //管理控制
            CCNo = GetMGData.CCNo(comB_CC.Text);
            clb_Manage.Items.Clear();
            string sqlm = " select distinct IName from MGPeriod where CCNo='" + CCNo + "'";
            DataTable tempm = ODbcmd.SelectToDataTable(sqlm);
            for (int i = 0; i < tempm.Rows.Count; i++)
            {
                clb_Manage.Items.Add(tempm.Rows[i]["IName"].ToString());
            }

            //电费控制
            CCNo = GetElectricData.CCNo(comB_CC.Text);
            clb_Electric.Items.Clear();
            string sqle = "select distinct Item,year from EPeriod where CCNo ='" + CCNo + "'";
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
