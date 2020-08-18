

(function(dfsj_jq){

	dfsj_jq.fn.pagination = function(option){

		var self = this,

			cached = {};

		option = dfsj_jq.extend({

			target:dfsj_jq('ul li'),

			perpage:10,

			pagetotal:10,

			r_num:10

		},option);

		option.total = Math.ceil(option.pagetotal/option.perpage);

		//添加分页元素相应的事件

		var initEvent = function(ele){

			ele.find('a').bind('click',function(){

				 var self = dfsj_jq(this);

				 ele.children().remove();

				 ele.html(makePagnation(self.attr('page')) || '');

				 initEvent(ele);

				 dfsj_jq(window).scrollTop(670);

			});

			ele.find('.custompage2').bind('keydown',function(event){

				if(event.keyCode == 13){

					var self = dfsj_jq(this),

						val = self.val(),

						total = self.attr('maxPage');

					if(/[\d]+/.test(val)){

						val = parseInt(val);

						if(val>0 && val <= total){

							ele.children().remove();

							ele.html(makePagnation(val) || '');

							initEvent(ele);

						}

					}



				}

			})

		}

		//生成分页HTML

		var makePagnation = function(cur){

			cur = parseInt(cur);

			if(cur <1 || cur > option.total)return '';

			//控制显示的行数

			option.target.each(function(key){

				var max = cur * option.perpage - 1,

					min = (cur-1) * option.perpage

					self = dfsj_jq(this);

				if(key>=min && key <=max){

					self.show();

					var img = self.find('.deannewpifg img'),

					img_src = img.attr('src');

					!img_src && img.attr('src',img.attr('src_data'));

				}else{

					self.hide();

				}

			});

			//在分页缓存中查找

			if(cached[cur])return cached[cur];

			 var i =2,

				 tmpl = ['<div class="pages cl">'];

			 if(cur == 1){

				 r_num = Math.min(option.r_num,option.total);

				 tmpl.push('<span>1</span>');

				 for(;i<=r_num;i++)tmpl.push('<a page="'+i+'" href="javascript:;">'+i+'</a>');

				 if(option.total > i-1){

					tmpl.push('<a class="last" page="'+option.total+'" href="javascript:;">'+option.total+'</a>');

					tmpl.push('<a class="a1" page="2" >+</a>');

				 }

			 }else if(cur == option.total){

				 r_num = Math.max(1,option.total-2);

				 if(r_num >1){

					 tmpl.push('<a class="a1" page="'+(option.total-1)+'" href="javascript:;">-</a>');

					 tmpl.push('<a class="first" page="1" href="javascript:;">1</a>');

				 }

				 for(i=r_num;i<option.total;i++)tmpl.push('<a page="'+i+'" href="javascript:;">'+i+'</a>');

				 tmpl.push('<span>'+option.total+'</span>');

			 }else{

				 if(cur-2>0){

					 tmpl.push('<a class="a1" page="'+(cur-1)+'" href="javascript:;">-</a>');

					 tmpl.push('<a class="first" page="1" href="javascript:;">1</a>');

				 }

				 tmpl.push('<a page="'+(cur-1)+'" href="javascript:;">'+(cur-1)+'</a>');

				 tmpl.push('<span>'+cur+'</span>');

				 tmpl.push('<a page="'+(cur+1)+'" href="javascript:;">'+(cur+1)+'</a>');

				 if(cur+2 <= option.total){

					tmpl.push('<a class="last" page="'+option.total+'" href="javascript:;">'+option.total+'</a>');

					tmpl.push('<a class="a1" page="'+(cur+1)+'" >+</a>');

				 }

			 }

			 tmpl.push('</div>');

			 cached[cur] = tmpl.join('');

			 return cached[cur];

		}

		return this.each(function(){

			var ele = dfsj_jq(this);

			ele.html(makePagnation(1) || '');

			initEvent(ele);

		})

	}

})(jQuery);