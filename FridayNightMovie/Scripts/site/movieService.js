(function () {

    'use strict';

    angular.module(APPNAME).factory('movieService', MovieService);

    MovieService.$inject = ['$http', '$q'];

    function MovieService($http, $q) {

        var srv = {
            getAll: _getAll,
            getRandom: _getRandom,
            getById: _getById,
            post: _post,
            put: _put,
            deleteById: _deleteById
        };

        return srv;

        function _getAll() {
            return $http.get("/api/movies")
                .then(getAllSuccess)
                .catch(getAllFailure)

            function getAllSuccess(response) {
                return response;
            }

            function getAllFailure(response) {
                return $q.reject(response);
            }
        }

        function _getRandom() {
            return $http.get("/api/movies/random")
                .then(getRandomSuccess)
                .catch(getRandomFailure)

            function getRandomSuccess(response) {
                return response.data[0];
            }

            function getRandomFailure(response) {
                return $q.reject(response);
            }
        }

        function _getById(id) {
            return $http.get("/api/movies/" + id)
                .then(getByIdSuccess)
                .catch(getByIdFailure)

            function getByIdSuccess(response) {
                return response;
            }

            function getByIdFailure(response) {
                return $q.reject(response);
            }
        }

        function _post(data) {
            return $http.post("/api/movies", data)
                .then(postSuccess)
                .catch(postFailure)

            function postSuccess(response) {
                return response;
            }

            function postFailure(response) {
                return $q.reject(response);
            }
        }

        function _put(id, data) {
            return $http.put("/api/movies/" + id, data)
                .then(putSuccess)
                .catch(putFailure)

            function putSuccess(response) {
                return response;
            }

            function putFailure(response) {
                return $q.reject(response);
            }
        }

        function _deleteById(id) {
            return $http.delete("/api/movies/" + id)
                .then(deleteSuccess)
                .catch(deleteError)

            function deleteSuccess(response) {
                return response;
            }

            function deleteError(response) {
                return $q.reject(response);
            }
        }
    }

})();