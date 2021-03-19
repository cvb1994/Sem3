using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Collections.ObjectModel;
using NEWSAPI.Models;

namespace NEWSAPI
{
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Article> Articles;
        public MainPage()
        {
            this.InitializeComponent();
            Articles = new ObservableCollection<Article>();
            GetAR("tesla", "2021-02-17", "publishedAt", "20f0bc79a63947818867de418e5f4ab3");
        }

        private async void GetAR(string q, string from, string SortBy, string ApiKey)
        {
            //var url = string.Format("https://newsapi.org/v2/everything?q={0}&from={1}&sortBy={2}&apiKey={3}", q, from, SortBy, ApiKey);
            var url = string.Format("http://newsapi.org/v2/everything?q=tesla&from=2021-02-17&sortBy=publishedAt&apiKey=a033f27b27cc4342a4802d954eca16bd");
            var news = await New.GetNew(url) as RootObject;
            news.articles.ForEach(n => {
                Articles.Add(n);
            });
        }

        private void View_ItemClick(object sender, ItemClickEventArgs e)
        {
            Article ar = e.ClickedItem as Article;
            Frame.Navigate(typeof(ArticleView), ar);
        }
    }
}
