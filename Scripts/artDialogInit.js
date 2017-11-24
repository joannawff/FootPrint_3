function Alert(content, icon, title, href) {
    art.dialog({
        content: content,
        icon: icon,
        title: title,
        ok: function () {
            if (href != undefined && href != "") {
                location.href = href;
            }
        }
    });
}
function dialog(message, href) {
    if (message != undefined && message != "") {
        var icon = message.substring(0, 7);
        var content = message.substring(7);
        var title = "";
        switch (icon) {
            case "Succeed":
                title = "成功";
                break;
            case "Warning":
                title = "警告";
                break;
            case "Error11":
                title = "错误";
                break;
        }
        Alert(content, icon, title, href);
    }
}