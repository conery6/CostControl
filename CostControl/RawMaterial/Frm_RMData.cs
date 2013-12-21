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
		public string Eno = "";
		public string FNo = "";
		public string PNo = "";
		public string Year = "";
		public string Reporttype;
		public string CCNo = "";
		public List<int[]> flaglist = new List<int[]>();
		public float[,] BasicData = new float[5, 13];
		public float[,] ChangedData = new float[5, 13];
		public string mode;
		DataTable dt1 = new DataTable();

		public Frm_RMData(String Eno)
		{
			InitializeComponent();
			this.Eno = Eno;
		}

		private void RMData_Load(object sender, EventArgs e)
		{
			string sql = "select distinct Fname from Facility";
			DataTable temp = ODbcmd.SelectToDataTable(sql);
			for (int i = 0; i < temp.Rows.Count; i++)
			{
				comB_Facility.Items.Add(temp.Rows[i]["FName"].ToString());
			}


			comB_RpType.Text = "T1";

			dgvinitial();
			mode = "search";
			btn_Save.Visible = false;
			btn_update.Visible = false;
			btn_delete.Visible = false;
			Btn_search.Visible = true;
			btn_Cancel.Visible = false;
			btn_Exceladd.Visible = true;
			btn_newbudget.Visible = true;
		}


		private void dgvinitial()
		{
			for (int i = dgv_rmdata.Rows.Count; i > 0; i--)
			{
				dgv_rmdata.Rows.RemoveAt(0);
			}
			dgv_rmdata.Rows.Add("PurchaseCost", null, null, null, null, null, null, null, null, null, null, null, null);
			dgv_rmdata.Rows.Add("PurchasePrice", null, null, null, null, null, null, null, null, null, null, null, null);
			dgv_rmdata.Rows.Add("PurchaseQuantity", null, null, null, null, null, null, null, null, null, null, null, null);
			dgv_rmdata.Rows.Add("SalesQuantity", null, null, null, null, null, null, null, null, null, null, null, null);
			dgv_rmdata.Rows.Add("Availability", null, null, null, null, null, null, null, null, null, null, null, null);
			dgv_rmdata.RowHeadersVisible = false;
			for (int i = 1; i < 13; i++)
			{
				dgv_rmdata.Columns[i].Width = 60;
				dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
			}
			for (int j = 0; j < 5; j++)
			{
				dgv_rmdata.Rows[j].Height = 60;
				dgv_rmdata.Rows[j].ReadOnly = true;
			}
			dgv_rmdata.Rows[0].DefaultCellStyle.Format = "N2";
			dgv_rmdata.Rows[1].DefaultCellStyle.Format = "N2";
			dgv_rmdata.Rows[2].DefaultCellStyle.Format = "N0";
			dgv_rmdata.Rows[3].DefaultCellStyle.Format = "N0";
			dgv_rmdata.Rows[4].DefaultCellStyle.Format = "N2";

		}


		private bool getPK()//获取四个主键，做了个封装
		{
			if (FNo == "" || CCNo == "" || PNo == "" || Year == "" || Reporttype == "")
			{
				MessageBox.Show("出错！可能原因是选择不完整！");
				return false;
			}
			else
			{
				return true;
			}
		}

		private void Btn_Search_Click(object sender, EventArgs e)
		{
			if (getPK())
			{
				DataTable r = new DataTable();
				mode = "search";

				switch (comB_RpType.Text)
				{
					case "T1":
						r = GetRMData.Budget(CCNo, PNo, Year);
						break;
					case "RF1":
						r = GetRMData.MiddleBudget(CCNo, PNo, Year, 3);
						break;
					case "RF2":
						r = GetRMData.MiddleBudget(CCNo, PNo, Year, 6);
						break;
					case "E3":
						r = GetRMData.MiddleBudget(CCNo, PNo, Year, 9);
						break;
					case "R":
						r = GetRMData.Actual(CCNo, PNo, Year);
						break;
				}
				dt1 = r;
				if (r.Rows.Count > 0)
				{
					for (int i = 0; i < 5; i++)
					{
						for (int j = 0; j < 5; j++)
						{
							if (r.Rows[j][0].ToString() == (i + 1).ToString())
							{
								for (int k = 0; k < 12; k++)
								{
									dgv_rmdata[k + 1, i].Value = r.Rows[j]["M" + (k + 1).ToString()];
								}
							}
						}
					}
					changecolor();
				}
				else
				{ MessageBox.Show("数据为空！"); }

				BasicData = GetRMData.DTto2DFloat(r);
				dgv_rmdata.Rows[0].DefaultCellStyle.Format = "N2";
				dgv_rmdata.Rows[1].DefaultCellStyle.Format = "N2";
				dgv_rmdata.Rows[2].DefaultCellStyle.Format = "N0";
				dgv_rmdata.Rows[3].DefaultCellStyle.Format = "N0";
				dgv_rmdata.Rows[4].DefaultCellStyle.Format = "N2";

				btn_update.Visible = true;
				btn_delete.Visible = true;

			}
		}


		private void dgv_rmdata_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (getPK())
			{
				int colm = dgv_rmdata.CurrentCell.ColumnIndex;
				int rowm = dgv_rmdata.CurrentCell.RowIndex;
				try
				{


					switch (rowm)
					{
						case 1:
							dgv_rmdata[colm, 0].Value = Convert.ToSingle(dgv_rmdata[colm, 1].Value) * Convert.ToSingle(dgv_rmdata[colm, 2].Value);
							dgv_rmdata[colm, 4].Value = Convert.ToSingle(dgv_rmdata[colm, 3].Value) / Convert.ToSingle(dgv_rmdata[colm, 2].Value);
							break;
						case 2:
							dgv_rmdata[colm, 0].Value = Convert.ToSingle(dgv_rmdata[colm, 1].Value) * Convert.ToSingle(dgv_rmdata[colm, 2].Value);
							dgv_rmdata[colm, 4].Value = Convert.ToSingle(dgv_rmdata[colm, 3].Value) / Convert.ToSingle(dgv_rmdata[colm, 2].Value);
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

					if (mode == "update")
					{
						int[] flag = new int[] { colm, rowm };

						if (Convert.ToSingle(dgv_rmdata[colm, rowm].Value) != BasicData[rowm, colm])
						{
							flaglist.Add(flag);
							dgv_rmdata.CurrentCell.Style.BackColor = Color.LightPink;
						}
					}

				}
				catch { }

			}
		}

		private void btn_Excel_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.DefaultExt = "xls";
			//文件后缀列表   
			dlg.Filter = "EXCEL文件(*.xls)|*.xls";
			//默然路径是Document目录   
			dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			//打开保存对话框   
			if (dlg.ShowDialog() == DialogResult.Cancel) return;
			//返回文件路径   
			string strFileName = dlg.FileName;
			//验证strFileName是否为空或值无效   
			if (strFileName.Trim() == "") return;
            //DataTable dt = ExcelControl.GetDataFromExcel(strFileName);
            //dgv_rmdata.DataSource = dt;
            //changecolor();
            //dgv_rmdata.Rows[0].DefaultCellStyle.Format = "N2";
            //dgv_rmdata.Rows[1].DefaultCellStyle.Format = "N2";
            //dgv_rmdata.Rows[2].DefaultCellStyle.Format = "N0";
            //dgv_rmdata.Rows[3].DefaultCellStyle.Format = "N0";
            //dgv_rmdata.Rows[4].DefaultCellStyle.Format = "N2";

            //btn_update.Visible = true;
            //btn_delete.Visible = true;
			
		}

		private void btn_update_Click(object sender, EventArgs e)
		{
			mode = "update";
			btn_Cancel.Visible = true;
			switch (comB_RpType.Text)
			{

				case "T1":
					dgv_rmdata.Rows[0].ReadOnly = true;
					dgv_rmdata.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
					dgv_rmdata.Rows[1].ReadOnly = false;
					dgv_rmdata.Rows[2].ReadOnly = false;
					dgv_rmdata.Rows[3].ReadOnly = true;
					dgv_rmdata.Rows[3].DefaultCellStyle.BackColor = Color.Gray;
					dgv_rmdata.Rows[4].ReadOnly = false;
					dgv_rmdata.Columns[0].DefaultCellStyle.BackColor = Color.White;
					for (int i = 1; i < 13; i++)
					{
						dgv_rmdata.Columns[i].ReadOnly = false;
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
					}
					break;
				case "RF1":
					dgv_rmdata.Rows[0].ReadOnly = true;
					dgv_rmdata.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
					dgv_rmdata.Rows[1].ReadOnly = false;
					dgv_rmdata.Rows[2].ReadOnly = false;
					dgv_rmdata.Rows[3].ReadOnly = true;
					dgv_rmdata.Rows[3].DefaultCellStyle.BackColor = Color.Gray;
					dgv_rmdata.Rows[4].ReadOnly = false;
					dgv_rmdata.Columns[0].DefaultCellStyle.BackColor = Color.White;
					for (int i = 1; i < 4; i++)
					{
						dgv_rmdata.Columns[i].ReadOnly = true;
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.Yellow;
					}
					for (int i = 4; i < 13; i++)
					{
						dgv_rmdata.Columns[i].ReadOnly = false;
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
					}
					break;
				case "RF2":
					dgv_rmdata.Rows[0].ReadOnly = true;
					dgv_rmdata.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
					dgv_rmdata.Rows[1].ReadOnly = false;
					dgv_rmdata.Rows[2].ReadOnly = false;
					dgv_rmdata.Rows[3].ReadOnly = true;
					dgv_rmdata.Rows[3].DefaultCellStyle.BackColor = Color.Gray;
					dgv_rmdata.Rows[4].ReadOnly = false;
					dgv_rmdata.Columns[0].DefaultCellStyle.BackColor = Color.White;
					for (int i = 1; i < 7; i++)
					{
						dgv_rmdata.Columns[i].ReadOnly = true;
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.Yellow;
					}
					for (int i = 7; i < 13; i++)
					{
						dgv_rmdata.Columns[i].ReadOnly = false;
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
					}
					break;

				case "E1":
					dgv_rmdata.Rows[0].ReadOnly = true;
					dgv_rmdata.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
					dgv_rmdata.Rows[1].ReadOnly = false;
					dgv_rmdata.Rows[2].ReadOnly = false;
					dgv_rmdata.Rows[3].ReadOnly = true;
					dgv_rmdata.Rows[3].DefaultCellStyle.BackColor = Color.Gray;
					dgv_rmdata.Rows[4].ReadOnly = false;
					dgv_rmdata.Columns[0].DefaultCellStyle.BackColor = Color.White;
					for (int i = 1; i < 10; i++)
					{
						dgv_rmdata.Columns[i].ReadOnly = true;
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.Yellow;
					}
					for (int i = 10; i < 13; i++)
					{
						dgv_rmdata.Columns[i].ReadOnly = false;
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
					}
					break;
				case "R":
					dgv_rmdata.Rows[0].ReadOnly = true;
					dgv_rmdata.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
					dgv_rmdata.Rows[1].ReadOnly = false;
					dgv_rmdata.Rows[2].ReadOnly = false;
					dgv_rmdata.Rows[3].ReadOnly = false;
					dgv_rmdata.Rows[4].ReadOnly = true;
					dgv_rmdata.Rows[4].DefaultCellStyle.BackColor = Color.Gray;
					dgv_rmdata.Columns[0].DefaultCellStyle.BackColor = Color.White;
					for (int i = 1; i < 13; i++)
					{
						dgv_rmdata.Columns[i].ReadOnly = false;
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
					}
					break;
			}
			btn_Save.Visible = true;
			btn_delete.Visible = false;
			btn_newbudget.Visible = false;
			btn_Exceladd.Visible = false;
			btn_update.Enabled = false;
			Btn_search.Visible = false;
		}

		private void changecolor()
		{
			switch (comB_RpType.Text)
			{

				case "T1":
					for (int i = 1; i < 13; i++)
					{
						dgv_rmdata.Columns[i].ReadOnly = false;
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
					}
					break;
				case "RF1":
					for (int i = 1; i < 4; i++)
					{
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.Yellow;
					}
					for (int i = 4; i < 13; i++)
					{
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
					}
					break;
				case "RF2":
					for (int i = 1; i < 7; i++)
					{
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.Yellow;
					}
					for (int i = 7; i < 13; i++)
					{
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
					}
					break;

				case "E3":
					for (int i = 1; i < 10; i++)
					{
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.Yellow;
					}
					for (int i = 10; i < 13; i++)
					{
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
					}
					break;
				case "R":
					for (int i = 1; i < 13; i++)
					{
						dgv_rmdata.Columns[i].DefaultCellStyle.BackColor = Color.White;
					}
					break;
			}
		}


		private void btn_Save_Click(object sender, EventArgs e)
		{
			if (mode == "update")
			{
				if (flaglist.Count != 0)
				{
					foreach (int[] a in flaglist)
					{
						if (Convert.ToSingle(dgv_rmdata[a[0], a[1]].Value) != BasicData[a[1], a[0]])//值确实改变了
						{
							try
							{
								if (Reporttype != "R")
								{
									string sql = string.Format(" insert into RMBudgetEdit values('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},{9},'{10}','{11}') ",
										FNo, PNo, CCNo, Year, a[0], BasicData[0, a[0]], BasicData[1, a[0]], BasicData[2, a[0]], BasicData[3, a[0]],
										BasicData[4, a[0]], System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Eno);
									ODbcmd.ExecuteSQLNonquery(sql);
									for (int i = 0; i < 5; i++)
									{
										string sql1 = string.Format(" update RMBudget set M{0}={1}"
										+ " where FNo='{2}' and PNO='{3}' and CCNo='{4}' and Year={5} and Type='{6}' ",
										a[0], Convert.ToSingle(dgv_rmdata[a[0], i].Value),
										FNo, PNo, CCNo, Year, i + 1);
										ODbcmd.ExecuteSQLNonquery(sql1);
									}
								}
								else
								{
									for (int i = 0; i < 5; i++)
									{
										string sql1 = string.Format(" update RMActual set M{0}={1}"
										+ " where FNo='{2}' and PNO='{3}' and CCNo='{4}' and Year={5} and Type='{6}' ",
										a[0], Convert.ToSingle(dgv_rmdata[a[0], i].Value),
										FNo, PNo, CCNo, Year, i + 1);
										ODbcmd.ExecuteSQLNonquery(sql1);
									}
								}

							}
							catch { }
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
					DataTable r = GetRMData.Budget(CCNo, PNo, Year);
					if (r.Rows.Count > 0)
					{
						MessageBox.Show("系统监测到已有数据，不能添加！");
					}
					else
					{
						for (int i = 0; i < 5; i++)
						{

							string sql1 = string.Format(" insert into RMBudget values ('{0}','{1}','{2}',{3},{4},'{5}',{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},'{18}','{19}')",
							FNo, PNo, CCNo, Year, i + 1, dgv_rmdata[0, i].Value,
							Convert.ToSingle(dgv_rmdata[1, i].Value),
							Convert.ToSingle(dgv_rmdata[2, i].Value),
							Convert.ToSingle(dgv_rmdata[3, i].Value),
							Convert.ToSingle(dgv_rmdata[4, i].Value),
							Convert.ToSingle(dgv_rmdata[5, i].Value),
							Convert.ToSingle(dgv_rmdata[6, i].Value),
							Convert.ToSingle(dgv_rmdata[7, i].Value),
							Convert.ToSingle(dgv_rmdata[8, i].Value),
							Convert.ToSingle(dgv_rmdata[9, i].Value),
							Convert.ToSingle(dgv_rmdata[10, i].Value),
							Convert.ToSingle(dgv_rmdata[11, i].Value),
							Convert.ToSingle(dgv_rmdata[12, i].Value),
							System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Eno);
							ODbcmd.ExecuteSQLNonquery(sql1);
						}
						MessageBox.Show("添加成功！");

					}
					btn_newbudget.Enabled = true;
				}

			}
			comB_Year.DropDownStyle = ComboBoxStyle.DropDown;
			btn_Save.Visible = false;
			btn_newbudget.Visible = true;
			btn_delete.Visible = true;
			btn_update.Visible = true;
			btn_Exceladd.Visible = true;
			dgv_rmdata.ReadOnly = true;
			comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
			Btn_search.Visible = true;
			dgv_rmdata.DefaultCellStyle.BackColor = Color.White;
		}

		private void btn_Add_Click(object sender, EventArgs e)
		{
			mode = "add";
			comB_Year.DropDownStyle = ComboBoxStyle.DropDown;

			dgvinitial();
			for (int j = 1; j < 13; j++)
			{
				dgv_rmdata.Columns[j].ReadOnly = false;
				dgv_rmdata.Columns[j].DefaultCellStyle.BackColor = Color.White;
			}
			btn_Save.Visible = true;
			btn_update.Visible = false;
			btn_delete.Visible = false;

			comB_Product.Items.Clear();
			string sql = "select distinct Pname from Product";
			DataTable temp = ODbcmd.SelectToDataTable(sql);
			for (int i = 0; i < temp.Rows.Count; i++)
			{
				comB_Product.Items.Add(temp.Rows[i]["PName"].ToString());
			}
			btn_delete.Visible = false;
			btn_Exceladd.Visible = false;
			btn_update.Visible = false;
			btn_Save.Visible = true;
			btn_newbudget.Enabled = false;
			Btn_search.Visible = false;
			btn_Cancel.Visible = true;

		}

		private void btn_del_Click(object sender, EventArgs e)
		{
			mode = "del";
			if (getPK())
			{
				try
				{
					string sql;
					if (MessageBox.Show("是否确认删除本表？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						switch (Reporttype)
						{
							case "T1":
								sql = string.Format("delete from RMBudget where FNo ='{0}' and PNo ='{1}' and CCNo='{2}' and Year={3}",
									FNo, PNo, CCNo, Year);
								ODbcmd.ExecuteSQLNonquery(sql);
								MessageBox.Show("删除成功");
								comB_CC.Text = "";
								comB_Product.Text = "";
								comB_Year.Text = "";
								break;
							case "R":
								sql = string.Format("delete from RMActual where FNo ='{0}' and PNo ='{1}' and CCNo='{2}' and Year={3}",
								FNo, PNo, CCNo, Year);
								ODbcmd.ExecuteSQLNonquery(sql);
								MessageBox.Show("删除成功");
								comB_CC.Text = "";
								comB_Product.Text = "";
								comB_Year.Text = "";
								break;
							default:
								MessageBox.Show("只能删除T1及R表");
								break;
						}
					}

				}
				catch { }

			}

		}


		#region CTRL+V 粘帖板实现
		private void dgv_rmdata_KeyDown(object sender, KeyEventArgs e)//Ctrl+V 进行数据黏贴
		{
			if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.V) && (dgv_rmdata.CurrentCell != null))
			{
				int insertRowIndex = dgv_rmdata.CurrentCell.RowIndex;
				int insertColumnIndex = dgv_rmdata.CurrentCell.ColumnIndex;
				// 获取剪切板的内容，并按行分割
				string pasteText = Clipboard.GetText();
				if (string.IsNullOrEmpty(pasteText))
					return;
				pasteText = pasteText.Replace("\r", "");
				pasteText = pasteText.Replace(' ', ' ');
				pasteText.TrimEnd(new char[] { ' ' });
				string[] lines = pasteText.Split('\n');
				for (int j = 0; j < issmeller(dgv_rmdata.Rows.Count - insertRowIndex, lines.Count()); j++)
				{
					// 按 Tab 分割数据
					string[] vals = lines[j].Split('\t');
					DataGridViewRow row = dgv_rmdata.Rows[j];
					for (int i = insertColumnIndex; i < issmeller(row.Cells.Count, vals.Count() + insertColumnIndex); i++)
					{
						row.Cells[i].Value = vals[i - insertColumnIndex];
					}
					// DataGridView的行索引+1
				}
			}
		}

		private int issmeller(int a, int b)
		{
			if (a > b)
			{ return b; }
			else
			{ return a; }
		}
		#endregion

		#region COMB框选择
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
			if (mode == "search" || mode == "update")
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

		}

		private void comB_Product_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (mode == "search" || mode == "update")
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
		}

		private void comB_report_SelectedIndexChanged(object sender, EventArgs e)
		{
			Reporttype = comB_RpType.Text;
		}

		private void comB_Year_SelectedIndexChanged(object sender, EventArgs e)
		{
			Year = comB_Year.Text;
		}
		#endregion

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("是否确认不保存操作？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				btn_newbudget.Enabled = true;
				btn_update.Enabled = true;
				comB_Year.DropDownStyle = ComboBoxStyle.DropDownList;
				flaglist.Clear();
				RMData_Load(sender, e);

			}
		}

		private void btn_ExcelOut_Click(object sender, EventArgs e)
		{
			if (dgv_rmdata[1, 1].Value == null)
			{
				MessageBox.Show("请先进行查询!");
				return;
			}
			ExcelControl a = new ExcelControl();
			a.SaveAsExcel(dgv_rmdata);
			//a.DataTableToExcel(comB_CC.Text + "_" + comB_Year.Text + "_" + Reporttype, dt1);
		}

		private void dgv_rmdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

	}
}
