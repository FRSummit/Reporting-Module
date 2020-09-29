import { Aurelia, Container } from 'aurelia-framework'
import {PLATFORM} from 'aurelia-pal';
import $ from "jquery";
import environment from './environment';
import { SignalrWrapper } from 'signalrwrapper';

function startAurelia(aurelia: Aurelia) {
  aurelia.use
  .developmentLogging(environment.debug ? 'debug' : 'warn')
  .standardConfiguration()
  .plugin(PLATFORM.moduleName('aurelia-dialog'))
  .feature(PLATFORM.moduleName('resources/index'));

  if (environment.testing) {
    aurelia.use.plugin(PLATFORM.moduleName('aurelia-testing'));
  }

  return aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app'))); 
}

export function configure(aurelia: Aurelia) {
  const signalrwrapper = <SignalrWrapper>Container.instance.get(SignalrWrapper);
  signalrwrapper.start();
  return startAurelia(aurelia);
}
