//========================================设置目标对象在页面绝对居中================================
function SetObjCenter(Tobj,tag){
	switch(tag){
	  //方法一：利用CSS的自动绝对居中（无论窗口如何变化）
	  case 1:
		with(Tobj){
			css('position','absolute');
			css('left','50%');
			css('top','50%');
			css('margin-top',(0-parseInt(height()))/2+'px');
			css('margin-left',(0-parseInt(width()))/2+'px');
		}
	  
	  //方法二：实时根据对象所在位置来计算
	  case 2:
	  	with(Tobj){
			css('position','absolute');
			css('left',($(document).width()-width())/2 + 'px');
			css('top',($(document).height()-height())/2 + 'px');
		}
	}
}