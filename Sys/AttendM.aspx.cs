using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_AttendM : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        if (!IsPostBack)
        {
            GridBind();
        }
    }

    private void GridBind()
    {
        int userId = int.Parse(Session["userId"].ToString().Trim());
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        DataTable dt = new DataTable();
        AttendInfoData attendInfoData = new AttendInfoData();
        dt = attendInfoData.GetAttendInfosByUserId(userId, roleCode);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "del":
                try
                {
                    int attendId = int.Parse(e.CommandArgument.ToString().Trim());
                    AttendInfoData attendInfoData = new AttendInfoData();
                    attendInfoData.DeleteAttendInfo(attendId);
                    this.Alert("删除成功！", MessageType.Succeed);
                }
                catch (Exception ex)
                {
                    this.Alert("删除失败！", MessageType.Error11);
                    return;
                }
                break;
        }
        GridBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].Text = Convert.ToDateTime(e.Row.Cells[3].Text).ToString("yyyy-MM-dd");
            e.Row.Cells[4].Text = Convert.ToDateTime(e.Row.Cells[4].Text).ToString("yyyy-MM-dd");
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        int userId = int.Parse(Session["userId"].ToString().Trim());
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        String projectName = this.txtConditionProjectName.Text.Trim();
        String title = this.txtConditionTitle.Text.Trim();
        DataTable dt = new DataTable();
        AttendInfoData attendInfoData = new AttendInfoData();
        dt = attendInfoData.GetAttendInfosByUserIdWithCondition(userId, roleCode, projectName, title);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}