function previewZoom(zoom){
    var img_files = document.querySelectorAll('.file-view__preview');
    
    Array.prototype.forEach.call(img_files, function (img) {
        var img_w = img.width;
        var new_w = 0;
        
        if(zoom)
            new_w = img_w + 10;
        else
            new_w = img_w - 10;
        
        img.style.width = new_w + 'px';
    });
}