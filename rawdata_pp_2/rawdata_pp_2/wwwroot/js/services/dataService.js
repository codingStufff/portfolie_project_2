define(['jquery'], function ($) {
     var sendLoginCredentials = function (loginData, callback, errorCallback) {
        $.ajax({
            method: "POST",
            url: "api/users/login",
            data: loginData,
            contentType:'application/json',
            dataType: 'json',
            success: function (returnData) {
                callback(returnData);
                console.log("response from server" + returnData);
            },
            error: errorCallback
        });
    };
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

    var getPost = function (query, callback) {
        $.getJSON(query, function (data) {
            callback(data);
        });
    } 

    return {
        sendLoginCredentials,
        getWeightSearch,
        getExactMatch,
        getBestMatch,
        getPost
    };
});