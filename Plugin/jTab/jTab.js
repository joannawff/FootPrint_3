/*
 * jTab 1.0
 * Make By Zehee, Modyfy By Lee(2008.9.7)
*/
var jTab = {
    createjTab:function(id, attr) {
        function getValue(name){
			var config=new RegExp(name+":([^,]+)", "i");
			return (config.test(attr))? eval( '('+RegExp.$1+')') : 0;
		}
		var tabid = "#" + id
        var tab = jQuery(tabid);
        
        tab.css = getValue("css") ? getValue("css") : "jTab";
        tab.position = getValue("position"); //tab的位置(horizontal, vertical)
        tab.backgroundCss = getValue("backgroundCss");
        tab.mouseoverCss = getValue("mouseoverCss"); //鼠标移上去时的样式
        tab.selectedCss = getValue("selectedCss"); //选定tab标题的样式
        tab.contentCss = getValue("contentCss"); //内容的样式
        tab.splitWidth = getValue("splitWidth"); //每个tab元素之间的间隔
        
        tab.addClass(tab.css);
        if(tab.position == "vertical") {
            tab.backgroundCss = tab.backgroundCss ? tab.backgroundCss : "jTab_vTitle_bg";
            tab.mouseoverCss = tab.mouseoverCss ? tab.mouseoverCss : "jTab_vTitle_over";
            tab.selectedCss = tab.selectedCss ? tab.selectedCss : "jTab_vTitle_selected";
            tab.contentCss = tab.contentCss ? tab.contentCss : "jTab_vContent"
            tab.splitWidth = tab.splitWidth ? tab.splitWidth : 24;
        }
        else{
            tab.backgroundCss = tab.backgroundCss ? tab.backgroundCss : "jTab_hTitle_bg";
            tab.mouseoverCss = tab.mouseoverCss ? tab.mouseoverCss : "jTab_hTitle_over";
            tab.selectedCss = tab.selectedCss ? tab.selectedCss : "jTab_hTitle_selected";
            tab.contentCss = tab.contentCss ? tab.contentCss : "jTab_hContent"
            tab.splitWidth = tab.splitWidth ? tab.splitWidth : 28;
        }
        
        var titles = tab.children("span");
        titles.css({cursor:"hand",cursor:"pointer"});
        titles.css({position:"absolute",top:"0",zoom:"100%"});
        titles.addClass(tab.backgroundCss);
        
        var contents = tab.children("div");
        contents.addClass(tab.contentCss).hide();
        tab.children("div:first").fadeIn("slow");
        
        if(!titles.hasClass(tab.selectedCss)){
            tab.children("span:first").addClass(tab.selectedCss);
        }
        
        if(titles.length > 1){
            titles.each(function(){
                jQuery(this).mouseover(function(){
                    jQuery(this).addClass(tab.mouseoverCss);
                });
                
                jQuery(this).mouseout(function(){
                    jQuery(this).removeClass(tab.mouseoverCss);
                });
                
                jQuery(this).click(function(){
                    if(!jQuery(this).hasClass(tab.selectedCss)) {
                        titles.removeClass(tab.selectedCss);
                        jQuery(this).addClass(tab.selectedCss);
                        tab.children("div").hide();
                        jQuery(this).next("div").fadeIn("slow"); // 可更换为其他动画形式
                    }
                });
            });
        }
        
        titles.fadeIn("fast");
        if(tab.position == "vertical") {
            for(var i = 1;i < titles.length;i ++){
                jQuery(titles[i]).css("top", jQuery(titles[i-1]).offset().top - tab.offset().top + jQuery(titles[i-1]).height() + tab.splitWidth + "px")
            }
        }
        else {
            for(var i = 1;i < titles.length;i ++){
                jQuery(titles[i]).css("left", jQuery(titles[i-1]).offset().left - tab.offset().left + jQuery(titles[i-1]).width() + tab.splitWidth + "px")
            }
        }
    }
}