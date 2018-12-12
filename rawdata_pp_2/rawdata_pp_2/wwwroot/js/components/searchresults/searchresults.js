define(['knockout', 'dataService', 'postman'], function (ko, ds, postman) {
    return function (params) {
        var searchResults = ko.observableArray([]);
        var searchExactResults = ko.observableArray([]);
        var selectedSeacheType = ko.observable(params.searchType);
        var searcString = ko.observable(params.searchText);
        //var searchExactString = ko.observable();
        //var searchBestString = ko.observable();

        if (params.searchText !== null && params.searchType !== null) {
            search;
        }

         var search = function () {
            switch (selectedSeacheType()) {
                case "exact":
                    ds.getExactMatch(searcString(), function (data) {
                        searchExactResults(data);
                        console.log("exact");
                    });break;

                case "best":
                    ds.getBestMatch(searcString(), function (data) {
                        searchResults(data);
                        console.log("best");
                    });
                        break;

                case "weight":
                    ds.getWeightSearch(searcString(), function (data) {
                        searchResults(data);
                        console.log("weight");
                    });break;
            }
        }
        var weight = function () {
            ds.getWeightSearch(searcString(), function (data) {
                searchResults(data);
                console.log("weight");
            });
        }
        var exact = function () {
            ds.getExactMatch(searcString(), function (data) {
                searchExactResults(data);
                console.log("exact");
            });
        }
        var best = function () {
            ds.getBestMatch(searcString(), function (data) {
                searchResults(data);
                console.log("best");
            });
        }

        var navigateToPost = function (post) {
            postman.publish("showPost", { menu: "post", url: post.url, searchText: searcString(), searchType: selectedSeacheType() });
        };


        return {
            /*weight*/
            searchResults,
            searchExactResults,
            //exact,
            //best,
            //searchWeightString,
            //searchExactString,
            //searchBestString,
            searcString,
            navigateToPost,
            selectedSeacheType,
            search
        };
    };
});
