'use strict';

var logger  = require('./logger'),
    env     = process.env.NODE_ENV;

if (!env) {
  env = 'development';
} 

logger.log('Node environment: ' + env);
logger.log('loading config.' + env + '.json');

module.exports = require('../config/config.' + env + '.json');