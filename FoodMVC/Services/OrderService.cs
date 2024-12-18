using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FoodMVC.Services
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44321/");
        }

        public async Task<bool> PlaceOrder(int? userId)
        {
            var order = new { UserId = userId };
            var response = await _httpClient.PostAsJsonAsync("api/Order", order);

            return response.IsSuccessStatusCode;
        }
    }
}