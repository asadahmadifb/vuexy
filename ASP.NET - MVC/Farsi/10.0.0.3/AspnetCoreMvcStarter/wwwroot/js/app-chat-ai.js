/**
 * App Chat
 */

'use strict';

document.addEventListener('DOMContentLoaded', async function () {
    $.ajax({
      url: '/api/CfApi', // آدرس سرویس شما
      method: 'GET',
      contentType: 'application/json',
      success:function (response) {
        console.log(response);
        const data = response; // تبدیل پاسخ به JSON
        // نمایش پاسخ هوش مصنوعی
        createChatContactList(data);      },
      error: function (xhr, status, error) {
        console.error('خطا در ساخت داشبورد هوشمند:', error);
      }
    });
});

function createChatContactList(items) {
      console.log(items);
      // انتخاب عنصر <div class="row"> موجود
      const rowDiv = $('#exampleRow');
      // تابع برای تعیین کلاس‌های Bootstrap بر اساس تعداد سرستون‌ها
      function getColumnClass(numColumns) {
        if (numColumns >= 4) return 'col-12';
        if (numColumns === 3) return 'col-lg-6 col-md-12 col-x-12';
        if (numColumns === 2) return 'col-lg-4 col-md-6 col-x-12';
        if (numColumns === 1) return 'col-sm-6 col-lg-3 ';
      }
      // برای هر آیتم در آرایه items، یک کارت جدید ایجاد کنید
      items.forEach(item => {
        // ایجاد عنصر <div> برای کارت
        //<small class="text-muted">${item.response}</small>
        const crowdfundingData = JSON.parse(item.crowdfundingdata); // فرض بر این است که این داده‌ها یک شیء JSON است
        const projectKeys = Object.keys(crowdfundingData); // کلیدهای پروژه‌ها
        const projectValues = Object.values(crowdfundingData); // مقادیر پروژه‌ها

        // استخراج سرستون‌ها از اولین پروژه (برای داینامیک بودن)
        const headers = Object.keys(projectValues[0]);
        const numColumns = headers.length; // تعداد سرستون‌ها

        // ایجاد جدول داینامیک
        const tableHeaders = headers.map(header => `<th>${header}</th>`).join('');
        const tableRows = projectValues.map(project => {
          const rowData = headers.map(header => {
            // تبدیل مقدار به عدد و فرمت کردن آن
            const value = project[header];
            // بررسی اینکه آیا مقدار عددی است یا خیر
            const formattedValue = typeof value === 'number' ? value.toLocaleString() : value;
            return `<td>${formattedValue}</td>`;
          }).join('');
          return `<tr>${rowData}</tr>`;
        });
        // تعیین کلاس مناسب برای عرض کارت
        const columnClass = getColumnClass(numColumns);
        let cardContainer = ``;
        if (numColumns === 1 && projectValues.length === 1) {
          const colors = [
            '-primary',
            '-warning',
            '-danger',
            '-info'
          ];
          const randomColor = colors[Math.floor(Math.random() * colors.length)];

          cardContainer = `
              <div class="${columnClass} mb-4">
                  <div class="card card-border-shadow${randomColor}">
                    <div class="card-body">
                      <div class="d-flex align-items-center mb-2 pb-1">
                        <div class="avatar me-2">
                          <span class="avatar-initial rounded bg-label${randomColor}">
                            <i class="ti ti-truck ti-md"></i>
                          </span>
                        </div>
		                    <h4 class="ms-1 mb-0" id="OtherStartedValue">${tableRows}</h4>
                      </div>
		                  <p class="mb-1">${item.question}</p>
                      </div>
                  </div>
              </div>
           `;
        }
        if (numColumns === 1 && projectValues.length > 1) {
          cardContainer = `
            <div class="${columnClass} mb-4">
                <div class="card">
                    <div class="card-header d-flex justify-content-between">
                        <div class="card-title mb-0">
                            <h5 class="mb-0">${item.question}</h5>

                        </div>
                        <div class="dropdown">
                            <button aria-expanded="false" aria-haspopup="true" class="btn p-0" data-bs-toggle="dropdown" id="earningReportsTabsId" type="button">
                                <i class="ti ti-dots-vertical ti-sm text-muted"></i>
                            </button>
                            <div aria-labelledby="earningReportsTabsId" class="dropdown-menu dropdown-menu-end">
                                <a class="dropdown-item" href="javascript:void(0);">موارد بیشتر</a>
                                <a class="dropdown-item" href="javascript:void(0);">حذف</a>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="d-flex overflow-hidden" >
                          <div class="flex-grow-1" style="overflow-x:auto; white-space: nowrap;">
                              <div class="table-responsive" >
                                  <table class="table table-bordered" id="projects-table" style="line-height: 15px !important;">
                                  <thead>
                                      <tr>
                                      ${tableHeaders}
                                      </tr>
                                  </thead>
                                  <tbody>
                                  ${tableRows}
                                  </tbody>
                              </table>
                              </div>
                          </div>
                      </div>
                    </div>
                </div>
            </div>
          `;
        }
        if (numColumns >= 2) {
          cardContainer = `
            <div class="${columnClass} mb-4">
                <div class="card">
                    <div class="card-header d-flex justify-content-between">
                        <div class="card-title mb-0">
                            <h5 class="mb-0">${item.question}</h5>

                        </div>
                        <div class="dropdown">
                            <button aria-expanded="false" aria-haspopup="true" class="btn p-0" data-bs-toggle="dropdown" id="earningReportsTabsId" type="button">
                                <i class="ti ti-dots-vertical ti-sm text-muted"></i>
                            </button>
                            <div aria-labelledby="earningReportsTabsId" class="dropdown-menu dropdown-menu-end">
                                <a class="dropdown-item" href="javascript:void(0);">موارد بیشتر</a>
                                <a class="dropdown-item" href="javascript:void(0);">حذف</a>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="d-flex overflow-hidden" >
                          <div class="flex-grow-1" style="overflow-x:auto; white-space: nowrap;">
                              <div class="table-responsive" >
                                  <table class="table table-bordered" id="projects-table" style="line-height: 15px !important;">
                                  <thead>
                                      <tr>
                                      ${tableHeaders}
                                      </tr>
                                  </thead>
                                  <tbody>
                                  ${tableRows}
                                  </tbody>
                              </table>
                              </div>
                          </div>
                      </div>
                    </div>
                </div>
            </div>
          `;
        }


        // اضافه کردن کارت به <div class="row">
        rowDiv.append(cardContainer);
      });
    }
