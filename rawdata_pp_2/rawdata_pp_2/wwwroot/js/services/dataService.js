define(['jquery'], function ($) {

    var loginUser = function (loginData, callback, errorCallback) {
        callServer("Post", "api/users/login", loginData, callback, errorCallback);
    };
    var registerUser = function (registerData, callback, errorCallback) {
        callServer("Post", "api/users/register", registerData, callback, errorCallback);
    };
    var createBookmark = function (bookmarkInfo) {
        callServer("Post", "api/posts/bookmark", bookmarkInfo);
    };
    // creating the object to send to database
    var callServer = function (httpMethod, url, dataSet, callback, errorCallback ) {
        $.ajax({
            method: httpMethod,
            url: url,
            data: dataSet,
            contentType: 'application/json',
            dataType: 'json',
            success: function (returnData) {
                callback(returnData);
                console.log("response from server" + returnData);
            },
            error: errorCallback
        });
       
    }
    // get functions
    var getWeightSearch = function (query, callback) {
        $.getJSON("api/posts/weightedSearch/" + query, function (data) {
            callback(data);
        });
    }
    var getExactMatch = function (query, callback) {
        $.getJSON("api/posts/exactMatch/" + query, function (data) {
            callback(data);
        });
    }
    var getBestMatch = function (query, callback) {
        $.getJSON("api/posts/bestMatch/" + query, function (data) {
            callback(data);
        });
    }

    var getNextPage = function (query, callback) {
        $.getJSON(query, function (data) {
            callback(data);
        });
    }

    var getPreviousPage = function (query, callback) {
        $.getJSON(query, function (data) {
            callback(data);
        });
    }

    var getPost = function (query, callback) {
        $.getJSON(query, function (data) {
            callback(data);
        });
    } 

    var getCloud = function (query, callback) {
        $.getJSON("api/posts/wordcloud/" + query, function (data) {
            callback(data);
        });
    }

    var getBookmarks = function (query, callback) {
        $.getJSON("api/posts/userbookmarks/" + query, function (data) {
            callback(data);
        });
    }

    

    return {
        loginUser,
        registerUser,
        getWeightSearch,
        getExactMatch,
        getBestMatch,
        getPost,
        callServer,
        getNextPage,
        getPreviousPage,
        getCloud,
        createBookmark,
        getBookmarks

    };
});