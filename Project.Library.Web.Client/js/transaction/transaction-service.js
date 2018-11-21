transactionModule.factory('transactionFactory', ['$http', '$q', function ($http, $q) {
    var BaseUrl = 'http://localhost:51531/api/transactions';
    return {
        getTransactions: function () {
            var deferred = $q.defer();
            $http({ method: 'GET', url: BaseUrl })
                .then(function (data, status, header, config) {
                    deferred.resolve(data);
                }, function (data, status, headers, config) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        createTransaction: function (transaction) {
            var deferred = $q.defer();
            $http({ method: 'POST', url: BaseUrl, data: transaction })
                .then(function (data, status, header, config) {
                    deferred.resolve(data);
                }, function (data, status, headers, config) {
                    deferred.reject(data);
                });

            return deferred.promise;
        }
    }
}]);