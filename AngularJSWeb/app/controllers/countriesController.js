'use strict';
app.controller('countriesController', ['$scope', 'countriesService', function ($scope, countriesService) {

    $scope.countries = [];

    countriesService.getCountries().then(function (results) {

        $scope.countries = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

}]);