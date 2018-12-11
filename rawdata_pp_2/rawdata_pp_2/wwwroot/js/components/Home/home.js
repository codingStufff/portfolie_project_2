define(['knockout', /*'dataService',*/ 'postman'], function (ko, /*ds,*/ postman) {
    return function (params) 
    {


        var test = function () 
        {
            console.log('hej');
        };

         var goToHome = function() {
            postman.publish("changeMenu", "home");
        };

    var changeMenu = function() {
            postman.publish("changeMenu", "Login");
        };

        return{
            test,
            goToHome,
changeMenu
        };

    };
});
