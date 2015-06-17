
var app = angular.module("myapp", ['ngRoute']);


app.config(function ($routeProvider) {

    $routeProvider
    .when('/about',{
        templateUrl: '/App/about.html',
        controller : 'aboutController'
    })

  //  $locationProvider.html5Mode(false).hashPrefix('!');
});

app.controller("homeController", function ($scope) {

    $scope.title = "Hello im from controller";

});


app.controller("aboutController", function ($scope) {

    $scope.title = "im about controller from angular";
});