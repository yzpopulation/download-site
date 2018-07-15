/// <binding BeforeBuild='default' />
var gulp = require('gulp');

gulp.task('default', function() {
    return gulp.src('node_modules/*/dist/**/*')
        .pipe(gulp.dest('wwwroot/lib'));
});