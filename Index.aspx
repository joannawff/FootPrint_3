<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel="stylesheet" href="Css/frame.css" type="text/css" />
    <%--<script src="Scripts/datetime.js" type="text/javascript"></script>--%>
    <script src="../Scripts/jquery-1.7.js" type="text/javascript"></script>
    <script src="../Plugin/artDialog/artDialog.js" type="text/javascript"></script>
    <script src="../Plugin/artDialog/plugins/iframeTools.js" type="text/javascript"></script>
    <link href="../Plugin/artDialog/skins/default.css" rel="stylesheet" type="text/css" />
    <%--marquee--%>
    <script src="Plugin/marqueeSlide/dest/marquee.js"></script>

    <style type="text/css">
        td.left
        {
            padding-left: 10px;
            color: #FFFFFF;
            text-align: left;
            font-size: 12px;
            font-weight: bolder;
        }

        .bu01
        {
            font-size: 12px;
            font-weight: bolder;
            color: #FFFFFF;
            text-align: center;
            cursor: hand;
        }

        .bu01on
        {
            font-size: 12px;
            font-weight: bolder;
            color: #F00;
            text-align: center;
            cursor: hand;
        }

        a:link
        {
            font-size: 12px;
            font-weight: bolder;
            color: #FFFFFF;
            border: 0;
            text-decoration: none;
            text-align: center;
            cursor: hand;
        }

        a:visited
        {
            font-size: 12px;
            font-weight: bolder;
            color: #FFFFFF;
            border: 0;
            text-decoration: none;
            text-align: center;
        }

        a:active
        {
            font-size: 12px;
            font-weight: bolder;
            color: #FFFFFF;
            border: 0;
            text-decoration: none;
            text-align: center;
        }

        a:hover
        {
            font-size: 12px;
            font-weight: bolder;
            color: #FFFFFF;
            border: 0;
            text-decoration: none;
            text-align: center;
        }

        .wrap, .box
        {
            margin-bottom: 0px;
        }

            .wrap ul, .wrap .ul
            {
                overflow: hidden;
                clear: both;
                *zoom: 1;
            }

            .wrap li, .wrap .li
            {
                list-style: none;
                width: 120px;
                margin: 0px 5px 0px 5px;
                line-height: 30px;
            }
    </style>
    <script type="text/javascript">
        function reLogin() {
            var flag = 0;
            art.dialog({
                title: '操作确认',
                content: '您是否确认需要退出系统!',
                ok: function () {
                    $.ajax({
                        //要用post方式   
                        type: "Post",
                        //方法所在页面和方法名   
                        url: "Index.aspx/LoginOffHelper",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data:"",
                        success: function (data) {
                            //返回的数据用data.d获取内容   
                            ;
                        },
                        error: function (err) {
                            ;
                        }
                    });

                    window.location = "Login.aspx";
                },
                icon: 'question',
                width: 300,
                height: 100,
                cancelVal: '取消',
                cancel: true
            });
        }
    </script>

    <script type="text/javascript">
        $(function () {
            setTimeout(function () {
                $(".bottom_box").slideDown("slow");
            }, 2000);

            $(".close").click(function () {
                $(".bottom_box").hide();
                $(".mini").show(200);
            })
            $(".mini").click(function () {
                $(this).hide();
                $(".bottom_box").show();
            })
        });
        

        $(function () {
            //AjaxReadData();
            //Ajax定时读取数据，时间间隔10分钟
            setTimeout(function () {
                AjaxReadData();
            }, 2000);//10*60*1000毫秒

            //$('#wrap1').marquee();
            $('#wrap1').marquee({
                auto: true,
                interval: 2000,
                showNum: 1,
                type: 'vertical'
            });
        });

    </script>
</head>
<body style="width: 100%; text-align: center; overflow-x: hidden">
    <form id="form1" runat="server">
        <div style="margin: 0px auto; padding: 0px; width: 100%;">
            <table style="width: 100%; height: 110px; background-image: url('./Images/logo-bg.gif')"
                cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td  colspan="9" style="height: 60px; text-align:left">
                        <img src="Images/TextTitle.PNG" style="height:60px" /></td>                                   
                </tr>
                <tr style="height: 30px; background-image: url('./Images/bg-logo.gif')">
                    <td id="time" style="font-weight: bold; text-align: left; font-size: 12px; width:200px">
                        <div id="jnkc" style="color: #fff; margin-left: 10px;">
                        </div>
                        <script type="text/javascript">setInterval("jnkc.innerHTML=new Date().toLocaleString();", 1000);
                        </script>
                    </td>

                    <td class="left" style="font-weight: bold; text-align: left; width: 150px; font-size: 12px; width:180px">
                        欢迎您！<asp:Literal ID="userName" runat="server"></asp:Literal>
                    </td>
                    <td class="left" style="text-align: left; font-size: 12px;">
                        <asp:Label ID="task" runat="server"></asp:Label>
                    </td>
                    <td style="width: 80px;">                        
                    </td>
                    <td style="width: 80px;">
                        <a href="indexRight.aspx" target="main">系统首页</a>
                    </td>
                    <td style="width: 80px;">
                        <a href="Sys/UserInfoD.aspx" target="main">用户信息</a>
                    </td>
                    <td style="width: 80px;">
                        <a href="Sys/ChangePassword.aspx" target="main">密码修改</a>
                    </td>
                    <td style="width: 80px;">
                        <div class="bu01" style="cursor: pointer;" onclick="reLogin();">
                            退出系统
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <iframe src="index-bottom.html" width="100%" height="490px" scrolling="no" frameborder="1"
            framespacing="0"></iframe>
        <div class="bottom_box">
            <div class="bottom">
            </div>
            <div class="close"></div>
        </div>
        <div id="newTask" style="display: none;"></div>

    </form>
</body>
</html>

