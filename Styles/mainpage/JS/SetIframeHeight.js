//输入你希望根据页面高度自动调整高度的iframe的名称的列表 
//用逗号把每个iframe的ID分隔. 例如: ["myframe1", "myframe2"]，可以只有一个窗体，则不用逗号。 
//定义iframe的ID
var iframeids = ["menuFrame"];
//如果用户的浏览器不支持iframe是否将iframe隐藏 yes 表示隐藏，no表示不隐藏 
var iframehide = "yes";
function dyniframesize() {
    var dyniframe = new Array();
    for (var i = 0; i < iframeids.length; i++) {
        if (document.getElementById) {
            //自动调整iframe高度 
            dyniframe[dyniframe.length] = document.getElementById(iframeids[i]);
            if (dyniframe[i] && !window.opera) {
                dyniframe[i].style.display = "block";
                if (dyniframe[i].contentDocument && dyniframe[i].contentDocument.body.offsetHeight) {
                    //如果用户的浏览器是IE 
                    var contentDocHeight = dyniframe[i].contentDocument.body.offsetHeight;
                    dyniframe[i].height = contentDocHeight + 30;
                }
                else if (dyniframe[i].Document && dyniframe[i].Document.body.scrollHeight) {
                    //其它浏览器
                    dyniframe[i].height = dyniframe[i].Document.body.scrollHeight + 30;
                }
            }
        }
        //根据设定的参数来处理不支持iframe的浏览器的显示问题 
        if ((document.all || document.getElementById) && iframehide == "no") {
            var tempobj = document.all ? document.all[iframeids[i]] : document.getElementById(iframeids[i]);
            tempobj.style.display = "block";
        }
    }
}
if (window.addEventListener) {
    window.addEventListener("load", dyniframesize, false);
}
else if (window.attachEvent) {
    window.attachEvent("onload", dyniframesize);
}
else {
    window.onload = dyniframesize;
}
//function reinitIframe(){
//    var iframe = document.getElementById("menuFrame");
//    try{
//        var bHeight = iframe.contentWindow.document.body.scrollHeight;
//        var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
//        var height = Math.max(bHeight, dHeight);
//        iframe.height =  height;
//    }catch (ex){}
//}
//window.setInterval("reinitIframe()", 0);

