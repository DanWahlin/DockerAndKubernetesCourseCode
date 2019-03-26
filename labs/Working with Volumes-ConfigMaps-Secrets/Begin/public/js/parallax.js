"use strict";

(function($) {
    if (codeWithDan.helpers.isMobile() || codeWithDan.helpers.isIE()) return;

    $(document).ready(function () {
        var $window = $(window),
            parallaxes = [];

        $('.parallax').each(function () {
            parallaxes.push({item: $(this), speed: $(this).attr('data-speed')});
        });

        $window.scroll(function () {
            for (var i=0;i<parallaxes.length;i++) {
                var obj = parallaxes[i],
                    parallax = obj.item,
                    speed = (obj.speed) ? obj.speed : 5;

                var yPos = -(($window.scrollTop() - parallax.offset().top) / speed);
                //if(yPos > 0) yPos = 0;
                var coords = '50% ' + yPos + 'px';
                parallax.css({backgroundPosition: coords});
            }

        });

    });


    document.createElement("article");
    document.createElement("section");

}(jQuery));
