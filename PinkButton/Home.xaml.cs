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

namespace PinkButton
{
    public partial class Home : PhoneApplicationPage
    {
        BitmapImage PinkButtonTapped;
        BitmapImage PinkButtonNormal;
        BitmapImage UpdateTapped;
        BitmapImage UpdateNormal;
        
        public Home()
        {
            InitializeComponent();
            Loaded += Home_Loaded;
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
            base.OnNavigatedTo(e);
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