/**
 * @ngdoc overview
 * @name app.core
 * @description Run funciton for core module
 */

(function(){

  'use strict';

  angular.module('app.core')
    .run(runFunciton);

  /* @ngInject */
  function runFunciton($ionicPlatform) {
    $ionicPlatform.ready(function() {
        // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
        // for form inputs)
        if (window.cordova && window.cordova.plugins.Keyboard) {
            cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
        }
        if (window.StatusBar) {
        // org.apache.cordova.statusbar required
            StatusBar.styleDefault();
        }
    });
  }
}());
