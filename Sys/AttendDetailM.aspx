<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendDetailM.aspx.cs" Inherits="Sys_AttendDetailM" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>考勤管理</title>
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
            var url = 'AttendDetailO.aspx';
            
            url = url + '?startAndEndDate=' + '<%=GetStartAndEndDate() %>';
            url = url + '&attendId=' + '<%=this.hfAttendId.Value.Trim() %>';
            if (id != "") {
                url = url + '&id=' + id;
            }
            art.dialog.open(url,
            {
                id: 'AttendDetail',
                title: '考勤信息维护',
                fixed: true,
                top: 60,
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
        function MakeStaticHeader(gridId, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById('DivHeaderRow');
                var DivMC = document.getElementById('DivMainContent');

                //*** Set divheaderRow Properties ****
                DivHR.style.height = headerHeight + 'px';
                DivHR.style.width = (parseInt(width) - 16) + 'px';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '10';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + 'px';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -headerHeight + 'px';
                DivMC.style.zIndex = '1';
                //****Copy Header in divHeaderRow****
                DivHR.appendChild(tbl.cloneNode(true));
            }
        }



        function OnScrollDiv(Scrollablediv) {
            document.getElementById('DivHeaderRow').scrollLeft = Scrollablediv.scrollLeft;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="DivHeader">
            <div style="float: right; text-align: right; margin-right: 5px;">
                <input id="btnAdd" type="button" onclick="Edit('')" class="bu02" value="添加" />
            </div>
            <h2>考勤日志</h2>
        </div>
        <div>
            <table class="t02">
                <tbody>
                    <tr style="height: 40px;">
                        <td style="text-align: right; width: 200px; font-weight: bold;"></td>
                        <td style="text-align: right; width: 80px; font-weight: bold;">姓名：
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtConditionUserName" class="in01" Width="95%" runat="server"></asp:TextBox>
                        </td>
                        <td style="text-align: center; width: 120px;">
                            <asp:Button ID="btnQuery" class="bu03" runat="server" Text="查询" OnClick="btnQuery_Click"/>
                        </td>
                        <td style="text-align: center; width: 120px;"></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div id ="DivRoot">
            <div style="overflow:hidden;" id="DivHeaderRow">
            </div>
            <div style="overflow:scroll;" onscroll="OnScrollDiv(this)" id="DivMainContent">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                 AllowSorting="True" GridLines="Both" BorderColor="#A1B6E1" ShowFooter="true"
                 BorderWidth="1px" CellPadding="1" DataKeyNames="Id" 
                 OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" 
                 PageSize="15" ShowHeaderWhenEmpty="True">
                 <PagerSettings Mode="NextPreviousFirstLast" />
                 <FooterStyle CssClass="GridViewFooterStyle" />
                 <RowStyle CssClass="GridViewRowStyle" />
                 <SelectedRowStyle BackColor="#FFCC33" CssClass="GridViewSelectedRowStyle" />
                 <PagerStyle CssClass="GridViewPagerStyle" />
                 <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                 <HeaderStyle CssClass="GridViewHeaderStyle" />
                 <EmptyDataRowStyle CssClass="GridViewEmptyStyle" />
                 <EmptyDataTemplate>
                     暂无数据
                 </EmptyDataTemplate>
                 <Columns>
                     <asp:TemplateField>
                         <HeaderStyle Width="40px" />
                         <HeaderTemplate>
                             序号
                         </HeaderTemplate>
                         <ItemTemplate>
                             <asp:Label ID="labID" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="UserName" ItemStyle-Width="60px" HeaderText="姓名" />
                     <asp:BoundField DataField="curMonthDay01" HeaderText="01" />
                     <asp:BoundField DataField="curMonthDay02" HeaderText="02" />
                     <asp:BoundField DataField="curMonthDay03" HeaderText="03" />
                     <asp:BoundField DataField="curMonthDay04" HeaderText="04" />
                     <asp:BoundField DataField="curMonthDay05" HeaderText="05" />
                     <asp:BoundField DataField="curMonthDay06" HeaderText="06" />
                     <asp:BoundField DataField="curMonthDay07" HeaderText="07" />
                     <asp:BoundField DataField="curMonthDay08" HeaderText="08" />
                     <asp:BoundField DataField="curMonthDay09" HeaderText="09" />
                     <asp:BoundField DataField="curMonthDay10" HeaderText="10" />
                     <asp:BoundField DataField="curMonthDay11" HeaderText="11" />
                     <asp:BoundField DataField="curMonthDay12" HeaderText="12" />
                     <asp:BoundField DataField="curMonthDay13" HeaderText="13" />
                     <asp:BoundField DataField="curMonthDay14" HeaderText="14" />
                     <asp:BoundField DataField="curMonthDay15" HeaderText="15" />
                     <asp:BoundField DataField="curMonthDay16" HeaderText="16" />
                     <asp:BoundField DataField="curMonthDay17" HeaderText="17" />
                     <asp:BoundField DataField="curMonthDay18" HeaderText="18" />
                     <asp:BoundField DataField="curMonthDay19" HeaderText="19" />
                     <asp:BoundField DataField="curMonthDay20" HeaderText="20" />
                     <asp:BoundField DataField="curMonthDay21" HeaderText="21" />
                     <asp:BoundField DataField="curMonthDay22" HeaderText="22" />
                     <asp:BoundField DataField="curMonthDay23" HeaderText="23" />
                     <asp:BoundField DataField="curMonthDay24" HeaderText="24" />
                     <asp:BoundField DataField="curMonthDay25" HeaderText="25" />
                     <asp:BoundField DataField="curMonthDay26" HeaderText="26" />
                     <asp:BoundField DataField="curMonthDay27" HeaderText="27" />
                     <asp:BoundField DataField="curMonthDay28" HeaderText="28" />
                     <asp:BoundField DataField="curMonthDay29" HeaderText="29" />
                     <asp:BoundField DataField="curMonthDay30" HeaderText="30" />
                     <asp:BoundField DataField="curMonthDay31" HeaderText="31" />
                     <asp:BoundField DataField="nextMonthDay01" HeaderText="01" />
                     <asp:BoundField DataField="nextMonthDay02" HeaderText="02" />
                     <asp:BoundField DataField="nextMonthDay03" HeaderText="03" />
                     <asp:BoundField DataField="nextMonthDay04" HeaderText="04" />
                     <asp:BoundField DataField="nextMonthDay05" HeaderText="05" />
                     <asp:BoundField DataField="nextMonthDay06" HeaderText="06" />
                     <asp:BoundField DataField="nextMonthDay07" HeaderText="07" />
                     <asp:BoundField DataField="nextMonthDay08" HeaderText="08" />
                     <asp:BoundField DataField="nextMonthDay09" HeaderText="09" />
                     <asp:BoundField DataField="nextMonthDay10" HeaderText="10" />
                     <asp:BoundField DataField="nextMonthDay11" HeaderText="11" />
                     <asp:BoundField DataField="nextMonthDay12" HeaderText="12" />
                     <asp:BoundField DataField="nextMonthDay13" HeaderText="13" />
                     <asp:BoundField DataField="nextMonthDay14" HeaderText="14" />
                     <asp:BoundField DataField="nextMonthDay15" HeaderText="15" />
                     <asp:BoundField DataField="nextMonthDay16" HeaderText="16" />
                     <asp:BoundField DataField="nextMonthDay17" HeaderText="17" />
                     <asp:BoundField DataField="nextMonthDay18" HeaderText="18" />
                     <asp:BoundField DataField="nextMonthDay19" HeaderText="19" />
                     <asp:BoundField DataField="nextMonthDay20" HeaderText="20" />
                     <asp:BoundField DataField="nextMonthDay21" HeaderText="21" />
                     <asp:BoundField DataField="nextMonthDay22" HeaderText="22" />
                     <asp:BoundField DataField="nextMonthDay23" HeaderText="23" />
                     <asp:BoundField DataField="nextMonthDay24" HeaderText="24" />
                     <asp:BoundField DataField="nextMonthDay25" HeaderText="25" />
                     <asp:BoundField DataField="nextMonthDay26" HeaderText="26" />
                     <asp:BoundField DataField="nextMonthDay27" HeaderText="27" />
                     <asp:BoundField DataField="nextMonthDay28" HeaderText="28" />
                     <asp:BoundField DataField="nextMonthDay29" HeaderText="29" />
                     <asp:BoundField DataField="nextMonthDay30" HeaderText="30" />
                     <asp:BoundField DataField="nextMonthDay31" HeaderText="31" />
                     <asp:TemplateField HeaderText="详情" ItemStyle-Width="40px">
                         <ItemTemplate>
                            <img alt="查看" style="cursor: pointer;" src="../Images/bb-show.gif" />
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="修改" ItemStyle-Width="40px">
                         <ItemTemplate>
                            <img alt="修改" style="cursor: pointer;" onclick="Edit(<%# DataBinder.Eval(Container.DataItem, "Id")%>)"
                                src="../Images/bb-ud.gif" />
                         </ItemTemplate>
                         <ItemStyle Width="40px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="删除" ItemStyle-Width="40px">
                         <ItemTemplate>
                             <asp:ImageButton ID="imgBtn" OnClientClick="javascript:return confirm('数据删除后无法恢复，您确定删除？');" CommandName="del" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' runat="server" ImageUrl="../images/bb-del.gif" />
                         </ItemTemplate>
                         <ItemStyle Width="40px" />
                     </asp:TemplateField>
                 </Columns>
                 <PagerSettings Mode="NextPreviousFirstLast" Visible="False" />
             </asp:GridView>
            </div>
        </div>
        <div>
            <asp:HiddenField ID="hfAttendId" runat="server" />
        </div>
    </form>
</body>
</html>
