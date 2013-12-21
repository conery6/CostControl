using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace CostControl
{
    class ExcelControl
    {
        public void SaveAsExcel(DataGridView dgv, string otherInfo = "")
        {
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默认文件后缀   
            dlg.DefaultExt = "xls";
            //文件后缀列表   
            dlg.Filter = "EXCEL文件(*.xls)|*.xls";
            //默然路径是Document目录   
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.FileName = "Sheet1.xls";
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == "")
            { return; }
            //定义表格内数据的行数和列数   
            int rowscount = dgv.Rows.Count;
            int colscount = dgv.Columns.Count;
            //行数必须大于0   
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0   
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536   
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于255   
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它   
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            Excel.Application appExcel = null;
            Excel.Workbook workBook = null;
            Excel.Worksheet workSheet = null;
            try
            {
                //申明对象   
                appExcel = new Excel.Application();
                workBook = appExcel.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                workSheet = (Excel.Worksheet)workBook.ActiveSheet;
                Excel.Range range;
                //设置EXCEL不可见   
                appExcel.Visible = false;
                string[] infoArray = otherInfo.Split('|');
                for (int i = 0; i < infoArray.Length; i++)
                {
                    appExcel.Cells[1, i + 1] = infoArray[i].Split(':')[0];
                    appExcel.Cells[2, i + 1] = infoArray[i].Split(':')[1];
                    range = (Excel.Range)workSheet.Cells[1, i + 1];
                    range.Interior.ColorIndex = 15;
                    range.Font.Bold = true;
                }
                //向Excel中写入表格的表头   
                int displayColumnsCount = 1;
                for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                    {
                        appExcel.Cells[4, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
                        range = (Excel.Range)workSheet.Cells[4, displayColumnsCount];

                        range.Interior.ColorIndex = 15;
                        range.Font.Bold = true;
                        displayColumnsCount++;
                    }
                }
                //向Excel中逐行逐列写入表格中的数据   
                for (int row = 0; row <= dgv.RowCount - 1; row++)
                {
                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dgv.Columns[col].Visible == true)
                        {
                            try
                            {
                                workSheet.Cells.EntireColumn.AutoFit();
                                appExcel.Cells[row + 5, displayColumnsCount] = dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                range = (Excel.Range)workSheet.Cells[row + 5, displayColumnsCount];
                                range.NumberFormat = "0.00";
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }

                        }
                    }
                }
                //保存文件   
                workBook.SaveAs(fileNameString, Excel.XlFileFormat.xlWorkbookNormal, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用   
                if (workBook != null) workBook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (appExcel.Workbooks != null) appExcel.Workbooks.Close();
                if (appExcel != null) appExcel.Quit();

                workSheet = null;
                workBook = null;
                appExcel = null;
            }
            MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static DataSet GetDataFromExcel(string strFileName)
        {
            DataSet ds = new DataSet();
            Excel.Application appExcel = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            appExcel.Visible = false;
            workBook = appExcel.Workbooks.Open(strFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            workSheet = (Excel.Worksheet)workBook.Sheets[1];
            int iRowCount = workSheet.UsedRange.Cells.Rows.Count;
            int iColumnAccount = workSheet.UsedRange.Cells.Columns.Count;
            DataTable dtControl = new DataTable();
            DataRow drControl = dtControl.NewRow();
            for (int i = 0; i < 5; i++)
            {
                dtControl.Columns.Add(((Excel.Range)workSheet.Cells[1, i + 1]).Text.ToString());
                drControl[i] = ((Excel.Range)workSheet.Cells[2, i + 1]).Text.ToString();
            }
            dtControl.Rows.Add(drControl);
            DataTable dt = new DataTable();
            try
            {

                for (int i = 1; i <= iColumnAccount; i++)
                {
                    dt.Columns.Add(((Excel.Range)workSheet.Cells[4, i]).Text.ToString());
                }

                for (int row = 5; row <= iRowCount; row++)
                {
                    DataRow dr = dt.NewRow();
                    for (int col = 0; col <= iColumnAccount - 1; col++)
                    {
                        dr[col] = ((Excel.Range)workSheet.Cells[row, col + 1]).Text.ToString();
                    }
                    dt.Rows.Add(dr);
                }

            }
            catch (Exception ex)
            {
                appExcel.Quit();
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            appExcel.Quit();
            ds.Tables.Add(dt);
            ds.Tables.Add(dtControl);
            return ds;

        }
        //public void SaveAsExcel(DataGridView  dgv) //另存新档按钮   导出成Excel
        //{
        //	SaveFileDialog saveFileDialog = new SaveFileDialog();
        //	saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
        //	saveFileDialog.FilterIndex = 0;
        //	saveFileDialog.RestoreDirectory = true;
        //	saveFileDialog.CreatePrompt = true;
        //	saveFileDialog.Title = "Open Excel File From";
        //	saveFileDialog.ShowDialog();

        //	Stream myStream;
        //	if (saveFileDialog.FileName != "")
        //	{
        //	myStream = saveFileDialog.OpenFile();

        //	StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
        //	string str = "";
        //	try
        //	{ //写标题
        //		for (int i = 0; i < dgv.ColumnCount; i++)
        //		{
        //			if (i > 0)
        //			{
        //				str +=  "\t";
        //			} str += dgv.Columns[i].HeaderText;

        //		}
        //		sw.WriteLine(str);
        //		//写内容
        //		for (int j = 0; j < dgv.Rows.Count; j++)
        //		{
        //			string tempStr = "";
        //			for (int k = 0; k < dgv.Columns.Count; k++)
        //			{
        //				if (k > 0) { tempStr += "\t"; } tempStr += dgv.Rows[j].Cells[k].Value.ToString();
        //			}
        //			sw.WriteLine(tempStr);
        //		}
        //		sw.Close();
        //		myStream.Close();
        //	}
        //	catch (Exception e)
        //	{
        //		MessageBox.Show(e.ToString());
        //	}
        //	finally
        //	{
        //		sw.Close(); myStream.Close();
        //	}
        //}}

        public void ExcelIntodgv(DataGridView dgv) //Excel导入Datagridview
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "Execl files (*.xls)|*.xls";
            OpenFileDialog1.FilterIndex = 0;
            OpenFileDialog1.Title = "Export Excel File To";
            //OpenFileDialog1.ShowDialog();

            String FileName;
            //Stream myStream;
            //myStream = OpenFileDialog1.OpenFile();
            //StreamReader sw = new StreamReader(myStream, System.Text.Encoding.GetEncoding(-0));
            try
            {
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileName = OpenFileDialog1.FileName;
                    string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1;'";
                    OleDbConnection connection = new OleDbConnection(sConnectionString);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    string sql_select_commands = "Select * from  [2014$]";
                    OleDbCommand command = new OleDbCommand(sql_select_commands, connection);
                    OleDbDataAdapter adp = new OleDbDataAdapter(command);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    dgv.DataSource = dt;
                    connection.Close();
                    adp.Dispose();

                }
            }

            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog fileDialog = new OpenFileDialog();
        //    fileDialog.Filter = "Microsoft Excel files (*.xls)|*.xls";//指定打开文件的内型 
        //    string fileName;
        //    string connectionString;
        //    if (fileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        fileName = fileDialog.FileName;
        //        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;'";
        //        OleDbConnection con = new OleDbConnection(connectionString);//连接到指定的Excel文件 
        //        con.Open();
        //        string strSQL = "SELECT * FROM [Sheet1$]";
        //        OleDbCommand command = new OleDbCommand(strSQL, con);
        //        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
        //        DataTable table = new DataTable();
        //        adapter.Fill(table);
        //        dataGridView1.DataSource = table;
        //        con.Close();
        //        adapter.Dispose();
        //    }
        //}

        //    try
        //    { //写标题
        //        if (OpenFileDialog1.ShowDialog()==DialogResult.ok)
        //        {
        //            if (i > 0)
        //            {
        //                str += "\t";
        //            } str += dgv.Columns[i].HeaderText;

        //        }
        //        sw.ReadLine(str);
        //        //写内容
        //        for (int j = 0; j < dgv.Rows.Count; j++)
        //        {
        //            string tempStr = "";
        //            for (int k = 0; k < dgv.Columns.Count; k++)
        //            {
        //                if (k > 0) { tempStr += "\t"; } tempStr += dgv.Rows[j].Cells[k].Value.ToString();
        //            }
        //            sw.ReadLine(tempStr);
        //        }
        //        sw.Close();
        //        myStream.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //    }
        //    finally
        //    {
        //        sw.Close(); myStream.Close();
        //    }
        //}



        //public void DataTableToExcel(string FileName,DataTable dt)
        //{
        //    string txtfile = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"CSV\";
        //    string BackupPath = txtfile;

        //    if (!Directory.Exists(BackupPath))
        //    { Directory.CreateDirectory(BackupPath); }

        //    BackupPath += DateTime.Now.ToString("yyMMdd");
        //    BackupPath += "_";
        //    BackupPath += FileName;
        //    BackupPath += ".csv";


        //    if (File.Exists(BackupPath))
        //    {
        //        File.Delete(BackupPath);
        //    }
        //    //先打印标头
        //    StringBuilder strColu = new StringBuilder();
        //    StringBuilder strValue = new StringBuilder();
        //    int i = 0;

        //    try
        //    {
        //        StreamWriter sw = new StreamWriter(new FileStream(BackupPath, FileMode.CreateNew), System.Text.Encoding.UTF8);

        //        for (i = 0; i <= dt.Columns.Count - 1; i++)
        //        {
        //            strColu.Append(dt.Columns[i].ColumnName);
        //            strColu.Append(",");
        //        }
        //        strColu.Remove(strColu.Length - 1, 1);//移出掉最后一个,字符
        //        //strValue.Append("\n");

        //        sw.WriteLine(strColu);

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            for (i = 0; i <= dt.Columns.Count - 1; i++)
        //            {
        //                strValue.Append(dr[i].ToString());
        //                strValue.Append(",");
        //            }
        //            strValue.Remove(strValue.Length - 1, 1);//移出掉最后一个,字符
        //            //strValue.Append("\n");
        //            sw.WriteLine(strValue);
        //            strValue.Remove(0, strValue.Length);//移出
        //        }

        //        sw.Close();



        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);

        //    }
        //}


        //public void ExcelToAccess (string FileName,string DataBaseName)
        //{
        //    try
        //    {
        //        string sConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + FileName  + ";Extended Properties=Excel 8.0;";
        //        OleDbConnection connection = new OleDbConnection(sConnectionString);
        //        string sql_select_commands = "Select * from [Sheet1$]";
        //        OleDbDataAdapter adp = new OleDbDataAdapter(sql_select_commands, connection);
        //        DataTable dt = new DataTable();

        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //        C#实现Access导入导出Excel  

        //2011-04-13 12:19:43|  分类： C# |  标签：excel  filename  access  messagebox  openfile   |字号 订阅
        //一、Access从Excel中导入数据

        //1.用到的Excel表的格式及内容



        //实现



        //OleDbConnection con = new OleDbConnection();   
        //            try  
        //            {   
        //                OpenFileDialog openFile = new OpenFileDialog();//打开文件对话框。   
        //                openFile.Filter = ("Excel 文件(*.xls)|*.xls");//后缀名。   
        //                if (openFile.ShowDialog() == DialogResult.OK)   
        //                {   
        //                    string filename = openFile.FileName;   
        //                    int index = filename.LastIndexOf("\\");//截取文件的名字   
        //                    filename = filename.Substring(index + 1);   
        //                    conExcel.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" +    
        //                                                Application.StartupPath + "\\Appdata.mdb";   
        //                    //将excel导入access   
        //                    //distinct :删除excel重复的行.   
        //                    //[excel名].[sheet名] 已有的excel的表要加$   
        //                    //where not in : 插入不重复的记录。   

        //                    string sql = "insert into Users2(用户编号,用户姓名) select distinct * from [Excel 8.0;database=" +   
        //                                filename + "].[name$] where 用户编号 not in (select 用户编号 from Users2) ";   
        //                    OleDbCommand com = new OleDbCommand(sql, con);   
        //                    con.Open();   
        //                    com.ExecuteNonQuery();   
        //                    MessageBox.Show("导入数据成功", "导入数据", MessageBoxButtons.OK, MessageBoxIcon.Information);   
        //                }   
        //            }   
        //            catch (Exception ex)   
        //            {   
        //                MessageBox.Show(ex.ToString());   
        //            }   
        //            finally  
        //            {   
        //                con.Close();   
        //            }  
        //OleDbConnection con = new OleDbConnection();
        //            try
        //            {
        //                OpenFileDialog openFile = new OpenFileDialog();//打开文件对话框。
        //                openFile.Filter = ("Excel 文件(*.xls)|*.xls");//后缀名。
        //                if (openFile.ShowDialog() == DialogResult.OK)
        //                {
        //                    string filename = openFile.FileName;
        //                    int index = filename.LastIndexOf("\\");//截取文件的名字
        //                    filename = filename.Substring(index + 1);
        //                    conExcel.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + 
        //                                                Application.StartupPath + "\\Appdata.mdb";
        //                    //将excel导入access
        //                    //distinct :删除excel重复的行.
        //                    //[excel名].[sheet名] 已有的excel的表要加$
        //                    //where not in : 插入不重复的记录。

        //                    string sql = "insert into Users2(用户编号,用户姓名) select distinct * from [Excel 8.0;database=" +
        //                                filename + "].[name$] where 用户编号 not in (select 用户编号 from Users2) ";
        //                    OleDbCommand com = new OleDbCommand(sql, con);
        //                    con.Open();
        //                    com.ExecuteNonQuery();
        //                    MessageBox.Show("导入数据成功", "导入数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString());
        //            }
        //            finally
        //            {
        //                con.Close();
        //            }



        //二、Access导出Excel

        //view plaincopy to clipboardprint?
        //OleDbConnection con = new OleDbConnection();   
        //            try  
        //            {   
        //                SaveFileDialog saveFile = new SaveFileDialog();   
        //                saveFile.Filter = ("Excel 文件(*.xls)|*.xls");//指定文件后缀名为Excel 文件。   
        //                if (saveFile.ShowDialog() == DialogResult.OK)   
        //                {   
        //                    string filename = saveFile.FileName;   
        //                    if (System.IO.File.Exists(filename))   
        //                    {   
        //                        System.IO.File.Delete(filename);//如果文件存在删除文件。   
        //                    }   
        //                    int index = filename.LastIndexOf("\\");//获取最后一个\的索引   
        //                    filename = filename.Substring(index + 1);//获取excel名称(新建表的路径相对于SaveFileDialog的路径)   
        //                    //select * into 建立 新的表。   
        //                    //[[Excel 8.0;database= excel名].[sheet名] 如果是新建sheet表不能加$,如果向sheet里插入数据要加$.　   
        //                    //sheet最多存储65535条数据。   
        //                    string sql = "select top 65535 *  into   [Excel 8.0;database=" + filename + "].[用户信息] from Users2";   
        //                    con.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + Application.StartupPath + "\\Appdata.mdb";//将数据库放到debug目录下。   
        //                    OleDbCommand com = new OleDbCommand(sql, con);   
        //                    con.Open();   
        //                    com.ExecuteNonQuery();   

        //                    MessageBox.Show("导出数据成功", "导出数据", MessageBoxButtons.OK, MessageBoxIcon.Information);   
        //                }   
        //            }   
        //            catch (Exception ex)   
        //            {   
        //                MessageBox.Show(ex.ToString());   
        //            }   
        //            finally  
        //            {   
        //                con.Close();   
        //            } 
    }
}
