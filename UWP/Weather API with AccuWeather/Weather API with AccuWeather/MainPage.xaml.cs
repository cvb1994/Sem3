using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Weather_API_with_AccuWeather.Models;
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

namespace Weather_API_with_AccuWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<WeatherJSON> WeatherEachHours;
        ObservableCollection<DailyForecast> WeatherEachDays;

        public MainPage()
        {
            this.InitializeComponent();
            WeatherEachHours = new ObservableCollection<WeatherJSON>();
            InitJSON();

            WeatherEachDays = new ObservableCollection<DailyForecast>();
            InitEachDaysJSON();
        }

        private async void InitEachDaysJSON()
        {
            var urlFiveDay = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/353412?" +
                "apikey=RAfUtVw4EQYVSzAYvL26llVBLhNyTYZs&metric=true";
            var obj = await WeatherEachDay.GetWeatherEach(urlFiveDay) as WeatherEachDay;
            obj.DailyForecasts.ForEach(it =>
            {
                var matchs = Regex.Matches(it.Date, "\\d+");
                var date = new DateTime(int.Parse(matchs[0].Value), int.Parse(matchs[1].Value), int.Parse(matchs[2].Value));
                it.Date = date.DayOfWeek.ToString();
                it.day.Icon = string.Format("http://vortex.accuweather.com/adc2010/images/slate/icons/{0}.svg", it.day.Icon);
                Debug.WriteLine("Binh: " + it.Date);
                WeatherEachDays.Add(it);
            });
            Today.Text = WeatherEachDays[0].Date + " Today";
            MaxTemperature.Text = WeatherEachDays[0].Temperature.Maximum.Value + "";
            MinTemperature.Text = WeatherEachDays[0].Temperature.Minimum.Value + "";
            WeatherEachDays.RemoveAt(0);
        }

        private async void InitJSON()
        {
            var url = "http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/353412?" + "apikey=RAfUtVw4EQYVSzAYvL26llVBLhNyTYZs&metric=true";
            var list = await WeatherJSON.getJSON(url) as List<WeatherJSON>;
            Debug.WriteLine("Count: " + list.Count);

            list.ForEach(it =>
            {
                var match = Regex.Matches(it.dateTime, "T(?<time>\\d+):")[0].Groups["time"].Value;
                if (int.Parse(match) > 12)
                {
                    match = (int.Parse(match) - 12) + "PM";
                }
                else
                {
                    match += "PM";
                }
                it.dateTime = match;
                it.temperature.value += "\u00B0";
                it.weatherIcon = string.Format("http://vortex.accuweather.com/adc2010/images/slate/icons/{0}.svg", it.weatherIcon);

                WeatherEachHours.Add(it);
            });
            WeatherDescriptionTextBlock.Text = list[0].iconPhrase;
            WeatherTemperatureTextBlock.Text = list[0].temperature.value;
        }
    }
}
