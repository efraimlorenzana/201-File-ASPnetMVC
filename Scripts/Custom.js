include = (id, e) => {
    
    $.post('/Setting/toggle_extension', {
        isChecked : e.target.checked,
        ext_id : id
    }, data => {
        console.log(data);
    })
}

subNav = (e, folder_id, emp_no) => {
    let removeActive = document.querySelectorAll('.sub-nav-link');
    let btnUpload = document.querySelector('.upload-link');
    
    removeActive.forEach(al => {
        al.classList.remove('active');
    })
    
    e.target.classList.add('active');
    
    btnUpload.href = `/File/New_Record?folder_id=${folder_id}&search=${emp_no}`;
    
    $.get('/Employee/Employee_Records', {
        folder_id : folder_id,
        EmpNo : emp_no
    }, data => {
        console.log(data);
        document.querySelector('.profile__content').innerHTML = data;
    });
}

loadEmployeeDetails = () => {
    document.querySelector('.fa-address-card').parentElement.classList.add('active-nav');
}

toggleUpload = () => {
    let btnSearch = document.querySelector('#btnSearch');
    btnSearch.type = "submit";
}

showSuggestion = (e) => {
    let suggestion = document.querySelector('.search__suggestion');
    let txtSearch = document.querySelector('.search__bar--text');
    let list = "";
    let arr_list = [];
    
    if(txtSearch.value.length > 2) {
        suggestion.hidden = false;
    } else {
        suggestion.hidden = true;
    }
    
    txtSearch.onblur = () => {
        suggestion.hidden = true;
    }
    
    $.get('/Employee/autocomplete', {
        term : e.target.value
    }, data => {
        
        data.forEach(item => {
            if(!NameExist(item)) {
                list = list + `<li class="search__suggestion--item">${item}</li>`
                arr_list.push(item);
            }
        });
        
        document.querySelector('.search__suggestion--list').innerHTML = list;
    });
    
    NameExist = (name) => {
        let isExist = false;
        arr_list.forEach(arr_data => {
            if(arr_data == name)
                isExist = true;
        });

        return isExist;
    }
}

set_DOM_on_page_load = () => {
    let current_page = location.href;
    let btnSearch = document.querySelector('#btnSearch');
    
    if(current_page.includes("New_Record")) {
        btnSearch.type = "submit";
    }
}

set_DOM_on_page_load();