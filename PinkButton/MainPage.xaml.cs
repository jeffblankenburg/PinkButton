using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PinkButton
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void SkipButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GoHome();
        }

        private void SaveButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GoHome();
        }

        private void GoHome()
        {
            NavigationService.Navigate(new Uri("/Home.xaml", UriKind.Relative));
        }
    }
}