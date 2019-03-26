var gulp = require('gulp'),
    babel = require('gulp-babel'),
    sass = require('gulp-sass'),
    csso = require('gulp-csso'),
    uglify = require('gulp-uglify'),
    concat = require('gulp-concat'),
    plumber = require('gulp-plumber'),
    templateCache = require('gulp-angular-templatecache'),
    jsPath = 'public/js/*.js',
    jsDist = 'public/js/dist',
    es6FilesPath = 'public/js/*.es6.js';

gulp.task('sass', function() {
    gulp.src('public/css/styles.scss')
        .pipe(plumber())
        .pipe(sass({ errLogToConsole: true }))
        .pipe(csso())
        .pipe(gulp.dest('public/css'));
});

gulp.task('babel', function () {
    return gulp.src([
            es6FilesPath
         ])
        .pipe(babel())
        .pipe(gulp.dest('public/js/compiled'));;
});

gulp.task('compressScripts', function() {
    gulp.src([
        jsPath
    ])
        .pipe(concat('scripts.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(jsDist));
});

gulp.task('compressCartApp', function() {
    gulp.src([
        'public/app/app.js',
        'public/app/services/*.js',
        'public/app/controllers/*.js',
        'public/app/filters/*.js',
        'public/app/directives/*.js'
    ])
        .pipe(concat('cartApp.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(jsDist));
});

gulp.task('templates', function() {
    gulp.src('public/app/views/**/*.html')
        .pipe(templateCache({ root: 'app/views', module: 'codeWithDan' }))
        .pipe(gulp.dest(jsDist));
});

gulp.task('watch', function() {

    gulp.watch('public/css/*.scss', ['sass']);

    gulp.watch([
        'public/js/*.js' /*,
        '!public/js/compiled',
        '!public/js/lib' */],
        ['compressScripts']);

    gulp.watch([
        'public/app/*.js'],
        ['compressCartApp']);

});

gulp.task('default', ['sass', 'compressScripts', 'compressCartApp', 'templates', 'watch']);

