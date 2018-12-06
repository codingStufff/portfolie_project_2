define([], function () {
    var subscribers = [];
    var debug = true;
    var subscribe = function (event, callback) {
        var subscriber = { event, callback };
        if (debug) console.log("subscribe: " + JSON.stringify(subscriber));

        subscribers.push(subscriber);

        // return unsubscribe function
        return function () {
            subscribers = subscribers.filter(function (e) {
                return e !== subscriber;
            });
        };
    };

    var publish = function (event, data) {
        if (debug) console.log("publish: " + JSON.stringify({ event, data }));
        subscribers.forEach(function (s) {
            if (event === s.event) s.callback(data);
        });
    };

    return {
        subscribe,
        publish
    };
});