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
        float[,] FDT1a = new float[10, 13];
        float[,] FDT2a = new float[10, 13];
        float[,] FDT1b = new float[10, 13];
        float[,] FDT2b = new float[10, 13];
        float[] sum1 = new float[12];
        float[] sum2 = new float[12];
        float[] sum1a = new float[12];
        float[] sum2a = new float[12];
        float[] sum1b = new float[12];
        float[] sum2b = new float[12];
        float[] total1 = new float[12];
        float[] total2 = new float[12];
        float[] total1a = new float[12];
        float[] total2a = new float[12];
        float[] total1b = new float[12];
        float[] total2b = new float[12];

        DataTable DT1;
        DataTable DT2;
        DataTable DT1a;
        DataTable DT2a;
        DataTable DT1b;
        DataTable DT2b;

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
                string FSNo1 = "";
                DataTable sumdt = new DataTable();
                DataTable sumdta = new DataTable();
                DataTable sumdtb = new DataTable();
                DataTable sumall = new DataTable();

                float[] spa = new float[12];
                float[] sub = new float[12];
                float[] all = new float[12];

                for (int i = 0; i < clb_FSystem.CheckedItems.Count; i++)
                {
                    FSNo1 += "'" + GetMaintainData.FSNo(clb_FSystem.CheckedItems[i].ToString()) + "',";
                }
            
                FSNo1 = FSNo1.Remove(FSNo1.Length - 1);
                
                String Period = comB_RpType1.Text;
               
                //Get data
                sumdt = GetMaintainData.GetData2(FNo, FSNo1, Year1, CCNo, Period);
                //spa
                sumdta = GetMaintainData.GetDataa(FNo, FSNo1, Year1, CCNo, Period);
                //sub
                sumdtb = GetMaintainData.GetDatab(FNo, FSNo1, Year1, CCNo, Period);
             

                if (sumdt.Rows.Count == 0)
                {
                    MessageBox.Show("数据为空");
                    return;
                }
                else
                {
                    dgv_rmdata1.DataSource = sumdt;
                }
                //1.sumall
                DT1 = sumdt;
                FDT1 = GetMaintainData.DTto2DFloat(DT1);

                for (int i = 0; i < dgv_rmdata1.Columns.Count-2; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < dgv_rmdata1.Rows.Count; j++)
                    {
                        sum += FDT1[j, i];
                    }
                    sum1[i] = sum;
                }
                //累计值
                total1[0] = sum1[0];
                for (int j = 1; j < 12; j++)
                {
                    total1[j] = sum1[j] + total1[j - 1];
                }

                //2.spa
                DT1a = sumdta;
                FDT1a = GetMaintainData.DTto2DFloat(DT1a);

                for (int i = 0; i < dgv_rmdata1.Columns.Count - 2; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < dgv_rmdata1.Rows.Count; j++)
                    {
                        sum += FDT1[j, i];
                    }
                    sum1a[i] = sum;
                }
                total1a[0] = sum1a[0];
                for (int j = 1; j < 12; j++)
                {
                    total1a[j] = sum1a[j] + total1a[j - 1];
                }

                //3.sub
                DT1b = sumdtb;
                FDT1b = GetMaintainData.DTto2DFloat(DT1b);

                for (int i = 0; i < dgv_rmdata1.Columns.Count - 2; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < dgv_rmdata1.Rows.Count; j++)
                    {
                        sum += FDT1[j, i];
                    }
                    sum1b[i] = sum;
                }
                total1b[0] = sum1b[0];
                for (int j = 1; j < 12; j++)
                {
                    total1b[j] = sum1b[j] + total1b[j - 1];
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
                DataTable sumdta = new DataTable();
                DataTable sumdtb = new DataTable();
                DataTable sumall = new DataTable();

                float [] spa = new float [12];
                float [] sub = new float [12] ;
                float [] all = new float [12];

                for (int i = 0; i < clb_FSystem.CheckedItems.Count; i++)
                {
                    FSNo += "'" + GetMaintainData.FSNo(clb_FSystem.CheckedItems[i].ToString()) + "',";
                }
                FSNo = FSNo.Remove(FSNo.Length - 1);

                String Period = comB_RpType2.Text;

                //Get data
                sumdt = GetMaintainData.GetData2(FNo, FSNo, Year2, CCNo, Period);
                sumdta = GetMaintainData.GetDataa(FNo, FSNo, Year2, CCNo, Period);
                sumdtb = GetMaintainData.GetDatab(FNo, FSNo, Year2, CCNo, Period);

                if (sumdt.Rows.Count == 0)
                {
                    MessageBox.Show("数据为空");
                }
                else
                {
                    dgv_rmdata2.DataSource = sumdt;
                }
                //1
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
                total2[0] = sum2[0];
                for (int j = 1; j < 12; j++)
                {
                    total2[j] = sum2[j] + total2[j - 1];
                }
                //2
                DT2a = sumdta;
                FDT2a = GetMaintainData.DTto2DFloat(DT2a);

                for (int i = 0; i < 12; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < dgv_rmdata2.Rows.Count; j++)
                    {
                        sum += FDT2[j, i];
                    }
                    sum2a[i] = sum;
                }
                total2a[0] = sum2a[0];
                for (int j = 1; j < 12; j++)
                {
                    total2a[j] = sum2a[j] + total2a[j - 1];
                }
                //3
                DT2b = sumdtb;
                FDT2b = GetMaintainData.DTto2DFloat(DT2b);

                for (int i = 0; i < 12; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < dgv_rmdata2.Rows.Count; j++)
                    {
                        sum += FDT2[j, i];
                    }
                    sum2b[i] = sum;
                }
                total2b[0] = sum2b[0];
                for (int j = 1; j < 12; j++)
                {
                    total2b[j] = sum2b[j] + total2b[j - 1];
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

        private void button2_Click(object sender, EventArgs e)
        {
            //通过object[]参数导出excel
            object[] cells1 = { comB_Facility.Text, clb_CC.Text, int.Parse(comB_Year1.Text), comB_RpType1.Text }; //基准数据 Facility，CC,Year,Period
            object[] cells2 = { comB_Facility.Text, clb_CC.Text, int.Parse(comB_Year2.Text), comB_RpType2.Text }; //比较数据 Facility，CC,Year,Period
            object[] obj1 = new object[total1a.Length];
            object[] obj2 = new object[total1b.Length];
            object[] obj3 = new object[total1.Length];

            object[] obj11 = new object[total2a.Length];
            object[] obj22 = new object[total2b.Length];
            object[] obj33 = new object[total2.Length];

            total1a.CopyTo(obj1, 0);
            total1b.CopyTo(obj2, 0);
            total1.CopyTo(obj3, 0);

            total2a.CopyTo(obj11, 0);
            total2b.CopyTo(obj22, 0);
            total2.CopyTo(obj33, 0);

            ExcelHelper excelHelp = new ExcelHelper();
            if (excelHelp.ShowSaveFileDialog())
            {
                excelHelp.LoadFromTemplate("ExcelTemplate\\MaintainTemplate.xlsx");
                excelHelp.AppendToExcel(cells1, 2, 2, false);
                excelHelp.AppendToExcel(cells2, 3, 2, false);
                excelHelp.AppendToExcel(obj1, 5, 2, false);
                excelHelp.AppendToExcel(obj2, 6, 2, false);
                excelHelp.AppendToExcel(obj3, 7, 2, false);
                excelHelp.AppendToExcel(obj11, 8, 2, false);
                excelHelp.AppendToExcel(obj22, 9, 2, false);
                excelHelp.AppendToExcel(obj33, 10, 2, false);
                excelHelp.SaveToExcel();
            }

            //if (excelHelp.ShowSaveFileDialog())
            //{
            //    excelHelp.LoadFromTemplate("ExcelTemplate\\MaintainTemplate.xlsx");
            //    excelHelp.AppendToExcel(cells1, 2, 2, false);
            //    excelHelp.AppendToExcel(cells2, 3, 2, false);
            //    DataTable dt1 = (DataTable)dgv_rmdata1.DataSource; //数据源1，M1，M2，M3...
            //    DataTable dt2 = (DataTable)dgv_rmdata2.DataSource; ////数据源2，M1，M2，M3...
            //    excelHelp.DataTableToExcel(dt1, 5, 2, false, ExcelHelper.ExportStyle.None);
            //    excelHelp.DataTableToExcel(dt2, 8, 2, false, ExcelHelper.ExportStyle.None);
            //    excelHelp.SaveToExcel();
            //}
        }
    }
}
