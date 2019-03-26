'use strict';
var mongoose = require('mongoose');

var database = function () {
    var conn = null,

        init = function (config) {
            console.log('Trying to connect to ' + config.host + '/' + config.database + ' MongoDB database');
            var options = {
                server: {},
                replset: {}
            };

            if (config.username && config.password) {           
                options.user = config.username;
                options.pass = config.password;
            }
            
            options.server.socketOptions = options.replset.socketOptions = { keepAlive: 1 };
            
            mongoose.connect('mongodb://' + config.host + '/' + config.database, options);
            conn = mongoose.connection;
            conn.on('error', console.error.bind(console, 'connection error:'));
            conn.once('open', function() {
                console.log('db connection open');
            });
            return conn;
        },

        close = function() {
            if (conn) {
                conn.close(function () {
                    console.log('Mongoose default connection disconnected through app termination');
                    process.exit(0);
                });
            }
        }

    return {
        init:  init,
        close: close
    };

}();

module.exports = database;
