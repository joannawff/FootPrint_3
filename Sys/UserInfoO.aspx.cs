using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_UserInfoO : BasePage
{
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        id = Request["id"];
        if (!this.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = new RoleInfoData().GetRoleInfos();
            this.Role.DataSource = dt;
            this.Role.DataTextField = "RoleName";
            this.Role.DataValueField = "Id";
            this.Role.DataBind();
            if (!string.IsNullOrEmpty(id))
            {
                PageInit(id);
            }
        }
    }

    private void PageInit(string id)
    {
        UserInfoData userInfoData = new UserInfoData();
        UserInfo userInfo = userInfoData.GetUserInfoByUserId(int.Parse(id.Trim()));
        this.UserName.Text = userInfo.UserName.Trim();
        this.Role.SelectedIndex = this.Role.Items.IndexOf(this.Role.Items.FindByValue(userInfo.RoleInfo.Id + ""));
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        UserInfo userInfo = new UserInfo();
        if (!string.IsNullOrEmpty(id))
        {
            userInfo.Id = int.Parse(id.Trim());
        }
        userInfo.UserName = this.UserName.Text.Trim();
        userInfo.Password = "123456";
        RoleInfo roleInfo = new RoleInfo();
        roleInfo.Id = int.Parse(this.Role.SelectedItem.Value.Trim());
        roleInfo.RoleName = this.Role.SelectedValue.Trim();
        userInfo.RoleInfo = roleInfo;
        UserInfoData userInfoData = new UserInfoData();

        //try
        //{
        userInfoData.CommitUserInfo(userInfo);

        if (string.IsNullOrEmpty(id))
        {
            this.Alert("用户信息添加完成，请继续添加。", "UserInfoO.aspx", MessageType.Succeed);
        }
        else
        {
            this.Alert("用户信息修改完成。", "UserInfoM.aspx", MessageType.Succeed);

        }
        this.panelClose.Visible = true;
        /*}
        catch (Exception ex)
        {
            this.Alert(ex.Message, MessageType.Error11);
        }*/
    }
}