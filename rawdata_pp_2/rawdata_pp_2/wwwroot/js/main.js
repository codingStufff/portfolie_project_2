// configure requirejs
require.config({
    baseUrl: 'js',
    paths: {
        knockout: 'lib/knockout/dist/knockout',
        jquery: 'lib/jquery/dist/jquery.min',
        text: 'lib/text/text',
        jqcloud: 'lib/jqcloud2/dist/jqcloud',
        dataService: 'services/dataService',
        postman: 'services/postman'
    },
    shim: {
        // set default deps
        'jqcloud': ['jquery']
    }
});


// start application
require(['knockout', 'app', 'jqcloud'], function (ko, app) {
    ko.applyBindings(app);
});