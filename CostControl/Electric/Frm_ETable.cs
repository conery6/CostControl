using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CostControl.Electric
{
    public partial class Frm_ETable : Form
    {
        string FNo;
        string CCNo;
        string Year1;
        string Year2;
        string Reporttype1;
        string Reporttype2;
        float[,] f1;
        float[,] f2;
        float[,] FDT1 = new float[5, 13];
        float[,] FDT2 = new float[5, 13];

        List<string> Title = new List<string>();

        public Frm_ETable()
        {
            InitializeComponent();
        }

        private void Frm_ETable_Load(object sender, EventArgs e)
        {
            
        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetElectricData.FNo(comB_Facility.Text);
            comB_CC.Items.Clear();
            string sql = "select CCName from CostCenter where  FNo ='" + FNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_CC.Items.Add(temp.Rows[i]["CCName"].ToString());
            }
        }

        private void comB_CC_SelectedIndexChanged(object sender, EventArgs e)
        {
            CCNo = GetElectricData.CCNo(comB_CC.Text);
            clb_CCItem.Items.Clear();
            string sql = "select distinct TypeName from EPeriod where CCNo ='" + CCNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                clb_CCItem.Items.Add(temp.Rows[i]["TypeName"].ToString());
            }

            comB_Year1.Items.Clear();
            comB_Year2.Items.Clear();

            string sql1 = "select distinct Year from EPeriod where CCNo ='" + CCNo + "'";
            DataTable tmp2 = ODbcmd.SelectToDataTable(sql1);
            for (int i = 0; i < tmp2.Rows.Count; i++)
            {
                comB_Year1.Items.Add(tmp2.Rows[i]["Year"].ToString());
                comB_Year2.Items.Add(tmp2.Rows[i]["Year"].ToString());

            }
        }

        private void btn_addalll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clb_CCItem.Items.Count; i++)
            {
                clb_CCItem.SetItemChecked(i, true);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clb_CCItem.Items.Count; i++)
            {
                clb_CCItem.SetItemChecked(i, false);
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

        private void comB_RpType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype1 = comB_Month1.Text;
        }

        private void comB_RpType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype2 = comB_Month2.Text;
        }

        private bool getPK1()
        {

            if (comB_Facility.Text == "" || comB_CC.Text == "" || clb_CCItem.CheckedItems == null || comB_Year1.Text == "" || comB_Month1.Text == "")
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool getPK2()
        {
            if (comB_Facility.Text == "" || comB_CC.Text == "" || clb_CCItem.CheckedItems == null || comB_Year2.Text == "" || comB_Month2.Text == "")
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
                string Period = comB_Month1.Text;
                string typeName = "";
                for (int i = 0; i < clb_CCItem.CheckedItems.Count; i++)
                {
                    typeName += "'" + clb_CCItem.CheckedItems[i].ToString() + "',";
                }
                typeName = typeName.Remove(typeName.Length - 1);
                string str = "select TypeName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod  where year=" + Year1
                    + " and FNo='" + FNo + "' and CCNo='" + CCNo + "' and Period = '" + Period + "' and TypeName in (" + typeName + ") order by Type";
                DataTable dt = ODbcmd.SelectToDataTable(str);
                dgv_edata1.DataSource = dt;
                //for (int k = 0; k < dt.Rows.Count; k++ )
                //{
                //    dgv_edata1.Rows.Add();
                //    for (int j = 0; j < dt.Columns.Count; j++)
                //    {
                //        dgv_edata1[j, dgv_edata1.Rows.Count - 1].Value = dt.Rows[k][j].ToString();
                //    }
                //}

                Title.Clear();

                f1 = new float[dgv_edata1.Rows.Count, 12];
                for (int i = 0; i < dgv_edata1.Rows.Count; i++)
                {
                    Title.Add(dgv_edata1[1, i].Value.ToString());
                   
                    for (int j = 2; j < dgv_edata1.Columns.Count; j++)
                    {
                        float val = 0;
                        Single.TryParse(dgv_edata1[j, i].Value.ToString(), out val);
                        f1[i, j - 2] =val;
                    }
                }
            }
        }

        private void btn_dataok2_Click(object sender, EventArgs e)
        {
            if (getPK2())
            {
                string Period = comB_Month2.Text;
                string typeName = "";
                for (int i = 0; i < clb_CCItem.CheckedItems.Count; i++)
                {
                    typeName += "'" + clb_CCItem.CheckedItems[i].ToString() + "',";
                    
                }
                typeName = typeName.Remove(typeName.Length - 1);
                string str = "select TypeName,Type,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod  where year=" + Year2
                    + " and FNo='" + FNo + "' and CCNo='" + CCNo + "' and Period = '" + Period + "' and TypeName in (" + typeName + ") order by Type";
                DataTable dt = ODbcmd.SelectToDataTable(str);
                dgv_edata2.DataSource = dt;
                //if (dt.Rows.Count != 0)
                //{
                //    dgv_edata2.Rows.Add();
                //    for (int j = 0; j < dt.Columns.Count; j++)
                //    {
                //        dgv_edata2[j, dgv_edata2.Rows.Count - 1].Value = dt.Rows[0][j].ToString();
                //    }
                //}

                Title.Clear();
                f2 = new float[dgv_edata2.Rows.Count, 12];
                for (int i = 0; i < dgv_edata2.Rows.Count; i++)
                {
                    Title.Add(dgv_edata2[1, i].Value.ToString());
                   
                    for (int j = 2; j < dgv_edata2.Columns.Count; j++)
                    {
                        float val = 0;
                        Single.TryParse(dgv_edata1[j, i].Value.ToString(), out val);
                        f2[i, j - 2] = val;
                    }
                }
            }
        }


        private void btn_compare_Click(object sender, EventArgs e)
        {
            string title = comB_Facility.Text + " " + comB_CC.Text + " " + comB_Year1.Text + "年 " + comB_Month1.Text + "与" + comB_Year2.Text + "年 " + comB_Month2.Text + "差值比较表";
            string[] chartInfo = { title, comB_Year1.Text + "  " + comB_Month1.Text, comB_Year2.Text + "  " + comB_Month2.Text };
            Frm_EChart M_Chart = new Frm_EChart(f1, chartInfo);
            M_Chart.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object[] cells1 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), comB_Month1.Text }; //基准数据 Facility，CC,Year,Period
            object[] cells2 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year2.Text), comB_Month1.Text }; //比较数据 Facility，CC,Year,Period
            ExcelHelper excelHelp = new ExcelHelper();
            if (excelHelp.ShowSaveFileDialog())
            {
                excelHelp.LoadFromTemplate("ExcelTemplate\\CHJElectricTemplate.xlsx");
                excelHelp.AppendToExcel(cells1, 2, 2, false);
                excelHelp.AppendToExcel(cells2, 3, 2, false);
                DataTable dt1 = (DataTable)dgv_edata1.DataSource; //数据源1，M1，M2，M3...
                DataTable dt2 = (DataTable)dgv_edata2.DataSource; ////数据源2，M1，M2，M3...
                excelHelp.DataTableToExcel(dt1, 5, 2, false, ExcelHelper.ExportStyle.None);
                excelHelp.DataTableToExcel(dt2, 105, 2, false, ExcelHelper.ExportStyle.None);
                excelHelp.SaveToExcel();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            object[] cells1 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year1.Text), comB_Month1.Text }; //基准数据 Facility，CC,Year,Period
            object[] cells2 = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year2.Text), comB_Month1.Text }; //比较数据 Facility，CC,Year,Period
            ExcelHelper excelHelp = new ExcelHelper();
            if (excelHelp.ShowSaveFileDialog())
            {
                excelHelp.LoadFromTemplate("ExcelTemplate\\HLSElectricTemplate.xlsx");
                excelHelp.AppendToExcel(cells1, 2, false);
                excelHelp.AppendToExcel(cells2, 3, false);
                DataTable dt1 = (DataTable)dgv_edata1.DataSource; //数据源1，M1，M2，M3...
                DataTable dt2 = (DataTable)dgv_edata2.DataSource; ////数据源2，M1，M2，M3...
                excelHelp.DataTableToExcel(dt1, 5, 1, false, ExcelHelper.ExportStyle.None);
                excelHelp.DataTableToExcel(dt2, 38, 1, false, ExcelHelper.ExportStyle.None);
                excelHelp.SaveToExcel();
            }

        }

        //private void chkB_T1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkB_T1.Checked == true)
        //    {
        //        //获取差值数据
        //        float[,] f = GetElectricData.FReportTable1(FDT1, FDT2);
        //        f1 = f;
        //        //dgv_edata3.Rows[0].Visible = true;
        //        ////为gridview赋值
        //        //for (int j = 1; j < 6; j++)
        //        //{
        //        //    dgv_edata3.Rows[j].Visible = true;
        //        //    //1到12列赋值，第0列已有数据
        //        //    for (int i = 1; i < 13; i++)
        //        //    {
        //        //        dgv_edata3[i, j].Value = f[j - 1, i];
        //        //    }
        //        //}
        //    }
        //    else
        //    {
        //        //for (int j = 0; j < dgv_edata3.Rows.Count; j++)
        //        //{
        //        //    dgv_edata3.Rows[j].Visible = false;
        //        //}
        //    }
        //}
    }
}
