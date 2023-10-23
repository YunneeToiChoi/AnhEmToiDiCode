var user = document.querySelector('.user-navbar__box')
var userParent = document.querySelector('.user-header__form--active-Parent')
var overplayUser = document.querySelector('.form-user--overplay')

function main() {
    openUserNav(); // mo user box nav
    remove(); // tat userboxnav
    openForm(); // mo form
    hideBoxNavForm(); // mo form xong tat nav user 
}
////////////////////////////   BEGIN On Off USERNAV     //////////////////////////
function openUserNav() { // mo nav
    user.addEventListener('click', openUserNav)
    userParent.classList.add('active')
}
user.addEventListener('click', openUserNav) // mo user box nav 
function remove() { // tat nav khi chua mo overplay/form
    userParent.classList.remove('active')
}
overplayUser.addEventListener('click', remove); // tat nav user o ngoai main
////////////////////////////  END On Off USERNAV     //////////////////////////

const registerNav = document.querySelector('.user-header__form--navRegister') // goi sign in
const loginNav = document.querySelector('.user-header__form--navLogin') //Bat form login nav
const ModalForm = document.querySelector('.form-vadition--modal') // goi form
const closeForm = ModalForm.querySelector('.vadition__header-icon') // goi dong form
const overPlayForm = ModalForm.querySelector('.form-vadition--overplay') // goi overplay



////////////////////////////////// BEGIN OPEN OFF form///////////////////////////

registerNav.addEventListener('click', () => { // mo form REGISTER
    ModalForm.classList.add('active') // nhan nav register >> mo form >> + active form register
    registerForm.classList.add('active')        // active form register
    hideBoxNavForm();
})
loginNav.addEventListener('click', () => { // mo form LOGIN
    ModalForm.classList.add('active') // nhan nav login >> mo form >> + active form login
    loginForm.classList.add('active')        // active form register
    hideBoxNavForm();
})

function hideBoxNavForm() { // dong form
    userParent.classList.remove('active')

}

// close Form = overplay

overPlayForm.addEventListener('click', () => { ModalForm.classList.remove('active'); registerForm.classList.remove('active');loginForm.classList.remove('active') }) // click overplay >> tat form >> sau do tat register/login active 
closeForm.addEventListener('click ', () => { ModalForm.classList.remove('active'); registerForm.classList.remove('active'); loginForm.classList.remove('active') })// icon closeForm*/




////////////////////////////////// END OPEN OFF form///////////////////////////


////FORM NAV TO LOGIN/REGISTER //
const loginForm = ModalForm.querySelector('.form-vadition__container--login') // bat form login
const registerForm = ModalForm.querySelector('.form-vadition__container--register') // bat form login





