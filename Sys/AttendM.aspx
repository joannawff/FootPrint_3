﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendM.aspx.cs" Inherits="Sys_AttendM" %>

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
        <script type="text/javascript">
            $(function () {
                dialog('<%= Message %>', '<%= Href %>');
           });
            //修改
            function Edit(id) {
                var url = 'AttendO.aspx';
                if (id != "") {
                    url = url + '?id=' + id;
                }
                art.dialog.open(url,
                    {
                        id: 'Attend',
                        title: '考勤信息维护',
                        fixed: true,
                        top: 80,
                        width: 1000,
                        height: 350,
                        resize: false,
                        close: function () {
                            if (art.dialog.data('message') != undefined) {
                                art.dialog({
                                    content: art.dialog.data('message').substring(7),
                                    icon: "succeed",
                                    title: "成功",
                                    ok: function () {
                                        $("#btnQuery").click();
                                    }
                                });
                                art.dialog.removeData('message');
                            }
                        }
                    }, false);
            }
            //GoTo详细信息
            function Go(id) {
                var url = 'AttendDetailM.aspx';
                if (id != "") {
                    url = url + '?id=' + id;
                }
                window.location.href = url;
            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="DivHeader">
            <div style="float: right; text-align: right; margin-right: 5px;">
                <input id="btnAdd" type="button" onclick="Edit('');" class="bu02" value="添加" />
            </div>
            <h2>考勤表</h2>
        </div>
        <div>
            <table class="t02">
                <tbody>
                    <tr style="height: 40px;">
                        <td style="text-align: right; width: 80px; font-weight: bold;">项目名：
                        </td>
                        <td style="text-align: left; width: 200px;">
                            <asp:TextBox ID="txtConditionProjectName" Width="98%" class="in01" runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: right; width: 80px; font-weight: bold;">表名：
                        </td>
                        <td style="text-align: left; width: auto;">
                            <asp:TextBox ID="txtConditionTitle" class="in01" Width="95%" runat="server"></asp:TextBox>
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
                ShowHeaderWhenEmpty="True" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
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
                    <asp:BoundField DataField="ProjectName" HeaderText="项目名" ItemStyle-Width="280px"></asp:BoundField>
                    <asp:BoundField DataField="Title" HeaderText="表名"></asp:BoundField>
                    <asp:BoundField DataField="StartDate" ItemStyle-Width="80px" HeaderText="开始日期" />
                    <asp:BoundField DataField="EndDate" ItemStyle-Width="80px" HeaderText="结束日期" />
                    <asp:TemplateField HeaderText="详情" ItemStyle-Width="40px">
                        <ItemTemplate>
                            <img alt="详情" style="cursor: pointer;" src="../Images/bb-show.gif"  onclick="Go(<%# DataBinder.Eval(Container.DataItem, "Id")%>)"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="修改" ItemStyle-Width="40px">
                        <ItemTemplate>
                            <img alt="修改" style="cursor: pointer;" onclick="Edit(<%# DataBinder.Eval(Container.DataItem, "Id")%>)"
                                src="../Images/bb-ud.gif" />
                        </ItemTemplate>
                        <ItemStyle Width="40px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除" ItemStyle-Width="40px">
                         <ItemTemplate>
                             <asp:ImageButton ID="imgBtn" OnClientClick="javascript:return confirm('数据删除后无法恢复，您确定删除整张考勤日志表吗？');" 
                                 CommandName="del" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' runat="server" ImageUrl="../images/bb-del.gif" />
                         </ItemTemplate>
                         <ItemStyle Width="40px" />
                     </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="NextPreviousFirstLast" Visible="False" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
