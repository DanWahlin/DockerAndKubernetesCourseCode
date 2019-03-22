'use strict';

var Feature     = require('../models/feature'),
    redisClient = require('./redisClient'),
    logger      = require('./logger');

var featureRepository = function() {

    var getFeatures = function(callback) {
      
        var cacheKey = 'finance',
            client = redisClient.connect();
        
            //Check cache for features
            client.get(cacheKey, function(err, features) {
                if (features) {
                    logger.log('Retrieved features data from Redis cache...');
                    callback(err, JSON.parse(features));
                }
                else {
                    //No features in cache so call DB and update Redis cache
                    Feature.find({ 'isFeatured' : true })
                        .sort({ position: 'asc' })
                        //.select("position title text highlightText backgroundImageUrl productId link linkText customCssClass transparentBackground")
                        .populate('sku')
                        .exec(function(err, features) {
                            logger.log('Retrieved features data from MongoDB...');
                            if (!err) {
                                client.set(cacheKey, JSON.stringify(features), function(err, reply) {});
                                client.expire(cacheKey, 30);
                                logger.log('Added features data to Redis cache...');
                            }
                            callback(err, features);
                        });                     
                }
            });  
    };

    return {
        getFeatures: getFeatures
    };

}();

module.exports = featureRepository;

