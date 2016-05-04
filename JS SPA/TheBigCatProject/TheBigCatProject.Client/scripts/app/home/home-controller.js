(function () {
    'use strict';

    function HomeController() {
        var vm = this;
        this.hi = 'Hi!';
        //cats.searchCats({ page: 1 })
        //    .then(function (initialCats) {
        //        vm.cats = initialCats;
        //    });
    }

    angular.module('catApp.controllers')
        .controller('HomeController', HomeController);
}());