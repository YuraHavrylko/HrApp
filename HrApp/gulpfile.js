/// <binding Clean='clean, min' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");

var paths = {
    webroot: "./wwwroot/bundle/"
};

paths.js = [

    "./node_modules/jquery/dist/jquery.js",
    "./node_modules/bootstrap/dist/js/bootstrap.js",
    "./node_modules/ripples/dist/js/ripple.js",
    "./node_modules/admin-lte/dist/js/material.js",
    "./node_modules/admin-lte/dist/js/adminlte.js",
    "./node_modules/admin-lte/dist/js/demo.js",
    //"./node_modules/datatables.net/js/jquery.dataTables.js",
    //"./node_modules/datatables.net-bs/js/dataTables.bootstrap.js"
];
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = [
    "./node_modules/bootstrap/dist/css/bootstrap.css",
    "./node_modules/admin-lte/dist/css/AdminLTE.min.css",
    "./node_modules/admin-lte/dist/css/bootstrap-material-design.min.css",
    "./node_modules/ripples/dist/css/ripple.min.css",
    "./node_modules/admin-lte/dist/css/MaterialAdminLTE.min.css",
    "./node_modules/admin-lte/dist/css/skins/all-md-skins.min.css",
    "./node_modules/datatables.net-bs/css/dataTables.bootstrap.css"
];
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
    return gulp.src(paths.js)
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src(paths.css)
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);