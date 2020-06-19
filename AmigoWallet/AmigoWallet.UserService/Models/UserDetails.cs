using System;
using System.Collections.Generic;

namespace AmigoWallet.UserService.Models
{
    public partial class UserDetails
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public long PhoneNumber { get; set; }
        public string CardNumber { get; set; }
        public string Password { get; set; }
    }
}
