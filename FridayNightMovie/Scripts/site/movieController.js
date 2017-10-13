(function () {
    'use strict';

    angular.module(APPNAME).controller('movieCtrl', MovieCtrl);

    MovieCtrl.$inject = ['movieService', '$scope', '$location', '$window', '$uibModal'];

    function MovieCtrl(movieService, $scope, $location, $window, $uibModal) {
        var vm = this;

        vm.movieService = movieService;
        vm.$scope = $scope;
        vm.$location = $location;
        vm.$window = $window;
        vm.$uibModal = $uibModal;

        vm.randomMovie = _randomMovie;
        vm.getMovie = _getMovie;

        vm.movieList = "Friday Night Movie";

        function _getMovie() {
            console.log("fuck you cunt");
            _randomMovie();
        }

        //once genre selection is introduced, I will need to add a parameter into the function, quite possibly a number pertaining to that particular 
        //genre. Should be cake.
        function _randomMovie() {
            return vm.movieService.getRandom().then(function (data) {
                console.log(data);
                vm.movieList = data.Title;
            })
        }
    }


})();