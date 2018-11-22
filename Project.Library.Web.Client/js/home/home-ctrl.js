homeModule.controller('homeController', ['$scope', 'homeFactory', function ($scope, homeFactory) {
    var self = $scope;
    self.title = 'This is from the home';
    self.columns = [1, 2, 3, 4, 5, 6, 7, 9, 10, 11, 12];
    self.columns2 = [1, 2, 3, 4, 5, 6];
    self.columns3 = [1, 2, 3, 4];
    self.columns4 = [1, 2, 3];
    self.columns6 = [1, 2];
    console.log('Working home controller');
}]);