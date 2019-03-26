'use strict';

var mongoose        = require('mongoose'),
    Schema          = mongoose.Schema,
    ObjectId        = Schema.Types.ObjectId;
    
var exampleSchema = Schema({
    example     : { type: String, required: true },
    description : { type: String, required: true },

});

var dockerCommandSchema = Schema({
    command                 : { type: String, required: true },
    description             : { type: String, required: true },
    examples                : [exampleSchema]
});

var DockerCommandModel = mongoose.model('dockerCommand', dockerCommandSchema);


module.exports = DockerCommandModel;