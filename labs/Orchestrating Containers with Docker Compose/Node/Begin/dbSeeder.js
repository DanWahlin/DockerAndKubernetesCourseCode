'use strict';
var dataInitializer = require('./lib/dataSeeder'),
    config = require('./config/config.development.json'),
    db = require('./lib/database');

db.init(config.databaseConfig);

console.log('Initializing Data');
dataInitializer.initializeData(function(err) {
  if (err) {
      console.log(err);
  }
  else {
      console.log('Data Initialized!')
  }
});