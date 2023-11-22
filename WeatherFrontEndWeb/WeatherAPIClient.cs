using System;
using System.Net.Http;
using System.Text.Json;
using WeatherForecastLib;

namespace WeatherFrontEndWeb
{
    public class WeatherAPIClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        public WeatherAPIClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = httpClientFactory.CreateClient("weatherappapi");
        }

        public async Task<List<WeatherForecast>> GetWeatherAsync()
        {
            var weatherForecastList = new List<WeatherForecast>();
            var response = await _httpClient.GetAsync("WeatherForecast");
            if (response.IsSuccessStatusCode)
            {
                using (var contentStream = await response.Content.ReadAsStreamAsync())
                {
                    weatherForecastList = 
                        await JsonSerializer.DeserializeAsync<List<WeatherForecast>>(contentStream);
                }
            }

            else
            {
                throw new Exception("http error");
            }

            return weatherForecastList;
        }

    }
}
