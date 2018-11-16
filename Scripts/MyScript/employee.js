loadEmployeeDetails = () => {
    document.querySelector('.fa-address-card').parentElement.classList.add('active-nav');
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
        document.querySelector('.profile__content').innerHTML = data;
    });
}