using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void login_Click(object sender, EventArgs e)
    {
        String userName = this.username.Value.Trim();
        String password = this.userpwd.Value.Trim();
        UserInfoData userData = new UserInfoData();
        UserInfo userInfo = userData.Login(userName);
        if (password.Equals(userInfo.Password)) {
            Session["userId"] = userInfo.Id;
            Session["userName"] = userInfo.UserName;
            Session["roleCode"] = userInfo.RoleInfo.RoleCode;
            Response.Redirect("Index.aspx");
        }
    }
}