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
    public partial class Frm_MGActual : Form
    {
        public string Eno = "";

        public string FNo;
        public string FSNo;
        public string CCNo;
        public string Year;

        public List<int[]> flaglist = new List<int[]>();
        public float[,] BasicData = new float[5, 13];
        public float[,] ChangedData = new float[5, 13];
        public string mode;
        
        public Frm_MGActual()
        {
            InitializeComponent();
        }

        private void Frm_MGActual_Load(object sender, EventArgs e)
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

        private void comB_Year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comB_CC_SelectedIndexChanged(object sender, EventArgs e)
        {
            CCNo = GetMGData.CCNo(comB_CC.Text);
            comB_Year.Items.Clear();
            string sql = " select distinct Year from MGBudget where CCNo='" + CCNo + "'";
            DataTable temp = ODbcmd.SelectToDataTable(sql);
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                comB_Year.Items.Add(temp.Rows[i]["Year"].ToString());
            }
        }

        private bool getPK()
        {
            if (FNo == "" || CCNo == "" || Year == "")
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
            if (getPK())
            {
                DataTable r = new DataTable();
                mode = "search";

                FNo = GetMGData.FNo(comB_Facility.Text);
                CCNo = GetMGData.CCNo(comB_CC.Text);
                Year = comB_Year.Text;

               r = GetMGData.Actual(FNo, CCNo, Year);

                if (r.Rows.Count > 0)
                {

                    dgv_MGData.DataSource = r;
                }
                else
                { MessageBox.Show("数据为空！"); }

                BasicData = GetMGData.DTto2DFloat(r);

                btn_update.Visible = true;
                btn_delete.Visible = true;

            }
        }

        private void btn_exceladd_Click(object sender, EventArgs e)
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

            comB_Year.Text = dr["年份"].ToString();
            FNo = GetMGData.FNo(comB_Facility.Text);
            CCNo = GetMGData.CCNo(comB_CC.Text);
            Year = comB_Year.Text;
            DataTable r = ExcelHelper.ExcelToDataTable(strFileName, 3, 0, 0, 0, 0);
            dgv_MGData.DataSource = r;
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
                string[] header = { "工厂", "成本中心","年份"};
                object[] cells = { comB_Facility.Text, comB_CC.Text, int.Parse(comB_Year.Text)};
                ExcelHelper excelHelp = new ExcelHelper();
                excelHelp.ShowSaveFileDialog();
                excelHelp.AppendHeader(header);
                excelHelp.AppendContent(cells);
                DataTable dt = (DataTable)dgv_MGData.DataSource;
                excelHelp.AppendToExcel(dt, true);
                excelHelp.SaveToExcel();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            mode = "update";
            dgv_MGData.ReadOnly = false;
            btn_Save.Visible = true;
            btn_Cancel.Visible = true;
            dgv_MGData.Columns[0].ReadOnly = true;
            dgv_MGData.Columns[0].DefaultCellStyle.BackColor = Color.Gray;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            mode = "delete";
            if (getPK())
            {
                try
                {
                    string sql;
                    if (MessageBox.Show("是否确认删除本表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                                sql = string.Format("delete from MGActual where FNo ='{0}' and CCNo='{1}' and Year={2}",
                                FNo, CCNo, Year);
                                ODbcmd.ExecuteSQLNonquery(sql);
                                MessageBox.Show("删除成功");
                                comB_CC.Text = "";
                                comB_Year.Text = "";
                                dgv_MGData.DataSource = null;
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        //private void dgvinitial()
        //{
        //    for (int i = dgv_MGData.Rows.Count; i > 0; i--)
        //    {
        //        dgv_MGData.Rows.RemoveAt(0);
        //    }
        //    dgv_MGData.Rows.Add("Entertainment", null, null, null, null, null, null, null, null, null, null, null, null);
        //    dgv_MGData.Rows.Add("IT/IS", null, null, null, null, null, null, null, null, null, null, null, null);
        //    dgv_MGData.Rows.Add("Office", null, null, null, null, null, null, null, null, null, null, null, null);
        //    dgv_MGData.Rows.Add("Other Operation Cost", null, null, null, null, null, null, null, null, null, null, null, null);
        //    dgv_MGData.Rows.Add("Professional service", null, null, null, null, null, null, null, null, null, null, null, null);
        //    dgv_MGData.Rows.Add("Rental", null, null, null, null, null, null, null, null, null, null, null, null);
        //    dgv_MGData.Rows.Add("Safety", null, null, null, null, null, null, null, null, null, null, null, null);
        //    dgv_MGData.Rows.Add("Telecom-Data/Voice", null, null, null, null, null, null, null, null, null, null, null, null);
        //    dgv_MGData.Rows.Add("Transportation", null, null, null, null, null, null, null, null, null, null, null, null);
        //    dgv_MGData.Rows.Add("Travel", null, null, null, null, null, null, null, null, null, null, null, null);
        //    dgv_MGData.RowHeadersVisible = false;
        //    for (int i = 1; i < 13; i++)
        //    {
        //        dgv_MGData.Columns[i].Width = 60;
        //        dgv_MGData.Columns[i].DefaultCellStyle.BackColor = Color.White;
        //    }
        //    for (int j = 0; j < 10; j++)
        //    {
        //        dgv_MGData.Rows[j].Height = 60;
        //        dgv_MGData.Rows[j].ReadOnly = true;
        //    }
        //}

        private void btn_newactual_Click(object sender, EventArgs e)
        {
            mode = "add";
            comB_Year.DropDownStyle = ComboBoxStyle.DropDown;
            for (int i = dgv_MGData.Rows.Count; i < 0; i--)
            {
                dgv_MGData.Rows.RemoveAt(i);
            }
            string str = "select TypeName as IName,M1,M2,M3,M4,M5,M6,M7,M8,M9,M10,M11,M12 from Tamplate where TableName = 'MGActual' ";
            DataTable dt = ODbcmd.SelectToDataTable(str);
            dgv_MGData.DataSource = dt;
            for (int i = 1; i < dgv_MGData.Columns.Count; i++)
            {
                for (int j = 0; j < dgv_MGData.Rows.Count; j++)
                {
                    dgv_MGData[i, j].Value = 0;
                }
            }
           
            dgv_MGData.ReadOnly = false;
            dgv_MGData.Columns[0].ReadOnly = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (mode == "update")
            {
                if (flaglist.Count != 0)
                {
                    foreach (int[] a in flaglist)
                    {
                        if (Convert.ToSingle(dgv_MGData[a[0], a[1]].Value) != BasicData[a[1], a[0]])//值确实改变了
                        {
                            try
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    string sql1 = string.Format(" update MGActual set M{0}={1}"
                                            + " where FNo='{2}'  and CCNo='{3}' and Year={4} and Type={5} ",
                                            a[0], Convert.ToSingle(dgv_MGData[a[0], i].Value),
                                            FNo, CCNo, Year, i + 1);
                                    ODbcmd.ExecuteSQLNonquery(sql1);
                                }
                            }
                            catch (System.Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                    }
                    MessageBox.Show("修改成功");
                    flaglist.Clear();

                }
                btn_update.Enabled = true;
           
            }

            if (mode == "add")
            {
                if (getPK())
                {
                    DataTable r = GetMGData.Budget(FNo, CCNo, Year);
                    if (r.Rows.Count > 0)
                    {
                        MessageBox.Show("系统监测到已有数据，不能添加！");
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {

                            string sql1 = string.Format(" insert into MGActual values ('{0}','{1}','{2}',{3},{4},'{5}',{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},'{18}')",
                            dgv_MGData[0, i].Value, FNo, CCNo, Year, i + 1,
                            Convert.ToSingle(dgv_MGData[1, i].Value),
                            Convert.ToSingle(dgv_MGData[2, i].Value),
                            Convert.ToSingle(dgv_MGData[3, i].Value),
                            Convert.ToSingle(dgv_MGData[4, i].Value),
                            Convert.ToSingle(dgv_MGData[5, i].Value),
                            Convert.ToSingle(dgv_MGData[6, i].Value),
                            Convert.ToSingle(dgv_MGData[7, i].Value),
                            Convert.ToSingle(dgv_MGData[8, i].Value),
                            Convert.ToSingle(dgv_MGData[9, i].Value),
                            Convert.ToSingle(dgv_MGData[10, i].Value),
                            Convert.ToSingle(dgv_MGData[11, i].Value),
                            Convert.ToSingle(dgv_MGData[12, i].Value),
                            System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Eno);
                            ODbcmd.ExecuteSQLNonquery(sql1);
                        }
                        MessageBox.Show("添加成功！");

                    }
                    btn_newactual.Enabled = true;
                }

            }
            comB_Year.DropDownStyle = ComboBoxStyle.DropDown;
            btn_Save.Visible = false;
            btn_Cancel.Visible = false;
            btn_newactual.Visible = true;
            btn_delete.Visible = true;
            btn_update.Visible = true;
            
            btn_exceladd.Visible = true;
            dgv_MGData.ReadOnly = true;
            dgv_MGData.DefaultCellStyle.BackColor = Color.White;
            comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            btn_search.Visible = true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认不保存操作？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btn_newactual.Enabled = true;
                btn_update.Enabled = true;
                comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
                flaglist.Clear();
                btn_search_Click(sender, e);

            }
        }

        private void dgv_MGData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (getPK())
            {
                int colm = dgv_MGData.CurrentCell.ColumnIndex;
                int rowm = dgv_MGData.CurrentCell.RowIndex;
                    if (mode == "update")
                    {
                        int[] flag = new int[] { colm, rowm };

                        if (Convert.ToSingle(dgv_MGData[colm, rowm].Value) != BasicData[rowm, colm])
                        {
                            flaglist.Add(flag);
                            dgv_MGData.CurrentCell.Style.BackColor = Color.LightPink;
                        }
                    }
            }
        }
    }
}
