(function () {

    'use strict';

    var appUserRole = {
        Admin: 'Administrator',
        All: 'All'
    };

    angular
        .module('app.core')
        .constant('appUserRole', appUserRole);
}());