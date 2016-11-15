(function () {
    var app = angular.module("githubViewer", []);
    var MainController = function ($scope, github, $interval, $log, $anchorScroll, $location) {

        //var onUserComplete = function (response) {
        var onUserComplete = function (data) {
            $scope.user = data;
            github.getRepos($scope.user).then(onRepos, onError);
            //$http.get($scope.user.repos_url)
        }

        var onRepos = function (data) {
            alert(data);
            $scope.repos = data;
            $location.hash("userDetails");
            $anchorScroll();
        }

        var onError = function (reason) {
            $scope.error = "Could not fetch user";
        }

        $scope.search = function (username) {
            $log.info("Searching for " + username);

            //$http.get("https://api.github.com/users/" + username)
            github.getUser(username).then(onUserComplete, onError);

            if (countdownInterval) {
                $interval.cancel(countdownInterval);
                $scope.countdown = null;


            }
        };

        var decrementCountdown = function () {
            $scope.countdown -= 1;
            if ($scope.countdown < 1) {
                $scope.search($scope.username);
            }


        }

        var countdownInterval = null;
        var startCountdown = function () {
            countdownInterval = $interval(decrementCountdown, 1000, $scope.countdown);
        }

        $scope.username = "angular";
        $scope.message = "GitHub Viewer";
        $scope.repoSortOrder = "-stargazers_count";
        $scope.countdown = 5;
        startCountdown();
    }

    app.controller("MainController", MainController);
    //hunnit i videon till filters..
    //["$scope", "$http", "$interval", "$log", MainController]
}());

/*var myAppModule = angular.module('myApp', []);
myAppModule.controller('ExampleController', function ($scope) {
    $scope.name = "Alex Pop";
    $scope.previousName = "";
    $scope.onNameFocused = function () {
        $scope.previousName = $scope.name;
    };
});*/
