(function () {
    'use strict';

    function AddCatController($location, cats) {
        var vm = this;

        vm.addCat = function (cat, catForm) {
            if (catForm.$valid) {
                cats.addCat(cat)
                    .then(function () {
                        //$location.path('/cats/details/' + catId);
                        alert('CAT ADDED!');
                    });
            }
        }
    }

    angular.module('catApp.controllers')
        .controller('AddCatController', ['$location', 'cats', AddCatController])
}());