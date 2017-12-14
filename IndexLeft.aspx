<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndexLeft.aspx.cs" Inherits="IndexLeft" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Styles/StyleSheet1.css" type="text/css" rel="stylesheet" />
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="Plugin/ddaccordion/ddaccordion.js"></script>
    <link href="Plugin/ddaccordion/ddaccordion.css" rel="stylesheet" />
    <script src="Scripts/Services.js" type="text/javascript"></script>
    <script type="text/javascript">
        //menu(菜单栏的控制--各种css+js事件)
        ddaccordion.init({
            headerclass: "expandable", //Shared CSS class name of headers group that are expandable
            contentclass: "categoryitems", //Shared CSS class name of contents group
            revealtype: "click", //Reveal content when user clicks or onmouseover the header? Valid value: "click", "clickgo", or "mouseover"
            mouseoverdelay: 200, //if revealtype="mouseover", set delay in milliseconds before header expands onMouseover
            collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
            defaultexpanded: [0], //index of content(s) open by default [index1, index2, etc]. [] denotes no content
            onemustopen: false, //Specify whether at least one header should be open always (so never all headers closed)
            animatedefault: false, //Should contents open by default be animated into view?
            persiststate: true, //persist state of opened contents within browser session?
            toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
            togglehtml: ["prefix", "", ""], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
            animatespeed: "fast", //speed of animation: integer in milliseconds (ie: 200), or keywords "fast", "normal", or "slow"
            oninit: function (headers, expandedindices) { //custom code to run when headers have initalized
                //do nothing
            },
            onopenclose: function (header, index, state, isuseractivated) { //custom code to run whenever a header is opened or closed
                //do nothing
            }
        })
    </script>
    <base target="main" />
</head>
<body class="le-body">
    <form id="form1" runat="server">
        <div style="height: 27px; line-height :27px; vertical-align :central; width: 172px; font-size: 14px; background-image: url('images/left-bg03.gif'); background-repeat: no-repeat; text-align: center; font-weight: bolder; color: #ff0">
            系统菜单
            
        </div>
        <div id="main" class="arrowlistmenu">
            <asp:Panel ID="panelProject" runat="server">
                <h3 class='menuheader expandable'>业务管理</h3>
                <ul class='categoryitems'>
                    <li><a href="Sys/SurveyM.aspx">勘测日志</a></li>
                    <li><a href="Sys/AttendM.aspx">考勤日志</a></li>
                    <li><a href="Sys/ReportM.aspx">报表管理</a></li>
                </ul>
            </asp:Panel>
            <asp:Panel ID="panelData" runat="server">
                <h3 class='menuheader expandable'>数据维护</h3>
                <ul class='categoryitems'>
                    <li><a href="Sys/ProjectM.aspx">项目管理</a></li>
                    <li><a href="Sys/UserInfoM.aspx">用户管理</a></li>
                </ul>
            </asp:Panel>
            <asp:Panel ID="panelEmployee" runat="server">
            <h3 class='menuheader expandable'>个人信息</h3>
                <ul class='categoryitems'>
                    <li><a href="Sys/UserInfoD.aspx">个人信息</a></li>
                    <li><a href="Sys/ChangePassword.aspx">密码修改</a></li>
                    <li><a href="Sys/AttendInfoM.aspx">个人考勤</a></li>
                </ul>
            </asp:Panel>
        </div>
        <div>
        </div>
    </form>
</body>
</html>
