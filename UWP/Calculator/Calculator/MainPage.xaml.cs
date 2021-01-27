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
using System.Globalization;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string stringNumber;
        double no_1;
        double no_2;
        double result;
        string _operator;
        bool checkDot = false;
        bool isClear = true;
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void refreshdisplay()
        {
            if(checkDot)
            {
                txtDisplay.Text = stringNumber;
            } 
            else
            {
                string display = string.Format("{0:#,##0}", double.Parse(stringNumber));
                stringNumber = display;
                txtDisplay.Text = display;
            }
            
        }

        public double convertToDouble()
        {
            stringNumber = stringNumber.Replace(",", "");
            double a = double.Parse(stringNumber, CultureInfo.InvariantCulture.NumberFormat);
            return a;
        }

        public string convertToString(double num)
        {
            string a = num.ToString();
            int found = a.IndexOf('.');
            
            string last = a.Substring(found);
            string first = a.Substring(0, a.Length - found);
            string format = string.Format("{0:#,##0}", double.Parse(first));
            string b = string.Concat(format, last);
            return a;
        }

        private void InputNumber(object sender, RoutedEventArgs e)
        {
            string a = (string)(sender as Button).Content;
            stringNumber = string.Concat(stringNumber, a);
            if (a.Equals(".")){
                checkDot = true;
            }
            refreshdisplay();
        }

        private void btClearAll(object sender, RoutedEventArgs e)
        {
            stringNumber = "";
            txtDisplay.Text = "0";
            no_1 = 0;
            no_2 = 0;
            checkDot = false;
            isClear = true;
        }

        private void btAddOperator(object sender, RoutedEventArgs e)
        {
            if(isClear)
            {
                no_1 = convertToDouble();
                isClear = false;
            }
            stringNumber = "";
            string a = (string)(sender as Button).Content;
            switch (a)
            {
                case "+":
                    _operator = "add";
                    break;
                case "-":
                    _operator = "minus";
                    break;

                case "*":
                    _operator = "multiply";
                    break;

                case "/":
                    _operator = "divine";
                    break;

            }

        }

        private void btResult(object sender, RoutedEventArgs e)
        {
            no_2 = convertToDouble();
            switch (_operator)
            {
                case "add":
                    result = no_1 + no_2;
                    no_1 = result;
                    break;
                case "minus":
                    result = no_1 - no_2;
                    no_1 = result;
                    break;
                case "multiply":
                    result = no_1 * no_2;
                    no_1 = result;
                    break;
                case "divine":
                    result = no_1/no_2;
                    no_1 = result;
                    break;
            }

            txtDisplay.Text = result.ToString();
        }

        private void btDelete(object sender, RoutedEventArgs e)
        {
            if(stringNumber.Length > 1)
            {
                stringNumber = stringNumber.Remove(stringNumber.Length - 1);
            } else if (stringNumber.Length == 1)
            {
                stringNumber = "0";
            }
            refreshdisplay();
        }
    }
}
