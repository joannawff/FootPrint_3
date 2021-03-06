﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;

/// <summary>
/// UserData 的摘要说明
/// </summary>
public class UserInfoData
{
    private SqlConnection con;
    public UserInfoData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        con = new SqlConnection();
        con.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\FootPrint.mdf; Integrated Security = True";
        //con.ConnectionString = "Initial Catalog=FootPrintDB;Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";

    }

    public UserInfo Login(String userName)
    {
        UserInfo userInfo = new UserInfo();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select u.id,u.UserName,u.Password,r.RoleCode " +
            "from UserInfo u join Role r " +
            "on u.RoleId=r.Id " +
            "where UserName = N'" + userName + "'";
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            /*
            String tmpPass = dr.GetString(2).Trim();
            if (tmpPass.Equals(password))
            {
                HttpContext.Current.Session["userId"] = dr.GetInt32(0);
                HttpContext.Current.Session["userName"] = dr.GetString(1).Trim();
                HttpContext.Current.Session["roleCode"] = dr.GetString(3).Trim();
            }
            */
            userInfo.Id = dr.GetInt32(0);
            userInfo.UserName = dr.GetString(1).Trim();
            userInfo.Password = dr.GetString(2).Trim();
            RoleInfo roleInfo = new RoleInfo();
            roleInfo.RoleCode = dr.GetInt32(3);
            userInfo.RoleInfo = roleInfo;
        }
        con.Close();
        return userInfo;
    }

    public string getUserNameByUserId(int userId)
    {
        string userName = "";
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select UserName from UserInfo where Id = " + userId;

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            userName = dr.GetString(0);    
        }
        con.Close();
        return userName;
    }



    public DataTable GetUserInfos() {
        DataTable dt = new DataTable();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select u.Id as Id,u.UserName as UserName,r.RoleName as RoleName from UserInfo u join Role r on u.RoleId=r.id where UserName != \'admin\'";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        return dt;
    }

    public bool CommitUserInfo(UserInfo userInfo) {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if (userInfo.Id == 0)
            cmd.CommandText = "insert into UserInfo values(N'" + userInfo.UserName + "','123456','"+userInfo.RoleInfo.Id+"','" + userInfo.Tel + "','" + userInfo.Code + "')";
        else
            cmd.CommandText = "update UserInfo set UserName = N'" + userInfo.UserName + "', Tel = '" + userInfo.Tel + "', RoleId = '" + userInfo.RoleInfo.Id+"', Code = '" + userInfo.Code + "' where id = " + userInfo.Id;
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }

    public DataTable GetUserInfoWithCondition(String userName)
    {
        DataTable dt = new DataTable(); //声明数据库表
        //获取数据源  
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select u.Id as Id,u.UserName as UserName,r.RoleName as RoleName from UserInfo u join Role r on u.RoleId=r.id where UserName != \'admin\'";
        if (!String.IsNullOrEmpty(userName))//项目名过滤
        {
            cmd.CommandText += " and u.UserName like N'%" + userName + "%'";//模糊过滤、模糊查询
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        return dt;
    }

    public UserInfo GetUserInfoByUserId(int userId)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select " +
            "u.Id as Id," +
            "u.UserName as UserName," +
            "r.RoleName as RoleName," +
            "u.Id as UserId " +
            "from " +
            "UserInfo u join Role r " +
            "on u.RoleId=r.id " +
            "where u.id = " + userId;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Id = dr.GetInt32(0);
            userInfo.UserName = dr.GetString(1);
            RoleInfo roleInfo = new RoleInfo();
            roleInfo.Id = dr.GetInt32(3);
            roleInfo.RoleName = dr.GetString(2);
            userInfo.RoleInfo = roleInfo;
            con.Close();
            return userInfo;
        }
        else
        {
            con.Close();
            return null;
        }
    }
}