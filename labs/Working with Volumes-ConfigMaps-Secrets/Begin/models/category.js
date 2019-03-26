'use strict';

var mongoose    = require('mongoose'),
    Schema      = mongoose.Schema;

var categorySchema = Schema({
    title	: { type: String },
    imageUrl: { type: String },
    cssClass: { type: String }
});

var CategoryModel = mongoose.model('category', categorySchema, 'categories');

module.exports = CategoryModel;





