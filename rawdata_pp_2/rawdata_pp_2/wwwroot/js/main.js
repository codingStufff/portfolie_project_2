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

    ko.components.register("home", {
        viewModel: {require: 'components/Home/home'},
        template: {require: 'text!components/Home/home.html'}
    });

    ko.components.register("searchResults", {
        viewModel: { require: 'components/searchresults/searchresults' },
        template: { require: 'text!components/searchresults/searchresultsView.html'}
    });

    ko.components.register("post", {
        viewModel: { require: 'components/Post/post' },
        template: { require: 'text!components/Post/postView.html'}
        });

    ko.components.register("regUser", {
        viewModel: {require: 'components/regUser/regUser'},
        template: {require: 'text!components/regUser/regUser.html'}
    })
        
});


// start application
require(['knockout', 'app'], function (ko, app) {

    ko.applyBindings(app);
});