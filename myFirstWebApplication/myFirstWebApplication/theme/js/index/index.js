/* Author:WebThemez
 * Author URI:http://webthemez.com
 * License: Creative Commons Attribution 3.0 License (https://creativecommons.org/licenses/by/3.0/)
 */

(function ($) {
    $(document).ready(function () {

        setInterval(function () {
            var imgList = $("#banner_scoll").children('img');
            for (var i = 0; i < imgList.length; i++) {
                $(imgList[i]).fadeToggle(2000);
            }
        }, 5000)

        // Fixed header
        //-----------------------------------------------
        $(window).scroll(function () {
            if (($(".header.fixed").length > 0)) {
                if (($(this).scrollTop() > 0) && ($(window).width() > 767)) {
                    $("body").addClass("fixed-header-on");
                } else {
                    $("body").removeClass("fixed-header-on");
                }
            };
        });

        $(window).load(function () {
            if (($(".header.fixed").length > 0)) {
                if (($(this).scrollTop() > 0) && ($(window).width() > 767)) {
                    $("body").addClass("fixed-header-on");
                } else {
                    $("body").removeClass("fixed-header-on");
                }
            };
        });

        $('#quote-carousel').carousel({
            pause: true,
            interval: 4000,
        });
        //Scroll Spy
        //-----------------------------------------------
        if ($(".scrollspy").length > 0) {
            $("body").addClass("scroll-spy");
            $('body').scrollspy({
                target: '.scrollspy',
                offset: 152
            });
        }

        //Smooth Scroll
        //-----------------------------------------------
        if ($(".smooth-scroll").length > 0) {
            $('.smooth-scroll a[href*=#]:not([href=#]), a[href*=#]:not([href=#]).smooth-scroll').click(function () {
                if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
                    var target = $(this.hash);
                    target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                    if (target.length) {
                        $('html,body').animate({
                            scrollTop: target.offset().top - 151
                        }, 1000);
                        return false;
                    }
                }
            });
        }

        // Animations
        //-----------------------------------------------
        if (($("[data-animation-effect]").length > 0) && !Modernizr.touch) {
            $("[data-animation-effect]").each(function () {
                var $this = $(this),
				animationEffect = $this.attr("data-animation-effect");
                if (Modernizr.mq('only all and (min-width: 768px)') && Modernizr.csstransitions) {
                    $this.appear(function () {
                        setTimeout(function () {
                            $this.addClass('animated object-visible ' + animationEffect);
                        }, 400);
                    }, { accX: 0, accY: -130 });
                } else {
                    $this.addClass('object-visible');
                }
            });
        };

        // Isotope filters
        //-----------------------------------------------
        if ($('.isotope-container').length > 0) {
            $(window).load(function () {
                $('.isotope-container').fadeIn();
                var $container = $('.isotope-container').isotope({
                    itemSelector: '.isotope-item',
                    layoutMode: 'masonry',
                    transitionDuration: '0.6s',
                    filter: "*"
                });
                // filter items on button click
                $('.filters').on('click', 'ul.nav li a', function () {
                    var filterValue = $(this).attr('data-filter');
                    $(".filters").find("li.active").removeClass("active");
                    $(this).parent().addClass("active");
                    $container.isotope({ filter: filterValue });
                    return false;
                });
            });
        };

        //Modal
        //-----------------------------------------------
        if ($(".modal").length > 0) {
            $(".modal").each(function () {
                $(".modal").prependTo("body");
            });
        }

    }); // End document ready
})(this.jQuery);



function cambiar_login() {
  document.querySelector('.cont_forms').className = "cont_forms cont_forms_active_login";  
document.querySelector('.cont_form_login').style.display = "block";
document.querySelector('.cont_form_sign_up').style.opacity = "0";   
document.getElementById("zhezhao").style.display="block";
document.querySelector('.cont_forms').style.display = "block";
setTimeout(function(){  document.querySelector('.cont_form_login').style.opacity = "1"; },100);  
  
setTimeout(function(){    
document.querySelector('.cont_form_sign_up').style.display = "none";
},400);  
  }




function cambiar_sign_up(at) {
  document.querySelector('.cont_forms').className = "cont_forms cont_forms_active_sign_up";
  document.querySelector('.cont_form_sign_up').style.display = "block";
document.querySelector('.cont_form_login').style.opacity = "0";
document.getElementById("zhezhao").style.display="block";
document.querySelector('.cont_forms').style.display = "block";
setTimeout(function(){  document.querySelector('.cont_form_sign_up').style.opacity = "1";
},100);  

setTimeout(function(){   document.querySelector('.cont_form_login').style.display = "none";
},400);  


}

function ocultar_login_sign_up() {

document.querySelector('.cont_forms').className = "cont_forms";  
document.querySelector('.cont_form_sign_up').style.opacity = "0";               
document.querySelector('.cont_form_login').style.opacity = "0"; 
document.getElementById("zhezhao").style.display="none";
document.querySelector('.cont_forms').style.display = "none";
document.getElementById("username").value = "";
document.getElementById("password").value = "";
document.getElementById("input1").value = "";
document.getElementById("Setusername").value = "";
document.getElementById("Setpassword").value = "";
document.getElementById("Setcheckpassword").value = "";
document.getElementById("Inviter").value = "";
document.getElementById("input2").value = "";

setTimeout(function(){
document.querySelector('.cont_form_sign_up').style.display = "none";
document.querySelector('.cont_form_login').style.display = "none";
},200);  
  
  }