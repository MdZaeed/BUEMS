var app = angular.module("service-app", []);

// define the app's single controller
app.controller("appCtrl", ["$scope", "baseService",

function ($scope, baseService) {
    
    baseService.get("/Salaries/SalarySheetAng")
    .then(function (response) {
        $scope.salaries = response;

    });

    $scope.update = function () {
        baseService.put($scope.salaries, "/Salaries/UpdateAll")
            .then(function (response) {
                //alert("Updated");
            });
    }

}
]);