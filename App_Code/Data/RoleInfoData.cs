using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// RoleInfoData 的摘要说明
/// </summary>
public class RoleInfoData
{
    private SqlConnection con;
    public RoleInfoData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        con = new SqlConnection();
        con.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\FootPrint.mdf; Integrated Security = True";
        //con.ConnectionString = "Initial Catalog=FootPrintDB;Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";

    }

    public DataTable GetRoleInfos()
    {
        DataTable dt = new DataTable();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select Id, RoleName from Role where RoleName != \'admin\'";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        return dt;
    }
}