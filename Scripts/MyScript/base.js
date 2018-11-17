modify_DOM_on_page_load = () => {
    let current_page = location.href;
    let btnSearch = document.querySelector('#btnSearch');
    let formSearchBox = document.querySelector('#searchBox');
    
    if(current_page.includes("New_Record")) {
        btnSearch.type = "submit";
    }

    if(current_page.includes("Employee/Index") || current_page.includes("/Employee")) {
        btnSearch.type = "submit";

        formSearchBox.action = "/Employee/Index";
        formSearchBox.method = "GET";
    }
}

modify_DOM_on_page_load();