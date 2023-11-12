var boxfilterforuser = document.querySelector('.form-filter--overplay') // bat cai box mo
var form = document.querySelector('.form-filter--modal') // bat form
var filterbox = document.querySelector('.box-loc') // cai box filter
var icfilterbox = document.querySelector('.filterbox-ic')
filterbox.addEventListener('click', moboxfilter)
function moboxfilter() { // su kien mo filterbox
    form.classList.add('active')
}
boxfilterforuser.addEventListener('click', closefilterbox)
icfilterbox.addEventListener('click', closefilterbox) // su kien tat  filterbox = icon hoac form
function closefilterbox() {
    form.classList.remove('active')
}
        // su kien tat  filterbox = form
        //form.addEventListener('click', closeFilterBoxWithForm)
        //function closeFilterBoxWithForm (){
        //     form.classList.remove('active')
        //    boxfilterforuser.classList.remove('active')
        //}