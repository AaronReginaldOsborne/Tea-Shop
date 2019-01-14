using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeaShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* Startup Window, Personal Information Window, Tea Order Window, and Checkout Window created as specified with proper user prompts and groups */
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new home();
        }


        private void HomeOnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new home();
        }

        private void PersonalInfoOnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new Personal_Information();
        }

        private void StoreOnClick(object sender, RoutedEventArgs e)
        {
            //disable store if the user isn't set
            if (StaticUser.FirstName != null)
                Main.Content = new store();
        }

        private void CheckOutOnClick(object sender, RoutedEventArgs e)
        {
            //disable button if the user isn't set and checkoutlist isn't set
            if (StaticUser.FirstName != null&& StaticCheckOutList.Count() != 0)
                Main.Content = new Checkout();
        }

        // helpers display and smaller the menu
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        //might use later
        private void Close(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
