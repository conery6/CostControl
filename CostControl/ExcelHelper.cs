using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing.Chart;
using System.Collections.Generic;
namespace CostControl
{
    class ExcelHelper
    {
        private string fileName;
        private ExcelPackage _excelPackage;
        private ExcelWorkbook _workBook;
        private ExcelWorksheet _currentSheet;
        private List<TableStruct> _addedTables = new List<TableStruct>();
        public ExcelHelper(string fileName)
        {
            _excelPackage = new ExcelPackage();
            _workBook = _excelPackage.Workbook;
            this.fileName = fileName;
        }

        public ExcelHelper() { }

        private struct TableStruct
        {
            public int rowFrom;
            public int rowTo;
            public int colFrom;
            public int colTo;
        }

        public int LastRowNum
        {
            get
            {
                if (_currentSheet.Dimension == null) return 1;
                return _currentSheet.Dimension.End.Row;
            }
        }

        public ExcelWorksheet CurrentSheet
        {
            get { return _currentSheet; }
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
            //	IWorkbook workBook;
            //	try
            //	{
            //		using (FileStream fs = File.OpenRead(fileName))
            //		{
            //			workBook = WorkbookFactory.Create(fs);
            //		}
            //		ISheet sheet = workBook.GetSheetAt(sheetNum);
            //		//为0则初始为最大行数
            //		rowEnd = (rowEnd == 0 ? sheet.LastRowNum : rowEnd);
            //		//为0则初始为最大列数
            //		colEnd = (colEnd == 0 ? sheet.GetRow(rowStart).LastCellNum - 1 : colEnd);

            //		if (hasHeader)
            //		{
            //			for (int i = colStart; i <= colEnd; i++)
            //			{
            //				dt.Columns.Add(sheet.GetRow(rowStart).GetCell(i).ToString());
            //			}
            //		}
            //		else
            //		{
            //			for (int i = colStart; i <= colEnd; i++)
            //			{
            //				dt.Columns.Add("Column" + (i - colStart));
            //			}
            //			rowStart = rowStart - 1;
            //		}
            //		for (int i = rowStart + 1; i <= rowEnd; i++)
            //		{
            //			DataRow dr = dt.NewRow();
            //			for (int j = colStart; j <= colEnd; j++)
            //			{
            //				dr[j - colStart] = sheet.GetRow(i).GetCell(j);
            //			}
            //			dt.Rows.Add(dr);
            //		}
            //	}
            //	catch (Exception)
            //	{
            //		MessageBox.Show("Excel格式有误，返回部分结果！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //	}
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
            //	dt = ExcelToDataTable(fileName, 0, 0, 0, 0, sheetNum);
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
                    _currentSheet = _workBook.Worksheets.Add("Sheet" + (_workBook.Worksheets.Count + 1));
                }
                else
                {
                    _currentSheet = _workBook.Worksheets.Add(sheetName);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private static void SetHeaderCellValue(ExcelRange cell, string value)
        {
            cell.Value = value;
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(Color.LightSteelBlue);
        }

        private static void SetCellValue(ExcelRange cell, object obj)
        {
            Type t = obj.GetType();
            switch (t.ToString())
            {
                case "System.String"://字符串类型
                    cell.Value = obj.ToString();
                    break;
                case "System.DateTime"://日期类型
                    cell.Value = (DateTime)obj;
                    break;
                case "System.Boolean"://布尔型
                    cell.Value = (bool)obj;
                    break;
                case "System.Int16"://整型
                case "System.Int32":
                case "System.Int64":
                case "System.Byte":
                    int intV = 0;
                    int.TryParse(obj.ToString(), out intV);
                    cell.Value = intV;
                    cell.Style.Numberformat.Format = "0";
                    break;
                case "System.Decimal"://浮点型
                case "System.Double":
                case "System.Single":
                    double doubV = 0;
                    double.TryParse(obj.ToString(), out doubV);
                    cell.Value = doubV;
                    cell.Style.Numberformat.Format = "0.00";
                    break;
                case "System.DBNull"://空值处理
                    cell.Value = "";
                    break;
                default:
                    cell.Value = obj.ToString();
                    break;
            }
        }

        public enum ExportStyle
        {
            RMTable,
            Normal,
            None
        }

        public void DataTableToExcelForTotal(DataTable dt, int rowStart, int colStart, bool hasHead = true, ExportStyle style = ExportStyle.Normal)
        {
            int rowIndex = 0;
            if (hasHead)
            {
                switch (style)
                {
                    case ExportStyle.RMTable:
                    case ExportStyle.None:
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            SetCellValue(_currentSheet.Cells[rowStart, i + 1], dt.Columns[i].ColumnName);
                        }
                        break;
                    case ExportStyle.Normal:
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            SetHeaderCellValue(_currentSheet.Cells[rowStart, i + 1], dt.Columns[i].ColumnName);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                rowStart = rowStart - 1;
            }
            foreach (DataRow dtRow in dt.Rows)
            {
                foreach (DataColumn dtColumn in dt.Columns)
                {
                    SetCellValue(_currentSheet.Cells[rowStart + rowIndex + 1, dtColumn.Ordinal + 1], dtRow[dtColumn]);
                    if (style != ExportStyle.None)
                    {
                        _currentSheet.Cells[rowStart + rowIndex + 1, dtColumn.Ordinal + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                }
                rowIndex++;
            }
            switch (style)
            {
                case ExportStyle.RMTable:
                    _currentSheet.Cells[rowStart + 1, 1, dt.Rows.Count + rowStart, dt.Columns.Count].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    _currentSheet.Cells[rowStart + 1, 1, rowStart + 1, dt.Columns.Count].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _currentSheet.Cells[rowStart + 1, 1, rowStart + 1, dt.Columns.Count].Style.Fill.BackgroundColor.SetColor(Color.LightSteelBlue);
                    break;
                case ExportStyle.Normal:
                    _currentSheet.DefaultColWidth = 15;
                    _currentSheet.Column(1).Width = 16;
                    break;
                case ExportStyle.None:
                    break;
                default:
                    break;
            }
            TableStruct tb = new TableStruct();
            tb.rowFrom = rowStart + 1;
            tb.rowTo = LastRowNum;
            tb.colFrom = 1;
            tb.colTo = dt.Columns.Count;
            _addedTables.Add(tb);
        }

        /// <summary>
        /// DataTable转换为Excel
        /// </summary>
        /// <param name="dt">DataTable源</param>
        /// <param name="rowStart">Excel开始行数(1-based)</param>
        /// <param name="colStart">Excel开始列数(1-based)</param>
        /// <param name="hasHead">是否将DataTable列名作为Excel中表格的表头</param>
        public void DataTableToExcel(DataTable dt, int rowStart, int colStart, bool hasHead = true, ExportStyle style = ExportStyle.Normal)
        {
            int rowIndex = 0;
            if (hasHead)
            {
                switch (style)
                {
                    case ExportStyle.RMTable:
                    case ExportStyle.None:
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            SetCellValue(_currentSheet.Cells[rowStart, i + colStart], dt.Columns[i].ColumnName);
                        }
                        break;
                    case ExportStyle.Normal:
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            SetHeaderCellValue(_currentSheet.Cells[rowStart, i + colStart], dt.Columns[i].ColumnName);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                rowStart = rowStart - 1;
            }
            foreach (DataRow dtRow in dt.Rows)
            {
                foreach (DataColumn dtColumn in dt.Columns)
                {
                    SetCellValue(_currentSheet.Cells[rowStart + rowIndex + 1, dtColumn.Ordinal + colStart], dtRow[dtColumn]);
                    if (style != ExportStyle.None)
                    {
                        _currentSheet.Cells[rowStart + rowIndex + 1, dtColumn.Ordinal + colStart].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                }
                rowIndex++;
            }
            switch (style)
            {
                case ExportStyle.RMTable:
                    _currentSheet.Cells[rowStart + 1, colStart, dt.Rows.Count + rowStart, dt.Columns.Count].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    _currentSheet.Cells[rowStart + 1, colStart, rowStart + 1, dt.Columns.Count].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _currentSheet.Cells[rowStart + 1, colStart, rowStart + 1, dt.Columns.Count].Style.Fill.BackgroundColor.SetColor(Color.LightSteelBlue);
                    break;
                case ExportStyle.Normal:
                    _currentSheet.DefaultColWidth = 15;
                    _currentSheet.Column(1).Width = 16;
                    break;
                case ExportStyle.None:
                    break;
                default:
                    break;
            }
        }



        /// <summary>
        /// 数组作为表头追加，前面空一行
        /// </summary>
        /// <param name="array"></param>
        public void AppendHeader(object[] array)
        {
            int rowStart = LastRowNum + 2;
            if (LastRowNum == 1)
            {
                rowStart = 1;
            }
            AppendToExcel(array, rowStart, true);
        }

        /// <summary>
        /// 数组作为表格内容追加，前面不空行
        /// </summary>
        /// <param name="array"></param>
        public void AppendContent(object[] array)
        {

            int rowStart = LastRowNum + 1;
            AppendToExcel(array, rowStart, false);
        }

        /// <summary>
        /// 向当前Sheet追加内容
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="rowStart">起始行</param>
        /// <param name="isHeader">是否追加为表头样式</param>
        public void AppendToExcel(object[] array, int rowStart, bool isHeader)
        {

            if (isHeader)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    ExcelRange er = _currentSheet.Cells[rowStart, 1, rowStart, array.Length + 1];
                    SetHeaderCellValue(_currentSheet.Cells[rowStart, i + 1], array.GetValue(i).ToString());
                }

            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    SetCellValue(_currentSheet.Cells[rowStart, i + 1], array.GetValue(i));
                }
            }

        }

        public void AppendToExcel(object[] array, int rowStart, int colStart, bool isHeader)
        {

            if (isHeader)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    ExcelRange er = _currentSheet.Cells[rowStart, colStart, rowStart, array.Length + 1];
                    SetHeaderCellValue(_currentSheet.Cells[rowStart, colStart + i], array.GetValue(i).ToString());
                }

            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    SetCellValue(_currentSheet.Cells[rowStart, colStart + i], array.GetValue(i));
                }
            }

        }
        /// <summary>
        /// 向当前Sheet中追加内容
        /// </summary>
        /// <param name="dt">DataTable源</param>
        /// <param name="isNewTable">是否追加为新表格</param>
        public void AppendToExcel(DataTable dt, bool isNewTable, ExportStyle style = ExportStyle.Normal)
        {
            if (isNewTable)
            {
                int rowStart = LastRowNum + 2;
                DataTableToExcel(dt, rowStart, 1, true, style);
            }
            else
            {
                int rowStart = LastRowNum + 1;
                DataTableToExcel(dt, rowStart, 1, false, style);
            }
        }

        /// <summary>
        /// 显示文件保存对话框，并根据文件后缀名确定要生成的Excel版本
        /// </summary>
        public bool ShowSaveFileDialog()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "xlsx";
            dlg.Filter = "Excel 工作簿(*.xlsx)|*.xlsx";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.FileName = "Sheet1.xlsx";
            if (dlg.ShowDialog() == DialogResult.Cancel) return false;
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == "") return false;
            this.fileName = fileNameString;
            if (_excelPackage == null)
            {
                _excelPackage = new ExcelPackage();
                _workBook = _excelPackage.Workbook;
            }
            if (_currentSheet == null)
            {
                _currentSheet = _workBook.Worksheets.Add("Sheet1");
            }
            return true;
        }

        //public struct ChartInfo
        //{
        //    public string chartTitle;
        //    public string baseSeries;
        //    public string compareSeries;
        //    public string[] infoHeader;
        //    public object[] baseInfo;
        //    public object[] compareInfo;
        //}

        //public ExcelChart AddChart(int row, int column, ChartInfo chartInfo)
        //{
        //    string charTitle = chartInfo.chartTitle;
        //    string baseSeries = chartInfo.baseSeries;
        //    string compareSeries = chartInfo.compareSeries;
        //    string[] infoHeader = chartInfo.infoHeader;
        //    object[] baseInfo = chartInfo.baseInfo;
        //    object[] compareInfo = chartInfo.compareInfo;
        //    var chart = _currentSheet.Drawings.AddChart("Table", eChartType.ColumnStacked);
        //    chart.XAxis.MinorUnit = 1;
        //    chart.SetPosition(row, 0, column, 0);
        //    chart.SetSize(640, 400);
        //    chart.Border.LineStyle = OfficeOpenXml.Drawing.eLineStyle.Solid;
        //    chart.Legend.Position = eLegendPosition.Bottom;
        //    chart.Legend.Add();
        //    chart.Title.Text = charTitle;
        //    chart.Title.Font.Size = 12;
        //    chart.Title.Font.Bold = true;
        //    return chart;
        //}

        //public void AddSerieToChart(ExcelChart chart, ExcelChartSerie chartSerie, string serieHeader, ExcelRange serie, ExcelRange XSerie)
        //{
        //    chartSerie = chart.Series.Add(serie, XSerie);
        //    chartSerie.Header = serieHeader;
        //}

        //public void ExportExcelWithChart(DataTable baseTable, DataTable compareTable, ChartInfo chartInfo)
        //{
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    dlg.DefaultExt = "xlsx";
        //    dlg.Filter = "Excel 工作簿(*.xlsx)|*.xlsx";
        //    dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    dlg.FileName = "Sheet1.xlsx";
        //    if (dlg.ShowDialog() == DialogResult.Cancel) return;
        //    //返回文件路径   
        //    string fileNameString = dlg.FileName;
        //    //验证strFileName是否为空或值无效   
        //    if (fileNameString.Trim() == "") return;
        //    using (ExcelPackage package = new ExcelPackage())
        //    {
        //        int maxColNum = baseTable.Columns.Count;
        //        int baseSumNum;
        //        int compareSumNum;
        //        string charTitle = chartInfo.chartTitle;
        //        string baseSeries = chartInfo.baseSeries;
        //        string compareSeries = chartInfo.compareSeries;
        //        string[] infoHeader = chartInfo.infoHeader;
        //        object[] baseInfo = chartInfo.baseInfo;
        //        object[] compareInfo = chartInfo.compareInfo;
        //        ExcelWorkbook workBook = package.Workbook;
        //        ExcelWorksheet workSheet = workBook.Worksheets.Add("Sheet1");
        //        for (int i = 0; i < infoHeader.Length; i++)
        //        {
        //            workSheet.Cells[1, i + 1].Value = infoHeader[i];
        //            workSheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            workSheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Gray);
        //            workSheet.Cells[2, i + 1].Value = baseInfo[i];
        //        }
        //        for (int i = 0; i < baseTable.Columns.Count; i++)
        //        {
        //            workSheet.Cells[4, i + 1].Value = baseTable.Columns[i].ColumnName;
        //            workSheet.Cells[4, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            workSheet.Cells[4, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Gray);
        //        }
        //        int currentRow = 5;
        //        foreach (DataRow dtRow in baseTable.Rows)
        //        {

        //            foreach (DataColumn dtColumn in baseTable.Columns)
        //            {
        //                workSheet.Cells[currentRow, dtColumn.Ordinal + 1].Value = dtRow[dtColumn];
        //                workSheet.Cells[currentRow, dtColumn.Ordinal + 1].Style.Numberformat.Format = "0.00";
        //            }
        //            currentRow++;
        //        }
        //        workSheet.Cells[currentRow, 1].Value = "总计";
        //        for (int i = 2; i <= baseTable.Columns.Count; i++)
        //        {
        //            workSheet.Cells[currentRow, i].Formula = string.Format("Sum({0})", ExcelCellBase.GetAddress(5, i, currentRow - 1, i));
        //            workSheet.Cells[currentRow, i].Style.Numberformat.Format = "0.00";
        //        }
        //        currentRow++;
        //        workSheet.Cells[currentRow, 1].Value = "累计";
        //        baseSumNum = currentRow;
        //        for (int i = 2; i <= baseTable.Columns.Count; i++)
        //        {
        //            workSheet.Cells[currentRow, i].Formula = string.Format("Sum({0})", ExcelCellBase.GetAddress(currentRow - 1, 2, currentRow - 1, i));
        //            workSheet.Cells[currentRow, i].Style.Numberformat.Format = "0.00";
        //        }

        //        currentRow = currentRow + 2;
        //        for (int i = 0; i < infoHeader.Length; i++)
        //        {
        //            workSheet.Cells[currentRow, i + 1].Value = infoHeader[i];
        //            workSheet.Cells[currentRow, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            workSheet.Cells[currentRow, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Gray);
        //            workSheet.Cells[currentRow + 1, i + 1].Value = compareInfo[i];
        //        }
        //        currentRow = currentRow + 3;
        //        for (int i = 0; i < compareTable.Columns.Count; i++)
        //        {
        //            workSheet.Cells[currentRow, i + 1].Value = compareTable.Columns[i].ColumnName;
        //            workSheet.Cells[currentRow, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            workSheet.Cells[currentRow, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Gray);
        //        }
        //        currentRow = currentRow + 1;
        //        foreach (DataRow dtRow in compareTable.Rows)
        //        {

        //            foreach (DataColumn dtColumn in compareTable.Columns)
        //            {
        //                workSheet.Cells[currentRow, dtColumn.Ordinal + 1].Value = dtRow[dtColumn];
        //                workSheet.Cells[currentRow, dtColumn.Ordinal + 1].Style.Numberformat.Format = "0.00";
        //            }
        //            currentRow++;
        //        }
        //        workSheet.Cells[currentRow, 1].Value = "总计";

        //        for (int i = 2; i <= compareTable.Columns.Count; i++)
        //        {
        //            workSheet.Cells[currentRow, i].Formula = string.Format("Sum({0})", ExcelCellBase.GetAddress(currentRow - compareTable.Rows.Count, i, currentRow - 1, i));
        //            workSheet.Cells[currentRow, i].Style.Numberformat.Format = "0.00";
        //        }
        //        currentRow++;
        //        workSheet.Cells[currentRow, 1].Value = "累计";
        //        compareSumNum = currentRow;
        //        for (int i = 2; i <= baseTable.Columns.Count; i++)
        //        {
        //            workSheet.Cells[currentRow, i].Formula = string.Format("Sum({0})", ExcelCellBase.GetAddress(currentRow - 1, 2, currentRow - 1, i));
        //            workSheet.Cells[currentRow, i].Style.Numberformat.Format = "0.00";
        //        }
        //        var chart = workSheet.Drawings.AddChart("MGTable", eChartType.ColumnClustered3D);
        //        ExcelChartSerie serie;
        //        chart.XAxis.MinorUnit = 1;
        //        chart.SetPosition(1, 0, maxColNum, 20);
        //        chart.SetSize(640, 400);
        //        chart.Legend.Position = eLegendPosition.TopRight;
        //        chart.Legend.Add();
        //        chart.XAxis.Title.Text = "月份";
        //        chart.XAxis.Title.Font.Italic = true;
        //        chart.XAxis.Title.Font.Size = 10;
        //        chart.YAxis.Title.Text = "累计";
        //        chart.YAxis.Title.Font.Italic = true;
        //        chart.YAxis.Title.Font.Size = 10;
        //        chart.Title.Text = charTitle;
        //        chart.Title.Font.Size = 12;
        //        chart.Title.Font.Bold = true;
        //        serie = chart.Series.Add(workSheet.Cells[baseSumNum, 2, baseSumNum, maxColNum], workSheet.Cells[4, 2, 4, maxColNum]);
        //        serie.Header = baseSeries;
        //        serie = chart.Series.Add(workSheet.Cells[compareSumNum, 2, compareSumNum, maxColNum], workSheet.Cells[4, 2, 4, maxColNum]);
        //        serie.Header = compareSeries;

        //        try
        //        {
        //            FileInfo file = new FileInfo(fileNameString);
        //            package.SaveAs(file);
        //            MessageBox.Show(fileName + "\n导出成功", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        catch (Exception e)
        //        {

        //            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //    }
        //}

        public void LoadFromTemplate(string fileName)
        {
            using (FileStream fs = File.OpenRead(fileName))
            {
                _excelPackage.Load(fs);
                _workBook = _excelPackage.Workbook;
                _currentSheet = _workBook.Worksheets[1];
            }

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
                    _excelPackage.SaveAs(fs);
                    _excelPackage.Dispose();
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
