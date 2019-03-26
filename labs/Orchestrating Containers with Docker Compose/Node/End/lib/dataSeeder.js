'use strict';

var DockerCommand = require('../models/dockerCommand');

var dataInitializer = function () {

    var initializeData = function(callback) {
           
            var runDockerCommand = new DockerCommand({
                command             : 'run',
                description         : 'Runs a Docker container',
                examples            : [
                    {
                        example: 'docker run imageName',
                        description: 'Creates a running container from the image. Pulls it from Docker Hub if the image is not local'
                    },
                    {
                        example: 'docker run -d -p 8080:3000 imageName',
                        description: 'Runs a container in "daemon" mode with an external port of 8080 and a container port of 3000.'
                    }
                ]});
             
             runDockerCommand.save(function(err) {
                 if (err) {
                     return callback(err);                     
                 }
             });
             
            var psDockerCommand = new DockerCommand({
                command             : 'ps',
                description         : 'Lists containers',
                examples            : [
                    {
                        example: 'docker ps',
                        description: 'Lists all running containers'
                    },
                    {
                        example: 'docker ps -a',
                        description: 'Lists all containers (even if they are not running)'
                    }
                ]});
             
             psDockerCommand.save(function(err) {
                 if (err) {
                     return callback(err);                     
                 }
             });

        };


    return {
        initializeData: initializeData
    };

}();

module.exports = dataInitializer;