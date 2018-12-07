define(['knockout', /*'dataService',*/ 'postman'], function (ko, /*ds,*/ postman) {
    return function () {
        var username = ko.observable();
        var password = ko.observable();

        var test = function () {
            console.log('hej');
        };


        return{
            test
        };

    };
});