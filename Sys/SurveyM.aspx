<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SurveyM.aspx.cs" Inherits="Sys_SurveyM" %>

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
            return year + "-" + month + "-" + date;
        }

        $(function () {
            dialog('<%= Message %>', '<%= Href %>');
        });
        //修改
        function Edit(id) {
            var url = 'SurveyO.aspx';
            if (id != "") {
                url = url + '?id=' + id;
            }
            art.dialog.open(url,
                {
                    id: 'Survey',
                    title: '勘测信息维护',
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
        //查看
        function View(id) {
            var url = 'SurveyV.aspx';
            if (id != "") {
                url = url + '?id=' + id;
            }
            art.dialog.open(url,
                {
                    id: 'Survey',
                    title: '勘测信息',
                    fixed: true,
                    top: 100,
                    width: 1000,
                    height: 320,
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
            <h2>勘测日志</h2>
        </div>
        <div>
            <table class="t02">
                <tbody>
                    <tr style="height: 40px;">
                        <td style="text-align: right; width: 200px; font-weight: bold;"></td>
                        <td style="text-align: right; width: 80px; font-weight: bold;">项目名：
                        </td>
                        <td style="text-align: left; width: 200px;">
                            <asp:DropDownList ID="ddlProject" runat="server" CssClass="se01">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: center; width: 120px;">
                            <asp:Button ID="btnQuery" class="bu03" runat="server" Text="查询"/>
                        </td>
                        <td style="text-align: center; width: 120px;"></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="margin: 5px 10px 0px 3px;"">
             <asp:DataList ID="ParentList" runat="server" OnItemDataBound="ParentList_OnItemDataBound" HorizontalAlign="Center">
                <HeaderTemplate>  
                <table style="border-collapse: collapse;border: 0px solid #999;cellspacing:0;cellpadding:0">
                    <tr class="GridViewHeaderStyle" style="vertical-align:bottom">
                            <th valign:"bottom" width="40px">序号</th>
                            <th valign:"bottom" width="40px">组长兼安全员</th>  
                            <th valign:"bottom" width="80px">工作项目</th>  
                            <th valign:"bottom" width="70px">组员</th>
                            <th colspan="5" valign:"bottom">
                                <table style="border-collapse: collapse;border: 0px solid #999;cellspacing:0;cellpadding:0" width="100%">
                                    <tr style="border-bottom:1px solid #999;vertical-align:bottom;align-content:center"><td colspan="5">生产记录</td></tr>
                                    <tr style="vertical-align:bottom;align-content:center">
                                        <td style="border-top: 0;border-right: 1px solid #999;border-bottom: 0;border-left: 0;width:90px">计划</td>
                                        <td style="border-top: 0;border-right: 1px solid #999;border-bottom: 0;border-left: 0;width:140px">实际</td>
                                        <td style="border-top: 0;border-right: 1px solid #999;border-bottom: 0;border-left: 0;width:140px">收工时间</td>
                                        <td style="border-top: 0;border-right: 1px solid #999;border-bottom: 0;border-left: 0;width:80px">整理资料</td>
                                        <td style="border-top: 0;border-right: 1px solid #999;border-bottom: 0;border-left: 0;width:70px">参与人员</td>
                                    </tr>
                                </table>
                            </th>
                            <th valign:"bottom" width="70px">使用仪器及设备号</th>
                            <th valign:"bottom" width="100px">用车记录</th>
                            <th valign:"bottom" width="auto">备注</th>
                            <th valign:"bottom" width="40px">修改</th>
                        </tr>  
                </HeaderTemplate> 
                <ItemTemplate>
                    <tr  style="background-color:white;text-align: center;font-size: 15px;height :26px;"><td colspan="13">
                        <asp:Label ID="LabeProjectName" runat="server" Text='<%# Eval("ProjectName")%>'></asp:Label>-
                        <asp:Label ID="labTitle" runat="server" Text='<%# Eval("Title")%>'></asp:Label>-
                        <asp:Label ID="labSurveyDate" runat="server" Text='<%# Eval("SurveyDate")%>'></asp:Label>
                        <asp:Label ID="labSurveyId" runat="server" Text='<%# Eval("Id")%>' Visible="false"></asp:Label>
                    </td></tr>
                    <asp:DataList ID="ChildList" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" OnItemDataBound="ChildList_ItemDataBound">
                         
                        <ItemTemplate>
                            <tr class="GridViewRowStyle">   
                                <td><asp:Label ID="labID" runat="server" Text='<%# Container.ItemIndex+1 %>'></asp:Label></td>
                                <td><asp:Label ID="lableader" runat="server" Text='<%# Eval("LeaderAndSecurityOfficer")%>'></asp:Label></td>
                                <td><asp:Label ID="labProjectDetail" runat="server" Text='<%# Eval("ProjectDetail")%>'></asp:Label></td>  
                                <td><asp:Label ID="labMembers" runat="server" Text='<%# Eval("Members")%>'></asp:Label></td>
                                <td width="90px"><asp:Label ID="labPlan" runat="server" Text='<%# Eval("Plan")%>'></asp:Label></td>
                                <td width="140px"><asp:Label ID="labActual" runat="server" Text='<%# Eval("Actual")%>'></asp:Label></td>
                                <td width="140px"><asp:Label ID="labOffTime" runat="server" Text='<%# Eval("OffTime")%>'></asp:Label></td>
                                <td width="80px"><asp:Label ID="labSortData" runat="server" Text='<%# Eval("SortData")%>'></asp:Label></td>
                                <td width="70px"><asp:Label ID="labSortDataParticipants" runat="server" Text='<%# Eval("SortDataParticipants")%>'></asp:Label></td>
                                <td><asp:Label ID="labDevice" runat="server" Text='<%# Eval("Device")%>'></asp:Label></td>
                                <td><asp:Label ID="labVehicleRecord" runat="server" Text='<%# Eval("VehicleRecord")%>'></asp:Label></td>
                                <td><asp:Label ID="labRemark" runat="server" Text='<%# Eval("Remark")%>'></asp:Label></td>
                                <td><img alt="修改" style="cursor: pointer;" onclick="Edit(<%# DataBinder.Eval(Container.DataItem, "Id")%>)"
                                src="../Images/bb-ud.gif" /></td>
                            </tr> 
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="GridViewAlternatingRowStyle"> 
                                <td><asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex+1 %>'></asp:Label></td>
                                <td><asp:Label ID="labID" runat="server" Text='<%# Eval("LeaderAndSecurityOfficer")%>'></asp:Label></td>
                                <td><asp:Label ID="labProjectDetail" runat="server" Text='<%# Eval("ProjectDetail")%>'></asp:Label></td>  
                                <td><asp:Label ID="labMembers" runat="server" Text='<%# Eval("Members")%>'></asp:Label></td>
                                <td width="90px"><asp:Label ID="labPlan" runat="server" Text='<%# Eval("Plan")%>'></asp:Label></td>
                                <td width="140px"><asp:Label ID="labActual" runat="server" Text='<%# Eval("Actual")%>'></asp:Label></td>
                                <td width="140px"><asp:Label ID="labOffTime" runat="server" Text='<%# Eval("OffTime")%>'></asp:Label></td>
                                <td width="80px"><asp:Label ID="labSortData" runat="server" Text='<%# Eval("SortData")%>'></asp:Label></td>
                                <td width="70px"><asp:Label ID="labSortDataParticipants" runat="server" Text='<%# Eval("SortDataParticipants")%>'></asp:Label></td>
                                <td><asp:Label ID="labDevice" runat="server" Text='<%# Eval("Device")%>'></asp:Label></td>
                                <td><asp:Label ID="labVehicleRecord" runat="server" Text='<%# Eval("VehicleRecord")%>'></asp:Label></td>
                                <td><asp:Label ID="labRemark" runat="server" Text='<%# Eval("Remark")%>'></asp:Label></td>
                                <td><img alt="修改" style="cursor: pointer;" onclick="Edit(<%# DataBinder.Eval(Container.DataItem, "Id")%>)"
                                src="../Images/bb-ud.gif" /></td>
                            </tr> 
                        </AlternatingItemTemplate>
                        
                    </asp:DataList>
                </ItemTemplate>
                <FooterTemplate>
                    </table>  
                </FooterTemplate> 
            </asp:DataList>
        </div>
        <div id="print" style="display:none;"></div>
    </form>
</body>
</html>
