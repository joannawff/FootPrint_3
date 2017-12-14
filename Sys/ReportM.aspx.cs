using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.ExcelEdit;

public partial class Sys_ReportM : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        if (!this.IsPostBack)
        {
            GridBind();
        }
    }

    private void GridBind()
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals("") || Session["roleCode"] == null || Session["roleCode"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        int useId = int.Parse(Session["userId"].ToString().Trim());
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        DataTable dt = new DataTable();
        ProjectInfoData projectInfoData = new ProjectInfoData();
        dt = projectInfoData.GetProjectInfoByUserId(useId, roleCode);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int projectId = int.Parse(e.CommandArgument.ToString().Trim());
        ProjectInfoData projectInfoData = new ProjectInfoData();
        string projectName = projectInfoData.GetProjectNameByProjectId(projectId);
        switch (e.CommandName)
        {
            case "printSurvey":
                try
                {
                    bool result = printSurveyReport(projectId, projectName);
                    if (result)
                    {
                        this.Alert("下载成功！", MessageType.Succeed);
                    }
                    else
                    {
                        this.Alert("该项目尚无勘测日志！", MessageType.Error11);
                    }
                }
                catch (Exception ex)
                {
                    this.Alert("出错，下载失败！", MessageType.Error11);
                    return;
                }
                break;
            case "printAttend":
                try
                {
                    bool result = printAttendReport(projectId, projectName);
                    if (result)
                    {
                        this.Alert("下载成功！", MessageType.Succeed);

                    }
                    else
                    {
                        this.Alert("该项目尚无考勤日志！", MessageType.Error11);
                    }
                }
                catch (Exception ex)
                {
                    this.Alert("出错，下载失败！", MessageType.Error11);
                    return;
                }
                break;
        }
        GridBind();
    }

    protected bool printSurveyReport(int projectId, string projectName)
    {
        SurveyDetailInfoData surveyDetailInfoData = new SurveyDetailInfoData();
        DataTable dt = new DataTable();
        //dt = surveyDetailInfoData.GetSurveyDetailByProjectId(projectId);

        dt = surveyDetailInfoData.GetSurveyReportByProjectId(projectId);

        if (dt.Rows.Count == 0)
        {
            return false;
        }

        const int columnCount = 14;
        string[] head = new string[columnCount]{"项目名称", " 勘测任务", "勘测日期", "组长兼安全员",
                                                "工作项目","组员","计划","实际",
                                                "收工时间","整理资料","整理人员","使用仪器及设备号",
                                                "用车记录","备注"};

        //string projectName = dt.Rows[0]["ProjectName"].ToString();
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + projectName + "勘测日志" + System.DateTime.Now.ToString("yyyyMMdd") + ".xls";
        string sheetName = "SurveyReport";

        ExcelHelper excelHelper = new ExcelHelper();
        excelHelper.WriteExcel(dt, projectName, filePath, head);
        return true;
    }

    //protected void printSurveyReport(int projectId)
    //{
    //    SurveyDetailInfoData surveyDetailInfoData = new SurveyDetailInfoData();
    //    DataTable dt = new DataTable();
    //    //dt = surveyDetailInfoData.GetSurveyDetailByProjectId(projectId);

    //    dt = surveyDetailInfoData.GetSurveyReportByProjectId(projectId);

    //    const int columnCount = 12;
    //    string[] head = new string[columnCount]{"标题","组长兼安全员","工作项目","组员",
    //                                    "计划","实际","收工时间","整理资料","整理人员",
    //                                    "使用仪器及设备号","用车记录","备注"};

    //    string projectName = dt.Rows[0]["ProjectName"].ToString();
    //    string fileName = projectName + System.DateTime.Now.ToString("yyyyMMdd") + ".xls";
    //    string sheetName = "SurveyReport";

    //    ExcelEdit excelEdit = new ExcelEdit();
    //    //excelEdit.Create(); //创建一个Microsoft.Office.Interop.Excel对象
    //    excelEdit.Open(fileName); //打开一个Microsoft.Office.Interop.Excel文件
    //    Excel.Worksheet ws = excelEdit.AddSheet(sheetName); //添加一个工作表

    //    //设置表头
    //    for(int col = 0; col < dt.Columns.Count; col++)
    //    {
    //        excelEdit.SetCellValue(ws,0,col,head[col]);
    //    }

    //    //插入数据
    //    excelEdit.InsertTable(dt, ws, 1, 0);
    //    excelEdit.SaveAs(fileName);
    //    excelEdit.Close();

    //    //ToExcel(columnCount, head, dt);

    //    /*
    //    SurveyInfoData surveyInfoData = new SurveyInfoData();
    //    DataTable surveyDt = new DataTable();
    //    surveyDt = surveyInfoData.GetSurveyInfoByProjectId(projectId);
    //    List<DataTable> dtList = new List<DataTable>();

    //    foreach (DataRow row in surveyDt.Rows)
    //    {
    //        int surveyId = int.Parse(row["Id"].ToString());

    //        SurveyDetailInfoData surveyDetailInfoData = new SurveyDetailInfoData();
    //        DataTable surveyDetailDt = new DataTable();
    //        surveyDetailDt = surveyDetailInfoData.GetSurveyDetailBySurveyId(surveyId);
    //        dtList.Add(surveyDetailDt);
    //    }

    //    ToExcel(dtList[0]);
    //    */
    //    return;
    //}

    protected bool printAttendReport(int projectId, string projectName)
    {
        AttendInfoData attendInfoData = new AttendInfoData();
        DataTable attendDt = new DataTable();
        attendDt = attendInfoData.GetAttendInfoByProjectId(projectId);

        if (attendDt.Rows.Count == 0)
        {
            return false;
        }

        
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + projectName + "考勤日志" + System.DateTime.Now.ToString("yyyyMMdd") + ".xls";
        ExcelHelper excelHelper = new ExcelHelper();

        excelHelper.AttendToExcel(attendDt, projectName, filePath);

        return true;
    }

    public void ToExcel(int columnCount, string[] head, DataTable dt)
    {
        string sourceFile = @"";
        string targetFile = @"";

        Excel.Application xApp = null; //创建excel应用程序
        Excel.Workbook xBook = null; //工作簿
        Excel.Worksheet xSheet = null; //工作簿中创建工作表
        bool PrintNote = false;
        try
        {
            //xApp = new Excel.ApplicationClass();
            //xBook = xApp.Workbooks.Open(targetFile,
            //                            Type.Missing,
            //                            Type.Missing,
            //                            Type.Missing,
            //                            Type.Missing,
            //                            Type.Missing,
            //                            Type.Missing,
            //                            Type.Missing,
            //                            Type.Missing,
            //                            Type.Missing,
            //                            Type.Missing,
            //                            Type.Missing,
            //                            Type.Missing);
            //xSheet = (Excel.Worksheet)xBook.Sheets[1];
            //xSheet.Name = "勘测日志";
            //string temp = "";
            //if (dt.Columns.Count < 26)
            //{
            //    temp = ((char)('A' + dt.Columns.Count)).ToString();
            //}
            //else if (dt.Columns.Count <= 26 + 26 * 26)
            //{
            //    temp = ((char)('A' + (dt.Columns.Count - 26) / 26)).ToString()
            //            + ((char)('A' + (dt.Columns.Count - 26)) % 26).ToString();
            //}
            //else
            //{
            //    throw new Exception("列数过多");
            //}

            //xSheet.get_Range("A" + 1);
            for (int i = 0; i < columnCount; i++)
            {
                //设置表头
                Excel.Range headRange = xSheet.Cells[1, i + 1] as Excel.Range;
                headRange.Value2 = head[i]; // 设置单元格文本
                headRange.Font.Name = "宋体"; //设置字体
                headRange.Font.Size = 12;
                headRange.Font.Bold = false;
                headRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//水平居中
                headRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;//垂直居中

                //设置每列格式
                Excel.Range contentRange = xSheet.get_Range(xSheet.Cells[2, i+1], xSheet.Cells[dt.Rows.Count - 1 + 3, i+1]);
                contentRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                contentRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                contentRange.WrapText = true; //自动换行
                contentRange.NumberFormat = "@"; //文本格式
            }


            //填充数据
            //InsertTableToSheet();

        }
        catch
        {
            return;
        }
    }

    // 将dt插入到工作表的指定位置中
    public void InsertTableToSheet(DataTable dt, Excel.Worksheet ws, int startX, int startY)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int j = 0; j < dt.Columns.Count - 1; j++)
            {
                ws.Cells[startX + 1, j + startY] = dt.Rows[i][j];
            }
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals("") || Session["roleCode"] == null || Session["roleCode"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        int useId = int.Parse(Session["userId"].ToString().Trim());
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        DataTable dt = new DataTable();
        ProjectInfoData projectInfoData = new ProjectInfoData();
        dt = projectInfoData.GetProjectInfoByUserIdWithCondition(useId, roleCode, this.txtConditionProjectName.Text.Trim());
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

}