/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    path = require("path"),
    watch = require("gulp-watch"),
    batch = require("gulp-batch");

var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    // Kinda gross, but it's quick way to ensure files are concat in the correct order
    return gulp.src(
        [
            paths.webroot + '/js/models/*.js',
            paths.webroot + '/js/services/*.js',
            paths.webroot + '/js/view-updater.js',
            paths.webroot + '/js/weather-app.js',
            , "!" + paths.minJs
        ], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

// Run js min whenever a js file that is not a min.js file changes
gulp.task("watch:js", function () {
    watch([paths.js, "!" + paths.minJs], batch(function (events, done) {
        gulp.start("min:js", done);
    }))
});

gulp.task("min", ["min:js", "min:css"]);
