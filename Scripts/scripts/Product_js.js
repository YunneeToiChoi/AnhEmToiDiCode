var icon = document.querySelector('.content-wishlist__icon');
function fillicon() {
    icon.classList.add('filled');
}
icon.addEventListener('click', fillicon)
document.addEventListener('DOMContentLoaded', function () {
    var checkbox = document.getElementById('checkboxInput');
    var item = document.querySelector('.oo'); // su kien mac dinh
    var items = document.querySelector('.ee') // su kien texas
    if (checkbox) { // true
        checkbox.addEventListener('change', function () {
            if (checkbox.checked) {
                // Checkbox đã được chọn
                console.log('Checkbox is checked'); // >> thue
                //loadPartialView(partialViewName, partialViewContainer);
                // action to product Ago

                //item.classList.add('anoo');
                //items.classList.add('hienee');
                item.style.display = "none";
                items.style.display = "block";
            } else { // false
                // Checkbox đã bị bỏ chọn
                console.log('Checkbox is unchecked'); // bth
                // action to product index
                //item.classList.remove('anoo');
                //items.classList.remove('hienee');
                item.style.cssText = "block !important";
                items.style.cssText = "none !important";

            }
        });
    }
});


function loadPartialView(partialViewName, container) {
    // Sử dụng AJAX để tải PartialView và hiển thị nó trong container
    $.get('@Url.Action("Product_Index_Main__Agothims")', function (data) {
        container.innerHTML = data;
    });
}