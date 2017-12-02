using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sys_SurveyM : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
        }
        if (!this.IsPostBack)
        {
            GridBind();
        }
    }


    private void GridBind()
    {
        int userid = int.Parse(Session["userId"].ToString().Trim());
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        /*
        if(roleCode>=2)//不是管理员或者项目负责人
        {
            this.Alert("权限不足。", "../IndexRight.aspx", MessageType.Warning);
            this.panelClose.Visible = true;
            return;
        }
        */
        DataTable dt = new DataTable();
        SurveyInfoData surveyInfoData = new SurveyInfoData();
        dt = surveyInfoData.GetSurveyInfoByUserId(userid, roleCode);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].Text = Convert.ToDateTime(e.Row.Cells[3].Text).ToString("yyyy-MM-dd");
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "del":
                try
                {
                    int surveyId = int.Parse(e.CommandArgument.ToString().Trim());
                    SurveyInfoData surveyInfoData = new SurveyInfoData();
                    surveyInfoData.DeleteSurveyInfo(surveyId);
                    this.Alert("删除成功！", MessageType.Succeed);
                }
                catch (Exception ex)
                {
                    this.Alert("删除失败！", MessageType.Error11);
                    return;
                }
                break;
        }
        GridBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        int userid = int.Parse(Session["userId"].ToString().Trim());
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        DataTable dt = new DataTable();
        SurveyInfoData surveyInfoData = new SurveyInfoData();
        dt = surveyInfoData.GetSurveyInfoByUserIdWithCondition(userid, roleCode,this.txtConditionProjectName.Text.Trim());
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}