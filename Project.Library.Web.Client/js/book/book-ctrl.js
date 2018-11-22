bookModule.controller('bookController', ['$scope','$route', 'bookFactory', 'borrowerFactory', 'transactionFactory', function ($scope, $route, bookFactory, borrowerFactory, transactionFactory) {
    var self = $scope;
    self.title = "Books List";
    self.books = {};
    self.borrowers = {};
    self.filterBook = "";
    self.transaction = {};
    self.Sample = 1 < 1;

    self.getBooks = function ()
    {
        self.books = {};
        bookFactory.getBooks()
            .then(function (result) {
                console.log(result);
                self.books = result.data;
            });
    }

    self.getBorrowers = function () {
        self.borrowers = {};
        borrowerFactory.getBorrowers()
            .then(function (result) {
                console.log(result);
                self.borrowers = result.data;
            });
    }

    self.toggleRentModal = function (book) {
        self.transaction.Book = book;
        $('#rentModal').modal('show');
    }

    self.rentBook = function () {
        self.transaction.Borrower = JSON.parse(self.transaction.Borrower);
        self.transaction.TransactionType = 'Borrow';
        transactionFactory.createTransaction(self.transaction)
            .then(function (result) {
                console.log(result.data);
                $('#rentModal').modal('hide');
                self.transaction = {};
                self.init();
            });
    }

    self.init = function () {
        self.getBorrowers();
        self.getBooks();
    }

    self.init();
}]);
