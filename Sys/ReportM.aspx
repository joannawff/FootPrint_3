<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportM.aspx.cs" Inherits="Sys_ReportM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>报表管理</title>
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
    <script type="text/javascript">
            $(function () {
                dialog('<%= Message %>', '<%= Href %>');
            });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="DivHeader">
            <h2>报表管理</h2>
        </div>
        <div>
            <table class="t02">
                <tbody>
                    <tr style="height: 40px;">
                        <td style="text-align: right; width: 200px; font-weight: bold;"></td>
                        <td style="text-align: right; width: 80px; font-weight: bold;">项目名：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtConditionProjectName" Width="98%" class="in01" runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: center; width: 120px;">
                            <asp:Button ID="btnQuery" class="bu03" runat="server" Text="查询" OnClick="btnQuery_Click"/>
                        </td>
                        <td style="text-align: center; width: 120px;"></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="margin: 5px 10px 0px 3px;">
            <asp:GridView ID="GridView1" DataKeyNames="Id" AllowSorting="True"
                runat="server" BorderColor="#A1B6E1" BorderWidth="1px" CellPadding="1" AutoGenerateColumns="False"
                PageSize="15" 
                ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand">
                <PagerSettings Mode="NextPreviousFirstLast" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" BackColor="#FFCC33" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <EmptyDataRowStyle CssClass="GridViewEmptyStyle" />
                <EmptyDataTemplate>
                    暂无数据
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField>
                        <HeaderStyle Width="40px"></HeaderStyle>
                        <HeaderTemplate>
                            序号
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="labID" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProjectName"  HeaderText="项目名"></asp:BoundField>
                    <asp:BoundField DataField="UserName" ItemStyle-Width="60px" HeaderText="负责人"></asp:BoundField>
                    <asp:BoundField DataField="Tel" ItemStyle-Width="60px" HeaderText="联系方式" />
                    <asp:BoundField DataField="Resident" ItemStyle-Width="100px" HeaderText="驻地"></asp:BoundField>
                
                    <asp:TemplateField HeaderText="勘测报表" ItemStyle-Width="60px">
                         <ItemTemplate>
                             <asp:ImageButton ID="exportSurveyReportBtn" OnClientClick="javascript:return confirm('您确定下载勘测日志报表吗？');" CommandName="printSurvey" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' runat="server" ImageUrl="../images/bb-print.gif" />
                         </ItemTemplate>
                         <ItemStyle Width="60px" />
                     </asp:TemplateField>
                    <asp:TemplateField HeaderText="考勤报表" ItemStyle-Width="60px">
                         <ItemTemplate>
                             <asp:ImageButton ID="exportAttendReportBtn" OnClientClick="javascript:return confirm('您确定下载考勤日志报表吗？');" CommandName="printAttend" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' runat="server" ImageUrl="../images/bb-print.gif" />
                         </ItemTemplate>
                         <ItemStyle Width="60px" />
                     </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="NextPreviousFirstLast" Visible="False" />
            </asp:GridView>
            <asp:Panel ID="panelClose" runat="server" Visible="false">
                <script type="text/javascript">
                    parent.art.dialog.data('message', '<%= Message %>');
                    Close();
                </script>
            </asp:Panel>
        </div>
        <div>
            <asp:HiddenField ID="hfProjectId" runat="server" />
        </div>
    </form>
</body>
</html>
