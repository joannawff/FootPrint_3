using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Sys_AttendDetailM : BasePage
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
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "<script>MakeStaticHeader('" + GridView1.ClientID + "',400,1080,30,true);</script>", false);
            this.hfAttendId.Value = Request["id"].Trim();
            GridInti();
            GridBind();
        }
    }

    public void GridInti()
    {
        int attendId = int.Parse(this.hfAttendId.Value);
        //调整GridView结构
        AttendInfo attendInfo = new AttendInfo();
        attendInfo = new AttendInfoData().GetAttendInfoByAttendId(attendId);

        int startYear = attendInfo.StartDate.Year;
        int startMonth = attendInfo.StartDate.Month;
        int startDay = attendInfo.StartDate.Day;
        int endYear = attendInfo.EndDate.Year;
        int endMonth = attendInfo.EndDate.Month;
        int endDay = attendInfo.EndDate.Day;
        if (startYear < endYear || startMonth < endMonth)
        {
            int curMonthEndDay = DateTime.DaysInMonth(startYear, startMonth);
            for (int idx = 2; idx < startDay + 1; idx++)
            {
                this.GridView1.Columns[idx].Visible = false;
            }
            for (int idx = curMonthEndDay + 2; idx <= 32; idx++)
            {
                this.GridView1.Columns[idx].Visible = false;
            }
            for (int idx = endDay + 34; idx <= 63; idx++)
            {
                this.GridView1.Columns[idx].Visible = false;
            }
        }
        else
        {
            for (int idx = 2; idx < startDay + 1; idx++)
            {
                this.GridView1.Columns[idx].Visible = false;
            }
            for (int idx = endDay + 2; idx <= 63; idx++)
            {
                this.GridView1.Columns[idx].Visible = false;
            }
        }
    }

    private void GridBind()
    {
        int attendId = int.Parse(this.hfAttendId.Value);
        DataTable dt = new DataTable();
        dt = new AttendDetailInfoData().GetAttendDetailInfoByAttendanceId(attendId);
        this.GridView1.DataSource = dt;
        this.GridView1.DataBind();
    }

    public String GetStartAndEndDate()
    {
        int attendId = int.Parse(this.hfAttendId.Value);
        AttendInfo attendInfo = new AttendInfo();
        attendInfo = new AttendInfoData().GetAttendInfoByAttendId(attendId);
        String startDate = attendInfo.StartDate.ToString("yyyy-MM-dd");
        String endDate = attendInfo.EndDate.ToString("yyyy-MM-dd");
        return startDate + "," + endDate;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "del":
                try
                {
                    int attendDetailId = int.Parse(e.CommandArgument.ToString().Trim());
                    AttendDetailInfoData attendDetailInfoData = new AttendDetailInfoData();
                    attendDetailInfoData.DeleteAttendDetailInfo(attendDetailId);
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
            ;
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        int attendId = int.Parse(this.hfAttendId.Value);
        DataTable dt = new DataTable();
        dt = new AttendDetailInfoData().GetAttendDetailInfoByAttendanceIdWithCondition(attendId, this.txtConditionUserName.Text.Trim());
        this.GridView1.DataSource = dt;
        this.GridView1.DataBind();
    }
}