using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TeaShop
{
    /// <summary>
    /// Interaction logic for checkout.xaml
    /// </summary>
    public partial class Checkout : Page
    {
        private double subtotal;
        int listViewIndex;
        public Checkout()
        {
            DataContext = this;
            InitializeComponent();

            //load items into list view from static object
            lvCheckOut.ItemsSource = StaticCheckOutList.GetList();
            for (var i = 0; i < StaticCheckOutList.Count(); ++i)
                subtotal += StaticCheckOutList.GetByIndex(i).ProductTotal;

            //load sub-total tax and grand total
            tbSubTotal.Text = string.Format("${0:0.00}", subtotal);
            tbTax.Text = string.Format("${0:0.00}", (subtotal * 0.13));
            tbTotal.Text = string.Format("${0:0.00}", (subtotal * 1.13));

            //set mail address from static user
            tbMailAddress.Text = StaticUser.Address;
        }

        /* Correctly saves all user information (personal information and order) to a file(s) when user clicks Purchase Order */
        private void BtnPurchaseOrderOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // get User Creditcard from textfield
                string number = tbCreditCard.Text;
                //do luhn algorithm https://en.wikipedia.org/wiki/Luhn_algorithm
                if (DoLuhn(number))
                {
                    //create Json String from the static user
                    string Userjson = JsonConvert.SerializeObject(StaticUser.GetUser());
                    //create Json String from the static checkout
                    string Shoppingjson = JsonConvert.SerializeObject(StaticCheckOutList.GetList());
                    
                    //set Paths
                    var userPath = AppDomain.CurrentDomain.BaseDirectory + "user.json";
                    var shopPath = AppDomain.CurrentDomain.BaseDirectory + "shop.json";

                    //write to files
                    File.WriteAllText(userPath, Userjson);
                    File.WriteAllText(shopPath, Shoppingjson);

                    //use the message queue to send a message.
                    var messageQueue = SnackbarAdded.MessageQueue;
                    var message = "Your Order has been Sent for proccessing";

                    //the message queue can be called from any thread
                    Task.Factory.StartNew(() => messageQueue.Enqueue(message));
                }
                else
                    tbCreditCard.Text = "invalid credit card number";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to write to file :" + ex.ToString());
            }
        }

        protected bool DoLuhn(string number)
        {
            //if user didn't put a number
            if (number == "")
                return false;
            // From the rightmost digit, moving left through every digit
            int sum = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                // Get the digit's numeric value
                int value = number[i] - '0';

                // If this is an digit that is an odd number of postions from the last digit
                int offsetFromLast = number.Length - 1 - i;
                if (offsetFromLast % 2 != 0)
                {
                    // Double the digit's value
                    value *= 2;

                    // If the product of this doubling operation is greater than 9, then sum the digits of the product 
                    // (NOTE: same as subtracting 9 for sums less than 20 and greater than 9)
                    if (value > 9)
                        value -= 9;
                }

                // Add it to the sum
                sum += value;
            }

            // If the sum modulo 10 is equal to 0 then the number is valid 
            return sum % 10 == 0;
        }

        private void UpdateOnClick(object sender, RoutedEventArgs e)
        {
            if (tbChangeQty.Text != "")
            {
                // if the user types a letter or anything else don't crash
                bool isNumeric = int.TryParse(tbChangeQty.Text, out int n);
                if (isNumeric)
                {
                    //if user puts number 0 or negative
                    if (Convert.ToInt32(tbChangeQty.Text) <= 0)
                    {
                        StaticCheckOutList.EditQty(listViewIndex, 0);
                    }
                    else
                        StaticCheckOutList.EditQty(listViewIndex, Convert.ToInt32(tbChangeQty.Text));
                    lvCheckOut.Items.Refresh();

                    //load sub-total tax and grand total
                    subtotal = 0;
                    for (var i = 0; i < StaticCheckOutList.Count(); ++i)
                        subtotal += StaticCheckOutList.GetByIndex(i).ProductTotal;
                    tbSubTotal.Text = string.Format("${0:0.00}", subtotal);
                    tbTax.Text = string.Format("${0:0.00}", (subtotal * 0.13));
                    tbTotal.Text = string.Format("${0:0.00}", (subtotal * 1.13));
                }
                else
                {
                    // show the user the error
                    tbProductName.Text = "Not a number";
                }
            }
        }

        private void LvCheckOut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //display values to user
            listViewIndex = lvCheckOut.SelectedIndex;
            tbProductName.Text = StaticCheckOutList.GetByIndex(listViewIndex).ProductName;
            tbChangeQty.Text = StaticCheckOutList.GetByIndex(listViewIndex).Quntity.ToString();
        }
    }
}
