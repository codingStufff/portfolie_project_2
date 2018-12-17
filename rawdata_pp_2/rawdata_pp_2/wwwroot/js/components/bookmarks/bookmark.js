define(['knockout', 'dataService', 'postman', 'jqcloud'], function (ko, ds, postman) {
    return function (params) {
        var bookmarks = ko.observableArray([]);
        var userId = 18;

        ds.getBookmarks(userId, function (data) {
            bookmarks(data);
        });

        return {
            bookmarks
        };

    };
});
