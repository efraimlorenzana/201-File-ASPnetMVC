include = (id, e) => {
    
    $.post('/Setting/toggle_extension', {
        isChecked : e.target.checked,
        ext_id : id
    }, data => {
        console.log(data);
    })
}

subNav = (e) => {
    let removeActive = document.querySelectorAll('.sub-nav-link');

    removeActive.forEach(al => {
        al.classList.remove('active');
    })

    e.target.classList.add('active');
}