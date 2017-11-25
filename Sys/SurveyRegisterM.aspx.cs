using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sys_SurveyRegisterM : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
            {
                Response.Write(" <script> parent.window.location.href= '../Login.aspx ' </script> ");
            }
            GridBind();
        }
    }

    private void GridBind()
    {
        int userid = int.Parse(Session["userId"].ToString().Trim());
        DataTable dt = new DataTable();
        SurveyInfoData surveyInfoData = new SurveyInfoData();
        dt = surveyInfoData.GetSurveyInfoByUserId(userid);
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
        GridBind();
    }
}