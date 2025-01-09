/**
 * App Chat
 */

'use strict';

document.addEventListener('DOMContentLoaded', async function () {
  try {
    const response = await fetch('https://localhost:7230/api/CfApi', {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    });

    if (!response.ok) {
      throw new Error('Network response was not ok');
    }

    const data = await response.json(); // تبدیل پاسخ به JSON
    // نمایش پاسخ هوش مصنوعی
    createChatContactList(data);
  } catch (error) {
    console.log("Error fetching data:", error);
  }
});
function createChatContactList(items) {
      console.log(items);
      // انتخاب عنصر <div class="row"> موجود
      const rowDiv = $('#exampleRow');
      // تابع برای تعیین کلاس‌های Bootstrap بر اساس تعداد سرستون‌ها
      function getColumnClass(numColumns) {
        if (numColumns >= 4) return 'col-12';
        if (numColumns === 3) return 'col-6 col-md-12 col-x-12';
        if (numColumns === 2) return 'col-4 col-md-6 col-x-12';
        if (numColumns === 1) return 'col-3 col-md-6 col-x-12';
        return 'col-12'; // برای تعداد بیشتر از 4
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
          const rowData = headers.map(header => `<td>${project[header]}</td>`).join('');
          return `<tr>${rowData}</tr>`;
        }).join('');
        // تعیین کلاس مناسب برای عرض کارت
        const columnClass = getColumnClass(numColumns);
      const cardContainer = `
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
            //<pre class="formatted-response">${item.crowdfundingdata}</pre> <!--استفاده از < pre > برای فرمت‌بندی-- >

        // اضافه کردن کارت به <div class="row">
        rowDiv.append(cardContainer);
      });
    }
