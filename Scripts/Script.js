//=====================.net客户段验证2.0===========================

/**
 * @author zyj
 */
//=====================.net客户段验证2.0===========================

/*---------------------------------该段代码用于定义xWin-----------------------------------*/
var x0=0,y0=0,x1=0,y1=0;
var offx=6,offy=6;
var moveable=false;
var hover='orange',normal='slategray';//color;
var index=10000;//z-index;
//开始拖动;
function startDrag(obj)
{
 if(event.button==1)
 {
  //锁定标题栏;
  obj.setCapture();
  //定义对象;
  var win = obj.parentNode;
  var sha = win.nextSibling;
  //记录鼠标和层位置;
  x0 = event.clientX;
  y0 = event.clientY;
  x1 = parseInt(win.style.left);
  y1 = parseInt(win.style.top);
  //记录颜色;
  normal = obj.style.backgroundColor;
  //改变风格;
  obj.style.backgroundColor = hover;
  win.style.borderColor = hover;
  obj.nextSibling.style.color = hover;
  sha.style.left = x1 + offx;
  sha.style.top  = y1 + offy;
  moveable = true;
 }
}
//拖动;
function drag(obj)
{
 if(moveable)
 {
  var win = obj.parentNode;
  var sha = win.nextSibling;
  win.style.left = x1 + event.clientX - x0;
  win.style.top  = y1 + event.clientY - y0;
  sha.style.left = parseInt(win.style.left) + offx;
  sha.style.top  = parseInt(win.style.top) + offy;
 }
}
//停止拖动;
function stopDrag(obj)
{
 if(moveable)
 {
  var win = obj.parentNode;
  var sha = win.nextSibling;
  var msg = obj.nextSibling;
  win.style.borderColor     = normal;
  obj.style.backgroundColor = normal;
  msg.style.color           = normal;
  sha.style.left = obj.parentNode.style.left;
  sha.style.top  = obj.parentNode.style.top;
  obj.releaseCapture();
  moveable = false;
 }
}
//获得焦点;
function getFocus(obj)
{
 if(obj.style.zIndex!=index)
 {
  index = index + 2;
  var idx = index;
  obj.style.zIndex=idx;
  obj.nextSibling.style.zIndex=idx-1;
 }
}
//最小化;
function min(obj)
{
 var win = obj.parentNode.parentNode;
 var sha = win.nextSibling;
 var tit = obj.parentNode;
 var msg = tit.nextSibling;
 var flg = msg.style.display=="none";
 if(flg)
 {
  win.style.height  = parseInt(msg.style.height) + parseInt(tit.style.height) + 2*2;
  sha.style.height  = win.style.height;
  msg.style.display = "block";
  obj.innerHTML = "0";
 }
 else
 {
  win.style.height  = parseInt(tit.style.height) + 2*2;
  sha.style.height  = win.style.height;
  obj.innerHTML = "2";
  msg.style.display = "none";
 }
}
//关闭;
function cls(id)
{	
	var e = document.getElementById("xMsg"+id);
	e.style.visibility = "hidden";
	
	var sha = e.nextSibling
	sha.style.visibility = "hidden";
	
	var p = e.parentElement;
	p.removeChild(e);
	p.removeChild(sha);	
}

function build() {
	var str = ""
  + "<div id=xMsg" + this.id + " "
  + "style='"
  + "z-index:" + this.zIndex + ";"
  + "width:" + this.width + ";"
  + "height:" + this.height + ";"
  + "left:" + this.left + ";"
  + "top:" + this.top + ";"
  + "background-color:" + normal + ";"
  + "color:" + normal + ";"
  + "font-size:10px;"
  + "font-family:Verdana;"
  + "position:absolute;"
  + "cursor:default;"
  + "border:2px solid " + normal + ";"
  + "' "
  + "onmousedown='getFocus(this)'>"
   + "<div "
   + "style='"
   + "background-color:" + normal + ";"
   + "width:" + (this.width-2*2) + ";"
   + "height:20;"
   + "color:white;"
   + "' "
   + "onmousedown='startDrag(this)' "
   + "onmouseup='stopDrag(this)' "
   + "onmousemove='drag(this)' "
   + "ondblclick='min(this.childNodes[1])'"
   + ">"
    + "<p align='left'> <span style='width:" + (this.width-2*12-4) + ";padding-left:3px;font-size:12px;'>" + this.title + "</span>"
    + "<span style='width:12;border-width:0px;color:white;font-size:12px;font-family:webdings;' onclick='min(this)'>0</span>"
    + "<span style='width:12;border-width:0px;color:white;font-size:12px;font-family:webdings;' onclick='cls("
	+this.id+")'>r</span></p>"
   	+ "</div>"
    + "<div style='"
    + "width:100%;"
    + "height:" + (this.height-20-4) + ";"
    + "background-color:white;"
    + "line-height:14px;"
    + "word-break:break-all;"
    + "padding:3px;"
    + "'>" + "<ul id='"+"xMsg"+this.id+":ErrorDisplay'>"+"</ul>" + "</div>"
	  + "</div>"
	  + "<div style='"
	  + "width:" + this.width + ";"
	  + "height:" + this.height + ";"
	  + "top:" + this.top + ";"
	  + "left:" + this.left + ";"
	  + "z-index:" + (this.zIndex-1) + ";"
	  + "position:absolute;"
	  + "background-color:black;"
	  + "filter:alpha(opacity=40);"
	  + "'></div>";  
 	document.body.insertAdjacentHTML("beforeEnd",str);
}

