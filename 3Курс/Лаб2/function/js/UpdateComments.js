$(document).ready(function(){
	if($(document).scrollHeight == $(document).offsetHeight)
	{	
    	SendPhp();
	}
    $(window).scroll(function()
    {
        if($(window).scrollTop() + $(window).height() >= $(document).height()-1) 
        {
			SendPhp();
		}
    });
});

function SendPhp() {
	var $target = $("#insertCommits");
	var comment = parseInt($target.attr("data-page"));	
	$.ajax({ 
		url: "function/php/LoadThreeComments.php?comment="+comment,  
		dataType: "html",
		success: function(data){
			comment+=3;
			$("#insertCommits").append(data);
			$target.attr("data-page", comment)
		}
	});
}