using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// AttendInfoData 的摘要说明
/// </summary>
public class AttendInfoData
{
    private SqlConnection con;
    public AttendInfoData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        con = new SqlConnection();
        con.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\FootPrint.mdf; Integrated Security = True";
    }

    //查询
    public DataTable GetAttendInfosByUserId(int userId)
    {
        DataTable dt = new DataTable();
        String userName = HttpContext.Current.Session["userName"].ToString().Trim();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if(userName.Equals("admin"))
        {
            cmd.CommandText = "select a.*,p.ProjectName from Attendance a join Project p on a.ProjectId = p.Id";

        }else
        {
            cmd.CommandText = "select distinct a.*,p.ProjectName from Attendance a join AttendDetail ad on a.Id = ad.AttendId join Project p on a.ProjectId=p.Id where ad.UserId=" + userId;
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        return dt;
    }

    public AttendInfo GetAttendInfoByAttendId(int attendId)
    {
        AttendInfo attendInfo = new AttendInfo();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select Id,StartDate,EndDate,Title,ProjectId from Attendance where Id = " + attendId;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            attendInfo.Id = dr.GetInt32(0);
            attendInfo.StartDate = dr.GetDateTime(1);
            attendInfo.EndDate = dr.GetDateTime(2);
            attendInfo.Title = dr.GetString(3);
            ProjectInfo projectInfo = new ProjectInfo();
            projectInfo.Id = dr.GetInt32(4);
            attendInfo.ProjectInfo = projectInfo;
        }
        return attendInfo;
    }

    public bool CommitAttendInfo(AttendInfo attendInfo)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if (attendInfo.Id == 0)//"insert into Attendance values('2017-10-17','2017-11-15',N'起个名字',10001)"
            cmd.CommandText = "insert into Attendance values('" + attendInfo.StartDate.ToString("yyyy-MM-dd") + "','" + attendInfo.EndDate.ToString("yyyy-MM-dd") + "',N'" + attendInfo.Title + "',"+attendInfo.ProjectInfo.Id+")";
        else
            cmd.CommandText = "update Attendance " +
                "set StartDate = '" + attendInfo.StartDate.ToString("yyyy-MM-dd") + "', " +
                " EndDate = '" + attendInfo.EndDate.ToString("yyyy-MM-dd") + "', " +
                " Title = N'" + attendInfo.Title + "', " +
                " ProjectId = " + attendInfo.ProjectInfo.Id + " " +
                " where Id = " + attendInfo.Id;
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }
}