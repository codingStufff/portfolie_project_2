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


//register Components
require(['knockout'], function (ko){

    ko.components.register("login",{
        viewModel: {require: 'components/login/login'}, 
        template: {require: 'text!components/login/loginView.html'} 
        });
});


// start application
require(['knockout', 'app'], function (ko, app) {

    ko.applyBindings(app);
});