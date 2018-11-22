homeModule.controller('homeController', ['$scope', 'homeFactory', function ($scope, homeFactory) {
    $scope.title = 'This is from the home controller';
    console.log('Working home controller');
}]);