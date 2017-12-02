﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendO.aspx.cs" Inherits="Sys_AttendO" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Styles/css.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.js" type="text/javascript"></script>
    <script src="../Scripts/PageInit.js" type="text/javascript"></script>
    <script src="../Plugin/artDialog/artDialog.js" type="text/javascript"></script>
    <link href="../Plugin/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/artDialogInit.js" type="text/javascript"></script>
    <%--日期控件--%>
    <link href="../Plugin/My97DatePicker/WdatePicker.css" rel="stylesheet" />
    <script src="../Plugin/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../Scripts/PageInit.js" type="text/javascript"></script>
    <%--客户端验证--%>
    <script src="../Plugin/formValidator/formValidator_min.js" type="text/javascript"></script>
    <script src="../Plugin/formValidator/formValidatorRegex.js" type="text/javascript"></script>
    <link href="../Plugin/formValidator/validator.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(function () {
            dialog('<%= Message %>', '<%= Href %>');
        });
        //客户端验证
        $(document).ready(function () {
            $.formValidator.initConfig({});
            $("#txtTitle").formValidator({ onshow: "请输入考勤表名", onfocus: "考勤表名不能为空", oncorrect: "输入正确" }).regexValidator({ regexp: "notempty", datatype: "enum", onerror: "错误" });
            $("#txtStartDate").formValidator({ onshow: "请输入开始日期", onfocus: "开始日期不能为空", oncorrect: "输入正确" }).regexValidator({ regexp: "notempty", datatype: "enum", onerror: "错误" });
            $("#txtEndDate").formValidator({ onshow: "请输入结束日期", onfocus: "结束日期不能为空", oncorrect: "输入正确" }).regexValidator({ regexp: "notempty", datatype: "enum", onerror: "错误" });
            $.formValidator.initConfig({ validatorgroup: "2" });
        });

        //用于设置需要验证与不需要验证
        function Check() {
            return jQuery.formValidator.pageIsValid("1");
        }
        function noCheck() {
            return jQuery.formValidator.pageIsValid("2");
        }

        function Close() {
            var dialog = parent.art.dialog({ id: 'Attend' });
            if (dialog != null) {
                dialog.close();
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 5px 10px 0px 3px;">
            <table class="t01">
                <tr>
                    <td class="td01">项目：
                    </td>
                    <td class="td02a">
                        <asp:DropDownList ID="ddlProject" runat="server" CssClass="se01">
                        </asp:DropDownList>
                    </td>
                    <td class="td02b">
                        <div id="ddlProjectTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">考勤表名：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" Width="98%" ID="txtTitle" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="txtTitleTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">制表人：
                    </td>
                    <td class="td02a">
                        <asp:DropDownList ID="ddlCreater" runat="server" Width="80px" CssClass="se01">
                        </asp:DropDownList>
                    </td>
                    <td class="td02b">
                        <div id="ddlCreaterTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">复查：
                    </td>
                    <td class="td02a">
                        <asp:DropDownList ID="ddlReviewer" runat="server" Width="80px" CssClass="se01">
                        </asp:DropDownList>
                    </td>
                    <td class="td02b">
                        <div id="ddlReviewerTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">审核：
                    </td>
                    <td class="td02a">
                        <asp:DropDownList ID="ddlAuditor" runat="server" Width="80px" CssClass="se01">
                        </asp:DropDownList>
                    </td>
                    <td class="td02b">
                        <div id="ddlAuditorTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">开始日期：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="txtStartDate" onfocus="WdatePicker()" Width="80px" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="txtStartDateTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">结束日期：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="txtEndDate" onfocus="WdatePicker()" Width="80px" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="txtEndDateTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">制表时间：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="txtCreateDate" onfocus="WdatePicker()" Width="80px" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="txtCreateDateTip">
                        </div>
                    </td>
                </tr>
            </table>
            <p class="button-p01">
                <asp:Button ID="btnConfirm" runat="server" CssClass="bu03" OnClientClick="return Check();"
                    OnClick="btnConfirm_Click" Text="确定" />
                <input id="btnClose" type="submit" onclick="Close()" class="bu03" value="关闭" />
            </p>
            <asp:Panel ID="panelClose" runat="server" Visible="false">
                <script type="text/javascript">
                    parent.art.dialog.data('message', '<%= Message %>');
                    Close();
                </script>
            </asp:Panel>
        </div>
    </form>
</body>
</html>