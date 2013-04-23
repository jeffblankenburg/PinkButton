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
using System.Windows.Navigation;
using System.Text.RegularExpressions;

namespace PinkButton
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            bool AllowSkip = true;
            if (App.settings.Contains("name")) NameBox.Text = App.settings["name"].ToString();
            else AllowSkip = false;
            if (App.settings.Contains("address")) AddressBox.Text = App.settings["address"].ToString();
            else AllowSkip = false;
            if (App.settings.Contains("phone")) PhoneBox.Text = App.settings["phone"].ToString();
            else AllowSkip = false;
            if (App.settings.Contains("email")) EmailBox.Text = App.settings["email"].ToString();
            else AllowSkip = false;
            if (App.settings.Contains("carmodel")) CarModelBox.Text = App.settings["carmodel"].ToString();
            if (App.settings.Contains("insurance")) InsuranceBox.Text = App.settings["insurance"].ToString();
            if (App.settings.Contains("deductible")) DeductibleBox.Text = App.settings["deductible"].ToString();
            if (App.settings.Contains("textmessage")) TextMessageBox.Text = App.settings["textmessage"].ToString();

            if (AllowSkip == true) SkipButton.Opacity = 1;
        }

        private void SkipButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SkipButton.Opacity == 1) GoHome();
        }

        private void SaveButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SaveData()) NavigationService.Navigate(new Uri("/ThankYou.xaml", UriKind.Relative));
            else ValidateData();
        }

        public bool IsValidEmail(string s)
        {
                if (string.IsNullOrEmpty(s))
                    return false;
                else
                {
                    var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                    return regex.IsMatch(s) && !s.EndsWith(".");
                }
        }

        private void ValidateData()
        {
            if (NameBox.Text == "Name") NameBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0xED, 0x27, 0x93));
            if (AddressBox.Text == "Address") AddressBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0xED, 0x27, 0x93));
            if (PhoneBox.Text == "Mobile Phone #") PhoneBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0xED, 0x27, 0x93));
            if (EmailBox.Text == "Email Address") EmailBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0xED, 0x27, 0x93));
            if (!IsValidEmail(EmailBox.Text)) EmailBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0xED, 0x27, 0x93));
        }

        private bool SaveData()
        {
            bool valid = true;
            if (NameBox.Text != "Name") App.settings["name"] = NameBox.Text;
            else valid = false;
            if (AddressBox.Text != "Address") App.settings["address"] = AddressBox.Text;
            else valid = false;
            if (PhoneBox.Text != "Mobile Phone #") App.settings["phone"] = PhoneBox.Text;
            else valid = false;
            if ((EmailBox.Text != "Email Address") && (IsValidEmail(EmailBox.Text))) App.settings["email"] = EmailBox.Text;
            else valid = false;
            if (CarModelBox.Text != "Make/Model of your car") App.settings["carmodel"] = CarModelBox.Text;
            if (InsuranceBox.Text != "Your insurance company") App.settings["insurance"] = InsuranceBox.Text;
            if (DeductibleBox.Text != "Deductible amount") App.settings["deductible"] = DeductibleBox.Text;
            if (TextMessageBox.Text != "Text message you'd like your emergency contact to receive") App.settings["textmessage"] = TextMessageBox.Text;
            return valid;
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