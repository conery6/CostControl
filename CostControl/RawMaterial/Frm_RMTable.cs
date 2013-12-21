using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CostControl.RawMaterial
{
    public partial class Frm_RMTable : Form
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
        float[,] FDT1 = new float[5,13];
        float[,] FDT2 = new float[5,13];
        float[,] f1 = new float[5, 13];
        float[,] f2 = new float[5, 13];
        float[,] f3 = new float[5, 13];

        public Frm_RMTable(string ENo1)
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

            dgv_rmdata1.Rows.Add("BASIC TABLE", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata1.Rows.Add("Purchase Cost", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata1.Rows.Add("Purchase Price", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata1.Rows.Add("Purchase Quantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata1.Rows.Add("Sales Quantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata1.Rows.Add("Availbility", null, null, null, null, null, null, null, null, null, null, null, null);

            dgv_rmdata1.Rows.Add("COMPARE TABLE", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata1.Rows.Add("Purchase Cost", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata1.Rows.Add("Purchase Price", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata1.Rows.Add("Purchase Quantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata1.Rows.Add("Sales Quantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata1.Rows.Add("Availbility", null, null, null, null, null, null, null, null, null, null, null, null);

            dgv_rmdata1.RowHeadersVisible = false;
            dgv_rmdata1.Columns[0].Width = 120;
            for (int i = 1; i < 13; i++)
            { dgv_rmdata1.Columns[i].Width = 60; }
            for (int j = 0; j < 12; j++)
            { dgv_rmdata1.Rows[j].Height = 20;
            dgv_rmdata1.Rows[j].ReadOnly = true;
            }
            dgv_rmdata1.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
            dgv_rmdata1.Rows[6].DefaultCellStyle.BackColor = Color.Gray;

            dgv_rmdata2.Rows.Add("T1", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("PurchaseCost", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("PurchasePrice", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("PurchaseQuantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("SalesQuantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("Availability", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("T2", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("PurchaseCost", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("PurchasePrice", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("PurchaseQuantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("SalesQuantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("Availability", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("T3", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("PurchaseCost", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("PurchasePrice", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("PurchaseQuantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("SalesQuantity", null, null, null, null, null, null, null, null, null, null, null, null);
            dgv_rmdata2.Rows.Add("Availability", null, null, null, null, null, null, null, null, null, null, null, null);



            dgv_rmdata2.RowHeadersVisible = false;
            dgv_rmdata2.Columns[0].Width = 120;
            for (int i = 1; i < 13; i++)
            { dgv_rmdata2.Columns[i].Width = 60; }
            for (int j = 0; j < 18; j++)
            {
                dgv_rmdata2.Rows[j].Height = 20;
                dgv_rmdata2.Rows[j].ReadOnly = true;
                dgv_rmdata2.Rows[j].Visible = false; 
            }

            dgv_rmdata2.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
            dgv_rmdata2.Rows[1].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[2].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[3].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[4].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[5].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[6].DefaultCellStyle.BackColor = Color.Gray;
            dgv_rmdata2.Rows[7].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[8].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[9].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[10].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[11].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[12].DefaultCellStyle.BackColor = Color.Gray;
            dgv_rmdata2.Rows[13].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[14].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[15].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[16].DefaultCellStyle.Format = "N2";
            dgv_rmdata2.Rows[17].DefaultCellStyle.Format = "N2";
        }

        private bool getPK1()//获取四个主键，做了个封装
        {
            if (FNo == "" || CCNo == "" || PNo == "" || Year1 == "" || Reporttype1 == "")
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
            if (FNo == "" || CCNo == "" || PNo == "" || Year2 == "" || Reporttype2 == "")
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
                DataTable r = new DataTable();
                switch (Reporttype1)
                {
                    case "T1":
                        r = GetRMData.Budget(CCNo, PNo, Year1);
                        break;
                    case "RF1":
                        r = GetRMData.MiddleBudget(CCNo, PNo, Year1, 3);
                        break;
                    case "RF2":
                        r = GetRMData.MiddleBudget(CCNo, PNo, Year1, 6);
                        break;
                    case "E3":
                        r = GetRMData.MiddleBudget(CCNo, PNo, Year1, 9);
                        break;
                    case "R":
                        r = GetRMData.Actual(CCNo, PNo, Year1);
                        break;
                }

                if (r.Rows.Count > 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (r.Rows[j][0].ToString() == (i + 1).ToString())
                            {
                                for (int k = 0; k < 12; k++)
                                {
                                    dgv_rmdata1[k + 1, i + 1].Value = r.Rows[j]["M" + (k + 1).ToString()];
                                }
                            }
                        }
                    }
                }
                else
                { MessageBox.Show("数据为空！"); }

                DT1 = r;
                FDT1 = GetRMData.DTto2DFloat(DT1);
            }
        }

        private void btn_dataok2_Click(object sender, EventArgs e)
        {
            if (getPK2())
            {
                DataTable r = new DataTable();

                switch (Reporttype2)
                {
                    case "T1":
                        r = GetRMData.Budget(CCNo, PNo, Year2);
                        break;
                    case "RF1":
                        r = GetRMData.MiddleBudget(CCNo, PNo, Year2, 3);
                        break;
                    case "RF2":
                        r = GetRMData.MiddleBudget(CCNo, PNo, Year2, 6);
                        break;
                    case "E3":
                        r = GetRMData.MiddleBudget(CCNo, PNo, Year2, 9);
                        break;
                    case "R":
                        r = GetRMData.Actual(CCNo, PNo, Year2);
                        break;
                }

                if (r.Rows.Count > 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (r.Rows[j][0].ToString() == (i + 1).ToString())
                            {
                                for (int k = 0; k < 12; k++)
                                {
                                    dgv_rmdata1[k + 1, i + 7].Value = r.Rows[j]["M" + (k + 1).ToString()];
                                }
                            }
                        }
                    }
                }
                else
                { 
                    MessageBox.Show("数据为空！");
                }
                DT2 = r;
                FDT2 = GetRMData.DTto2DFloat(DT2);
            }
        }

        private void chkB_T1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB_T1.Checked == true)
            {
                float[,] f = GetRMData.FReportTable1(FDT1, FDT2);
                f1 = f;
                dgv_rmdata2.Rows[0].Visible = true;
                for (int j = 1; j < 6; j++)
                {
                    dgv_rmdata2.Rows[j].Visible = true;
                    for (int i = 1; i < 13; i++)
                    {
                        dgv_rmdata2[i, j].Value = f[j-1, i];
                    }

                }
            }
            else
            {
                for (int j = 0; j < 6; j++)
                {
                    dgv_rmdata2.Rows[j].Visible = false ;
                }
            }
        }

        private void chkB_T2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB_T2.Checked == true)
            {
                //DataTable r = GetRMData.ReportTable2(DT1,DT2);
                float[,] f = GetRMData.FReportTable2(FDT1, FDT2);
                f2 = f;
                dgv_rmdata2.Rows[6].Visible = true;

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
                    dgv_rmdata2.Rows[j].Visible = true;
                    for (int i = 1; i < 13; i++)
                    {
                        dgv_rmdata2[i, j].Value = f[j - 7, i];
                    }
                }
            }
            else
            {
                for (int j =6; j < 12; j++)
                {
                    dgv_rmdata2.Rows[j].Visible = false;
                }
            }
        }

        private void chkB_T3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB_T3.Checked == true)
            {
                float[,] f = GetRMData.FReportTable3(FDT1, FDT2);
                f3 = f;
                dgv_rmdata2.Rows[12].Visible = true;
                for (int j = 13; j < 18; j++)
                {
                    dgv_rmdata2.Rows[j].Visible = true;
                    for (int i = 1; i < 13; i++)
                    {
                        dgv_rmdata2[i, j].Value =f[j - 13,i];
                    }
                }
            }
            else
            {
                for (int j = 12; j < 18; j++)
                {
                    dgv_rmdata2.Rows[j].Visible = false;
                }
            }
        }

        private void btn_TP1_Click(object sender, EventArgs e)
        {
            Frm_RMChart M_Chart = new Frm_RMChart(f1,1,-1);
            M_Chart.Show();
        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetRMData.FNo(comB_Facility.Text);
            comB_CC.Items.Clear();
            CCNo = "";
            string sql = "select CCName from CostCenter where  FNo ='" + FNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_CC.Items.Add(temp.Rows[i]["CCName"].ToString());
            }
        }

        private void comB_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
                PNo = GetRMData.PNo(comB_Product.Text);
                comB_Year1.Items.Clear();
                comB_Year2.Items.Clear();
                Year1 = "";
                Year2 = "";
                string sql = " select distinct Year from RMBudget where CCNo='" + CCNo + "' and PNo ='" + PNo + "'";
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

        private void comB_CC_SelectedIndexChanged(object sender, EventArgs e)
        {
            CCNo = GetRMData.CCNo(comB_CC.Text);
            comB_Product.Items.Clear();
            PNo = "";
            string sql = " select distinct PName from RMBudget, Product,CostCenter where CostCenter.CCNo =RMBudget.CCNo and Product.PNo =RMBudget.PNo and CCName='" + comB_CC.Text + "' ";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Product.Items.Add(temp.Rows[i]["PName"].ToString());
            }
        }

        private void btn_data1_Click(object sender, EventArgs e)
        {
            Frm_RMChart M_Chart = new Frm_RMChart(FDT1,100,0);
            M_Chart.Show();
        }

        private void btn_data2_Click(object sender, EventArgs e)
        {
            Frm_RMChart M_Chart = new Frm_RMChart(FDT2,100,0);
            M_Chart.Show();
        }

        private void btn_tp2_Click(object sender, EventArgs e)
        {
            Frm_RMChart M_Chart = new Frm_RMChart(f2,1,-1);
            M_Chart.Show();
        }

        private void btn_tp3_Click(object sender, EventArgs e)
        {
            Frm_RMChart M_Chart = new Frm_RMChart(f3,1,-1);
            M_Chart.Show();
        }

    }
}
