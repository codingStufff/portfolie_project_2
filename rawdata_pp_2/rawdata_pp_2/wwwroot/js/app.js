define(['knockout', 'postman','dataService'], function (ko, postman, ds) {
   //var title = "Group11";
   // var currentView = ko.observable("home");
    var currentParams = ko.observable({ test: ''});
    //var loginView = ko.observable("login");
    var loggedIn = true;
    if (loggedIn === false) {
        var menuItems = [
            //{ name: 'Home', component: 'home' },
            { name: 'Login', component: 'login' },
            { name: 'Search', component: 'searchResults' },
            { name: 'cloud', component: 'cloud' }
        ];
    }
    else {
        var menuItems = [
            //{ name: 'Home', component: 'home' },
            { name: 'Logout', component: 'logout' },
            { name: 'Saved Posts', component: 'savedPosts' },
            { name: 'Search History', component: 'search history' },
            { name: 'Search', component: 'searchResults' },
            { name: 'cloud', component: 'cloud' }
            
        ];
    }
 
    

    var selectedMenu = ko.observable(menuItems[0]);
    var selectedComponent = ko.observable("home");

    var changeMenu = function(menu) {
        selectedMenu(menu);
        selectedComponent(menu.component);
    }


    postman.subscribe("changeMenu", function(menuName) {
        var menu = menuItems.find(function(m) {
            return m.name === menuName;
        });
        if (menu) changeMenu(menu);
    });

    postman.subscribe("showPost", function (data) {
        
        currentParams(data);
        selectedComponent("post");
       
    });

    postman.subscribe("showRegister", function(){
        selectedComponent("regUser");
    });

    postman.subscribe("search", function (data) {

        currentParams(data);
        var menu = menuItems.find(function (m) {
            return m.name === "Search";
        });
        if (menu) changeMenu(menu);

    });
    //postman.subscribe("work", function () {
    //    menuItems = [
    //        //{ name: 'Home', component: 'home' },
    //        { name: 'Logout', component: 'logout' },
    //        { name: 'Saved Posts', component: 'savedPosts' },
    //        { name: 'Search History', component: 'search history' },
    //        { name: 'Search', component: 'searchResults' },
    //        { name: 'cloud', component: 'cloud' }

    //    ];
    //    changeMenu(menuItems[1]);
    //});

    

    



    return {
      // title,
     // currentView,
      currentParams,
        menuItems,
      changeMenu,
      selectedComponent
    };
});

   // var changeView = function (){
     //   if(currentView() === "home"){
    //    console.log('click');

  //      currentView("login");
 //   };
//};