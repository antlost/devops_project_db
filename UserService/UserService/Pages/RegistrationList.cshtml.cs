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
    public class RegistrationListModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<Registration> Registrations { get; private set; }

        public bool HasError { get; private set; }

        public RegistrationListModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            HasError = false;
        }

        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://devopsprojectuserservice.azurewebsites.net/api/Registrations");
            request.Headers.Add("Accept", "text/plain, application/json, text/json");
            
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Registrations = await response.Content.ReadAsAsync<IEnumerable<Registration>>();
            }
            else
            {
                HasError = true;
                Registrations = Array.Empty<Registration>();
            }
        }
    }
}