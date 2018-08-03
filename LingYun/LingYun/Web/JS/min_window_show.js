function BOX_show(e, BOX_overlay)//显示
{
    if (document.getElementById(e) == null) {
        return;
    }

    BOX_layout(e, BOX_overlay);
    window.onresize = function () { BOX_layout(e, BOX_overlay); } //改变窗体重新调整位置
    window.onscroll = function () { BOX_layout(e, BOX_overlay); } //滚动窗体重新调整位置
    document.onkeyup = function (event) {
        var evt = window.event || event;
        var code = evt.keyCode ? evt.keyCode : evt.which;
        //alert(code);

        if (code == 27) {
            BOX_remove(e, BOX_overlay);
        }
    }
}

//11.23新加关闭方式
function BOX_show_BT(s) {
    var v = document.getElementById(s).value;
    BOX_show(v, BOX_overlay);
}

function BOX_remove(e, BOX_overlay)//移除
{
    window.onscroll = null;
    window.onresize = null;
    document.getElementById(BOX_overlay).style.display = "none";
    document.getElementById(e).style.display = "none";

    var selects = document.getElementsByTagName('select');
    for (i = 0; i < selects.length; i++) {
        selects[i].style.visibility = "visible";
    }
    //document.body.style.overflow = "auto"; //11.22新加
}

function BOX_layout(e, BOX_overlay)//调整位置
{
    var a = document.getElementById(e);

    if (document.getElementById(BOX_overlay) == null)//判断是否新建遮掩层
    {

        var overlay = document.createElement("div");
        overlay.setAttribute('id', BOX_overlay);

        //overlay.onclick=function(){BOX_remove(e);};
        //a.parentNode.appendChild(overlay);
        document.body.appendChild(overlay);
    }

    document.getElementById(BOX_overlay).ondblclick = function () { BOX_remove(e, BOX_overlay); };
    //取客户端左上坐标，宽，高
    var scrollLeft = (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
    var scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
    //var scrollLeft = document.documentElement.scrollLeft;
    //var scrollTop = document.documentElement.scrollTop;

    var clientWidth;
    if (window.innerWidth) {
        clientWidth = window.innerWidth;
        // clientWidth = ((Sys.Browser.agent === Sys.Browser.Safari) ? window.innerWidth : Math.min(window.innerWidth, document.documentElement.clientWidth));
    }
    else {
        clientWidth = document.documentElement.clientWidth;
    }

    var clientHeight;
    if (window.innerHeight) {
        clientHeight = window.innerHeight;
        //clientHeight = ((Sys.Browser.agent === Sys.Browser.Safari) ? window.innerHeight : Math.min(window.innerHeight, document.documentElement.clientHeight));
    }
    else {
        clientHeight = document.documentElement.clientHeight;
    }

    var bo = document.getElementById(BOX_overlay);
    bo.style.left = scrollLeft + 'px';
    bo.style.top = scrollTop + 'px';
    bo.style.width = clientWidth + 'px';
    bo.style.height = clientHeight + 'px';
    bo.style.display = "";
    //Popup窗口定位
    a.style.position = 'absolute';
    a.style.zIndex = 999;
    a.style.display = "";
    a.style.left = scrollLeft + ((clientWidth - a.offsetWidth) / 2) + 'px';
    a.style.top = scrollTop + ((clientHeight - a.offsetHeight) / 2) + 'px';
}

function HiddenButton(e) {
    e.style.visibility = 'hidden';
    e.coolcodeviousSibling.style.visibility = 'visible'
}