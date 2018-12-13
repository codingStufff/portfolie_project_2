define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) 
    {
        var userName = ko.observable();
        var regPassword = ko.observable();
        var age = ko.observable();
        var displayName = ko.observable();
        var location = ko.observable();


    
var register = function(){
};


         return {
             userName,
             regPassword,
             age,
             displayName,
             location,
             register
            };
    };

});