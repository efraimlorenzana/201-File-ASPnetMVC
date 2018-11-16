﻿toggleUpload = () => {
    let btnSearch = document.querySelector('#btnSearch');
    btnSearch.type = "submit";
}

showSuggestion = (e) => {
    let suggestion = document.querySelector('.search__suggestion');
    let txtSearch = document.querySelector('.search__bar--text');
    let list = "";
    let arr_list = [];
    
    if(txtSearch.value.length >= 3) {
        suggestion.hidden = false;
    }
    
    txtSearch.onblur = () => {
        suggestion.hidden = true;
    }
    
    $.get('/Employee/autocomplete', {
        term : e.target.value
    }, data => {
        data.forEach(item => {
            if(!NameExist(item)) {
                list = list + `<li class="search__suggestion--item"
                                    onmousedown="returnToSearch(event)">
                                    ${item}
                               </li>`
                arr_list.push(item);
            }
        });
        
        document.querySelector('.search__suggestion--list').innerHTML = list;
        document.querySelector('.search__suggestion').style.overflowY = "scroll";
    });
    
    NameExist = (name) => {
        let isExist = false;
        arr_list.forEach(arr_data => {
            if(arr_data == name)
                isExist = true;
        });

        return isExist;
    }

    returnToSearch = (e) => {
        let txtSearch = document.querySelector('.search__bar--text');

        txtSearch.value = e.target.textContent.trim();

        txtSearch.focus();
    }
}