var app = angular.module("service-app", ['wj']);

// define the app's single controller
app.controller("appCtrl", ["$scope", "baseService",
    function($scope, baseService) {
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
        $scope.thisMonthConfirmed = false;
        var flag = 0;
        $scope.update = function (){
            baseService.get("/Salaries/NewIndex?month=" + $scope.selectedMonth + "&year=" + $scope.selectedYear).
                then(function(response) {
                    $scope.salaries = response;
                    if($scope.salaries.length!=0 && flag==0){
                        $scope.thisMonthConfirmed = true;
                        flag == 1;
                    }
                });
        }

        $scope.update2 = function () {
            var from = month.indexOf($scope.fromMonth);
            var to = month.indexOf($scope.toMonth);
            $scope.salaries = [];
            for (var i = from; i <= to; i++) {
                baseService.get("/Salaries/NewIndex?month=" + month[i] + "&year=" + $scope.selectedYear).
                then(function (response) {
                    $scope.salaries=$scope.salaries.concat(response);
                });
            }
            
        }

        $scope.update();

        $scope.print = function () {

            // create document
            var doc = new wijmo.PrintDocument({
                title: "abcd"
            });


            // add content to it
            var view = document.querySelector('#zoom');
            for (var i = 0; i < view.children.length; i++) {
                doc.append(view.children[i]);
            }

            // and print it
            doc.print();
        }
    }
]);