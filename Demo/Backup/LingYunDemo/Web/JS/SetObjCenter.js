//========================================����Ŀ�������ҳ����Ծ���================================
function SetObjCenter(Tobj,tag){
	switch(tag){
	  //����һ������CSS���Զ����Ծ��У����۴�����α仯��
	  case 1:
		with(Tobj){
			css('position','absolute');
			css('left','50%');
			css('top','50%');
			css('margin-top',(0-parseInt(height()))/2+'px');
			css('margin-left',(0-parseInt(width()))/2+'px');
		}
	  
	  //��������ʵʱ���ݶ�������λ��������
	  case 2:
	  	with(Tobj){
			css('position','absolute');
			css('left',($(document).width()-width())/2 + 'px');
			css('top',($(document).height()-height())/2 + 'px');
		}
	}
}