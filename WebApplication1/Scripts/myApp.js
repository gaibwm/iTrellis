//import { data } from "jquery";

var app = angular.module("myApp", []);

//app.controller("myCtrl", function ($scope) {
//    $scope.firstName = "John";
//    $scope.balance = "1500.00";
//});


app.controller('StudentCtrl', ['$scope', 'myService',
    function ($scope, myService) {
        //$scope.blnText = "Save";
        $scope.StudentID = "";
        getAll();
        
        function getAll() {
            var servCall = myService.get();
            servCall.then(function (d) {
                $scope.students = d.data;
            }, function (error) {
                alert('Oops! Something went wrong while fetching the data.')
            });
        }

        $scope.FillTable = function (dataModel) {           
            $scope.studentID = dataModel.StudentID;
            $scope.firstName = dataModel.FirstName;
            $scope.lastName = dataModel.LastName;
            $scope.email = dataModel.Email;
            $scope.address = dataModel.Address;
        }

        $scope.DeleteStudent = function (dataModel) {
            var result = myService.delete(dataModel.StudentID);
            result.then(function (response) {
                if (response.data != "") {
                    alert("Data Delete Successfully");
                    getAll();
                    $scope.Clear();
                } else {
                    alert("Some error");
                }
            }, function (error) {
                console.log("Error: " + error);
            });  

        }

        $scope.SaveUpdate = function () {
            var student = {
                FirstName: $scope.firstName,
                LastName: $scope.lastName,
                Email: $scope.email,
                Address: $scope.address,
                StudentID: $scope.studentID
            }

            if ($scope.studentID == "") {
                var result = myService.post(student);
                result.then(function (response) {
                    if (response.data != "") {
                        getAll();
                        alert("Data Save Successfully");
                        $scope.Clear();
                    } else {
                        alert("Some error");
                    }
                }, function (error) {
                    console.log("Error: " + error);
                });
            }
            else
            {
                alert("update Record");
                var result = myService.put(student);
                result.then(function (response) {
                    if (response.data != "") {
                        getAll();
                        alert("Data Update Successfully");
                        $scope.Clear();
                    } else {
                        alert("Some error");
                    }
                }, function (error) {
                    console.log("Error: " + error);
                });  
            }
        }

        $scope.Clear = function () {
            $scope.studentID = "";
            $scope.firstName = "";
            $scope.lastName = "";
            $scope.email = "";
            $scope.address = "";
        }
    }
]);
