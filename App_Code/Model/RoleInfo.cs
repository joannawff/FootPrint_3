using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Role 的摘要说明
/// </summary>
public class RoleInfo
{
    public RoleInfo()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public RoleInfo(int id, string roleName, int roleCode, string remark)
    {
        this.id = id;
        this.roleName = roleName;
        this.roleCode = roleCode;
        this.remark = remark;
    }

    private int id;
    private String roleName;
    private int roleCode;
    private String remark;

    public int Id { get => id; set => id = value; }
    public string RoleName { get => roleName; set => roleName = value; }
    public int RoleCode { get => roleCode; set => roleCode = value; }
    public string Remark { get => remark; set => remark = value; }
}