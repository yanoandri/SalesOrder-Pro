(function () {
    var hide_preloader;

    $.fn.textWidth = function (text, font) {
        if (!$.fn.textWidth.fakeEl) {
            $.fn.textWidth.fakeEl = $('<span>').hide().appendTo(document.body);
        }
        $.fn.textWidth.fakeEl.text(text || this.val() || this.text()).css('font', font || this.css('font'));
        return $.fn.textWidth.fakeEl.width();
    };

    $.fn.get_parent_menu = function (options) {
        return this.each(function () {
            var $li_parent, $this, defaults, opts;
            $this = $(this);
            defaults = {
                title: null
            };
            opts = $.extend({}, defaults, options);
            $li_parent = $this.find("ol li, ul li");
            return $li_parent.each(function () {
                var $li;
                $li = $(this);
                if ($li.find("ol,ul").length !== 0) {
                    $li.find("> a").prepend("<span></span>").append("<i></i>");
                    return $li.addClass("parent");
                }
            });
        });
    };

    $.fn.dashboard_menu = function (options) {
        return this.each(function () {
            var $li_parent, $this, defaults, opts;
            $this = $(this);
            defaults = {
                title: null
            };
            opts = $.extend({}, defaults, options);
            $li_parent = $this.find(">ol>li>a, >ul>li>a");
            return $li_parent.each(function () {
                return $(this).each(function () {
                    return $(this).on("click", function (e) {
                        e.preventDefault();
                        $(this).parent().find("ul,ol").slideToggle();
                        return $(this).parent().siblings().find("ul,ol").slideUp();
                    });
                });
            });
        });
    };

    $.fn.gauge = function (options) {
        var $this;
        $this = $(this);
        return this.each(function () {
            var $color, H, W, bgcolor, canvas, color, ctx, defaults, degrees, from, init, new_degrees, opts, value;
            canvas = this;
            $color = canvas.getAttribute("data-color") ? canvas.getAttribute("data-color") : "#2d5980";
            defaults = {
                color: $color,
                bgcolor: "#eee",
                border_width: 20,
                border_radius: 70,
                font_family: "Verdana",
                font_size: "40px"
            };
            opts = $.extend({}, defaults, options);
            ctx = canvas.getContext("2d");
            W = canvas.width;
            H = canvas.height;
            value = parseInt(canvas.getAttribute("data-value"));
            from = canvas.getAttribute("data-from");
            new_degrees = Math.round((value / from) * 360);
            degrees = new_degrees;
            color = opts.color;
            bgcolor = opts.bgcolor;
            init = function () {
                var radians, text, text_width;
                ctx.clearRect(0, 0, W, H);
                ctx.beginPath();
                ctx.strokeStyle = bgcolor;
                ctx.lineWidth = opts.border_width;
                ctx.arc(W / 2, H / 2, opts.border_radius, 0, Math.PI * 2, false);
                ctx.stroke();
                radians = degrees * Math.PI / 180;
                ctx.beginPath();
                ctx.strokeStyle = color;
                ctx.lineWidth = opts.border_width;
                ctx.arc(W / 2, H / 2, opts.border_radius, 0 - 90 * Math.PI / 180, radians - 90 * Math.PI / 180, false);
                ctx.stroke();
                ctx.fillStyle = color;
                ctx.font = opts.font_size + " " + opts.font_family;
                text = value;
                text_width = ctx.measureText(text).width;
                return ctx.fillText(text, W / 2 - text_width / 2, (H / 2) + 0 + 15);
            };
            return init();
        });
    };

    hide_preloader = function () {
        return $("#preloader").fadeOut(1000);
    };

    $(window).load(function () {
        return hide_preloader();
    });

    $(document).ready(function () {
        var document_h, overheight, window_h;
        window_h = $(window).height();
        document_h = $(document).height();
        overheight = document_h - window_h;
        $(".breadcrumb").find("li:last-child a").attr("href", "javascript:;").on("click", function () {
            return false;
        });
        $('#gototop').click(function () {
            $("html, body").animate({
                scrollTop: 0
            }, 600);
            return false;
        });
        $(".fancybox").fancybox;
        $("#dashboard_menu").dashboard_menu();
        $(".gauge_img").gauge();
        $(".top_menu li li a").each(function () {
            return $(this).css({
                width: $(this).textWidth() + 20.
            });
        });
        $(".top_menu,#dashboard_menu").get_parent_menu();
        $(".accordion_field").each(function () {
            var button;
            button = $(this).find(".acc_button");
            button.on("click", function (e) {
                return $(this).toggleClass("close").parents(".acc_wrap").find(".acc_target").slideToggle();
            });
            return button.each(function () {
                if ($(this).hasClass("close")) {
                    return $(this).parents(".acc_wrap").find(".acc_target").slideUp();
                }
            });
        });
        //$('[class*="table"]').find("td").has('button, input[type="checkbox"], input[type="radio"], input[type="text"], textarea, select').css({
        //    textAlign: "center"
        //});

        $('[class*="table"]').find("td").has('button,  textarea').css({
            textAlign: "center"
        });
        return $('[class*="table"]').find('td').filter(function () {
            return this.innerHTML.match(/^[0-9\s\.,]+$/);
        }).css({
            textAlign: "center"
        });
    });

    $(window).bind('resize', function (e) {
        var $window_h, $window_w;
        $window_w = $(window).width();
        return $window_h = $(window).height();
    }).trigger('resize');

    $(window).scroll(function () {
        var $header, document_h, min_scroll, overheight, window_h, window_scr;
        window_scr = $(window).scrollTop();
        window_h = $(window).height();
        document_h = $(document).height();
        overheight = document_h - window_h;
        min_scroll = window_h;
        $header = $(".header");
        if (window_scr > min_scroll + 100) {
            return $("#gototop").addClass("active");
        } else {
            return $("#gototop").removeClass("active");
        }
    });

}).call(this);
