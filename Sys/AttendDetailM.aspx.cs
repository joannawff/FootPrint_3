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
            Response.Write(" <script> parent.window.location.href= '../Login.aspx ' </script> ");
            return;
        }

        if (!this.IsPostBack)
        {
            
            this.hfAttendId.Value = Request["id"].Trim();
            int userId = int.Parse(Session["userId"].ToString().Trim());
            DataTable dt = new DataTable();
            dt = new AttendInfoData().GetAttendInfosByUserId(userId);
            this.ddlAttendance.DataTextField = "Title";
            this.ddlAttendance.DataValueField = "Id";
            this.ddlAttendance.DataSource = dt;
            this.ddlAttendance.DataBind();
        }
        GridBind();
    }

    private void GridBind()
    {
        int attendId = int.Parse(this.hfAttendId.Value);
        DataTable dt = new DataTable();
        dt = new AttendDetailInfoData().GetAttendDetailInfoByAttendanceId(attendId);
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
            for(int idx = 2;idx<startDay+1;idx++)
            {
                this.GridView1.Columns[idx].Visible = false;
            }
            for(int idx = curMonthEndDay+2; idx <= 32; idx++)
            {
                this.GridView1.Columns[idx].Visible = false;
            }
            for(int idx = endDay+34;idx<=63;idx++)
            {
                this.GridView1.Columns[idx].Visible = false;
            }
        }
        else
        {
            for (int idx = 2; idx < startDay+1; idx++)
            {
                this.GridView1.Columns[idx].Visible = false;
            }
            for (int idx = endDay + 2; idx <= 63; idx++)
            {
                this.GridView1.Columns[idx].Visible = false;
            }
        }
        this.GridView1.DataSource = dt;
        this.GridView1.DataBind();
        this.ddlAttendance.SelectedIndex = this.ddlAttendance.Items.IndexOf(this.ddlAttendance.Items.FindByValue(attendId + ""));
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

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}