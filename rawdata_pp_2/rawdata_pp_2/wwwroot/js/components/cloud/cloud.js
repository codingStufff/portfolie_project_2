define(['jquery', 'knockout', 'dataService', 'postman', 'jqcloud'], function ($, ko, ds, postman) {
    return function (params) {
        //var words1 = ko.observableArray([]);
        var words = ko.observableArray([
            { text: "c", weight: 13 },
            { text: "l", weight: 10.5 }]);
        var searchWord = ko.observable("java");



        // to be able to use a asynchronous functon call
        // we need to implement updates on the cloud, since
        // the data will first be available after the creation
        // of the cloud

        //ds.getCloud("java", function (data) {
        //    words(data);
        //});

        var getWords = function () {
            ds.getCloud(searchWord(), function (data) {
                words(data.map(function (e) {
                    return {
                        text: e.word,
                        weight: e.weight
                    }
                }));
               
            });
        }

       

        return {
            getWords,
            searchWord,
            words,
            
        };

    };
});