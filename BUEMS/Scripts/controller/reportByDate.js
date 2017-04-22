var app = angular.module("service-app", ['wj']);

        // define the app's single controller
        app.controller("appCtrl", ["$scope", "baseService", "$filter",
        
        function ($scope, baseService, $filter) {
            var url = window.location.pathname;
            console.log(url);
            var parts = url.split("/");
            var id = parts[parts.length - 1];
            baseService.get("/salaries/IndividualSheetData/" + id)
            .then(function(response){
                $scope.salary = response;

            });
            

            // commands
            $scope.print = function () {

                // create document
                var doc = new wijmo.PrintDocument({
                    title: "abcd"
                });
                

                // add content to it
                var view = document.querySelector('.zoom');
                for (var i = 0; i < view.children.length; i++) {
                    doc.append(view.children[i]);
                }

                // and print it
                doc.print();
            }

    }
]);