using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.Util;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using NPOI.SS.Util;
namespace CostControl
{
    class ExcelHelper
    {
        private IWorkbook workBook;
        private string fileName;
        private ISheet currentSheet;
        private ICellStyle titleStyle;
        private ICellStyle headerStyle;
        private ICellStyle dateTimeStyle;
        private ICellStyle dateYearStyle;
        private ICellStyle doubleNumStyle;
        private ICellStyle intNumStyle;

        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            if (fileName.EndsWith(".xlsx"))
            {
                workBook = new XSSFWorkbook();
            }
            else
            {
                workBook = new HSSFWorkbook();
            }
            InitStyle();
        }

        private void InitStyle()
        {
            titleStyle = workBook.CreateCellStyle();
            headerStyle = workBook.CreateCellStyle();
            dateTimeStyle = workBook.CreateCellStyle();
            dateYearStyle = workBook.CreateCellStyle();
            doubleNumStyle = workBook.CreateCellStyle();
            intNumStyle = workBook.CreateCellStyle();
        }
        public ExcelHelper() { }


        /// <summary>
        /// 设置标题，居中显示，默认合并前两行
        /// </summary>
        /// <param name="title">标题内容</param>
        /// <param name="colNum">列数 从0开始</param>
        public void SetTitle(string title, int lastCol)
        {
            IRow row = currentSheet.CreateRow(0);
            ICell cell = row.CreateCell(0);
            cell.SetCellValue(title);
            cell.CellStyle = TitleStyle;
            currentSheet.AddMergedRegion(new CellRangeAddress(0, 1, 0, lastCol));
        }

        /// <summary>
        /// 将DataGridView转换为DataTable
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static DataTable GridViewToDataTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dt.Columns.Add(dgv.Columns[i].DataPropertyName.Trim());
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dr[j] = dgv[j, i].Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 从Excel文件某个Sheet表截取指定区域转换为DataTable，第一行需为DataTable列名
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="rowStart">开始行号 从0开始计数</param>
        /// <param name="rowEnd">结束行号 从0开始计数(为0则自动取最大行数)</param>
        /// <param name="colStart">开始列号 从0开始计数</param>
        /// <param name="colEnd">结束列号 从0开始计数(为0则自动取最大列数)</param>
        /// <param name="sheetNum">Sheet号，从0开始计数</param>
        /// <param name="hasHeader">是否将第一行作为列名</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string fileName, int rowStart, int rowEnd, int colStart, int colEnd, int sheetNum, bool hasHeader = true)
        {
            DataTable dt = new DataTable();
            IWorkbook workBook;
            try
            {
                using (FileStream fs = File.OpenRead(fileName))
                {
                    workBook = WorkbookFactory.Create(fs);
                }
                ISheet sheet = workBook.GetSheetAt(sheetNum);
                //为0则初始为最大行数
                rowEnd = (rowEnd == 0 ? sheet.LastRowNum : rowEnd);
                //为0则初始为最大列数
                colEnd = (colEnd == 0 ? sheet.GetRow(rowStart).LastCellNum - 1 : colEnd);

                if (hasHeader)
                {
                    for (int i = colStart; i <= colEnd; i++)
                    {
                        dt.Columns.Add(sheet.GetRow(rowStart).GetCell(i).ToString());
                    }
                }
                else
                {
                    for (int i = colStart; i <= colEnd; i++)
                    {
                        dt.Columns.Add("Column" + (i - colStart));
                    }
                    rowStart = rowStart - 1;
                }
                for (int i = rowStart + 1; i <= rowEnd; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = colStart; j <= colEnd; j++)
                    {
                        dr[j - colStart] = sheet.GetRow(i).GetCell(j);
                    }
                    dt.Rows.Add(dr);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Excel格式有误，返回部分结果！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }


        /// <summary>
        /// 将Excel文件的Sheet表转换为DataTable,适用于整张Sheet只有一个表格的情况
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="sheetNum">Sheet号,从0开始计数</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string fileName, int sheetNum)
        {
            DataTable dt = new DataTable();
            dt = ExcelToDataTable(fileName, 0, 0, 0, 0, sheetNum);
            return dt;
        }

