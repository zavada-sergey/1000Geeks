$('document').ready(function () {

  showPictures();

  $("#upload-picture").change(function () {
    for (var i = 0; i < document.forms.length; i++) {
      $.ajax({
        url: "api/Picture/Add",
        type: "POST",
        data: new FormData(document.forms[i]),
        processData: false,
        contentType: false,
        success: function (result) {
          showPictures();
        }
      });
    }
  });

});

function showPictures() {
  $.get("/api/Picture/GetAll", function (pictures) {

    $('#pictures-container').empty();
    $('#pictures-container').append(`<div class="swiper-container">  <div id="view-pictures" class="swiper-wrapper"></div>  </div>`);

    pictures.forEach(function (item) {
      $('#view-pictures').append(`<img class="swiper-slide" style="width: 1000px;" src="${item.picture}"/>`);
    });

    new Swiper('.swiper-container', {
      loop: true,

      pagination: {
        el: '.swiper-pagination'
      },

      navigation: {
        nextEl: '.gallery-image__right',
        prevEl: '.gallery-image__left'
      },

      scrollbar: {
        el: '.swiper-scrollbar'
      }
    });
  });
}