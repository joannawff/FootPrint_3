using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ProjectInfo 的摘要说明
/// </summary>
public class ProjectInfo
{
    public ProjectInfo()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public ProjectInfo(int id, UserInfo userInfo, string projectName, string resident)
    {
        this.id = id;
        this.userInfo = userInfo;
        this.projectName = projectName;
        this.resident = resident;
    }

    private int id;
    private UserInfo userInfo;
    private String projectName;
    private String resident;

    public int Id { get => id; set => id = value; }
    public UserInfo UserInfo { get => userInfo; set => userInfo = value; }
    public string ProjectName { get => projectName; set => projectName = value; }
    public string Resident { get => resident; set => resident = value; }
}