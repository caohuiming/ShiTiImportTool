/*
 * 解决Execl组建错误的情况此类不需要服务器的execl组建支持
 * 此类不会出现党同时导出execl人数大于50是服务器过载或无响应的情况
 * 
 * NPOI 是 POI 项目的 .NET 版本。POI是一个开源的Java读写Excel、WORD等微软OLE2组件文档的项目。
 * 使用 NPOI 你就可以在没有安装 Office 或者相应环境的机器上对 WORD/EXCEL 文档进行读写。
 * NPOI是构建在POI 3.x版本之上的，它可以在没有安装Office的情况下对Word/Excel文档进行读写操作
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using System.Windows.Forms;
using System.Threading;

namespace ShiTiImportTool.Helper
{
    /// <summary>
    /// NPOIExeclHelper
    /// </summary>
    public class NPOIExeclHelper
    {
        #region [导出Excel（3个方法重载）]
        static HSSFWorkbook hssfworkbook;
        /// <summary>
        /// 初始化execl
        /// </summary>
        public static void InitializeWorkbook()
        {
            hssfworkbook = new HSSFWorkbook();

            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "Excel工具";
            hssfworkbook.DocumentSummaryInformation = dsi;

            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "数据导出";
            hssfworkbook.SummaryInformation = si;
        }

        /// <summary>
        /// 导出Excel方法
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <param name="sheetname">sheft名称</param>
        /// <param name="outputname">输出的execl名称</param>
        public static void ExportDataTableToExcel(DataTable dt, string sheetname, string outputname)
        {
            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet(sheetname);

            HSSFRow row;
            HSSFCell cell;
            HSSFRow rowCap;

            //首先设置表列名称
            rowCap = (HSSFRow)sheet1.CreateRow(0);
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                cell = (HSSFCell)rowCap.CreateCell(j);
                cell.SetCellValue(dt.Columns[j].Caption);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                row = (HSSFRow)sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    cell = (HSSFCell)row.CreateCell(j);
                    cell.SetCellValue(dr[j].ToString());
                }
            }
            SaveToFile(outputname);
        }

        /// <summary>
        /// 导出Excel包含单元格样式的方法
        /// 注：要求在需要有样式的单元格加上 @?@，字体颜色变红（特用）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sheetname">sheft名称</param>
        /// <param name="fileName">文件名称，包含路径</param>
        public static void ExportExcelFileContainCss(DataTable dt, string sheetname, string fileName)
        {
            ExportExcelFileContainCss(dt, sheetname, fileName, null);
        }


        public static void ExportExcelFileContainCss(DataTable dt, string sheetname, string fileName, string[] columns)
        {
            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet(sheetname);

            //设置标题行样式
            HSSFCellStyle style = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
            HSSFFont font = (HSSFFont)hssfworkbook.CreateFont();
            font.Color = 10;//代表红色
            style.SetFont(font);

            HSSFRow row;
            HSSFCell cell;
            HSSFRow rowCap;
            //首先设置表列名称
            rowCap = (HSSFRow)sheet1.CreateRow(0);
            if (columns != null)
            {
                for (int j = 0; j < columns.Length; j++)
                {
                    cell = (HSSFCell)rowCap.CreateCell(j);
                    cell.SetCellValue(columns[j]);

                    sheet1.AutoSizeColumn(j);
                }
            }
            else
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    cell = (HSSFCell)rowCap.CreateCell(j);
                    cell.SetCellValue(dt.Columns[j].Caption);

                    sheet1.AutoSizeColumn(j);
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                row = (HSSFRow)sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    cell = (HSSFCell)row.CreateCell(j);
                    if (dr[j].ToString().Contains("@?@"))
                    {
                        dr[j] = dr[j].ToString().Replace("@?@", "");
                        cell.CellStyle = style;
                    }
                    cell.SetCellValue(dr[j].ToString());
                }
            }

            //获取当前列的宽度，然后对比本列的长度，取最大值  
            for (int columnNum = 0; columnNum <= dt.Columns.Count; columnNum++)
            {
                int columnWidth = sheet1.GetColumnWidth(columnNum) / 256;
                for (int rowNum = 1; rowNum <= sheet1.LastRowNum; rowNum++)
                {
                    IRow currentRow;
                    //当前行未被使用过  
                    if (sheet1.GetRow(rowNum) == null)
                    {
                        currentRow = sheet1.CreateRow(rowNum);
                    }
                    else
                    {
                        currentRow = sheet1.GetRow(rowNum);
                    }

                    if (currentRow.GetCell(columnNum) != null)
                    {
                        ICell currentCell = currentRow.GetCell(columnNum);
                        int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                        if (columnWidth < length)
                        {
                            columnWidth = length;
                        }
                    }
                }
                sheet1.SetColumnWidth(columnNum, columnWidth * 350);
            }

            SaveToFile(fileName);
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="saveFileDialog"></param>
        /// <param name="columns">列名</param>
        public static void ExportExcelFileContainCss(DataTable dt, SaveFileDialog saveFileDialog, string[] columns)
        {
            DialogResult rs = saveFileDialog.ShowDialog();
            if (rs != DialogResult.OK)
            {
                return;
            }
            try
            {
                string filename = saveFileDialog.FileName.ToString();

                ExportExcelFileContainCss(dt, "sheet1", saveFileDialog.FileName, columns);

                //打开Excel
                OpenFile(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存出错！" + ex.Message);
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="fileName"></param>
        private static void OpenFile(string fileName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        /// <summary>
        /// 导出Excel包含单元格样式的方法
        /// 注：要求在需要有样式的单元格加上 @?@，字体颜色变红（特用）
        /// </summary>
        /// <param name="dataset"></param>
        /// <param name="fileName"></param>
        public static void ExportExcelFileContainCss(DataSet dataset, string fileName)
        {
            InitializeWorkbook();
            foreach (DataTable dt in dataset.Tables)
            {
                HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet(dt.TableName);

                //设置标题行样式
                HSSFCellStyle style = (HSSFCellStyle)hssfworkbook.CreateCellStyle();
                HSSFFont font = (HSSFFont)hssfworkbook.CreateFont();
                font.Color = 10;//代表红色
                style.SetFont(font);

                HSSFRow row;
                HSSFCell cell;
                HSSFRow rowCap;
                //首先设置表列名称
                rowCap = (HSSFRow)sheet1.CreateRow(0);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    cell = (HSSFCell)rowCap.CreateCell(j);
                    cell.SetCellValue(dt.Columns[j].Caption);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    row = (HSSFRow)sheet1.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        cell = (HSSFCell)row.CreateCell(j);
                        if (dr[j].ToString().Contains("@?@"))
                        {
                            dr[j] = dr[j].ToString().Replace("@?@", "");
                            cell.CellStyle = style;
                        }
                        cell.SetCellValue(dr[j].ToString());
                    }
                }
            }
            SaveToFile(fileName);
        }
        #endregion

        #region [将Excel文件转换成DataTable、DataSet]
        /// <summary>
        /// Excel文档转换成DataTable，指定sheet名称，第一行必须为标题行
        /// </summary>
        /// <param name="strFileName">Excel文件路径</param>
        /// <param name="sheetName">sheet名称</param>
        /// <returns></returns>
        public static DataTable RenderFromExcel(string strFileName, string sheetName)
        {
            return RenderFromExcel(strFileName, sheetName, 0);
        }

        /// <summary>
        /// Excel文档转换成DataTable，指定sheet名称，指定那一行属于表头
        /// </summary>
        /// <param name="strFileName">Excel文件路径</param>
        /// <param name="sheetName">表名称</param>
        /// <param name="headerRowIndex">标题行索引号，如第一行为0</param>
        /// <returns></returns>
        public static DataTable RenderFromExcel(string strFileName, string sheetName, int headerRowIndex)
        {
            DataTable table = null;
            using (FileStream excelFileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new HSSFWorkbook(excelFileStream);
                ISheet sheet = workbook.GetSheet(sheetName);
                table = RenderFromExcel(sheet, headerRowIndex);
            }
            return table;
        }

        /// <summary>
        /// Excel文档转换成DataTable，默认转换Excel的第一个sheet，第一行必须为标题行
        /// </summary>
        /// <param name="strFileName">Excel文件路径</param>
        /// <returns></returns>
        public static DataTable RenderFromExcel(string strFileName)
        {
            return RenderFromExcel(strFileName, 0, 0);
        }

        /// <summary>
        /// Excel文档转换成DataTable，指定是那个sheet，第一行必须为标题行
        /// </summary>
        /// <param name="excelFileStream">Excel文件路径</param>
        /// <param name="sheetIndex">表索引号，如第一个表为0</param>
        /// <returns></returns>
        public static DataTable RenderFromExcel(string strFileName, int sheetIndex)
        {
            return RenderFromExcel(strFileName, sheetIndex, 0);
        }

        /// <summary>
        /// Excel文档转换成DataTable，指定sheet，指定那一行属于表头
        /// </summary>
        /// <param name="strFileName">Excel文件路径</param>
        /// <param name="sheetIndex">表索引号，如第一个表为0</param>
        /// <param name="headerRowIndex">标题行索引号，如第一行为0</param>
        /// <returns></returns>
        public static DataTable RenderFromExcel(string strFileName, int sheetIndex, int headerRowIndex)
        {
            DataTable table = null;
            try
            {
                using (FileStream excelFileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new HSSFWorkbook(excelFileStream);
                    ISheet sheet = workbook.GetSheetAt(sheetIndex);
                    table = RenderFromExcel(sheet, headerRowIndex);
                }
            }
            catch (Exception ex)
            {
                 throw new Exception("该Excel正被另一程序使用，请关闭后在操作！");
            }
            return table;
        }

        /// <summary>
        /// Excel文档转换成DataTable，指定sheet，指定那一行属于表头
        /// </summary>
        /// <param name="strFileName">Excel文件路径</param>
        /// <param name="sheetIndex">表索引号，如第一个表为0</param>
        /// <returns></returns>
        public static DataSet RenderDataSetFromExcel(string strFileName, int sheetIndex)
        {
            DataSet dataset = new DataSet();
            using (FileStream excelFileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new HSSFWorkbook(excelFileStream);

                DataTable table = null;
                for (int i = 0; i <= sheetIndex; i++)
                {
                    ISheet sheet = workbook.GetSheetAt(i);
                    table = new DataTable();
                    table = RenderFromExcel(sheet, 0);
                    dataset.Tables.Add(table);
                }
            }
            return dataset;
        }

        /// <summary>
        /// 私有：Excel表格转换成DataTable
        /// </summary>
        /// <param name="sheet">表格</param>
        /// <param name="headerRowIndex">标题行索引号，如第一行为0</param>
        /// <returns></returns>
        private static DataTable RenderFromExcel(ISheet sheet, int headerRowIndex)
        {
            IRow headerRow = sheet.GetRow(headerRowIndex);
            if (headerRow == null)
                return new DataTable();//防止空Excel报错

            int cellCount = headerRow.LastCellNum;
            int rowCount = sheet.LastRowNum;
            DataTable table = new DataTable();
            DataColumn column = null;
            try
            {
                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //从第二行开始读取数据
            for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();
                if (row != null)
                {
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = GetCellValue(row.GetCell(j));
                    }
                }

                //如果为空行则循环下一次
                if (IsEmptyDataRow(dataRow,cellCount))
                    continue;

                table.Rows.Add(dataRow);
            }
            return table;
        }
        #endregion

        #region [检验Excel文档流是否有数据，防止execl无值出现错误]
        /// <summary>
        /// Excel文档流是否有数据，防止execl无值出现错误
        /// </summary>
        /// <param name="strFileName">Excel文件路径</param>
        /// <param name="sheetIndex">表索引号，如第一个表为0</param>
        /// <returns></returns>
        public static bool IsHasData(string strFileName, int sheetIndex)
        {
            using (FileStream excelFileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new HSSFWorkbook(excelFileStream);
                if (workbook.NumberOfSheets > 0)
                {
                    if (sheetIndex < workbook.NumberOfSheets)
                    {
                        ISheet sheet = workbook.GetSheetAt(sheetIndex);
                        return sheet.PhysicalNumberOfRows > 0;
                    }
                }
            }
            return false;
        }
        #endregion

        #region [私有方法]
        /// <summary>
        /// 私有：将excel文件流写入文件中
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="fileName"></param>
        private static void SaveToFile(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                MemoryStream ms = new MemoryStream();
                hssfworkbook.Write(ms);
                byte[] data = ms.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Flush();
                data = null;
            }
        }

        /// <summary>
        /// 私有：获取单元格的值
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static string GetCellValue(ICell cell)
        {
            if (cell == null)
                return string.Empty;
            switch (cell.CellType)
            {
                case CellType.BLANK:
                    return string.Empty;
                case CellType.BOOLEAN:
                    return cell.BooleanCellValue.ToString();
                case CellType.ERROR:
                    return cell.ErrorCellValue.ToString();
                case CellType.NUMERIC:
                    if (DateUtil.IsCellDateFormatted(cell))
                        return cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                    else
                        return cell.NumericCellValue.ToString();
                case CellType.Unknown:
                default:
                    return cell.ToString();
                case CellType.STRING:
                    return cell.StringCellValue;
                case CellType.FORMULA:
                    //try
                    //{
                    //    HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                    //    e.EvaluateInCell(cell);
                    //    return cell.ToString();
                    //}
                    //catch
                    //{
                    //    return cell.NumericCellValue.ToString();
                    //}
                    cell.SetCellType(CellType.STRING);
                    return cell.StringCellValue;
            }
        }

        /// <summary>
        /// 判断空行
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnCount"></param>
        /// <returns></returns>
        public static bool IsEmptyDataRow(DataRow dr, int columnCount)
        {
            bool b = false;
            if (dr == null)
            {
                b = true;
                return b;
            }

            if (dr.Table.Columns.Count < columnCount)
            {
                columnCount = dr.Table.Columns.Count;
            }


            int nullCount = 0;
            for (int i = 0; i < columnCount; i++)
            {
                if (dr[i] == null || string.IsNullOrEmpty(dr[i].ToString()) || string.IsNullOrWhiteSpace(dr[i].ToString()))
                {
                    nullCount++;
                }
            }

            if (columnCount == nullCount)
            {
                b = true;
            }
            return b;
        }
        #endregion

        #region [将DataGridView转换成DataTable]
        /// <summary>
        /// 导出Excel方法
        /// </summary>
        /// <param name="grid">DataGridView数据</param>
        /// <param name="sheetname">sheft名称</param>
        /// <param name="outputname">输出的execl名称</param>
        public static void ExportDataGridViewToExcel(DataGridView grid, string sheetname, string outputname)
        {
            DataTable dt = DataGridViewToDataTable(grid, true, false);

            InitializeWorkbook();
            HSSFSheet sheet1 = (HSSFSheet)hssfworkbook.CreateSheet(sheetname);

            HSSFRow row;
            HSSFCell cell;
            HSSFRow rowCap;

            //首先设置表列名称
            rowCap = (HSSFRow)sheet1.CreateRow(0);
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                cell = (HSSFCell)rowCap.CreateCell(j);
                cell.SetCellValue(dt.Columns[j].Caption);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                row = (HSSFRow)sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    cell = (HSSFCell)row.CreateCell(j);
                    cell.SetCellValue(dr[j].ToString());
                }
            }

            //获取当前列的宽度，然后对比本列的长度，取最大值  
            for (int columnNum = 0; columnNum <= dt.Columns.Count; columnNum++)
            {
                int columnWidth = sheet1.GetColumnWidth(columnNum) / 256;
                for (int rowNum = 1; rowNum <= sheet1.LastRowNum; rowNum++)
                {
                    IRow currentRow;
                    //当前行未被使用过  
                    if (sheet1.GetRow(rowNum) == null)
                    {
                        currentRow = sheet1.CreateRow(rowNum);
                    }
                    else
                    {
                        currentRow = sheet1.GetRow(rowNum);
                    }

                    if (currentRow.GetCell(columnNum) != null)
                    {
                        ICell currentCell = currentRow.GetCell(columnNum);
                        int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                        if (columnWidth < length)
                        {
                            columnWidth = length;
                        }
                    }
                }
                sheet1.SetColumnWidth(columnNum, columnWidth * 256);
            }

            SaveToFile(outputname);
        }

        /// <summary>
        /// 将DataGridView转换成DataTable
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="visibleOnly">只导出可见的列</param>
        /// <param name="includeNewRow">是否导出新行</param>
        /// <returns></returns>
        public static DataTable DataGridViewToDataTable(DataGridView grid, bool visibleOnly, bool includeNewRow)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (visibleOnly && !col.Visible)
                {
                    continue;
                }
                string cname = string.Empty;
                cname = GetColumnName(dt, col.HeaderText, 0);
                dt.Columns.Add(cname);
            }
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!includeNewRow && row.IsNewRow)
                {
                    continue;
                }
                object[] obj = new object[dt.Columns.Count];
                int index = 0;
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    if (visibleOnly && !col.Visible)
                    {
                        continue;
                    }

                    obj[index++] = row.Cells[col.Name].Value;
                }
                dt.Rows.Add(obj);
            }
            return dt;
        }

        /// <summary>
        /// 获取列名称
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cname"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static string GetColumnName(DataTable dt, string cname, int index)
        {
            if (dt.Columns.Contains(cname))
            {
                GetColumnName(dt, cname + index, index + 1);
            }
            return cname;
        }
        #endregion
    }
}
