using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Sys_ProjectM : BasePage
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
        ProjectInfoData projectInfoData = new ProjectInfoData();
        dt = projectInfoData.GetProjectInfoByUserId(useId,roleCode);
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
        int useId = int.Parse(Session["userId"].ToString().Trim());
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        DataTable dt = new DataTable();
        ProjectInfoData projectInfoData = new ProjectInfoData();
        dt = projectInfoData.GetProjectInfoByUserIdWithCondition(useId,roleCode,this.txtConditionProjectName.Text.Trim());
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}