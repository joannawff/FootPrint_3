using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexLeft : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals("") || Session["roleCode"] == null || Session["roleCode"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        int roleCode = int.Parse(Session["roleCode"].ToString().Trim());
        if (roleCode > 1)//不是管理员
        {
            this.panelData.Visible = false;   
        }
        if(roleCode > 2)//不是项目负责人
        {
            this.panelProject.Visible = false;
        }
    }
}