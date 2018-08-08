// Write your JavaScript code.
$(document)
    .ready(function () {

        // fix menu when passed
        $('.masthead')
            .visibility({
                once: false,
                onBottomPassed: function () {
                    $('.fixed.menu').transition('fade in');
                },
                onBottomPassedReverse: function () {
                    $('.fixed.menu').transition('fade out');
                }
            })
            ;

        // create sidebar and attach to menu open
        $('.ui.sidebar')
            .sidebar('attach events', '.toc.item')
            ;
        //Semantic ui Dropdown initialization
        $('.ui.dropdown')
            .dropdown();

        //Hack to make MVC ValidationSummary tag helper play nicely with Semantic UI
        $('.ui.error ul').addClass('list');

        if ($('.ui.error ul li:first').css('display') === 'none') {
            $('.ui.error').hide();
        } else {
            $('.ui.error').show();
        }

        $('.ui.checkbox').checkbox();

    })
    ;
