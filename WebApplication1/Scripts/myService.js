app.service('myService', function ($http) {
    var apiRoute = '/api/Student';

    this.post = function (Model) {
        var request = $http({
            method: "post",
            url: apiRoute,
            data: Model
        });
        return request;
    }

    this.put = function (Model) {
        var request = $http({
            method: "put",
            url: apiRoute,
            data: Model
        });
        return request;
    }

    this.delete = function (sID) {
        alert('DEBUG: ' + apiRoute + '/' + sID);
        var request = $http({
            method: "delete",
            url: apiRoute + '/' + sID
        });
        return request;
    }

    this.get = function () {
        return $http.get(apiRoute);
    }

    this.getbyID = function (sID) {
        //urlGet = apiRoute + '/' + studentID;
        return $http.get(apiRoute + '/' + sID);
    }
}); 