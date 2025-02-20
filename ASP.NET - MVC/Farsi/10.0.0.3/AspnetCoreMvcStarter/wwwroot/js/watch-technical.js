/**
 * Charts Apex
 */

'use strict';
let scatterChart; // متغیر برای نگه‌داشتن مرجع به نمودار
let candlestickChart; // متغیر برای نگه‌داشتن مرجع به نمودار کندل استیک

document.addEventListener('DOMContentLoaded', async function () {
  // بارگذاری اولیه داده‌ها
  loadSelectOptions();

  // رویداد تغییر برای select
  $('#select2Basic').on('change', function () {
    const selectedInsCode = $(this).val(); // گرفتن insCode انتخاب شده
    if (selectedInsCode) {
      updateChart(selectedInsCode); // به‌روزرسانی نمودار
      loadCandlestickData(selectedInsCode); // بارگذاری داده‌های کندل استیک
    }
  });
});

// تابع برای بارگذاری گزینه‌ها در select
function loadSelectOptions() {
  $.ajax({
    url: '/api/TsetmcApi/GetInstrumentList', // آدرس سرویس شما
    method: 'GET',
    contentType: 'application/json',
    success: function (response) {
      $('#select2Basic').empty(); // پاک کردن محتوای قبلی

      response.forEach(item => {
        $('#select2Basic').append(
          $('<option></option>').val(item.insCode).text(item.symbolName + '( ' + item.lVal30 + ' )')
        );
      });

      $('#select2Basic').prepend(
        $('<option></option>').val('').text('لطفاً انتخاب کنید').prop('disabled', true).prop('selected', true)
      );

      $('#select2Basic').select2(); // به‌روزرسانی select2
    },
    error: function (xhr, status, error) {
      console.error('خطا در بارگذاری داده‌ها:', error);
    }
  });
}

function updateChart(insCode) {
  $.ajax({
    url: '/api/TsetmcApi/GetPriceAdjustList?insCode=' + insCode, // آدرس سرویس شما
    method: 'GET',
    contentType: 'application/json',
    success: function (response) {
      console.log(response);
      const data = response; // تبدیل پاسخ به JSON
      // استخراج مقادیر dEven و diff برای سری تقسیم سود
      const dividendData = data.map(item => [item.dEven, item.diff]);
      $.ajax({
        url: '/api/TsetmcApi/GetInstrumentShareChange?insCode=' + insCode, // آدرس سرویس شما
        method: 'GET',
        contentType: 'application/json',
        success: function (response) {
          console.log(response);
          const data = response; // تبدیل پاسخ به JSON
          // استخراج مقادیر dEven و diff برای سری تقسیم سود
          const ShareChangeData = data.map(item => [item.dEven, item.diff]);
          // اگر نمودار قبلاً ایجاد شده است، داده‌ها را به‌روزرسانی کنید
          if (scatterChart) {
            scatterChart.updateSeries([
              {
                name: 'افزایش سرمایه',
                data: ShareChangeData
              },
              {
                name: 'تقسیم سود',
                data: dividendData
              }
            ]);
          } else {
            // اگر نمودار هنوز ایجاد نشده است، آن را ایجاد کنید
            createScatterChart(dividendData, ShareChangeData);
          }
        },
        error: function (xhr, status, error) {
          console.error('خطا در ساخت داشبورد هوشمند:', error);
        }
      });
    },
    error: function (xhr, status, error) {
      console.error('خطا در ساخت داشبورد هوشمند:', error);
    }
  });
}

// تابع برای بارگذاری داده‌های کندل استیک
function loadCandlestickData(insCode) {
  $.ajax({
    url: '/api/TsetmcApi/GetClosingPriceDailyList?insCode=' + insCode, // آدرس سرویس شما
    method: 'GET',
    contentType: 'application/json',
    success: function (response) {
      console.log(response);
      // فرض می‌کنیم DEven به صورت YYYYMMDD است
      const candlestickData = response
        .map(item => {
          const year = parseInt(item.dEven.toString().substring(0, 4), 10);
          const month = parseInt(item.dEven.toString().substring(4, 6), 10) - 1; // ماه‌ها در جاوا اسکریپت از 0 شروع می‌شوند
          const day = parseInt(item.dEven.toString().substring(6, 8), 10);
          return {
            x: new Date(year, month, day), // تبدیل به تاریخ
            y: [item.open, item.high, item.low, item.close]
          };
        })
        .filter(item => {
          const [open, high, low, close] = item.y;
          return open !== 0 && high !== 0 && low !== 0 && close !== 0; // حذف کندل‌هایی که هر کدام صفر هستند
        });

      // رسم نمودار کندل استیک
      renderCandlestickChart(candlestickData);

    },
    error: function (xhr, status, error) {
      console.error('خطا در بارگذاری داده‌های کندل استیک:', error);
    }
  });
}

