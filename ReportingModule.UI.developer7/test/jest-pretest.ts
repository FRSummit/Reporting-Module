import 'aurelia-polyfills';
import {Options} from 'aurelia-loader-nodejs';
import {globalize} from 'aurelia-pal-nodejs';
import * as path from 'path';
Options.relativeToDir = path.join(__dirname, 'unit');
globalize();
import {JSDOM} from "jsdom";
const jsdom = new JSDOM('<!doctype html><html><body></body></html>');

(global as any).HTMLAnchorElement = jsdom.window.HTMLAnchorElement;

class LocalStorageMock {
    store: {};
    constructor() {
      this.store = {};
    }
  
    clear() {
      this.store = {};
    }
  
    getItem(key) {
      return this.store[key] || null;
    }
  
    setItem(key, value) {
      this.store[key] = value.toString();
    }
  
    removeItem(key) {
      delete this.store[key];
    }
  };
  
declare global {
    interface Window { localStorage: any; }
}

window.localStorage = new LocalStorageMock();