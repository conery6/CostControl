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
            Reporttype1 = comB_RpType1.Text;
        }

        private void comB_RpType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype2 = comB_RpType2.Text;
        }

        private void btn_dataok1_Click(object sender, EventArgs e)
        {
            if (FNo == "" || CCNo == "" || Year1 == "" || Reporttype1 == "")
            {
                MessageBox.Show("数据选择不完整！");
            }
            else
            {

                dgv_edata1.Rows.Clear();
                for (int i = 0; i < clb_CCItem.CheckedItems.Count; i++)
                {
                    string str = "select Type,TypeName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod  where year=" + Year1
                    + " and FNo='" + FNo + "' and CCNo='" + CCNo + "' and Period = '" + Reporttype1 + "' and TypeName ='" + clb_CCItem.CheckedItems[i].ToString() + "'";
                    DataTable dt = ODbcmd.SelectToDataTable(str);
                    if (dt.Rows.Count != 0)
                    {
                        dgv_edata1.Rows.Add();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            dgv_edata1[j, dgv_edata1.Rows.Count - 1].Value = dt.Rows[0][j].ToString();
                        }
                    }
                }

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
            if (FNo == "" || CCNo == "" || Year2 == "" || Reporttype2 == "")
            {
                MessageBox.Show("数据选择不完整！");
            }
            else
            {

                dgv_edata2.Rows.Clear();
                for (int i = 0; i < clb_CCItem.CheckedItems.Count; i++)
                {
                    string str = "select Type,TypeName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from EPeriod  where year=" + Year2
                    + " and FNo='" + FNo + "' and CCNo='" + CCNo + "' and Period = '" + Reporttype2 + "' and TypeName ='" + clb_CCItem.CheckedItems[i].ToString() + "'";
                    DataTable dt = ODbcmd.SelectToDataTable(str);
                    if (dt.Rows.Count != 0)
                    {
                        dgv_edata2.Rows.Add();
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            dgv_edata2[j, dgv_edata2.Rows.Count - 1].Value = dt.Rows[0][j].ToString();
                        }
                    }
                }

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

        private void btn_Chart1_Click(object sender, EventArgs e)
        {
            if (f1 != null)
            {

                Frm_EChart m_Frm_EChart = new Frm_EChart(Title, f1);
                m_Frm_EChart.Show();
            }
        }

        private void btn_Chart2_Click(object sender, EventArgs e)
        {
            if (f2 != null)
            {

                Frm_EChart m_Frm_EChart = new Frm_EChart(Title, f2);
                m_Frm_EChart.Show();
            }
        }

        private void btn_compare_Click(object sender, EventArgs e)
        {
            if (f1 != null && f2 != null && Title.Count != 0)
            {
                float[,] f3 = new float[dgv_edata2.Rows.Count, 12];
                for (int i = 0; i < Title.Count; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        f3[i, j] = (f2[i, j] - f1[i, j]) / f2[i, j];
                    }
                }


                for (int i = 0; i < Title.Count; i++)
                {
                    dgv_edata3.Rows.Add();
                    dgv_edata3[1, i].Value = Title[i];
                    for (int j = 2; j < dgv_edata2.Columns.Count; j++)
                    {
                        dgv_edata3[j, i].Value = f3[i, j - 2];
                    }
                }

                Frm_EChart m_Frm_EChart = new Frm_EChart(Title, f3);
                m_Frm_EChart.Show();
            }


        }


    }
}
