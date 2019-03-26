var codeWithDan = codeWithDan || {};

(function($) {

    $(document).ready(function() {

        $('#searchButton').click(function() {
            var searchText = $('#searchText').val();
            if (searchText === '') return;
            location.href="/search?searchtext=" + searchText;
        });

        $('.category-header').click(function() {
            var catId = $(this).attr('data-categoryId');
            $('.category-container div[data-categoryId="' + catId + '"]').slideToggle(200);
        });

        //http://lazcreative.com/blog/adding-swipe-support-to-bootstrap-carousel-3-0/
        if (codeWithDan.helpers.isMobile()) {
            $("#carousel-codewithdan")
                .swiperight(function () {
                    $(this).carousel('prev');
                }).swipeleft(function () {
                    $(this).carousel('next');
                });
        }

        if (codeWithDan.helpers.isIE()) {
            //IE has issues with fixed background attachment
            $('.parallax').css('background-attachment', 'scroll');
        }
        
        var preloadImages = ['/img/background_manrocks_1920x500.jpg'];
        for (var i=0,len=preloadImages.length;i<len;i++) {
            $('<img />').attr('src', preloadImages[i]);
        };

    });

})(jQuery);

codeWithDan.helpers = function() {

    var isMobile = function() {
        return navigator.userAgent.match(/ipad|iphone|ipod|android|blackberry|webos|symbianos|silk|mobi/i) != null;
    },

    isIE = function() {
        return (navigator.userAgent.toLowerCase().indexOf('msie') !== -1 || navigator.userAgent.toLowerCase().indexOf('trident') !== -1);
    };

    return {
        isMobile: isMobile,
        isIE: isIE
    }

}();


