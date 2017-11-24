using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Role 的摘要说明
/// </summary>
public class Role
{
    public Role()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public Role(int id, string roleName, string remark)
    {
        this.id = id;
        RoleName = roleName;
        Remark = remark;
    }

    private int id;
    private String RoleName;
    private String Remark;

    public int Id { get => id; set => id = value; }
    public string RoleName1 { get => RoleName; set => RoleName = value; }
    public string Remark1 { get => Remark; set => Remark = value; }
}