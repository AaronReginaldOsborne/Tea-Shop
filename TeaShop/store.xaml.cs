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
    /// Interaction logic for store.xaml
    /// </summary>
    public partial class store : Page
    {
        TeaList teas;
        CheckOut item;
        public store()
        {
            InitializeComponent();
            // create a teas list object
            teas = new TeaList();

            // load combobox of teas
            for (var i = 0; i < teas.Length(); ++i)
                cbTeas.Items.Add(teas.GetTea(i).Name);

            //set data for first tea object
            imgTeaPicture.Source = new BitmapImage(new Uri(teas.GetTea(0).Image, UriKind.Relative));
            tbName.Text = teas.GetTea(0).Name;
            tbDescription.Text = teas.GetTea(0).Description;
            tbCost.Text = string.Format("${0:0.00}", teas.GetTea(0).Cost);

            //enable button when your checkoutlist is bigger than 0
            if(StaticCheckOutList.Count() != 0)
                btnProccedToCheckOut.IsEnabled = true;

            //load combo box
            lvCheckOut.ItemsSource = StaticCheckOutList.GetList();
        }

        private void CbTeas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // grab the combo box index
            int currentMyComboBoxIndex = cbTeas.SelectedIndex;

            // set values
            imgTeaPicture.Source = new BitmapImage(new Uri(teas.GetTea(currentMyComboBoxIndex).Image, UriKind.Relative));
            tbName.Text = teas.GetTea(currentMyComboBoxIndex).Name;
            tbDescription.Text = teas.GetTea(currentMyComboBoxIndex).Description;
            tbCost.Text = string.Format("${0:0.00}", teas.GetTea(currentMyComboBoxIndex).Cost);

            //reset the index to blank
            cbSize.SelectedIndex = -1;
            cbQty.SelectedIndex = -1;
        }

        private void AddToCartOnClick(object sender, RoutedEventArgs e)
        {
            // grab the combo box index
            int currentMyComboBoxIndex = cbTeas.SelectedIndex;

            item = new CheckOut();
            item.ProductName = teas.GetTea(currentMyComboBoxIndex).Name;
            item.ProductDescription = teas.GetTea(currentMyComboBoxIndex).Description;

            SetDefaultColors();
            //if valid
            if (IsValid())
            {
                item.ProductSize = cbSize.Text;
                item.Quntity = Int32.Parse(cbQty.Text);
                item.ProductCost = teas.GetTea(currentMyComboBoxIndex).Cost;
                item.ProductTotal = item.ProductCost * item.Quntity;

                //use the message queue to send a message.
                var messageQueue = SnackbarAdded.MessageQueue;
                var message = item.Quntity + " " + item.ProductName + " Added";

                //the message queue can be called from any thread
                Task.Factory.StartNew(() => messageQueue.Enqueue(message));
                StaticCheckOutList.Add(item);

                //load items into list view from static object
                lvCheckOut.Items.Refresh();

                btnProccedToCheckOut.IsEnabled = true;
            }
        }

        private void ProceedToCheckOutOnClick(object sender, RoutedEventArgs e)
        {
            Checkout checkout = new Checkout();
            NavigationService.Navigate(checkout);
        }

        //helper methods
        // set colors to red if error
        private bool IsValid()
        {
            bool isValid = true;
            if (cbSize.SelectedIndex == -1)
            {
                isValid = false;
                cbSize.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89FF0000"));
                cbSize.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF70505"));
            }
            if (cbQty.SelectedIndex == -1)
            {
                isValid = false;
                cbQty.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89FF0000"));
                cbQty.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF70505"));
            }

            return isValid;
        }

        // set to default colors
        private void SetDefaultColors()
        {
            cbSize.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            cbSize.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            cbQty.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            cbQty.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
        }

        private void LvCheckOut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
