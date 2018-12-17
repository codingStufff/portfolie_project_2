define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) 
    {
        var userName = ko.observable();
        var password = ko.observable();
        var age = ko.observable();
        var displayName = ko.observable();
        var location = ko.observable();
        var errorMsg = ko.observable();
    
        var doRegistration = function () {
            errorMsg("");
            var registrationInfo = {
                userPassword: password(), username: userName(), 
                age: age(), displayName: displayName(), userLocation: location()
            }; 
            ds.registerUser(
                JSON.stringify(registrationInfo),
                function (data) {
                    console.log("Welocome " + data.displayName + "!");
                    console.log("This is your personalized dashboard");
                }, 
                function (data) {
                    console.log("User registration unsuccessful" + data.responseText);
                    errorMsg("User registration unsuccessful");
                }
            );
        };

        return {
             userName,
             password,
             age,
             displayName,
             location,
            doRegistration, 
             errorMsg
        };
    };
});