// تابع برای رسم نمودار کندل استیک
function renderCandlestickChart(candlestickData) {
  const candlestickEl = document.querySelector('#candleStickChart'),
    candlestickChartConfig = {
      chart: {
        height: 410,
        type: 'candlestick',
        parentHeightOffset: 0,
        toolbar: {
          show: true 
        },
        zoom: {
          enabled: true // فعال کردن زوم
        }
      },
      series: [
        {
          data: candlestickData // استفاده از داده‌های بارگذاری‌شده
        }
      ],
      xaxis: {
        tickAmount: 10,
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        labels: {
            formatter: function (val) {
              const date = new Date(val);
              const year = date.getFullYear();
              const month = String(date.getMonth() + 1).padStart(2, '0'); // به دست آوردن ماه با صفر جلو
              const day = String(date.getDate()).padStart(2, '0'); // به دست آوردن روز با صفر جلو
              return `${year}${month}${day}`; // فرمت YYYYMMDD
            },
          style: {
            colors: 'black', // رنگ برچسب‌ها
            fontSize: '13px'
          }
        }
      },
      yaxis: {
        tooltip: {
          enabled: true
        },
        labels: {
          style: {
            colors: 'black', // رنگ برچسب‌های محور y
            fontSize: '13px'
          }
        }
      },
      grid: {
        borderColor: '#e0e0e0', // رنگ مرز شبکه
        xaxis: {
          lines: {
            show: true
          }
        },
        padding: {
          top: -20
        }
      },
      plotOptions: {
        candlestick: {
          colors: {
            upward: '#00b746', // رنگ شمع‌های صعودی
            downward: '#ff0000' // رنگ شمع‌های نزولی
          }
        },
        bar: {
          columnWidth: '40%'
        }
      }
    };

  if (candlestickEl) {
    // اگر چارت قبلاً وجود دارد، آن را حذف کنید
    if (candlestickChart) {
      candlestickChart.destroy();
    }
    candlestickChart = new ApexCharts(candlestickEl, candlestickChartConfig);
    candlestickChart.render();
  }
}

function createScatterChart(dividendData, ShareChangeData) {
  let cardColor, headingColor, labelColor, borderColor, legendColor;

  if (isDarkStyle) {
    cardColor = config.colors_dark.cardColor;
    headingColor = config.colors_dark.headingColor;
    labelColor = config.colors_dark.textMuted;
    legendColor = config.colors_dark.bodyColor;
    borderColor = config.colors_dark.borderColor;
  } else {
    cardColor = config.colors.cardColor;
    headingColor = config.colors.headingColor;
    labelColor = config.colors.textMuted;
    legendColor = config.colors.bodyColor;
    borderColor = config.colors.borderColor;
  }

  // Scatter Chart
  // --------------------------------------------------------------------
  const scatterChartEl = document.querySelector('#scatterChart'),
    scatterChartConfig = {
      chart: {
        height: 400,
        type: 'scatter',
        zoom: {
          enabled: true,
          type: 'xy'
        },
        parentHeightOffset: 0,
        toolbar: {
          show: false
        }
      },
      grid: {
        borderColor: borderColor,
        xaxis: {
          lines: {
            show: true
          }
        }
      },
      legend: {
        show: true,
        position: 'top',
        horizontalAlign: 'start',
        labels: {
          colors: legendColor,
          useSeriesColors: false
        }
      },
      colors: [config.colors.primary, config.colors.warning],
      series: [
        {
          name: 'افزایش سرمایه',
          data: ShareChangeData
        },
        {
          name: 'تقسیم سود',
          data: dividendData
        },
      ],
      xaxis: {
        tickAmount: 10,
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        tooltip: {
          enabled: true,
          style: {
            fontSize: '12px', // اندازه متن
            background: '#fff', // رنگ پس‌زمینه
          },
          onDatasetHover: {
            highlightDataSeries: true // هایلایت کردن سری داده
          },
          formatter: function (val, { series, seriesIndex, dataPointIndex, w }) {
            const symbolName = w.globals.seriesNames[seriesIndex]; // نام نماد از سری‌ها
            const shamsiDate = convertToShamsi(val); // تبدیل تاریخ میلادی به شمسی
            return `<p>${symbolName}: ${shamsiDate}</p>`; // ترکیب نام نماد و تاریخ شمسی
          }
        },
        labels: {
          formatter: function (val) {
            return parseFloat(val).toFixed(0);
          },
          style: {
            colors: labelColor,
            fontSize: '13px'
          }
        }
      },
      yaxis: {
        labels: {
          style: {
            colors: labelColor,
            fontSize: '13px'
          }
        }
      }
    };

  if (scatterChartEl) {
    scatterChart = new ApexCharts(scatterChartEl, scatterChartConfig);
    scatterChart.render();
  }
}

// تابع برای تبدیل تاریخ میلادی به شمسی
function convertToShamsi(miladiDate) {
  const year = parseInt(miladiDate.toString().substring(0, 4), 10);
  const month = parseInt(miladiDate.toString().substring(4, 6), 10);
  const day = parseInt(miladiDate.toString().substring(6, 8), 10);

  // استفاده از PersianCalendar برای تبدیل به شمسی
  const persianCalendar = new Intl.DateTimeFormat('fa-IR', {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit',
  });

  const miladiDateObj = new Date(year, month - 1, day); // ماه‌ها در جاوا اسکریپت از 0 شروع می‌شوند
  const [shamsiYear, shamsiMonth, shamsiDay] = persianCalendar.format(miladiDateObj).split('/');

  return `${shamsiYear}/${shamsiMonth}/${shamsiDay}`;
}
