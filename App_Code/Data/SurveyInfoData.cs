using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SurveyInfoData 的摘要说明
/// </summary>
public class SurveyInfoData
{
    private SqlConnection con;
    public SurveyInfoData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        con = new SqlConnection();
        con.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\FootPrint.mdf; Integrated Security = True";
        //con.ConnectionString = "Initial Catalog=FootPrintDB;Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";
    }

    public SurveyInfo GetSurveyInfoBySurveyId(int surveyId) {

        SurveyInfo surveyInfo = new SurveyInfo();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select " +
            "Id," +
            "Title," +
            "SurveyDate," +
            "ProjectId " +
            "from " +
            "Survey " +
            "where Id = " + surveyId;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            surveyInfo.Id = dr.GetInt32(0);
            surveyInfo.Title = dr.GetString(1).Trim();
            surveyInfo.SurveyDate = dr.GetDateTime(2);
            ProjectInfo p = new ProjectInfo();
            p.Id = dr.GetInt32(3);
            surveyInfo.ProjectInfo = p;
        }
        con.Close();
        return surveyInfo;
    }

    /*
    public DataTable GetSurveyInfoByUserId(int projectId, int userId, int roleCode)
    {
        return GetSurveyInfoByUserIdWithCondition(projectId, userId, roleCode);
    }
    public DataTable GetSurveyInfoByUserIdWithCondition(int projectId, int userId, int roleCode)
    {
        DataTable dt = new DataTable();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select s.*,p.ProjectName " +
            "from " +
            "Survey s join Project p " +
            "on s.ProjectId = p.Id " +
            "where s.ProjectId = " + projectId;
        if (roleCode != 1)
            cmd.CommandText += " and p.UserId = " + userId;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        return dt;
    }
    */

    public DataTable GetSurveyInfoByUserId(int userId,int roleCode)
    {
        return GetSurveyInfoByUserIdWithCondition(userId, roleCode, null);
    }
    public DataTable GetSurveyInfoByUserIdWithCondition(int userId, int roleCode,String projectName)
    {
        DataTable dt = new DataTable();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select s.*,p.ProjectName " +
            "from " +
            "Survey s join Project p " +
            "on s.ProjectId = p.Id " +
            "where 1=1 ";
        if (roleCode != 1)
            cmd.CommandText += " and p.UserId = " + userId;
        if (!String.IsNullOrEmpty(projectName))
            cmd.CommandText += " and p.ProjectName like N'%" + projectName + "%'";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable GetSurveyInfoByProjectId(int projectId)
    {
        DataTable dt = new DataTable();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * " +
            "from Survey " +
            "where ProjectId = " + projectId;
        return dt;
    }

    public bool CommitSurveyInfo(SurveyInfo surveyInfo)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if (surveyInfo.Id == 0)//"insert into Survey values('开工前勘测','2017-10-01',10001)"
            cmd.CommandText = "insert into Survey values(N'" + surveyInfo.Title + "','" + surveyInfo.SurveyDate.ToString("yyyy-MM-dd") + "'," + surveyInfo.ProjectInfo.Id + ")";
        else
            cmd.CommandText = "update Survey " +
                "set Title = N'" + surveyInfo.Title.Trim() + "', " +
                " SurveyDate = '" + surveyInfo.SurveyDate.ToString("yyyy-MM-dd") + "', " +
                " ProjectId = " + surveyInfo.ProjectInfo.Id + " " +
                " where id = " + surveyInfo.Id;
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }

    public bool DeleteSurveyInfo(int surveyInfoId)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from Survey where id = " + surveyInfoId;
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }
}