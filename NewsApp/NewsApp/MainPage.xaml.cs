using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewsApp
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
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Financial.IsSelected)
            {
                NewsManager.GetNews("Financial", Articles, "tesla", "2021-02-18", "publishedAt", "a033f27b27cc4342a4802d954eca16bd");

                TitleTextBlock.Text = "Financial";
            }
            else if (Food.IsSelected)
            {
                TitleTextBlock.Text = "Food";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Financial.IsSelected = true;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string search = searchTxt.Text;
            Articles.Clear();
            NewsManager.GetNews("Financial", Articles, "tesla", "2021-02-18", "publishedAt", "a033f27b27cc4342a4802d954eca16bd");

        }
    }
}
