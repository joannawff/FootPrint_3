<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SurveyO.aspx.cs" Inherits="Sys_SurveyO" %>


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
            $("#lableader").formValidator({ onshow: "请输入组长/安全员信息", onfocus: "组长信息不能为空", oncorrect: "输入正确" }).regexValidator({ regexp: "notempty", datatype: "enum", onerror: "错误" });
            $.formValidator.initConfig({ validatorgroup: "2" });
        });
        //时间格式转换
        function DataShortFormat(time) {
            time = time.replace("/Date(", "").replace(")/", "");
            var datetime = new Date();
            datetime.setTime(time);
            var year = datetime.getFullYear();
            var month = datetime.getMonth() + 1 < 10 ? "0" + (datetime.getMonth() + 1) : datetime.getMonth() + 1;
            var date = datetime.getDate() < 10 ? "0" + datetime.getDate() : datetime.getDate();
            var hour = datetime.getHours() < 10 ? "0" + datetime.getHours() : datetime.getHours();
            var minute = datetime.getMinutes() < 10 ? "0" + datetime.getMinutes() : datetime.getMinutes();
            var second = datetime.getSeconds() < 10 ? "0" + datetime.getSeconds() : datetime.getSeconds();
            return year + "-" + month + "-" + date;
        }
        
        function Check() {
            return jQuery.formValidator.pageIsValid("1");
        }
        function noCheck() {
            return jQuery.formValidator.pageIsValid("2");
        }

        function Close() {
            var dialog = parent.art.dialog({ id: 'Survey' });
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
                        <asp:TextBox CssClass="in01" ID="lableader" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="lableaderTip">
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td class="td01">工作项目：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="labProjectDetail" runat="server"></asp:TextBox>
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
                        <asp:TextBox CssClass="in01" ID="labMembers" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labMembersTip">
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td class="td01">计划： </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="labPlan" runat="server"></asp:TextBox>
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
                        <asp:TextBox CssClass="in01" ID="labActual" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labActualTip">
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td class="td01">收工时间：
                    </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="labOffTime" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labOffTimeTip">
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td class="td01">整理资料： </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="labSortData" runat="server"></asp:TextBox>
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
                        <asp:TextBox CssClass="in01" ID="labSortDataParticipants" runat="server"></asp:TextBox>
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
                        <asp:TextBox CssClass="in01" ID="labDevice" runat="server"></asp:TextBox>
                    </td>
                    <td class="td02b">
                        <div id="labDeviceTip">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="td01">用车记录： </td>
                    <td class="td02a">
                        <asp:TextBox CssClass="in01" ID="labVehicleRecord" runat="server"></asp:TextBox>
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
                        <asp:TextBox CssClass="in01" ID="labRemark" runat="server"></asp:TextBox>
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
    </form>
</body>
</html>