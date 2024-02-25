const $= document.querySelector.bind(document)
const $$= document.querySelectorAll.bind(document)

var itemProductsImg =$$(".background-products-img img")
var minusSubnav =$$(".body-filter-products-item i")
var subNav =$$(".filter-products-sub-list")
var itemnavBar =$$(".header-navbar-item-link")
var iconSearch=$(".header-navbar-icon-search")
var inputSearch=$(".header-input-search")
var closeSearch =$(".header-input-search-close")
var modelMenu =$$(".main-menu-item .lv1")
var modelsubMenu =$$(".main-subMenu-item .lv2")
var navbar=$(".header-navbar")
var mobileSearch=$(".mobile-search")
var pro_img_main=$(".detail-img-sub-img")
var allPickColor=$$(".detail-info-color-item")
var allPickSize=$$(".detail-info-size-item")
var proTabs=$$(".pro-product-detail-tab-item")
var proPanes=$$(".product-detail-tab-pane")

// Di chuyển các tab của trong trang product 
function moveTabs(){
    proTabs.forEach((tab,index)=>{
        const pane = proPanes[index]
        tab.onclick =function(){
            console.log();
            $(".pro-product-detail-tab-item.active").classList.remove("active");
            $(".product-detail-tab-pane.active").classList.remove("active");
            this.classList.add("active")
            pane.classList.add("active")
        }
    })
}

// Thay đổi màu sắc của trong trang product
function choseColor(){
    allPickColor.forEach((color)=>{
        color.onclick=function(){
            $(".detail-info-color-item.active").classList.remove("active")
            this.classList.add("active")
        }
    })
}

// Thay đổi size của trong trang product

function choseSize(){
    allPickSize.forEach((size)=>{
        size.onclick=function(){
            $(".detail-info-size-item.active").classList.remove("active")
            this.classList.add("active")
        }
    })
}

// Mở tắt menu thứ cấp 1 trong phần menu model bên trái 
function modalMainMenu(){
    modelMenu.forEach((e)=>{
        e.addEventListener("click",()=>{
            e.classList.toggle("active")
            console.log(e);
        })
    })
}

// Mở tắt menu thứ cấp 2 trong phần menu model bên trái 
function modalMainsubMenu(){
    modelsubMenu.forEach((e)=>{
        e.addEventListener("click",()=>{
            e.classList.toggle("active")
        })
    })
}
//Mở tắt menu thú cấp trong phần filter trang chủ
function dropDownSubList(){
    minusSubnav.forEach((e)=>{
        e.addEventListener("click",()=>{
            e.classList.toggle("active")
            e.classList.toggle("fa-plus")
            e.classList.toggle("fa-minus")
        })
    })
}

// Mở menu phụ trong phần header navbar
function dropDownSubnav(){
    itemnavBar.forEach((e)=>{
        e.addEventListener("click",()=>{
            e.classList.toggle("active")
        })
    })
}

//Hiệu ứng thay đổi ảnh của product khi di chuột vào 
function changeImg(){
    itemProductsImg.forEach((e)=>{
        e.addEventListener("mouseenter",function(){
            let src = e.src;
            e.parentElement.style.backgroundImage = "url(" + src + ")";
        })
    })
}

//Mở thanh search khi nhấn vào icon search
function showSearch(){
    iconSearch.addEventListener("click",function(e){
        inputSearch.classList.toggle("display__flex-important")
    });
    closeSearch.addEventListener("click",function(e){
        inputSearch.classList.toggle("display__flex-important")
    });

}
modalMainsubMenu()
dropDownSubList()
dropDownSubnav()
choseColor()
showSearch()
choseSize()
modalMainMenu()
changeImg()
moveTabs()
