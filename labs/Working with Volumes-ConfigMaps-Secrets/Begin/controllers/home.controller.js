'use strict';

var featureRepository = require('../lib/featureRepository');

module.exports = function (router) {

    router.get('/', function (req, res, next) {

        featureRepository.getFeatures(function (err, features) {

            if (err) return next(err);

            res.render('index', {
                features: features
            });
        });

    });
};


