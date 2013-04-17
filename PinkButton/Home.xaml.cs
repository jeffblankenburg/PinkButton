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
        
        public Home()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string imagepath = "Assets/Images/pinkbutton_tapped.png";
            PinkButtonTapped = new BitmapImage(new Uri(imagepath, UriKind.Relative));
            TheButton.Source = PinkButtonTapped;
            imagepath = "Assets/Images/pinkbutton.png";
            PinkButtonNormal = new BitmapImage(new Uri(imagepath, UriKind.Relative));
            TheButton.Source = PinkButtonNormal;
        }

        private void PinkButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
            TheButton.Source = PinkButtonTapped;
        }

        private void PinkButton_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TheButton.Source = PinkButtonNormal;
        }
    }
}