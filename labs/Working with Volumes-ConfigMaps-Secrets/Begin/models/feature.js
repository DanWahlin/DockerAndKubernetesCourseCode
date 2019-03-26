'use strict';

var mongoose        = require('mongoose'),
    Schema          = mongoose.Schema,
    ObjectId        = Schema.ObjectId;

var featureSchema = Schema({
    isFeatured              : { type: Boolean, required: true, default: true },
    position                : { type: Number,  required: true },
    title                   : { type: String,  required: true },
    text                    : { type: String,  required: true },
    highlightText           : { type: String,  required: false },
    backgroundImageUrl      : { type: String,  required: true },
    productId               : { type: ObjectId, turnOn: false, ref: 'product', required: false },
    link                    : { type: String, required: false },
    linkText                : { type: String, required: false },
    customCssClass          : { type: String, required: false },
    transparentBackground   : { type: Boolean, required: false },
    date                    : { type: Date, default: Date.now }
});

var FeatureModel = mongoose.model('feature', featureSchema, 'features');

module.exports = FeatureModel;
