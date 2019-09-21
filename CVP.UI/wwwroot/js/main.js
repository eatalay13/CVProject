/*!
 * Caracraft Theme
 * version: 0.1
 * Dev: nurealamsabbir
 * DevURL: fb.com/nurealamsabbir
 * MADE BY:  PULSTHEME
 */
(function($) {
    'use strict';

    /*------------------------------------------------
     Magnificpopup for gallery section
    -------------------------------------------------- */
    $('.gallery-popup').magnificPopup({
        type: 'image',
        mainClass: 'mfp-with-zoom', // this class is for CSS animation below
        gallery: {
            enabled: true
        },
        zoom: {
            enabled: true, // By default it's false, so don't forget to enable it
            duration: 300, // duration of the effect, in milliseconds
            easing: 'ease-in-out', // CSS transition easing function
            opener: function(openerElement) {
                return openerElement.is('img') ? openerElement : openerElement.find('img');
            }
        }
    });

    /*------------------------------------------------
     Magnificpopup for video gallery section
    -------------------------------------------------- */
    $('.popup').magnificPopup({
        type: "iframe",
        mainClass: "mfp-fade",
        removalDelay: 160,
        preloader: false,
        fixedContentPos: false
    });

    /*------------------------------------------------
     Slik slider service section.
    -------------------------------------------------- */
    $('.service-slider').slick({
        centerMode: false,
        centerPadding: '0',
        slidesToShow: 3,
        responsive: [{
            breakpoint: 1024,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 3,
                infinite: true
            }
        }, {
            breakpoint: 768,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '0',
                slidesToShow: 2
            }
        }, {
            breakpoint: 767,
            settings: {
                arrows: true,
                centerMode: true,
                centerPadding: '0',
                slidesToShow: 1
            }
        }, {
            breakpoint: 481,
            settings: {
                arrows: true,
                centerMode: true,
                centerPadding: '0',
                slidesToShow: 1
            }
        }]
    });

    /*------------------------------------------------
     Caracraft main slider
    -------------------------------------------------- */
    $('.caracraft-slider').slick({
        dots: false,
        arrows: false,
        infinite: true,
        speed: 300,
        slidesToShow: 1
    });

    /*------------------------------------------------
     Caracraft testimonial slider
    -------------------------------------------------- */
    $('.testimonial-slider').slick({
        dots: false,
        arrows: true,
        infinite: true,
        speed: 300,
        slidesToShow: 1
    });

    /*------------------------------------------------
     Caracraft banner slider
    -------------------------------------------------- */
    $('.banner-slider').slick({
        dots: false,
        arrows: false,
        infinite: true,
        speed: 300,
        slidesToShow: 1
    });
    /*------------------------------------------------
     Caracraft brand logo slider
    -------------------------------------------------- */
    $('.brand-logo-slider').slick({
        dots: false,
        arrows: true,
        infinite: true,
        speed: 300,
        slidesToShow: 2,
        responsive: [{
            breakpoint: 481,
            settings: {
                centerMode: true,
                centerPadding: '0',
                slidesToShow: 1
            }
        }]
    });

    /*------------------------------------------------
     Caracraft gallery slider and slide counter.
    -------------------------------------------------- */
    var $countStatus = $('.pagingInfo');
    var $slickElement = $('.gallery-slider');
    $slickElement.on('init reInit afterChange', function(event, slick, currentSlide, nextSlide) {
        var i = (currentSlide ? currentSlide : 0) + 1;
        $countStatus.text(i + ' of ' + slick.slideCount);
    });
    $slickElement.slick({
        dots: false,
        arrows: true,
        infinite: true,
        speed: 300,
        slidesToShow: 1
    });

    /* -------------------------------------------------------
     Portfolio filter set active class for style
    ----------------------------------------------------------*/
    $('.portfolio-filter li').on('click', function(event) {
        $(this).siblings('.active').removeClass('active');
        $(this).addClass('active');
        event.preventDefault();
    });

    /* ----------------------------------------------------
     Portfolio masonry isotope
    ------------------------------------------------------*/
    var $varPortfolioMasonry = $('.portfolio-masonry');
    if (typeof imagesLoaded == 'function') {
        imagesLoaded($varPortfolioMasonry, function() {
            setTimeout(function() {
                $varPortfolioMasonry.isotope({
                    itemSelector: '.portfolio-item',
                    resizesContainer: false,
                    filter: '*',
                    layoutMode: 'masonry'
                });
            }, 500);
        });
    };
    /* ----------------------------------------------------
       Portfolio without masonry isotope
      ------------------------------------------------------*/
    var $varPortfolioMasonry2 = $('.portfolio-simple');
    if (typeof imagesLoaded == 'function') {
        imagesLoaded($varPortfolioMasonry2, function() {
            setTimeout(function() {
                $varPortfolioMasonry2.isotope({
                    itemSelector: '.portfolio-item',
                    resizesContainer: false,
                    filter: '*'
                });
            }, 500);
        });
    };

    /* ---------------------------------------------------
     Portfolio filtering
    ---------------------------------------------------- */
    $('.portfolio-filter').on('click', 'a', function() {
        $(this).addClass('current');
        var filterValue = $(this).attr('data-filter');
        $(this).parents(".portfolio-section").find(".portfolio").isotope({
            filter: filterValue
        });
    });

    /*-------------------------------------------
       Scroll to top button
    ---------------------------------------------*/
    if ($('#back-to-top').length) {
        var scrollTrigger = 100, // px
            backToTop = function() {
                var scrollTop = $(window).scrollTop();
                if (scrollTop > scrollTrigger) {
                    $('#back-to-top').addClass('to-top-show');
                } else {
                    $('#back-to-top').removeClass('to-top-show');
                }
            };
        backToTop();
        $(window).on('scroll', function() {
            backToTop();
        });
        $('#back-to-top').on('click', function(e) {
            e.preventDefault();
            $('html,body').animate({
                scrollTop: 0
            }, 700);
        });
    };

    /*------------------------------------------------
     Magnificpopup for portfolio gallery section
    -------------------------------------------------- */
    $('.portfolio-gallery-set').magnificPopup({
        type: 'image',
        mainClass: 'mfp-with-zoom',
        gallery: {
            enabled: true
        },
        zoom: {
            enabled: true,
            duration: 350,
            easing: 'ease-in-out',
            opener: function(openerElement) {
                return openerElement.is('img') ? openerElement : openerElement.find('img');
            }
        }
    });


    /*------------------------------------------------
     *SendMail: by fb.com/nurealamsabbir
     *-------------------------------------------------- */
    // Function for email address validation and contact form ajax code
    /*function validateEmail(email) {
	    var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
	    return re.test(email);
	}*/
    /******************** CONTACT FORM ********************/
    /*$('#caracraft-contact-form').on('submit', function(e) {
		//console.log($(this).attr('action'));
	    e.preventDefault();
	    $('#form_errors').addClass('hide');
	    var data = $(this).serialize();
	    
	    if (validateEmail( $(this).find('input[name="email"]').val() )) {
	        $.ajax({
	            type: "POST",
	            url: $(this).attr('action'),
	            data: data,
	            success: function(res) {
	                //console.log(res);
	                res = $.parseJSON(res);
	                if(res.status) {
	                    $('#form_success').html(res.message).removeClass('hide');
	                    $('#contact-form').addClass('hide');
	                } else {
	                    $('#form_errors').html(res.message).removeClass('hide');
	                }
	            }
	        });
	    } else {
	        $('#form_errors').html('Please give a valid email address').removeClass('hide');
	    }
	    return false;
	});*/
    /*------------------------------------------------
        Instagram Gallery Plugin
       -------------------------------------------------- */
    /*var feed = new Instafeed({
           get: 'tagged',
           tagName: 'caracraft_black_white',
           clientId: '330f457fcb1e40e4aad14b38d21ce894',
           accessToken: 'e6c23c6a67b8478193543910d9468652'
       });
       feed.run();*/
    /*------------------------------------------------
        Pre-loader javascript
    -------------------------------------------------- */
        setTimeout(function(){
            $('body').addClass('loaded');
        }, 2000);


})(jQuery);