﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// AttendDetailData 的摘要说明
/// </summary>
public class AttendDetailInfoData
{
    private SqlConnection con;
    public AttendDetailInfoData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
        //
        // TODO: 在此处添加构造函数逻辑
        //
        con = new SqlConnection();
        con.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\FootPrint.mdf; Integrated Security = True";
        //con.ConnectionString = "Initial Catalog=FootPrintDB;Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";
    }

    public DataTable GetAttendDetailInfoByAttendanceId(int attendId)
    {
        return GetAttendDetailInfoByAttendanceIdWithCondition(attendId, null);
    }

    public DataTable GetAttendDetailInfoByAttendanceIdWithCondition(int attendId,String userName)
    {
        DataTable dt = new DataTable(); //声明数据库表

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select ad.*,u.UserName as UserName " +
            "from " +
            "AttendDetail ad join UserInfo u on ad.UserId=u.Id " +
            "where AttendId = " + attendId;
        if (!String.IsNullOrEmpty(userName))
            cmd.CommandText += " and u.UserName like N'%" + userName + "'";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        return dt;
    }

    public AttendDetailInfo GetAttendDetailInfoByAttendDetailId(int attendDetialId)
    {
        AttendDetailInfo attendDetailInfo = new AttendDetailInfo();
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * " +
            "from AttendDetail " +
            "where Id = " + attendDetialId;
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            attendDetailInfo.Id = dr.GetInt32(0);
            AttendInfo attendInfo = new AttendInfo();
            attendInfo.Id = dr.GetInt32(1);
            attendDetailInfo.AttendInfo = attendInfo;
            UserInfo userInfo = new UserInfo();
            userInfo.Id = dr.GetInt32(2);
            attendDetailInfo.UserInfo = userInfo;
            attendDetailInfo.CurMonthDay01 = dr.IsDBNull(3)?"": dr.GetString(3);
            attendDetailInfo.CurMonthDay02 = dr.IsDBNull(4) ? "" : dr.GetString(4);
            attendDetailInfo.CurMonthDay03 = dr.IsDBNull(5) ? "" : dr.GetString(5);
            attendDetailInfo.CurMonthDay04 = dr.IsDBNull(6) ? "" : dr.GetString(6);
            attendDetailInfo.CurMonthDay05 = dr.IsDBNull(7) ? "" : dr.GetString(7);
            attendDetailInfo.CurMonthDay06 = dr.IsDBNull(8) ? "" : dr.GetString(8);
            attendDetailInfo.CurMonthDay07 = dr.IsDBNull(9) ? "" : dr.GetString(9);
            attendDetailInfo.CurMonthDay08 = dr.IsDBNull(10) ? "" : dr.GetString(10);
            attendDetailInfo.CurMonthDay09 = dr.IsDBNull(11) ? "" : dr.GetString(11);
            attendDetailInfo.CurMonthDay10 = dr.IsDBNull(12) ? "" : dr.GetString(12);
            attendDetailInfo.CurMonthDay11 = dr.IsDBNull(13) ? "" : dr.GetString(13);
            attendDetailInfo.CurMonthDay12 = dr.IsDBNull(14) ? "" : dr.GetString(14);
            attendDetailInfo.CurMonthDay13 = dr.IsDBNull(15) ? "" : dr.GetString(15);
            attendDetailInfo.CurMonthDay14 = dr.IsDBNull(16)?"": dr.GetString(16);
            attendDetailInfo.CurMonthDay15 = dr.IsDBNull(17)?"": dr.GetString(17);
            attendDetailInfo.CurMonthDay16 = dr.IsDBNull(18)?"": dr.GetString(18);
            attendDetailInfo.CurMonthDay17 = dr.IsDBNull(19)?"": dr.GetString(19);
            attendDetailInfo.CurMonthDay18 = dr.IsDBNull(20)?"": dr.GetString(20);
            attendDetailInfo.CurMonthDay19 = dr.IsDBNull(21)?"": dr.GetString(21);
            attendDetailInfo.CurMonthDay20 = dr.IsDBNull(22)?"": dr.GetString(22);
            attendDetailInfo.CurMonthDay21 = dr.IsDBNull(23)?"": dr.GetString(23);
            attendDetailInfo.CurMonthDay22 = dr.IsDBNull(24)?"": dr.GetString(24);
            attendDetailInfo.CurMonthDay23 = dr.IsDBNull(25)?"": dr.GetString(25);
            attendDetailInfo.CurMonthDay24 = dr.IsDBNull(26)?"": dr.GetString(26);
            attendDetailInfo.CurMonthDay25 = dr.IsDBNull(27)?"": dr.GetString(27);
            attendDetailInfo.CurMonthDay26 = dr.IsDBNull(28)?"": dr.GetString(28);
            attendDetailInfo.CurMonthDay27 = dr.IsDBNull(29)?"": dr.GetString(29);
            attendDetailInfo.CurMonthDay28 = dr.IsDBNull(30)?"": dr.GetString(20);
            attendDetailInfo.CurMonthDay29 = dr.IsDBNull(31)?"": dr.GetString(31);
            attendDetailInfo.CurMonthDay30 = dr.IsDBNull(32)?"": dr.GetString(32);
            attendDetailInfo.CurMonthDay31 = dr.IsDBNull(33)?"": dr.GetString(33);
            attendDetailInfo.NextMonthDay01 = dr.IsDBNull(34)?"": dr.GetString(34);
            attendDetailInfo.NextMonthDay02 = dr.IsDBNull(35)?"": dr.GetString(35);
            attendDetailInfo.NextMonthDay03 = dr.IsDBNull(36)?"": dr.GetString(36);
            attendDetailInfo.NextMonthDay04 = dr.IsDBNull(37)?"": dr.GetString(37);
            attendDetailInfo.NextMonthDay05 = dr.IsDBNull(38)?"": dr.GetString(38);
            attendDetailInfo.NextMonthDay06 = dr.IsDBNull(39)?"": dr.GetString(39);
            attendDetailInfo.NextMonthDay07 = dr.IsDBNull(40)?"": dr.GetString(40);
            attendDetailInfo.NextMonthDay08 = dr.IsDBNull(41)?"": dr.GetString(41);
            attendDetailInfo.NextMonthDay09 = dr.IsDBNull(42)?"": dr.GetString(42);
            attendDetailInfo.NextMonthDay10 = dr.IsDBNull(43)?"": dr.GetString(43);
            attendDetailInfo.NextMonthDay11 = dr.IsDBNull(44)?"": dr.GetString(44);
            attendDetailInfo.NextMonthDay12 = dr.IsDBNull(45)?"": dr.GetString(45);
            attendDetailInfo.NextMonthDay13 = dr.IsDBNull(46)?"": dr.GetString(46);
            attendDetailInfo.NextMonthDay14 = dr.IsDBNull(47)?"": dr.GetString(47);
            attendDetailInfo.NextMonthDay15 = dr.IsDBNull(48)?"": dr.GetString(48);
            attendDetailInfo.NextMonthDay16 = dr.IsDBNull(49)?"": dr.GetString(49);
            attendDetailInfo.NextMonthDay17 = dr.IsDBNull(50)?"": dr.GetString(50);
            attendDetailInfo.NextMonthDay18 = dr.IsDBNull(51)?"": dr.GetString(51);
            attendDetailInfo.NextMonthDay19 = dr.IsDBNull(52)?"": dr.GetString(52);
            attendDetailInfo.NextMonthDay20 = dr.IsDBNull(53)?"": dr.GetString(53);
            attendDetailInfo.NextMonthDay21 = dr.IsDBNull(54)?"": dr.GetString(54);
            attendDetailInfo.NextMonthDay22 = dr.IsDBNull(55)?"": dr.GetString(55);
            attendDetailInfo.NextMonthDay23 = dr.IsDBNull(56)?"": dr.GetString(56);
            attendDetailInfo.NextMonthDay24 = dr.IsDBNull(57)?"": dr.GetString(57);
            attendDetailInfo.NextMonthDay25 = dr.IsDBNull(58)?"": dr.GetString(58);
            attendDetailInfo.NextMonthDay26 = dr.IsDBNull(59)?"": dr.GetString(59);
            attendDetailInfo.NextMonthDay27 = dr.IsDBNull(60)?"": dr.GetString(60);
            attendDetailInfo.NextMonthDay28 = dr.IsDBNull(61)?"": dr.GetString(61);
            attendDetailInfo.NextMonthDay29 = dr.IsDBNull(62)?"": dr.GetString(62);
            attendDetailInfo.NextMonthDay30 = dr.IsDBNull(63)?"": dr.GetString(63);
            attendDetailInfo.NextMonthDay31 = dr.IsDBNull(64)?"": dr.GetString(64);
            attendDetailInfo.Remark = dr.IsDBNull(65)?"": dr.GetString(65);

        }
        return attendDetailInfo;
    }

    public bool CommitAttendDetailInfo(AttendDetailInfo attendDetailInfo)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if (attendDetailInfo.Id == 0)//"insert into attendDetailInfo values(1001,100001,'1','1',...,N'备注')"
        {
            cmd.CommandText = "insert into AttendDetail values(" + attendDetailInfo.AttendInfo.Id + "," +
                attendDetailInfo.UserInfo.Id + ",";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay01 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay02 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay03 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay04 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay05 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay06 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay07 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay08 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay09 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay10 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay11 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay12 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay13 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay14 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay15 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay16 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay17 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay18 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay19 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay20 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay21 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay22 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay23 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay24 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay25 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay26 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay27 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay28 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay29 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay30 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.CurMonthDay31 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay01 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay02 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay03 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay04 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay05 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay06 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay07 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay08 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay09 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay10 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay11 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay12 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay13 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay14 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay15 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay16 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay17 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay18 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay19 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay20 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay21 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay22 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay23 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay24 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay25 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay26 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay27 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay28 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay29 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay30 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.NextMonthDay31 + "',";
            cmd.CommandText += "N'" + attendDetailInfo.Remark + "'" +")";
        }
        else
        {
            cmd.CommandText = "update AttendDetail " +
            "set " +
            "AttendId = " + attendDetailInfo.AttendInfo.Id + "," +
            "UserId = " + attendDetailInfo.UserInfo.Id + "," +
            "CurMonthDay01 = N'" + attendDetailInfo.CurMonthDay01 + "'," +
            "CurMonthDay02 = N'" + attendDetailInfo.CurMonthDay02 + "'," +
            "CurMonthDay03 = N'" + attendDetailInfo.CurMonthDay03 + "'," +
            "CurMonthDay04 = N'" + attendDetailInfo.CurMonthDay04 + "'," +
            "CurMonthDay05 = N'" + attendDetailInfo.CurMonthDay05 + "'," +
            "CurMonthDay06 = N'" + attendDetailInfo.CurMonthDay06 + "'," +
            "CurMonthDay07 = N'" + attendDetailInfo.CurMonthDay07 + "'," +
            "CurMonthDay08 = N'" + attendDetailInfo.CurMonthDay08 + "'," +
            "CurMonthDay09 = N'" + attendDetailInfo.CurMonthDay09 + "'," +
            "CurMonthDay10 = N'" + attendDetailInfo.CurMonthDay10 + "'," +
            "CurMonthDay11 = N'" + attendDetailInfo.CurMonthDay11 + "'," +
            "CurMonthDay12 = N'" + attendDetailInfo.CurMonthDay12 + "'," +
            "CurMonthDay13 = N'" + attendDetailInfo.CurMonthDay13 + "'," +
            "CurMonthDay14 = N'" + attendDetailInfo.CurMonthDay14 + "'," +
            "CurMonthDay15 = N'" + attendDetailInfo.CurMonthDay15 + "'," +
            "CurMonthDay16 = N'" + attendDetailInfo.CurMonthDay16 + "'," +
            "CurMonthDay17 = N'" + attendDetailInfo.CurMonthDay17 + "'," +
            "CurMonthDay18 = N'" + attendDetailInfo.CurMonthDay18 + "'," +
            "CurMonthDay19 = N'" + attendDetailInfo.CurMonthDay19 + "'," +
            "CurMonthDay20 = N'" + attendDetailInfo.CurMonthDay20 + "'," +
            "CurMonthDay21 = N'" + attendDetailInfo.CurMonthDay21 + "'," +
            "CurMonthDay22 = N'" + attendDetailInfo.CurMonthDay22 + "'," +
            "CurMonthDay23 = N'" + attendDetailInfo.CurMonthDay23 + "'," +
            "CurMonthDay24 = N'" + attendDetailInfo.CurMonthDay24 + "'," +
            "CurMonthDay25 = N'" + attendDetailInfo.CurMonthDay25 + "'," +
            "CurMonthDay26 = N'" + attendDetailInfo.CurMonthDay26 + "'," +
            "CurMonthDay27 = N'" + attendDetailInfo.CurMonthDay27 + "'," +
            "CurMonthDay28 = N'" + attendDetailInfo.CurMonthDay28 + "'," +
            "CurMonthDay29 = N'" + attendDetailInfo.CurMonthDay29 + "'," +
            "CurMonthDay30 = N'" + attendDetailInfo.CurMonthDay30 + "'," +
            "CurMonthDay31 = N'" + attendDetailInfo.CurMonthDay31 + "'," +
            "NextMonthDay01 = N'" + attendDetailInfo.NextMonthDay01 + "'," +
            "NextMonthDay02 = N'" + attendDetailInfo.NextMonthDay02 + "'," +
            "NextMonthDay03 = N'" + attendDetailInfo.NextMonthDay03 + "'," +
            "NextMonthDay04 = N'" + attendDetailInfo.NextMonthDay04 + "'," +
            "NextMonthDay05 = N'" + attendDetailInfo.NextMonthDay05 + "'," +
            "NextMonthDay06 = N'" + attendDetailInfo.NextMonthDay06 + "'," +
            "NextMonthDay07 = N'" + attendDetailInfo.NextMonthDay07 + "'," +
            "NextMonthDay08 = N'" + attendDetailInfo.NextMonthDay08 + "'," +
            "NextMonthDay09 = N'" + attendDetailInfo.NextMonthDay09 + "'," +
            "NextMonthDay10 = N'" + attendDetailInfo.NextMonthDay10 + "'," +
            "NextMonthDay11 = N'" + attendDetailInfo.NextMonthDay11 + "'," +
            "NextMonthDay12 = N'" + attendDetailInfo.NextMonthDay12 + "'," +
            "NextMonthDay13 = N'" + attendDetailInfo.NextMonthDay13 + "'," +
            "NextMonthDay14 = N'" + attendDetailInfo.NextMonthDay14 + "'," +
            "NextMonthDay15 = N'" + attendDetailInfo.NextMonthDay15 + "'," +
            "NextMonthDay16 = N'" + attendDetailInfo.NextMonthDay16 + "'," +
            "NextMonthDay17 = N'" + attendDetailInfo.NextMonthDay17 + "'," +
            "NextMonthDay18 = N'" + attendDetailInfo.NextMonthDay18 + "'," +
            "NextMonthDay19 = N'" + attendDetailInfo.NextMonthDay19 + "'," +
            "NextMonthDay20 = N'" + attendDetailInfo.NextMonthDay20 + "'," +
            "NextMonthDay21 = N'" + attendDetailInfo.NextMonthDay21 + "'," +
            "NextMonthDay22 = N'" + attendDetailInfo.NextMonthDay22 + "'," +
            "NextMonthDay23 = N'" + attendDetailInfo.NextMonthDay23 + "'," +
            "NextMonthDay24 = N'" + attendDetailInfo.NextMonthDay24 + "'," +
            "NextMonthDay25 = N'" + attendDetailInfo.NextMonthDay25 + "'," +
            "NextMonthDay26 = N'" + attendDetailInfo.NextMonthDay26 + "'," +
            "NextMonthDay27 = N'" + attendDetailInfo.NextMonthDay27 + "'," +
            "NextMonthDay28 = N'" + attendDetailInfo.NextMonthDay28 + "'," +
            "NextMonthDay29 = N'" + attendDetailInfo.NextMonthDay29 + "'," +
            "NextMonthDay30 = N'" + attendDetailInfo.NextMonthDay30 + "'," +
            "NextMonthDay31 = N'" + attendDetailInfo.NextMonthDay31 + "'," +
            "Remark = N'" + attendDetailInfo.Remark + "' " +
            "where id = " + attendDetailInfo.Id;
        }
        
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }

    public bool DeleteAttendDetailInfo(int attendDetailId)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from AttendDetail where id = " + attendDetailId;
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i >= 1;
    }

}