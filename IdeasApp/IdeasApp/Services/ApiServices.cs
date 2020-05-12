using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using IdeasApp.Models;
using Newtonsoft.Json;

namespace IdeasApp.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterAsync(string email, string password, string comfirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = comfirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            var response = await client.PostAsync("https://localhost:44341/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }
    }
}
