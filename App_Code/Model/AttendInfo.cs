using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AttendInfo 的摘要说明
/// </summary>
public class AttendInfo
{
    public AttendInfo()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public AttendInfo(int id, DateTime startDate, DateTime endDate,String title, ProjectInfo projectInfo)
    {
        this.id = id;
        this.startDate = startDate;
        this.endDate = endDate;
        this.title = title;
        this.projectInfo = projectInfo;
    }

    private int id;
    private DateTime startDate;
    private DateTime endDate;
    private String title;
    private ProjectInfo projectInfo;

    public int Id { get => id; set => id = value; }
    public DateTime StartDate { get => startDate; set => startDate = value; }
    public DateTime EndDate { get => endDate; set => endDate = value; }
    public String Title { get => title; set => title = value; }
    public ProjectInfo ProjectInfo { get => projectInfo; set => projectInfo = value; }
}