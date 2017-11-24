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

    public UserInfo(int id, string userName, string password, Role role, string tel)
    {
        this.id = id;
        this.userName = userName;
        this.password = password;
        this.role = role;
        this.tel = tel;
    }

    private int id;
    private String userName;
    private String password;
    private Role role;
    private String tel;

    public int Id { get => id; set => id = value; }
    public string UserName { get => userName; set => userName = value; }
    public string Password { get => password; set => password = value; }
    public Role Role { get => role; set => role = value; }
    public string Tel { get => tel; set => tel = value; }
}