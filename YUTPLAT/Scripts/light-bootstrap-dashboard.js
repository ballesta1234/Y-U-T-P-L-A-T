/*!
    
 =========================================================
 * Light Bootstrap Dashboard - v1.3.1.0
 =========================================================
 
 * Product Page: http://www.creative-tim.com/product/light-bootstrap-dashboard
 * Copyright 2017 Creative Tim (http://www.creative-tim.com)
 * Licensed under MIT (https://github.com/creativetimofficial/light-bootstrap-dashboard/blob/master/LICENSE.md)
 
 =========================================================
 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 
 */
 
var searchVisible = 0;
var transparent = true;

var transparentDemo = true;
var fixedTop = false;

var navbar_initialized = false;

jQuery(document).ready(function(){
    window_width = jQuery(window).width();

    // check if there is an image set for the sidebar's background
    lbd.checkSidebarImage();

    // Init navigation toggle for small screens
    if(window_width <= 991){
        lbd.initRightMenu();
    }

    //  Activate the tooltips
    jQuery('[rel="tooltip"]').tooltip();

    //      Activate the switches with icons
    if(jQuery('.switch').length != 0){
        jQuery('.switch')['bootstrapSwitch']();
    }
    //      Activate regular switches
    if(jQuery("[data-toggle='switch']").length != 0){
         jQuery("[data-toggle='switch']").wrap('<div class="switch" />').parent().bootstrapSwitch();
    }

    jQuery('.form-control').on("focus", function(){
        jQuery(this).parent('.input-group').addClass("input-group-focus");
    }).on("blur", function(){
        jQuery(this).parent(".input-group").removeClass("input-group-focus");
    });

    // Fixes sub-nav not working as expected on IOS
jQuery('body').on('touchstart.dropdown', '.dropdown-menu', function (e) { e.stopPropagation(); });
});

// activate collapse right menu when the windows is resized
jQuery(window).resize(function(){
    if(jQuery(window).width() <= 991){
        lbd.initRightMenu();
    }
});

lbd = {
    misc:{
        navbar_menu_visible: 0
    },

    checkSidebarImage: function(){
        jQuerysidebar = jQuery('.sidebar');
        image_src = jQuerysidebar.data('image');

        if(image_src !== undefined){
            sidebar_container = '<div class="sidebar-background" style="background-image: url(' + image_src + ') "/>'
            jQuerysidebar.append(sidebar_container);
        }
    },
    initRightMenu: function(){
         if(!navbar_initialized){
            jQuerynavbar = jQuery('nav').find('.navbar-collapse').first().clone(true);

            jQuerysidebar = jQuery('.sidebar');
            sidebar_color = jQuerysidebar.data('color');

            jQuerylogo = jQuerysidebar.find('.logo').first();
            logo_content = jQuerylogo[0].outerHTML;

            ul_content = '';

            jQuerynavbar.attr('data-color',sidebar_color);

            //add the content from the regular header to the right menu
            jQuerynavbar.children('ul').each(function(){
                content_buff = jQuery(this).html();
                ul_content = ul_content + content_buff;
            });

            // add the content from the sidebar to the right menu
            content_buff = jQuerysidebar.find('.nav').html();
            ul_content = ul_content + content_buff;


            ul_content = '<div class="sidebar-wrapper">' +
                            '<ul class="nav navbar-nav">' +
                                ul_content +
                            '</ul>' +
                          '</div>';

            navbar_content = logo_content + ul_content;

            jQuerynavbar.html(navbar_content);

            jQuery('body').append(jQuerynavbar);

            background_image = jQuerysidebar.data('image');
            if(background_image != undefined){
                jQuerynavbar.css('background',"url('" + background_image + "')")
                       .removeAttr('data-nav-image')
                       .addClass('has-image');
            }


             jQuerytoggle = jQuery('.navbar-toggle');

             jQuerynavbar.find('a').removeClass('btn btn-round btn-default');
             jQuerynavbar.find('button').removeClass('btn-round btn-fill btn-info btn-primary btn-success btn-danger btn-warning btn-neutral');
             jQuerynavbar.find('button').addClass('btn-simple btn-block');

             jQuerytoggle.click(function (){
                if(lbd.misc.navbar_menu_visible == 1) {
                    jQuery('html').removeClass('nav-open');
                    lbd.misc.navbar_menu_visible = 0;
                    jQuery('#bodyClick').remove();
                     setTimeout(function(){
                        jQuerytoggle.removeClass('toggled');
                     }, 400);

                } else {
                    setTimeout(function(){
                        jQuerytoggle.addClass('toggled');
                    }, 430);

                    div = '<div id="bodyClick"></div>';
                    jQuery(div).appendTo("body").click(function() {
                        jQuery('html').removeClass('nav-open');
                        lbd.misc.navbar_menu_visible = 0;
                        jQuery('#bodyClick').remove();
                         setTimeout(function(){
                            jQuerytoggle.removeClass('toggled');
                         }, 400);
                    });

                    jQuery('html').addClass('nav-open');
                    lbd.misc.navbar_menu_visible = 1;

                }
            });
            navbar_initialized = true;
        }

    }
}


// Returns a function, that, as long as it continues to be invoked, will not
// be triggered. The function will be called after it stops being called for
// N milliseconds. If `immediate` is passed, trigger the function on the
// leading edge, instead of the trailing.

function debounce(func, wait, immediate) {
	var timeout;
	return function() {
		var context = this, args = arguments;
		clearTimeout(timeout);
		timeout = setTimeout(function() {
			timeout = null;
			if (!immediate) func.apply(context, args);
		}, wait);
		if (immediate && !timeout) func.apply(context, args);
	};
};