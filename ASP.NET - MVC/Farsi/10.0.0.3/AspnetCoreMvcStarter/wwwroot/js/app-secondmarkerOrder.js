/**
 * DataTables Extensions (jquery)
 */

'use strict';

$(async function () {

  const toastAnimationExample = document.querySelector('.toast-ex');
  let selectedType, selectedAnimation, selectedPlacement, toast, toastAnimation, toastPlacement;
  let intervalId; // متغیر برای نگهداری شناسه تایمر

  toastAnimationExample.classList.add(1);
  toastAnimationExample.querySelector('.ti').classList.add(0);

  toastAnimation = new bootstrap.Toast(toastAnimationExample);
  toastAnimation.show();
  var dt_sale = $('.dt-sale');
  var dt_buy = $('.dt-buy');

  if (dt_sale.length) {
    try {
      //const response = await fetch('https://cfai.ir/api/CfSecondaryMarketApi/GetSaleOrder', {
      const response = await fetch('https://localhost:7230/api/CfSecondaryMarketApi/GetSaleOrder', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error('Network response was not ok');
      }

      const data = await response.json(); // تبدیل پاسخ به JSON
      console.log(data);
      // ایجاد DataTable با داده‌های دریافتی
      dt_sale = dt_sale.DataTable({
        data: data, // فرض بر این است که داده‌ها در یک آرایه به نام 'data' قرار دارند
        columns: [
          { data: 'projectName' },
          { data: 'benefit' },
          { data: 'startTime' },
          { data: 'amount' },
          { data: 'pay' },
        ],
        // Scroll options
        scrollY: '200px',
        scrollX: true,
        dom: '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6 d-flex justify-content-center justify-content-md-end"f>>t<"row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>'
      });

      calculateTotalAmountsale();

    } catch (error) {
      console.log("Error fetching data:", error);
    }
  }

  if (dt_buy.length) {
    try {
      //const response = await fetch('https://cfai.ir/api/CfSecondaryMarketApi/GetBuyOrder', {
      const response = await fetch('https://localhost:7230/api/CfSecondaryMarketApi/GetBuyOrder', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error('Network response was not ok');
      }

      const data = await response.json(); // تبدیل پاسخ به JSON
      console.log(data);
      // ایجاد DataTable با داده‌های دریافتی
      dt_buy = dt_buy.DataTable({
        data: data, // فرض بر این است که داده‌ها در یک آرایه به نام 'data' قرار دارند
        columns: [
          { data: 'projectName' },
          { data: 'benefit' },
          { data: 'startTime' },
          { data: 'amount' },
          { data: 'pay' },
        ],
        // Scroll options
        scrollY: '200px',
        scrollX: true,
        dom: '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6 d-flex justify-content-center justify-content-md-end"f>>t<"row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>'
      });

      calculateTotalAmountbuy();


    } catch (error) {
      console.log("Error fetching data:", error);
    }
  }
  function calculateTotalAmountbuy() {
    const total = dt_buy.column(3).data().reduce((a, b) => {
      // تبدیل مقادیر به عدد
      const numA = parseFloat(a) || 0; // اگر تبدیل به عدد موفق نبود، 0 در نظر گرفته می‌شود
      const numB = parseFloat(b) || 0; // اگر تبدیل به عدد موفق نبود، 0 در نظر گرفته می‌شود
      return numA + numB; // جمع دو عدد
    }, 0); // مقدار اولیه 0    //const totalPercentage = (total / 100).toFixed(2) + '%'; // تبدیل به درصد (اگر نیاز دارید)
    $('#total-amount-buy').text(total.toLocaleString()); // نمایش مجموع در تگ <bdi>

    const total1 = dt_buy.column(4).data().reduce((a, b) => {
      // تبدیل مقادیر به عدد
      const numA = parseFloat(a) || 0; // اگر تبدیل به عدد موفق نبود، 0 در نظر گرفته می‌شود
      const numB = parseFloat(b) || 0; // اگر تبدیل به عدد موفق نبود، 0 در نظر گرفته می‌شود
      return numA + numB; // جمع دو عدد
    }, 0); // مقدار اولیه 0    //const totalPercentage = (total / 100).toFixed(2) + '%'; // تبدیل به درصد (اگر نیاز دارید)
    $('#total-pay-buy').text("(" + total1.toLocaleString() + ")"); // نمایش مجموع در تگ <bdi>




    calculateTotal();
  }


  function calculateTotalAmountsale() {
    const total = dt_sale.column(3).data().reduce((a, b) => {
      // تبدیل مقادیر به عدد
      const numA = parseFloat(a) || 0; // اگر تبدیل به عدد موفق نبود، 0 در نظر گرفته می‌شود
      const numB = parseFloat(b) || 0; // اگر تبدیل به عدد موفق نبود، 0 در نظر گرفته می‌شود
      return numA + numB; // جمع دو عدد
    }, 0); // مقدار اولیه 0 // محاسبه مجموع ستون 'amount'
    //const totalPercentage = (total / 100).toFixed(2) + '%'; // تبدیل به درصد (اگر نیاز دارید)
    $('#total-amount-sale').text(total.toLocaleString()); // نمایش مجموع در تگ <bdi>

    const total1 = dt_sale.column(4).data().reduce((a, b) => {
      // تبدیل مقادیر به عدد
      const numA = parseFloat(a) || 0; // اگر تبدیل به عدد موفق نبود، 0 در نظر گرفته می‌شود
      const numB = parseFloat(b) || 0; // اگر تبدیل به عدد موفق نبود، 0 در نظر گرفته می‌شود
      return numA + numB; // جمع دو عدد
    }, 0); // مقدار اولیه 0 // محاسبه مجموع ستون 'amount'
    //const totalPercentage = (total / 100).toFixed(2) + '%'; // تبدیل به درصد (اگر نیاز دارید)
    $('#total-pay-sale').text("(" + total1.toLocaleString() + ")"); // نمایش مجموع در تگ <bdi>

    calculateTotal();
  }
  // تابع برای محاسبه مجموع
  function calculateTotal() {
    // دریافت مقادیر از دو تگ
    const amount1 = parseFloat($('#total-amount-buy').text().replace(/,/g, '')) || 0; // تبدیل به عدد
    const amount2 = parseFloat($('#total-amount-sale').text().replace(/,/g, '')) || 0; // تبدیل به عدد
    const totalSum = amount1 + amount2;
    $('#total-amount').text(totalSum.toLocaleString()); // نمایش با فرمت مناسب
    const amount3 = parseFloat($('#total-pay-buy').text().replace('(', '').replace(')', '').replace(/,/g, '')   ) || 0; // تبدیل به عدد
    
    const amount4 = parseFloat($('#total-pay-sale').text().replace('(', '').replace(')', '').replace(/,/g, '')) || 0; // تبدیل به عدد
    const totalSumpay = amount3 + amount4;
    $('#total-pay').text("(" + totalSumpay.toLocaleString() + ")"); // نمایش با فرمت مناسب

    $('#total-all').text((totalSum * totalSumpay).toLocaleString() ); // نمایش با فرمت مناسب
  }

 


  const connection = new signalR.HubConnectionBuilder()
    .withUrl("/orderHub")
    .build();

  connection.on("ReceiveOrderUpdate", function (order ) {
    if (order.status === 1) {
      dt_sale.row.add(order).draw(); // اضافه کردن به DataTable اول
      calculateTotalAmountsale();

    } else {
      dt_buy.row.add(order).draw(); // اضافه کردن به DataTable دوم
      calculateTotalAmountbuy();

    }
    showToast(order);


  });

  function showToast(order) {
    const toastEl = document.getElementById('ordertoast');
    const toastBody = toastEl.querySelector('.toast-body');
    if (order.status === 1) {
      toastBody.textContent = "سفارش فروش"; // تغییر محتوای پیام
    } else {
      toastBody.textContent = "سفارش خرید"; // تغییر محتوای پیام
    }
    const toast = new bootstrap.Toast(toastEl);
    toast.show(); // نمایش Toast
  }

  connection.start().catch(function (err) {
    return console.error(err.toString());
  });


  document.getElementById('delete-buy').addEventListener('click',async function () {
    try {
      //const response = await fetch('https://cfai.ir/api/CfSecondaryMarketApi/DeleteBuy', {
      const response = await fetch('https://localhost:7230/api/CfSecondaryMarketApi/DeleteBuy', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error('Network response was not ok');
      }

      dt_buy.clear().draw(); // این خط تمام داده‌ها را حذف می‌کند و جدول را بروزرسانی می‌کند
      calculateTotalAmountbuy();

    } catch (error) {
      console.log("Error fetching data:", error);
    }
  });

  document.getElementById('delete-sale').addEventListener('click', async function () {
    try {
      //const response = await fetch('https://cfai.ir/api/CfSecondaryMarketApi/DeleteSale', {
      const response = await fetch('https://localhost:7230/api/CfSecondaryMarketApi/DeleteSale', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error('Network response was not ok');
      }

      dt_sale.clear().draw(); // این خط تمام داده‌ها را حذف می‌کند و جدول را بروزرسانی می‌کند
      calculateTotalAmountsale();

    } catch (error) {
      console.log("Error fetching data:", error);
    }
  });


  $('#automaticOrder').on('click', function () {
    if (!intervalId) { // اگر تایمر فعال نیست
      // تغییر متن دکمه
      $(this).find('span').text('توقف سفارشات اتوماتیک');
      $(this).addClass('btn-danger').removeClass('btn-primary');

      // شروع فراخوانی سرویس هر 100 میلی‌ثانیه (10 بار در ثانیه)
      intervalId = setInterval(insertOrder, 100);
    } else { // اگر تایمر فعال است
      // توقف فراخوانی
      clearInterval(intervalId);
      intervalId = null; // ریست کردن شناسه تایمر
      // تغییر متن دکمه به حالت اولیه
      $(this).find('span').text('سفارشات اتوماتیک');
      $(this).addClass('btn-primary').removeClass('btn-danger');

    }
  });

  function generateRandomOrder() {
    const projects = ["پروژه A", "پروژه B", "پروژه C", "پروژه D"];

    return {
      ProjectName: projects[Math.floor(Math.random() * projects.length)],
      Benefit: (Math.floor(Math.random() * (45 - 30 + 1)) + 30).toString(),
      StartTime: new Date().toLocaleTimeString('fa-IR', {
        hour: '2-digit',
        minute: '2-digit',  
        hour12: false // برای نمایش به صورت 24 ساعته
      }), // زمان شروع به فرمت ISO
      Amount: (Math.floor(Math.random() * (2000 - 100 + 1)) + 100).toString(),
      Pay: (Math.floor(Math.random() * (190 - 90 + 1)) + 90).toString(),
      Status: Math.floor(Math.random() * 2)
    };
  }

  function insertOrder() {
    const newOrder = generateRandomOrder(); // تولید داده‌های تصادفی
    console.log(newOrder);
    $.ajax({
      url: '/api/CfSecondaryMarketApi/InsertOrder', // آدرس سرویس شما
      method: 'POST',
      contentType: 'application/json',
      data: JSON.stringify(newOrder),
      success: function (response) {
        console.log('سفارش با موفقیت اضافه شد:', response);
      },
      error: function (xhr, status, error) {
        console.error('خطا در اضافه کردن سفارش:', error);
      }
    });
  }

  // Filter form control to default size
  // ? setTimeout used for multilingual table initialization
  setTimeout(() => {
    $('.dataTables_filter .form-control').removeClass('form-control-sm');
    $('.dataTables_length .form-select').removeClass('form-select-sm');
  }, 200);
});
