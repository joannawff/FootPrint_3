using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sys_SurveyDetailM : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userId = 0;
        int roleCode = 0;
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
        if (!Page.IsPostBack)
        {
            DropDownListBind(userId,roleCode);
            this.hfSurveyId.Value = Request["id"].Trim();
        }
        GridBind();
    }

    private void DropDownListBind(int userId,int roleCode)
    {
        DataTable dt = new DataTable();
        dt = new ProjectInfoData().GetProjectInfoByUserId(userId, roleCode);
        this.ddlProject.DataSource = dt;
        this.ddlProject.DataTextField = "ProjectName";
        this.ddlProject.DataValueField = "Id";
        this.ddlProject.DataBind();
    }

    private void GridBind()
    {
        SurveyDetailInfoData surveyDetailInfoData = new SurveyDetailInfoData();
        DataTable dt = new DataTable();
        dt = surveyDetailInfoData.GetSurveyDetailBySurveyId(int.Parse(this.hfSurveyId.Value.Trim()));
        this.DataList.DataSource = dt;
        this.DataList.DataBind();
    }

    protected void DataList_OnItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label labOffTime = (Label)e.Item.FindControl("labOffTime");
            String offTime = Convert.ToDateTime(labOffTime.Text.Trim()).ToString("yyyy-MM-dd hh:mm:ss");
            labOffTime.Text = offTime;
            if (offTime.Equals("1999-01-01 00:00:00"))
                labOffTime.Text = "-";
        }

    }
}