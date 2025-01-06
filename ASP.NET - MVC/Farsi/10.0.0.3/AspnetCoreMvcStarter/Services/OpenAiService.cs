using AspnetCoreMvcStarter.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace AspnetCoreMvcStarter.Services
{



    public class OpenAiService
    {
        private readonly string _apiKey;

        public OpenAiService()
        {
            _apiKey = "aa-tjWuLOuFw8cXivusXZdbzFnMTYS2b13RvygLsQLkz8yaOCdY";
        }
        public async Task<string> GetSqlQueryFromOpenAi( string questionInPersian, string tableStructure)
        {
           

            //// ترکیب ساختار جدول و سوال کاربر
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            // ترکیب ساختار جدول و سوال کاربر، همراه با تاکید بر اینکه فقط کوئری SQL تولید شود
            var prompt = $"ساختار جدول:\n{tableStructure}\nسوال: {questionInPersian}\n SQL بدون هیچ توضیحی بده ضمنا برای sqllite  میخواهم.";
            //var prompt = $"ساختار جدول:\n{tableStructure}\nسوال :لطفاً یک کوئری SQL بنویس که بر اساس جمله زیر ایجاد شود {questionInPersian}\nفقط کوئری را بدون هیچ توضیح اضافی ارائه بده و در صورت نیاز از like N % استفاده کن ";

            //var requestBody = new
            //{
            //    model = "gpt-4",
            //    prompt = prompt,
            //    max_tokens = 150,
            //    temperature = 0.3,
            //    stop = new[] { "\n" } // اینجا می‌توانیم از stop token استفاده کنیم تا بعد از اولین خط کوئری متوقف شود
            //};

            var requestBody = new
            {
                model = "gpt-4o-mini",
                messages = new[]
              {
                        new { role = "user", content = prompt }
                    }
            };


            var response = await client.PostAsJsonAsync("https://api.avalai.ir/v1/chat/completions", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<dynamic>();
                return result.choices[0].message.content;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                return "خطا در دریافت پاسخ. لطفاً دوباره تلاش کنید." + errorResponse;
            }

        }
    }
}
