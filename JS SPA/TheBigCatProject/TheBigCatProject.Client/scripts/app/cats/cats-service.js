(function () {
    'use strict';

    function catsService($http, $q, baseUrl) {

        //var CATS_API_URL = 'api/cats';

        function addCat(cat) {
            var defered = $q.defer();

            $http.post(baseUrl + 'api/cats', cat)
                .then(function (response) {
                    defered.resolve(response)
                }, function (err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        //function searchCats(request) {
        //    return data.get(CATS_API_URL, request);
        //}

        return {
            addCat: addCat
            //searchCats: searchCats
        }
    }

    angular.module('catApp.services')
        .factory('cats', ['$http', '$q', 'baseUrl', catsService])
}());