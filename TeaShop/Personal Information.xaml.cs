using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TeaShop
{
    /// <summary>
    /// Interaction logic for Personal_Information.xaml
    /// </summary>
    public partial class Personal_Information : Page
    {
        User Person = new User();
        public Personal_Information()
        {
            InitializeComponent();

            //load combo box
            cbProvince.Items.Add("Alberta");
            cbProvince.Items.Add("British Columbia");
            cbProvince.Items.Add("Manitoba");
            cbProvince.Items.Add("New Brunswick");
            cbProvince.Items.Add("Newfoundland and Labrador");
            cbProvince.Items.Add("Nova Scotia");
            cbProvince.Items.Add("Northwest Territories");
            cbProvince.Items.Add("Nunavut");
            cbProvince.Items.Add("Ontario");
            cbProvince.Items.Add("Prince Edward Island");
            cbProvince.Items.Add("Quebec");
            cbProvince.Items.Add("Saskatchewan");
            cbProvince.Items.Add("Yukon");

            //Can switch to two letters if needed
            //cbProvince.Items.Add("AB");
            //cbProvince.Items.Add("BC");
            //cbProvince.Items.Add("MB");
            //cbProvince.Items.Add("NB");
            //cbProvince.Items.Add("NL");
            //cbProvince.Items.Add("NS");
            //cbProvince.Items.Add("NT");
            //cbProvince.Items.Add("NU");
            //cbProvince.Items.Add("ON");
            //cbProvince.Items.Add("PE");
            //cbProvince.Items.Add("QC");
            //cbProvince.Items.Add("SK");
            //cbProvince.Items.Add("YT");
            LoadUserData();
        }

        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                StaticUser.FirstName = tbFirstName.Text;
                StaticUser.LastName = tbLastName.Text;
                StaticUser.DateOfBirth = dpDateOfBirth.Text;
                StaticUser.Address = tbAddress.Text;
                StaticUser.City = tbCity.Text;
                StaticUser.Province = cbProvince.Text;
                StaticUser.PostalCode = tbPostalCode.Text;
                StaticUser.PhoneNumber = tbPhoneNumber.Text;
                StaticUser.Email = tbEmail.Text;
                home home = new home();
                this.NavigationService.Navigate(home);
            }
        }

        // cancle pressed and they want to go home
        private void OnYesClick(object sender, RoutedEventArgs e)
        {
            home homePage = new home();
            this.NavigationService.Navigate(homePage);
        }
        // helper methods 

        // load data to screen
        private void LoadUserData()
        {
            tbFirstName.Text = StaticUser.FirstName;
            tbLastName.Text = StaticUser.LastName;
            dpDateOfBirth.Text = StaticUser.DateOfBirth;
            tbAddress.Text = StaticUser.Address;
            tbCity.Text = StaticUser.City;
            cbProvince.Text = StaticUser.Province;
            tbPostalCode.Text = StaticUser.PostalCode;
            tbPhoneNumber.Text = StaticUser.PhoneNumber;
            tbEmail.Text = StaticUser.Email;
        }

        // validation add color
        private bool IsValid()
        {
            bool isValid = true;
            SetDefaultColors();
            if (tbFirstName.Text == "")
            {
                tbFirstName.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89FF0000"));
                tbFirstName.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF70505"));
                isValid = false;
            }
            if (tbLastName.Text == "")
            {
                tbLastName.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89FF0000"));
                tbLastName.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF70505"));
                isValid = false;
            }
            if (dpDateOfBirth.Text == "")
            {
                dpDateOfBirth.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89FF0000"));
                dpDateOfBirth.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF70505"));
                isValid = false;
            }
            if (tbAddress.Text == "")
            {
                tbAddress.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89FF0000"));
                tbAddress.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF70505"));
                isValid = false;
            }
            if (tbCity.Text == "")
            {
                tbCity.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89FF0000"));
                tbCity.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF70505"));
                isValid = false;
            }
            if (cbProvince.Text == null)
            {
                cbProvince.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89FF0000"));
                cbProvince.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF70505"));
                isValid = false;
            }
            if (PostalCodeValidation())
            {
                tbPostalCode.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89FF0000"));
                tbPostalCode.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF70505"));
                isValid = false;
            }
            if (PhoneNumberValidation())
            {
                tbPhoneNumber.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89FF0000"));
                tbPhoneNumber.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF70505"));
                isValid = false;
            }
            if (EmailValidation())
            {
                tbEmail.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#89FF0000"));
                tbEmail.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF70505"));
                isValid = false;
            }
            //PostalCodeValidation();
            return isValid;
        }


        // reset color
        private void SetDefaultColors()
        {
            tbFirstName.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            tbFirstName.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));

            tbLastName.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            tbLastName.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));


            dpDateOfBirth.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            dpDateOfBirth.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));

            tbAddress.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            tbAddress.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));


            tbCity.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            tbCity.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));


            cbProvince.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            cbProvince.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));


            tbPostalCode.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            tbPostalCode.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));

            tbPhoneNumber.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            tbPhoneNumber.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));

            tbEmail.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
            tbEmail.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
        }

        private bool PostalCodeValidation()
        {
            bool isBad;
            var regex = @"^[A-Za-z][0-9][A-Za-z][ -]?[0-9][A-Za-z][0-9]";

            Match match = Regex.Match(tbPostalCode.Text, regex, RegexOptions.IgnoreCase);

            if (tbPostalCode.Text != string.Empty && match.Success)
            {
                isBad = false;
            }
            else
            {
                tbPostalCode.Text = "invalid try N5Z-5C8";
                isBad = true;
            }
            return isBad;
        }

        private bool PhoneNumberValidation()
        {
            bool isBad;
            var regex = @"^\(?[0-9][0-9][0-9][\)\-\s]?[0-9][0-9][0-9][\s]?[-]?[0-9][0-9][0-9][0-9]";

            Match match = Regex.Match(tbPhoneNumber.Text, regex, RegexOptions.IgnoreCase);

            if (tbPhoneNumber.Text != string.Empty && match.Success)
            {
                isBad = false;
            }
            else
            {
                tbPhoneNumber.Text = "invalid try (519)932-0405";
                isBad = true;
            }
            return isBad;
        }

        private bool EmailValidation()
        {
            bool isBad;
            var regex = @"^\S*\w*\@\w*\.\w*";

            Match match = Regex.Match(tbEmail.Text, regex, RegexOptions.IgnoreCase);

            if (tbEmail.Text != string.Empty && match.Success)
            {
                isBad = false;
            }
            else
            {
                tbEmail.Text = "invalid try agoldfish@fish.com";
                isBad = true;
            }
            return isBad;
        }
    }
}
