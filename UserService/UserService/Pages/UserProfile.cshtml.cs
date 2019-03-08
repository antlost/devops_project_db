using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserService.Model;

namespace UserService.Pages
{
    public class UserProfileModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public Registration RegisteredUser { get; private set; }

        public Loyalty UserLoyalty { get; private set; }

        public bool HasError { get; private set; }

        public string UserId {get; private set; }

        public UserProfileModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            HasError = false;
            UserId = "5";
        }

        public async Task OnGet()
        {
            await GetUser();
            await GetLoyaltyPoints();
        }

        private async Task GetUser()
        {
            string registrationUri = $"https://devopsprojectuserservice.azurewebsites.net/api/Registrations/{UserId}";

            var request = new HttpRequestMessage(HttpMethod.Get, registrationUri);
            request.Headers.Add("Accept", "text/plain, application/json, text/json");
            
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                RegisteredUser = await response.Content.ReadAsAsync<Registration>();
            }
            else
            {
                HasError = true;
                RegisteredUser = null;
            }
        }

        private async Task GetLoyaltyPoints()
        {
            string loyaltyUri = $"https://loyaltyservice.azurewebsites.net/api/todo/{UserId}";

            var request = new HttpRequestMessage(HttpMethod.Get, loyaltyUri);
            request.Headers.Add("Accept", "text/plain, application/json, text/json");
            
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                UserLoyalty = await response.Content.ReadAsAsync<Loyalty>();
            }
            else
            {
                HasError = true;
                UserLoyalty = null;
            }
        }
    }
}