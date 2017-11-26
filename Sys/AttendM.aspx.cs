using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_AttendM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id;
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write(" <script> parent.window.location.href= '../Login.aspx ' </script> ");
        }
        id = Request["id"];
        if (!this.IsPostBack)
        {
            int userId = int.Parse(Session["userId"].ToString().Trim());
            DataTable dt = new DataTable();
            dt = new ProjectInfoData().GetProjectInfoByUserId(userId);
            this.ddlProject.DataSource = dt;
            this.ddlProject.DataTextField = "ProjectName";
            this.ddlProject.DataValueField = "Id";
            this.ddlProject.DataBind();
            if (!string.IsNullOrEmpty(id))
            {
                PageInit(id);
            }
        }
    }

    private void PageInit(string id)
    {
        SurveyInfoData surveyInfoData = new SurveyInfoData();
        SurveyInfo surveyInfo = surveyInfoData.GetSurveyInfoBySurveyId(int.Parse(id.Trim()));
        this.ddlProject.SelectedIndex = this.ddlProject.Items.IndexOf(this.ddlProject.Items.FindByValue(surveyInfo.ProjectInfo.Id + ""));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
}