//创建一个对象;
function xWin(id,w,h,l,t,tit)
{
	 index = index+2; 
	 this.id      = id;
	 this.width   = w;
	 this.height  = h;
	 this.left    = l;
	 this.top     = t;
	 this.zIndex  = index;
	 this.title   = tit;
	 	 
	 this.obj     = null;  
	 build.call(this);
	 this.Container = document.getElementById("xMsg"+this.id);
 	 this.ul=document.getElementById("xMsg"+this.id+":"+"ErrorDisplay");  	
}
xWin.prototype.hide = function() {
	var e =  this.Container;
	
	e.style.visibility = "hidden";
	
	var sha = e.nextSibling
	sha.style.visibility = "hidden";
	
}
xWin.prototype.show = function() 
{
	var e =  this.Container;
	if(e.style.visibility =="hidden") {
		e.style.visibility = "visible";
		var sha = e.nextSibling
		sha.style.visibility = "visible";
	}
}
xWin.prototype.dispose = function() 
{
	var e =  document.getElementById("xMsg"+this.id);
	if(e) {
	    e.style.visibility = "hidden";
    	
	    var sha = e.nextSibling
	    sha.style.visibility = "hidden";
    	
	    var p = e.parentElement;
	    p.removeChild(e);
	    p.removeChild(sha);
	}	
}
xWin.prototype.haveDisposed = function() 
{
    return !document.getElementById("xMsg"+this.id);
}
xWin.prototype.insertError = function(err) 
{
		
		var v = this.ul;		
		var p = document.createElement("li");
		p.innerHTML= "<p align='left'><font color='#FF0000' size='-1'>"+err+"</font></p>";
		v.appendChild(p);
}
xWin.prototype.clear = function() {
	var v = this.ul;
	v.innerHTML = "";
}
/*-------------------------xWin定义结束--------------------------------*/


/**
 * @author zyj
 * 下面是一个验证框架，用以验证输入 
**/

//接受一个displaywin对象用于显示一个错误提示窗体
//如var v=new ValidFrameWork(new xWin(IdIndex.IdBase++,360,200,200,200,"title"));
function ValidFrameWork(displayWin) 
{
	this.win = displayWin;	
	this.win.hide();
	this.valid = true;
}
ValidFrameWork.prototype.showPopWin = 
function() 
{		
	this.win.show();
}
ValidFrameWork.prototype.IsValid = 
function() {
	return this.valid;
}
//增加对某个元素的验证，eId是控件的Id,msg是验证没有通过的时候的错误提示
//validFunction是用于验证的函数，该函数接受一个字符串，返回bool表示验证
//结果
ValidFrameWork.prototype.addValidElement=
function(eId,msg,validFunction) 
{
	if(!validFunction(document.getElementById(eId).value)) {
		this.win.insertError(msg);
		this.valid = false;
	}		
}
var ValidFunction = {};
ValidFunction.notEmpty = function(content) {
	return (content!="");
}
ValidFunction.IsYearMonth= function(content) {
    if(content=="") return true;
	var filter=/^(\d{4})(.)(\d{1,2})$/;
    if (filter.test(content)) {
		var year=content.substr(0,content.indexOf('.'));
	    var month=content.substr(content.indexOf('.')+1,content.length);
	    var y = parseInt(year);
		var m = parseInt(month);
		if((y>=1000 && y<=3000) && (m>0 && m<13))    
		   	return true;		
	}		
	return false;	
}
ValidFunction.IsNumber=function(content) {
	if(content.search(/^[0-9]+$/)==-1 && content!="")
		return false;
	return true
}

/**
 * @author zyj
 *验证多个文本框的值是一个和，例如
 * validateSum('t1','t2','t3','t4')
 *该函数在id为t1的文本框的值＝＝id为t2,t3,t4的文本框值和的时候返回true,否则返回false
 */
function validateSum(){
	if(arguments.length < 2)
		return true;
	
	var total = parseFloat(document.getElementById(arguments[0]).value);
	
	var  t = 0.0;
	for (var i = 1; i < arguments.length; i++) {
		var element = document.getElementById(arguments[i]);
		
		//    if (typeof element == 'string')
		//      element = document.getElementById(element);
		//
		//    if (arguments.length == 1) 
		//      return element;
		//      
		//    elements.push(element);
		t+=parseFloat(element.value);			
	}
	if (t == total) {
		return true;
	}
	else {
	alert("您输入的计划总投资不相等，请重新输入！");
	 	return false;
	}
}

//验证短日期，如：2008.03
function CheckYearMonth(txt)
{
    var filter=/^(\d{1,4})(.)(\d{1,2})$/;
    if(filter.test(txt.value))
        return true;
    else
    {
        alert("日期格式为YYYY.MM,例如:2008.03");
        txt.focus();   
        return false;
    }
}  

function ck(http)
{
  var IP="http://wufeng/bzgl/"+http;
  window.top.main.location.href=IP;
  dh('Home','Operation','Stock','Storage','Report','Sys','Help');
}

function fob(n, d)
{
   var p,i,x;
   if(!d) d=document;
   if((p=n.indexOf("?"))>0&&parent.frames.length) 
   {
       d=parent.frames[n.substring(p+1)].document;
       n=n.substring(0,p);
   }
   if(!(x=d[n])&&d.all) 
        x=d.all[n];
   for (i=0;!x&&i<d.forms.length;i++) 
        x=d.forms[i][n];
   for(i=0;!x&&d.layers&&i<d.layers.length;i++) 
        x=fob(n,d.layers[i].document); 
   return x;
} 


