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
    public partial class Frm_EActual : Form
    {
        string FNo;
        string CCNo;
        string Year;
        //public List<int[]> flaglist = new List<int[]>();


        public Frm_EActual()
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
            string sql = "select distinct Year from EPeriod where CCNo ='" + CCNo + "'";
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
            if (comB_Facility.Text == "" || comB_CC.Text == "" || comB_Year.Text == "")
            {
                MessageBox.Show("参数不全！");
            }
            else
            {
                for (int i = 0; i < dgv_Edata.Columns.Count; i++)
                {
                    dgv_Edata.Columns[i].ReadOnly = true;
                    dgv_Edata.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
                DataTable r = new DataTable();
                r = GetElectricData.Actual(FNo, Year, CCNo);

                if (r.Rows.Count != 0)
                {
                    dgv_Edata.DataSource = r;
                }

            }
        }

        private void comB_RpType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Frm_EData_Load(object sender, EventArgs e)
        {

        }

        private void dgv_Edata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //int colm = dgv_Edata.CurrentCell.ColumnIndex;
            //int rowm = dgv_Edata.CurrentCell.RowIndex;

            //try
            //{
            //    if (FNo == "WX_F001")
            //    {

            //        dgv_Edata[colm, 8].Value = Convert.ToSingle(dgv_Edata[colm, 1].Value) * Convert.ToSingle(dgv_Edata[colm, 4].Value);
            //        dgv_Edata[colm, 9].Value = Convert.ToSingle(dgv_Edata[colm, 2].Value) * Convert.ToSingle(dgv_Edata[colm, 5].Value);
            //        dgv_Edata[colm, 10].Value = Convert.ToSingle(dgv_Edata[colm, 3].Value) * Convert.ToSingle(dgv_Edata[colm, 6].Value);

            //        dgv_Edata[colm, 14].Value = Convert.ToSingle(dgv_Edata[colm, 8].Value) + Convert.ToSingle(dgv_Edata[colm, 9].Value) + Convert.ToSingle(dgv_Edata[colm, 10].Value);
            //        dgv_Edata[colm, 18].Value = Convert.ToSingle(dgv_Edata[colm, 8].Value) * Convert.ToSingle(dgv_Edata[colm, 15].Value);
            //        dgv_Edata[colm, 20].Value = Convert.ToSingle(dgv_Edata[colm, 9].Value) * Convert.ToSingle(dgv_Edata[colm, 16].Value);
            //        dgv_Edata[colm, 22].Value = Convert.ToSingle(dgv_Edata[colm, 10].Value) * Convert.ToSingle(dgv_Edata[colm, 15].Value);

            //        dgv_Edata[colm, 23].Value = Convert.ToSingle(dgv_Edata[colm, 17].Value) + Convert.ToSingle(dgv_Edata[colm, 18].Value) + Convert.ToSingle(dgv_Edata[colm, 19].Value) +
            //             Convert.ToSingle(dgv_Edata[colm, 20].Value) + Convert.ToSingle(dgv_Edata[colm, 21].Value) + Convert.ToSingle(dgv_Edata[colm, 22].Value);
            //    }
            //    else
            //    {
            //        dgv_Edata[colm, 1].Value = Convert.ToSingle(dgv_Edata[colm, 5].Value) + Convert.ToSingle(dgv_Edata[colm, 75].Value);
            //        dgv_Edata[colm, 2].Value = Convert.ToSingle(dgv_Edata[colm, 6].Value) + Convert.ToSingle(dgv_Edata[colm, 76].Value);
            //        dgv_Edata[colm, 3].Value = Convert.ToSingle(dgv_Edata[colm, 7].Value) + Convert.ToSingle(dgv_Edata[colm, 77].Value);
            //        dgv_Edata[colm, 12].Value = Convert.ToSingle(dgv_Edata[colm, 16].Value) * Convert.ToSingle(dgv_Edata[colm, 20].Value) / 100
            //            + Convert.ToSingle(dgv_Edata[colm, 17].Value) * Convert.ToSingle(dgv_Edata[colm, 21].Value) / 100
            //            + Convert.ToSingle(dgv_Edata[colm, 18].Value) * Convert.ToSingle(dgv_Edata[colm, 22].Value) / 100
            //            + Convert.ToSingle(dgv_Edata[colm, 19].Value) * Convert.ToSingle(dgv_Edata[colm, 23].Value) / 100;
            //        dgv_Edata[colm, 27].Value = Convert.ToSingle(dgv_Edata[colm, 20].Value) * Convert.ToSingle(dgv_Edata[colm, 60].Value)/500;
            //        dgv_Edata[colm, 30].Value = Convert.ToSingle(dgv_Edata[colm, 21].Value) * Convert.ToSingle(dgv_Edata[colm, 60].Value) / 500;
            //        dgv_Edata[colm, 33].Value = Convert.ToSingle(dgv_Edata[colm, 22].Value) * Convert.ToSingle(dgv_Edata[colm, 60].Value) / 500;
            //        dgv_Edata[colm, 36].Value = Convert.ToSingle(dgv_Edata[colm, 23].Value) * Convert.ToSingle(dgv_Edata[colm, 60].Value) / 500;
            //        dgv_Edata[colm, 41].Value = Convert.ToSingle(dgv_Edata[colm, 29].Value) + Convert.ToSingle(dgv_Edata[colm, 32].Value) + Convert.ToSingle(dgv_Edata[colm, 35].Value) + Convert.ToSingle(dgv_Edata[colm, 38].Value);
            //        dgv_Edata[colm, 44].Value = Convert.ToSingle(dgv_Edata[colm, 54].Value) + Convert.ToSingle(dgv_Edata[colm, 55].Value) + Convert.ToSingle(dgv_Edata[colm, 58].Value);
            //        try { dgv_Edata[colm, 49].Value = Convert.ToSingle(dgv_Edata[colm, 50].Value) / Convert.ToSingle(dgv_Edata[colm, 65].Value); } catch { }
            //        dgv_Edata[colm, 57].Value = Convert.ToSingle(dgv_Edata[colm, 55].Value) - Convert.ToSingle(dgv_Edata[colm, 56].Value);

            //        dgv_Edata[colm, 4].Value = -(Convert.ToSingle(dgv_Edata[colm, 6].Value) * Convert.ToSingle(dgv_Edata[colm, 12].Value) + Convert.ToSingle(dgv_Edata[colm, 9].Value)) * Convert.ToSingle(dgv_Edata[colm, 11].Value);
            //        dgv_Edata[colm, 8].Value = Convert.ToSingle(dgv_Edata[colm, 12].Value) * Convert.ToSingle(dgv_Edata[colm, 13].Value);
            //        try { dgv_Edata[colm, 28].Value = Convert.ToSingle(dgv_Edata[colm, 29].Value)*100 / Convert.ToSingle(dgv_Edata[colm, 27].Value);} catch { }
            //        try { dgv_Edata[colm, 31].Value = Convert.ToSingle(dgv_Edata[colm, 32].Value) * 100 / Convert.ToSingle(dgv_Edata[colm, 30].Value);} catch { }
            //        try { dgv_Edata[colm, 34].Value = Convert.ToSingle(dgv_Edata[colm, 35].Value) * 100 / Convert.ToSingle(dgv_Edata[colm, 33].Value);} catch { }
            //        try { dgv_Edata[colm, 37].Value = Convert.ToSingle(dgv_Edata[colm, 38].Value) * 100 / Convert.ToSingle(dgv_Edata[colm, 36].Value);} catch { }
            //        try { dgv_Edata[colm, 39].Value = Convert.ToSingle(dgv_Edata[colm, 6].Value) / (Convert.ToSingle(dgv_Edata[colm, 41].Value) * Convert.ToSingle(dgv_Edata[colm, 40].Value) + Convert.ToSingle(dgv_Edata[colm, 62].Value));} catch { }
            //        dgv_Edata[colm, 51].Value = Convert.ToSingle(dgv_Edata[colm, 43].Value) + Convert.ToSingle(dgv_Edata[colm, 41].Value) - Convert.ToSingle(dgv_Edata[colm, 44].Value);
            //        dgv_Edata[colm, 63].Value = Convert.ToSingle(dgv_Edata[colm, 65].Value) - Convert.ToSingle(dgv_Edata[colm, 44].Value);

            //        dgv_Edata[colm, 0].Value = Convert.ToSingle(dgv_Edata[colm, 4].Value) + Convert.ToSingle(dgv_Edata[colm, 74].Value);
            //        dgv_Edata[colm, 42].Value = Convert.ToSingle(dgv_Edata[colm, 44].Value) + Convert.ToSingle(dgv_Edata[colm, 51].Value);
            //        dgv_Edata[colm, 48].Value = Convert.ToSingle(dgv_Edata[colm, 39].Value) * Convert.ToSingle(dgv_Edata[colm, 12].Value);
            //        dgv_Edata[colm, 64].Value = Convert.ToSingle(dgv_Edata[colm, 62].Value) - Convert.ToSingle(dgv_Edata[colm, 63].Value);
            //        try { dgv_Edata[colm, 66].Value = Convert.ToSingle(dgv_Edata[colm, 44].Value) * 100 / (Convert.ToSingle(dgv_Edata[colm, 44].Value) + Convert.ToSingle(dgv_Edata[colm, 51].Value));} catch { }
            //        try { dgv_Edata[colm, 67].Value = Convert.ToSingle(dgv_Edata[colm, 63].Value) * 100 / Convert.ToSingle(dgv_Edata[colm, 62].Value);} catch { }
            //        try { dgv_Edata[colm, 68].Value = (-Convert.ToSingle(dgv_Edata[colm, 4].Value) + Convert.ToSingle(dgv_Edata[colm, 43].Value) * Convert.ToSingle(dgv_Edata[colm, 46].Value)) / Convert.ToSingle(dgv_Edata[colm, 65].Value);} catch { }
            //        try { dgv_Edata[colm, 69].Value = -Convert.ToSingle(dgv_Edata[colm, 4].Value) / (Convert.ToSingle(dgv_Edata[colm, 41].Value)*Convert.ToSingle(dgv_Edata[colm, 40].Value)+Convert.ToSingle(dgv_Edata[colm, 62].Value));} catch { }
            //        try { dgv_Edata[colm, 73].Value = (Convert.ToSingle(dgv_Edata[colm, 62].Value) + (Convert.ToSingle(dgv_Edata[colm, 41].Value)+Convert.ToSingle(dgv_Edata[colm, 43].Value))*Convert.ToSingle(dgv_Edata[colm, 40].Value))*Convert.ToSingle(dgv_Edata[colm, 39].Value)/Convert.ToSingle(dgv_Edata[colm, 65].Value);} catch { }

            //        dgv_Edata[colm, 47].Value = Convert.ToSingle(dgv_Edata[colm, 48].Value) + Convert.ToSingle(dgv_Edata[colm, 49].Value);
            //        dgv_Edata[colm, 70].Value = Convert.ToSingle(dgv_Edata[colm, 64].Value) * Convert.ToSingle(dgv_Edata[colm, 39].Value) * Convert.ToSingle(dgv_Edata[colm, 12].Value);
            //        try { dgv_Edata[colm, 52].Value = (Convert.ToSingle(dgv_Edata[colm, 44].Value) - Convert.ToSingle(dgv_Edata[colm, 45].Value)) * (Convert.ToSingle(dgv_Edata[colm, 46].Value) - Convert.ToSingle(dgv_Edata[colm, 47].Value)) / Convert.ToSingle(dgv_Edata[colm, 46].Value); }
            //        catch { }
            //        dgv_Edata[colm, 53].Value = Convert.ToSingle(dgv_Edata[colm, 51].Value) + Convert.ToSingle(dgv_Edata[colm, 52].Value);
            //        dgv_Edata[colm, 71].Value = Convert.ToSingle(dgv_Edata[colm, 53].Value) * Convert.ToSingle(dgv_Edata[colm, 40].Value) * Convert.ToSingle(dgv_Edata[colm, 39].Value) * Convert.ToSingle(dgv_Edata[colm,12].Value);
            //        dgv_Edata[colm, 72].Value = Convert.ToSingle(dgv_Edata[colm, 70].Value) + Convert.ToSingle(dgv_Edata[colm, 71].Value);

            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    //MessageBox.Show(ex.ToString());
            //}
        }

        private bool getPK()//获取四个主键
        {
            if (comB_Facility.Text == "" || comB_CC.Text == "" || comB_Year.Text == "" )
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
            //if (getPK())
            //{
            //    try
            //    {
            //        if (MessageBox.Show("是否确认删除本表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            string str = "delete from EActual where  CCNo ='" + CCNo + "' and Year =" + Year;
            //            ODbcmd.ExecuteSQLNonquery(str);
            //            MessageBox.Show("删除成功");
            //            comB_Year.Text = "";
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //comB_Year.DropDownStyle = ComboBoxStyle.DropDown;
            //for (int i = dgv_Edata.Rows.Count; i <0 ; i--)
            //{
            //    dgv_Edata.Rows.RemoveAt(i);
            //}
            //string str = "select Itemnum ,Item,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from Tamplate where TableName = 'Ebudget' and CCNo = '" + CCNo + "'";
            //DataTable dt = ODbcmd.SelectToDataTable (str );
            //dgv_Edata .DataSource =dt ;
            //for (int i =2;i<dgv_Edata .Columns .Count ;i++)
            //{
            //    for (int j=0;j <dgv_Edata .Rows .Count ;j++)
            //    {
            //        dgv_Edata[i, j].Value = 0;
            //    }
            //}

            //int[] autoItemnum;
            //if (FNo == "WX_F001")
            //{
            //    autoItemnum = new int[] { 0, 8, 9, 10, 11, 12, 13, 14, 18, 20, 22, 23, 24, 25, 26, 27, 28, 29 };
            //}
            //else
            //{
            //    autoItemnum = new int[] { 0, 1, 2, 3, 4, 8, 12, 27, 28, 30, 31, 33, 34, 36, 37, 39, 41, 42, 44, 47, 48, 49, 51, 52, 53, 57, 63, 64, 66, 67, 68, 69, 70, 71, 72, 73 };
            //}
            //for (int i = 0; i < autoItemnum.Length; i++)
            //{
            //    dgv_Edata.Rows[autoItemnum[i]].DefaultCellStyle.BackColor = Color.LightGray;
            //}
            //dgv_Edata.ReadOnly = false;
        }

        private void comB_Year_TextChanged(object sender, EventArgs e)
        {
            Year = comB_Year.Text;
        }

        private void Exceladd_Click(object sender, EventArgs e)
        {
            //OpenFileDialog xlsDileDialog = new OpenFileDialog();
            //xlsDileDialog.Filter = "xls文件|*.xlsx|所有文件|*.*";
            //xlsDileDialog.FilterIndex = 1;

            //if (xlsDileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string sExcelFile = xlsDileDialog.FileName;

            //}
        }

        private void Excelout_Click(object sender, EventArgs e)
        {
            if (dgv_Edata.DataSource == null)
            {
                MessageBox.Show("数据为空!");
                return;
            }
            if (getPK())
            {
                string[] header = { "工厂", "成本中心", "年份" };
                object[] cells = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year.Text) };
                ExcelHelper excelHelp = new ExcelHelper();
                if (excelHelp.ShowSaveFileDialog())
                {
                    excelHelp.AppendHeader(header);
                    excelHelp.AppendContent(cells);
                    DataTable dt = (DataTable)dgv_Edata.DataSource;
                    excelHelp.AppendToExcel(dt, true);
                    excelHelp.SaveToExcel();
                }
            }
        }

        private void btn_SearchPeriod_Click(object sender, EventArgs e)
        {
            
            comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            if (getPK())
            {
                for (int i = 0; i < dgv_Edata.Columns.Count; i++)
                {
                    dgv_Edata.Columns[i].ReadOnly = true;
                    dgv_Edata.Columns[i].DefaultCellStyle.BackColor = Color.White;
                }
                DataTable dt = new DataTable();
                dt = GetElectricData.Period(FNo, Year, CCNo, "A12");
                dgv_Edata.DataSource = dt;
            }
            


        }


        private void btn_Change_Click(object sender, EventArgs e)
        {
            //if (dgv_Edata.Rows.Count > 0)
            //{

            //    dgv_Edata.ReadOnly = false;
            //    dgv_Edata.Columns[0].ReadOnly = true;
            //    comB_Year.DropDownStyle = ComboBoxStyle.DropDown;
            //    int[] autoItemnum;
            //    if (FNo == "WX_F001")
            //    {
            //         autoItemnum = new int [] { 0, 8, 9, 10, 11, 12, 13, 14, 18, 20, 22, 23, 24, 25, 26, 27, 28, 29 };
            //    }
            //    else
            //    {
            //        autoItemnum =  new int [] {0,1,2,3,4,8,12,27,28,30,31,33,34,36,37,39,41,42,44,47,48,49,51,52,53,57,63,64,66,67,68,69,70,71,72,73 };
            //    }

            //    for (int i = 0; i < autoItemnum.Length; i++)
            //    {
            //        dgv_Edata.Rows[autoItemnum[i]].ReadOnly = true;
            //        dgv_Edata.Rows[autoItemnum[i]].DefaultCellStyle.BackColor = Color.LightGray;
            //    }

            //}
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //if (getPK())
            //{
            //    DataTable dt = new DataTable();
            //    dt = GetElectricData.Actual(FNo, Year, CCNo);
            //    if (dt.Rows.Count > 0)
            //    {
            //        if (MessageBox.Show("检测到数据已存在，是否更新数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            string str = "delete from EActual where  CCNo ='" + CCNo + "' and Year =" + Year;
            //            ODbcmd.ExecuteSQLNonquery(str);

            //            for (int i = 0; i < dgv_Edata.Rows.Count; i++)
            //            {
            //                string str1 = string.Format("insert into EActual  values ({0},'{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})",
            //                    dgv_Edata[0, i].Value.ToString(), dgv_Edata[1, i].Value.ToString(), FNo, CCNo, Year,
            //                    dgv_Edata[2, i].Value.ToString(), dgv_Edata[3, i].Value.ToString(), dgv_Edata[4, i].Value.ToString(),
            //                    dgv_Edata[5, i].Value.ToString(), dgv_Edata[6, i].Value.ToString(), dgv_Edata[7, i].Value.ToString(),
            //                    dgv_Edata[8, i].Value.ToString(), dgv_Edata[9, i].Value.ToString(), dgv_Edata[10, i].Value.ToString(),
            //                    dgv_Edata[11, i].Value.ToString(), dgv_Edata[12, i].Value.ToString(), dgv_Edata[13, i].Value.ToString());
            //                ODbcmd.ExecuteSQLNonquery(str1);
            //            }
            //        }
            //        MessageBox.Show("数据修改成");
            //        comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;

            //        dgv_Edata.ReadOnly = true;
            //        dgv_Edata.BackgroundColor = Color.White;
            //    }
            //    else
            //    {
            //        if (MessageBox.Show("是否将数据存为" + Year  + "Actual表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            for (int i = 0; i < dgv_Edata.Rows.Count; i++)
            //            {
            //                string str1 = string.Format("insert into EActual  values ({0},'{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})",
            //                    dgv_Edata[0, i].Value.ToString(), dgv_Edata[1, i].Value.ToString(), FNo, CCNo, Year,
            //                    dgv_Edata[2, i].Value.ToString(), dgv_Edata[3, i].Value.ToString(), dgv_Edata[4, i].Value.ToString(),
            //                    dgv_Edata[5, i].Value.ToString(), dgv_Edata[6, i].Value.ToString(), dgv_Edata[7, i].Value.ToString(),
            //                    dgv_Edata[8, i].Value.ToString(), dgv_Edata[9, i].Value.ToString(), dgv_Edata[10, i].Value.ToString(),
            //                    dgv_Edata[11, i].Value.ToString(), dgv_Edata[12, i].Value.ToString(), dgv_Edata[13, i].Value.ToString());
            //                ODbcmd.ExecuteSQLNonquery(str1);
            //            }
            //            MessageBox.Show("数据保存成功");
            //        }
            //        comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;

            //        dgv_Edata.ReadOnly = true;
            //        dgv_Edata.BackgroundColor = Color.White;

            //    }

            //}
        }

        private void dgv_Edata_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


    }
}
