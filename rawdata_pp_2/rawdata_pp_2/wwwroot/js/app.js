define(['knockout'], function (ko) {
   //var title = "Group11";
    var currentView = ko.observable("home");
var currentParams = ko.observable({ test: 'ffsfs'});
   //var loginView = ko.observable("login");

    var changeView = function (){
        if(currentView() === "home"){
        console.log('click');
        currentParams({test: 'eqweqweq'});
        currentView("login");
    };
};

    return {
      // title,
      currentView,
        currentParams,
      changeView
    };
   });