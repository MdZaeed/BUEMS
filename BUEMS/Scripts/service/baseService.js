app.factory("baseService", ["$http", "$q", 
    function($http, $q) {    
        return {
            get: function(url) {
                var deferred = $q.defer();
                $http({
                        url: url,
                        method: "GET",
                        headers: {
                            "accept": "application/json;odata=verbose",
                            "content-Type": "application/json;odata=verbose"
                        }
                    })
                    .success(function(result) {
                        deferred.resolve(result);
                    })
                    .error(function(result, status) {
                        deferred.reject(status);
                    });
                return deferred.promise;
            },
            add: function(data, url) {
                var deferred = $q.defer();
                $http({
                        url: url,
                        method: "POST",
                        headers: {
                            "accept": "application/json;odata=verbose",
                            "content-Type": "application/json;odata=verbose"
                        },
                        data: JSON.stringify(data)
                    })
                    .success(function(result) {
                        deferred.resolve(result);
                    })
                    .error(function(result, status) {
                        deferred.reject(status);
                    });
                return deferred.promise;
            },
            remove: function(url) {
                var deferred = $q.defer();
                $http({
                        url: url,
                        method: "Get",
                        headers: {
                            "accept": "application/json;odata=verbose"
                        }
                    })
                    .success(function(result) {
                        deferred.resolve(result);
                    })
                    .error(function(result, status) {
                        deferred.reject(status);
                    });
                return deferred.promise;
            }
        };
    }
]);