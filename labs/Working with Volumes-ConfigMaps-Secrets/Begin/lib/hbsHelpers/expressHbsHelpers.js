'use strict';

var helpers = function() {

    var formatCurrency = function (value, options) {
        var currencyString = '$0.00';

        if (value && !isNaN(value)) {
            currencyString = '$' + parseFloat(value).toFixed(2);
        }

        return currencyString;
    },

    formatPrice = function(regularPrice, discountPrice, options) {
        var priceString = '';

        if (discountPrice) {
            priceString = '<span class="regularPriceBeforeDiscount"> $' + regularPrice + '</span> ' +
                ' <span class="discountPrice">$' + discountPrice + '</span> ';
        }
        else {
            priceString = '<span class="">$' + regularPrice + '</span> ';
        }

        return priceString;
    };

    return {
        formatCurrency: formatCurrency,
        formatPrice: formatPrice
    };

}();

module.exports = helpers;
