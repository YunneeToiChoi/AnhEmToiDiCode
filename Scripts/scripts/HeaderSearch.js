var HeaderSearchBox = document.querySelector('.search-container')
var HeaderSearchOption = document.querySelector('.header__searchOption-container')
var header = document.querySelector('.header')
var sukienoverplay = document.querySelector('.form-headerSearch--modal')
var xinchao = document.querySelector('.header-welcome__tittle') // mo box xin chao khi xuat hien search option
function OpenHeaderOption() { // mo overplay va mo box search
    HeaderSearchOption.classList.add('activefl')
    sukienoverplay.classList.add('active')
    xinchao.classList.add('active')
    HeaderSearchBox.classList.add('activehide')
}
HeaderSearchBox.addEventListener('click', OpenHeaderOption)  


// xoa overplay va xoa box search
function tatSearchOption() {
    HeaderSearchOption.classList.remove('activefl')
    sukienoverplay.classList.remove('active')
    xinchao.classList.remove('active')
    HeaderSearchBox.classList.remove('activehide')

}
sukienoverplay.addEventListener('click', tatSearchOption)


