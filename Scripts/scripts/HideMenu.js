var menu = document.querySelector('.menu')
var BoxNavAll = document.querySelectorAll('.menu-mobile__box')
var boxLogin = document.querySelector('.vadition__box-tittle')
// menu luc dau co hide on form
// neu boxnavall co click -> hide on form co style display none 
function menuHide() {
    menu.style.display = 'none !important'
    menu.classList.add('active')
}
if (boxLogin.classList.contains('vadition__box-tittle')) {
    menuHide();
}
function add() {
    menu.classList.add('xxxx')
}
for (var i = 0; i < BoxNavAll; i++) {
    if (BoxNavAll[i].addEventListener('click', add)) {

    }
}