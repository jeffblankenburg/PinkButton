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

        private void NameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text == "Name") NameBox.Text = "";
        }

        private void NameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text == "") NameBox.Text = "Name";
        }

        private void AddressBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AddressBox.Text == "Address") AddressBox.Text = "";
        }

        private void AddressBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AddressBox.Text == "") AddressBox.Text = "Address";
        }

        private void PhoneBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PhoneBox.Text == "Mobile Phone #") PhoneBox.Text = "";
        }

        private void PhoneBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PhoneBox.Text == "") PhoneBox.Text = "Mobile Phone #";
        }

        private void EmailBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailBox.Text == "Email Address") EmailBox.Text = "";
        }

        private void EmailBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EmailBox.Text == "") EmailBox.Text = "Email Address";
        }

        private void CarModelBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CarModelBox.Text == "Make/Model of your car") CarModelBox.Text = "";
        }

        private void CarModelBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CarModelBox.Text == "") CarModelBox.Text = "Make/Model of your car";
        }

        private void InsuranceBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (InsuranceBox.Text == "Your insurance company") InsuranceBox.Text = "";
        }

        private void InsuranceBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (InsuranceBox.Text == "") InsuranceBox.Text = "Your insurance company";
        }

        private void DeductibleBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DeductibleBox.Text == "Deductible amount") DeductibleBox.Text = "";
        }

        private void DeductibleBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DeductibleBox.Text == "") DeductibleBox.Text = "Deductible amount";
        }

        private void TextMessageBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextMessageBox.Text == "Text message you'd like your emergency contact to receive") TextMessageBox.Text = "";
        }

        private void TextMessageBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextMessageBox.Text == "") TextMessageBox.Text = "Text message you'd like your emergency contact to receive";
        }
    }
}