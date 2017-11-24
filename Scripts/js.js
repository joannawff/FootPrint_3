<!--换样式单-->
function ClassNew(obj, new_style) {
    obj.className = new_style;
}

<!--控制frame-->
function changeWin(){
    if(parent.forum.cols!="11,*")
    {
        parent.forum.cols="11,*";
        document.all.menuSwitch.innerHTML="<font class=point>4</font>";
    }
    else
    {
        parent.forum.cols="183,*";
        document.all.menuSwitch.innerHTML="<font class=point>3</font>";
    }
}
<!--关闭窗口-->
function close()
{
    window.opener=null; 
    window.open('','_self'); 
    window.close(); 
}