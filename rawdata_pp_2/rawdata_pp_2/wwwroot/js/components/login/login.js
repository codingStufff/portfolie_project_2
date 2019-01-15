define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) 
    {
        var username = ko.observable();
        var password = ko.observable();
        var errorMsg = ko.observable();
        var goToReg = ko.observable();
        var userInfo = ko.observable();
        var loggedIn = ko.observable();

        var doLogin = function () {
            errorMsg("");

            var loginInfo = { "userName": username(), "userPassword": password() };

            ds.loginUser(
                JSON.stringify(loginInfo),
                function (data) {
                    userInfo(data);

                    postman.publish("work");
                },
                function () {
                    errorMsg("Wrong username or password");
                });
            
        }

        var login = function () 
        {
            
            console.log(username()+' '+password());

        };

        var goToReg = function () {
            postman.publish("showRegister")
        }

        var goToLogin = function () {
            postman.publish("changeMenu", "login");
        };

        //var loginSucces = function () {
        //    if (errorMsg != "Wrong username or password") {
        //        postman.publish("loginSucces");
        //    }
        //}

        return {
            doLogin,
            username,
            password,
            errorMsg, 
            goToLogin,
            goToReg,
            userInfo
        };

    };
});
