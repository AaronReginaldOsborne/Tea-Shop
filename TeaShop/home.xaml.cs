using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace TeaShop
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : Page
    {
        public home()
        {
            InitializeComponent();
            //load user from file
            LoadUserData();
            //load static checkoutList
            lvCheckOut.ItemsSource = StaticCheckOutList.GetList();
            //load video from bin debug
            meVideo.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "my.wmv");
        }

        /*The user has the option to load the user information from file if the file exists or create a new user information*/
        private void LoadUser(object sender, RoutedEventArgs e)
        {
            try
            {
                // grab path from bin debug
                var userPath = AppDomain.CurrentDomain.BaseDirectory + "user.json";
                // read the file and store as a string
                var readText = File.ReadAllText(userPath);
                // deseralize the data
                var json = JsonConvert.DeserializeObject<User>(readText);
                /// set data from Json
                SetUserData(json);
                // load the user to screen
                LoadUserData();
            }
            catch (Exception ex)
            {
                //if they try to load a file that isn't made yet
                MessageBox.Show("Sorry but you need to add a user before loading nothing also here is the error: " + ex);
            }
        }
        /*The user has the option to load the tea order from file if the file exists or create a new order */
        private void LoadCheckout(object sender, RoutedEventArgs e)
        {
            try
            {
                // grab path from bin debug
                var shopPath = AppDomain.CurrentDomain.BaseDirectory + "shop.json";
                // read the file and store as a string
                var readText = File.ReadAllText(shopPath);
                // deseralize the data
                var json = JsonConvert.DeserializeObject<List<CheckOut>>(readText);
                /// set data from Json
                StaticCheckOutList.SetList(json);
                // load the checkout to screen
                lvCheckOut.ItemsSource = StaticCheckOutList.GetList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry but you need to add an Order before loading nothing also here is the error: " + ex);
            }
        }
        // helper methods

        // set user Data
        private void SetUserData(User json)
        {
            StaticUser.FirstName = json.FirstName;
            StaticUser.LastName = json.LastName;
            StaticUser.DateOfBirth = json.DateOfBirth;
            StaticUser.Address = json.Address;
            StaticUser.City = json.City;
            StaticUser.Province = json.Province;
            StaticUser.PostalCode = json.PostalCode;
            StaticUser.PhoneNumber = json.PhoneNumber;
            StaticUser.Email = json.Email;
        }

        // load user Data
        private void LoadUserData()
        {
            tbFirstName.Text = StaticUser.FirstName;
            tbLastName.Text = StaticUser.LastName;
            tbDateOfBirth.Text = StaticUser.DateOfBirth;
            tbAddress.Text = StaticUser.Address;
            tbCity.Text = StaticUser.City;
            tbProvince.Text = StaticUser.Province;
            tbPostalCode.Text = StaticUser.PostalCode;
            tbPhoneNumber.Text = StaticUser.PhoneNumber;
            tbEmail.Text = StaticUser.Email;
        }
    }
}
