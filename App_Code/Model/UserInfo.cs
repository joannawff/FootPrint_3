using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserInfo 的摘要说明
/// </summary>
public class UserInfo
{
    public UserInfo()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    
    public UserInfo(int id, string userName, string password, RoleInfo roleInfo, string tel, string code)
    {
        this.id = id;
        this.userName = userName;
        this.password = password;
        this.roleInfo = roleInfo;
        this.tel = tel;
        this.code = code;
    }

    private int id;
    private String userName;
    private String password;
    private RoleInfo roleInfo;
    private String tel;
    private String code;

    public int Id { get => id; set => id = value; }
    public string UserName { get => userName; set => userName = value; }
    public string Password { get => password; set => password = value; }
    public RoleInfo RoleInfo { get => roleInfo; set => roleInfo = value; }
    public string Tel { get => tel; set => tel = value; }
    public string Code { get => code; set => code = value; }
}