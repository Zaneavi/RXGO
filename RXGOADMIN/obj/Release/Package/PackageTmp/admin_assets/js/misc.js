(function ($) {
    'use strict';
    $(function () {
        // sidemenu
        $.sidebarMenu = function (menu) {
            var animationSpeed = 300;

            $(menu).on('click', 'li a', function (e) {
                var $this = $(this);
                var checkElement = $this.next();

                if (checkElement.is('.treeview-menu') && checkElement.is(':visible')) {
                    checkElement.slideUp(animationSpeed, function () {
                        checkElement.removeClass('menu-open');
                    });
                    checkElement.parent("li").removeClass("active");
                }

                    //If the menu is not visible
                else if ((checkElement.is('.treeview-menu')) && (!checkElement.is(':visible'))) {
                    //Get the parent menu
                    var parent = $this.parents('ul').first();
                    //Close all open menus within the parent
                    var ul = parent.find('ul:visible').slideUp(animationSpeed);
                    //Remove the menu-open class from the parent
                    ul.removeClass('menu-open');
                    //Get the parent li
                    var parent_li = $this.parent("li");

                    //Open the target menu and add the menu-open class
                    checkElement.slideDown(animationSpeed, function () {
                        //Add the class active to the parent li
                        checkElement.addClass('menu-open');
                        parent.find('li.active').removeClass('active');
                        parent_li.addClass('active');
                    });
                }
                //if this isn't a link, prevent the page from being redirected
                if (checkElement.is('.treeview-menu')) {
                    e.preventDefault();
                }
            });
        }
        // sidemenu
        // sidemenu active
        $.sidebarMenu($('.sidebar-menu'))
        // sidemenu active


        var url = window.location;
        // for sidebar menu but not for treeview submenu
        $('ul.sidebar-menu a').filter(function () {
            return this.href == url;
        }).parent().siblings().removeClass('active').end().addClass('active');
        // for treeview which is like a submenu
        $('ul.treeview-menu a').filter(function () {
            return this.href == url;
        }).parentsUntil(".sidebar-menu > .treeview-menu").siblings().removeClass('active').end().addClass('active');




        //Change sidebar and content-wrapper height
        applyStyles();

        function applyStyles() {
            //Applying perfect scrollbar
            if ($('.scroll-container').length) {
                const ScrollContainer = new PerfectScrollbar('.scroll-container');
            }
        }

        //checkbox and radios
        $(".form-check label,.form-radio label").append('<i class="input-helper"></i>');
        $(".purchace-popup .popup-dismiss").on("click", function () {
            $(".purchace-popup").slideToggle();
        });

        // datatable
        $(function () {
            $('#example1').DataTable()
            $('#example2').DataTable({
                'paging': true,
                'lengthChange': false,
                'searching': false,
                'ordering': true,
                'info': true,
                'autoWidth': false
            })
        })

        // summernote
        $('#summernote').summernote({
            height: 300, // set editor height
            placeholder: 'Hello default Summernote',
            minHeight: null, // set minimum height of editor
            maxHeight: null, // set maximum height of editor
            focus: false // set focus to editable area after initializing summernote
        });
        var edit = function () {
            $('.click2edit').summernote({ focus: true });
        };
        var save = function () {
            var markup = $('.click2edit').summernote('code');
            $('.click2edit').summernote('destroy');
        };






    });



})(jQuery);