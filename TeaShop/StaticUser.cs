using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShop
{
    // a user that you can edit once and will change all instances of it and you call it from everypage
    public static class StaticUser
    {
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string DateOfBirth { get; set; }
        public static string Address { get; set; }
        public static string City { get; set; }
        public static string Province { get; set; }
        public static string PostalCode { get; set; }
        public static string PhoneNumber { get; set; }
        public static string Email { get; set; }

        public static User GetUser()
        {
            User send = new User();
            send.FirstName = StaticUser.FirstName;
            send.LastName = StaticUser.LastName;
            send.DateOfBirth = StaticUser.DateOfBirth;
            send.Address = StaticUser.Address;
            send.City = StaticUser.City;
            send.Province = StaticUser.Province;
            send.PostalCode = StaticUser.PostalCode;
            send.PhoneNumber = StaticUser.PhoneNumber;
            send.Email = StaticUser.Email;
            return send;
        }
    }
}
