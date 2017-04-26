var app = angular.module("service-app", []);

// define the app's single controller
app.controller("appCtrl", ["$scope", "baseService",

function ($scope, baseService) {
    var date = new Date();
    var month = new Array();
    month[0] = "January";
    month[1] = "February";
    month[2] = "March";
    month[3] = "April";
    month[4] = "May";
    month[5] = "June";
    month[6] = "July";
    month[7] = "August";
    month[8] = "September";
    month[9] = "October";
    month[10] = "November";
    month[11] = "December";
    $scope.selectedMonth = month[date.getMonth()];
    $scope.selectedYear = date.getFullYear();
    baseService.get("Salaries/NewIndex?month=" + $scope.selectedMonth + "&year=" + $scope.selectedYear)
    .then(function (response) {
        $scope.salaries = response;

    });

    $scope.update = function () {
        console.log($scope.salaries);
    }

}
]);