var express = require('express');
var router = express.Router();
var dockerCommandsRepository = require('../lib/dockerCommandsRepository');

/* GET home page. */
router.get('/', function(req, res, next) {
  dockerCommandsRepository.getDockerCommands(function(err, commands) {
      res.render('index', { dockerCommands: commands });
  })
  
});

module.exports = router;
