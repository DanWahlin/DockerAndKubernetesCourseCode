"use strict";

var helpers = function() {
    
    var isBot = function(req) {
        var bfield = req.body.bfield;
        return (bfield && bfield.length);
    },

    itemExists = function (array, propertyName, value) {
            if (!array) return -1;
            var pos;
            if (propertyName) {
                pos = array.map(function (item) {
                    return item[propertyName].toString();
                }).indexOf(value);
            }
            else {
                pos = array.map(function (item) {
                    return item.toString();
                }).indexOf(value);
            }
            return pos;
    },

    addDays = function(days) {
        var date = new Date(),
            expDate = new Date();

        expDate.setDate(date.getDate() + days);
        expDate.setHours(0,0,0,0);
        return expDate;
    },

    getDateTimeString = function () {
        var now = new Date();
        var datetime = (now.getMonth() + 1) + "/" +
            now.getDate() + "/" +
            now.getFullYear() + " " +
            now.getHours() + ":" +
            now.getMinutes() + ":" +
            now.getSeconds();
        return datetime;
    },

    getDateTime = function() {
        return new Date(Date.now()); //GMT
    },

    getUTCDateTime = function () {
        var dateString = getDateTimeString() + " UTC";
        return new Date(dateString);
    };

    return {
        isBot: isBot,
        itemExists: itemExists,
        addDays: addDays,
        getDateTimeString: getDateTimeString,
        getDateTime: getDateTime,
        getUTCDateTime: getUTCDateTime
    };

}();

module.exports = helpers;
