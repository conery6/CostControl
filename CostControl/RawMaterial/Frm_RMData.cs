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
    public partial class Frm_RMData : Form
    {
        string Eno = "";
        string FNo = "";
        string CCNo = "";
        string Year = "";
        string PNo = "";
        string Reporttype = "";
        int ReportMonth;
        int acMonth;


        public Frm_RMData(string Eno)
        {
            InitializeComponent();
            this.Eno = Eno;
        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetRMData.FNo(comB_Facility.Text);
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
            CCNo = GetRMData.CCNo(comB_CC.Text);
            comB_Product.Items.Clear();
            string sql = " select distinct PName from RMBudget, Product,CostCenter where CostCenter.CCNo =RMBudget.CCNo and Product.PNo =RMBudget.PNo and CCName='" + comB_CC.Text + "' ";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Product.Items.Add(temp.Rows[i]["PName"].ToString());
            }

        }

        private void comB_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year = comB_Year.Text;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (comB_Year.Text == "" || comB_Facility.Text == "" || comB_CC.Text == "" || comB_Month.Text == "")
            {
                MessageBox.Show("参数不全！");
            }
            else
            {
                for (int i = 0; i < dgv_rmdata.Columns.Count; i++)
                {
                    dgv_rmdata.Columns[i].ReadOnly = true;
                    dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
                DataTable r = new DataTable();
                r = GetRMData.MiddleBudget(FNo, CCNo, PNo, Year, ReportMonth);

                if (r.Rows.Count != 0)
                {
                    dgv_rmdata.DataSource = r;
                }
                acMonth = ReportMonth;

                dgv_rmdata.Columns[0].ReadOnly = true;
                dgv_rmdata.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
                dgv_rmdata.Columns[1].ReadOnly = true;
                dgv_rmdata.Columns[1].DefaultCellStyle.BackColor = Color.LightYellow;

                for (int i = 2; i <= acMonth + 1; i++)
                {
                    dgv_rmdata.Columns[i].ReadOnly = true;
                    dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }

            }
        }

        private void comB_RpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype = comB_RpType.Text;
        }

        private void Frm_RMData_Load(object sender, EventArgs e)
        {
            string sql = "select distinct Fname from Facility";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Facility.Items.Add(temp.Rows[i]["FName"].ToString());
            }

            dgv_rmdata.ReadOnly = true;
        }

        private void dgv_rmdata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int colm = dgv_rmdata.CurrentCell.ColumnIndex;
            int rowm = dgv_rmdata.CurrentCell.RowIndex;

            try
            {
                switch (rowm)
                {
                    case 1:
                        dgv_rmdata[colm, 0].Value = Convert.ToSingle(dgv_rmdata[colm, 1].Value) * Convert.ToSingle(dgv_rmdata[colm, 2].Value);
                        dgv_rmdata[colm, 4].Value = Convert.ToSingle(dgv_rmdata[colm, 3].Value) * 100 / Convert.ToSingle(dgv_rmdata[colm, 2].Value);
                        break;
                    case 2:
                        dgv_rmdata[colm, 0].Value = Convert.ToSingle(dgv_rmdata[colm, 1].Value) * Convert.ToSingle(dgv_rmdata[colm, 2].Value);
                        dgv_rmdata[colm, 4].Value = Convert.ToSingle(dgv_rmdata[colm, 3].Value) * 100 / Convert.ToSingle(dgv_rmdata[colm, 2].Value);
                        break;
                    case 3:
                        dgv_rmdata[colm, 4].Value = Convert.ToSingle(dgv_rmdata[colm, 3].Value) / Convert.ToSingle(dgv_rmdata[colm, 2].Value);
                        dgv_rmdata[colm, 0].Value = Convert.ToSingle(dgv_rmdata[colm, 1].Value) * Convert.ToSingle(dgv_rmdata[colm, 2].Value);
                        break;
                    case 4:
                        dgv_rmdata[colm, 2].Value = Convert.ToSingle(dgv_rmdata[colm, 3].Value) / Convert.ToSingle(dgv_rmdata[colm, 4].Value);
                        dgv_rmdata[colm, 0].Value = Convert.ToSingle(dgv_rmdata[colm, 1].Value) * Convert.ToSingle(dgv_rmdata[colm, 2].Value);
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private bool getPK()//获取四个主键
        {
            if (comB_Year.Text == "" || comB_Facility.Text == "" || comB_CC.Text == "" || comB_RpType.Text == "")
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
                    if (MessageBox.Show("是否确认删除本表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string str = "delete from RMPeriod where Period ='" + Reporttype + "' and CCNo ='" + CCNo + "' and PNo ='" + PNo + "' and Year =" + Year;
                        ODbcmd.ExecuteSQLNonquery(str);
                        MessageBox.Show("删除成功");
                        comB_Year.Text = "";
                        comB_RpType.Text = "";
                        comB_Month.Text = "";
                        dgv_rmdata.DataSource = null;
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
            for (int i = dgv_rmdata.Rows.Count; i < 0; i--)
            {
                dgv_rmdata.Rows.RemoveAt(i);
            }
            string str = "select Type,TypeName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from Tamplate where TableName = 'Rmbudget' ";
            DataTable dt = ODbcmd.SelectToDataTable(str);
            dgv_rmdata.DataSource = dt;
            for (int i = 2; i < dgv_rmdata.Columns.Count; i++)
            {
                for (int j = 0; j < dgv_rmdata.Rows.Count; j++)
                {
                    dgv_rmdata[i, j].Value = 0;
                }
            }

            dgv_rmdata.ReadOnly = false;
            int[] autoItemnum;
            dgv_rmdata.DefaultCellStyle.BackColor = Color.White;

            autoItemnum = new int[] { 0, 3 };
            for (int i = 0; i < autoItemnum.Length; i++)
            {
                dgv_rmdata.Rows[autoItemnum[i]].DefaultCellStyle.BackColor = Color.LightGray;
                dgv_rmdata.Rows[autoItemnum[i]].ReadOnly = true;
            }
            dgv_rmdata.Columns[0].ReadOnly = true;
            dgv_rmdata.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
            dgv_rmdata.Columns[1].ReadOnly = true;
            dgv_rmdata.Columns[1].DefaultCellStyle.BackColor = Color.LightYellow;


        }


        private void comB_Year_TextChanged(object sender, EventArgs e)
        {
            Year = comB_Year.Text;
        }


        private void Exceladd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "xls";
            //文件后缀列表   
            dlg.Filter = "Excel 97-2003 工作簿(*.xls)|*.xls|Excel 工作簿(*.xlsx)|*.xlsx";
            //默然路径是Document目录   
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径   
            string strFileName = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (strFileName.Trim() == "") return;
            DataTable dtControl = ExcelHelper.ExcelToDataTable(strFileName, 0, 1, 0, 0, 0);

            DataRow dr = dtControl.Rows[0];

            comB_Facility.Text = dr["工厂"].ToString();
            comB_CC.Text = dr["成本中心"].ToString();
            comB_Product.Text = dr["产品"].ToString();
            comB_Year.Text = dr["年份"].ToString();
            comB_RpType.Text = dr["报表类型"].ToString();
            FNo = GetRMData.FNo(comB_Facility.Text);
            CCNo = GetRMData.CCNo(comB_CC.Text);
            PNo = GetRMData.PNo(comB_Product.Text);
            Year = comB_Year.Text;
            Reporttype = comB_RpType.Text;
            DataTable r = ExcelHelper.ExcelToDataTable(strFileName, 3, 0, 0, 0, 0);
            dgv_rmdata.DataSource = r;
        }

        private void Excelout_Click(object sender, EventArgs e)
        {
            if (dgv_rmdata.DataSource == null)
            {
                MessageBox.Show("数据为空!");
                return;
            }
            if (getPK())
            {
                string[] header = { "工厂", "成本中心", "产品", "年份", "报表类型" };
                object[] cells = { comB_Facility.Text, comB_CC.Text, comB_Product.Text, int.Parse(comB_Year.Text), comB_RpType.Text };
                ExcelHelper excelHelp = new ExcelHelper();
                excelHelp.ShowSaveFileDialog();
                excelHelp.AppendHeader(header);
                excelHelp.AppendContent(cells);
                DataTable dt = (DataTable)dgv_rmdata.DataSource;
                excelHelp.AppendToExcel(dt, true);
                excelHelp.SaveToExcel();
            }
        }

        private void btn_SearchPeriod_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_rmdata.Columns.Count; i++)
            {
                dgv_rmdata.Columns[i].ReadOnly = true;
                dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
            }
            comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            if (getPK())
            {
                DataTable dt = new DataTable();
                dt = GetRMData.Period(FNo, CCNo, Year, PNo, Reporttype);
                dgv_rmdata.DataSource = dt;
            }

            switch (Reporttype)
            {
                case "T1": acMonth = 0; break;
                case "RF1": acMonth = 3; break;
                case "RF2": acMonth = 6; break;
                case "E3": acMonth = 9; break;
                case "Actual": acMonth = 12; break;
            }

            dgv_rmdata.Columns[0].ReadOnly = true;
            dgv_rmdata.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
            dgv_rmdata.Columns[1].ReadOnly = true;
            dgv_rmdata.Columns[1].DefaultCellStyle.BackColor = Color.LightYellow;

            for (int i = 2; i <= acMonth + 1; i++)
            {
                dgv_rmdata.Columns[i].ReadOnly = true;
                dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }


        }

        private void comB_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportMonth = Convert.ToInt32(comB_Month.Text);
        }

        private void btn_Change_Click(object sender, EventArgs e)
        {
            if (dgv_rmdata.Rows.Count > 0)
            {

                dgv_rmdata.ReadOnly = false;
                comB_Year.DropDownStyle = ComboBoxStyle.DropDown;
                //int[] autoItemnum;

                //autoItemnum = new int[] { 0, 3 };
                //for (int i = 0; i < autoItemnum.Length; i++)
                //{
                //    dgv_rmdata.Rows[autoItemnum[i]].DefaultCellStyle.BackColor = Color.LightGray;
                //    dgv_rmdata.Rows[autoItemnum[i]].ReadOnly = true;
                //}

                //dgv_rmdata.Columns[0].ReadOnly = true;
                //dgv_rmdata.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;
                //dgv_rmdata.Columns[1].ReadOnly = true;
                //dgv_rmdata.Columns[1].DefaultCellStyle.BackColor = Color.LightYellow;

                //for (int i =2; i <= acMonth+1; i++)
                //{
                //    dgv_rmdata.Columns[i].ReadOnly = true;
                //    dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                //}
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (getPK())
            {
                if (Reporttype == "Actual")
                {
                    MessageBox.Show("不可修改真实数据！");
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = GetRMData.Period(FNo, CCNo, Year, PNo, Reporttype);
                    if (dt.Rows.Count > 0)
                    {
                        if (MessageBox.Show("检测到数据已存在，是否更新数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string str = "delete from RMPeriod where Period ='" + Reporttype + "' and CCNo ='" + CCNo + "' and PNo ='" + PNo + "' and Year =" + Year;
                            ODbcmd.ExecuteSQLNonquery(str);

                            for (int i = 0; i < dgv_rmdata.Rows.Count; i++)
                            {
                                string str1 = string.Format("insert into RMPeriod  values ('{0}','{1}','{2}','{3}',{4},{5},'{6}',{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},'{19}','{20}')",
                                    Reporttype, FNo, PNo, CCNo, Year, dgv_rmdata[0, i].Value.ToString(), dgv_rmdata[1, i].Value.ToString(),
                                    dgv_rmdata[2, i].Value.ToString(), dgv_rmdata[3, i].Value.ToString(), dgv_rmdata[4, i].Value.ToString(),
                                    dgv_rmdata[5, i].Value.ToString(), dgv_rmdata[6, i].Value.ToString(), dgv_rmdata[7, i].Value.ToString(),
                                    dgv_rmdata[8, i].Value.ToString(), dgv_rmdata[9, i].Value.ToString(), dgv_rmdata[10, i].Value.ToString(),
                                    dgv_rmdata[11, i].Value.ToString(), dgv_rmdata[12, i].Value.ToString(), dgv_rmdata[13, i].Value.ToString(), DateTime.Now, Eno);
                                ODbcmd.ExecuteSQLNonquery(str1);
                            }
                        }
                        MessageBox.Show("数据修改成");
                        comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;

                        dgv_rmdata.ReadOnly = true;
                        dgv_rmdata.BackgroundColor = Color.White;
                    }
                    else
                    {
                        if (MessageBox.Show("是否将数据存为" + Year + Reporttype + "表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            for (int i = 0; i < dgv_rmdata.Rows.Count; i++)
                            {
                                string str1 = string.Format("insert into RMPeriod  values ('{0}','{1}','{2}','{3}',{4},{5},'{6}',{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},'{19}','{20}')",
                                    Reporttype, FNo, PNo, CCNo, Year, dgv_rmdata[0, i].Value.ToString(), dgv_rmdata[1, i].Value.ToString(),
                                    dgv_rmdata[2, i].Value.ToString(), dgv_rmdata[3, i].Value.ToString(), dgv_rmdata[4, i].Value.ToString(),
                                    dgv_rmdata[5, i].Value.ToString(), dgv_rmdata[6, i].Value.ToString(), dgv_rmdata[7, i].Value.ToString(),
                                    dgv_rmdata[8, i].Value.ToString(), dgv_rmdata[9, i].Value.ToString(), dgv_rmdata[10, i].Value.ToString(),
                                    dgv_rmdata[11, i].Value.ToString(), dgv_rmdata[12, i].Value.ToString(), dgv_rmdata[13, i].Value.ToString(), DateTime.Now, Eno);
                                ODbcmd.ExecuteSQLNonquery(str1);
                            }
                            MessageBox.Show("数据保存成功");
                        }
                        comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;

                        dgv_rmdata.ReadOnly = true;
                        dgv_rmdata.BackgroundColor = Color.White;

                    }

                }


            }
        }

        private void dgv_rmdata_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void comB_Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            PNo = GetRMData.PNo(comB_Product.Text);
            comB_Year.Items.Clear();
            string sql = " select distinct Year from RMBudget where CCNo='" + CCNo + "' and PNo ='" + PNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Year.Items.Add(temp.Rows[i]["Year"].ToString());
            }
        }

        private void dgv_rmdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
