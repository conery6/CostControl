using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CostControl.Management
{
    public partial class Frm_MGData : Form
    {
        public Frm_MGData()
        {
            InitializeComponent();
        }
        public string Eno = "";

        public string FNo;
        public string FSNo;
        public string CCNo;
        public string Year;
        public string Reporttype;
        int ReportMonth;
        int acMonth;
        public List<int[]> flaglist = new List<int[]>();
        public float[,] BasicData = new float[5, 13];
        public float[,] ChangedData = new float[5, 13];
        public string mode;
        DataTable dt1 = new DataTable();
        string currentType = "";

        private void Frm_MGData_Load(object sender, EventArgs e)
        {


            string sql = "select distinct Fname from Facility";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Facility.Items.Add(temp.Rows[i]["FName"].ToString());
            }

            for (int i = 1; i < 13; i++)
            {
                dgv_MGData.Columns[i].Width = 60;
            }
            dgv_MGData.RowHeadersWidth = 20;

        }


        private bool getPK()//获取四个主键，做了个封装
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

        private void btn_search_Click(object sender, EventArgs e)
        {
           
            comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            if (getPK())
            {
                for (int i = 0; i < dgv_MGData.Columns.Count; i++)
                {
                    dgv_MGData.Columns[i].ReadOnly = true;
                    dgv_MGData.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                DataTable dt = new DataTable();
                if (Reporttype == "Actual")
                {
                    dt = GetMGData.Period(FNo, CCNo, Year, "A12");
                }
                else
                {
                    dt = GetMGData.Period(FNo, CCNo, Year, Reporttype);
                }
                dgv_MGData.DataSource = dt;
            }

            switch (Reporttype)
            {
                case "T1": acMonth = 0; break;
                case "RF1": acMonth = 3; break;
                case "RF2": acMonth = 6; break;
                case "E3": acMonth = 9; break;
                case "Actual": acMonth = 12; break;
            }

            dgv_MGData.Columns[0].ReadOnly = true;
            dgv_MGData.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;

            for (int i = 1; i <= acMonth; i++)
            {
                dgv_MGData.Columns[i].ReadOnly = true;
                dgv_MGData.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
            currentType = Reporttype;
        }

        private void btn_exceladd_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.DefaultExt = "xls";
            ////文件后缀列表   
            //dlg.Filter = "Excel 97-2003 工作簿(*.xls)|*.xls|Excel 工作簿(*.xlsx)|*.xlsx";
            ////默然路径是Document目录   
            //dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ////打开保存对话框   
            //if (dlg.ShowDialog() == DialogResult.Cancel) return;
            ////返回文件路径   
            //string strFileName = dlg.FileName;
            ////验证strFileName是否为空或值无效   
            //if (strFileName.Trim() == "") return;
            //DataTable dtControl = ExcelHelper.ExcelToDataTable(strFileName, 0, 1, 0, 0, 0);

            //DataRow dr = dtControl.Rows[0];

            //comB_Facility.Text = dr["工厂"].ToString();
            //comB_CC.Text = dr["成本中心"].ToString();

            //comB_Year.Text = dr["年份"].ToString();
            //comB_RpType.Text = dr["报表类型"].ToString();
            //FNo = GetMGData.FNo(comB_Facility.Text);
            //CCNo = GetMGData.CCNo(comB_CC.Text);
            //Year = comB_Year.Text;
            //Reporttype = comB_RpType.Text;
            //DataTable r = ExcelHelper.ExcelToDataTable(strFileName, 3, 0, 0, 0, 0);
            //dgv_MGData.DataSource = r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv_MGData.DataSource == null)
            {
                MessageBox.Show("数据为空!");
                return;
            }
            if (getPK())
            {
                string[] header = { "工厂", "成本中心", "年份", "报表类型" };
                object[] cells = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year.Text), currentType };
                ExcelHelper excelHelp = new ExcelHelper();
                if (excelHelp.ShowSaveFileDialog())
                {
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    DataTable dt = (DataTable)dgv_MGData.DataSource;
                    excelHelp.AppendToExcel(dt, true);
                    excelHelp.SaveToExcel();
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            //if (dgv_MGData.Rows.Count > 0)
            //{

            //    dgv_MGData.ReadOnly = false;
            //    comB_Year.DropDownStyle = ComboBoxStyle.DropDown;

            //}

        }



        private void btn_delete_Click(object sender, EventArgs e)
        {
            //if (getPK())
            //{
            //    try
            //    {
            //        if (MessageBox.Show("是否确认删除本表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            string str = "delete from MGPeriod where Period ='" + Reporttype + "' and CCNo ='" + CCNo +  "' and Year =" + Year;
            //            ODbcmd.ExecuteSQLNonquery(str);
            //            MessageBox.Show("删除成功");
            //            comB_Year.Text = "";
            //            comB_RpType.Text = "";
            //            comB_Month.Text = "";
            //            dgv_MGData.DataSource = null;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}

        }

        private void btn_newbudget_Click(object sender, EventArgs e)
        {
            //comB_Year.DropDownStyle = ComboBoxStyle.DropDown;
            //for (int i = dgv_MGData.Rows.Count; i < 0; i--)
            //{
            //    dgv_MGData.Rows.RemoveAt(i);
            //}
            //string str = "select Type,TypeName as IName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from Tamplate where TableName = 'MGbudget' ";
            //DataTable dt = ODbcmd.SelectToDataTable(str);
            //dgv_MGData.DataSource = dt;
            //for (int i = 2; i < dgv_MGData.Columns.Count; i++)
            //{
            //    for (int j = 0; j < dgv_MGData.Rows.Count; j++)
            //    {
            //        dgv_MGData[i, j].Value = 0;
            //    }
            //}

            //dgv_MGData.ReadOnly = false;
        }

        private void comB_CC_SelectedIndexChanged(object sender, EventArgs e)
        {
            CCNo = GetMGData.CCNo(comB_CC.Text);
            comB_Year.Items.Clear();
            string sql = " select distinct Year from MGPeriod where CCNo='" + CCNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Year.Items.Add(temp.Rows[i]["Year"].ToString());
            }
        }

        private void comB_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            FNo = GetMGData.FNo(comB_Facility.Text);
            comB_CC.Items.Clear();
            string sql = "select CCName from CostCenter where  FNo ='" + FNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_CC.Items.Add(temp.Rows[i]["CCName"].ToString());
            }

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //if (getPK())
            //{
            //    if (Reporttype == "Actual")
            //    {
            //        MessageBox.Show("不可修改真实数据！");
            //    }
            //    else
            //    {
            //        DataTable dt = new DataTable();
            //        dt = GetMGData.Period(FNo,CCNo, Year, Reporttype);
            //        if (dt.Rows.Count > 0)
            //        {
            //            if (MessageBox.Show("检测到数据已存在，是否更新数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //            {
            //                string str = "delete from MGPeriod where Period ='" + Reporttype + "' and CCNo ='" + CCNo + "' and Year =" + Year;
            //                ODbcmd.ExecuteSQLNonquery(str);

            //                for (int i = 0; i < dgv_MGData.Rows.Count; i++)
            //                {
            //                    string str1 = string.Format("insert into MGPeriod  values ('{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17})",
            //                         Reporttype, dgv_MGData[1, i].Value.ToString(), FNo, CCNo, Year, dgv_MGData[0, i].Value.ToString(),
            //                         dgv_MGData[2, i].Value.ToString() == "" ? "0" : dgv_MGData[2, i].Value.ToString(), dgv_MGData[3, i].Value.ToString() == "" ? "0" : dgv_MGData[3, i].Value.ToString(), dgv_MGData[4, i].Value.ToString() == "" ? "0" : dgv_MGData[4, i].Value.ToString(),
            //                         dgv_MGData[5, i].Value.ToString() == "" ? "0" : dgv_MGData[5, i].Value.ToString(), dgv_MGData[6, i].Value.ToString() == "" ? "0" : dgv_MGData[6, i].Value.ToString(), dgv_MGData[7, i].Value.ToString() == "" ? "0" : dgv_MGData[7, i].Value.ToString(),
            //                         dgv_MGData[8, i].Value.ToString() == "" ? "0" : dgv_MGData[8, i].Value.ToString(), dgv_MGData[9, i].Value.ToString() == "" ? "0" : dgv_MGData[9, i].Value.ToString(), dgv_MGData[10, i].Value.ToString() == "" ? "0" : dgv_MGData[10, i].Value.ToString(),
            //                         dgv_MGData[11, i].Value.ToString() == "" ? "0" : dgv_MGData[11, i].Value.ToString(), dgv_MGData[12, i].Value.ToString() == "" ? "0" : dgv_MGData[12, i].Value.ToString(), dgv_MGData[13, i].Value.ToString() == "" ? "0" : dgv_MGData[13, i].Value.ToString());
            //                    ODbcmd.ExecuteSQLNonquery(str1);
            //                }
            //            }
            //            MessageBox.Show("数据修改成");
            //            comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;

            //            dgv_MGData.ReadOnly = true;
            //            dgv_MGData.BackgroundColor = Color.White;
            //        }
            //        else
            //        {
            //            if (MessageBox.Show("是否将数据存为" + Year + Reporttype + "表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //            {
            //                for (int i = 0; i < dgv_MGData.Rows.Count; i++)
            //                {
            //                    string str1 = string.Format("insert into MGPeriod  values ('{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17})",
            //                          Reporttype, dgv_MGData[1, i].Value.ToString(), FNo, CCNo, Year, dgv_MGData[0, i].Value.ToString(),
            //                          dgv_MGData[2, i].Value.ToString() == "" ? "0" : dgv_MGData[2, i].Value.ToString(), dgv_MGData[3, i].Value.ToString() == "" ? "0" : dgv_MGData[3, i].Value.ToString(), dgv_MGData[4, i].Value.ToString() == "" ? "0" : dgv_MGData[4, i].Value.ToString(),
            //                          dgv_MGData[5, i].Value.ToString() == "" ? "0" : dgv_MGData[5, i].Value.ToString(), dgv_MGData[6, i].Value.ToString() == "" ? "0" : dgv_MGData[6, i].Value.ToString(), dgv_MGData[7, i].Value.ToString() == "" ? "0" : dgv_MGData[7, i].Value.ToString(),
            //                          dgv_MGData[8, i].Value.ToString() == "" ? "0" : dgv_MGData[8, i].Value.ToString(), dgv_MGData[9, i].Value.ToString() == "" ? "0" : dgv_MGData[9, i].Value.ToString(), dgv_MGData[10, i].Value.ToString() == "" ? "0" : dgv_MGData[10, i].Value.ToString(),
            //                          dgv_MGData[11, i].Value.ToString() == "" ? "0" : dgv_MGData[11, i].Value.ToString(), dgv_MGData[12, i].Value.ToString() == "" ? "0" : dgv_MGData[12, i].Value.ToString(), dgv_MGData[13, i].Value.ToString() == "" ? "0" : dgv_MGData[13, i].Value.ToString());
            //                    ODbcmd.ExecuteSQLNonquery(str1);
            //                }
            //                MessageBox.Show("数据保存成功");
            //            }
            //            comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;

            //            dgv_MGData.ReadOnly = true;
            //            dgv_MGData.BackgroundColor = Color.White;

            //        }

            //    }


            //}
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("是否确认不保存操作？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    btn_newbudget.Enabled = true;
            //    btn_update.Enabled = true;
            //    comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            //    flaglist.Clear();
            //    btn_search_Click(sender, e);

            //}
        }

        private void comB_RpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reporttype = comB_RpType.Text;
        }

        private void comB_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year = comB_Year.Text;
        }

        private void btn_Search_Click_1(object sender, EventArgs e)
        {
            if (comB_Year.Text == "" || comB_Facility.Text == "" || comB_CC.Text == "" || comB_Month.Text == "")
            {
                MessageBox.Show("参数不全！");
            }
            else
            {
                for (int i = 0; i < dgv_MGData.Columns.Count; i++)
                {
                    dgv_MGData.Columns[i].ReadOnly = true;
                    dgv_MGData.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
                DataTable r = new DataTable();
                switch (comB_Month.Text)
                {
                    case "3":
                        r = GetMGData.Period(FNo, CCNo, Year, "RF1");
                        break;
                    case "6":
                        r = GetMGData.Period(FNo, CCNo, Year, "RF2");
                        break;
                    case "9":
                        r = GetMGData.Period(FNo, CCNo, Year, "E3");
                        break;
                    default:
                        r = GetMGData.Period(FNo, CCNo, Year, "A" + ReportMonth);
                        break;
                }

                dgv_MGData.DataSource = r;

                acMonth = ReportMonth;

                dgv_MGData.Columns[0].ReadOnly = true;
                dgv_MGData.Columns[0].DefaultCellStyle.BackColor = Color.LightYellow;

                for (int i = 1; i <= acMonth; i++)
                {
                    dgv_MGData.Columns[i].ReadOnly = true;
                    dgv_MGData.Columns[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                }
                currentType = "A" + ReportMonth;
            }
        }

        private void comB_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportMonth = Convert.ToInt32(comB_Month.Text);
        }
    }
}
