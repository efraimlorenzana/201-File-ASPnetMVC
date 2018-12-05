function modify_DOM_on_page_load(){
    var current_page = location.href;
    var btnSearch = document.querySelector('#btnSearch');
    var formSearchBox = document.querySelector('#searchBox');
    
    if(current_page.indexOf("New_Record")) {
        btnSearch.type = "submit";
    }
    
    if(current_page.indexOf("Employee/Index") || current_page.indexOf("/Employee")) {
        btnSearch.type = "submit";
        
        formSearchBox.action = "/Employee/Index";
        formSearchBox.method = "GET";
    }
}

function homeNavLink() {
    Array.prototype.forEach.call(document.querySelectorAll('.homeNavLink'),
    function (link) {
        link.classList.add('active-nav');
    });
}

function fileNavLink() {
    Array.prototype.forEach.call(document.querySelectorAll('.fileNavLink'),
    function (link) {
        link.classList.add('active-nav');
    });
}

function employeeNavLink() {
    Array.prototype.forEach.call(document.querySelectorAll('.employeeNavLink'),
    function (link) {
        link.classList.add('active-nav');
    });
}

function pageLoaded() {
    document.querySelector('.loading').classList.add('loading-hide');
}