$(function () {
    //注册Button事件 input[type=submit]
    $(".bu01").hover(function () {
        $(this).removeClass("bu01");
        $(this).addClass("bu01on");
    }, function () {
        $(this).removeClass("bu01on");
        $(this).addClass("bu01");
    });
    //注册Button事件 input[type=submit]
    $(".bu02").hover(function () {
        $(this).removeClass("bu02");
        $(this).addClass("bu02on");
    }, function () {
        $(this).removeClass("bu02on");
        $(this).addClass("bu02");
    });
    //注册Button事件 input[type=submit]
    $(".bu03").hover(function () {
        $(this).removeClass("bu03");
        $(this).addClass("bu03on");
    }, function () {
        $(this).removeClass("bu03on");
        $(this).addClass("bu03");
    });
    //返回按钮
    $("input[value='返回'],input[value='后退']").click(function () {
        window.history.go(-1);
    });
});

$(function () {
    $("input[type=text], input[type=password], textarea").bind("keydown", function () {
        if (window.event.keyCode == 13) {
            if (window.event.ctrlKey) {
                //Ctrl + Enter 触发第一个按钮
                $("input[type='submit']:first").click();
            }
            else {
                //Enter 当作　Tab
                window.event.keyCode = 9;
            }
        }
    });
    //注册文本框获得、失去焦点
    $("input[type=text], input[type=password], textarea").focus(function () {
        $(this).addClass("focus")
    }).blur(function () {
        $(this).removeClass("focus")
    });
});
//页面垂直、水平居中
$(function () {
    var $div = $("#divCenter");
    $div.css("margin-left", -$div.width() / 2);
    $div.css("margin-top", -$div.height() / 2);
    $div.css("left", "50%");
    $div.css("top", "50%");
});
//页面水平居中
$(function () {
    var $div = $("#horizontallyCenter");
    $div.css("margin-left", -$div.width() / 2);
    $div.css("left", "50%");
});