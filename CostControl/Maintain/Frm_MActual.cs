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
    public partial class Frm_MActual : Form
    {
        public Frm_MActual(string s_FINorACE)
        {
            InitializeComponent();
            FINorACE = s_FINorACE;
        }

        public string FNo = "";
        public string FSNo = "";
        public string CCNo = "";
        public string Year = "";
        public List<int[]> flaglist = new List<int[]>();
        public string mode = "search";
        public string FINorACE;

        private void Btn_search_Click(object sender, EventArgs e)
        {
            if (getPK())
            {
                dgv_Mdata.Rows.Clear();
                DataTable a = new DataTable();
                if (FINorACE == "FIN")
                {
                    a = GetMaintainData.Actual_FIN(FNo, FSNo, Year, CCNo);
                }
                else
                {
                    a = GetMaintainData.Actual_ACE(FNo, FSNo, Year, CCNo);
                }

                for (int j = 0; j < a.Rows.Count; j++)
                {
                    dgv_Mdata.Rows.Add();
                    dgv_Mdata[0, j].Value = a.Rows[j]["EqName"].ToString();
                    dgv_Mdata[1, j].Value = a.Rows[j]["Type"].ToString();
                    for (int i = 2; i < dgv_Mdata.Columns.Count; i++)
                    {
                        dgv_Mdata[i, j].Value = a.Rows[j]["M" + (i - 1).ToString()].ToString();
                    }
                }
                if (dgv_Mdata.Rows.Count < 1)
                {
                    MessageBox.Show("没有数据！", "提示");
                }
            }
        }

        private void Frm_RMFIN_Load(object sender, EventArgs e)
        {
            string sql = "select distinct Fname from Facility";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Facility.Items.Add(temp.Rows[i]["FName"].ToString());
            }


            for (int i = 2; i < 14; i++)
            {
                dgv_Mdata.Columns[i].Width = 60;
            }
            dgv_Mdata.RowHeadersWidth = 20;
        }

        public bool getPK()
        {
            if (FNo == "" || CCNo == "" || FSNo == "" || Year == "" )
            {
                MessageBox.Show("出错！可能原因是选择不完整！");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetMaintainData.FNo(comB_Facility.Text);
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
            CCNo = GetMaintainData.CCNo(comB_CC.Text);
            if (mode == "search")
            {

                comB_FSystem.Items.Clear();
                string sql = " select distinct FSName from FacilitySystem, Equipment where FacilitySystem.FSNo =Equipment.FSNo and CCNo='" + CCNo + "'";
                DataTable temp = ODbcmd.SelectToDataTable(sql);
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    comB_FSystem.Items.Add(temp.Rows[i]["FSName"].ToString());
                }
            }
        }

        private void comB_FSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            FSNo = GetMaintainData.FSNo(comB_FSystem.Text);
            if (mode == "search")
            {


                comB_Year.Items.Clear();
                string sql = " select distinct Year from MaintianPeriod,Equipment where Equipment.EqNo = MaintianPeriod.EqNo and CCNo='" + CCNo + "' and Period ='A12' and FSNo ='" + FSNo + "'";
                DataTable temp = ODbcmd.SelectToDataTable(sql);
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    comB_Year.Items.Add(temp.Rows[i]["Year"].ToString());
                }

            }
        }

        private void comB_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year = comB_Year.Text;
        }

        private void comB_Year_TextChanged(object sender, EventArgs e)
        {
            Year = comB_Year.Text;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            dgv_Mdata.ReadOnly = false;
            //btn_UpdateOk.Visible = true;
            //btn_Cancel.Visible = true;
            mode = "update";
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string Tablename;
            if (FINorACE == "FIN")
            {
                Tablename = "MaintianFin";
            }
            else
            {
                Tablename = "MaintianActual";
            }

            for (int i = 0; i < dgv_Mdata.Rows.Count; i += 2)
            {
                string EqNo = GetMaintainData.EqNo(dgv_Mdata[0, i].Value.ToString());
                string str = "delete from "+Tablename +" where EqNo ='" + EqNo + "' and Year =" + Year;
                ODbcmd.ExecuteSQLNonquery(str);
            }
            
        }

        private void btn_newbudget_Click(object sender, EventArgs e)
        {
            mode = "add";
            //button1.Visible = true;
            //btn_AddOk.Visible = true;
            //btn_Cancel.Visible = true;
            comB_Year.DropDownStyle = ComboBoxStyle.DropDown;
            dgv_Mdata.Rows.Clear();
            comB_FSystem.Items.Clear();
            string sql = " select distinct FSName from FacilitySystem ";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_FSystem.Items.Add(temp.Rows[i]["FSName"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FNo == "" || CCNo == "" || FSNo == "" || Year == "")
            { MessageBox.Show("出错"); }
            else
            {

                dgv_Mdata.ReadOnly = false;
                dgv_Mdata.Columns[0].ReadOnly = true;
                dgv_Mdata.Columns[1].ReadOnly = true;
                DataTable b = new DataTable();
                b = GetMaintainData.newBudget(FNo, FSNo, CCNo);
                for (int j = 0; j < b.Rows.Count; j++)
                {
                    dgv_Mdata.Rows.Add();
                    dgv_Mdata[0, 2 * j].Value = b.Rows[j]["EqName"].ToString();
                    dgv_Mdata[1, 2 * j].Value = "spa";
                    dgv_Mdata.Rows.Add();
                    dgv_Mdata[0, 2 * j + 1].Value = b.Rows[j]["EqName"].ToString();
                    dgv_Mdata[1, 2 * j + 1].Value = "sub";

                }


            }
            //btn_AddOk.Visible = true;
        }


        private void btn_AddOk_Click(object sender, EventArgs e)
        {
            try
            {
                string Tablename;
                if (FINorACE == "FIN")
                {
                    Tablename = "MaintianFin";
                }
                else
                {
                    Tablename = "MaintianActual";
                }

                DataTable dt = new DataTable();
                dt = GetMaintainData.GetData(FNo, FSNo, Year, CCNo,"");
                if (dgv_Mdata.Rows.Count == 0 || dt.Rows.Count > 1)
                {
                    MessageBox.Show("未找到任何行或数据已存在！");
                }
                else
                {
                    for (int i = 0; i < dgv_Mdata.Rows.Count; i++)
                    {
                        string EqNo = GetMaintainData.EqNo(dgv_Mdata[0, i].Value.ToString());
                        string sql1 = string.Format("insert into {0} values ('{1}','{2}',{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15})",
                            Tablename ,
                            EqNo, dgv_Mdata[1, i].Value.ToString(),Year ,
                            Convert.ToSingle(dgv_Mdata[2, i].Value),
                            Convert.ToSingle(dgv_Mdata[3, i].Value),
                            Convert.ToSingle(dgv_Mdata[4, i].Value),
                            Convert.ToSingle(dgv_Mdata[5, i].Value),
                            Convert.ToSingle(dgv_Mdata[6, i].Value),
                            Convert.ToSingle(dgv_Mdata[7, i].Value),
                            Convert.ToSingle(dgv_Mdata[8, i].Value),
                            Convert.ToSingle(dgv_Mdata[9, i].Value),
                            Convert.ToSingle(dgv_Mdata[10, i].Value),
                            Convert.ToSingle(dgv_Mdata[11, i].Value),
                            Convert.ToSingle(dgv_Mdata[12, i].Value),
                            Convert.ToSingle(dgv_Mdata[13, i].Value));
                        ODbcmd.ExecuteSQLNonquery(sql1);
                    }
                    //btn_AddOk.Visible = false;
                    comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
                    flaglist.Clear();
                    mode = "search";
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_UpdateOk_Click(object sender, EventArgs e)
        {
            if (flaglist.Count != 0)
            {
                string Tablename;
                if (FINorACE == "FIN")
                {
                    Tablename = "MaintianFin";
                }
                else
                {
                    Tablename = "MaintianActual";
                }

                foreach (int[] a in flaglist)
                {
                    try
                    {
                        string EqNo = GetMaintainData.EqNo(dgv_Mdata[0, a[1]].Value.ToString());
                        string sql1 = string.Format(" update {0} set M{1}={2}"
                        + " where EqNo='{3}' and Type='{4}' and Year={5} ",
                        Tablename ,a[0], Convert.ToSingle(dgv_Mdata[a[0], a[1]].Value),
                        EqNo, dgv_Mdata[1, a[1]].Value.ToString(), Year);
                        ODbcmd.ExecuteSQLNonquery(sql1);
                    }
                    catch { }
                }
            }
            MessageBox.Show("修改成功");
            flaglist.Clear();
            //btn_UpdateOk.Visible = false;
            mode = "search";

        }

        private void dgv_Mdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Mdata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int colm = dgv_Mdata.CurrentCell.ColumnIndex;
            int rowm = dgv_Mdata.CurrentCell.RowIndex;
            int[] flag = new int[] { colm, rowm };
            flaglist.Add(flag);
            dgv_Mdata.CurrentCell.Style.BackColor = Color.LightPink;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //btn_AddOk.Visible = false;
            //btn_UpdateOk.Visible = false;
            //button1.Visible = false;
            flaglist.Clear();
            mode = "search";
            //btn_Cancel.Visible = false;
            comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btn_exceladd_Click(object sender, EventArgs e)
        {
            OpenFileDialog xlsDileDialog = new OpenFileDialog();
            xlsDileDialog.Filter = "xls文件|*.xlsx|所有文件|*.*";
            xlsDileDialog.FilterIndex = 1;

            if (xlsDileDialog.ShowDialog() == DialogResult.OK)
            {
                string sExcelFile = xlsDileDialog.FileName;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (getPK())
            {
                string[] header = { "工厂", "成本中心", "系统", "年份" };
                object[] cells = { comB_Facility.Text, comB_CC.Text, comB_FSystem.Text, int.Parse(comB_Year.Text) };
                ExcelHelper excelHelp = new ExcelHelper();
                if (excelHelp.ShowSaveFileDialog())
                {
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    DataTable dt = ExcelHelper.GridViewToDataTable(dgv_Mdata);
                    excelHelp.AppendToExcel(dt, true);
                    excelHelp.SaveToExcel();
                }
            }
        }
    }
}
