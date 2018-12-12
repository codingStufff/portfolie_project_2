define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        var searchResults = ko.observableArray([]);

        var test = function () {
            ds.getSearch(function (data) {
                searchResults(data);
                console.log(data);
            });
        }
        return {
            test,
            searchResults
        };
    };
});
