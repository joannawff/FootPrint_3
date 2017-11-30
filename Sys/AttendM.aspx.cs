using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_AttendM : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userId;
        int roleCode;
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write(" <script> parent.window.location.href= '../Login.aspx ' </script> ");
            return;
        }
        else
        {
            userId = int.Parse(Session["userId"].ToString().Trim());
            roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        }
        if (!IsPostBack)
        {
            ProjectInfoData projectInfoData = new ProjectInfoData();
            DataTable dt = projectInfoData.GetProjectInfoByUserId(userId,roleCode);
            this.ddlProject.DataSource = dt;
            this.ddlProject.DataTextField = "ProjectName";
            this.ddlProject.DataValueField = "Id";
            this.ddlProject.DataBind();
        }
        GridBind();
    }

    private void GridBind()
    {
        int userId = 0;
        userId = int.Parse(Session["userId"].ToString().Trim());
        DataTable dt = new DataTable();
        AttendInfoData attendInfoData = new AttendInfoData();
        dt = attendInfoData.GetAttendInfosByUserId(userId);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        AttendInfoData attendInfo = new AttendInfoData();
        String[] date = this.StartDateTxt.Text.Split('-');

        //surveyInfo.SurveyDate = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]))

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].Text = Convert.ToDateTime(e.Row.Cells[3].Text).ToString("yyyy-MM-dd");
            e.Row.Cells[4].Text = Convert.ToDateTime(e.Row.Cells[4].Text).ToString("yyyy-MM-dd");
        }
    }
}