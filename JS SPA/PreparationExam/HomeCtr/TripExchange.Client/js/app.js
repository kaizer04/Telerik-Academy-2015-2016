(function () {
    'use strict';

    function config($routeProvider) {

        var PARTIALS_PREFIX = 'views/partials/';
        var CONTROLLER_AS_VIEW_MODEL = 'vm';

        $routeProvider
            .when('/', {
                templateUrl: PARTIALS_PREFIX + 'home/home.html',
                controller: 'HomeController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/register', {
                templateUrl: PARTIALS_PREFIX + 'identity/register.html',
                controller: 'SignUpCtrl'
            })
            .otherwise({ redirectTo: '/' });
    }

    angular.module('myApp.services', []);
    angular.module('myApp.controllers', ['myApp.services']);
    angular.module('myApp', ['ngRoute', 'ngCookies', 'myApp.controllers']).
        config(['$routeProvider', config])
        .value('toastr', toastr)
        .constant('baseServiceUrl', 'http://spa2014.bgcoder.com');
}());