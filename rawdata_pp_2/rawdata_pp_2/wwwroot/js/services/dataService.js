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

    return {
        sendLoginCredentials
    };
});