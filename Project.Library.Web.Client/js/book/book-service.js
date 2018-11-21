bookModule.factory('bookFactory', ['$http', '$q', function ($http, $q){
    var BaseUrl = 'http://localhost:51531/api/books';
    return {
        getBooks: function () {
            var deferred = $q.defer();
            $http({ method: 'GET', url: BaseUrl })
                .then(function (data, status, header, config) {
                    deferred.resolve(data);
                }, function (data, status, headers, config) {
                    deferred.reject(data);
                });

            return deferred.promise;

        }
    }
}]);