using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_UserInfoM : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        if (!this.IsPostBack)
        {
            GridBind();
        }
    }

    private void GridBind()
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals("") || Session["roleCode"] == null || Session["roleCode"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        int useId = int.Parse(Session["userId"].ToString().Trim());
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        DataTable dt = new DataTable();
        UserInfoData userInfoData = new UserInfoData();
        dt = userInfoData.GetUserInfos();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals("") || Session["roleCode"] == null || Session["roleCode"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        DataTable dt = new DataTable();
        UserInfoData userInfoData = new UserInfoData();
        dt = userInfoData.GetUserInfoWithCondition(this.txtConditionUserName.Text);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}