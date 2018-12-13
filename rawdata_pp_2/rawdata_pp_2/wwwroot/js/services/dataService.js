﻿define(['jquery'], function ($) {
    var loginUser = function (loginData) {
        callServer("Post", "api/users/login", loginData);
    };
    var registerUser = function (registerData) {
        callServer("Post", "api/users/register", registerData);
    };
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
        loginUser,
        registerUser,
        getWeightSearch,
        getExactMatch,
        getBestMatch,
        getPost,
        callServer
    };
});