using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.Web;
using System.Collections;
using System.Diagnostics;

namespace Lyh.Libs.Office
{
    /// <summary>
    /// Description：NPOI帮助类
    /// Author：lyh
    /// Date：2013-10-15
    /// </summary>
    public class NPOIHelper
    {
        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="data">数据表</param>
        /// <param name="fileName">保存文件名</param>
        public static bool Export(DataTable data, string fileName)
        {
            try
            {
                using (MemoryStream ms = GetBaseData(data))
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    {
                        byte[] bytes = ms.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Flush();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 获得文档流
        /// </summary>
        /// <param name="data">数据表</param>
        /// <returns></returns>
        public static MemoryStream GetBaseData(DataTable data)
        {
            return GetBaseData(data, null, null);
        }

        /// <summary>
        /// 获得文档流
        /// </summary>
        /// <param name="data">数据表</param>
        /// <param name="dsi">文档属性信息</param>
        /// <param name="si">属性信息</param>
        /// <returns></returns>
        public static MemoryStream GetBaseData(DataTable data, DocumentSummaryInformation dsi, SummaryInformation si)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            #region 文件属性
            workbook.DocumentSummaryInformation = dsi;
            workbook.SummaryInformation = si;
            #endregion


            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[data.Columns.Count];
            foreach (DataColumn item in data.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding("gb2312").GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding("gb2312").GetBytes(data.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in data.Rows)
            {
                #region 新建表，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 列头及样式
                    IRow headerRow = sheet.CreateRow(0);
                    ICellStyle headStyle = workbook.CreateCellStyle();
                    headStyle.Alignment = HorizontalAlignment.CENTER;
                    IFont font = workbook.CreateFont();
                    font.FontHeightInPoints = 10;
                    font.Boldweight = 700;
                    headStyle.SetFont(font);
                    foreach (DataColumn column in data.Columns)
                    {
                        headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                        headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                        //设置列宽
                        sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                    }
                    #endregion

                    rowIndex = 1;
                }
                #endregion


                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in data.Columns)
                {
                    ICell newCell = dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            if (DateTime.TryParse(drValue, out dateV))
                                newCell.SetCellValue(dateV);
                            else
                                newCell.SetCellValue("");
                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                return ms;
            }
        }

        /// <summary>
        /// 用于Web导出
        /// </summary>
        /// <param name="data">源DataTable</param>
        /// <param name="fileName">文件名</param>
        public static void ExportByWeb(DataTable data, string fileName)
        {
            HttpContext context = HttpContext.Current;

            // 设置编码和附件格式
            context.Response.ContentType = "application/vnd.ms-excel";
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.Charset = "";
            context.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));

            context.Response.BinaryWrite(GetBaseData(data).GetBuffer());
            context.Response.End();
        }

        /// <summary>
        /// 读取excel，默认第一行为标头
        /// </summary>
        /// <param name="fileName">excel文件名</param>
        /// <returns></returns>
        public static DataTable Import(string fileName)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        /// <summary>
        /// 打开文档
        /// </summary>
        /// <param name="fileName"></param>
        public static void OpenFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                Process.Start(fileName);
            }
        }
    }
}