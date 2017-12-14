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
    public DataTable GetAttendInfosByUserId(int userId,int roleCode)
    {
        return GetAttendInfosByUserIdWithCondition(userId, roleCode, null, null);
    }

    public DataTable GetAttendInfosByUserIdWithCondition(int userId, int roleCode, String projectName, String title)
    {
        DataTable dt = new DataTable();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if (roleCode == 1)
        {
            cmd.CommandText = "select a.*,p.ProjectName,c.UserName as CreaterName,r.UserName as ReviewerName,au.UserName as AuditorName " +
                "from Attendance a join Project p " +
                "on a.ProjectId = p.Id " +
                "join UserInfo c on a.Creater = c.id " +
                "join UserInfo r on a.Creater = r.id " +
                "join UserInfo au on a.Creater = au.id " +
                "where 1=1 ";

        }
        else
        {
            cmd.CommandText = "select distinct a.*,p.ProjectName,c.UserName as CreaterName,r.UserName as ReviewerName,au.UserName as AuditorName " +
                "from Attendance a join AttendDetail ad " +
                "on a.Id = ad.AttendId " +
                "join Project p on a.ProjectId = p.Id " +
                "join UserInfo c on a.Creater = c.id " +
                "join UserInfo r on a.Creater = r.id " +
                "join UserInfo au on a.Creater = au.id " +
                "where p.UserId = " + userId;//是项目负责人
        }

        if (!String.IsNullOrEmpty(projectName))
        {
            cmd.CommandText += " and p.ProjectName like N'%" + projectName + "%'";
        }
        if(!String.IsNullOrEmpty(title))
        {
            cmd.CommandText += " and a.Title like N'%" + title + "%'";
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
        cmd.CommandText = "select " +
            "Id,StartDate," +
            "EndDate,Title,ProjectId," +
            "Creater,Reviewer,Auditor,CreateDate " +
            "from Attendance where Id = " + attendId;
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
            UserInfo creater = new UserInfo();
            creater.Id = dr.IsDBNull(5) ? 0 : dr.GetInt32(5);
            attendInfo.Creater = creater;
            UserInfo reviewer = new UserInfo();
            reviewer.Id = dr.IsDBNull(6) ? 0 : dr.GetInt32(6);
            attendInfo.Reviewer = reviewer;
            UserInfo auditor = new UserInfo();
            auditor.Id = dr.IsDBNull(7) ? 0 : dr.GetInt32(7);
            attendInfo.Auditor = auditor;
            attendInfo.CreateDate = dr.GetDateTime(8);
        }
        con.Close();
        return attendInfo;
    }

    public DataTable GetAttendInfoByProjectId(int projectId)
    {
        DataTable dt = new DataTable();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Attendance where ProjectId = " + projectId;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        return dt;
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
        if (attendInfo.Id == 0)//"insert into Attendance values('2017-10-17','2017-11-15',N'起个名字',10001,1,2,3,'2018-10-10')"
            cmd.CommandText = "insert into Attendance values('" + attendInfo.StartDate.ToString("yyyy-MM-dd") + "','" +
                attendInfo.EndDate.ToString("yyyy-MM-dd") + "'," +
                "N'" + attendInfo.Title + "'," +
                attendInfo.ProjectInfo.Id + "," +
                attendInfo.Creater.Id + "," +
                attendInfo.Reviewer.Id + "," +
                attendInfo.Auditor.Id + "," +
                "'" + attendInfo.CreateDate.ToString("yyyy-MM-dd") + "'" +
                ")";
        else
            cmd.CommandText = "update Attendance " +
                "set StartDate = '" + attendInfo.StartDate.ToString("yyyy-MM-dd") + "', " +
                " EndDate = '" + attendInfo.EndDate.ToString("yyyy-MM-dd") + "', " +
                " Title = N'" + attendInfo.Title + "', " +
                " ProjectId = " + attendInfo.ProjectInfo.Id + ", " +
                " Creater = " + attendInfo.Creater.Id + ", " +
                " Reviewer = " + attendInfo.Reviewer.Id + ", " +
                " Auditor = " + attendInfo.Auditor.Id + ", " +
                " CreateDate = '" + attendInfo.CreateDate.ToString("yyyy-MM-dd") + "' " +
                " where Id = " + attendInfo.Id;
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }

    public bool DeleteAttendInfo(int attendId)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from Attendance where id = " + attendId;
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }
}