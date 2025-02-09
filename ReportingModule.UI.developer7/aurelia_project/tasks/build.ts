import * as webpackConfig from '../../webpack.config';
import * as webpack from 'webpack';
import * as project from '../aurelia.json';
import * as gulp from 'gulp';
import * as del from 'del';
import {CLIOptions, Configuration} from 'aurelia-cli';
import configureEnvironment from './environment';

const analyze = CLIOptions.hasFlag('analyze');
const buildOptions = new Configuration(project.build.options);
const production = CLIOptions.getEnvironment() === 'prod';
const server = buildOptions.isApplicable('server');
const extractCss = buildOptions.isApplicable('extractCss');
const coverage = buildOptions.isApplicable('coverage');

const config = webpackConfig({
  production, server, extractCss, coverage, analyze
});
const compiler = webpack(<any>config);

function buildWebpack(done) {
  if (CLIOptions.hasFlag('watch')) {
    compiler.watch({}, onBuild);
  } else {
    compiler.run(onBuild);
    compiler.hooks.done.tap('done', () => done());
  }
}

function onBuild(err, stats) {
  if (!CLIOptions.hasFlag('watch') && err) {
    console.error(err.stack || err);
    if (err.details) console.error(err.details);
    process.exit(1);
  } else {
    process.stdout.write(stats.toString({ colors: require('supports-color') }) + '\n');

    if (!CLIOptions.hasFlag('watch') && stats.hasErrors()) {
      process.exit(1);
    }
  }
}

function copyAppStackTheme() {
  return gulp.src("appstack-1-2-2/dist/**")
    .pipe(gulp.dest(project.platform.output + "/appstack-1-2-2/dist"));
}

function clearDist() {
  return del([config.output.path]);
}

const build = gulp.series(
  clearDist,
  configureEnvironment,
  copyAppStackTheme,
  buildWebpack
);

export {
  config,
  buildWebpack,
  copyAppStackTheme
  build as default
};
