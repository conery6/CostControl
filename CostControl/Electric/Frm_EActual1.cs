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
    public partial class Frm_EActual1 : Form
    {
        string FNo;
        string CCNo;
        string Year;
        //string Reporttype;
        public List<int[]> flaglist = new List<int[]>();
        public Frm_EActual1()
        {
            InitializeComponent();
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
            comB_Year.Items.Clear();
            string sql = "select distinct Year from EBudget where CCNo='" + CCNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Year.Items.Add(temp.Rows[i]["Year"].ToString());
            }
        }

        private void comB_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year = comB_Year.Text;
        }


        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (Year == "" || FNo == "" || CCNo == "")
            {
                MessageBox.Show("参数不齐全!");
            }
            else
            {
                DataTable r = new DataTable();
                r = GetElectricData.Actual(FNo, Year, CCNo);
                dgv_Edata.DataSource = r;
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            dgv_Edata.ReadOnly = false;
            dgv_Edata.Columns[0].ReadOnly = true;
            int[] autoItemnum = { 0, 1, 2, 3, 8, 9, 10, 14, 18, 20, 22, 23 };
            for (int i = 0; i < autoItemnum.Length; i++)
            {
                dgv_Edata.Rows[autoItemnum[i]].ReadOnly = true;
                dgv_Edata.Rows[autoItemnum[i]].DefaultCellStyle.BackColor = Color.LightGray;
            }
            btn_UpdateOk.Visible = true;
            btn_addOK.Visible = false;
            btn_Cancel.Visible = true;

        }

        private void dgv_Edata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int colm = dgv_Edata.CurrentCell.ColumnIndex;
            int rowm = dgv_Edata.CurrentCell.RowIndex;
            try
            {
                if (Convert.ToSingle(dgv_Edata[colm, 4].Value) != 0 && Convert.ToSingle(dgv_Edata[colm, 5].Value) != 0 && Convert.ToSingle(dgv_Edata[colm, 7].Value) != 0)
                {
                    dgv_Edata[colm, 0].Value = Convert.ToSingle(dgv_Edata[colm, 14].Value) / (Convert.ToSingle(dgv_Edata[colm, 4].Value) + Convert.ToSingle(dgv_Edata[colm, 5].Value) + 0.43 * Convert.ToSingle(dgv_Edata[colm, 7].Value));
                    dgv_Edata[colm, 1].Value = Convert.ToSingle(dgv_Edata[colm, 11].Value) / (Convert.ToSingle(dgv_Edata[colm, 4].Value) + 0.43 * Convert.ToSingle(dgv_Edata[colm, 6].Value));
                    dgv_Edata[colm, 2].Value = (Convert.ToSingle(dgv_Edata[colm, 12].Value) - Convert.ToSingle(dgv_Edata[colm, 13].Value)) / Convert.ToSingle(dgv_Edata[colm, 5].Value);
                    dgv_Edata[colm, 14].Value = Convert.ToSingle(dgv_Edata[colm, 11].Value) + Convert.ToSingle(dgv_Edata[colm, 12].Value);
                    dgv_Edata[colm, 3].Value = (Convert.ToSingle(dgv_Edata[colm, 14].Value) - Convert.ToSingle(dgv_Edata[colm, 1].Value) * Convert.ToSingle(dgv_Edata[colm, 4].Value) - Convert.ToSingle(dgv_Edata[colm, 2].Value) * Convert.ToSingle(dgv_Edata[colm, 5].Value)) / Convert.ToSingle(dgv_Edata[colm, 7].Value);
                    dgv_Edata[colm, 8].Value = Convert.ToSingle(dgv_Edata[colm, 1].Value) * Convert.ToSingle(dgv_Edata[colm, 4].Value);
                    dgv_Edata[colm, 9].Value = Convert.ToSingle(dgv_Edata[colm, 2].Value) * Convert.ToSingle(dgv_Edata[colm, 5].Value);
                    dgv_Edata[colm, 10].Value = Convert.ToSingle(dgv_Edata[colm, 3].Value) * Convert.ToSingle(dgv_Edata[colm, 7].Value);
                    dgv_Edata[colm, 18].Value = Convert.ToSingle(dgv_Edata[colm, 8].Value) * Convert.ToSingle(dgv_Edata[colm, 15].Value);
                    dgv_Edata[colm, 20].Value = Convert.ToSingle(dgv_Edata[colm, 9].Value) * Convert.ToSingle(dgv_Edata[colm, 16].Value);
                    dgv_Edata[colm, 22].Value = Convert.ToSingle(dgv_Edata[colm, 10].Value) * Convert.ToSingle(dgv_Edata[colm, 15].Value);
                    dgv_Edata[colm, 23].Value = Convert.ToSingle(dgv_Edata[colm, 17].Value) + Convert.ToSingle(dgv_Edata[colm, 18].Value) + Convert.ToSingle(dgv_Edata[colm, 19].Value) + Convert.ToSingle(dgv_Edata[colm, 20].Value) + Convert.ToSingle(dgv_Edata[colm, 21].Value) + Convert.ToSingle(dgv_Edata[colm, 22].Value);
                }
            }
            catch { }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            comB_Year.DropDownStyle = ComboBoxStyle.DropDown;
            btn_UpdateOk.Visible = false;
            btn_addOK.Visible = true;
            btn_Cancel.Visible = true;
            for (int i = dgv_Edata.Rows.Count; i < 0; i--)
            {
                dgv_Edata.Rows.RemoveAt(i);
            }
            string str = "select itemnum,Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from Tamplate where TableName ='EBudget'and CCNo='" + CCNo + "'";
            DataTable dt = ODbcmd.SelectToDataTable(str);
            dgv_Edata.DataSource = dt;

            for (int i = 2; i < dgv_Edata.Columns.Count; i++)
            {
                for (int j = 0; j < dgv_Edata.Rows.Count; j++)
                {
                    dgv_Edata[i, j].Value = 0;
                }
            }

            dgv_Edata.ReadOnly = false;
            dgv_Edata.Columns[0].ReadOnly = true;
            int[] autoItemnum = { 0, 1, 2, 3, 8, 9, 10, 14, 18, 20, 22, 23 };
            for (int i = 0; i < autoItemnum.Length; i++)
            {
                dgv_Edata.Rows[autoItemnum[i]].ReadOnly = true;
                dgv_Edata.Rows[autoItemnum[i]].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }


        private void btn_addOK_Click(object sender, EventArgs e)
        {
            if (Year == "" || FNo == "" || CCNo == "")
            { MessageBox.Show("参数不齐全!"); }

            else
            {
                DataTable r = GetElectricData.Budget(FNo, Year, CCNo);
                if (r.Rows.Count > 0)
                {
                    MessageBox.Show("Actual表已存在！");
                }
                else
                {
                    for (int i = 0; i < dgv_Edata.Rows.Count; i++)
                    {
                        string str = string.Format(" insert into EActual values ('{0}',{1},'{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})",
                            Convert.ToString(dgv_Edata[1, i].Value), Convert.ToInt16(dgv_Edata[0, i].Value), FNo, CCNo, Year,
                            Convert.ToSingle(dgv_Edata[2, i].Value), Convert.ToSingle(dgv_Edata[3, i].Value), Convert.ToSingle(dgv_Edata[4, i].Value),
                            Convert.ToSingle(dgv_Edata[5, i].Value), Convert.ToSingle(dgv_Edata[6, i].Value), Convert.ToSingle(dgv_Edata[7, i].Value),
                            Convert.ToSingle(dgv_Edata[8, i].Value), Convert.ToSingle(dgv_Edata[9, i].Value), Convert.ToSingle(dgv_Edata[10, i].Value),
                            Convert.ToSingle(dgv_Edata[11, i].Value), Convert.ToSingle(dgv_Edata[12, i].Value), Convert.ToSingle(dgv_Edata[13, i].Value));
                        ODbcmd.ExecuteSQLNonquery(str);
                    }
                }
            }

        }


        private void comB_Year_TextChanged(object sender, EventArgs e)
        {
            Year = comB_Year.Text;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (FNo == "" || CCNo == "" || Year == "")
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
            }
                else
                {
                try
                {
                    //string TableName = string.Empty;
                    if (MessageBox.Show("是否确认删除本表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgv_Edata.Rows.Count; i += 2)
                        {
                            //string CCNo = GetElectricData.CCNo(dgv_Edata[0, i].Value.ToString());
                            string str = "delete from EActual where CCNo ='" + CCNo + "' and Year =" + Year;
                            ODbcmd.ExecuteSQLNonquery(str);
                        }
                        MessageBox.Show("删除成功");
                        comB_CC.Text = "";
                        comB_Year.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Exceladd_Click(object sender, EventArgs e)
        {
            OpenFileDialog xlsDileDialog = new OpenFileDialog();
            xlsDileDialog.Filter = "xls文件|*.xlsx|所有文件|*.*";
            xlsDileDialog.FilterIndex = 1;

            if (xlsDileDialog.ShowDialog() == DialogResult.OK)
            {
                string sExcelFile = xlsDileDialog.FileName;

            }
        }

        private void Excelout_Click(object sender, EventArgs e)
        {
            ExcelControl a = new ExcelControl();
            a.SaveAsExcel(dgv_Edata);
        }

        private void Frm_EActual_Load(object sender, EventArgs e)
        {

        }
    }
    }
