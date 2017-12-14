using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_ReportO : System.Web.UI.Page
{
    string id;
    int type;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userId"] == null || Session["userId"].ToString().Trim().Equals(""))
        {
            Response.Write("<script language=javascript>top.location.href='../Login.aspx'</script>");
            return;
        }
        id = Request["id"];
        type = int.Parse(Request["type"].Trim());
        if (!this.IsPostBack)
        {
            if (!string.IsNullOrEmpty(id))
            {
                PageInit(id);
            }
        }
    }

    private void PageInit(string id)
    {
        //Response.ContentType = "application/x-zip-compressed";
        //Response.AddHeader("Content-Disposition", "attachment;filename=8月份报表.zip");
        //string filename = Server.MapPath("DownLoad/8月份报表.zip");
        ////指定编码 防止中文文件名乱码  
        //Response.HeaderEncoding = System.Text.Encoding.GetEncoding("gb2312");
        //Response.TransmitFile(filename);

        string fileName = "aaa.txt";//客户端保存的文件名  
        string filePath = Server.MapPath("DownLoad/aaa.txt");//路径  
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
        if (fileInfo.Exists == true)
        {
            const long ChunkSize = 102400;//100K 每次读取文件，只读取100K，这样可以缓解服务器的压力  
            byte[] buffer = new byte[ChunkSize];

            Response.Clear();
            System.IO.FileStream iStream = System.IO.File.OpenRead(filePath);
            long dataLengthToRead = iStream.Length;//获取下载的文件总大小  
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
            while (dataLengthToRead > 0 && Response.IsClientConnected)
            {
                int lengthRead = iStream.Read(buffer, 0, Convert.ToInt32(ChunkSize));//读取的大小  
                Response.OutputStream.Write(buffer, 0, lengthRead);
                Response.Flush();
                dataLengthToRead = dataLengthToRead - lengthRead;
            }
            Response.Close();
        }
    }
}