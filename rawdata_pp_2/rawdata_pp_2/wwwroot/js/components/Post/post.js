define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        var post = ko.observable();
        var searchText = params.searchText;
        var searchType = params.searchType;


        ds.getPost(params.url, function (data) {
                post(data);
        });

        var back = function () {
            postman.publish("search", { searchText, searchType });
        };

        return {
            post,
            back
        };

    };
});