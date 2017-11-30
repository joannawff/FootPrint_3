using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sys_SurveyDetailO : BasePage
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
            this.hfSurveyId.Value = Request["surveyId"];
            int userId = int.Parse(Session["userId"].ToString().Trim());
            for (int i = 0; i < 24; i++) { this.ddlHour.Items.Add(i + ""); }
            for (int i = 0; i < 60; i++) { this.ddlMinute.Items.Add(i + ""); }
            for (int i = 0; i < 60; i++) { this.ddlSecond.Items.Add(i + ""); }
            if (!string.IsNullOrEmpty(id))
            {
                PageInit(id);
            }
        }
    }

    private void PageInit(string id)
    {
        SurveyDetailInfoData surveyDetailData = new SurveyDetailInfoData();
        SurveyDetailInfo surveyDetailInfo = surveyDetailData.GetSurveyDetailInfoBySurveyDetailId(int.Parse(id.Trim()));
        this.txtLeaderAndSecurityOfficer.Text = surveyDetailInfo.LeaderAndSecurityOfficer.Trim();
        this.txtProjectDetail.Text = surveyDetailInfo.ProjectDetail;
        this.txtMembers.Text = surveyDetailInfo.Members;
        this.txtPlan.Text = surveyDetailInfo.Plan;
        this.txtActual.Text = surveyDetailInfo.Actual;
        DateTime offtime = surveyDetailInfo.OffTime;
        if (offtime.ToString("yyyy-MM-dd").Equals("1999-01-01"))
        {
            this.txtOffTime.Text = "";
        }
        else
        {
            this.txtOffTime.Text = offtime.ToString("yyyy-MM-dd");
        }
        this.ddlHour.SelectedIndex = offtime.Hour;
        this.ddlMinute.SelectedIndex = offtime.Minute;
        this.ddlMinute.SelectedIndex = offtime.Second;
        this.txtSortData.Text = surveyDetailInfo.SortData;
        this.txtSortDataParticipants.Text = surveyDetailInfo.SortDataParticipants;
        this.txtDevice.Text = surveyDetailInfo.Device;
        this.txtVehicleRecord.Text = surveyDetailInfo.VehicleRecord;
        this.txtRemark.Text = surveyDetailInfo.Remark;
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        SurveyDetailInfo surveyDetailInfo = new SurveyDetailInfo();

        if (!string.IsNullOrEmpty(id))
        {
            surveyDetailInfo.Id = int.Parse(id.Trim());
        }
        surveyDetailInfo.LeaderAndSecurityOfficer = this.txtLeaderAndSecurityOfficer.Text.Trim();
        SurveyInfo surveyInfo = new SurveyInfo();
        surveyInfo.Id = int.Parse(this.hfSurveyId.Value.Trim());
        surveyDetailInfo.SurveyInfo = surveyInfo;
        surveyDetailInfo.ProjectDetail = this.txtProjectDetail.Text.Trim();
        surveyDetailInfo.Members = this.txtMembers.Text.Trim();
        surveyDetailInfo.Plan = this.txtPlan.Text.Trim();
        surveyDetailInfo.Actual = this.txtActual.Text.Trim();
        if (!this.txtOffTime.Text.Trim().Equals(""))
        {
            String[] date = this.txtOffTime.Text.Trim().Split('-');
            int year = int.Parse(date[0]);
            int month = int.Parse(date[1]);
            int day = int.Parse(date[2]);
            int hour = int.Parse(this.ddlHour.SelectedValue.Trim());
            int minute = int.Parse(this.ddlMinute.SelectedValue.Trim());
            int second = int.Parse(this.ddlSecond.SelectedValue.Trim());
            DateTime offtime = new DateTime(year, month, day, hour, minute, second);
            surveyDetailInfo.OffTime = offtime;
        }
        else
        {
            DateTime offtime = new DateTime(1999, 1, 1);
            surveyDetailInfo.OffTime = offtime;
        }
        surveyDetailInfo.SortData = this.txtSortData.Text.Trim();
        surveyDetailInfo.SortDataParticipants = this.txtSortDataParticipants.Text.Trim();
        surveyDetailInfo.Device = this.txtDevice.Text.Trim();
        surveyDetailInfo.VehicleRecord = this.txtVehicleRecord.Text.Trim();
        surveyDetailInfo.Remark = this.txtRemark.Text.Trim();
        SurveyDetailInfoData surveyDetailData = new SurveyDetailInfoData();
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