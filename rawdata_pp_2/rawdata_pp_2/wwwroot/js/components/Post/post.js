define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        var post = ko.observable();
        var searchText = params.searchText;
        var searchType = params.searchType;
        var annotationText = ko.observable();
        var userId = ko.observable(18);

        ds.getPost(params.url, function (data) {
                post(data);
        });

        var back = function () {
            postman.publish("search", { searchText, searchType });
        };

        var makeBookmark = function () {
            var bookmarkInfo = {
                URL: params.url, userid: userId(), annotation: annotationText()
            };
            ds.createBookmark(JSON.stringify(bookmarkInfo));
            console.log("bookmark made");
            
        }

        return {
            post,
            back,
            annotationText,
            makeBookmark,
            userId
           
        };

    };
});