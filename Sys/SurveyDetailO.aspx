<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SurveyDetailO.aspx.cs" Inherits="Sys_SurveyDetailO" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            $("#txtLeaderAndSecurityOfficer").formValidator({ onshow: "请输入组长/安全员信息", onfocus: "组长信息不能为空", oncorrect: "输入正确" }).regexValidator({ regexp: "notempty", datatype: "enum", onerror: "错误" });
            $.formValidator.initConfig({ validatorgroup: "2" });
        });
        
        function Check() {
            return jQuery.formValidator.pageIsValid("1");
        }
        function noCheck() {
            return jQuery.formValidator.pageIsValid("2");
        }

        function Close() {
            var dialog = parent.art.dialog({ id: 'SurveyDetail' });
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
                    <td class="td01">组长兼安全员：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="txtLeaderAndSecurityOfficer" Width="98%" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="ddlLeaderTip">
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td class="td01">工作项目：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="txtProjectDetail" Width="98%" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labProjectDetailTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">组员：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" Width="98%" ID="txtMembers" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labMembersTip">
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td class="td01">计划： </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" Width="98%" ID="txtPlan" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labPlanTip">
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td class="td01">实际：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" Width="98%" ID="txtActual" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labActualTip">
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td class="td01">收工时间：
                    </td>
                    <td class="td02a" style="vertical-align:bottom;">
                        <asp:TextBox CssClass="in01" ID="txtOffTime" onfocus="WdatePicker()" Width="80px" runat="server"></asp:TextBox>&nbsp;
                        <asp:DropDownList ID="ddlHour" Width="50px" runat="server" CssClass="se01">
                        </asp:DropDownList>时&nbsp;
                        <asp:DropDownList ID="ddlMinute" Width="50px" runat="server" CssClass="se01">
                        </asp:DropDownList>分&nbsp;
                        <asp:DropDownList ID="ddlSecond" Width="50px" runat="server" CssClass="se01">
                        </asp:DropDownList>秒
                    </td>
                    <td class="td02b">
                        <div id="labOffTimeTip">
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td class="td01">整理资料： </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" Width="98%" ID="txtSortData" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labSortDataTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">整理资料参与人员：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" Width="98%" ID="txtSortDataParticipants" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labSortDataParticipantsTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">使用仪器及设备号：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" Width="98%" ID="txtDevice" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labDeviceTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">用车记录： </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" Width="98%" ID="txtVehicleRecord" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labVehicleRecordTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">备注：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" Width="98%" ID="txtRemark" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labRemarkTip">
                        </div>
                    </td>
                </tr>
            </table>
            <p class="button-p01">
                <asp:Button ID="btnConfirm" runat="server" CssClass="bu03" OnClientClick="return Check();"
                    OnClick="btnConfirm_Click" Text="确定" />
                <input id="btnClose" type="submit" onclick="Close(); return false;" class="bu03" value="关闭" />
            </p>
            <asp:Panel ID="panelClose" runat="server" Visible="false">
                <script type="text/javascript">
                    parent.art.dialog.data('message', '<%= Message %>');
                    Close();
                </script>
            </asp:Panel>
        </div>
        <div>
            <asp:HiddenField ID="hfSurveyId" runat="server" />
        </div>
    </form>
</body>
</html>