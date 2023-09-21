using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAuthenticationAPI.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "brian_admin", EmailAddress = "brian.admin@email.com", Password = "Pass.12345", GivenName = "Brian", Surname = "Dol", Role = "Administrator" },
            new UserModel() { Username = "kelvin_seller", EmailAddress = "kelvin.seller@email.com", Password = "Pass.98765", GivenName = "Kelvin", Surname = "Dol", Role = "Seller" },
        };
    }
}
