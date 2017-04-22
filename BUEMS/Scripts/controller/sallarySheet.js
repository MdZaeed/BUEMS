var app = angular.module("service-app", []);

// define the app's single controller
app.controller("appCtrl", ["$scope", "baseService", "$filter",

function ($scope, baseService, $filter) {

    baseService.get("/Salaries/SalarySheetAng")
    .then(function (response) {
        $scope.salaries = response;

    });

    $scope.update = function () {
        console.log($scope.salaries);
    }

}
]);