/*字符串的扩展方法*/
//去除空格
String.prototype.trimSpace = function () {
    return this.replace(/^\s\s*/, '').replace(/\s\s*$/, '');
}
//为空判断
String.prototype.isNull = function () {
    if (this == "" || typeof (this) == "undefined" || this == null) return true;
    else return false;
}
//去除某段字符串
String.prototype.exclued = function (eStr) {
    var subIndex=this.indexOf(eStr);
	var firstStr=this.substring(0,subIndex);
	var lastStr=this.substring(eStr.Length+subIndex);
	return firstStr+lastStr;
}

/*浮点数的扩展方法*/
//格式化保留2位小数
function toDecimal2(x) {
    var f = parseFloat(x);
    if (isNaN(f)) {
        return false;
    }
    var f = Math.round(x * 100) / 100;
    var s = f.toString();
    var rs = s.indexOf('.');
    if (rs < 0) {
        rs = s.length;
        s += '.';
    }
    while (s.length <= rs + 2) {
        s += '0';
    }
    return s;
}