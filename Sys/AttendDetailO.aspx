<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendDetailO.aspx.cs" Inherits="Sys_AttendDetailO" %>

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
        
        function Close() {
            var dialog = parent.art.dialog({ id: 'AttendDetail' });
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
                <tr><td class="td00" style="text-align:right">姓名</td>
                    <td class="td00" colspan ="31">
                        <asp:DropDownList ID="ddlUserName" runat="server" Width="100px" CssClass="se01"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="td00" style="text-align:right">
                        <asp:Label ID="labCurMonth" runat="server"></asp:Label>月：
                    </td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur1" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur2" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur3" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur4" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur5" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur6" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur7" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur8" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur9" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur10" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur11" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur12" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur13" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur14" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur15" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur16" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur17" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur18" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur19" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur20" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur21" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur22" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur23" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur24" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur25" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur26" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur27" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur28" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur29" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur30" runat="server"></asp:Label></td>
                    <td class="td00" style="width:20px;"><asp:Label ID="labCur31" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="td00" style="text-align:right">
                        考勤纪录：
                    </td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur1" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur2" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur3" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur4" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur5" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur6" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur7" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur8" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur9" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur10" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur11" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur12" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur13" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur14" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur15" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur16" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur17" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur18" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur19" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur20" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur21" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur22" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur23" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur24" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur25" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur26" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur27" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur28" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur29" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur30" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtCur31" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="td00" style="text-align:right">
                        <asp:Label ID="labNextMonth" runat="server"></asp:Label>月：
                    </td>
                    <td class="td00"><asp:Label ID="labNext1" Width="16px" runat="server" Text="01"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext2" Width="16px" runat="server" Text="02"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext3" Width="20px" runat="server" Text="03"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext4" Width="20px" runat="server" Text="04"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext5" Width="20px" runat="server" Text="05"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext6" Width="20px" runat="server" Text="06"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext7" Width="20px" runat="server" Text="07"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext8" Width="20px" runat="server" Text="08"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext9" Width="20px" runat="server" Text="09"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext10" Width="20px" runat="server" Text="10"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext11" Width="20px" runat="server" Text="11"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext12" Width="20px" runat="server" Text="12"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext13" Width="20px" runat="server" Text="13"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext14" Width="20px" runat="server" Text="14"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext15" Width="20px" runat="server" Text="15"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext16" Width="20px" runat="server" Text="16"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext17" Width="20px" runat="server" Text="17"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext18" Width="20px" runat="server" Text="18"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext19" Width="20px" runat="server" Text="19"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext20" Width="20px" runat="server" Text="20"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext21" Width="20px" runat="server" Text="21"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext22" Width="20px" runat="server" Text="22"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext23" Width="20px" runat="server" Text="23"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext24" Width="20px" runat="server" Text="24"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext25" Width="20px" runat="server" Text="25"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext26" Width="20px" runat="server" Text="26"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext27" Width="20px" runat="server" Text="27"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext28" Width="20px" runat="server" Text="28"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext29" Width="20px" runat="server" Text="29"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext30" Width="20px" runat="server" Text="30"></asp:Label></td>
                    <td class="td00"><asp:Label ID="labNext31" Width="20px" runat="server" Text="31"></asp:Label></td>
                </tr>
                <tr>
                    <td class="td00" style="text-align:right">
                        考勤纪录：
                    </td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext1" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext2" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext3" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext4" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext5" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext6" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext7" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext8" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext9" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext10" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext11" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext12" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext13" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext14" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext15" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext16" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext17" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext18" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext19" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext20" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext21" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext22" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext23" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext24" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext25" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext26" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext27" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext28" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext29" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext30" runat="server"></asp:TextBox></td>
                    <td class="td00"><asp:TextBox CssClass="in01" Width="15px" ID="txtNext31" runat="server"></asp:TextBox></td>
                </tr>
                <tr><td class="td00" style="text-align:right">备注</td>
                    <td class="td00" colspan ="31">
                        <asp:TextBox ID="txtRemark" CssClass="in01" Width="400px" runat="server"></asp:TextBox>
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
        <div>
            <asp:HiddenField ID="hfStartDate" runat="server" />
            <asp:HiddenField ID="hfEndDate" runat="server" />
            <asp:HiddenField ID="hfAttendId" runat="server" />
        </div>
    </form>
</body>
</html>