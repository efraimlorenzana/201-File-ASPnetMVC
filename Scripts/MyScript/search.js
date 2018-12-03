let suggestion = document.querySelector('.search__suggestion');

function toggleUpload(){
    let btnSearch = document.querySelector('#btnSearch');
    btnSearch.type = "submit";
}

function showSuggestion(e){
    var suggestion = document.querySelector('.search__suggestion');
    var txtSearch = document.querySelector('.search__bar--text');
    var list = "";
    var arr_list = [];
    
    if(txtSearch.value.length >= 3) {
        suggestion.hidden = false;
    }

    $.get('/Employee/autocomplete', {
        term : e.target.value
    }, function (data) {
        
        console.log(data);
        Array.prototype.forEach.call(data, function (item) {
            if(!NameExist(item)) {
                list = list + '<li class="search__suggestion--item" onclick="returnToSearch(event)">'
                + item +
                '</li>'
                arr_list.push(item);
            }
        });
        
        document.querySelector('.search__suggestion--list').innerHTML = list;
        document.querySelector('.search__suggestion').style.overflowY = "scroll";
    });
    
    function NameExist(name){
        let isExist = false;

        Array.prototype.forEach.call(arr_list, function (arr_data) {
            if(arr_data == name)
            isExist = true;
        });
        
        return isExist;
    }
    
    txtSearch.onblur = function () {
        setTimeout(function () {
            suggestion.hidden = true;
        }, 500);
    }
}

function returnToSearch(e) {
    var txtSearch = document.querySelector('.search__bar--text');

    txtSearch.value = e.target.textContent.trim();

    // txtSearch.focus();
    focusMethod();
}

focusMethod = function getFocus() {           
    document.querySelector('.search__bar--text').focus();
    suggestion.hidden = true;
}