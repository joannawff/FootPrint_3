using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Sys_ProjectO : BasePage
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
            dt = new UserInfoData().GetUserInfos();
            this.User.DataSource = dt;
            this.User.DataTextField = "UserName";
            this.User.DataValueField = "Id";
            this.User.DataBind();
            if (!string.IsNullOrEmpty(id))
            {
                PageInit(id);
            }
        }
    }

    private void PageInit(string id)
    {
        ProjectInfoData projectInfoData = new ProjectInfoData();
        ProjectInfo projectInfo = projectInfoData.GetProjectInfoByProjectId(int.Parse(id.Trim()));
        this.ProjectName.Text = projectInfo.ProjectName.Trim();
        this.User.SelectedIndex = this.User.Items.IndexOf(this.User.Items.FindByValue(projectInfo.UserInfo.Id + ""));
        this.Resident.Text = projectInfo.Resident.Trim();
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        ProjectInfo projectInfo = new ProjectInfo();
        if (!string.IsNullOrEmpty(id))
        {
            projectInfo.Id = int.Parse(id.Trim());
        }
        projectInfo.ProjectName = this.ProjectName.Text.Trim();
        UserInfo userInfo = new UserInfo();
        userInfo.Id = int.Parse(this.User.SelectedItem.Value.Trim());
        projectInfo.UserInfo = userInfo;
        projectInfo.Resident = this.Resident.Text.Trim();
        ProjectInfoData projectInfoData = new ProjectInfoData();
        //try
        //{
            projectInfoData.CommitProjectInfo(projectInfo);

            if (string.IsNullOrEmpty(id))
            {
                this.Alert("项目信息添加完成，请继续添加。", "ProjectO.aspx", MessageType.Succeed);
            }
            else
            {
                this.Alert("项目信息修改完成。", "ProjectM.aspx", MessageType.Succeed);

            }
            this.panelClose.Visible = true;
        /*}
        catch (Exception ex)
        {
            this.Alert(ex.Message, MessageType.Error11);
        }*/
    }

}