//写cookies
function setCookie(name, value, days) {
    var Days = days;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + ";path=/";

    //var strsec = getsec(time);
    //var exp = new Date();
    //exp.setTime(exp.getTime() + strsec * 1);
    //document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
}

//读取cookies
function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");

    if (arr = document.cookie.match(reg))
        return (unescape(arr[2]));
    else
        return null;
}

//删除cookies
function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null)
        document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString() + ";path=/";
}


///读取cookies子健的值
function GetCookie(mainName, subName) {
    var arr = document.cookie.match(new RegExp("(^| )" + mainName + "=([^;]*)(;|$)"));
    if (arr != null) {
        arr = decodeURI(unescape(arr[2])).split("&");
        for (x in arr) {
            if (arr[x].split("=")[0] == subName) {
                return arr[x].split("=")[1];
            }
        }
    }
    return null;
}

///得到cookies中所有子健的名称
function GetCookieAllSubName(mainName) {
    var arrayName = new Array(); //要返回的子健名称的集合

    var arr = document.cookie.match(new RegExp("(^| )" + mainName + "=([^;]*)(;|$)"));
    if (arr != null) {
        arr = unescape(arr[2]).split("&");
        for (x in arr) {
            arrayName.push(arr[x].split("=")[0]);
        }
        return arrayName;
    }
    return null;
}

///设置cookies子健的值
function SetCookie(mainName, subName, value, days) {
    //子健以&字符拼接  如cookies("userinfo")的值为username=nike&password=1234&age=18

    //先判断是否已存在该cookies
    var _value = getCookie(mainName);

    if (_value != null) {
        //判断是否已存在该子健，如果存在则修改值，如果不存在，则增加该子健
        var obj = GetCookie(mainName, subName);
        //先解码原先的字符串
        _value = decodeURI(_value);
        if (obj == null) {
            value = _value + "&" + subName + "=" + value;
        }
        else {
            var indexStart = _value.indexOf(subName); //该子健在字符串中的起始位置
            var indexEnd = _value.indexOf("&", indexStart); //从开始位置检索到等式（a=1&）的结束位置
            if (!(indexEnd < 0)) {
                if (indexStart == 0) //在开始位置
                {
                    _value = _value.substring(indexEnd);
                    value = subName + "=" + value + _value;
                }
                else //在中间位置
                {
                    var arr1, arr2;
                    arr1 = _value.substring(0, indexStart);
                    arr2 = _value.substring(indexEnd);
                    value = arr1 + subName + "=" + value + arr2;
                }
            }
            else //在尾部位置
            {
                var index = _value.lastIndexOf("=");
                _value = _value.substring(0, index + 1);
                value = _value + value;
            }
        }
    }
    else {
        value = subName + "=" + value;
    }
    var Days = days;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = mainName + "=" + escape(encodeURI(value)) + ";expires=" + exp.toGMTString() + ";path=/";
}

///删除cookies子健的值
function DelCookie(mainName, subName) {
    var arr = document.cookie.match(new RegExp("(^| )" + mainName + "=([^;]*)(;|$)"));
    if (arr != null) {
        arr = unescape(arr[2]);
        //查找索引替换字符串
        //var rex = eval("/&?" + subName + "/");
        var indexStart = arr.indexOf(subName); //该子项在字符串中的初始位置
        var indexEnd = arr.indexOf("&", indexStart); //从开始位置检索到等式（a=1&）的结束位置
        var arr1, arr2;
        if (!(indexEnd < 0))  //该子项处于字符串的前部
        {
            if (indexStart == 0) //在开始位置
            {
                arr = arr.substring(indexEnd + 1);
            }
            else //在中间位置
            {
                arr1 = arr.substring(0, indexStart - 1);
                arr2 = arr.substring(indexEnd);
                arr = arr1 + arr2;
            }
        }
        else //该子项处于字符串的尾部
        {
            arr = arr.substring(0, indexStart - 1);
        }
        var Days = 7;
        var exp = new Date();
        exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
        document.cookie = mainName + "=" + escape(arr) + ";expires=" + exp.toGMTString() + ";path=/";
    }
}