function cb()
{
   var a=cb.arguments;
   var name=fob(a[0]);
   e=document.forms(0).elements;
   if (name.checked==true)
   {
      for (i=0;i<e.length;i++)
      {
         e[i].checked=true;
      }
   }
   else
   {
      for (i=0;i<e.length;i++)
      {
         e[i].checked=false;
      }
   }
}

//------------------------------用于验证输入的代码，提示信息显示在一个XWin中---------------------------------------------
//win必须是一个xWin类型的对象
function inputValidInXWin() 
{
   var win =  new xWin("1",360,200,200,200,"Message","xWin <br> A Cool Pop Div Window<br>Version:1.0<br>2002-8-13");
   var i,j,name,value,message,length,type,a=inputValidInXWin.arguments,cb_name; 
   var result = true; 
   for (i=0; i<(a.length-2); i+=3) 
   {
       if (a[i].indexOf('#')!=-1)
       {
           name=fob(a[i].substr(0,a[i].indexOf('#')));
           cb_name=fob(a[i].substr((a[i].indexOf('#')+1),a[i].length));
       }
       else
       {
          name=fob(a[i]); // 控件名称
       }
       message=a[i+1]; // 提示信息
       type=a[i+2]; // 类型
       if (type!="r_time")
       {
          value=name.value.replace(/ +/g, ""); // 控件值
       }
       else
       {
          value=name.value;
       }
   
       if (name) 
       {
          
       // ===============判断复选框是否选中================ //
          if (type=="r_cb")
          {      
             e=document.forms(0).elements;
             var flag=false;
             for (i=0;i<e.length;i++)
             { 
                if (e[i]!=cb_name)
                {
                   if (e[i].checked==true)
                   {
                       flag=true;
                       break;
                   }
                }
                if (i==e.length-1)
                {
                    break;
                }
             }
             if (flag==false)
             {
                //alert(message+"!\n"); //为空时出现的提示
                win.insertError(message);
                result = resul && false;
             }
          }
          
          // ===============判断下拉框是否选择================ //
          if (type=="r_sl")
          {
            if (name.selected==false)
            {
                 //alert(message+"!\n"); //为空时出现的提示
                 win.insertError(message);
                result = resul && false;
            }
          }
          
          // ===============不能为空的判断================ //
          if (type=="r") 
          {
             if (value=="") // 判断是否为空
             {
                 //alert(message+"!\n"); //为空时出现的提示
                 win.insertError(message);
                 name.focus();
                 name.select();
                result = resul && false;
             }
          }
          
          // ===============不能为空的判断,但不获得焦点================ //
          if (type=="o_r") 
          {
             if (value=="") // 判断是否为空
             {
                 //alert(message+"!\n"); //为空时出现的提示
                 win.insertError(message);
                result = resul && false;
             }
          }
         // ===============只能输入中文================ //
         if (type=="r_china")
         {
             if (value.search(/^[\u4e00-\u9fa5]+$/)==-1) 
             {
                  //alert(message+"!\n"); // 判断不能为空
                  win.insertError(message);
                  name.focus();
                  name.select();
                  result = resul && false;
             }
         }
         
         // ===============不能为空,必须是数字或者字符判断================ //
         if (type=="r_num_char")
         {
             if (value=="")
             {
                 // alert(message+"!\n"); //为空时出现的提示
                 win.insertError(message);
                 name.focus();
                 name.select();
                  result = resul && false;
             }
             else if (value.search(/^[0-9a-zA-Z]+$/)==-1) 
             {
                 //alert(message+"!\n"); //为空时出现的提示
                 win.insertError(message);
                 name.focus();
                 name.select();
                result = resul && false;
             }
          }
          
          // ===============可以为空，不为空时，填数字================ //
         if (type=="num")
         {
             if (value.search(/^[0-9]+$/)==-1 && value!="") 
             {
                  //alert(message+"!\n"); // 判断不能为空
                  win.insertError(message);
                  name.focus();
                  name.select();
                  result = resul && false;
             }
         }
         
         // ===============不能为空,必须是数字判断================ //
         if (type=="r_num")
         {
             if (value=="")
             {
                  //alert(message+"!\n");
                  win.insertError(message);
                  name.focus();
                 name.select();
                 result = resul && false;
             }
             else if (value.search(/^[0-9]+$/)==-1) 
             {
                  //alert(message+"!\n"); // 判断不能为空
                  win.insertError(message);
                  name.focus();
                 name.select();
                 result = resul && false;
             }
          }
          
          // ===============必须输入小于n的数字================ //
          if (type.indexOf("r_num<")!=-1)
          {
              length=type.substring((type.indexOf('<')+1),type.length); // 获得rn<后面的数 
   
              if (value=="") // 为空做的提示
              {
                  //alert(message+"!\n");
                  win.insertError(message);
                  name.focus();
                  name.select();
                 result = resul && false;
              }
              else if (value.search(/^[0-9]+$/)==-1)  // 不是数字做的提示
              {
                  //alert(message+"!\n");
                  win.insertError(message);
                  name.focus();
                  name.select();
                 result = resul && false;
              }
              else if (value.length>length)  // 限制数字长度做的限制
              {
                 //alert(message+"!\n");
                 win.insertError(message);
                 name.focus();
                 name.select();
                 result = resul && false;
              }
          }
          
          // ===============必须输入大于n的数字================ //
          if (type.indexOf("r_num>")!=-1)
          {
	         length=type.substring((type.indexOf('>')+1),type.length); // 获得rn<后面的数
             if (value=="") // 为空做的提示
             {
                //alert(message+"!\n");
                win.insertError(message);
                name.focus();
                name.select();
               result = resul && false;
             }
             else if (value.search(/^[0-9]+$/)==-1)  // 不是数字做的提示
             {
                //alert(message+"!\n");
                win.insertError(message);
                name.focus();
                name.select();
               result = resul && false;
             }
             else if (value.length<length)  // 限制数字长度做的限制
             {
                //alert(message+"!\n");
                win.insertError(message);
                name.focus();
                name.select();
                result = resul && false;
             }
          }
          
          // ===============必须输入a-b位之间的数字================ //		  
	      if (type.indexOf("r_num#<>")!=-1)
	      {
              length=type.substr((type.indexOf('>')+1),type.length);
              length=length.substr(0,length.lastIndexOf("-"));
	          length1=type.substring((type.indexOf('-')+1),type.length) // 获得rn<后面的数
              if (value=="") // 为空做的提示
	          {
		         //alert(message+"!\n");
		         win.insertError(message);
		         name.focus();
				 name.select();
				result = resul && false;
			  }
			  else if (value.search(/^[0-9]+$/)==-1) // 不是数字做的提示
			  {
				 //alert(message+"!\n");
				 win.insertError(message);
				 name.focus();
				 name.select();
				result = resul && false;
			  }
			  else if (value.length<length || value.length>length1)  // 限制数字长度做的限制
			  {
				 //alert(message+"!\n");
				 win.insertError(message);
				 name.focus();
				 name.select();
				 result = resul && false;
			  }
		  }
		  // ===============不能为空,必须是float类型================ //
         if (type=="r_float")
         {
             if (value=="")
             {
                  //alert(message+"!\n");
                  win.insertError(message);
                  name.focus();
                  name.select();
                 result = resul && false;
             }
             else if (value.search(/^[0-9]+$/)!=-1 || value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/)==-1)           
             {
                //alert(message+"!\n"); // 判断不能为空
                win.insertError(message);
                name.focus();
                name.select();
                result = resul && false;
             }
          }
		  
		  // ===============判断email,不一定输入================ //	
	      if (type.indexOf("email")!=-1)
	      {
	         if (name.value!="")
	         {
	             if (value.search(/^[_\.a-z0-9]+@[a-z0-9]+[\.][a-z0-9]{2,}$/i)==-1)
		         {
		             //alert(message+"!\n");
		             win.insertError(message);
     	    	     name.focus();
		             name.select();
		            result = resul && false;
		         }
	          }
	       }
	       // ===============判断email,一定输入================ //
			else if (type.indexOf("r_email")!=-1)
			{
				if (name.value=="")
				{
				    //alert(message+"!\n");
				    win.insertError(message);
				    name.focus();
				    name.select();
				    result = resul && false;
				}
				else if (value.search(/^[_\.a-z0-9]+@[a-z0-9]+[\.][a-z0-9]{2,}$/i)==-1)
				{
				    //alert(message+"!\n");
				    win.insertError(message);
     	            name.focus();
				    name.select();
				    result = resul && false;
				}
			}
	  
	   // ===============判断日期,比如2000-12-20================ //
          if (type=="r_date")
          {
              flag=true; 
              getdate=value;         
              if (getdate.search(/^[0-9]{4}-(0[1-9]|[1-9]|1[0-2])-((0[1-9]|[1-9])|1[0-9]|2[0-9]|3[0-1])$/)==-1) // 判断输入格式时候正确
              {
                   flag=false;
               }
               else
               {
                    var year=getdate.substr(0,getdate.indexOf('-'))  // 获得年
                    // 下面操作获得月份
					var transition_month=getdate.substr(0,getdate.lastIndexOf('-')); 
					var month=transition_month.substr(transition_month.lastIndexOf('-')+1,transition_month.length);
					if (month.indexOf('0')==0)
					{
					    month=month.substr(1,month.length);
					}
					// 下面操作获得日期
					var day=getdate.substr(getdate.lastIndexOf('-')+1,getdate.length);
					if (day.indexOf('0')==0)
					{
					    day=day.substr(1,day.length);
					}
					//alert(month);
					//alert(day)
					//return false;
                    if ((month==4 || month==6 || month==9 || month==11) && (day>30)) // 4,6,9,11月份日期不能超过30
                    {
                        flag=false; 
                     }
					if (month==2)  // 判断2月份
					{
						if (LeapYear(year))
						{
							if (day>29 || day<1){ flag=false; }
						}
						else
						{
							if (day>28 || day<1){flag=false; }
						}
					}
					else
					{
					    flag=true;
					}
			   }
          if (flag==false)
          {
              //alert(message+"!\n"); //为空时出现的提示
              win.insertError(message);
              name.focus();
              name.select();
              result = resul && false;
          }
        }
        
        
        // ===============判断日期,比如2000-12-20================ //
          if (type=="r_time")
          {
              flag=true; 
              getdate=value;
              if (getdate.search(/^[0-9]{4}-(0[1-9]|[1-9]|1[0-2])-((0[1-9]|[1-9])|1[0-9]|2[0-9]|3[0-1]) ((0[1-9]|[1-9])|1[0-9]|2[0-4]):((0[1-9]|[1-9])|[1-5][0-9]):((0[1-9]|[1-9])|[1-5][0-9])$/)==-1) // 判断输入格式时候正确
              {
                   flag=false;
               }
               else
               {
                    var year=getdate.substr(0,getdate.indexOf('-'))  // 获得年
                    // 下面操作获得月份
					var transition_month=getdate.substr(0,getdate.lastIndexOf('-')); 
					var month=transition_month.substr(transition_month.lastIndexOf('-')+1,transition_month.length);
					if (month.indexOf('0')==0)
					{
					    month=month.substr(1,month.length);
					}
					// 下面操作获得日期
					var day=getdate.substr(getdate.lastIndexOf('-')+1,getdate.length);
					if (day.indexOf('0')==0)
					{
					    day=day.substr(1,day.length);
					}
                    if ((month==4 || month==6 || month==9 || month==11) && (day>30)) // 4,6,9,11月份日期不能超过30
                    { 
                        flag=false; 
                     }
					if (month==2)  // 判断2月份
					{
						if (LeapYear(year))
						{
							if (day>29 || day<1){ flag=false; }
						}
						else
						{
							if (day>28 || day<1){flag=false; }
						}
					}
					else
					{
					    flag=true;
					}
			   }
          if (flag==false)
          {
              //alert(message+"!\n"); //为空时出现的提示
              win.insertError(message);
              name.focus();
              name.select();
             result = resul && false;
          }
 }
        //判断是否闰年
//参数		intYear 代表年份的值
//return	true: 是闰年	false: 不是闰年
function LeapYear(intYear) {
	if (intYear % 100 == 0) 
	{
		if (intYear % 400 == 0) { return true; }
	}
	else {
		if ((intYear % 4) == 0) { return true; }
	}
	return false;
}

      // ===============判断电话，可以为空================ //
	  if (type.indexOf("tel")!=-1)
	  {
	     if (name.value!="")
	     {
            if (value.search(/^(\([0-9]{4}\)|[0-9]{4}-)[0-9]{8}$/)==-1 && value.search(/^(\([0-9]{4}\)|[0-9]{4}-)[0-9]{7}$/)==-1)
		     {
		        win.insertError(message);
     	    	name.focus();
		        name.select();
		        result = resul && false;
		      }
	     }
	  }
	  
	  // ===============判断电话，不能为空================ //
	  if (type.indexOf("r_tel")!=-1)
	  {
	     if (name.value=="")
	     {
		    win.insertError(message);
		    name.focus();
		    name.select();
		    result = resul && false;
	     }
	     else if (value.search(/^(\([0-9]{4}\)|[0-9]{4}-)[0-9]{8}$/)==-1 && value.search(/^(\([0-9]{4}\)|[0-9]{4}-)[0-9]{8}$/)==-1)
	     {
	       win.insertError(message);
     	    name.focus();
		    name.select();
		   result = resul && false;
	     }
	  }
	  
	  // ===============判断手机，可以为空================ //
	  if (type.indexOf("mod")!=-1)
	  {
	     if (name.value!="")
	     {
            if (value.search(/^[0-9]{11}$/)==-1)
		    {
		       win.insertError(message);
		       name.select();
		      result = resul && false;
		    }
	     }
	   }
	   
	   // ===============判断手机，不能为空================ //
	   if (type.indexOf("r_mod")!=-1)
	   {
	      if (name.value=="")
	      {
		    win.insertError(message);
		      name.focus();
		      name.select();
		       result = resul && false;
	       }
	      else if (value.search(/^[0-9]{11}$/)==-1)
	      {
			 win.insertError(message);
     	    		name.focus();
			name.select();
			result = resul && false;
	       }
	   }
	   
	   // ===============判断街道================ //
	   if (type.indexOf("city")!=-1)
	   {
	      if (name.value!="")
	      {
              if (value.search(/^.{1,}(市|镇|乡).{1,}(路|街|道).{1,}号.{0,}$/)==-1)
		     {
		          win.insertError(message);
     	    	  name.focus();
		         name.select();
		         result = resul && false;
		      }
	       }
	   }
	   
	   // ===============判断街道，不能为空================ //
	   if (type.indexOf("r_city")!=-1)
	   {

	       if (name.value=="")
	       {
		       win.insertError(message);
		      name.focus();
		      name.select();
		     result = resul && false;
	       }

	       if (value.search(/^.{1,}(市|镇|乡).{1,}(路|街|道).{1,}号.{0,}$/)==-1)
	       {
		        win.insertError(message);
     	    	name.focus();
		        name.select();
		        result = resul && false;
	       }
	   }
      }
    }
    return false
}

