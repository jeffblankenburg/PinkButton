using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;
using System.Device.Location;

namespace PinkButton
{
    public partial class Home : PhoneApplicationPage
    {
        BitmapImage PinkButtonTapped;
        BitmapImage PinkButtonNormal;
        BitmapImage UpdateTapped;
        BitmapImage UpdateNormal;
        GeoCoordinateWatcher gcw;
        double Latitude = 0;
        double Longitude = 0;
        
        public Home()
        {
            InitializeComponent();
            Loaded += Home_Loaded;
            gcw = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            gcw.PositionChanged += gcw_PositionChanged;
            gcw.Start();
        }

        void gcw_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Latitude = e.Position.Location.Latitude;
            Longitude = e.Position.Location.Longitude;
        }

        void Home_Loaded(object sender, RoutedEventArgs e)
        {
            TheButton.Source = PinkButtonTapped;
            TheButton.Source = PinkButtonNormal;
            UpdateButton.Source = UpdateTapped;
            UpdateButton.Source = UpdateNormal;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.settings.Contains("firsttime"))
            {
                App.settings["firsttime"] = true;
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }


            string imagepath = "Assets/Images/pinkbutton_tapped.png";
            PinkButtonTapped = new BitmapImage(new Uri(imagepath, UriKind.Relative));
            
            imagepath = "Assets/Images/pinkbutton.png";
            PinkButtonNormal = new BitmapImage(new Uri(imagepath, UriKind.Relative));

            imagepath = "Assets/Images/button_clickheretoupdateyourinfo_tapped.png";
            UpdateTapped = new BitmapImage(new Uri(imagepath, UriKind.Relative));
            
            imagepath = "Assets/Images/button_clickheretoupdateyourinfo.png";
            UpdateNormal = new BitmapImage(new Uri(imagepath, UriKind.Relative));
            
        }

        private void PinkButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TheButton.Source = PinkButtonTapped;
        }

        private void PinkButton_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TheButton.Source = PinkButtonNormal;
            SendEmail();
        }

        private void SendEmail()
        {
            if (App.settings.Contains("name"))
            {
                EmailComposeTask ect = new EmailComposeTask();
                ect.To = "pinkbutton3c@gmail.com";
                ect.Subject = "Pink Button Alert! (Windows Phone)";
                ect.Body += "Name: " + App.settings["name"].ToString() + "\n";
                ect.Body += "Address: " + App.settings["address"].ToString() + "\n";
                ect.Body += "Mobile: " + App.settings["phone"].ToString() + "\n";
                ect.Body += "Email: " + App.settings["email"].ToString() + "\n";
                ect.Body += "Location: http://www.bing.com/maps/default.aspx?rtp=pos." + Latitude + "_" + Longitude + "\n";
                //http://www.bing.com/maps/default.aspx?rtp=pos.31_-81~pos.32_-84
                if (App.settings.Contains("carmodel")) ect.Body += "Car Make/Model: " + App.settings["carmodel"].ToString() + "\n";
                if (App.settings.Contains("insurance")) ect.Body += "Insurance: " + App.settings["insurance"].ToString() + "\n";
                if (App.settings.Contains("deductible")) ect.Body += "Deductible: " + App.settings["deductible"].ToString() + "\n";
                ect.Show();
            }
            else
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            
        }

        private void Update_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UpdateButton.Source = UpdateTapped;
        }

        private void Update_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UpdateButton.Source = UpdateNormal;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}