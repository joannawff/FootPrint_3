using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;

/// <summary>
/// ProjectInfoData 的摘要说明
/// </summary>
public class ProjectInfoData
{
    private SqlConnection con;
    public ProjectInfoData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        con = new SqlConnection();
        con.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\FootPrint.mdf; Integrated Security = True";
        //con.ConnectionString = "Initial Catalog=FootPrintDB;Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";

    }
    public DataTable GetDT() {
        DataTable dt = new DataTable(); //声明数据库表  
        int userId = int.Parse(HttpContext.Current.Session["userId"].ToString().Trim());
        String userName = HttpContext.Current.Session["userName"].ToString().Trim();
        //获取数据源  
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if(userName=="admin")
            cmd.CommandText = "select " +
            "p.Id as Id," +
            "p.ProjectName as ProjectName," +
            "u.UserName as UserName," +
            "u.Tel as Tel," +
            "p.Resident as Resident " +
            "from " +
            "Project p join UserInfo u " +
            "on p.UserId=u.id " +
            "where u.id = " + userId;
        else
            cmd.CommandText = "select " +
            "p.Id as Id," +
            "p.ProjectName as ProjectName," +
            "u.UserName as UserName," +
            "u.Tel as Tel," +
            "p.Resident as Resident " +
            "from " +
            "Project p join UserInfo u " +
            "on p.UserId=u.id ";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        return dt;
    }

    public ProjectInfo GetDataById(int id) {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select " +
            "p.Id as Id," +
            "p.ProjectName as ProjectName," +
            "u.UserName as UserName," +
            "u.Tel as Tel," +
            "p.Resident as Resident," +
            "u.Id as UserId " +
            "from " +
            "Project p join UserInfo u " +
            "on p.UserId=u.id " +
            "where p.id = " + id;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            ProjectInfo projectInfo = new ProjectInfo();
            projectInfo.Id = dr.GetInt32(0);
            projectInfo.ProjectName = dr.GetString(1);
            projectInfo.Resident = dr.GetString(4);
            UserInfo userInfo = new UserInfo();
            userInfo.Id = dr.GetInt32(5);
            userInfo.UserName = dr.GetString(2);
            userInfo.Tel = dr.GetString(3);
            projectInfo.UserInfo = userInfo;
            con.Close();
            return projectInfo;
        }
        else {
            con.Close();
            return null;
        }
    }

    public bool CommitProjectInfo(ProjectInfo projectInfo)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if (projectInfo.Id == 0)//"insert into Project values('测试项目3','10001','深圳')"
            cmd.CommandText = "insert into Project values(N'" + projectInfo.ProjectName + "'," + projectInfo.UserInfo.Id + ",N'" + projectInfo.Resident + "')";
        else
            cmd.CommandText = "update Project " +
                "set ProjectName = N'" + projectInfo.ProjectName.Trim() + "', " +
                " UserId = " + projectInfo.UserInfo.Id + ", " +
                " Resident = N'" + projectInfo.Resident.Trim() + "' " +
                " where id = " + projectInfo.Id;
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }
}