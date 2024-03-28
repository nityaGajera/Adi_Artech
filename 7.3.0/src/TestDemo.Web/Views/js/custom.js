/* ========== Navigation mobile view js Strat ========== */ 
$(document).ready(function () {

     
      $('#sidebarCollapse').on('click', function () {
          
          $('#sidebar').toggleClass('active');
          $('#sidebarCollapse').toggleClass('active');
          $('body').toggleClass('overflowhidden');
          $('.overlay').fadeIn();
          $('.collapse.in').toggleClass('in');
          $('a[aria-expanded=true]').attr('aria-expanded', 'false');
      });


         //Multiple Dropdown Click JS
      $("ul li.dropdown [data-toggle='dropdown']").on("click", function(event) {
          event.preventDefault();
          event.stopPropagation();

          $(this).siblings().toggleClass("show");
      
          if (!$(this).next().hasClass('show')) {
            $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
          }
          $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function(e) {
            $('.submenu .show').removeClass("show");
          });
      });
});
/* ========== Navigation mobile view js End ========== */
/* ========== Loader js Strat ========== */
// var overlaybox = document.getElementById("loaderbox");
//     window.addEventListener('load', function() {
//         overlaybox.style.display = 'none';
// })
/* ========== Loader js End ========== */
