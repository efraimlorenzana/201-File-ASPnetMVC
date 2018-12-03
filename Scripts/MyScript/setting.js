function include (id, e) {
    
    $.post('/Setting/toggle_extension', {
        isChecked : e.target.checked,
        ext_id : id
    }, function (data) {
        console.log(data);
    })
}