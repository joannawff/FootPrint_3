using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// SurveyDetailData 的摘要说明
/// </summary>
public class SurveyDetailInfoData
{
    private SqlConnection con;
    public SurveyDetailInfoData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        con = new SqlConnection();
        con.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\FootPrint.mdf; Integrated Security = True";
        //con.ConnectionString = "Initial Catalog=FootPrintDB;Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";
    }

    public DataTable GetSurveyDetailBySurveyId(int surveyId)
    {

        DataTable dt = new DataTable(); //声明数据库表

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from " +
            "SurveyDetail "+
            "where SurveyId = " + surveyId;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        return dt;
    }

    public SurveyDetailInfo GetSurveyDetailInfoBySurveyDetailId(int surveyDetailId)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * " +
            "from SurveyDetail " +
            "where id = " + surveyDetailId;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            SurveyDetailInfo surveyDetailInfo = new SurveyDetailInfo();
            surveyDetailInfo.Id = dr.GetInt32(0);
            SurveyInfo surveyInfo = new SurveyInfo();
            surveyInfo.Id = dr.GetInt32(1);
            surveyDetailInfo.SurveyInfo = surveyInfo;
            surveyDetailInfo.LeaderAndSecurityOfficer = dr.GetString(2).Trim();
            surveyDetailInfo.ProjectDetail = dr.GetString(3).Trim();
            surveyDetailInfo.Members = dr.GetString(4).Trim();
            surveyDetailInfo.Plan = dr.GetString(5).Trim();
            surveyDetailInfo.Actual = dr.GetString(6).Trim();
            surveyDetailInfo.OffTime = dr.GetDateTime(7);
            surveyDetailInfo.SortData = dr.GetString(8).Trim();
            surveyDetailInfo.SortDataParticipants = dr.GetString(9).Trim();
            surveyDetailInfo.Device = dr.GetString(10).Trim();
            surveyDetailInfo.VehicleRecord = dr.GetString(11).Trim();
            surveyDetailInfo.Remark = dr.GetString(12).Trim();
            con.Close();
            return surveyDetailInfo;
        }
        else
        {
            con.Close();
            return null;
        }
    }

    public bool CommitProjectInfo(SurveyDetailInfo surveyDetailInfo)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if (surveyDetailInfo.Id == 0)//"insert into SurveyDetail values(1001,'张三','开工前勘测','组员','计划','实际','收工时间','整理资料','整理资料参与人员','仪器','用车记录','备注')"
            cmd.CommandText = "insert into SurveyDetail values(" + surveyDetailInfo.SurveyInfo.Id + "," +
                "N'" + surveyDetailInfo.LeaderAndSecurityOfficer + "'," +
                "N'" + surveyDetailInfo.ProjectDetail + "'," +
                "N'" + surveyDetailInfo.Members + "'," +
                "N'" + surveyDetailInfo.Plan + "'," +
                "N'" + surveyDetailInfo.Actual + "'," +
                "'" + surveyDetailInfo.OffTime.ToString("yyyy-MM-dd hh:mm:ss") + "'," +
                "N'" + surveyDetailInfo.SortData + "'," +
                "N'" + surveyDetailInfo.SortDataParticipants + "'," +
                "N'" + surveyDetailInfo.Device + "'," +
                "N'" + surveyDetailInfo.VehicleRecord + "'," +
                "N'" + surveyDetailInfo.Remark + "'" +
                ")";
        else
            cmd.CommandText = "update SurveyDetail " +
                "set " +
                "SurveyId = " + surveyDetailInfo.SurveyInfo.Id + "," +
                "LeaderAndSecurityOfficer = N'" + surveyDetailInfo.LeaderAndSecurityOfficer + "'," +
                "ProjectDetail = N'" + surveyDetailInfo.ProjectDetail + "'," +
                "Members = N'" + surveyDetailInfo.Members + "'," +
                "[Plan] = N'" + surveyDetailInfo.Plan + "'," +
                "Actual = N'" + surveyDetailInfo.Actual + "'," +
                "OffTime = '" + surveyDetailInfo.OffTime.ToString("yyyy-MM-dd hh:mm:ss") + "'," +
                "SortData = N'" + surveyDetailInfo.SortData + "'," +
                "SortDataParticipants = N'" + surveyDetailInfo.SortDataParticipants + "'," +
                "Device = N'" + surveyDetailInfo.Device + "'," +
                "VehicleRecord = N'" + surveyDetailInfo.VehicleRecord + "'," +
                "Remark = N'" + surveyDetailInfo.Remark + "' " +
                "where id = " + surveyDetailInfo.Id;
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }

}