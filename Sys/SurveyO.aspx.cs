using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sys_SurveyO : BasePage
{
    String id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write(" <script> parent.window.location.href= '../Login.aspx ' </script> ");
        }
        id = Request["id"];
        if (!this.IsPostBack)
        {
            int userId = int.Parse(Session["userId"].ToString().Trim());
            for(int i = 0; i < 24; i++) { this.ddlHour.Items.Add(i + ""); }
            for (int i = 0; i < 60; i++) { this.ddlMinute.Items.Add(i + ""); }
            for (int i = 0; i < 60; i++) { this.ddlSecond.Items.Add(i + ""); }
            SurveyInfoData surveyInfoData = new SurveyInfoData();
            DataTable dt = surveyInfoData.GetSurveyInfoByUserId(userId);
            this.ddlSurvey.DataTextField = "FullTitle";
            this.ddlSurvey.DataValueField = "Id";
            this.ddlSurvey.DataSource = dt;
            this.ddlSurvey.DataBind();
            if (!string.IsNullOrEmpty(id))
            {
                PageInit(id);
            }
        }
    }

    private void PageInit(string id)
    {
        SurveyDetailData surveyDetailData = new SurveyDetailData();
        SurveyDetailInfo surveyDetailInfo = surveyDetailData.GetSurveyDetailInfoBySurveyDetailId(int.Parse(id.Trim()));
        this.lableader.Text = surveyDetailInfo.LeaderAndSecurityOfficer;
        this.ddlSurvey.SelectedIndex = this.ddlSurvey.Items.IndexOf(this.ddlSurvey.Items.FindByValue(surveyDetailInfo.SurveyInfo.Id + ""));
        this.labProjectDetail.Text = surveyDetailInfo.ProjectDetail;
        this.labMembers.Text = surveyDetailInfo.Members;
        this.labPlan.Text = surveyDetailInfo.Plan;
        this.labActual.Text = surveyDetailInfo.Actual;
        DateTime offtime = surveyDetailInfo.OffTime;
        if (offtime.ToString("yyyy-MM-dd").Equals("1999-01-01")){
            this.labOffTime.Text = "";
        }else{ 
            this.labOffTime.Text = offtime.ToString("yyyy-MM-dd");
        }
        this.ddlHour.SelectedIndex = offtime.Hour;
        this.ddlMinute.SelectedIndex = offtime.Minute;
        this.ddlMinute.SelectedIndex = offtime.Second;
        this.labSortData.Text = surveyDetailInfo.SortData;
        this.labSortDataParticipants.Text = surveyDetailInfo.SortDataParticipants;
        this.labDevice.Text = surveyDetailInfo.Device;
        this.labVehicleRecord.Text = surveyDetailInfo.VehicleRecord;
        this.labRemark.Text = surveyDetailInfo.Remark;
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        SurveyDetailInfo surveyDetailInfo = new SurveyDetailInfo();

        if (!string.IsNullOrEmpty(id))
        {
            surveyDetailInfo.Id = int.Parse(id.Trim());
        }
        surveyDetailInfo.LeaderAndSecurityOfficer = this.lableader.Text.Trim();
        SurveyInfo surveyInfo = new SurveyInfo();
        surveyInfo.Id = int.Parse(this.ddlSurvey.SelectedValue.Trim());
        surveyDetailInfo.SurveyInfo = surveyInfo;
        surveyDetailInfo.ProjectDetail = this.labProjectDetail.Text.Trim();
        surveyDetailInfo.Members = this.labMembers.Text.Trim();
        surveyDetailInfo.Plan = this.labPlan.Text.Trim();
        surveyDetailInfo.Actual = this.labActual.Text.Trim();
        if (!this.labOffTime.Text.Trim().Equals(""))
        {
            String[] date = this.labOffTime.Text.Trim().Split('-');
            int year = int.Parse(date[0]);
            int month = int.Parse(date[1]);
            int day = int.Parse(date[2]);
            int hour = int.Parse(this.ddlHour.SelectedValue.Trim());
            int minute = int.Parse(this.ddlMinute.SelectedValue.Trim());
            int second = int.Parse(this.ddlSecond.SelectedValue.Trim());
            DateTime offtime = new DateTime(year, month, day, hour, minute, second);
            surveyDetailInfo.OffTime = offtime;
        }
        else {
            DateTime offtime = new DateTime(1999, 1, 1);
            surveyDetailInfo.OffTime = offtime;
        }
        surveyDetailInfo.SortData = this.labSortData.Text.Trim();
        surveyDetailInfo.SortDataParticipants = this.labSortDataParticipants.Text.Trim();
        surveyDetailInfo.Device = this.labDevice.Text.Trim();
        surveyDetailInfo.VehicleRecord = this.labVehicleRecord.Text.Trim();
        surveyDetailInfo.Remark = this.labRemark.Text.Trim();
        SurveyDetailData surveyDetailData = new SurveyDetailData();
        //try
        //{
        surveyDetailData.CommitProjectInfo(surveyDetailInfo);

            if (string.IsNullOrEmpty(id))
            {
                this.Alert("增项信息添加完成，请继续添加。", "SurveyO.aspx", MessageType.Succeed);
            }
            else
            {
                this.Alert("增项信息修改完成。", "SurveyM.aspx", MessageType.Succeed);

            }
            this.panelClose.Visible = true;
        /*}
        catch (Exception ex)
        {
            this.Alert(ex.Message, MessageType.Error11);
        }*/
    }
}