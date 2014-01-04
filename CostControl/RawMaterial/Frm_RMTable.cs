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
        public int ReportMonth1;
        public int ReportMonth2;
        public string CCNo;
        DataTable DT1;
        DataTable DT2;
        float[,] FDT1 = new float[5, 13];
        float[,] FDT2 = new float[5, 13];
        float[,] f1 = new float[5, 13];
        float[,] f2 = new float[5, 13];
        float[,] f3 = new float[5, 13];
        string currentType1 = "";
        string currentType2 = "";
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

            if (comB_Facility.Text == "" || comB_CC.Text == "" || comB_Product.Text == "" || comB_Year1.Text == "" || comB_RpType1.Text == "")
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
            if (comB_Facility.Text == "" || comB_CC.Text == "" || comB_Product.Text == "" || comB_Year2.Text == "" || comB_RpType2.Text == "")
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
                return false;
            }
            else
            {
                return true;
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
                        dgv_rmdata2[i, j].Value = f[j - 1, i];
                    }

                }
            }
            else
            {
                for (int j = 0; j < 6; j++)
                {
                    dgv_rmdata2.Rows[j].Visible = false;
                }
            }
        }

        //private void chkB_T2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkB_T2.Checked == true)
        //    {

        //        float[,] f = GetRMData.FReportTable2(FDT1, FDT2);
        //        f2 = f;
        //        dgv_rmdata2.Rows[6].Visible = true;

        //        for (int j = 7; j < 12; j++)
        //        {
        //            dgv_rmdata2.Rows[j].Visible = true;
        //            for (int i = 1; i < 13; i++)
        //            {
        //                dgv_rmdata2[i, j].Value = f[j - 7, i];
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int j = 6; j < 12; j++)
        //        {
        //            dgv_rmdata2.Rows[j].Visible = false;
        //        }
        //    }
        //}

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
                        dgv_rmdata2[i, j].Value = f[j - 13, i];
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
            string title = comB_Facility.Text + " " + comB_CC.Text + " " + comB_Product.Text + " " + comB_Year1.Text + "年 " + currentType1 + "与" + currentType2 + "差值比较表";
            string[] chartInfo = { title, "PurchaseCost", "PurchasePrice", "PurchaseQuantity", "SalesQuantity", "Availability" };
            Frm_RMChart M_Chart = new Frm_RMChart(f1, chartInfo);
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
            string sql = " select distinct Year from RMPeriod where CCNo='" + CCNo + "' and PNo ='" + PNo + "' and FNO='" + FNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Year1.Items.Add(temp.Rows[i]["Year"].ToString());
                comB_Year2.Items.Add(temp.Rows[i]["Year"].ToString());
            }
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
            string sql = " select distinct PName from RMPeriod, Product,CostCenter where CostCenter.CCNo =RMPeriod.CCNo and Product.PNo =RMPeriod.PNo and CCName='" + comB_CC.Text + "' ";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Product.Items.Add(temp.Rows[i]["PName"].ToString());
            }
        }

        private void btn_data1_Click(object sender, EventArgs e)
        {
            string title = comB_Facility.Text + " " + comB_CC.Text + " " + comB_Product.Text + " " + comB_Year1.Text + "年 " + currentType1 + "基本数据";
            string[] chartInfo = { title, "PurchaseCost", "PurchasePrice", "PurchaseQuantity", "SalesQuantity", "Availability" };
            Frm_RMChart M_Chart = new Frm_RMChart(FDT1, chartInfo);
            M_Chart.Show();
        }

        private void btn_data2_Click(object sender, EventArgs e)
        {
            string title = comB_Facility.Text + " " + comB_CC.Text + " " + comB_Product.Text + " " + comB_Year1.Text + "年 " + currentType2 + "基本数据";
            string[] chartInfo = { title, "PurchaseCost", "PurchasePrice", "PurchaseQuantity", "SalesQuantity", "Availability" };
            Frm_RMChart M_Chart = new Frm_RMChart(FDT2, chartInfo);
            M_Chart.Show();
        }

        private void btn_tp2_Click(object sender, EventArgs e)
        {
            string title = comB_Facility.Text + " " + comB_CC.Text + " " + comB_Product.Text + " " + comB_Year1.Text + "年 " + currentType1 + "与" + currentType2 + "平均差值比较表";
            string[] chartInfo = { title, "PurchaseCost", "PurchasePrice", "PurchaseQuantity", "SalesQuantity", "Availability" };
            Frm_RMChart M_Chart = new Frm_RMChart(f2, chartInfo);
            M_Chart.Show();
        }

        private void btn_tp3_Click(object sender, EventArgs e)
        {
            string title = comB_Facility.Text + " " + comB_CC.Text + " " + comB_Product.Text + " " + comB_Year1.Text + "年 " + currentType1 + "与" + currentType2 + "累计值差值比较表";

            string[] chartInfo = { title, "PurchaseCost", "PurchasePrice", "PurchaseQuantity", "SalesQuantity", "Availability" };
            Frm_RMChart M_Chart = new Frm_RMChart(f3, chartInfo);
            M_Chart.Show();
        }

        private void comB_RpType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype1 = comB_RpType1.Text;
        }

        private void comB_RpType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype2 = comB_RpType2.Text;
        }

        private void btn_Search1_Click(object sender, EventArgs e)
        {
            if (comB_Year1.Text == "" || comB_Facility.Text == "" || comB_CC.Text == "" || comB_Month1.Text == "")
            {
                MessageBox.Show("参数不全！");
            }
            else
            {
                for (int i = 0; i < dgv_rmdata1.Columns.Count; i++)
                {
                    dgv_rmdata1.Columns[i].ReadOnly = true;
                    dgv_rmdata1.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                comB_Year1.DropDownStyle = ComboBoxStyle.DropDownList;
                DataTable r = new DataTable();
                switch (comB_Month1.Text)
                {
                    case "3":
                        r = GetRMData.Period(FNo, CCNo, Year1, PNo, "RF1");
                        break;
                    case "6":
                        r = GetRMData.Period(FNo, CCNo, Year1, PNo, "RF2");
                        break;
                    case "9":
                        r = GetRMData.Period(FNo, CCNo, Year1, PNo, "E3");
                        break;
                    default:
                        r = GetRMData.Period(FNo, CCNo, Year1, PNo, "A" + ReportMonth1);
                        break;
                }
                dgv_rmdata1.DataSource = r;
                int acMonth = ReportMonth1;

                dgv_rmdata1.Columns[0].ReadOnly = true;
                dgv_rmdata1.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;

                for (int i = 1; i <= acMonth; i++)
                {
                    dgv_rmdata1.Columns[i].ReadOnly = true;
                    dgv_rmdata1.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
                DT1 = r;
                FDT1 = GetRMData.DTto2DFloat(DT1);
                currentType1 = "A" + ReportMonth1;
            }

        }

        private void btn_Search2_Click(object sender, EventArgs e)
        {
            if (comB_Year2.Text == "" || comB_Facility.Text == "" || comB_CC.Text == "" || comB_Month2.Text == "")
            {
                MessageBox.Show("参数不全！");
            }
            else
            {
                for (int i = 0; i < dgv_rmdata3.Columns.Count; i++)
                {
                    dgv_rmdata3.Columns[i].ReadOnly = true;
                    dgv_rmdata3.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                comB_Year1.DropDownStyle = ComboBoxStyle.DropDownList;
                DataTable r = new DataTable();
                switch (comB_Month2.Text)
                {
                    case "3":
                        r = GetRMData.Period(FNo, CCNo, Year2, PNo, "RF1");
                        break;
                    case "6":
                        r = GetRMData.Period(FNo, CCNo, Year2, PNo, "RF2");
                        break;
                    case "9":
                        r = GetRMData.Period(FNo, CCNo, Year2, PNo, "E3");
                        break;
                    default:
                        r = GetRMData.Period(FNo, CCNo, Year2, PNo, "A" + ReportMonth2);
                        break;
                }



                dgv_rmdata3.DataSource = r;

                int acMonth = ReportMonth2;

                dgv_rmdata3.Columns[0].ReadOnly = true;
                dgv_rmdata3.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;

                for (int i = 1; i <= acMonth; i++)
                {
                    dgv_rmdata3.Columns[i].ReadOnly = true;
                    dgv_rmdata3.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }

                DT2 = r;
                FDT2 = GetRMData.DTto2DFloat(DT2);
                currentType2 = "A" +ReportMonth2;
            }

        }

        private void btn_SearchPeriod1_Click(object sender, EventArgs e)
        {
            if (getPK1())
            {
                for (int i = 0; i < dgv_rmdata1.Columns.Count; i++)
                {
                    dgv_rmdata1.Columns[i].ReadOnly = true;
                    dgv_rmdata1.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                DataTable dt = new DataTable();
                if (Reporttype1 == "Actual")
                {
                    dt = GetRMData.Period(FNo, CCNo, Year1, PNo, "A12");
                }
                else
                {
                    dt = GetRMData.Period(FNo, CCNo, Year1, PNo, Reporttype1);
                }
                dgv_rmdata1.DataSource = dt;
                int acMonth = 0;

                switch (Reporttype1)
                {
                    case "T1": acMonth = 0; break;
                    case "RF1": acMonth = 3; break;
                    case "RF2": acMonth = 6; break;
                    case "E3": acMonth = 9; break;
                    case "Actual": acMonth = 12; break;
                }

                dgv_rmdata1.Columns[0].ReadOnly = true;
                dgv_rmdata1.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;

                for (int i = 1; i <= acMonth; i++)
                {
                    dgv_rmdata1.Columns[i].ReadOnly = true;
                    dgv_rmdata1.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
                DT1 = dt;
                FDT1 = GetRMData.DTto2DFloat(DT1);
                currentType1 = Reporttype1;
            }
        }

        private void btn_SearchPeriod2_Click(object sender, EventArgs e)
        {
            if (getPK2())
            {
                for (int i = 0; i < dgv_rmdata3.Columns.Count; i++)
                {
                    dgv_rmdata3.Columns[i].ReadOnly = true;
                    dgv_rmdata3.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                DataTable dt = new DataTable();
                if (Reporttype2 == "Actual")
                {
                    dt = GetRMData.Period(FNo, CCNo, Year2, PNo, "A12");
                }
                else
                {
                    dt = GetRMData.Period(FNo, CCNo, Year2, PNo, Reporttype2);
                }
                dgv_rmdata3.DataSource = dt;

                int acMonth = 0;

                switch (Reporttype2)
                {
                    case "T1": acMonth = 0; break;
                    case "RF1": acMonth = 3; break;
                    case "RF2": acMonth = 6; break;
                    case "E3": acMonth = 9; break;
                    case "Actual": acMonth = 12; break;
                }

                dgv_rmdata3.Columns[0].ReadOnly = true;
                dgv_rmdata3.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
                for (int i = 1; i <= acMonth ; i++)
                {
                    dgv_rmdata3.Columns[i].ReadOnly = true;
                    dgv_rmdata3.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
                DT2 = dt;
                FDT2 = GetRMData.DTto2DFloat(DT2);
                currentType2 = Reporttype2;
            }
        }

        private void comB_Month1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportMonth1 = Convert.ToInt32(comB_Month1.Text);
        }

        private void comB_Month2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportMonth2 = Convert.ToInt32(comB_Month2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (getPK1() && getPK2())
            {
                string[] header = { "工厂", "成本中心", "产品", "年份", "报表类型" };
                object[] cells1 = { comB_Facility.Text, comB_CC.Text, comB_Product.Text, int.Parse(comB_Year1.Text),currentType1 };
                object[] cells2 = { comB_Facility.Text, comB_CC.Text, comB_Product.Text, int.Parse(comB_Year2.Text),currentType2 };
                ExcelHelper excelHelp = new ExcelHelper();
                if (excelHelp.ShowSaveFileDialog())
                {
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells1);
                    excelHelp.AppendContent(cells2);
                    DataTable dt1 = (DataTable)dgv_rmdata1.DataSource;
                    DataTable dt2 = (DataTable)dgv_rmdata3.DataSource;
                    excelHelp.AppendToExcel(dt1, true, ExcelHelper.ExportStyle.RMTable);
                    excelHelp.AppendToExcel(dt2, false, ExcelHelper.ExportStyle.RMTable);
                    excelHelp.GenerateCompare();
                    excelHelp.SaveToExcel();
                }
            }

        }

    }
}
