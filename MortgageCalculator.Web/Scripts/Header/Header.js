$(document).ready(function () {

    $('li').removeClass("active");
    $('a[href="' + this.location.pathname + '"]').parent().addClass('active');

})