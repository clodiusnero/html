$(window).scroll(function() {
// 150 = The point you would like to fade the nav in.
  
	if ($(window).scrollTop() > 150 ){
    
 		$('.header').addClass('show');
    
  } else {
    
    $('.header').removeClass('show');
    
 	};   	
});

$('.scroll').on('click', function(e){		
		e.preventDefault()
    
  $('html, body').animate({
      scrollTop : $(this.hash).offset().top
    }, 1500);
});