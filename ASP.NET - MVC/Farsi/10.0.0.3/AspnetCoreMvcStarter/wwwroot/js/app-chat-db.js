/**
 * App Chat
 */

'use strict';

document.addEventListener('DOMContentLoaded',async  function () {
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


   // ایجاد لیست و اضافه کردن به <ul> موجود

    const chatContactsBody = document.querySelector('.app-chat-contacts .sidebar-body'),
      chatContactListItems = [].slice.call(
        document.querySelectorAll('.chat-contact-list-item:not(.chat-contact-list-item-title)')
      ),
      chatHistoryBody = document.querySelector('.chat-history-body'),
      chatSidebarLeftBody = document.querySelector('.app-chat-sidebar-left .sidebar-body'),
      chatSidebarRightBody = document.querySelector('.app-chat-sidebar-right .sidebar-body'),
      chatUserStatus = [].slice.call(document.querySelectorAll(".form-check-input[name='chat-user-status']")),
      chatSidebarLeftUserAbout = $('.chat-sidebar-left-user-about'),
      formSendMessage = document.querySelector('.form-send-message'),
      messageInput = document.querySelector('.message-input'),
      searchInput = document.querySelector('.chat-search-input'),

      speechToText = $('.speech-to-text'), // ! jQuery dependency for speech to text
      userStatusObj = {
        active: 'avatar-online',
        offline: 'avatar-offline',
        away: 'avatar-away',
        busy: 'avatar-busy'
      };

    document.getElementById('delete-button').addEventListener('click', function () {
      fetch('/cf/deletehistory', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      }).then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json(); // تبدیل پاسخ به JSON
      })
        .then(data => {
          // نمایش پاسخ هوش مصنوعی
          createChatContactList(data);

        })
        .catch(error => {
          console.error("Error fetching data:", error);
        });
      alert('سلام');
    });

    // Initialize PerfectScrollbar
    // ------------------------------

    // Chat contacts scrollbar
    if (chatContactsBody) {
      new PerfectScrollbar(chatContactsBody, {
        wheelPropagation: false,
        suppressScrollX: true
      });
    }

    // Chat history scrollbar
    if (chatHistoryBody) {
      new PerfectScrollbar(chatHistoryBody, {
        wheelPropagation: false,
        suppressScrollX: true
      });
    }

    // Sidebar left scrollbar
    if (chatSidebarLeftBody) {
      new PerfectScrollbar(chatSidebarLeftBody, {
        wheelPropagation: false,
        suppressScrollX: true
      });
    }

    // Sidebar right scrollbar
    if (chatSidebarRightBody) {
      new PerfectScrollbar(chatSidebarRightBody, {
        wheelPropagation: false,
        suppressScrollX: true
      });
    }

    // Scroll to bottom function
    function scrollToBottom() {
      chatHistoryBody.scrollTo(0, chatHistoryBody.scrollHeight);
    }
    scrollToBottom();

    // User About Maxlength Init
    if (chatSidebarLeftUserAbout.length) {
      chatSidebarLeftUserAbout.maxlength({
        alwaysShow: true,
        warningClass: 'label label-success bg-success text-white',
        limitReachedClass: 'label label-danger',
        separator: '/',
        validate: true,
        threshold: 120
      });
    }

    // Update user status
    chatUserStatus.forEach(el => {
      el.addEventListener('click', e => {
        let chatLeftSidebarUserAvatar = document.querySelector('.chat-sidebar-left-user .avatar'),
          value = e.currentTarget.value;
        //Update status in left sidebar user avatar
        chatLeftSidebarUserAvatar.removeAttribute('class');
        Helpers._addClass('avatar avatar-xl ' + userStatusObj[value] + '', chatLeftSidebarUserAvatar);
        //Update status in contacts sidebar user avatar
        let chatContactsUserAvatar = document.querySelector('.app-chat-contacts .avatar');
        chatContactsUserAvatar.removeAttribute('class');
        Helpers._addClass('flex-shrink-0 avatar ' + userStatusObj[value] + ' me-3', chatContactsUserAvatar);
      });
    });

    // Select chat or contact
    chatContactListItems.forEach(chatContactListItem => {
      // Bind click event to each chat contact list item
      chatContactListItem.addEventListener('click', e => {
        // Remove active class from chat contact list item
        chatContactListItems.forEach(chatContactListItem => {
          chatContactListItem.classList.remove('active');
        });
        // Add active class to current chat contact list item
        e.currentTarget.classList.add('active');
      });
    });

    // Filter Chats
    if (searchInput) {
      searchInput.addEventListener('keyup', e => {
        let searchValue = e.currentTarget.value.toLowerCase(),
          searchChatListItemsCount = 0,
          searchContactListItemsCount = 0,
          chatListItem0 = document.querySelector('.chat-list-item-0'),
          contactListItem0 = document.querySelector('.contact-list-item-0'),
          searchChatListItems = [].slice.call(
            document.querySelectorAll('#chat-list li:not(.chat-contact-list-item-title)')
          ),
          searchContactListItems = [].slice.call(
            document.querySelectorAll('#contact-list li:not(.chat-contact-list-item-title)')
          );

        // Search in chats
        searchChatContacts(searchChatListItems, searchChatListItemsCount, searchValue, chatListItem0);
      });
    }

    // Search chat and contacts function
    function searchChatContacts(searchListItems, searchListItemsCount, searchValue, listItem0) {
      searchListItems.forEach(searchListItem => {
        let searchListItemText = searchListItem.textContent.toLowerCase();
        if (searchValue) {
          if (-1 < searchListItemText.indexOf(searchValue)) {
            searchListItem.classList.add('d-flex');
            searchListItem.classList.remove('d-none');
            searchListItemsCount++;
          } else {
            searchListItem.classList.add('d-none');
          }
        } else {
          searchListItem.classList.add('d-flex');
          searchListItem.classList.remove('d-none');
          searchListItemsCount++;
        }
      });
      // Display no search fount if searchListItemsCount == 0
      if (searchListItemsCount == 0) {
        listItem0.classList.remove('d-none');
      } else {
        listItem0.classList.add('d-none');
      }
  

    }
    // Send Message
    async function sendMessage(userMessage) {
      if (userMessage) {
        // نمایش پیام کاربر
        let userMessageElement = document.createElement('li');
        userMessageElement.className = 'chat-message chat-message-right';
        userMessageElement.innerHTML = `
                <div class="d-flex overflow-hidden">
                    <div class="flex-grow-1">
                        <div class="chat-message-text">
                            <pre class="mb-0 text-break">${userMessage}</pre>
                        </div>
                    </div>
                </div>
            `;
        const chatHistory = document.querySelector('.chat-history'); // اطمینان از اینکه این عنصر وجود دارد

        chatHistory.appendChild(userMessageElement);
        // بلاک کردن صفحه
        $('#card-block').block({
          message: '<div class="d-flex justify-content-center"><p class="mb-0">منتظر بمانید...</p> <div class="sk-wave m-0"><div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div></div> </div>',
          timeout: 1000,
          css: {
            backgroundColor: 'transparent',
            color: '#fff',
            border: '0'
          },
          overlayCSS: {
            opacity: 0.5
          }
        });

        const messageToSend = {
          Content: userMessage,  // محتوای پیام
          IsResponse: true      // تعیین اینکه این پیام پاسخ نیست
        };
        try {
        const response = await fetch('https://localhost:7230/api/CfApi/SendMessage', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(messageToSend) // تبدیل داده‌ها به فرمت JSON

        });

        if (!response.ok) {
          throw new Error('Network response was not ok');
        }

        const data = await response.json(); // تبدیل پاسخ به JSON
        // نمایش پاسخ سرور
        let aiMessageElement = document.createElement('li');
        aiMessageElement.className = 'chat-message';
        aiMessageElement.innerHTML = `
                    <div class="d-flex overflow-hidden">
                      <pre class="formatted-response">${JSON.stringify(data, null, 2)}</pre> <!-- استفاده از <pre> برای فرمت‌بندی -->
                    </div>
                `;
        chatHistory.appendChild(aiMessageElement);
      } catch (error) {
        alert('خطا در ارسال پیام. لطفا دوباره تلاش کنید.');
        console.log("Error fetching data:", error);
        let errorElement = document.createElement('li');
        errorElement.className = 'chat-message';
        errorElement.innerHTML = `
                    <div class="d-flex overflow-hidden">
                        <div class="chat-message-wrapper flex-grow-1">
                            <div class="chat-message-text">
                                <p class="mb-0">خطا در دریافت پاسخ از سرور.</p>
                            </div>
                        </div>
                    </div>
                `;
        chatHistory.appendChild(errorElement);
      }

       // پاک کردن تکس باکس
        messageInput.value = '';
        // اسکرول به پایین
        scrollToBottom();
        $('#card-block').unblock();

      }
    }

    function createChatContactList(items) {
      // پیدا کردن عنصر <ul> با شناسه مشخص شده
      const ul = document.getElementById('chat-list');
      const messageInput = document.getElementById('message-input');

      // بررسی وجود عنصر <ul>
      if (!ul) {
        console.error('Element with id "chat-list" not found.');
        return;
      }

      // برای هر آیتم در آرایه items، یک عنصر <li> ایجاد کنید
      items.forEach(item => {
        const li = document.createElement('li');
        li.className = 'chat-contact-list-item';

        const a = document.createElement('a');
        a.className = 'd-flex align-items-center';

        const div = document.createElement('div');
        div.className = 'chat-contact-info flex-grow-1 ms-2';

        const h6 = document.createElement('h6');
        h6.className = 'chat-contact-name text-muted  text-truncate m-0';
        h6.textContent = item.question; // متن آیتم را به h6 اضافه کنید

        // اضافه کردن رویداد کلیک برای نوشتن در input
        a.addEventListener('click', () => {
          messageInput.value = item.question; // نوشتن محتوای آیتم در input
        });
        // اضافه کردن عناصر به هم
        div.appendChild(h6);
        a.appendChild(div);
        li.appendChild(a);
        ul.appendChild(li); // اضافه کردن <li> به <ul>
      });
    }



    // مثال‌هایی برای استفاده از تابع


 

    // Send Message
    formSendMessage.addEventListener('submit', e => {
      e.preventDefault();

      if (messageInput.value) {
        const userMessage = messageInput.value.trim();
        const ul = document.getElementById('chat-list');

        const existingItems = Array.from(ul.getElementsByTagName('h6')).map(h => h.textContent);
        if (!existingItems.includes(userMessage)) {
          const examples = [userMessage];
          createChatContactList(examples);
        }
        sendMessage(userMessage);
      }
    });

    // on click of chatHistoryHeaderMenu, Remove data-overlay attribute from chatSidebarLeftClose to resolve overlay overlapping issue for two sidebar
    let chatHistoryHeaderMenu = document.querySelector(".chat-history-header [data-target='#app-chat-contacts']"),
      chatSidebarLeftClose = document.querySelector('.app-chat-sidebar-left .close-sidebar');
    //chatHistoryHeaderMenu.addEventListener('click', e => {
    //  chatSidebarLeftClose.removeAttribute('data-overlay');
    //});
    // }

    // Speech To Text
    if (speechToText.length) {
      var SpeechRecognition = SpeechRecognition || webkitSpeechRecognition;
      if (SpeechRecognition !== undefined && SpeechRecognition !== null) {
        var recognition = new SpeechRecognition(),
          listening = false;
        speechToText.on('click', function () {
          const $this = $(this);
          recognition.onspeechstart = function () {
            listening = true;
          };
          if (listening === false) {
            recognition.start();
          }
          recognition.onerror = function (event) {
            listening = false;
          };
          recognition.onresult = function (event) {
            $this.closest('.form-send-message').find('.message-input').val(event.results[0][0].transcript);
          };
          recognition.onspeechend = function (event) {
            listening = false;
            recognition.stop();
          };
        });
      }
    }

});
