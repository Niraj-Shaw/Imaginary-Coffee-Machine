using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineResponse.References
{
    class Weather
    {
        public async Task<double> GetTemperature()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org");
            var response = await client.GetAsync($"/data/2.5/weather?q=Sydney,Australia&units=metric&appid=2d022d33e3b011adff054a5d77fcf146");


            var stringResult = await response.Content.ReadAsStringAsync();

            var obj = JsonConvert.DeserializeObject<dynamic>(stringResult);
            double tmpDegreesC = Math.Round(((float)obj.main.temp), 2);

            return tmpDegreesC;
        }

    }
}
