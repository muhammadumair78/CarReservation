/**
 * @ngdoc overview
 * @name app.shell
 * @description Shell module
 */

(function(){

  angular.module('app.auth', [])
    .config(configuration);

  /* @ngInject */
  function configuration($stateProvider, appUserRole){

    $stateProvider
      .state('auth', {
        url:'/auth',
        role: appUserRole.All,
        templateUrl:'src/auth/landing.html'
      })
      .state('login', {
        url:'/login',
        role: appUserRole.All,
        templateUrl:'src/auth/login.html',
        controller: 'LoginCtrl as vm'
      })
      .state('register', {
        url:'/register',
        role: appUserRole.All,
        templateUrl:'src/auth/register.html',
        controller: 'RegisterCtrl as vm'
      });
  }

}());
