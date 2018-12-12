define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        var searchResults = ko.observableArray([]);
        var searchWeightString = ko.observable();
        var searchExactString = ko.observable();
        var searchBestString = ko.observable();

        var weight = function () {
            ds.getWeightSearch(searchWeightString(), function (data) {
                searchResults(data);
                console.log("weight");
            });
        }
        var exact = function () {
            ds.getExactMatch(searchExactString(), function (data) {
                searchResults(data);
                console.log("exact");
            })
        }
        var best = function () {
            ds.getBestMatch(searchBestString, function (data) {
                searchResults(data);
                console.log("best");
            });
        }
        return {
            weight,
            searchResults,
            exact,
            best,
            searchWeightString,
            searchExactString,
            searchBestString
        };
    };
});
