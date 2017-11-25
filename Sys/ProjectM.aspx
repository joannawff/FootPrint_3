<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectM.aspx.cs" Inherits="Sys_ProjectM" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>项目管理</title>
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
    <script type="text/javascript">
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
            return year + "-" + month + "-" + date ;
        }

        $(function () {
            dialog('<%= Message %>', '<%= Href %>');
        });

        //修改
        function Edit(id) {
            var url = 'ProjectO.aspx';
            if (id != "") {
                url = url + '?id=' + id;
            }
            art.dialog.open(url,
            {
                id: 'Project',
                title: '项目信息维护',
                fixed: true,
                top: 100,
                width: 1000,
                height: 250,
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
        //查看
        function View(id) {
            var url = 'ProjectV.aspx';
            if (id != "") {
                url = url + '?id=' + id;
            }
            art.dialog.open(url,
            {
                id: 'Project',
                title: '项目信息',
                fixed: true,
                top: 100,
                width: 1000,
                height: 250,
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="DivHeader">
            <div style="float: right; text-align: right; margin-right: 5px;">
                <input id="btnAdd" type="button" onclick="Edit('');" class="bu02" value="添加" />
            </div>
            <h2>项目管理</h2>
        </div>
        <div>
            <table class="t02">
                <tbody>
                    <tr style="height: 40px;">
                        <td style="text-align: right; width: 200px; font-weight: bold;"></td>
                        <td style="text-align: right; width: 80px; font-weight: bold;">项目名：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtCondition" class="in01" runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: center; width: 120px;">
                            <asp:Button ID="btnQuery" class="bu03" runat="server" Text="查询"/>
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
                ShowHeaderWhenEmpty="True">
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
                    <asp:BoundField DataField="Resident" ItemStyle-Width="200px" HeaderText="驻地"></asp:BoundField>
                
                    <asp:TemplateField HeaderText="修改" ItemStyle-Width="40px">
                        <ItemTemplate>
                            <img alt="修改" style="cursor: pointer;" onclick="Edit(<%# DataBinder.Eval(Container.DataItem, "Id")%>)"
                                src="../Images/bb-ud.gif" />
                        </ItemTemplate>
                        <ItemStyle Width="40px"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="NextPreviousFirstLast" Visible="False" />
            </asp:GridView>
        </div>
        <div id="print" style="display:none;"></div>
    </form>
</body>
</html>