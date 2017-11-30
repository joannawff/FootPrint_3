using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// BasePage 的摘要说明
/// </summary>
public enum MessageType { Succeed = 1, Warning = 2, Error11 = 3 }

public abstract class BasePage : Page
{
    //页面ID
    protected string pageId = "";


    #region 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    public BasePage()
    {
        //根据类名取得画面ID
        //pageId = this.GetType().Name.Replace("_aspx", "");
        //pageId = this.GetType().Name.Replace("_", ".");
        pageId = this.GetType().Name.Replace("_aspx", ".aspx").Replace("_", "/");
        pageId = pageId.ToLower();
    }

    #endregion

    private string message;
    private string href;

    public string Message { get { return this.message; } }
    public string Href { get { return this.href; } }

    protected void Alert(string message, string href, MessageType messageType)
    {
        this.href = href;
        this.message = messageType + message;
    }

    protected void Alert(string message, MessageType messageType)
    {
        this.message = messageType + message;
    }
}