define(['knockout', 'postman','dataService'], function (ko, postman, ds) {
   //var title = "Group11";
   // var currentView = ko.observable("home");
    var currentParams = ko.observable({ test: 'ffsfs'});
    //var loginView = ko.observable("login");



    var menuItems = [
        { name: 'Home', component: 'home' },
        { name: 'Login', component: 'login' },
        { name: 'SearchResults', component: 'searchResults'}
        ];

    var selectedMenu = ko.observable(menuItems[0]);
    var selectedComponent = ko.observable("searchResults");

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