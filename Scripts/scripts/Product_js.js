var icon = document.querySelector('.content-wishlist__icon');
function fillicon() {
    icon.classList.add('filled');
}
icon.addEventListener('click', fillicon)


function loadPartialView(partialViewName, container) {
    // Sử dụng AJAX để tải PartialView và hiển thị nó trong container
    $.get('@Url.Action("Product_Index_Main__Agothims")', function (data) {
        container.innerHTML = data;
    });
}