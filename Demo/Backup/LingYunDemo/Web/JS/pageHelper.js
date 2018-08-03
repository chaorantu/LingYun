
//得到焦点
function GetFocusByID(id) {
    document.getElementById(id).focus();
}

//跳转
function Redirect(url) {
    location = url;
}

//得到传递的参数的方法
function GetRequest() {
    var url = location.search; //获取url中"?"符后的字串
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            var result = strs[i].split("=");
            var name = result[0];
            var value = "";
            if (result.length < 3) {
                value = result[1];
            }
            else {
                for (var i = 1; i < result.length; i++) {
                    if (i == 1) {
                        value = result[i];
                    }
                    else {
                        value += "=" + result[i];
                    }
                }
            }
            theRequest[name] = (value);
        }
    }
    return theRequest;
}

//根据值改变选中项
function SelectItemByText(selectID, itemText) {
    var objSelect = document.getElementById(selectID);
    for (var i = 0; i < objSelect.options.length; i++) {
        if (objSelect.options[i].text == itemText) {
            objSelect.options[i].selected = true;
            break;
        }
    }
}

//得到select控件的选择值
function GetSelectText(id) {
    var select = document.getElementById(id);
    var text = select.options[select.options.selectedIndex].text;
    return text;
}

///去掉字符串中的空字符        
function Trim(str) {
    var text = str.replace(/\s/ig, '');
    return text;
}