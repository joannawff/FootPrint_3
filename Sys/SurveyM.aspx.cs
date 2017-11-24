using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sys_SurveyM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write(" <script> parent.window.location.href= '../Login.aspx ' </script> ");
        }
        if (!Page.IsPostBack)
        {
            int userId = int.Parse(Session["userId"].ToString().Trim());
            this.ParentList.DataSource = this.getSurveyInfoByUserId(userId);
            this.ParentList.DataBind();
        }
    }
    private DataTable getSurveyInfoByUserId(int userId)
    {
        SurveyInfoData surveyInfoData = new SurveyInfoData();
        DataTable dt = surveyInfoData.GetSurveyInfoByUserId(userId);
        return dt;
    }

    protected void ParentList_OnItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataList ChildList = (DataList)e.Item.FindControl("ChildList");

        int surveyId = int.Parse(((Label)e.Item.FindControl("labSurveyId")).Text.Trim());
        SurveyDetailData detailData = new SurveyDetailData();
        DataTable dt = detailData.GetSurveyDetailBySurveyId(surveyId);

        /*获取查询结果myds后进行数据绑定*/
        ChildList.DataSource = dt;
        ChildList.DataBind();
    }
}