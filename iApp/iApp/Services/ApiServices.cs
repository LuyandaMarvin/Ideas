using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using iApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using iApp.Helpers;
using Newtonsoft.Json.Linq;

namespace iApp.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterAsync(string email, string password, string comfirmPassword)
        {

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = comfirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://localhost:58358/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<string> LoginAsync(string username, string password)
         {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:58358//Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var jwt = await response.Content.ReadAsStringAsync();

           
            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);

            var accessToken = jwtDynamic.Value<string>("access_token");
            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");

            Settings.AccessTokenExpiration = accessTokenExpiration;

            Debug.WriteLine(jwt);

            return accessToken;
        }

        public async Task<List<Idea>> GetIdeasAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync("http://localhost:58358/api/Ideas");

            var ideas = JsonConvert.DeserializeObject<List<Idea>>(json);

            return ideas;
        }

        public async Task<bool> PostIdeaAsync(Idea idea, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(idea);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

           var response = await client.PostAsync("http://localhost:58358/api/Ideas", content);

           return response.IsSuccessStatusCode;
        }

        public async Task PutIdeaAsync(Idea idea, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(idea);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

           var response = await client.PutAsync("http://localhost:58358/api/Ideas/" + idea.Id, content);

           //if (response.)
           //{

           //}
        }

        public async Task DeleteIdeaAsync(int id, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.DeleteAsync("http://localhost:58358/api/Ideas/" + id);
        }

        public async Task<List<Idea>> SearchIdeasAsync(string keyword,string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync("http://localhost:58358/api/Ideas/Search/" + keyword);

            var ideas = JsonConvert.DeserializeObject<List<Idea>>(json);

            return ideas;
        }
    }
}
