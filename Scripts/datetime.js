function  show_time()
{   
    var today,hour,second,minute,year,month,date,time;

    today=new Date();

    year = today.getYear();
    month = today.getMonth()+1;
    date = today.getDate();
    hour = today.getHours();
    minute =today.getMinutes();
    second = today.getSeconds();
    week = today.getDay();

    if (week==0)
        week = "星期日";
    else if (week == 1)
        week = "星期一";
    else if (week == 2)
        week = "星期二";
    else if (week == 3)
        week = "星期三";
    else if (week == 4)
        week = "星期四";
    else if (week == 5)
        week = "星期五";
    else if (week == 6)
        week = "星期六";

    if(second < 10)
    {
        time = year + "年" + month + "月" + date +"日 " + week + " " + hour + ":" + minute + ":0" + second;
    }
    else
    {
        time = year + "年" + month + "月" + date +"日 " + week + " " + hour + ":" + minute + ":" + second;
    }

    //document.getElementById("time").innerText = time;
    $("#time").html(time);
} 
setInterval(show_time,1000);
