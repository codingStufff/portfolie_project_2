define(['knockout', /*'dataService',*/ 'postman'], function (ko, /*ds,*/ postman) {
    return function (params) 
    {
        var username = ko.observable();
        var password = ko.observable();

        var login = function () 
        {
            console.log(username()+' '+password());

        };

         var goToLogin = function() {
            postman.publish("changeMenu", "login");
        };


        return{
            login,
            username,
            password,
            goToLogin

        };

    };
});
