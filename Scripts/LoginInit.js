$(function() {
    //注册Button事件 input[type=submit]
    $(".bu01").hover(function() {
        $(this).removeClass("bu01");
        $(this).addClass("bu01on");
    }, function() {
        $(this).removeClass("bu01on");
        $(this).addClass("bu01");
    });
    $(".bu04").hover(function () {
        $(this).removeClass("bu04");
        $(this).addClass("bu04on");
    }, function () {
        $(this).removeClass("bu04on");
        $(this).addClass("bu04");
    });

});

$(function() {
    $("input[type=text], input[type=password], textarea").bind("keydown", function() {
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
});

//页面垂直、水平居中
$(function () {
    var $div = $("#divCenter");
    $div.css("margin-left", -$div.width() / 2);
    $div.css("margin-top", -$div.height() / 2);
    $div.css("left", "50%");
    $div.css("top", "60%");
});

