using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Sys_ProjectM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if(Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
            {
                Response.Write(" <script> parent.window.location.href= '../Login.aspx ' </script> ");
            }
            GridBind();
        }
    }
    private void GridBind()
    {
        DataTable dt = new DataTable();
        ProjectInfoData projectInfoData = new ProjectInfoData();
        dt = projectInfoData.GetDT();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}