define(['knockout', /*'dataService',*/ 'postman'], function (ko, /*ds,*/ postman) {
    return function (params) 
    {
        var username = ko.observable();
        var password = ko.observable();
        var errorMsg = ko.observable();

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

        var login = function () 
        {
            console.log(username()+' '+password());

        };

        var goToLogin = function () {
            postman.publish("changeMenu", "login");
        };

        return {
            doLogin,
            username,
            password,
            errorMsg, 
            goToLogin
        };

    };
});
