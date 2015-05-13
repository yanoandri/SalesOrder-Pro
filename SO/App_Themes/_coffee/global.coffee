#-- GET WIDTH FROM TEXT COUNT
$.fn.textWidth = (text, font) ->
	if (!$.fn.textWidth.fakeEl) 
		$.fn.textWidth.fakeEl = $('<span>').hide().appendTo(document.body);
	$.fn.textWidth.fakeEl.text(text || this.val() || this.text()).css('font', font || this.css('font'));
	$.fn.textWidth.fakeEl.width();
	
#-- MENU FIND PARENT
$.fn.get_parent_menu = (options) ->
	this.each ->
		$this			=	$(@)
	
		defaults	=
			title		:	null

		opts = $.extend( {}, defaults, options )

		$li_parent	=	$this.find("ol li, ul li")

		$li_parent.each ->
			$li	=	$(@)
			if $li.find("ol,ul").length != 0
				$li.find("> a")
					.prepend("<span></span>")
					.append("<i></i>")

				$li.addClass("parent")
	
#-- DASHBOARD MENU
$.fn.dashboard_menu = (options) ->
	this.each ->
		$this			=	$(@)
	
		defaults	=
			title		:	null

		opts = $.extend( {}, defaults, options )

		$li_parent	=	$this.find(">ol>li>a, >ul>li>a")

		$li_parent.each ->
			$(@).each ->
				$(@).on "click", (e) ->
					e.preventDefault()
					
					$(@).parent().find("ul,ol")
						.slideToggle()

					$(@).parent().siblings()
						.find("ul,ol")
						.slideUp()

#-- DASHBOARD MENU
$.fn.gauge = (options) ->
	$this			=	$(@)

#	if $this.length != 0
	this.each ->
		canvas	=	this

		$color = if canvas.getAttribute("data-color") then canvas.getAttribute("data-color") else "#2d5980"

		defaults	=
			color				:	$color
			bgcolor			:	"#eee"
			border_width	:	20
			border_radius	:	70
			font_family		:	"Verdana"
			font_size		:	"40px"

		opts = $.extend( {}, defaults, options )

		ctx						=	canvas.getContext("2d")
		W							=	canvas.width
		H							=	canvas.height

		value						=	parseInt(canvas.getAttribute("data-value"))
		from						=	canvas.getAttribute("data-from")

		new_degrees				=	Math.round(((value/from))*360)
		degrees					=	new_degrees
		color						=	opts.color
		bgcolor					=	opts.bgcolor

		init = ->
			ctx.clearRect(0, 0, W, H)

			ctx.beginPath()
			ctx.strokeStyle	=	bgcolor
			ctx.lineWidth		=	opts.border_width
			ctx.arc(W/2, H/2, opts.border_radius, 0, Math.PI*2, false)  
			ctx.stroke()

			radians				=	degrees * Math.PI / 180
			ctx.beginPath()
			ctx.strokeStyle	=	color
			ctx.lineWidth		=	opts.border_width 
			ctx.arc(W/2, H/2, opts.border_radius, 0 - 90*Math.PI/180, radians - 90*Math.PI/180, false)  
			ctx.stroke()

			ctx.fillStyle		=	color
			ctx.font				=	opts.font_size+" "+opts.font_family
			text					=	value 
			text_width			=	ctx.measureText(text).width 
			ctx.fillText(text, W/2 - text_width/2, (H/2)+0 + 15)

		init()
						
#-- FUNCTION - HIDE PRELOADER
hide_preloader = ->
    $("#preloader").fadeOut(1000)

#---------------------
#-- WINDOW LOAD
#---------------------
$(window).load ->
	
	#-- FUNCTION - HIDE PRELOADER - ACTIVATE
	hide_preloader()

#---------------------
#-- DOCUMENT READY
#---------------------
$(document).ready ->
	
	window_h		=	$(window).height()
	document_h	=	$(document).height()
	overheight	=	document_h - window_h

	#-- BREADCRUMB
	$(".breadcrumb").find("li:last-child a")
		.attr("href", "javascript:;")
		.on "click", ->
			return false
			
	#-- SCROLL TO TOP
	$('#gototop').click ->
		$("html, body").animate
			scrollTop: 0
		, 600
		return false
	
	#-- FANCYBOX
	$(".fancybox").fancybox

	#-- DASHBOARD MENU
	$("#dashboard_menu").dashboard_menu()
	
	#-- GAUGE ASSESSMENT RESULT
	$(".gauge_img").gauge()
	
	#-- TOP MENU
	$(".top_menu li li a").each ->
		$(@).css
			width	:	($(@).textWidth() + (20))
			
	$(".top_menu,#dashboard_menu")
		.get_parent_menu()
	
	#-- 
	$(".accordion_field").each ->
		button	=	$(@).find(".acc_button")
		
		button.on "click", (e) ->
			$(@)
				.toggleClass("close")
				.parents(".acc_wrap")
				.find(".acc_target")
				.slideToggle()

		button.each ->
			if($(@).hasClass("close"))
				$(@)
					.parents(".acc_wrap")
					.find(".acc_target")
					.slideUp()
				
	#-- AUTO CENTERING
	$('[class*="table"]')
		.find("td")
		.has('button,
			input[type="checkbox"],
			input[type="radio"],
			input[type="text"],
			textarea,
			select')
		.css
			textAlign	:	"center"

	$('[class*="table"]')
		.find('td')
		.filter ->
			this.innerHTML.match(/^[0-9\s\.,]+$/);
		.css
			textAlign	:	"center"


#---------------------
#-- DOCUMENT CLICK
#---------------------
$(document).bind "click", (e) ->
	target = e.target

#---------------------
#-- WINDOW RESIZE
#---------------------

$(window).bind 'resize', (e) ->
	$window_w	=	$(window).width()
	$window_h	=	$(window).height()

.trigger('resize')

#-- WINDOW SCROLL
$(window).scroll ->
	window_scr	=	$(window).scrollTop()
	window_h		=	$(window).height()
	document_h	=	$(document).height()
	overheight	=	document_h - window_h

	#-- STICKY HEADER
	min_scroll	=	window_h
	$header		=	$(".header")

	if window_scr > min_scroll + 100
		$("#gototop").addClass("active")
	else
		$("#gototop").removeClass("active")