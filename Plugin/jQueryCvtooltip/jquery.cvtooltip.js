/* 
* JQuery.cvtooltip.js
* http://www.chinavalue.net
* 
* J.Wang
* http://0417.cnblogs.ocm
*
* 2010.11.17
*/

(function($) {
    $.fn.cvtooltip = function(options) {
        var self = $(this);
        var defaults = {
            panel: "body",      //�ò����Ǽ���������ʾ��������ֵ��ͬ���ܻᵼ�¼����λ�ò�ͬ��Ĭ��Ϊ������body����
            selector: "",       //���ڼ��㶨λ�Ŀؼ�
            direction: 1,       //��ͷ����Ĭ������
            width: 300,         //������ʾ��ȣ���ȫ�ֶ�����
            left: 0,            //����panel��������߾�
            top: 0,             //����panel�������ϱ߾�
            delay: -1,          //�ӳٹرգ���λ���룬ֵΪ0ʱ��ʾ���̹ر�
            speed: 300,         //�ر�ʱ��Ч���������ٶ�
            close: true,        //�Ƿ���ʾ�رհ�ť
            callback: function() {
                $.noop();       //����رպ���¼�
            }
        };
        
        var param = $.extend({}, defaults, options || {});
        
        var controlID = self.attr("ID");
        
        //������ʽ
        var cvToolTipCssBtm = '';
        var cvToolTipCssTop = '';
        
        if(param.direction == 0){
            cvToolTipCssBtm = 'position: absolute; border-color: transparent transparent #F9E98E transparent; border-style: dashed dashed solid dashed; border-width: 12px 12px 12px 12px; width: 0; height: 0; overflow: hidden; left:40px; top:-24px;';
            cvToolTipCssTop = 'position: absolute; border-color: transparent transparent #FBF7AA transparent; border-style: dashed dashed solid dashed; border-width: 12px 12px 12px 12px; width: 0; height: 0; overflow: hidden; left:40px; top:-19px;';
        }
        else{
            cvToolTipCssBtm = 'position: absolute; border-color: #F9E98E transparent transparent transparent; border-style: solid dashed dashed dashed; border-width: 12px 12px 12px 12px; width: 0; height: 0; overflow: hidden; left:40px; bottom:-24px;';
            cvToolTipCssTop = 'position: absolute; border-color: #FBF7AA transparent transparent transparent; border-style: solid dashed dashed dashed; border-width: 12px 12px 12px 12px; width: 0; height: 0; overflow: hidden; left:40px; bottom:-19px;';
        }
	    
	    var cvToolTipCss = 'z-index:99999; display:none; position: absolute; border: 3px solid #F9E98E; background-color: #FBF7AA; line-height:14px; width: ' + param.width + 'px; left:' + param.left + 'px; top:' + param.top + 'px;';
	    
        //������ʾ
        var cvTipsElement = '';
        cvTipsElement += '<div id="' + controlID + 'Body" class="cvToolTip" style="' + cvToolTipCss + '">';
        cvTipsElement += '<span style="' + cvToolTipCssBtm + '"></span><span style="' + cvToolTipCssTop + '"></span>';
        cvTipsElement += '<span id="' + controlID + 'Content" style="float:left;"></span>';
        
        if(param.close){
            cvTipsElement += '<a id="' + controlID + 'Close" style="display:none;"><span style="float:right; font-family:verdana; position: absolute; top:1px; right:5px; font-size:12px; cursor:pointer;">x</span></a>';
        }
        
        cvTipsElement += '</div>';
        
        if ($("#" + controlID + "Body").length == 0) {
            $(param.panel).append(cvTipsElement);
        }

        //����������װ�����ݵ�����
        var cttBody = $("#" + controlID + "Body");
        var cttContent = $("#" + controlID + "Content");
        var cttClose = $("#" + controlID + "Close");
        
        cttBody.show();

        var ctt = {            
            content: function() {
                self.show();
                return self;
            },
            
            position: function() {
                var p = $(param.selector).position();
                
                cttBody.css("top", p.top + param.top);
                cttBody.css("left", p.left + param.left);
            },
            
            hide: function() {                
                cttBody.fadeOut(param.speed, function(){
                    ctt.content().hide().appendTo($(param.panel));
                    cttBody.remove();
                });
            },

            show: function() {
                if (cttContent.html() == "") {
                    cttContent.append(ctt.content());
                }
                
                if(param.selector != ""){
                    ctt.position();
                }
                
                if (param.delay >= 0) {
                    setTimeout(ctt.hide, param.delay);
                }
            }
        };

        ctt.show();
        
        //�ر�����        
        cttClose.click(function(){
            ctt.hide();
            param.callback();
        });
        
        cttBody.mouseover(function(){
            cttClose.show();
        });
        
        cttBody.mouseout(function(){
            cttClose.hide();
        });
    }
})(jQuery);