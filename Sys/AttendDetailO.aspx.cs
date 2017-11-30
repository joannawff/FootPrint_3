using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sys_AttendDetailO : BasePage
{
    private String id;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write(" <script> parent.window.location.href= '../Login.aspx ' </script> ");
            return;
        }
        id = Request["id"];
        if (!IsPostBack)
        {
            String startAndEndDate = Request["startAndEndDate"].Trim();
            String[] dates = startAndEndDate.Split(',');
            this.hfStartDate.Value = dates[0];
            this.hfEndDate.Value = dates[1];
            this.hfAttendId.Value = Request["attendId"].Trim();
            //绑定姓名的dropdownlist
            UserInfoData userInfoData = new UserInfoData();
            DataTable dt = userInfoData.GetUserInfos();
            this.ddlUserName.DataSource = dt;
            this.ddlUserName.DataTextField = "UserName";
            this.ddlUserName.DataValueField = "Id";
            this.ddlUserName.DataBind();
            TableInit(this.hfStartDate.Value, this.hfEndDate.Value);
            if (!String.IsNullOrEmpty(id))
                PageInit(int.Parse(id));
        }
    }
    private void PageInit(int attendDetailId)
    {
        AttendDetailInfoData attendDetailInfoData = new AttendDetailInfoData();
        AttendDetailInfo attendDetailInfo = attendDetailInfoData.GetAttendDetailInfoByAttendDetailId(attendDetailId);
        this.ddlUserName.SelectedIndex = this.ddlUserName.Items.IndexOf(this.ddlUserName.Items.FindByValue(attendDetailInfo.UserInfo.Id + ""));
        String[] date = this.hfStartDate.Value.Split('-');
        this.txtRemark.Text = attendDetailInfo.Remark.Trim();

        int startYear = int.Parse(date[0]);
        int startMonth = int.Parse(date[1]);
        int startDay = int.Parse(date[2]);
        date = this.hfEndDate.Value.Split('-');
        int endYear = int.Parse(date[0]);
        int endMonth = int.Parse(date[1]);
        int endDay = int.Parse(date[2]);
        int daysOfCurrentMonth = DateTime.DaysInMonth(startYear, startMonth) - startDay + 1;
        //通过反射绑定数据，，难
        Type type = attendDetailInfo.GetType();//获取对象类型，即类信息
        System.Reflection.PropertyInfo propertyInfo;//声明属性对象
        for (int idx = 1; idx < daysOfCurrentMonth + 1; idx++)
        {
            int tmp = startDay + idx - 1;
            propertyInfo = type.GetProperty("CurMonthDay" + (tmp < 10 ? "0" + tmp : "" + tmp));
            TextBox textBox = (TextBox)this.FindControl("txtCur" + idx);
            textBox.Text = propertyInfo.GetValue(attendDetailInfo).ToString();
        }
        for(int idx = 1;idx<=endDay; idx++)
        {
            propertyInfo = type.GetProperty("NextMonthDay" + (idx < 10 ? "0" + idx : "" + idx));
            TextBox textBox = (TextBox)this.FindControl("txtNext" + idx);
            textBox.Text = propertyInfo.GetValue(attendDetailInfo).ToString();
        }
    }
    private void TableInit(String startDate,String endDate) {
        String[] date = startDate.Split('-');
        int startYear = int.Parse(date[0]);
        int startMonth = int.Parse(date[1]);
        int startDay = int.Parse(date[2]);
        date = endDate.Split('-');
        int endYear = int.Parse(date[0]);
        int endMonth = int.Parse(date[1]);
        int endDay = int.Parse(date[2]);
        int daysOfCurrentMonth = DateTime.DaysInMonth(startYear, startMonth) - startDay + 1;
        this.labCurMonth.Text = startYear + "年" + startMonth + "";
        this.labNextMonth.Text = endYear + "年" + endMonth + "";
        for(int idx = 1;idx< daysOfCurrentMonth+1;idx++)
        {
            Label label = (Label)this.FindControl("labCur" + idx);
            label.Text = (startDay + idx - 1) + "";
        }
        for (int idx = daysOfCurrentMonth+1; idx <= 31 ; idx++)
        {
            Label label = (Label)this.FindControl("labCur" + idx);
            label.Visible = false;
            TextBox txtBox = (TextBox)this.FindControl("txtCur" + idx);
            txtBox.Visible = false;
        }
        for (int idx = endDay + 1; idx <= 31; idx++)
        {
            Label label = (Label)this.FindControl("labNext" + idx);
            label.Visible = false;
            TextBox txtBox = (TextBox)this.FindControl("txtNext" + idx);
            txtBox.Visible = false;
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        AttendDetailInfoData attendDetailInfoData = new AttendDetailInfoData();
        AttendDetailInfo attendDetailInfo = new AttendDetailInfo();
        if (!string.IsNullOrEmpty(id))
        {
            attendDetailInfo.Id = int.Parse(id.Trim());
        }
        UserInfo userInfo = new UserInfo();
        userInfo.Id = int.Parse(this.ddlUserName.SelectedItem.Value.Trim());
        attendDetailInfo.UserInfo = userInfo;
        AttendInfo attendInfo = new AttendInfo();
        attendInfo.Id = int.Parse(this.hfAttendId.Value.Trim());
        attendDetailInfo.AttendInfo = attendInfo;
        attendDetailInfo.Remark = this.txtRemark.Text.Trim();

        String[] date = this.hfStartDate.Value.Split('-');
        int startYear = int.Parse(date[0]);
        int startMonth = int.Parse(date[1]);
        int startDay = int.Parse(date[2]);
        date = this.hfEndDate.Value.Split('-');
        int endYear = int.Parse(date[0]);
        int endMonth = int.Parse(date[1]);
        int endDay = int.Parse(date[2]);
        int daysOfCurrentMonth = DateTime.DaysInMonth(startYear, startMonth) - startDay + 1;
        //通过反射获取数据，，难
        Type type = attendDetailInfo.GetType();//获取对象类型，即类信息
        System.Reflection.PropertyInfo propertyInfo;//声明属性对象
        for (int idx = 1; idx < daysOfCurrentMonth + 1; idx++)
        {
            int tmp = startDay + idx - 1;
            propertyInfo = type.GetProperty("CurMonthDay" + (tmp < 10 ? "0" + tmp : "" + tmp));
            TextBox textBox = (TextBox)this.FindControl("txtCur" + idx);
            propertyInfo.SetValue(attendDetailInfo, textBox.Text.Trim());
        }
        for (int idx = 1; idx <= endDay; idx++)
        {
            propertyInfo = type.GetProperty("NextMonthDay" + (idx < 10 ? "0" + idx : "" + idx));
            TextBox textBox = (TextBox)this.FindControl("txtNext" + idx);
            propertyInfo.SetValue(attendDetailInfo, textBox.Text.Trim());
        }


        //try
        //{
        attendDetailInfoData.CommitAttendDetailInfo(attendDetailInfo);
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