app.config(function ($locationProvider, $routeProvider) {
    $locationProvider.html5Mode(true);
    $routeProvider
        .when('/',
            {
                templateUrl: 'templates/home.html'
        })
        .when('/books',
            {
                templateUrl: 'templates/book.html'
        })
        .when('/borrowers',
            {
                templateUrl: 'templates/borrower.html'
        })
        .when('/transactions',
            {
                templateUrl: 'templates/transaction.html'
            })
        .otherwise(
            {
                redirectTo: '/'
            });


});