'use strict';

var DockerCommand = require('../models/dockerCommand');

var dockerCommandsRepository = function() {

    var getDockerCommands = function(callback) {

        DockerCommand.find(function(err, commands) {

            if (err) return callback(err, null);

            callback(err, commands);

        });

    };

    return {
        getDockerCommands : getDockerCommands
    };

}();

module.exports = dockerCommandsRepository;