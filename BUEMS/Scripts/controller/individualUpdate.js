var app = angular.module("service-app", []);

// define the app's single controller
app.controller("appCtrl", ["$scope", "baseService",

function ($scope, baseService) {
    var index = 0;
    var length = 0;
    $scope.salary = {};
    baseService.get("/Salaries/SalarySheetAng")
    .then(function (response) {
        $scope.salaries = response;
        length = $scope.salaries.length;
        if(length!=0){
            $scope.salary = $scope.salaries[index];
        }
    });

    $scope.update = function () {
        baseService.put($scope.salaries, "/Salaries/UpdateAll/")
            .then(function (response) {
                alert("Updated");
            });
    }
    $scope.selected = function () {

    }

    $scope.next = function () {
        index++;
        if (index == length) {
            alert("This is the last one.");
            index--;
        }
        $scope.salary = $scope.salaries[index];
    }

    $scope.previous = function () {
        index--;
        if (index == -1) {
            alert("This is the first one.");
            index++;
        }
        $scope.salary = $scope.salaries[index];
    }
    
}
]);