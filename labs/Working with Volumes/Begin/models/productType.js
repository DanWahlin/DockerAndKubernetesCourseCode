'use strict';

var mongoose        = require('mongoose'),
    Schema          = mongoose.Schema,
    ObjectId        = Schema.ObjectId;

var productTypeSchema = Schema({
    title	        : { type: String },
    linkTitle       : { type: String },
    iconCssClass    : { type: String },
    description     : { type: String }
});

var ProductTypeModel = mongoose.model('productType', productTypeSchema, 'productTypes');


module.exports = ProductTypeModel;
