using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sys_SurveyO : BasePage
{
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write(" <script> parent.window.location.href= '../Login.aspx ' </script> ");
            return;
        }
        id = Request["id"];
        if (!this.IsPostBack)
        {
            int userId = int.Parse(Session["userId"].ToString().Trim());
            int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
            DataTable dt = new DataTable();
            dt = new ProjectInfoData().GetProjectInfoByUserId(userId,roleCode);
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
        this.Title.Text = surveyInfo.Title.Trim();
        this.SurveyDate.Text = surveyInfo.SurveyDate.ToString("yyyy-MM-dd");
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        SurveyInfo surveyInfo = new SurveyInfo();
        if (!string.IsNullOrEmpty(id))
        {
            surveyInfo.Id = int.Parse(id.Trim());
        }
        surveyInfo.Title = this.Title.Text.Trim();
        String[] date = this.SurveyDate.Text.Split('-');
        surveyInfo.SurveyDate = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]))
; ProjectInfo p = new ProjectInfo();
        p.Id = int.Parse(this.ddlProject.SelectedItem.Value.Trim());
        surveyInfo.ProjectInfo = p;
        SurveyInfoData surveyInfoData = new SurveyInfoData();
        //try
        //{
        surveyInfoData.CommitSurveyInfo(surveyInfo);
        if (string.IsNullOrEmpty(id))
        {
            this.Alert("增项信息添加完成，请继续添加。", "SurveyRegisterO.aspx", MessageType.Succeed);
        }
        else
        {
            this.Alert("增项信息修改完成。", "SurveyRegisterM.aspx", MessageType.Succeed);

        }
        this.panelClose.Visible = true;
        /*}
        catch (Exception ex)
        {
            this.Alert(ex.Message, MessageType.Error11);
        }*/
    }
}