var Imtech = {};
Imtech.Pager = function() 
{
	this.paragraphsPerPage = 2;
    this.currentPage = 1;
    this.pagingControlsContainer = '#pagination';
    this.pagingContainerPath = '#content';
    this.numPages = function() 
    {
        var numPages = 0;
        if (this.paragraphs != null && this.paragraphsPerPage != null) {
            numPages = Math.ceil(this.paragraphs.length / this.paragraphsPerPage);
        }
        return numPages;
    };

    this.showPage = function(page) 
    {
        this.currentPage = page;
        var html = '';
        this.paragraphs.slice((page-1) * this.paragraphsPerPage,((page-1)*this.paragraphsPerPage) + this.paragraphsPerPage).each(function() 
        {
            html += '<div>' + $(this).html() + '</div>';
        });
        $(this.pagingContainerPath).html(html);   
        renderControls(this.pagingControlsContainer, this.currentPage, this.numPages());
    }
    

    var renderControls = function(container, currentPage, numPages) 
    {
        var pagingControls = '<ul>';
        if(currentPage-1>0)
        {
        	pagingControls += '<li><a href="#" onclick="pager.showPage(1); return false;"><<</a></li>';
        	pagingControls += '<li><a href="#" onclick="pager.showPage('+(currentPage-1)+'); return false;"><</a></li>';
        }
        for (var i = 1; i <= numPages; i++) 
        {
            if (i != currentPage) 
            {
                pagingControls += '<li><a href="#" onclick="pager.showPage(' + i + '); return false;">' + i + '</a></li>';
            } 
            else 
            {
                pagingControls += '<li id="SelectedPage">' + i + '</li>';
            }
        }
        if(currentPage+1<=numPages)
        {
        	pagingControls += '<li><a href="#" onclick="pager.showPage('+(currentPage+1)+'); return false;">></a></li>';
        	pagingControls += '<li><a href="#" onclick="pager.showPage(' + numPages + '); return false;">>></a></li>';
        }
        pagingControls += '</ul>';
        $(container).html(pagingControls);
    }
}   

var pager = new Imtech.Pager();
$(document).ready(function() 
{
    pager.paragraphsPerPage = 2; 
    pager.pagingContainer = $("#content"); 
    pager.paragraphs = $("div.block", pager.pagingContainer); 
    pager.showPage(1);
});