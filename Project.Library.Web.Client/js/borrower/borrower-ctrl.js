borrowerModule.controller('borrowerController', ['$scope', 'borrowerFactory', function ($scope, borrowerFactory) {
    var self = $scope;
    self.title = "Borrower List";
    self.borrowers = {};
    self.borrowerFilter = "";

    self.getBorrowers = function () {
        borrowerFactory.getBorrowers()
            .then(function (result) {
                self.borrowers = result.data;
            });
    }

    self.init = function () {
        self.getBorrowers();
    }
    self.init();
}]);