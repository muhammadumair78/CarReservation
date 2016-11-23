/**
 * @ngdoc controller
 * @name app.auth.controller:RegisterCtrl
 * @description Register controller
 */

(function(){

  'use strict';

  angular.module('app.auth')
    .controller('RegisterCtrl', RegisterCtrl);

  /* @ngInject */
  function RegisterCtrl(store){
    var vm = this;

    vm.register = register;

    function register() {
    }

  }

}());
