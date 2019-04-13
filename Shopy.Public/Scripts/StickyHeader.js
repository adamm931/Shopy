
$(window).scroll(function () {

    var scroll = $(window).scrollTop();

    if (scroll > 100) {
        $('.nav-2nd').addClass('sticky-top');
    }
    else {
        $('.nav-2nd').removeClass('sticky-top');
    }
})