        /// <summary>
        /// 新建一张Sheet
        /// </summary>
        /// <param name="sheetName">Sheet名</param>
        public void NewSheet(string sheetName = null)
        {
            try
            {
                if (sheetName == null)
                {
                    currentSheet = workBook.CreateSheet();
                }
                else
                {
                    currentSheet = workBook.CreateSheet(sheetName);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// DataTable转换为Excel
        /// </summary>
        /// <param name="dt">DataTable源</param>
        /// <param name="rowStart">Excel开始行数(0-based)</param>
        /// <param name="colStart">Excel开始列数(0-based)</param>
        /// <param name="hasHead">是否将DataTable列名作为Excel中表格的表头</param>
        public void DataTableToExcel(DataTable dt, int rowStart, int colStart, bool hasHead = true)
        {
            currentSheet.DefaultColumnWidth = 16;
            if (hasHead)
            {
                IRow headRow = currentSheet.CreateRow(rowStart);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell headCell = headRow.CreateCell(colStart + i);
                    headCell.SetCellType(CellType.String);
                    headCell.CellStyle = HeaderStyle;
                    headCell.SetCellValue(dt.Columns[i].ColumnName);
                }
            }
            else
            {
                rowStart = rowStart - 1;
            }
            int rowIndex = 0;
            foreach (DataRow dtRow in dt.Rows)
            {
                IRow iRow = currentSheet.CreateRow(rowStart + rowIndex + 1);
                foreach (DataColumn dtColumn in dt.Columns)
                {
                    ICell newCell = iRow.CreateCell(dtColumn.Ordinal);
                    object obj = dtRow[dtColumn];
                    SetCellValue(ref newCell, obj);
                }
                rowIndex++;
            }
        }


        /// <summary>
        /// 数组作为表头追加，前面空一行
        /// </summary>
        /// <param name="array"></param>
        public void AppendHeader(Array array)
        {
            int rowStart = currentSheet.LastRowNum + 2;
            if (currentSheet.LastRowNum == 0)
            {
                rowStart = 0;
            }
            AppendToExcel(array, rowStart, true);
        }

        /// <summary>
        /// 数组作为表格内容追加，前面不空行
        /// </summary>
        /// <param name="array"></param>
        public void AppendContent(Array array)
        {
            int rowStart = currentSheet.LastRowNum + 1;
            AppendToExcel(array, rowStart, false);
        }

        /// <summary>
        /// 向当前Sheet追加内容
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="rowStart">起始行</param>
        /// <param name="isHeader">是否追加为表头样式</param>
        public void AppendToExcel(Array array, int rowStart, bool isHeader)
        {
            currentSheet.DefaultColumnWidth = 16;
            ICellStyle headCellStyle = workBook.CreateCellStyle();
            headCellStyle.FillForegroundColor = HSSFColor.Grey40Percent.Index;
            headCellStyle.FillPattern = FillPattern.SolidForeground;
            if (isHeader)
            {
                IRow headRow = currentSheet.CreateRow(rowStart);
                for (int i = 0; i < array.Length; i++)
                {
                    ICell headerCell = headRow.CreateCell(i);
                    headerCell.SetCellType(CellType.String);
                    headerCell.CellStyle = headCellStyle;
                    headerCell.SetCellValue(array.GetValue(i).ToString());
                }
            }
            else
            {
                IRow row = currentSheet.CreateRow(rowStart);
                for (int i = 0; i < array.Length; i++)
                {
                    ICell newCell = row.CreateCell(i);
                    object obj = array.GetValue(i);
                    SetCellValue(ref newCell, obj);
                }
            }
        }

        /// <summary>
        /// 向当前Sheet中追加内容
        /// </summary>
        /// <param name="dt">DataTable源</param>
        /// <param name="isNewTable">是否追加为新表格</param>
        public void AppendToExcel(DataTable dt, bool isNewTable)
        {
            if (isNewTable)
            {
                int rowStart = currentSheet.LastRowNum + 2;
                DataTableToExcel(dt, rowStart, 0, true);
            }
            else
            {
                int rowStart = currentSheet.LastRowNum + 1;
                DataTableToExcel(dt, rowStart, 0, false);
            }
        }

        /// <summary>
        /// 设置单元
        /// </summary>
        /// <param name="newCell"></param>
        /// <param name="obj"></param>
        private void SetCellValue(ref ICell newCell, object obj)
        {
            Type t = obj.GetType();
            switch (t.ToString())
            {
                case "System.String"://字符串类型
                    newCell.SetCellValue(obj.ToString());
                    newCell.SetCellType(CellType.String);
                    break;
                case "System.DateTime"://日期类型
                    newCell.SetCellValue((DateTime)obj);
                    newCell.CellStyle = DateTimeStyle;//格式化显示
                    break;
                case "System.Boolean"://布尔型
                    newCell.SetCellValue((bool)obj);
                    newCell.SetCellType(CellType.Boolean);
                    break;
                case "System.Int16"://整型
                case "System.Int32":
                case "System.Int64":
                case "System.Byte":
                    int intV = 0;
                    int.TryParse(obj.ToString(), out intV);
                    newCell.SetCellValue(intV);
                    newCell.SetCellType(CellType.Numeric);
                    break;
                case "System.Decimal"://浮点型
                case "System.Double":
                    double doubV = 0;
                    double.TryParse(obj.ToString(), out doubV);
                    newCell.SetCellValue(doubV);
                    newCell.CellStyle = DoubleNumStyle;
                    newCell.SetCellType(CellType.Numeric);
                    break;
                case "System.DBNull"://空值处理
                    newCell.SetCellValue("");
                    newCell.SetCellType(CellType.Blank);
                    break;
                default:
                    newCell.SetCellValue(obj.ToString());
                    break;
            }
        }

        public ICellStyle TitleStyle
        {
            get
            {
                titleStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                IFont font = workBook.CreateFont();
                font.Boldweight = 6;
                font.FontHeight = 18 * 18;
                titleStyle.SetFont(font);
                return titleStyle;
            }
        }

        public ICellStyle HeaderStyle
        {
            get
            {
                headerStyle.FillForegroundColor = HSSFColor.Grey40Percent.Index;
                headerStyle.FillPattern = FillPattern.SolidForeground;
                return headerStyle;
            }
        }

        public ICellStyle DateTimeStyle
        {
            get
            {
                IDataFormat formatMD = workBook.CreateDataFormat();
                dateTimeStyle.DataFormat = formatMD.GetFormat("yyyy-mm-dd");
                return dateTimeStyle;
            }
        }

        public ICellStyle DateYearStyle
        {
            get
            {
                IDataFormat format = workBook.CreateDataFormat();
                dateYearStyle.DataFormat = format.GetFormat("yyyy");
                return dateYearStyle;
            }
        }

        public ICellStyle DoubleNumStyle
        {
            get
            {
                doubleNumStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                return doubleNumStyle;

            }
        }

        public ICellStyle IntNumStyle
        {
            get
            {
                intNumStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                return intNumStyle;
            }
        }

        /// <summary>
        /// 显示文件保存对话框，并根据文件后缀名确定要生成的Excel版本
        /// </summary>
        public void ShowSaveFileDialog()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "xls";
            dlg.Filter = "Excel 97-2003 工作簿(*.xls)|*.xls|Excel 工作簿(*.xlsx)|*.xlsx";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.FileName = "Sheet1.xls";
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == "") return;
            this.fileName = fileNameString;
            if (fileName.EndsWith(".xlsx"))
            {
                workBook = new XSSFWorkbook();
            }
            else
            {
                workBook = new HSSFWorkbook();
            }
            currentSheet = workBook.CreateSheet();
            InitStyle();
        }

        /// <summary>
        /// 保存Excel文件
        /// </summary>
        public void SaveToExcel()
        {
            try
            {
                using (FileStream fs = File.Open(fileName, FileMode.Create))
                {
                    workBook.Write(fs);
                    MessageBox.Show(fileName + "\n导出成功", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
