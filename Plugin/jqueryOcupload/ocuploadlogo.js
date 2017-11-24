$(function () {
    $("#uploadfile").upload({
        action: '../ServiceHandler/UploadLogo.ashx',
        name: 'file',
        params: {},
        onSelect: function () {
            this.autoSubmit = false;           
            if (CheckLogoType(this.filename())) {
                this.submit();
            }
            else {
                art.dialog({
                    content: "请选择JPG，GIF，PNG等图片文件。",
                    icon: "warning",
                    title: "警告",
                    ok: true
                });
            }
        },
        onSubmit: function () {

        },
        onComplete: function (data, self, element) {
            if (data.indexOf("error") == 0) {
                art.dialog({
                    content: data.substring(6),
                    icon: "error11",
                    title: "错误",
                    ok: true
                });
            }
            else {
                $("#imgFile").attr("src", "../" + data.substring(2));
                $("#imgFile").show();
                $("#hf_File").attr("value", "../" + data.substring(2));
            }
        }
    });
});

//判断文件类型
function CheckLogoType(objFile) {
    var objtype = objFile.substring(objFile.lastIndexOf(".")).toLowerCase();    
    var fileType = new Array(".gif", ".jpg", ".png", ".jpeg");
    for (var i = 0; i < fileType.length; i++) {
        if (objtype == fileType[i]) {
            return true;
        }
    }
    return false;
}