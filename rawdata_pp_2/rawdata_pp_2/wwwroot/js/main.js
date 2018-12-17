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

// custom bindings
    require(['jquery', 'knockout', 'jqcloud'], function ($, ko) {
        ko.bindingHandlers.cloud = {
            init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
                // This will be called when the binding is first applied to an element
                // Set up any initial state, event handlers, etc. here

                // we need to react to changes in the viewModel, so we need to subscribe to the words
                // and react if the array is changed.
                var cloud = allBindings.get('cloud');
                var words = cloud.words;

                // if we have words that is observables
                if (words && ko.isObservable(words)) {
                    // then subscribe and update the cloud on changes
                    words.subscribe(function () {
                        $(element).jQCloud('update', ko.unwrap(words));
                    });
                }

            },
            update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
                // This will be called once when the binding is first applied to an element,
                // and again whenever any observables/computeds that are accessed change
                // Update the DOM element based on the supplied values here.

                // we need to get the words from the bindings.
                // The allBindings parameter is an object with all the bindings
                // and we can get the 'cloud' binding 
                var cloud = allBindings.get('cloud');

                // from the cloud binding we want the array of words
                // we do not know wether this is an observable or not 
                // so the unwrap function is used to remove the observables if any
                // if words if not defined assign an empty array
                var words = ko.unwrap(cloud.words) || [];
                var width = cloud.width || 300;
                var height = cloud.height || 200;

                // to show the cloud we call the jqcloud function
                $(element).jQCloud(words, {
                    width: width,
                    height: height
                });
            }
        };
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

    ko.components.register("cloud", {
        viewModel: { require: 'components/cloud/cloud' },
        template: { require: 'text!components/cloud/cloudView.html' }
    })
    ko.components.register("savedPosts", {
        viewModel: { require: 'components/bookmarks/bookmark' },
        template: { require: 'text!components/bookmarks/bookmarkView.html' }
    })
        
});


// start application
require(['knockout', 'app', 'jqcloud'], function (ko, app) {

    ko.applyBindings(app);
});