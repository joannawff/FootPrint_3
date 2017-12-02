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
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        if (!Page.IsPostBack)
        {
            this.hfSurveyId.Value = Request["id"].Trim();
            GridBind();
        }
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

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        SurveyDetailInfoData surveyDetailInfoData = new SurveyDetailInfoData();
        DataTable dt = new DataTable();
        dt = surveyDetailInfoData.GetSurveyDetailBySurveyIdWithCondition(int.Parse(this.hfSurveyId.Value.Trim()), this.txtConditionLeaderName.Text.Trim());
        this.DataList.DataSource = dt;
        this.DataList.DataBind();
    }

    protected void DataList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if(e.CommandName=="del")
        {
            try
            {
                int surveyDetailId = int.Parse(this.DataList.DataKeys[e.Item.ItemIndex].ToString().Trim());
                SurveyDetailInfoData surveyDetailInfoData = new SurveyDetailInfoData();
                surveyDetailInfoData.DeleteSurveyDetailInfo(surveyDetailId);
                this.Alert("删除成功！", MessageType.Succeed);
                GridBind();
            }
            catch (Exception ex)
            {
                this.Alert("删除失败！", MessageType.Error11);
            }
        }
        GridBind();
    }
}