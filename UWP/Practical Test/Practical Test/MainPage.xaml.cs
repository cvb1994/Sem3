using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
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

namespace Practical_Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public SQLiteConnection conn = new SQLiteConnection("examDB.db");
        List<String> items = new List<String>();
        List<String> listPhone = new List<String>();

        public MainPage()
        {
            this.InitializeComponent();
            SQLiteConnection conn = new SQLiteConnection("examDB.db");
            string sql = @"CREATE TABLE IF NOT EXISTS Contact (Id Integer Primary Key AutoIncrement Not null
                        , name varchar(255), phoneNumber varchar(255)
                        );";
            SQLiteStatement statment = (SQLiteStatement)conn.Prepare(sql);
            statment.Step();
        }


        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nametxt.Text;
            string phone = phonetxt.Text;

            string select = @"Select * from contact where phoneNumber = '" + phone + "';";
            ISQLiteStatement dbState = (SQLiteStatement)conn.Prepare(select);
            while (dbState.Step() == SQLiteResult.ROW)
            {
                string nameContact = dbState["name"] as string;
                string phoneNumber = dbState["phone"] as string;
                items.Add(nameContact + "    " + phoneNumber);
                listPhone.Add(phoneNumber);
            }
            foreach (string s in listPhone)
            {
                if (s != phone)
                {
                    string sql = @"Insert into Contact (name, phoneNumber) values ('" + name + "', '" + phone + "'  ); ";
                    SQLiteStatement statment = (SQLiteStatement)conn.Prepare(sql);
                    statment.Step();
                }
                else
                {
                   // Message.Text = "Số điện thoại đã tồn tại";
                }
            }
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
