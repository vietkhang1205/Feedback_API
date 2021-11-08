using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackSystemAPI.Models
{
    public class UserWithToken : User
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithToken(User user)
        {
            this.UserId = user.RoleId;
            this.Email = user.Email;
            this.Password = user.Password;
            this.RoleId = user.RoleId;
            this.Name = user.Name;
            this.PhoneNumber = user.PhoneNumber;
        }
    }
}
