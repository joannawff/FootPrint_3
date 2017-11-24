<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
    <link href="Styles/css.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Login.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.js" type="text/javascript"></script>
    <script src="Scripts/LoginInit.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-image: url('Images/Login1.jpg'); background-repeat: no-repeat; position: absolute; top: 50%; left: 50%; margin: -300px 0 0 -450px; width: 900px; height: 600px;">
            <div style="width: 300px; height: 112px; position: absolute; top: 251px; left: 581px;">
                <table style="width: 300px; text-align: center; border: 0px;">
                    <tr style="height: 20px;">
                        <td></td>
                        <td></td>
                        <td rowspan="4" style="width: 120px; text-align: left;">
                            <asp:Button ID="btnLogin" runat="server" CssClass="bu04" OnClick="login_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60px; text-align: right; color: #fff; font-size: 12px;">用户名：
                        </td>
                        <td style="width: 120px; text-align: left;">
                            <input runat="server" id="username" style="width: 100px" tabindex="1" name="username" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60px; text-align: right; color: #fff; font-size: 12px;">密码：
                        </td>
                        <td style="width: 120px; text-align: left;">
                            <input id="userpwd" runat="server" style="width: 100px; margin-right: 10px;" tabindex="2"
                                type="password" name="userpwd" />
                        </td>
                    </tr>
                    <tr style="height: 20px;">
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
