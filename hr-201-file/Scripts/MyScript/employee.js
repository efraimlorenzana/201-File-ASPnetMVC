﻿
var fieldValues = {};
fieldsCollector = {};

function subNav(e, folder_id, emp_no) {
    let removeActive = document.querySelectorAll('.sub-nav-link');
    // let btnUpload = document.querySelector('.upload-link');
    // let btnUpload2 = document.querySelector('.upload-link2');
    
    // removeActive.prototype.forEach(function (al) {
    // })
    
    Array.prototype.forEach.call(removeActive, function (al) {
        al.classList.remove('active');
    });
    
    e.target.classList.add('active');
    
    // btnUpload.href = '/File/New_Record?folder_id=' + folder_id + '&search=' + emp_no;
    // btnUpload2.href = '/File/New_Record?folder_id=' + folder_id + '&search=' + emp_no;
    
    $.get('/Employee/Employee_Records', {
        folder_id : folder_id,
        EmpNo : emp_no
    }, function (data) {
        document.querySelector('.profile__content').innerHTML = data;
        setTimeout(disableFormFields(true), 1000);
        formFieldsEvent();


        //attached event in save button
        Array.prototype.forEach.call(document.querySelectorAll('.employee__info--savechanges'), function (e) {
            e.addEventListener('click', function (event) {
                disableFormFields(true);

                fieldValues['EmpId'] =  e.dataset.empid;

                $.post('/Employee/UpdateEmployeeRecords', fieldValues, function (data) {
                    if(data != "false") {
                        window.location.assign("/Employee/Index?search=" + data);
                    } else {
                        disableFormFields(false);
                    }
                });
            });
        });
    });
}

function disableFormFields(choice) {
    var selector = "section.emp > div > div > .text-box," +
                    "section.emp > div > div > textarea," + 
                    "section.emp > div > div > select"

    var fields = $(selector);

    fields.each(function () {
        $(this).prop("disabled", choice);
    });

    $('#submitEmployeeDetails').prop('hidden', choice);
}

function accordionToggle(e) {
    var section = document.querySelector('[data-title="section-' + e.target.dataset.title + '"]');
    section.classList.toggle("expand");
}

function formFieldsEvent() {
    var selector = "section.emp > div > div > .text-box," +
                    "section.emp > div > div > textarea," + 
                    "section.emp > div > div > select"

    var fields = $(selector);

    fields.each(function () {
        $(this).on('change',function (e) {
            fieldValues[e.target.name] = e.target.value;
            // console.log(fieldValues);

            // getAllEmployeeDetails();
            // console.log(fieldValues);
        });
    });
}

// function getAllEmployeeDetails() {
//     var selector = "section.emp > div > div > .text-box"

//     var fields = $(selector);

//     fields.each(function (i,e) {
//         fieldValues[e.attributes.name.value] = e.attributes.value.value;
//     });
// }