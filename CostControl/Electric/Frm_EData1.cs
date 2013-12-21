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
    public partial class Frm_EData1 : Form
    {
        string FNo;
        string CCNo;
        string Year;
        string Reporttype;

        public List<int[]> flaglist = new List<int[]>();


        public Frm_EData1()
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
            string sql = "select distinct Year from EBudget where CCNo ='" + CCNo + "'";
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
            if (Year == "" || FNo == "" || CCNo == "" || Reporttype == "")
            {
                MessageBox.Show("参数不全！");
            }
            else
            {
                DataTable r = new DataTable();
                switch (Reporttype)
                {
                    case "预算表 T1":
                        r = GetElectricData.Budget(FNo, Year, CCNo);
                        break ;
                    case "预算表 RF1":
                        r = GetElectricData.MiddleBudget(FNo, CCNo, Year, 3);
                        break ;
                    case "预算表 RF2":
                        r = GetElectricData.MiddleBudget(FNo, CCNo, Year, 6);
                        break;
                    case "预算表 E3":
                        r = GetElectricData.MiddleBudget(FNo, CCNo, Year, 9);
                        break;
                    case "Acutal表":
                        r = GetElectricData.Actual(FNo, Year, CCNo);
                        break;
                }

                dgv_Edata.DataSource = r;
                
            }
        }

        private void comB_RpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype = comB_RpType.Text;
        }

        private void Frm_EData_Load(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            dgv_Edata.ReadOnly = false;
            dgv_Edata .Columns [0].ReadOnly =true ;

            int [] autoItemnum = {0,8,9,10,11,12,13,14,18,20,22,23,24,25,26,27,28,29};

            for (int i = 0; i < autoItemnum.Length; i++)
            {
                dgv_Edata.Rows[autoItemnum [i]].ReadOnly = true;
                dgv_Edata.Rows[autoItemnum[i]].DefaultCellStyle.BackColor = Color.LightGray;
            }

            switch (Reporttype)
            {
                case "预算表 RF1":
                    for (int i = 2; i < 5; i++)
                    {
                        dgv_Edata.Columns[i].ReadOnly = true;
                        dgv_Edata.Columns[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    break;
                case "预算表 RF2":
                    for (int i = 2; i < 8; i++)
                    {
                        dgv_Edata.Columns[i].ReadOnly = true;
                        dgv_Edata.Columns[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    break;
                case "预算表 E3":
                    for (int i = 2; i < 11; i++)
                    {
                        dgv_Edata.Columns[i].ReadOnly = true;
                        dgv_Edata.Columns[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    break;
                case "Acutal表":
                    for (int i = 2; i < 14; i++)
                    {
                        dgv_Edata.Columns[i].ReadOnly = true;
                        dgv_Edata.Columns[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    break;
            }

            btn_UpdateOk.Visible = true;
            btn_Cancel.Visible = true;
        }

        private void dgv_Edata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private bool getPK()//获取四个主键
        {
            if (FNo == "" || CCNo == "" || Year == "" || Reporttype == "")
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (getPK())
            {
                try
                {
                    string TableName = string.Empty;
                    if (MessageBox.Show("是否确认删除本表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        switch (Reporttype)
                        {
                            case "预算表 T1":
                                TableName = "EBudget";
                                break;
                            case "Actual表":
                                TableName = "EActual";
                                break;
                            default:
                                MessageBox.Show("仅可删除 预算表 T1、预提表、Actual表、实际值表");
                                return;
                        }

                        for (int i = 0; i < dgv_Edata.Rows.Count; i += 2)
                        {
                            string CCNo = GetElectricData.CCNo(dgv_Edata[0, i].Value.ToString());
                            string str = "delete from " + TableName + " where CCNo ='" + CCNo + "' and Year =" + Year;
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            comB_Year.DropDownStyle = ComboBoxStyle.DropDown;
            btn_addOK.Visible = true;
            btn_Cancel.Visible = true;
            for (int i = dgv_Edata.Rows.Count; i <0 ; i--)
            {
                dgv_Edata.Rows.RemoveAt(i);
            }
            string str = "select Itemnum ,Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from Tamplate where TableName = 'Ebudget' and CCNo = '" + CCNo + "'";
            DataTable dt = ODbcmd.SelectToDataTable (str );
            dgv_Edata .DataSource =dt ;
            for (int i =2;i<dgv_Edata .Columns .Count ;i++)
            {
                for (int j=0;j <dgv_Edata .Rows .Count ;j++)
                {
                    dgv_Edata[i, j].Value = 0;
                }
            }

            int[] autoItemnum = { 0, 8, 9, 10, 11, 12, 13, 14, 18, 20, 22, 23, 24, 25, 26, 27, 28, 29 };

            for (int i = 0; i < autoItemnum.Length; i++)
            {
                dgv_Edata.Rows[autoItemnum[i]].DefaultCellStyle.BackColor = Color.LightGray;
            }
            dgv_Edata.ReadOnly = false;
        }

        private void btn_addOK_Click(object sender, EventArgs e)
        {
            if (Year == "" || FNo == "" || CCNo == "")
            {
                MessageBox.Show("参数不全！");
            }
            else
            {
                DataTable r = GetElectricData.Budget(FNo, Year, CCNo);
                if (r.Rows.Count > 0)
                {
                    MessageBox.Show("预算表已存在！");
                }
                else
                {
                    for (int i=0;i<dgv_Edata .Rows .Count ;i++)
                    {
                        string str = string.Format(" insert into EBudget values ('{0}',{1},'{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})",
                            Convert.ToString(dgv_Edata[1, i].Value  ), Convert.ToInt16(dgv_Edata[0, i].Value), FNo, CCNo, Year,
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

        private void btn_UpdateOk_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

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


    }
}
