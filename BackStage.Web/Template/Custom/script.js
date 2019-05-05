
/*
日期时间加减：
date：原始日期时间
addType：添加类型，指定d:天;h:小时;m:分钟;s:秒
addValue：增加值
*/
function addDate(date, addType, addValue) {
    var day = new Date(date);
    day = day.valueOf();
    if (addType == "s")
        day = day + addValue * 1000;
    else if (addType == "m")
        day = day + addValue * 60 * 1000;
    else if (addType == "h")
        day = day + addValue * 60 * 60 * 1000;
    else if (addType == "d")
        day = day + addValue * 24 * 60 * 60 * 1000;
    day = new Date(day);
    return day;
}

/* 
对Date的扩展，将 Date 转化为指定格式的String 
月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
例子： 
(new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
(new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
*/
Date.prototype.format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //ÔÂ·Ý 
        "d+": this.getDate(), //ÈÕ 
        "h+": this.getHours(), //Ð¡Ê± 
        "m+": this.getMinutes(), //·Ö 
        "s+": this.getSeconds(), //Ãë 
        "q+": Math.floor((this.getMonth() + 3) / 3), //¼¾¶È 
        "S": this.getMilliseconds() //ºÁÃë 
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
