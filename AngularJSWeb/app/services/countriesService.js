'use strict';
app.factory('countriesService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var countriesServiceFactory = {};

    var _getCountries = function () {

        return $http.get(serviceBase + 'api/countries').then(function (results) {
            return results;
        });
    };

    countriesServiceFactory.getCountries = _getCountries;

    return countriesServiceFactory;

}]);