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

    public AttendInfo(int id, DateTime startDate, DateTime endDate, string title, ProjectInfo projectInfo, UserInfo creater, UserInfo reviewer, UserInfo auditor, DateTime createDate)
    {
        this.id = id;
        this.startDate = startDate;
        this.endDate = endDate;
        this.title = title;
        this.projectInfo = projectInfo;
        this.creater = creater;
        this.reviewer = reviewer;
        this.auditor = auditor;
        this.createDate = createDate;
    }

    private int id;
    private DateTime startDate;
    private DateTime endDate;
    private String title;
    private ProjectInfo projectInfo;
    private UserInfo creater;
    private UserInfo reviewer;
    private UserInfo auditor;
    private DateTime createDate;

    public int Id { get => id; set => id = value; }
    public DateTime StartDate { get => startDate; set => startDate = value; }
    public DateTime EndDate { get => endDate; set => endDate = value; }
    public String Title { get => title; set => title = value; }
    public ProjectInfo ProjectInfo { get => projectInfo; set => projectInfo = value; }
    public UserInfo Creater { get => creater; set => creater = value; }
    public UserInfo Reviewer { get => reviewer; set => reviewer = value; }
    public UserInfo Auditor { get => auditor; set => auditor = value; }
    public DateTime CreateDate { get => createDate; set => createDate = value; }
}