/**
 *  Logistics Dashboard
 */

'use strict';

document.addEventListener('DOMContentLoaded', async function () {

  let labelColor, legendColor, borderColor, headingColor;
  if (isDarkStyle) {
    labelColor = config.colors_dark.textMuted;
    legendColor = config.colors_dark.bodyColor;
    borderColor = config.colors_dark.borderColor;
    headingColor = config.colors_dark.headingColor;

  } else {
    labelColor = config.colors.textMuted;
    legendColor = config.colors.bodyColor;
    borderColor = config.colors.borderColor;
    headingColor = config.colors.headingColor;

  }

  $.ajax({
    url: '/api/CfApi/GetProjectFinancingSummary', // آدرس سرویس شما
    method: 'GET',
    contentType: 'application/json',
    success: async function (response) {
      console.log(response);
      const data = response; // تبدیل پاسخ به JSON
      var htmlContent = '';
      // رنگ‌ها و آیکون‌ها برای هر رکورد
      const cardStyles = [
        { color: 'bg-label-primary', icon: 'ti ti-truck' },
        { color: 'bg-label-success', icon: 'ti ti-wallet' },
        { color: 'bg-label-warning', icon: 'ti ti-pulse' },
        { color: 'bg-label-danger', icon: 'ti ti-alert-triangle' }
      ];
      // ایجاد HTML برای هر رکورد
      data.forEach(function (item, index) {
        const style = cardStyles[index % cardStyles.length]; // انتخاب رنگ و آیکون بر اساس اندیس
          
        htmlContent += `
                <div class="col-sm-6 col-lg-3 mb-4">
                    <div class="card card-border-shadow-${style.color}">
                        <div class="card-body">
                            <div class="d-flex align-items-center mb-2 pb-1">
                                <div class="avatar me-2">
                                    <span class="avatar-initial rounded ${style.color}">
                                        <i class="ti ti-truck ti-md"></i>
                                    </span>
                                </div>
                                <h4 class="ms-1 mb-0">سال ${item.year}</h4>
                            </div>
                            <p class="mb-1">
                                تعداد طرح‌ها
                                <span id="totalProjects">${item.totalProjects}</span>
                            </p>
                            <p class="mb-0">
                                <small class="text-muted">
                                    مبلغ سرمایه گذاری
                                </small>
                                <span class="fw-medium me-1">
                                    <bdi id="totalInvestmentAmount">${item.totalInvestmentAmount.toLocaleString()}</bdi>
                                </span>
                            </p>
                            <p class="mb-0">
                                <small class="text-muted">
                                    تعداد سرمایه گذاری
                                </small>
                                <span class="fw-medium me-1">
                                    <bdi id="totalInvestments">${item.totalInvestments}</bdi>
                                </span>
                            </p>
                            <p class="mb-0">
                                <small class="text-muted">
                                    تعداد سرمایه گذاران یونیک
                                </small>
                                <span class="fw-medium me-1">
                                    <bdi id="uniqueInvestors">${item.uniqueInvestors}</bdi>
                                </span>
                            </p>
                        </div>
                    </div>
                </div>`;
      });

      // قرار دادن HTML در div مربوطه
      $('#your-container-id').html(htmlContent);

    },
    error: function (xhr, status, error) {
      console.log("Error fetching data:", error);
    }
  });

  $.ajax({

    url: '/api/CfApi/GetProjectStatusCounts', // آدرس سرویس شما
    method: 'GET',
    contentType: 'application/json',
    success: async function (response) {
      console.log(response);
      const data = response; // تبدیل پاسخ به JSON
      // فرض بر این است که داده‌ها به صورت آرایه‌ای از اشیاء برگشت داده می‌شوند
      var totalProjects = 0; // تعداد کل پروژه‌ها
      var projectStatusHtml = '';
      // رنگ‌ها و آیکون‌ها
      const badges = [
        { color: 'bg-label-success', icon: 'ti ti-mail' },
        { color: 'bg-label-danger', icon: 'ti ti-mail' },
        { color: 'bg-label-warning', icon: 'ti ti-exclamation-circle' },
        { color: 'bg-label-info', icon: 'ti ti-mail' },
        { color: 'bg-label-primary', icon: 'ti ti-check' },
        { color: 'bg-label-secondary', icon: 'ti ti-star' }
      ];
      // محاسبه تعداد کل پروژه‌ها
      data.forEach(function (item) {
        totalProjects += item.projectCount;
      });
      projectStatusHtml += `
                <div class="col-xl-6 col-md-6 mb-4">
                    <div class="card h-100">
                        <div class="card-header d-flex justify-content-between">
                            <div class="card-title mb-0">
                                <h5 class="mb-0">وضعیت طرح‌های تامین مالی</h5>
                                <small class="text-muted">${totalProjects.toLocaleString()} تعداد کل طرح‌ها</small>
                            </div>
                        </div>
                        <div class="card-body">
                            <ul class="p-0 m-0">
                            `;
      // ایجاد HTML برای هر وضعیت
      data.forEach(function (item) {
        // انتخاب رنگ و آیکون به صورت دورانی
        const randomIndex = Math.floor(Math.random() * badges.length);
        const badge = badges[randomIndex];

        // نوار پیشرفت جدید
        // نوار پیشرفت جدید
        const progressBar =
          '<div class="progress" style="height: 8px; width: 100%; margin-right: 10px;">' +
          '<div class="progress-bar" role="progressbar" style="width:' +
          item.percentage +
          '%;" aria-valuenow="' +
          item.percentage +
          '" aria-valuemin="0" aria-valuemax="100"></div>' +
          '</div>';

        projectStatusHtml += `
                                  <li class="mb-1 pb-1 d-flex align-items-center" style="flex-wrap: nowrap;">
                                    <div class="badge ${badge.color} rounded p-2"><i class="${badge.icon} ti-sm"></i></div>
                                    <h6 class="mb-0 ms-3 text-truncate" style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;">${item.projectStatus}</h6>
                                    <div class="ms-auto d-flex align-items-center" style="flex-shrink: 0;">
                                        <p class="mb-0 fw-medium ms-3">${item.projectCount.toLocaleString()}</p>
                                        <p class="ms-3 text-success mb-0">${item.percentage}%</p>
                                    </div>
                                </li>

                           `;
      });
      projectStatusHtml += `
                            </ul >
                        </div >
                    </div >
                </div >`;
      // قرار دادن HTML در div مربوطه
      $('#project-status-container').html(projectStatusHtml);
    },
    error: function (xhr, status, error) {
      console.log("Error fetching data:", error);
    }
  });

  $.ajax({
    url: '/api/CfApi/GetUnderwritingByYear', // آدرس سرویس شما
    method: 'GET',
    contentType: 'application/json',
    success: function (response) {
      console.log(response);
      const data = JSON.stringify(response); // تبدیل پاسخ به JSON
      // نمایش پاسخ هوش مصنوعی
      createChatContactList(data);
    },
    error: function (xhr, status, error) {
      console.error('خطا در ساخت داشبورد هوشمند:', error);
    }
  });
  function createChatContactList(data2) {

    //const earningReportsChart = JSON.parse(data);
    const earningReportsChart = JSON.parse(data2);

    // Earning Reports Tabs Orders
    // --------------------------------------------------------------------
    const earningReportsTabsOrdersEl = document.querySelector('#earningReportsTabsOrders'),
      earningReportsTabsOrdersConfig = EarningReportsBarChart(
        earningReportsChart[0].chart_data,
        earningReportsChart[0].active_option
      );
    if (typeof earningReportsTabsOrdersEl !== undefined && earningReportsTabsOrdersEl !== null) {
      const earningReportsTabsOrders = new ApexCharts(earningReportsTabsOrdersEl, earningReportsTabsOrdersConfig);
      earningReportsTabsOrders.render();
    }
    // Earning Reports Tabs Sales
    // --------------------------------------------------------------------
    const earningReportsTabsSalesEl = document.querySelector('#earningReportsTabsSales'),
      earningReportsTabsSalesConfig = EarningReportsBarChart(
        earningReportsChart[1].chart_data,
        earningReportsChart[1].active_option
      );
    if (typeof earningReportsTabsSalesEl !== undefined && earningReportsTabsSalesEl !== null) {
      const earningReportsTabsSales = new ApexCharts(earningReportsTabsSalesEl, earningReportsTabsSalesConfig);
      earningReportsTabsSales.render();
    }
    // Earning Reports Tabs Profit
    // --------------------------------------------------------------------
    const earningReportsTabsProfitEl = document.querySelector('#earningReportsTabsProfit'),
      earningReportsTabsProfitConfig = EarningReportsBarChart(
        earningReportsChart[2].chart_data,
        earningReportsChart[2].active_option
      );
    if (typeof earningReportsTabsProfitEl !== undefined && earningReportsTabsProfitEl !== null) {
      const earningReportsTabsProfit = new ApexCharts(earningReportsTabsProfitEl, earningReportsTabsProfitConfig);
      earningReportsTabsProfit.render();
    }
    // Earning Reports Tabs Income
    // --------------------------------------------------------------------
    const earningReportsTabsIncomeEl = document.querySelector('#earningReportsTabsIncome'),
      earningReportsTabsIncomeConfig = EarningReportsBarChart(
        earningReportsChart[3].chart_data,
        earningReportsChart[3].active_option
      );
    if (typeof earningReportsTabsIncomeEl !== undefined && earningReportsTabsIncomeEl !== null) {
      const earningReportsTabsIncome = new ApexCharts(earningReportsTabsIncomeEl, earningReportsTabsIncomeConfig);
      earningReportsTabsIncome.render();
    }
  }

  function EarningReportsBarChart(arrayData, highlightData) {
    const basicColor = config.colors_label.primary,
      highlightColor = config.colors.primary;
    var colorArr = [];

    for (let i = 0; i < arrayData.length; i++) {
      if (i === highlightData) {
        colorArr.push(highlightColor);
      } else {
        colorArr.push(basicColor);
      }
    }

    const earningReportBarChartOpt = {
      chart: {
        height: 258,
        parentHeightOffset: 0,
        type: 'bar',
        toolbar: {
          show: false
        }
      },
      plotOptions: {
        bar: {
          columnWidth: '32%',
          startingShape: 'rounded',
          borderRadius: 7,
          distributed: true,
          dataLabels: {
            position: 'top'
          }
        }
      },
      grid: {
        show: false,
        padding: {
          top: 0,
          bottom: 0,
          left: -10,
          right: -10
        }
      },
      colors: colorArr,
      dataLabels: {
        enabled: true,
        formatter: function (val) {
          return val + '';
        },
        offsetY: -20,
        style: {
          fontSize: '15px',
          colors: [legendColor],
          fontWeight: '500',
          fontFamily: 'font-primary'
        }
      },
      series: [
        {
          data: arrayData
        }
      ],
      legend: {
        show: false
      },
      tooltip: {
        enabled: false
      },
      xaxis: {
        categories: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر', 'دی', 'بهمن', 'اسفند'],
        axisBorder: {
          show: true,
          color: borderColor
        },
        axisTicks: {
          show: false
        },
        labels: {
          style: {
            colors: labelColor,
            fontSize: '13px',
            fontFamily: 'font-primary'
          }
        }
      },
      yaxis: {
        labels: {
          offsetX: -15,
          formatter: function (val) {
            return parseInt(val / 1) + '';
          },
          style: {
            fontSize: '13px',
            colors: labelColor,
            fontFamily: 'font-primary'
          },
          min: 0,
          max: 60000,
          tickAmount: 6
        }
      },
      responsive: [
        {
          breakpoint: 1441,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '41%'
              }
            }
          }
        },
        {
          breakpoint: 590,
          options: {
            plotOptions: {
              bar: {
                columnWidth: '61%',
                borderRadius: 5
              }
            },
            yaxis: {
              labels: {
                show: false
              }
            },
            grid: {
              padding: {
                right: 0,
                left: -20
              }
            },
            dataLabels: {
              style: {
                fontSize: '12px',
                fontWeight: '400'
              }
            }
          }
        }
      ]
    };
    return earningReportBarChartOpt;
  }

  // Chart Colors
  const chartColors = {
    donut: {
      series1: config.colors.success,
      series2: '#28c76fb3',
      series3: '#28c76f80',
      series4: config.colors_label.success
    },
    line: {
      series1: config.colors.warning,
      series2: config.colors.primary,
      series3: '#7367f029'
    }
  };

  $.ajax({
    url: '/api/CfApi/GetProjectCountByMonth', // آدرس سرویس شما
    method: 'GET',
    contentType: 'application/json',
    success: async function (response) {
      const shipmentData = response; // تبدیل پاسخ به JSON
      console.log(shipmentData); // برای بررسی داده‌ها
      // Shipment statistics Chart
      // --------------------------------------------------------------------
      const shipmentEl = document.querySelector('#shipmentStatisticsChart'),
        shipmentConfig = {
          series: [
            {
              name: 'میزان سرمایه گذاری شده',
              type: 'column',
              data: shipmentData.requiredCapital
            },
            {
              name: 'تعداد پروژه ها',
              type: 'line',
              data: shipmentData.investedCapital
            }
          ],
          chart: {
            height: 270,
            type: 'line',
            stacked: false,
            parentHeightOffset: 0,
            toolbar: {
              show: false
            },
            zoom: {
              enabled: false
            }
          },
          markers: {
            size: 4,
            colors: [config.colors.white],
            strokeColors: chartColors.line.series2,
            hover: {
              size: 6
            },
            borderRadius: 4
          },
          stroke: {
            curve: 'smooth',
            width: [0, 3],
            lineCap: 'round'
          },
          legend: {
            show: true,
            position: 'bottom',
            markers: {
              width: 8,
              height: 8,
              offsetX: -3
            },
            height: 40,
            offsetY: 10,
            itemMargin: {
              horizontal: 10,
              vertical: 0
            },
            fontSize: '15px',
            fontFamily: 'font-primary',
            fontWeight: 400,
            labels: {
              colors: headingColor,
              useSeriesColors: false
            },
            offsetY: 10
          },
          grid: {
            strokeDashArray: 8
          },
          colors: [chartColors.line.series1, chartColors.line.series2],
          fill: {
            opacity: [1, 1]
          },
          plotOptions: {
            bar: {
              columnWidth: '30%',
              startingShape: 'rounded',
              endingShape: 'rounded',
              borderRadius: 4
            }
          },
          dataLabels: {
            enabled: false
          },
          xaxis: {
            tickAmount: 10,
            categories: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر', 'دی','بهمن','اسفند'],
            labels: {
              style: {
                colors: labelColor,
                fontSize: '13px',
                fontFamily: 'font-primary',
                fontWeight: 400
              }
            },   
            axisBorder: { 
              show: false
            },
            axisTicks: {
              show: false
            }
          }, 
          yaxis: {
            tickAmount: 4,
            //min: 1000000000000,
            //max: 2262390059000 ,
            labels: {
              style: {
                colors: labelColor,
                fontSize: '13px',
                fontFamily: 'font-primary',
                fontWeight: 400
              },
              formatter: function (val) {
                return val ;
              }
            }
          },
          responsive: [
            {
              breakpoint: 1400,
              options: {
                chart: {
                  height: 270
                },
                xaxis: {
                  labels: {
                    style: {
                      fontSize: '10px'
                    }
                  }
                },
                legend: {
                  itemMargin: {
                    vertical: 0,
                    horizontal: 10
                  },
                  fontSize: '13px',
                  offsetY: 12
                }
              }
            },
            {
              breakpoint: 1399,
              options: {
                chart: {
                  height: 415
                },
                plotOptions: {
                  bar: {
                    columnWidth: '50%'
                  }
                }
              }
            },
            {
              breakpoint: 982,
              options: {
                plotOptions: {
                  bar: {
                    columnWidth: '30%'
                  }
                }
              }
            }, 
            {
              breakpoint: 480,
              options: {
                chart: {
                  height: 250
                },
                legend: {
                  offsetY: 7
                }
              }
            }
          ]
        };
      if (typeof shipmentEl !== undefined && shipmentEl !== null) {
        const shipment = new ApexCharts(shipmentEl, shipmentConfig);
        shipment.render();
      }
    },
    error: function (xhr, status, error) {
      console.log("Error fetching data:", error);
    }
  });

  // Reasons for delivery exceptions Chart
  // --------------------------------------------------------------------
  const deliveryExceptionsChartE1 = document.querySelector('#deliveryExceptionsChart'),
    deliveryExceptionsChartConfig = {
      chart: {
        height: 420,
        parentHeightOffset: 0,
        type: 'donut'
      },
      labels: ['آدرس اشتباه', 'هوا نامناسب', 'تعطیلات', 'تصادفات'],
      series: [13, 25, 22, 40],
      colors: [
        chartColors.donut.series1,
        chartColors.donut.series2,
        chartColors.donut.series3,
        chartColors.donut.series4
      ],
      stroke: {
        width: 0
      },
      dataLabels: {
        enabled: false,
        formatter: function (val, opt) {
          return parseInt(val) + '%';
        }
      },
      legend: {
        show: true,
        position: 'bottom',
        offsetY: 10,
        markers: {
          width: 8,
          height: 8,
          offsetX: -3
        },
        itemMargin: {
          horizontal: 15,
          vertical: 5
        },
        fontSize: '13px',
        fontFamily: 'font-primary',
        fontWeight: 400,
        labels: {
          colors: headingColor,
          useSeriesColors: false
        }
      },
      tooltip: {
        theme: false
      },
      grid: {
        padding: {
          top: 15
        }
      },
      states: {
        hover: {
          filter: {
            type: 'none'
          }
        }
      },
      plotOptions: {
        pie: {
          donut: {
            size: '77%',
            labels: {
              show: true,
              value: {
                fontSize: '26px',
                fontFamily: 'font-primary',
                color: headingColor,
                fontWeight: 500,
                offsetY: -30,
                formatter: function (val) {
                  return parseInt(val) + '%';
                }
              },
              name: {
                offsetY: 20,
                fontFamily: 'font-primary'
              },
              total: {
                show: true,
                fontSize: '.75rem',
                label: 'میانگین',
                color: labelColor,
                formatter: function (w) {
                  return '30%';
                }
              }
            }
          }
        }
      },
      responsive: [
        {
          breakpoint: 420,
          options: {
            chart: {
              height: 360
            }
          }
        }
      ]
    };
  if (typeof deliveryExceptionsChartE1 !== undefined && deliveryExceptionsChartE1 !== null) {
    const deliveryExceptionsChart = new ApexCharts(deliveryExceptionsChartE1, deliveryExceptionsChartConfig);
    deliveryExceptionsChart.render();
  }
});

// DataTable (jquery)
// --------------------------------------------------------------------

