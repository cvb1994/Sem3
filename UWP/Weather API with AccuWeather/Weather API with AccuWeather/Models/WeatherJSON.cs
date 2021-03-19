using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Weather_API_with_AccuWeather.Models
{
    public class Temperature
    {
        public string value { get; set; }
        public string unit { get; set; }
        public int unitType { get; set; }
    }
    public class WeatherJSON
    {
        public string dateTime { get; set; }
        public int EpochDateTime { get; set; }
        public string weatherIcon { get; set; }
        public string iconPhrase { get; set; }
        public string isDayLight { get; set; }
        public Temperature temperature { get; set; }
        public int PrecipitationProbability { get; set; }
        public string mobileLink { get; set; }
        public string link { get; set; }

        public async static Task<List<WeatherJSON>> getJSON(string url)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(List<WeatherJSON>));
            var dataStream = new MemoryStream(Encoding.UTF8.GetBytes(result));

            var value = serializer.ReadObject(dataStream) as List<WeatherJSON>;
            return value;
        }
    }
}
