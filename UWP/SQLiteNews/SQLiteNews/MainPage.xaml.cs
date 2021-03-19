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
using SQLite.Net.Attributes;
using SQLiteNews.Models;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLiteNews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
            var news = (Root) await News.getNews(url);
            news.articles.ForEach(n => {
                Articles.Add(n);
            });
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void CombackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GridViewConnection_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void NewsItemGrid_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