function vdf() 
{
   var i,j,name,value,message,length,type,a=vdf.arguments,cb_name;

   for (i=0; i<(a.length-2); i+=3) 
   {
       if (a[i].indexOf('#')!=-1)
       {
           name=fob(a[i].substr(0,a[i].indexOf('#')));
           cb_name=fob(a[i].substr((a[i].indexOf('#')+1),a[i].length));
       }
       else
       {
          name=fob(a[i]); // 控件名称
       }
       message=a[i+1]; // 提示信息
       type=a[i+2]; // 类型
       if (type!="r_time")
       {
          value=name.value.replace(/ +/g, ""); // 控件值
       }
       else
       {
          value=name.value;
       }
   
       if (name) 
       {
          
       // ===============判断复选框是否选中================ //
          if (type=="r_cb")
          {      
             e=document.forms(0).elements;
             var flag=false;
             for (i=0;i<e.length;i++)
             { 
                if (e[i]!=cb_name)
                {
                   if (e[i].checked==true)
                   {
                       flag=true;
                       break;
                   }
                }
                if (i==e.length-1)
                {
                    break;
                }
             }
             if (flag==false)
             {
                alert(message+"!\n"); //为空时出现的提示
                return false;
             }
          }
          
          // ===============判断下拉框是否选择================ //
          if (type=="r_sl")
          {
            if (name.selected==false)
            {
                 alert(message+"!\n"); //为空时出现的提示
                 return false;
            }
          }
          
          // ===============不能为空的判断================ //
          if (type=="r") 
          {
             if (value=="") // 判断是否为空
             {
                 alert(message+"!\n"); //为空时出现的提示
                 name.focus();
                 name.select();
                 return false;
             }
          }
          
          // ===============不能为空的判断,但不获得焦点================ //
          if (type=="o_r") 
          {
             if (value=="") // 判断是否为空
             {
                 alert(message+"!\n"); //为空时出现的提示
                 return false;
             }
          }
         // ===============只能输入中文================ //
         if (type=="r_china")
         {
             if (value.search(/^[\u4e00-\u9fa5]+$/)==-1) 
             {
                  alert(message+"!\n"); // 判断不能为空
                  name.focus();
                  name.select();
                  return false;
             }
         }
         
         // ===============不能为空,必须是数字或者字符判断================ //
         if (type=="r_num_char")
         {
             if (value=="")
             {
                  alert(message+"!\n"); //为空时出现的提示
                 name.focus();
                 name.select();
                 return false;
             }
             if (value.search(/^[0-9a-zA-Z]+$/)==-1) 
             {
                  alert(message+"!\n"); //为空时出现的提示
                 name.focus();
                 name.select();
                 return false;
             }
          }
          
          // ===============可以为空，不为空时，填数字================ //
         if (type=="num")
         {
             if (value.search(/^[0-9]+$/)==-1 && value!="") 
             {
                  alert(message+"!\n"); // 判断不能为空
                  name.focus();
                  name.select();
                  return false;
             }
         }
         
         // ===============不能为空,必须是数字判断================ //
         if (type=="r_num")
         {
             if (value=="")
             {
                  alert(message+"!\n");
                  name.focus();
                 name.select();
                  return false;
             }
             if (value.search(/^[0-9]+$/)==-1) 
             {
                  alert(message+"!\n"); // 判断不能为空
                  name.focus();
                 name.select();
                  return false;
             }
          }
          
          // ===============必须输入小于n的数字================ //
          if (type.indexOf("r_num<")!=-1)
          {
              length=type.substring((type.indexOf('<')+1),type.length); // 获得rn<后面的数 
   
              if (value=="") // 为空做的提示
              {
                  alert(message+"!\n");
                  name.focus();
                  name.select();
                  return false;
              }
              if (value.search(/^[0-9]+$/)==-1)  // 不是数字做的提示
              {
                  alert(message+"!\n");
                  name.focus();
                  name.select();
                  return false;
              }
              if (value.length>length)  // 限制数字长度做的限制
              {
                 alert(message+"!\n");
                 name.focus();
                 name.select();
                 return false;
              }
          }
          
          // ===============必须输入大于n的数字================ //
          if (type.indexOf("r_num>")!=-1)
          {
	         length=type.substring((type.indexOf('>')+1),type.length); // 获得rn<后面的数
             if (value=="") // 为空做的提示
             {
                alert(message+"!\n");
                name.focus();
                name.select();
                return false;
             }
             if (value.search(/^[0-9]+$/)==-1)  // 不是数字做的提示
             {
                alert(message+"!\n");
                name.focus();
                name.select();
                return false;
             }
             if (value.length<length)  // 限制数字长度做的限制
             {
                alert(message+"!\n");
                name.focus();
                name.select();
                return false;
             }
          }
          
          // ===============必须输入a-b位之间的数字================ //		  
	      if (type.indexOf("r_num#<>")!=-1)
	      {
              length=type.substr((type.indexOf('>')+1),type.length);
              length=length.substr(0,length.lastIndexOf("-"));
	          length1=type.substring((type.indexOf('-')+1),type.length) // 获得rn<后面的数
              if (value=="") // 为空做的提示
	          {
		         alert(message+"!\n");
		         name.focus();
				 name.select();
				 return false;
			  }
			  if (value.search(/^[0-9]+$/)==-1) // 不是数字做的提示
			  {
				 alert(message+"!\n");
				 name.focus();
				 name.select();
				 return false;
			  }
			  if (value.length<length || value.length>length1)  // 限制数字长度做的限制
			  {
				 alert(message+"!\n");
				 name.focus();
				 name.select();
				 return false;
			  }
		  }
		  // ===============不能为空,必须是float类型================ //
         if (type=="r_float")
         {
             if (value=="")
             {
                  alert(message+"!\n");
                  name.focus();
                  name.select();
                  return false;
             }
             if (value.search(/^[0-9]+$/)!=-1 || value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/)!=-1) 
             {
                return true;
             }
             else
             {
                alert(message+"!\n"); // 判断不能为空
                  name.focus();
                  name.select();
                  return false;
             }
          }
		  
		  // ===============判断email,不一定输入================ //	
	      if (type.indexOf("email")!=-1)
	      {
	         if (name.value!="")
	         {
	             if (value.search(/^[_\.a-z0-9]+@[a-z0-9]+[\.][a-z0-9]{2,}$/i)==-1)
		         {
		             alert(message+"!\n");
     	    	     name.focus();
		             name.select();
		             return false;
		         }
	          }
	       }

	       // ===============判断email,一定输入================ //
			if (type.indexOf("r_email")!=-1)
			{
				if (name.value=="")
				{
				alert(message+"!\n");
				name.focus();
				name.select();
				return false;
				}
				if (value.search(/^[_\.a-z0-9]+@[a-z0-9]+[\.][a-z0-9]{2,}$/i)==-1)
				{
				alert(message+"!\n");
     	    			name.focus();
				name.select();
				return false;
				}
			}
	  
	   // ===============判断日期,比如2000-12-20================ //
          if (type=="r_date")
          {
              flag=true; 
              getdate=value;         
              if (getdate.search(/^[0-9]{4}-(0[1-9]|[1-9]|1[0-2])-((0[1-9]|[1-9])|1[0-9]|2[0-9]|3[0-1])$/)==-1) // 判断输入格式时候正确
              {
                   flag=false;
               }
               else
               {
                    var year=getdate.substr(0,getdate.indexOf('-'))  // 获得年
                    // 下面操作获得月份
					var transition_month=getdate.substr(0,getdate.lastIndexOf('-')); 
					var month=transition_month.substr(transition_month.lastIndexOf('-')+1,transition_month.length);
					if (month.indexOf('0')==0)
					{
					month=month.substr(1,month.length);
					}
					// 下面操作获得日期
					var day=getdate.substr(getdate.lastIndexOf('-')+1,getdate.length);
					if (day.indexOf('0')==0)
					{
					day=day.substr(1,day.length);
					}
					//alert(month);
					//alert(day)
					//return false;
                    if ((month==4 || month==6 || month==9 || month==11) && (day>30)) // 4,6,9,11月份日期不能超过30
                    {
                    flag=false; 
                     }
					if (month==2)  // 判断2月份
					{
						if (LeapYear(year))
						{
							if (day>29 || day<1){ flag=false; }
						}
						else
						{
							if (day>28 || day<1){flag=false; }
						}
					}
					else
					{
					flag=true;
					}
			   }
          if (flag==false)
          {
              alert(message+"!\n"); //为空时出现的提示
              name.focus();
              name.select();
              return false;
          }
        }
        
        
        // ===============判断日期,比如2000-12-20================ //
          if (type=="r_time")
          {
              flag=true; 
              getdate=value;
              if (getdate.search(/^[0-9]{4}-(0[1-9]|[1-9]|1[0-2])-((0[1-9]|[1-9])|1[0-9]|2[0-9]|3[0-1]) ((0[1-9]|[1-9])|1[0-9]|2[0-4]):((0[1-9]|[1-9])|[1-5][0-9]):((0[1-9]|[1-9])|[1-5][0-9])$/)==-1) // 判断输入格式时候正确
              {
                   flag=false;
               }
               else
               {
                    var year=getdate.substr(0,getdate.indexOf('-'))  // 获得年
                    // 下面操作获得月份
					var transition_month=getdate.substr(0,getdate.lastIndexOf('-')); 
					var month=transition_month.substr(transition_month.lastIndexOf('-')+1,transition_month.length);
					if (month.indexOf('0')==0)
					{
					month=month.substr(1,month.length);
					}
					// 下面操作获得日期
					var day=getdate.substr(getdate.lastIndexOf('-')+1,getdate.length);
					if (day.indexOf('0')==0)
					{
					day=day.substr(1,day.length);
					}
                    if ((month==4 || month==6 || month==9 || month==11) && (day>30)) // 4,6,9,11月份日期不能超过30
                    { 
                        flag=false; 
                     }
					if (month==2)  // 判断2月份
					{
						if (LeapYear(year))
						{
							if (day>29 || day<1){ flag=false; }
						}
						else
						{
							if (day>28 || day<1){flag=false; }
						}
					}
					else
					{
					flag=true;
					}
			   }
          if (flag==false)
          {
              alert(message+"!\n"); //为空时出现的提示
              name.focus();
              name.select();
              return false;
          }
        }
        //判断是否闰年
//参数		intYear 代表年份的值
//return	true: 是闰年	false: 不是闰年
function LeapYear(intYear) {
	if (intYear % 100 == 0) 
	{
		if (intYear % 400 == 0) { return true; }
	}
	else {
		if ((intYear % 4) == 0) { return true; }
	}
	return false;
}

      // ===============判断电话，可以为空================ //
	  if (type.indexOf("tel")!=-1)
	  {
	     if (name.value!="")
	     {
                 if (value.search(/^(\([0-9]{4}\)|[0-9]{4}-)[0-9]{8}$/)==-1 && value.search(/^(\([0-9]{4}\)|[0-9]{4}-)[0-9]{7}$/)==-1)
		 {
		    alert(message+"!\n");
     	    	    name.focus();
		    name.select();
		    return false;
		  }
	     }
	  }
	  
	  // ===============判断电话，不能为空================ //
	  if (type.indexOf("r_tel")!=-1)
	  {
	     if (name.value=="")
	     {
		    alert(message+"!\n");
		    name.focus();
		    name.select();
		    return false;
	     }
	     if (value.search(/^(\([0-9]{4}\)|[0-9]{4}-)[0-9]{8}$/)==-1 && value.search(/^(\([0-9]{4}\)|[0-9]{4}-)[0-9]{8}$/)==-1)
	     {
	        alert(message+"!\n");
     	    name.focus();
		    name.select();
		    return false;
	     }
	  }
	  
	  // ===============判断手机，可以为空================ //
	  if (type.indexOf("mod")!=-1)
	  {
	     if (name.value!="")
	     {
                if (value.search(/^[0-9]{11}$/)==-1)
		{
		   alert(message+"!\n");
     	    	   name.focus();
		   name.select();
		   return false;
		}
	     }
	   }
	   
	   // ===============判断手机，不能为空================ //
	   if (type.indexOf("r_mod")!=-1)
	   {
	      if (name.value=="")
	      {
		  alert(message+"!\n");
		  name.focus();
		  name.select();
		  return false;
	       }
	      if (value.search(/^[0-9]{11}$/)==-1)
	      {
			alert(message+"!\n");
     	    		name.focus();
			name.select();
			return false;
	       }
	   }
	   
	   // ===============判断街道================ //
	   if (type.indexOf("city")!=-1)
	   {
	      if (name.value!="")
	      {
            	 if (value.search(/^.{1,}(市|镇|乡).{1,}(路|街|道).{1,}号.{0,}$/)==-1)
		 {
		     alert(message+"!\n");
     	    	     name.focus();
		     name.select();
		     return false;
		  }
	       }
	   }
	   
	   // ===============判断街道，不能为空================ //
	   if (type.indexOf("r_city")!=-1)
	   {

	       if (name.value=="")
	       {
		  alert(message+"!\n");
		  name.focus();
		  name.select();
		  return false;
	       }

	       if (value.search(/^.{1,}(市|镇|乡).{1,}(路|街|道).{1,}号.{0,}$/)==-1)
	       {
		  alert(message+"!\n");
     	    	  name.focus();
		  name.select();
		  return false;
	       }
	   }
        }
    }
}




