<<<<<<< HEAD
﻿define(['knockout', 'dataService'], function (ko, ds) {
    return function () {
=======
﻿define(['knockout', /*'dataService',*/ 'postman'], function (ko, /*ds,*/ postman) {
    return function (params) 
    {
>>>>>>> f2771f542131f92ed5671abfdfe1a8964e97de46
        var username = ko.observable();
        var password = ko.observable();
        var errorMsg = ko.observable();

<<<<<<< HEAD
        var doLogin = function () {
            errorMsg("");
            var loginInfo = { "userName": username(), "userPassword": password() };
            ds.sendLoginCredentials(
                JSON.stringify(loginInfo),
                function (data) {
                    
                },
                function () {
                    errorMsg("Wrong username or password");
                });
        }
=======
        var login = function () 
        {
            console.log(username()+' '+password());

        };

         var goToLogin = function() {
            postman.publish("changeMenu", "login");
        };
>>>>>>> f2771f542131f92ed5671abfdfe1a8964e97de46

        var goToLogin = function () {
            postman.publish("changeMenu", "login");
        };

<<<<<<< HEAD
        return {
            doLogin,
            username,
            password,
            errorMsg, 
            goToLogin
=======
        return{
            login,
            username,
            password,
            goToLogin

>>>>>>> f2771f542131f92ed5671abfdfe1a8964e97de46
        };

    };
});
