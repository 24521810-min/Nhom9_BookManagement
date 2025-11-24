using System;
using System.Net.Http;

namespace BookManagement.Services
{
    public static class ApiService
    {
        public static HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7214/")
            
        };
    }
}
