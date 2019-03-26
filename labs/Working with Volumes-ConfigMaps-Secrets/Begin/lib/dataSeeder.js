'use strict';

var mongoose        = require('mongoose'),
    Category        = require('../models/category'),
    ProductType     = require('../models/productType'),
    Feature         = require('../models/feature');

var dataSeeder = function () {
    var seed = function() {
        mongoose.connection.db.listCollections({name: 'productType'})
                .next((err, collinfo) => {
                    if (!collinfo) {
                        console.log('Starting dbSeeder...');
                        seedData();
                    }
                });
    },
    
    seedData = function() {

/*
 ########################################################################################
                               Product Types (for top menu on site)
 ########################################################################################
 */
            var videoProductType = new ProductType({
                title       : "Videos",
                linkTitle   : "Videos",
                iconCssClass: "fa-play-circle",
                description : "Get the highest quality video training out there!"
            });

            var trainingProductType = new ProductType({
                title: "Training",
                linkTitle   : "Training",
                iconCssClass: "fa-users",
                description : "Looking for expert onsite training for your team? We provide training on a range of technologies and have experts who know how to teach - not just talk!"
            });

            var trainingMaterialsProductType = new ProductType({
               title: "Courseware",
               linkTitle   : "Courseware",
               iconCssClass: "fa-file-text",
               description : "License our top-notch courseware, hands-on labs and code samples."
            });
            
            videoProductType.save();
            trainingProductType.save();
            trainingMaterialsProductType.save();

/*
 ########################################################################################
                                    General Categories
 ########################################################################################
 */

            var nodeCategory = new Category({
                title   : "Node.js Courses",
                imageUrl: "",
                cssClass: "nodeCategory"
            });

            var jsCategory = new Category({
                title: "JavaScript Courses",
                imageUrl: "",
                cssClass: "javascriptCategory"
            });

            nodeCategory.save();
            jsCategory.save();


/*
########################################################################################
                                    Features
########################################################################################
 */


            var feature1 = new Feature({
                position      : 0,
                isFeatured    : true,
                title         : "AngularJS JumpStart",
                text          : "The most productive way to learn AngularJS! JumpStart your learning with this step-by-step video course!",
                highlightText : "Over 6 hours of content!",
                link          : "/products/training",
                linkText      : "Get Details",
                highlightText : "Over 6 hours of content!",
                backgroundImageUrl : "/img/background_girl_1920x500.jpg"
            });

            var feature2 = new Feature({
                position : 3,
                isFeatured: true,
                title : "AngularJS Custom Directives",
                text : "Dive in to AngularJS and learn how to build custom directives!",
                highlightText : "Advanced AngularJS Content!",
                link : "/products/training",
                linkText : "Get Details",
                highlightText : "Advanced AngularJS Content!",
                backgroundImageUrl : "/img/background_man_couch_1920x500.jpg"
            });

            var feature3 = new Feature({
                position : 2,
                isFeatured: true,
                title : "Focused Onsite Training",
                text : "World-class JavaScript, Angular, Node.js, C#, ASP.NET MVC (and more) training at your location. Whether you're located in the middle of nowhere or in a high-rise corporate building.",
                link : "/products/training",
                linkText : "Get Details",
                backgroundImageUrl : "/img/background_road_1920x500.jpg",
                customCssClass : "white"
            });
            
            var feature4 = new Feature({
                position : 1,
                isFeatured: true,
                title : "World-Class Onsite Training",
                text : "We provide the worlds best hands-on training at your location. Anywhere in the world!",
                link : "/products/training",
                linkText : "Get Details",
                backgroundImageUrl : "/img/background_singapore_1920x500.jpg"
            });

            feature1.save();
            feature2.save();
            feature3.save();
            feature4.save();

            console.log('Data seeded!');
        };


    return {
        seed: seed,
        seedData: seedData
    };

}();

module.exports = dataSeeder;

