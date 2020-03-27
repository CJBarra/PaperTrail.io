// const navbarActive = document.querySelector('.nav-sidebar');
// li = navbarActive.querySelectorAll('li');

// li.forEach(function(e) {
//     e.addEventListener('click', function() {
//         for (let i = 0; i < li.length; i++) {
//             li[i].classList.remove('active');
//         }
//         this.classList.add('active');
//     });
// });


$(document).ready(function() {
    $.each($('.nav-sidebar').find('li'), function(){
        $(this).toggleClass('active', window.location.pathname.indexOf($(this).find('a').attr('asp-controller')) > -1)
    });
});



$(function () {
    $('#patronList').DataTable();
    $('#catalogId').DataTable();
    $('#checkoutList').DataTable({
      "paging": true,
      "lengthChange": false,
      "searching": false,
      "ordering": false,
      "info": true,
      "autoWidth": false,
    });
    $('#reserveList').DataTable({
      "paging": true,
      "lengthChange": false,
      "searching": false,
      "ordering": true,
      "info": true,
      "autoWidth": false,
    });
  });