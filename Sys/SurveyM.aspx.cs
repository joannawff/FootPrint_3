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
        string id;
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write(" <script> parent.window.location.href= '../Login.aspx ' </script> ");
        }
        else
        {
            id = Request["id"];
            int userId = int.Parse(Session["userId"].ToString().Trim());
            DataTable dt = new DataTable();
            dt = new ProjectInfoData().GetProjectInfoByUserId(userId);
            this.ddlProject.DataSource = dt;
            this.ddlProject.DataTextField = "ProjectName";
            this.ddlProject.DataValueField = "Id";
            this.ddlProject.DataBind();
            PageInit(userId);
        }
        if (!Page.IsPostBack)
        {
            id = Request["id"];
            int userId = int.Parse(Session["userId"].ToString().Trim());
            DataTable dt = new DataTable();
            dt = new ProjectInfoData().GetProjectInfoByUserId(userId);
            this.ddlProject.DataSource = dt;
            this.ddlProject.DataTextField = "ProjectName";
            this.ddlProject.DataValueField = "Id";
            this.ddlProject.DataBind();
            PageInit(userId);
        }
    }

    private void PageInit(int userId)
    {
        this.ParentList.DataSource = this.GetSurveyInfoByUserId(userId);
        this.ParentList.DataBind();
    }

    private DataTable GetSurveyInfoByUserId(int userId)
    {
        SurveyInfoData surveyInfoData = new SurveyInfoData();
        DataTable dt = surveyInfoData.GetSurveyInfoByUserId(userId);
        return dt;
    }

    protected void ParentList_OnItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label labSurveyDate = (Label)e.Item.FindControl("labSurveyDate");
            String surveyDate = Convert.ToDateTime(labSurveyDate.Text.Trim()).ToString("yyyy-MM-dd");
            labSurveyDate.Text = surveyDate;
            if (surveyDate.Equals("1999-01-01"))
                labSurveyDate.Text = "-";
            DataList ChildList = (DataList)e.Item.FindControl("ChildList");
            Label labSurveyId = (Label)e.Item.FindControl("labSurveyId");
            int surveyId = int.Parse(labSurveyId.Text.Trim());
            SurveyDetailData detailData = new SurveyDetailData();
            DataTable dt = detailData.GetSurveyDetailBySurveyId(surveyId);

            ChildList.DataSource = dt;
            ChildList.DataBind();
        }
        
    }

    protected void ChildList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label labOffTime = (Label)e.Item.FindControl("labOffTime");
            DateTime offTime = Convert.ToDateTime(labOffTime.Text.Trim());
            String surveyDate = offTime.ToString("yyyy-MM-dd");
            if (surveyDate.Equals("1999-01-01"))
                labOffTime.Text = "-";
            else
                labOffTime.Text = offTime.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}