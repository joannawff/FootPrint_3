using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sys_AttendO : BasePage
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
            int userId = int.Parse(Session["userId"].ToString().Trim());
            int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
            DataTable dt = new DataTable();
            dt = new ProjectInfoData().GetProjectInfoByUserId(userId,roleCode);
            this.ddlProject.DataSource = dt;
            this.ddlProject.DataTextField = "ProjectName";
            this.ddlProject.DataValueField = "Id";
            this.ddlProject.DataBind();

            DataTable dtUserInfos = new UserInfoData().GetUserInfos();
            //绑定创建者
            this.ddlCreater.DataSource = dtUserInfos;
            this.ddlCreater.DataTextField = "UserName";
            this.ddlCreater.DataValueField = "Id";
            this.ddlCreater.DataBind();
            this.ddlCreater.Items.Add(new ListItem("", "0"));
            this.ddlCreater.SelectedIndex = this.ddlCreater.Items.IndexOf(this.ddlCreater.Items.FindByValue("0"));
            //绑定复查人
            this.ddlReviewer.DataSource = dtUserInfos;
            this.ddlReviewer.DataTextField = "UserName";
            this.ddlReviewer.DataValueField = "Id";
            this.ddlReviewer.DataBind();
            this.ddlReviewer.Items.Add(new ListItem("", "0"));
            this.ddlReviewer.SelectedIndex = this.ddlReviewer.Items.IndexOf(this.ddlReviewer.Items.FindByValue("0"));
            //绑定审计
            this.ddlAuditor.DataSource = dtUserInfos;
            this.ddlAuditor.DataTextField = "UserName";
            this.ddlAuditor.DataValueField = "Id";
            this.ddlAuditor.DataBind();
            this.ddlAuditor.Items.Add(new ListItem("", "0"));
            this.ddlAuditor.SelectedIndex = this.ddlAuditor.Items.IndexOf(this.ddlAuditor.Items.FindByValue("0"));

            if (!string.IsNullOrEmpty(id))
            {
                PageInit(id);
            }
        }
    }

    private void PageInit(string id)
    {
        AttendInfoData attendInfoData = new AttendInfoData();
        AttendInfo attendInfo = attendInfoData.GetAttendInfoByAttendId(int.Parse(id.Trim()));
        this.ddlProject.SelectedIndex = this.ddlProject.Items.IndexOf(this.ddlProject.Items.FindByValue(attendInfo.ProjectInfo.Id + ""));
        this.txtTitle.Text = attendInfo.Title.Trim();
        this.txtStartDate.Text = attendInfo.StartDate.ToString("yyyy-MM-dd");
        this.txtEndDate.Text = attendInfo.EndDate.ToString("yyyy-MM-dd");
        this.ddlCreater.SelectedIndex = this.ddlCreater.Items.IndexOf(this.ddlCreater.Items.FindByValue(attendInfo.Creater.Id + ""));
        this.ddlReviewer.SelectedIndex = this.ddlReviewer.Items.IndexOf(this.ddlReviewer.Items.FindByValue(attendInfo.Reviewer.Id + ""));
        this.ddlAuditor.SelectedIndex = this.ddlAuditor.Items.IndexOf(this.ddlAuditor.Items.FindByValue(attendInfo.Auditor.Id + ""));
        String createDate = attendInfo.CreateDate.ToString("yyyy-MM-dd");
        if (createDate.Equals("1999-01-01"))
            this.txtCreateDate.Text = "";
        else
            this.txtCreateDate.Text = createDate;
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        AttendInfo attendInfo = new AttendInfo();
        if (!string.IsNullOrEmpty(id))
        {
            attendInfo.Id = int.Parse(id.Trim());
        }
        
        String[] date = this.txtStartDate.Text.Split('-');
        attendInfo.StartDate = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));

        date = this.txtEndDate.Text.Split('-');
        attendInfo.EndDate = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));

        attendInfo.Title = this.txtTitle.Text.Trim();

        ProjectInfo p = new ProjectInfo();
        p.Id = int.Parse(this.ddlProject.SelectedItem.Value.Trim());
        attendInfo.ProjectInfo = p;
        
        if(!String.IsNullOrEmpty(this.txtCreateDate.Text.Trim()))
        {
            date = this.txtCreateDate.Text.Split('-');
            attendInfo.CreateDate = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));
        }
        else
        {
            attendInfo.CreateDate = new DateTime(1999, 1, 1);
        }

        UserInfo creater = new UserInfo();
        creater.Id = int.Parse(this.ddlCreater.SelectedItem.Value.Trim());
        attendInfo.Creater = creater;

        UserInfo reviewer = new UserInfo();
        reviewer.Id = int.Parse(this.ddlReviewer.SelectedItem.Value.Trim());
        attendInfo.Reviewer = reviewer;

        UserInfo auditor = new UserInfo();
        auditor.Id = int.Parse(this.ddlAuditor.SelectedItem.Value.Trim());
        attendInfo.Auditor = auditor;

        AttendInfoData attendInfoData = new AttendInfoData();
        //try
        //{
        attendInfoData.CommitAttendInfo(attendInfo);
        if (string.IsNullOrEmpty(id))
        {
            this.Alert("增项信息添加完成，请继续添加。", "SurveyRegisterO.aspx", MessageType.Succeed);
        }
        else
        {
            this.Alert("增项信息修改完成。", "SurveyRegisterM.aspx", MessageType.Succeed);

        }
        this.panelClose.Visible = true;
        /*}
        catch (Exception ex)
        {
            this.Alert(ex.Message, MessageType.Error11);
        }*/
    }
}