
//$(window).scroll(_.throttle(() => {

$(window).scroll(function () {
    if ($(window).scroll > 100) {
        $('.nav-2nd').addClass('sticky-top');
    }
    else {
        $('.nav-2nd').removeClass('sticky-top');
    }
})

//}, 300));
