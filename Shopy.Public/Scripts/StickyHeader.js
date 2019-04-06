$(window).scroll(_.throttle(() => {

    var scrollPosition = Math.round(window.scrollY);

    if (scrollPosition > 100) {
        $('.nav-2nd').addClass('sticky-top');
    }
    else {
        $('.nav-2nd').removeClass('sticky-top');
    }

}, 300));