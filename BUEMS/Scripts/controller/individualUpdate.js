var app = angular.module("service-app", []);

// define the app's single controller
app.controller("appCtrl", ["$scope", "baseService",

function ($scope, baseService) {
    var index = 0;
    var length = 0;
    $scope.salary = {};
    $scope.categories = ["শিক্ষক", "কর্মকর্তা", "কর্মচারি"];
    $scope.selectedCategory = "শিক্ষক";
    $scope.data=[]
    
    $scope.getCategoryTitles = function () {
        $scope.showEditTable = false;
        $scope.selectedDept = null;
        baseService.get("/Titles/GetTitleByCategory?cat=" + $scope.selectedCategory)
            .then(function (response) {
                $scope.titles = response;
            });
    }
    
    $scope.selectTitle = function () {
        $scope.showEditTable = true;
        $scope.selectedDept = null;
        $scope.salaries = $scope.data.filter(function (node) {
            if (node.Title == $scope.selectedTitle) {
                return true;
            }
        });

        length = $scope.salaries.length;
        if (length != 0) {
            $scope.salary = $scope.salaries[index];
        }
    }

    $scope.selectDept = function () {
        $scope.showEditTable = true;
        $scope.salaries = $scope.salaries.filter(function (node) {
            if (node.Institute == $scope.selectedDept) {
                return true;
            }
        });

        length = $scope.salaries.length;
        if (length != 0) {
            $scope.salary = $scope.salaries[index];
        }
        else $scope.salary = null;
    }

    $scope.getCategoryTitles();

    baseService.get("/Salaries/SalarySheetAng")
    .then(function (response) {
        $scope.data = response;
        $scope.salaries = $scope.data;
    });

    baseService.get("/Departments/IndexJson")
    .then(function (response) {
        $scope.depts = response;
    });

    $scope.update = function () {
        baseService.put($scope.salaries, "/Salaries/UpdateAll/")
            .then(function (response) {
                alert("Updated");
            });
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