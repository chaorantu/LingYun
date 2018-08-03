//======================================Êó±êÍÏ×§¶ÔÏó==================================
$.extend({MoveObj:function(THandle,TObj,e){
   e = e?e:window.event;
   var DoMove = false;
   var M_offsetX = 0;
   var M_offsetY = 0;
   TObj.css('position','absolute');
   with(THandle){
	 css('cursor','move');
	 //Download by http://www.codefans.net
	 mousedown(function(e){
		 DoMove = true;
		 M_offsetX = e.offsetX?e.offsetX:e.layerX;
		 M_offsetY = e.offsetY?e.offsetY:e.layerY;
	  });
	 mouseup(function(){
		  DoMove = false;
	  });
   }
   
   $(document).mousemove(function(e){
	  if(!DoMove)
	  return;
	  var obj_x = e.clientX - M_offsetX;
	  var obj_y = e.clientY - M_offsetY;
	  with(TObj){
		  css("left", obj_x);
		  css("top", obj_y);
	  }
	});
  }
});