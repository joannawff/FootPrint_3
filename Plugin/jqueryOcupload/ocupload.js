$(function () {
    
    $("#uploadfile").upload({
        action: '../ServiceHandler/UploadFile.ashx',
        name: 'file',
        params: {},
        onSelect: function () {
        },
        onSubmit: function () {
            $("#uploadfile").attr("src", "../Images/loading.gif");
        },
        onComplete: function (data, self, element) {
            $("#uploadfile").attr("src", "../Images/selectfiles.gif");
            if (data.indexOf("error") > 0) {
                art.dialog({
                    content: data.substring(6),
                    icon: "error11",
                    title: "错误",
                    ok: true
                });
            }
            else {
                $("#aFile").attr("href", "../" + data.substring(2));
                $("#aFile").show();
                $("#hf_File").attr("value", data);
            }
        }
    });
});