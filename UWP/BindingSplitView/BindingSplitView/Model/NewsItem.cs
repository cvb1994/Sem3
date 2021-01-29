using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingSplitView.Model
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string  Category { get; set; }
        public string Headline { get; set; }
        public string Subhead { get; set; }
        public string DateLine { get; set; }
        public string Image { get; set; }
    }

    public class NewsManager
    {
        private static List<NewsItem> GetNewsItems()
        {
            var items = new List<NewsItem>();

            items.Add(new NewsItem { Id = 1, Category = "Financial", Headline = "abcad", Subhead = "asdga", DateLine = "aadsgoj", Image = "Assets/Financial.png" });
            items.Add(new NewsItem { Id = 2, Category = "Financial", Headline = "fdg", Subhead = "wtr", DateLine = "werg", Image = "Assets/Financial2.png" });
            items.Add(new NewsItem { Id = 3, Category = "Financial", Headline = "abcergad", Subhead = "asdgwerga", DateLine = "aadsgoj", Image = "Assets/Financial3.png" });
            items.Add(new NewsItem { Id = 4, Category = "Financial", Headline = "erg", Subhead = "werg", DateLine = "werg", Image = "Assets/Financial4.png" });
            items.Add(new NewsItem { Id = 5, Category = "Financial", Headline = "ergerg", Subhead = "werg", DateLine = "aadsgoj", Image = "Assets/Financial5.png" });

            return items;
        }

        public static void GetNews(string category, ObservableCollection<NewsItem> newsItems)
        {
            var allItems = GetNewsItems();
            var filteredNewsItems = allItems.Where(p => p.Category == category).ToList();
            newsItems.Clear();
            filteredNewsItems.ForEach(p => newsItems.Add(p));
        }
    }
}
