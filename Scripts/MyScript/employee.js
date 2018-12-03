
function subNav(e, folder_id, emp_no) {
    let removeActive = document.querySelectorAll('.sub-nav-link');
    let btnUpload = document.querySelector('.upload-link');
    let btnUpload2 = document.querySelector('.upload-link2');
    
    // removeActive.prototype.forEach(function (al) {
    // })
    
    Array.prototype.forEach.call(removeActive, function (al) {
        al.classList.remove('active');
    });
    
    e.target.classList.add('active');
    
    btnUpload.href = '/File/New_Record?folder_id=' + folder_id + '&search=' + emp_no;
    btnUpload2.href = '/File/New_Record?folder_id=' + folder_id + '&search=' + emp_no;
    
    $.get('/Employee/Employee_Records', {
        folder_id : folder_id,
        EmpNo : emp_no
    }, function (data) {
        document.querySelector('.profile__content').innerHTML = data;
    });
}