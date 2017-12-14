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
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals("") || Session["roleCode"] == null || Session["roleCode"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }

        if (!this.IsPostBack)
        {
            GridBind();
        }
        
        /*
        if (!Page.IsPostBack)
        {
            this.hfProjectId.Value = Request["id"].Trim();
            GridBind();
        }
        */
    }

    /*
    private void GridBind()
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals("") || Session["roleCode"] == null || Session["roleCode"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }

        int projectId = int.Parse(this.hfProjectId.Value.Trim());
        int userid = int.Parse(Session["userId"].ToString().Trim());
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());

        DataTable dt = new DataTable();
        SurveyInfoData surveyInfoData = new SurveyInfoData();
       dt = surveyInfoData.GetSurveyInfoByUserId(projectId, userid, roleCode);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }*/

    private void GridBind()
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals("") || Session["roleCode"] == null || Session["roleCode"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        int userid = int.Parse(Session["userId"].ToString().Trim());
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        
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
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals("") || Session["roleCode"] == null || Session["roleCode"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        int userid = int.Parse(Session["userId"].ToString().Trim());
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        DataTable dt = new DataTable();
        SurveyInfoData surveyInfoData = new SurveyInfoData();
        //dt = surveyInfoData.GetSurveyInfoByUserIdWithCondition(projectId, userid, roleCode);
        dt = surveyInfoData.GetSurveyInfoByUserIdWithCondition(userid, roleCode,this.txtConditionProjectName.Text.Trim());
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        return;
    }
}