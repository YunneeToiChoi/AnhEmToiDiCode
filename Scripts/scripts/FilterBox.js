var boxfilterforuser = document.querySelector('.vadition__box') // bat cai box mo
var form = document.querySelector('.form-vadition--modal') // bat form
var filterbox = document.querySelector('.box-loc') // cai box filter

filterbox.addEventListener('click', moboxfilter )
function moboxfilter() {
    form.classList.add('active')
    boxfilterforuser.classList.add('active')
}
