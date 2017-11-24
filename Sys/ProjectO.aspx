<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectO.aspx.cs" Inherits="Sys_ProjectO" %>

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
            $("#ProjectName").formValidator({ onshow: "请输入项目名", onfocus: "项目名不能为空", oncorrect: "输入正确" }).regexValidator({ regexp: "notempty", datatype: "enum", onerror: "错误" });
            $("#Resident").formValidator({ onshow: "请输入驻地信息", onfocus: "驻地信息不能为空", oncorrect: "输入正确" }).regexValidator({ regexp: "notempty", datatype: "enum", onerror: "错误" });
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
            var dialog = parent.art.dialog({ id: 'Project' });
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
                    <td class="td01">项目名：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="ProjectName" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="ProjectNameTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">负责人：
                    </td>
                    <td class="td02a">
                        <asp:DropDownList Width="80px" ID="User" runat="server" CssClass="se01">
                        </asp:DropDownList>
                    </td>
                    <td class="td02b">
                        <div id="UserTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">驻地：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="Resident" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="ResidentTip">
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