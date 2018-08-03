//=======================================动态生成蒙层效果============================
var CoverLayerID = 'CoverLayer';
function OverScreen(tag){
	if($('#'+CoverLayerID).length>0){
	  with($('#'+CoverLayerID)){
		  if(tag==1){
			  LayoutAttr($('#'+CoverLayerID));
		  }
		  else{
			  css('display','none');
		  }
	  }
	}
	
	else if(tag==1){
		var CoverLayer = $('<div></div>');
		CoverLayer.appendTo('body');
		with(CoverLayer){
			attr('id',CoverLayerID);
			LayoutAttr(CoverLayer);
		}
	}
}

function LayoutAttr(obj){
	with(obj){
		css('position','absolute');
		css('background-color','#CCC');
		css('z-index','10');
		css('width','100%');
		css('left','0px');
		css('top','0px');
		css('display','block');
		css('opacity',0.8);
		css('height',$(document).height());
	}
}