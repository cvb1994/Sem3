using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Models
{
    class News
    {
        public async static Task<RootObject> GetNew(string url)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var dataStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var value = serializer.ReadObject(dataStream) as RootObject;

            return value;
        }
    }
    public class NewsManager
    {
        public static async void GetNews(string category, ObservableCollection<Article> Articles, string q, string from, string SortBy, string ApiKey)
        {
            var url = string.Format("https://newsapi.org/v2/everything?q={0}&from={1}&sortBy={2}&apiKey={3}", q, from, SortBy, ApiKey);
            var news = await News.GetNew(url) as RootObject;
            news.articles.ForEach(n => {
                Articles.Add(n);
            });
        }
    }

    public class Source
    {
        public object id { get; set; }
        public string name { get; set; }
    }

    public class Article
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public string publishedAt { get; set; }
        public string content { get; set; }
    }

    public class RootObject
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }
}