// ------------------本系统函数--------------------
function dh()
{
	var a=dh.arguments;
	var i;
	for (i=0;i<a.length;i++)
	{
	    eval("window.top.nav.document."+a[i]+ ".src='Images/Top/btn_"+a[i]+".jpg'");
	}
}
// ＝＝＝颜色＝＝＝
var main_tr_onmouseover="#E4EFFC"; // 主题main的tr鼠标移动onmouseover上来时的颜色

// ＝＝＝打印功能＝＝＝
var gLoadFinished = true; // 检测页面加载标记
var gDataGridName = "id"; // 要打印的内容的名称
var Title="s";
			// 打开JustPrint(TM) 打印服务窗口
function OpenJustPrintDlg()
{
	window.open('JustPrintService.aspx','_blank',"left=0,top=0,width=520,height=350,status=yes,resizable=no,directories=no,location=no,menubar=no,scrollbars=no,titlebar=no,toolbar=no");
				
}


function checkIdcard(txt)
{ 
    var idcard = txt.value;
    var Errors=new Array( 
        "验证通过!", 
        "身份证号码位数不对!", 
        "身份证号码出生日期超出范围或含有非法字符!", 
        "身份证号码校验错误!", 
        "身份证地区非法!" ); 
    var area={11:"北京",12:"天津",13:"河北",14:"山西",15:"内蒙古",21:"辽宁",22:"吉林",23:"黑龙江",31:"上海",32:"江苏",33:"浙			江",34:"安徽",35:"福建",36:"江西",37:"山东",41:"河南",42:"湖北",43:"湖南",44:"广东",45:"广西",46:"海			南",50:"重庆",51:"四川",52:"贵州",53:"云南",54:"西藏",61:"陕西",62:"甘肃",63:"青海",64:"宁夏",65:"新			疆",71:"台湾",81:"香港",82:"澳门",91:"国外"}  
    var Y,JYM; 
    var S,M; 
    var idcard_array = new Array(); 
    idcard_array = idcard.split(""); 
    //地区检验 
    if(area[parseInt(idcard.substr(0,2))]==null) 
    {
       alert( Errors[4]); 
		//txt.focus();
		return false;
	}
        
    //身份号码位数及格式检验
    if(idcard.length == 15)
    {
        if ( (parseInt(idcard.substr(6,2))+1900) % 4 == 0 || ((parseInt(idcard.substr(6,2))+1900) % 100 == 0 && (parseInt(idcard.substr(6,2))+1900) % 4 == 0 ))
            { 
               ereg=/^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}$/;//测试出生日期的合法性 
            }
            else
            { 
               ereg=/^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}$/;//测试出生日期的合法性 
            } 
            if(ereg.test(idcard)) 
            {
		        return true;
	        }
            else
            {
               alert( Errors[2]); 
		        //txt.focus();
		        return false;
            }
    }
    else if(idcard.length == 18)
    {
            //18位身份号码检测 
            //出生日期的合法性检查  
            //闰年月日:((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9])) 
            //平年月日:((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8])) 
            if (parseInt(idcard.substr(6,4)) % 4 == 0 || (parseInt(idcard.substr(6,4)) % 100 == 0 && parseInt(idcard.substr(6,4))%4 == 0 ))
            { 
               ereg=/^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}[0-9Xx]$/;//闰年出生日期的合法性正则表达式 
            }
            else
            { 
               ereg=/^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}[0-9Xx]$/;//平年出生日期的合法性正则表达式 
            } 
            if(ereg.test(idcard))
            {
                //测试出生日期的合法性 
                //计算校验位 
                S = (parseInt(idcard_array[0]) + parseInt(idcard_array[10])) * 7 
                + (parseInt(idcard_array[1]) + parseInt(idcard_array[11])) * 9 
                + (parseInt(idcard_array[2]) + parseInt(idcard_array[12])) * 10 
                + (parseInt(idcard_array[3]) + parseInt(idcard_array[13])) * 5 
                + (parseInt(idcard_array[4]) + parseInt(idcard_array[14])) * 8 
                + (parseInt(idcard_array[5]) + parseInt(idcard_array[15])) * 4 
                + (parseInt(idcard_array[6]) + parseInt(idcard_array[16])) * 2 
                + parseInt(idcard_array[7]) * 1  
                + parseInt(idcard_array[8]) * 6 
                + parseInt(idcard_array[9]) * 3 ; 
                Y = S % 11; 
                M = "F"; 
                JYM = "10X98765432"; 
                M = JYM.substr(Y,1);//判断校验位 
                if(M == idcard_array[17])
                {
    		       return true;
                }
                else
                {
                   alert(Errors[3]); 
		            //txt.focus();
		            return false;
                }
            } 
            else
            {
               alert( Errors[2]); 
	            //txt.focus();
	            return false;
            } 
    }
    else
    {
        alert( Errors[1]); 
        //txt.focus();
        return false;
    }
 } 