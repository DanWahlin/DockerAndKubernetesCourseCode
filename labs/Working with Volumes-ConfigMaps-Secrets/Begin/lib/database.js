'use strict';
var mongoose = require('mongoose'),
    seeder = require('./dataSeeder');
mongoose.Promise = global.Promise;

var database = function () {
    var conn = null,
        connectionTries = 0,
        seeded = false,

        init = function (config) {
            console.log('Trying to connect to ' + config.host + '/' + config.database + ' MongoDB database');
            var options = {
                promiseLibrary: global.Promise
            };

            // #######
            //  If using Kubernetes we could pull the password from an env variable set via a Secret
            //  That's actually done in the .k8s/mongo.deployment.yml file if you're interested in seeing it in action
            //  Keeping it simple here on purpose
            // #######
            var connString = `mongodb://${encodeURIComponent(config.username)}:${encodeURIComponent(config.password)}@${config.host}:27017/${config.database}`;
            conn = mongoose.connection;
            conn.on('error', function(err) {
                console.error('Connection error: ', err);
            });
            conn.once('open', function() {
                console.log('db connection open');
                //Set NODE_ENV to 'development' and uncomment the following if to only run
                //the seeder when in dev mode
                //if (process.env.NODE_ENV === 'development') {
                //  seeder.seed();
                //} 
                
                // simple check just to make sure we don't accidentally seed multiple times
                if (!seeded) {
                    seeded = true;
                    seeder.seed();
                }
            });

            connect(connString, options);
            return conn;
        },

        connect = function(connStr, options) {
            mongoose.connect(connStr, options, function(err) {
                if (err) {
                    if (connectionTries < 10) {
                        setTimeout(() => {
                            console.log('****** Trying connect again. Tried ' + connectionTries + ' times ******');
                            connectionTries++;
                            connect(connStr, options);
                        }, 5000);
                    }
                }
            });
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
