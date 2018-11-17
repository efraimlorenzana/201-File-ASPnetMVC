previewZoom = (zoom) => {
    let img_files = document.querySelectorAll('.file-view__preview');
    
    img_files.forEach(img => {
        let img_w = img.width;
        let new_w = 0;
        
        if(zoom)
            new_w = img_w + 10;
        else
            new_w = img_w - 10;
        
        img.style.width = `${new_w}px`;
    });
}