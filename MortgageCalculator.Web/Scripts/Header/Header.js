$(document).ready(function () {
    $('li').removeClass("active");
    $('a[href="' + this.location.pathname + '"]').parent("li").addClass('active menu-bottom-border');
    
});