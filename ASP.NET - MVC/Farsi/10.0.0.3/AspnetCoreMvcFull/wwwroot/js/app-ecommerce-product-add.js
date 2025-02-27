/**
 * App eCommerce Add Product Script
 */
'use strict';

//Javascript to handle the e-commerce product add page

(function () {
  // Comment editor

  const commentEditor = document.querySelector('.comment-editor');

  if (commentEditor) {
    new Quill(commentEditor, {
      modules: {
        toolbar: '.comment-toolbar'
      },
      placeholder: 'توضیحات محصول',
      theme: 'snow'
    });
  }

  // previewTemplate: Updated Dropzone default previewTemplate

  // ! Don't change it unless you really know what you are doing

  const previewTemplate = `<div class="dz-preview dz-file-preview">
<div class="dz-details">
  <div class="dz-thumbnail">
    <img data-dz-thumbnail>
    <span class="dz-nopreview">بدون پیشنمایش</span>
    <div class="dz-success-mark"></div>
    <div class="dz-error-mark"></div>
    <div class="dz-error-message"><span data-dz-errormessage></span></div>
    <div class="progress">
      <div class="progress-bar progress-bar-primary" role="progressbar" aria-valuemin="0" aria-valuemax="100" data-dz-uploadprogress></div>
    </div>
  </div>
  <div class="dz-filename" data-dz-name></div>
  <div class="dz-size" data-dz-size></div>
</div>
</div>`;

  // ? Start your code from here

  // Basic Dropzone

  var faOption = {
    dictDefaultMessage: "فایل‌ها را برای ارسال اینجا رها کنید",
    dictFallbackMessage: "مرورگر شما از کشیدن و رهاکردن پشتیبانی نمی‌کند.",
    dictFallbackText: "لطفا از فرم زیر برای ارسال فایل های خود مانند دوران های گذشته استفاده کنید.",
    dictFileTooBig: "فایل خیلی بزرگ است ({{filesize}}MB). حداکثر اندازه فایل: {{maxFilesize}}MB.",
    dictInvalidFileType: "ارسال این نوع فرمت فایل‌ها مجاز نیست.",
    dictResponseError: "سرور با کد {{statusCode}} پاسخ داد.",
    dictCancelUpload: "لغو ارسال",
    dictCancelUploadConfirmation: "آیا از لغو کردن این ارسال اطمینان دارید؟",
    dictRemoveFile: "حذف فایل",
    dictMaxFilesExceeded: "امکان ارسال فایل دیگری وجود ندارد."
  }

  const dropzoneBasic = document.querySelector('#dropzone-basic');
  if (dropzoneBasic) {
    var options = {
      previewTemplate: previewTemplate,
      parallelUploads: 1,
      maxFilesize: 5,
      acceptedFiles: '.jpg,.jpeg,.png,.gif',
      addRemoveLinks: true,
      maxFiles: 1
    };
    Object.assign(options, faOption);

    const dropzoneBasic = document.querySelector('#dropzone-basic');
    if (dropzoneBasic) {
      const myDropzone = new Dropzone(dropzoneBasic, options);
    }

  }

  // Basic Tags

  const tagifyBasicEl = document.querySelector('#ecommerce-product-tags');
  const TagifyBasic = new Tagify(tagifyBasicEl);

  // Flatpickr

  // Datepicker
  const date = new Date();

  const productDate = document.querySelector('.product-date');

  if (productDate) {
    productDate.flatpickr({
      disableMobile: "true",
      monthSelectorType: 'static',
      locale: 'fa',
      defaultDate: date
    });
  }
})();

//Jquery to handle the e-commerce product add page

$(function () {
  // Select2
  var select2 = $('.select2');
  if (select2.length) {
    select2.each(function () {
      var $this = $(this);
      $this.wrap('<div class="position-relative"></div>').select2({
        dropdownParent: $this.parent(),
        placeholder: $this.data('placeholder') // for dynamic placeholder
      });
    });
  }

  var formRepeater = $('.form-repeater');

  // Form Repeater
  // ! Using jQuery each loop to add dynamic id and class for inputs. You may need to improve it based on form fields.
  // -----------------------------------------------------------------------------------------------------------------

  if (formRepeater.length) {
    var row = 2;
    var col = 1;
    formRepeater.on('submit', function (e) {
      e.preventDefault();
    });
    formRepeater.repeater({
      show: function () {
        var fromControl = $(this).find('.form-control, .form-select');
        var formLabel = $(this).find('.form-label');

        fromControl.each(function (i) {
          var id = 'form-repeater-' + row + '-' + col;
          $(fromControl[i]).attr('id', id);
          $(formLabel[i]).attr('for', id);
          col++;
        });

        row++;
        $(this).slideDown();
        $('.select2-container').remove();
        $('.select2.form-select').select2({
          placeholder: 'متن جایگزین'
        });
        $('.select2-container').css('width', '100%');
        $('.form-repeater:first .form-select').select2({
          dropdownParent: $(this).parent(),
          placeholder: 'متن جایگزین'
        });
        $('.position-relative .select2').each(function () {
          $(this).select2({
            dropdownParent: $(this).closest('.position-relative')
          });
        });
      }
    });
  }
});
