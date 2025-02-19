/**
 * Charts Apex
 */

'use strict';

document.addEventListener('DOMContentLoaded', async function () {


  // بارگذاری اولیه داده‌ها
  loadSelectOptions();

  // رویداد تغییر برای select
  $('#select2Basic').on('change', function () {
    const selectedInsCode = $(this).val(); // گرفتن insCode انتخاب شده
    if (selectedInsCode) {
      updateChart(selectedInsCode); // به‌روزرسانی نمودار
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
          $('<option></option>').val(item.insCode).text(item.symbolName + '( ' + item.lVal30 +' )')
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
          // حالا می‌توانیم نمودار را با داده‌های جدید رسم کنیم
          createScatterChart(dividendData, ShareChangeData);
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

  // Color constant
  const chartColors = {
    column: {
      series1: '#826af9',
      series2: '#d2b0ff',
      bg: '#f8d3ff'
    },
    donut: {
      series1: '#fee802',
      series2: '#3fd0bd',
      series3: '#826bf8',
      series4: '#2b9bf4'
    },
    area: {
      series1: '#29dac7',
      series2: '#60f2ca',
      series3: '#a5f8cd'
    }
  };

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
      colors: [config.colors.warning, config.colors.primary],
      series: [
        {
          name: 'افزایش سرمایه',
          data: ShareChangeData
        },
        {
          name: '‌تقسیم سود',
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
        //tooltip: {
        //  enabled: true,
        //  style: {
        //    fontSize: '12px', // اندازه متن
        //    background: '#fff', // رنگ پس‌زمینه
        //  },
        //  onDatasetHover: {
        //    highlightDataSeries: true // هایلایت کردن سری داده
        //  },
        //  formatter: function (val, { series, seriesIndex, dataPointIndex, w }) {
        //    const symbolName = "data.symbolName"; // نام نماد
        //    return `${symbolName}: ${val}`; // ترکیب نام نماد و مقدار
        //  }
        //},
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
  if (typeof scatterChartEl !== undefined && scatterChartEl !== null) {
    const scatterChart = new ApexCharts(scatterChartEl, scatterChartConfig);
    scatterChart.render();
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
  // Candlestick Chart
  // --------------------------------------------------------------------
  const candlestickEl = document.querySelector('#candleStickChart'),
    candlestickChartConfig = {
      chart: {
        height: 410,
        type: 'candlestick',
        parentHeightOffset: 0,
        toolbar: {
          show: false
        }
      },
      series: [
        {
          data: [
            {
              x: new Date(1538778600000),
              y: [150, 170, 50, 100]
            },
            {
              x: new Date(1538780400000),
              y: [200, 400, 170, 330]
            },
            {
              x: new Date(1538782200000),
              y: [330, 340, 250, 280]
            },
            {
              x: new Date(1538784000000),
              y: [300, 330, 200, 320]
            },
            {
              x: new Date(1538785800000),
              y: [320, 450, 280, 350]
            },
            {
              x: new Date(1538787600000),
              y: [300, 350, 80, 250]
            },
            {
              x: new Date(1538789400000),
              y: [200, 330, 170, 300]
            },
            {
              x: new Date(1538791200000),
              y: [200, 220, 70, 130]
            },
            {
              x: new Date(1538793000000),
              y: [220, 270, 180, 250]
            },
            {
              x: new Date(1538794800000),
              y: [200, 250, 80, 100]
            },
            {
              x: new Date(1538796600000),
              y: [150, 170, 50, 120]
            },
            {
              x: new Date(1538798400000),
              y: [110, 450, 10, 420]
            },
            {
              x: new Date(1538800200000),
              y: [400, 480, 300, 320]
            },
            {
              x: new Date(1538802000000),
              y: [380, 480, 350, 450]
            }
          ]
        }
      ],
      xaxis: {
        type: 'datetime',
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        labels: {
          style: {
            colors: labelColor,
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
            colors: labelColor,
            fontSize: '13px'
          }
        }
      },
      grid: {
        borderColor: borderColor,
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
            upward: config.colors.success,
            downward: config.colors.danger
          }
        },
        bar: {
          columnWidth: '40%'
        }
      }
    };
  if (typeof candlestickEl !== undefined && candlestickEl !== null) {
    const candlestickChart = new ApexCharts(candlestickEl, candlestickChartConfig);
    candlestickChart.render();
  }

}
