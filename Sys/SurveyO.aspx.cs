using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_SurveyO : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write(" <script> parent.window.location.href= 'Login.aspx ' </script> ");
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {

    }
}