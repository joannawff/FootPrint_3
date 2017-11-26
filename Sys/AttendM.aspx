<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendM.aspx.cs" Inherits="Sys_AttendM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>考勤日志</title>
    <link href="../Styles/css.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/GridView.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.js" type="text/javascript"></script>
    <script src="../Scripts/PageInit.js" type="text/javascript"></script>
    <script src="../Plugin/artDialog/artDialog.js" type="text/javascript"></script>
    <script src="../Plugin/artDialog/plugins/iframeTools.source.js" type="text/javascript"></script>
    <link href="../Plugin/artDialog/skins/default.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/artDialogInit.js" type="text/javascript"></script>
    <%--日期控件--%>
    <link href="../Plugin/My97DatePicker/WdatePicker.css" rel="stylesheet" />
    <script src="../Plugin/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Scripts/PageInit.js" type="text/javascript"></script>
    <script src="../Plugin/lodop/LodopFuncs.js"></script>
    <style type="text/css">
        #print table{
            border-right:1px solid black;border-bottom:1px solid black;
        }
        #print table td{
            border-left:1px solid black;border-top:1px solid black;
        } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="DivHeader">
            <div style="float: right; text-align: right; margin-right: 5px;">
                <input id="btnAdd" type="button" onclick="Edit('');" class="bu02" value="添加" />
            </div>
            <h2>勘测日志</h2>
        </div>
        <div>
            <table class="t02">
                <tbody>
                    <tr style="height: 40px;">
                        <td style="text-align: right; width: 80px; font-weight: bold;">项目名：
                        </td>
                        <td style="text-align: left; width: 200px;">
                            <asp:DropDownList ID="ddlProject" runat="server" CssClass="se01">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right; width: 80px; font-weight: bold;">开始日期:
                        &nbsp;
                        </td>
                        <td style="text-align: right; width: 80px; font-weight: bold;">
                        <asp:TextBox CssClass="in01" ID="TextBox2" onfocus="WdatePicker()" Width="80px" runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 80px; font-weight: bold;">结束日期:
                        </td>
                        <td>
                        <asp:TextBox CssClass="in01" ID="TextBox1" onfocus="WdatePicker()" Width="80px" runat="server"></asp:TextBox>&nbsp;&nbsp; <asp:Button ID="btnQuery" class="bu03" runat="server" Text="查询" OnClick="Button1_Click"/></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
