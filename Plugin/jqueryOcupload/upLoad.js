$(function () {
    $(".sc").each(function () {
        $(this).upload({
            action: '../ServiceHandler/UploadTaskArchives.ashx',
            name: 'file',
            params: { id: this.id, taskID: '<%= CustomerID %>' },
            onSelect: function (self, element) {
                this.autoSubmit = false;
                if (CheckType(this.filename())) {
                    this.submit();
                }
                else {
                    alert("请选择JPG，GIF，PNG等图片文件。");
                }
            },
            onSubmit: function () {
                $(this).hide();
                $("#ajax_update").parent().show();
            },
            onComplete: function (data, self, element) {
                $("#ajax_update").parent().hide();
                $(this).show();
                alert(data);
                if (data.indexOf("error") > 0) {
                    alert(data.substring(6));
                }
                else {
                    //增加链接地址
                    $("#File" + data).attr("href", "../" + data.substring(2));
                    $("#File" + data).show();
                    //设置材料状态

                }
            }
        });
    });
});

//判断文件类型
function CheckType(objFile) {
    var objtype = objFile.substring(objFile.lastIndexOf(".")).toLowerCase();
    var fileType = new Array(".gif", ".jpg", ".png");
    for (var i = 0; i < fileType.length; i++) {
        if (objtype == fileType[i]) {
            return true;
        }
    }
    return false;
}