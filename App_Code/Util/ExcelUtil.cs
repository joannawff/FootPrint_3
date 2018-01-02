﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Data;
using NPOI.HSSF.Util;

/// <summary>
/// ExcelUtil 的摘要说明
/// </summary>
public class ExcelUtil
{
    IWorkbook workbook;//Workbook对象 

    //构造函数
    public ExcelUtil()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        workbook = new HSSFWorkbook(); //初始化Workbook
    }

    // 创建勘测日志报表
    public void GenSurveySheet(DataTable dt, string projectName, string[] head, string sheetName)
    {
        if (null != dt && dt.Rows.Count > 0)
        {
            //创建sheet
            ISheet sheet = workbook.CreateSheet(sheetName);
            IRow row = sheet.CreateRow(0);

            for (int i = 0; i < head.Length; i++)
            {
                //row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                row.CreateCell(i).SetCellValue(head[i]);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(i + 1);
                //
                row2.CreateCell(0).SetCellValue(projectName);
                row2.CreateCell(1).SetCellValue(Convert.ToString(dt.Rows[i]["Title"]));
                row2.CreateCell(2).SetCellValue(Convert.ToString(dt.Rows[i]["SurveyDate"]));
                row2.CreateCell(3).SetCellValue(Convert.ToString(dt.Rows[i]["LeaderAndSecurityOfficer"]));
                row2.CreateCell(4).SetCellValue(Convert.ToString(dt.Rows[i]["ProjectDetail"]));
                row2.CreateCell(5).SetCellValue(Convert.ToString(dt.Rows[i]["Members"]));
                row2.CreateCell(6).SetCellValue(Convert.ToString(dt.Rows[i]["Plan"]));
                row2.CreateCell(7).SetCellValue(Convert.ToString(dt.Rows[i]["Actual"]));
                row2.CreateCell(8).SetCellValue(Convert.ToString(dt.Rows[i]["OffTime"]));
                row2.CreateCell(9).SetCellValue(Convert.ToString(dt.Rows[i]["SortData"]));
                row2.CreateCell(10).SetCellValue(Convert.ToString(dt.Rows[i]["SortDataParticipants"]));
                row2.CreateCell(11).SetCellValue(Convert.ToString(dt.Rows[i]["Device"]));
                row2.CreateCell(12).SetCellValue(Convert.ToString(dt.Rows[i]["VehicleRecord"]));
                row2.CreateCell(13).SetCellValue(Convert.ToString(dt.Rows[i]["Remark"]));
            }
        }
    }

    // 创建考勤日志报表
    public void GenAttendSheet(DataTable dt, string projectName, string sheetName)
    {
        if (null != dt && dt.Rows.Count > 0)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);

            int startRow = 0;

            foreach (DataRow attendRow in dt.Rows)
            {
                int attendId = int.Parse(attendRow["Id"].ToString());
                DateTime startDate = DateTime.Parse(attendRow["StartDate"].ToString());
                int curMonth = startDate.Month;
                DateTime endDate = DateTime.Parse(attendRow["EndDate"].ToString());
                string title = projectName + startDate.Year.ToString() + "年" + curMonth.ToString() + "月考勤表";

                AttendDetailInfoData attendDetailInfoData = new AttendDetailInfoData();
                DataTable detailDt = new DataTable();
                detailDt = attendDetailInfoData.GetAttendDetailInfoByAttendanceId(attendId);

                //插入标题
                #region 练习合并单元格
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(startRow, startRow, 0, 3 + endDate.Subtract(startDate).Days));
                //CellRangeAddress（）该方法的参数次序是：开始行号，结束行号，开始列号，结束列号。

                IRow row0 = sheet.CreateRow(startRow);
                row0.Height = 20 * 20;
                ICell icell1top0 = row0.CreateCell(startRow);
                icell1top0.CellStyle = Getcellstyle(workbook, stylexls.头);
                icell1top0.SetCellValue(title);
                startRow++;
                #endregion

                //插入表头
                NPOI.SS.UserModel.IRow row1 = sheet.CreateRow(startRow++);
                row1.CreateCell(0).SetCellValue("序号");
                row1.CreateCell(1).SetCellValue("姓名");
                row1.CreateCell(2).SetCellValue("代码");
                int headColIndex = 3;
                for (DateTime colDate = startDate; colDate <= endDate; colDate = colDate.AddDays(1))
                {
                    row1.CreateCell(headColIndex++).SetCellValue(colDate.Day);
                }

                //插入数据
                for (int i = 0; i < detailDt.Rows.Count; i++)
                {
                    NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(startRow++);
                    int j = 0;

                    //前三列
                    row2.CreateCell(j++).SetCellValue(Convert.ToString(i)); // 序号
                    UserInfoData userInfoData = new UserInfoData();
                    UserInfo userInfo = new UserInfo();
                    userInfo = userInfoData.GetUserInfoByUserId(int.Parse(detailDt.Rows[i]["UserId"].ToString()));
                    row2.CreateCell(j++).SetCellValue(userInfo.UserName); //姓名
                    row2.CreateCell(j++).SetCellValue(userInfo.Code); //代码

                    for (DateTime tt = startDate; tt <= endDate; tt = tt.AddDays(1))
                    {
                        string date = tt.Day >= 10 ? tt.Day.ToString() : "0" + tt.Day.ToString();
                        int month = tt.Month;
                        if (month == curMonth)
                        {
                            row2.CreateCell(j++).SetCellValue(Convert.ToString(detailDt.Rows[i]["curMonthDay" + date]));
                        }
                        else
                        {
                            row2.CreateCell(j++).SetCellValue(Convert.ToString(detailDt.Rows[i]["nextMonthDay" + date]));
                        }
                    }
                }
                startRow++;
            }
        }
    }

    public void DownloadFile(string filePath)
    {
        if(!string.IsNullOrEmpty(filePath))
        { 
            // 写入到客户端  
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                workbook.Write(ms);
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
                workbook = null;
            }
        }
    }

    #region 定义单元格常用到样式的枚举
    public enum stylexls
    {
        头,
        url,
        时间,
        数字,
        钱,
        百分比,
        中文大写,
        科学计数法,
        默认
    }
    #endregion

    #region
    static ICellStyle Getcellstyle(IWorkbook wb, stylexls str)
    {
        ICellStyle cellStyle = wb.CreateCellStyle();

        //定义几种字体  
        //也可以一种字体，写一些公共属性，然后在下面需要时加特殊的  
        IFont font12 = wb.CreateFont();
        font12.FontHeightInPoints = 10;
        font12.FontName = "微软雅黑";


        IFont font = wb.CreateFont();
        font.FontName = "微软雅黑";
        //font.Underline = 1;下划线  


        IFont fontcolorblue = wb.CreateFont();
        fontcolorblue.Color = NPOI.HSSF.Util.HSSFColor.OliveGreen.Blue.Index;
        fontcolorblue.IsItalic = true;//下划线  
        fontcolorblue.FontName = "微软雅黑";


        //边框  
        cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Dotted;
        cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Hair;
        cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Hair;
        cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Dotted;
        //边框颜色  
        cellStyle.BottomBorderColor = HSSFColor.OliveGreen.Blue.Index;
        cellStyle.TopBorderColor = HSSFColor.OliveGreen.Blue.Index;

        //背景图形，我没有用到过。感觉很丑  
        //cellStyle.FillBackgroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;  
        //cellStyle.FillForegroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;  
        cellStyle.FillForegroundColor = HSSFColor.White.Index;
        // cellStyle.FillPattern = FillPatternType.NO_FILL;  
        cellStyle.FillBackgroundColor = HSSFColor.Blue.Index;

        //水平对齐  
        cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

        //垂直对齐  
        cellStyle.VerticalAlignment = VerticalAlignment.Center;

        //自动换行  
        cellStyle.WrapText = true;

        //缩进;当设置为1时，前面留的空白太大了。希旺官网改进。或者是我设置的不对  
        cellStyle.Indention = 0;

        //上面基本都是设共公的设置  
        //下面列出了常用的字段类型  
        switch (str)
        {
            case stylexls.头:
                // cellStyle.FillPattern = FillPatternType.LEAST_DOTS;  
                cellStyle.SetFont(font12);
                break;
            case stylexls.时间:
                IDataFormat datastyle = wb.CreateDataFormat();

                cellStyle.DataFormat = datastyle.GetFormat("yyyy/mm/dd");
                cellStyle.SetFont(font);
                break;
            case stylexls.数字:
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                cellStyle.SetFont(font);
                break;
            case stylexls.钱:
                IDataFormat format = wb.CreateDataFormat();
                cellStyle.DataFormat = format.GetFormat("￥#,##0");
                cellStyle.SetFont(font);
                break;
            case stylexls.url:
                //fontcolorblue.Underline = 1;
                //cellStyle.SetFont(fontcolorblue);
                break;
            case stylexls.百分比:
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
                cellStyle.SetFont(font);
                break;
            case stylexls.中文大写:
                IDataFormat format1 = wb.CreateDataFormat();
                cellStyle.DataFormat = format1.GetFormat("[DbNum2][$-804]0");
                cellStyle.SetFont(font);
                break;
            case stylexls.科学计数法:
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00E+00");
                cellStyle.SetFont(font);
                break;
            case stylexls.默认:
                cellStyle.SetFont(font);
                break;
        }
        return cellStyle;
    }
    #endregion
}